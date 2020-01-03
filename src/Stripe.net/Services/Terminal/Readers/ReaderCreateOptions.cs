namespace Stripe.Terminal
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public class ReaderCreateOptions : BaseOptions, IHasMetadata
    {
        /// <summary>
        /// Custom label given to the reader for easier identification. If no
        /// label is specified, the registration code will be used.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// The location to assign the reader to. If no location is specified,
        /// the reader will be assigned to the account’s default location.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// Set of key-value pairs that you can attach to an object. This can be useful for storing
        /// additional information about the object in a structured format.
        /// </summary>
        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// A code generated by the reader used for registering to an account.
        /// </summary>
        [JsonProperty("registration_code")]
        public string RegistrationCode { get; set; }
    }
}
