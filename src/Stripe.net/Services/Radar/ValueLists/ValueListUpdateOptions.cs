namespace Stripe.Radar
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ValueListUpdateOptions : BaseOptions, IHasMetadata
    {
        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
