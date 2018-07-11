using FluentAssertions;
using Stripe.Tests.Xunit;
using System.Collections.Generic;
using System;
using System.Linq;
using Xunit;

namespace Stripe.Tests.XUnit
{
    public class when_listing_issuer_fraud_records
    {
        StripeList<StripeIssuerFraudRecord> result;

        public when_listing_issuer_fraud_records()
        {
            result = new StripeIssuerFraudRecordService(Cache.ApiKey).List(new StripeIssuerFraudRecordListOptions { Limit = 3 });
        }

        [Fact]
        public void list_is_iterable()
        {
            var count = 0;
            IEnumerable<StripeIssuerFraudRecord> enumerable = result as IEnumerable<StripeIssuerFraudRecord>;
            foreach (var obj in enumerable)
            {
                count += 1;
            }
            Assert.Equal(result.ToList().Count, 3);
            Assert.Equal(result.ToList().Count, count);
        }

        [Fact]
        public void list_contents_equal()
        {
            var datahash = new HashSet<String>();
            foreach (var obj in result.Data)
            {
                datahash.Add(obj.Id);
            }

            var enumhash = new HashSet<String>();
            IEnumerable<StripeIssuerFraudRecord> enumerable = result as IEnumerable<StripeIssuerFraudRecord>;
            foreach (var obj in enumerable)
            {
                enumhash.Add(obj.Id);
            }

            Assert.Equal(datahash, enumhash);
        }

        [Fact]
        public void list_contains_extra_attributes()
        {
            Assert.NotNull(result.Object);
            Assert.Equal(result.Object, "list");
            Assert.NotNull(result.Data);
            Assert.NotNull(result.Url);
        }
    }
}
