namespace StripeTests
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Stripe;
    using Xunit;

    public class BalanceServiceTest : BaseStripeTest
    {
        private readonly BalanceService service;

        public BalanceServiceTest(
            StripeMockFixture stripeMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(stripeMockFixture, mockHttpClientFixture)
        {
            this.service = new BalanceService { Client = this.StripeClient };
        }

        [Fact]
        public void Get()
        {
            var balance = this.service.Get();
            this.AssertRequest(HttpMethod.Get, "/v1/balance");
            Assert.NotNull(balance);
            Assert.Equal("balance", balance.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var balance = await this.service.GetAsync();
            this.AssertRequest(HttpMethod.Get, "/v1/balance");
            Assert.NotNull(balance);
            Assert.Equal("balance", balance.Object);
        }
    }
}
