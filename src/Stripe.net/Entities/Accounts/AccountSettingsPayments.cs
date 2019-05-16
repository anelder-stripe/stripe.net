namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public class AccountSettingsPayments : StripeEntity
    {
        /// <summary>
        /// The default text that appears on credit card statements when a charge is made. This
        /// field prefixes any dynamic <c>statement_descriptor</c> specified on the charge.
        /// </summary>
        [JsonProperty("statement_descriptor")]
        public string StatementDescriptor { get; set; }

        /// <summary>
        /// The Kana variation of the default text that appears on credit card statements when a
        /// charge is made (Japan only).
        /// </summary>
        [JsonProperty("statement_descriptor_kana")]
        public string StatementDescriptorKana { get; set; }

        /// <summary>
        /// The Kanji variation of the default text that appears on credit card statements when a
        /// charge is made (Japan only).
        /// </summary>
        [JsonProperty("statement_descriptor_kanji")]
        public string StatementDescriptorKanji { get; set; }
    }
}
