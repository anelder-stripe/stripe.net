namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public class SourceReceiver : StripeEntity<SourceReceiver>
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("amount_charged")]
        public long AmountCharged { get; set; }

        [JsonProperty("amount_received")]
        public long AmountReceived { get; set; }

        [JsonProperty("amount_returned")]
        public long AmountReturned { get; set; }
    }
}
