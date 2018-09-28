namespace Stripe
{
    using Newtonsoft.Json;

    public class CustomerListOptions : ListOptionsWithCreated
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
