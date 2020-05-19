namespace Stripe.Issuing
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class CardholderUpdateOptions : BaseOptions, IHasMetadata
    {
        [JsonProperty("billing")]
        public CardholderBillingOptions Billing { get; set; }

        [JsonProperty("company")]
        public CardholderCompanyOptions Company { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("individual")]
        public CardholderIndividualOptions Individual { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("spending_controls")]
        public CardholderSpendingControlsOptions SpendingControls { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
