namespace Stripe
{
    using System;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    [JsonConverter(typeof(EventConverter))]
    public class Event : StripeEntity<Event>, IHasId, IHasObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("api_version")]
        public string ApiVersion { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Created { get; set; } = Stripe.Infrastructure.DateTimeUtils.UnixEpoch;

        [JsonProperty("data")]
        public EventData Data { get; set; }

        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        [JsonProperty("pending_webhooks")]
        public long PendingWebhooks { get; set; }

        [JsonProperty("request")]
        public EventRequest Request { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
