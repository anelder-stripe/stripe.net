namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public class Subscription : StripeEntity<Subscription>, IHasId, IHasMetadata, IHasObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("application_fee_percent")]
        public decimal? ApplicationFeePercent { get; set; }

        /// <summary>
        /// One of <see cref="Billing" />. When charging automatically, Stripe will attempt to pay
        /// this subscription at the end of the cycle using the default source attached to the
        /// customer. When sending an invoice, Stripe will email your customer an invoice with
        /// payment instructions.
        /// </summary>
        [JsonProperty("billing")]
        public Billing? Billing { get; set; }

        [JsonProperty("billing_cycle_anchor")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? BillingCycleAnchor { get; set; }

        /// <summary>
        /// Define thresholds at which an invoice will be sent, and the subscription advanced to a
        /// new billing period
        /// </summary>
        [JsonProperty("billing_thresholds")]
        public SubscriptionBillingThresholds BillingThresholds { get; set; }

        /// <summary>
        /// A date in the future at which the subscription will automatically get canceled.
        /// </summary>
        [JsonProperty("cancel_at")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CancelAt { get; set; }

        [JsonProperty("cancel_at_period_end")]
        public bool CancelAtPeriodEnd { get; set; }

        [JsonProperty("canceled_at")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CanceledAt { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Created { get; set; }

        [JsonProperty("current_period_end")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CurrentPeriodEnd { get; set; }

        [JsonProperty("current_period_start")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CurrentPeriodStart { get; set; }

        #region Expandable Customer
        [JsonIgnore]
        public string CustomerId => this.InternalCustomer.Id;

        [JsonIgnore]
        public Customer Customer => this.InternalCustomer.ExpandedObject;

        [JsonProperty("customer")]
        [JsonConverter(typeof(ExpandableFieldConverter<Customer>))]
        internal ExpandableField<Customer> InternalCustomer { get; set; }
        #endregion

        /// <summary>
        /// Number of days a customer has to pay invoices generated by this subscription. This value will be null for subscriptions where billing=charge_automatically.
        /// </summary>
        [JsonProperty("days_until_due")]
        public long? DaysUntilDue { get; set; }

        #region Expandable DefaultPaymentMethod

        /// <summary>
        /// ID of the default payment method for the subscription.
        /// </summary>
        [JsonIgnore]
        public string DefaultPaymentMethodId => this.InternalDefaultPaymentMethod.Id;

        [JsonIgnore]
        public PaymentMethod DefaultPaymentMethod => this.InternalDefaultPaymentMethod.ExpandedObject;

        [JsonProperty("default_payment_method")]
        [JsonConverter(typeof(ExpandableFieldConverter<PaymentMethod>))]
        internal ExpandableField<PaymentMethod> InternalDefaultPaymentMethod { get; set; }
        #endregion

        #region Expandable DefaultSource
        [JsonIgnore]
        public string DefaultSourceId => this.InternalDefaultSource.Id;

        [JsonIgnore]
        public IPaymentSource DefaultSource => this.InternalDefaultSource.ExpandedObject;

        [JsonProperty("default_source")]
        [JsonConverter(typeof(ExpandableFieldConverter<IPaymentSource>))]
        internal ExpandableField<IPaymentSource> InternalDefaultSource { get; set; }
        #endregion

        /// <summary>
        /// The default tax rates that apply to this subscription.
        /// </summary>
        [JsonProperty("default_tax_rates")]
        public List<TaxRate> DefaultTaxRates { get; set; }

        [JsonProperty("discount")]
        public Discount Discount { get; set; }

        [JsonProperty("ended_at")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? EndedAt { get; set; }

        [JsonProperty("items")]
        public StripeList<SubscriptionItem> Items { get; set; }

        #region Expandable LatestInvoice
        [JsonIgnore]
        public string LatestInvoiceId => this.InternalLatestInvoice.Id;

        [JsonIgnore]
        public Invoice LatestInvoice => this.InternalLatestInvoice.ExpandedObject;

        [JsonProperty("latest_invoice")]
        [JsonConverter(typeof(ExpandableFieldConverter<Invoice>))]
        internal ExpandableField<Invoice> InternalLatestInvoice { get; set; }
        #endregion

        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("plan")]
        public Plan Plan { get; set; }

        [JsonProperty("quantity")]
        public long? Quantity { get; set; }

        [Obsolete("Use StartDate")]
        [JsonProperty("start")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Start { get; set; }

        /// <summary>
        /// Date when the subscription was first created. The date might differ from the
        /// <c>created</c> date due to backdating.
        /// </summary>
        [JsonProperty("start_date")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? StartDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [Obsolete("Use DefaultTaxRates")]
        [JsonProperty("tax_percent")]
        public decimal? TaxPercent { get; set; }

        [JsonProperty("transfer_data")]
        public SubscriptionTransferData TransferData { get; set; }

        [JsonProperty("trial_end")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? TrialEnd { get; set; }

        [JsonProperty("trial_start")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? TrialStart { get; set; }
    }
}
