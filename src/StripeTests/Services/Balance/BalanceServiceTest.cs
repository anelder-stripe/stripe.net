namespace StripeTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Stripe;
    using Xunit;

    public class BalanceServiceTest : BaseStripeTest
    {
        private BalanceService service;

        public BalanceServiceTest()
        {
            this.service = new BalanceService();
        }

        [Fact]
        public void Get()
        {
            var balance = this.service.Get();
            Assert.NotNull(balance);
            Assert.Equal("balance", balance.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var balance = await this.service.GetAsync();
            Assert.NotNull(balance);
            Assert.Equal("balance", balance.Object);
        }
    }
}
