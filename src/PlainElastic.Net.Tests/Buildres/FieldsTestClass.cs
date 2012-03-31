using System.Collections.Generic;

namespace PlainElastic.Net.Tests.Buildres
{
    public enum State {Active, UnderTest, Disabled, New }

    public class FieldsTestClass
    {
        public string StringProperty { get; set; }
        public bool BoolProperty { get; set; }
        public State EnumProperty { get; set; }
        public List<FieldsTestClass> CollectionProperty { get; set; }
    }
}