﻿using System;
using Newtonsoft.Json;
using Stripe.Infrastructure;

namespace Stripe
{
	public class StripeDiscount : StripeObject
	{
		[JsonProperty("start")]
		[JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? Start { get; set; }

		[JsonProperty("end")]
		[JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? End { get; set; }

		[JsonProperty("coupon")]
		public StripeCoupon StripeCoupon { get; set; }
	}
}
