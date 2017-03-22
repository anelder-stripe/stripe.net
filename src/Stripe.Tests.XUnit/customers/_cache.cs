﻿using System;

namespace Stripe.Tests.Xunit
{
    public static partial class Cache
    {
        public static StripeCustomer GetCustomer(string customerName = "customer")
        {
            if (Items.ContainsKey(customerName)) return (StripeCustomer) Items[customerName];

            var customer = new StripeCustomerService(ApiKey).Create(GetCustomerCreateOptions());
            Items.Add(customerName, customer);

            return customer;
        }

        public static StripeCustomerCreateOptions GetCustomerCreateOptions()
        {
            if (Items.ContainsKey("customer_create_options")) return (StripeCustomerCreateOptions) Items["customer_create_options"];

            var options = new StripeCustomerCreateOptions
            {
                Email = $"{Guid.NewGuid()}@email.com",
                SourceToken = GetToken().Id
            };
            Items.Add("customer_create_options", options);

            return options;
        }
    }
}
