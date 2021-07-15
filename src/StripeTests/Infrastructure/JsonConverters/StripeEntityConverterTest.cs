namespace StripeTests
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Stripe;
    using Xunit;

    public class StripeEntityConverterTest : BaseStripeTest
    {
        [Fact]
        public void DeserializeNull()
        {
            var json = "null";
            var obj = JsonConvert.DeserializeObject<TestObject>(json);
            Assert.Null(obj);
        }

        [Fact]
        public void DeserializeRoot()
        {
            var json = @"{ 
                            ""supported_field"": 1, 
                            ""unsupported_field"": 2
                         }";
            var obj = JsonConvert.DeserializeObject<TestObject>(json);
            Assert.Equal(1, obj.SupportedField);
            Assert.NotNull(obj.RawJObject);
            Assert.Equal(2, obj.RawJObject["unsupported_field"]);
            Assert.Equal(obj.RawJObject.ToString(), JObject.Parse(json).ToString());
        }

        [Fact]
        public void DeserializeChild()
        {
            var childJson = @"{
                                ""child_supported_field"": 1,
                                ""child_unsupported_field"": 2,
                              }";
            var json = $@"{{ ""child"": {childJson} }}";
            var obj = JsonConvert.DeserializeObject<TestObject>(json);

            Assert.NotNull(obj);
            Assert.Null(obj.SupportedField);
            Assert.NotNull(obj.RawJObject);
            Assert.Equal(obj.RawJObject.ToString(), JObject.Parse(json).ToString());

            Assert.NotNull(obj.Child);
            Assert.Equal(1, obj.Child.ChildSupportedField);
            Assert.NotNull(obj.Child.RawJObject);
            Assert.Equal(2, obj.Child.RawJObject["child_unsupported_field"]);
            Assert.Equal(obj.Child.RawJObject.ToString(), JObject.Parse(childJson).ToString());
        }

        private class TestObject : StripeEntity<TestObject>
        {
            [JsonProperty("supported_field")]
            public long? SupportedField { get; set; }

            [JsonProperty("child")]
            public TestChildObject Child { get; set; }
        }

        private class TestChildObject : StripeEntity<TestObject>
        {
            [JsonProperty("child_supported_field")]
            public long ChildSupportedField { get; set; }
        }
    }
}
