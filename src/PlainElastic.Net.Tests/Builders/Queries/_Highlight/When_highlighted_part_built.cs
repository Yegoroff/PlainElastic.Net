using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(Highlight<>))]
    class When_highlighted_part_built
    {
        Because of = () => result = new Highlight<FieldsTestClass>()
                                                .PreTags("<One>", "<Two>")
                                                .PostTags("</One>", "</Two>")
                                                .TagsSchema(HighlightTagsSchema.styled)
                                                .Order(HighlightOrder.score)
                                                .HighlightFilter(true)
                                                .FragmentSize(15)
                                                .NumberOfFragments(25)
                                                .Encoder(HighlightEncoder.html)
                                                .RequireFieldMatch(true)
                                                .BoundaryMaxScan(16)
                                                .BoundaryChars(",./!")
                                                .Type(HighlighterType.fvh)
                                                .Fragmenter(HighlightFragmenter.simple)
                                                .Fields(
                                                    f => f.FieldName(c => c.StringProperty).NumberOfFragments(8).Encoder(HighlightEncoder.html).Order(HighlightOrder.score),
                                                    f => f.FieldName("CustomField")
                                                )
                                                .ToString();

        It should_starts_with_highlight_declaration = () =>
            result.ShouldStartWith("'highlight': ".AltQuote());

        It should_contain_pre_tags_part = () => result.ShouldContain("'pre_tags': ['<One>','<Two>']".AltQuote());

        It should_contain_post_tags_part = () => result.ShouldContain("'post_tags': ['</One>','</Two>']".AltQuote());

        It should_contain_tags_schema_part = () => result.ShouldContain("'tags_schema': 'styled'".AltQuote());

        It should_contain_order_part = () => result.ShouldContain("'order': 'score'".AltQuote());

        It should_contain_highlight_filter_part = () => result.ShouldContain("'highlight_filter': true".AltQuote());

        It should_contain_fragment_size_part = () => result.ShouldContain("'fragment_size': 15".AltQuote());
        
        It should_contain_number_of_fragments_part = () => result.ShouldContain("'number_of_fragments': 25".AltQuote());

        It should_contain_encoder_part = () => result.ShouldContain("'encoder': 'html'".AltQuote());

        It should_contain_require_field_match_part = () => result.ShouldContain("'require_field_match': true".AltQuote());

        It should_contain_boundary_max_scan_part = () => result.ShouldContain("'boundary_max_scan': 16".AltQuote());

        It should_contain_boundary_chars_part = () => result.ShouldContain("'boundary_chars': ',./!'".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'fvh'".AltQuote());

        It should_contain_fragmenter_part = () => result.ShouldContain("'fragmenter': 'simple'".AltQuote());

        It should_contain_StringProperty_field = () => result.ShouldContain("{ 'StringProperty': { 'number_of_fragments': 8,'encoder': 'html','order': 'score' } }".AltQuote());

        It should_contain_CustomField_field = () => result.ShouldContain("{ 'CustomField': {  } }".AltQuote());

        It should_return_correct_JSON = () => result.ShouldEqual(("'highlight': { " +
                                                                    "'pre_tags': ['<One>','<Two>']," +
                                                                    "'post_tags': ['</One>','</Two>']," +
                                                                    "'tags_schema': 'styled'," +
                                                                    "'order': 'score'," +
                                                                    "'highlight_filter': true," +
                                                                    "'fragment_size': 15," +
                                                                    "'number_of_fragments': 25," +
                                                                    "'encoder': 'html'," +
                                                                    "'require_field_match': true," +
                                                                    "'boundary_max_scan': 16," +
                                                                    "'boundary_chars': ',./!'," +
                                                                    "'type': 'fvh'," +
                                                                    "'fragmenter': 'simple'," +
                                                                    "'fields': [ "+ 
                                                                        "{ 'StringProperty': { 'number_of_fragments': 8,'encoder': 'html','order': 'score' } }," +
                                                                        "{ 'CustomField': {  } } " +
                                                                    "] " +
                                                                 "}").AltQuote());

        private static string result;
    }
}
