using System;
using System.Collections.Generic;

namespace PlainElastic.Net.Tests.Builders
{
    public enum State {Active, UnderTest, Disabled, New }

    public class FieldsTestClass
    {
        public string StringProperty { get; set; }
        public int IntProperty { get; set; }
        public bool BoolProperty { get; set; }
        public State EnumProperty { get; set; }
        public DateTime DateProperty { get; set; }
        public FieldsTestClass ObjectProperty { get; set; }
        public List<FieldsTestClass> CollectionProperty { get; set; }
        public GeoPointClass GeoPointProperty { get; set; }
    }

    public class GeoPointClass
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

    public class AnotherTestClass: FieldsTestClass
    {
        public string AnotherProperty { get; set; }
    }
}