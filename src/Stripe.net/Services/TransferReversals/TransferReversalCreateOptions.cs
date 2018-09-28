namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class TransferReversalCreateOptions : BaseOptions, ISupportMetadata
    {
        [JsonProperty("amount")]
        public int? Amount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("refund_application_fee")]
        public bool? RefundApplicationFee { get; set; }
    }
}
