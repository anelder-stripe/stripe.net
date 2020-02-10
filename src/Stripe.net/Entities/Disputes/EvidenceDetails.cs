namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public class EvidenceDetails : StripeEntity<EvidenceDetails>
    {
        [JsonProperty("due_by")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? DueBy { get; set; }

        [JsonProperty("has_evidence")]
        public bool HasEvidence { get; set; }

        [JsonProperty("past_due")]
        public bool PastDue { get; set; }

        [JsonProperty("submission_count")]
        public long SubmissionCount { get; set; }
    }
}
