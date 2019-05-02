namespace StripeTests
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Stripe;
    using StripeTests.Infrastructure.TestData;
    using Xunit;

    public class StripeRequestTest : BaseStripeTest
    {
        [Fact]
        public void Ctor_GetRequest()
        {
            var options = new TestOptions { String = "string!" };
            var requestOptions = new RequestOptions();
            var request = new StripeRequest(HttpMethod.Get, "/get", options, requestOptions);

            Assert.Equal(HttpMethod.Get, request.Method);
            Assert.Equal($"{StripeConfiguration.ApiBase}/get?string=string!", request.Uri.ToString());
            Assert.Equal($"Bearer {StripeConfiguration.ApiKey}", request.AuthorizationHeader.ToString());
            Assert.True(request.StripeHeaders.ContainsKey("Stripe-Version"));
            Assert.Equal(StripeConfiguration.ApiVersion, request.StripeHeaders["Stripe-Version"]);
            Assert.False(request.StripeHeaders.ContainsKey("Idempotency-Key"));
            Assert.False(request.StripeHeaders.ContainsKey("Stripe-Account"));
            Assert.Null(request.Content);
        }

        [Fact]
        public async Task Ctor_PostRequest()
        {
            var options = new TestOptions { String = "string!" };
            var requestOptions = new RequestOptions();
            var request = new StripeRequest(HttpMethod.Post, "/post", options, requestOptions);

            Assert.Equal(HttpMethod.Post, request.Method);
            Assert.Equal($"{StripeConfiguration.ApiBase}/post", request.Uri.ToString());
            Assert.Equal($"Bearer {StripeConfiguration.ApiKey}", request.AuthorizationHeader.ToString());
            Assert.True(request.StripeHeaders.ContainsKey("Stripe-Version"));
            Assert.Equal(StripeConfiguration.ApiVersion, request.StripeHeaders["Stripe-Version"]);
            Assert.True(request.StripeHeaders.ContainsKey("Idempotency-Key"));
            Assert.False(request.StripeHeaders.ContainsKey("Stripe-Account"));
            Assert.NotNull(request.Content);
            var content = await request.Content.ReadAsStringAsync();
            Assert.Equal("string=string!", content);
        }

        [Fact]
        public void Ctor_DeleteRequest()
        {
            var options = new TestOptions { String = "string!" };
            var requestOptions = new RequestOptions();
            var request = new StripeRequest(HttpMethod.Delete, "/delete", options, requestOptions);

            Assert.Equal(HttpMethod.Delete, request.Method);
            Assert.Equal($"{StripeConfiguration.ApiBase}/delete?string=string!", request.Uri.ToString());
            Assert.Equal($"Bearer {StripeConfiguration.ApiKey}", request.AuthorizationHeader.ToString());
            Assert.True(request.StripeHeaders.ContainsKey("Stripe-Version"));
            Assert.Equal(StripeConfiguration.ApiVersion, request.StripeHeaders["Stripe-Version"]);
            Assert.False(request.StripeHeaders.ContainsKey("Idempotency-Key"));
            Assert.False(request.StripeHeaders.ContainsKey("Stripe-Account"));
            Assert.Null(request.Content);
        }

        [Fact]
        public void Ctor_RequestOptions()
        {
            var requestOptions = new RequestOptions
            {
                ApiKey = "sk_override",
                IdempotencyKey = "idempotency_key",
                StripeAccount = "acct_456",
                BaseUrl = "https://example.com",
                StripeVersion = "2012-12-21",
            };
            var request = new StripeRequest(HttpMethod.Get, "/get", null, requestOptions);

            Assert.Equal(HttpMethod.Get, request.Method);
            Assert.Equal("https://example.com/get", request.Uri.ToString());
            Assert.Equal("Bearer sk_override", request.AuthorizationHeader.ToString());
            Assert.True(request.StripeHeaders.ContainsKey("Stripe-Version"));
            Assert.Equal("2012-12-21", request.StripeHeaders["Stripe-Version"]);
            Assert.True(request.StripeHeaders.ContainsKey("Idempotency-Key"));
            Assert.Equal("idempotency_key", request.StripeHeaders["Idempotency-Key"]);
            Assert.True(request.StripeHeaders.ContainsKey("Stripe-Account"));
            Assert.Equal("acct_456", request.StripeHeaders["Stripe-Account"]);
            Assert.Null(request.Content);
        }

        [Fact]
        public void Ctor_ThrowsIfApiKeyIsNull()
        {
            var origKey = StripeConfiguration.ApiKey;

            try
            {
                StripeConfiguration.ApiKey = null;

                var options = new TestOptions();
                var requestOptions = new RequestOptions();

                var exception = Assert.Throws<StripeException>(() =>
                    new StripeRequest(HttpMethod.Get, "/get", options, requestOptions));

                Assert.Contains("No API key provided.", exception.Message);
            }
            finally
            {
                StripeConfiguration.ApiKey = origKey;
            }
        }

        [Fact]
        public void Ctor_ThrowsIfApiKeyIsEmpty()
        {
            var origKey = StripeConfiguration.ApiKey;

            try
            {
                StripeConfiguration.ApiKey = string.Empty;

                var options = new TestOptions();
                var requestOptions = new RequestOptions();

                var exception = Assert.Throws<StripeException>(() =>
                    new StripeRequest(HttpMethod.Get, "/get", options, requestOptions));

                Assert.Contains("No API key provided.", exception.Message);
            }
            finally
            {
                StripeConfiguration.ApiKey = origKey;
            }
        }

        [Fact]
        public void Ctor_ThrowsIfApiKeyContainsWhitespace()
        {
            var origKey = StripeConfiguration.ApiKey;

            try
            {
                StripeConfiguration.ApiKey = "sk_test_123\n";

                var options = new TestOptions();
                var requestOptions = new RequestOptions();

                var exception = Assert.Throws<StripeException>(() =>
                    new StripeRequest(HttpMethod.Get, "/get", options, requestOptions));

                Assert.Contains(
                    "Your API key is invalid, as it contains whitespace.",
                    exception.Message);
            }
            finally
            {
                StripeConfiguration.ApiKey = origKey;
            }
        }
    }
}
