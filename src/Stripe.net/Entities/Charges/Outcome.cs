namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public class Outcome : StripeEntity<Outcome>
    {
        [JsonProperty("network_status")]
        public string NetworkStatus { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("risk_level")]
        public string RiskLevel { get; set; }

        [JsonProperty("risk_score")]
        public long RiskScore { get; set; }

        #region Expandable Rule

        [JsonIgnore]
        public string RuleId
        {
            get => this.InternalRule?.Id;
            set => this.InternalRule = SetExpandableFieldId(value, this.InternalRule);
        }

        [JsonIgnore]
        public OutcomeRule Rule
        {
            get => this.InternalRule?.ExpandedObject;
            set => this.InternalRule = SetExpandableFieldObject(value, this.InternalRule);
        }

        [JsonProperty("rule")]
        [JsonConverter(typeof(ExpandableFieldConverter<OutcomeRule>))]
        internal ExpandableField<OutcomeRule> InternalRule { get; set; }
        #endregion

        [JsonProperty("seller_message")]
        public string SellerMessage { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
