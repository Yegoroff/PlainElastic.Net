namespace PlainElastic.Net.Tests.Buildres
{
    public enum State {Active, UnderTest, Disabled }

    public class FieldsTestClass
    {
        public string StringProperty { get; set; }
        public bool BoolProperty { get; set; }
        public State EnumProperty { get; set; }
    }
}