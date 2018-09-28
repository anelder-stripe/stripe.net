namespace Stripe
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Stripe.Infrastructure;

    public class BankAccountService : StripeService,
        INestedCreatable<BankAccount, BankAccountCreateOptions>,
        INestedDeletable<BankAccount>,
        INestedListable<BankAccount, BankAccountListOptions>,
        INestedRetrievable<BankAccount>,
        INestedUpdatable<BankAccount, BankAccountUpdateOptions>
    {
        public BankAccountService()
            : base(null)
        {
        }

        public BankAccountService(string apiKey)
            : base(apiKey)
        {
        }

        public bool ExpandCustomer { get; set; }

        public virtual BankAccount Create(string customerId, BankAccountCreateOptions createOptions, RequestOptions requestOptions = null)
        {
            return Mapper<BankAccount>.MapFromJson(
                Requestor.PostString(
                    this.ApplyAllParameters(createOptions, $"{Urls.BaseUrl}/customers/{customerId}/bank_accounts"),
                    this.SetupRequestOptions(requestOptions)));
        }

        public virtual BankAccount Get(string customerId, string bankAccountId, RequestOptions requestOptions = null)
        {
            return Mapper<BankAccount>.MapFromJson(
                Requestor.GetString(
                    this.ApplyAllParameters(null, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    this.SetupRequestOptions(requestOptions)));
        }

        public virtual BankAccount Update(string customerId, string bankAccountId, BankAccountUpdateOptions updateOptions, RequestOptions requestOptions = null)
        {
            return Mapper<BankAccount>.MapFromJson(
                Requestor.PostString(
                    this.ApplyAllParameters(updateOptions, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    this.SetupRequestOptions(requestOptions)));
        }

        public virtual BankAccount Delete(string customerId, string bankAccountId, RequestOptions requestOptions = null)
        {
            return Mapper<BankAccount>.MapFromJson(
                Requestor.Delete(
                    this.ApplyAllParameters(null, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    this.SetupRequestOptions(requestOptions)));
        }

        public virtual StripeList<BankAccount> List(string customerId, BankAccountListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return Mapper<StripeList<BankAccount>>.MapFromJson(
                Requestor.GetString(
                    this.ApplyAllParameters(listOptions, $"{Urls.BaseUrl}/customers/{customerId}/bank_accounts", true),
                    this.SetupRequestOptions(requestOptions)));
        }

        public virtual BankAccount Verify(string customerId, string bankAccountId, BankAccountVerifyOptions verifyoptions, RequestOptions requestOptions = null)
        {
            return Mapper<BankAccount>.MapFromJson(
                Requestor.PostString(
                    this.ApplyAllParameters(verifyoptions, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}/verify"),
                    this.SetupRequestOptions(requestOptions)));
        }

        public virtual async Task<BankAccount> CreateAsync(string customerId, BankAccountCreateOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<BankAccount>.MapFromJson(
                await Requestor.PostStringAsync(
                    this.ApplyAllParameters(createOptions, $"{Urls.BaseUrl}/customers/{customerId}/bank_accounts"),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false));
        }

        public virtual async Task<BankAccount> GetAsync(string customerId, string bankAccountId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<BankAccount>.MapFromJson(
                await Requestor.GetStringAsync(
                    this.ApplyAllParameters(null, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false));
        }

        public virtual async Task<BankAccount> UpdateAsync(string customerId, string bankAccountId, BankAccountUpdateOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<BankAccount>.MapFromJson(
                await Requestor.PostStringAsync(
                    this.ApplyAllParameters(updateOptions, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false));
        }

        public virtual async Task<BankAccount> DeleteAsync(string customerId, string bankAccountId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<BankAccount>.MapFromJson(
                await Requestor.DeleteAsync(
                    this.ApplyAllParameters(null, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false));
        }

        public virtual async Task<StripeList<BankAccount>> ListAsync(string customerId, BankAccountListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<StripeList<BankAccount>>.MapFromJson(
                await Requestor.GetStringAsync(
                    this.ApplyAllParameters(listOptions, $"{Urls.BaseUrl}/customers/{customerId}/bank_accounts", true),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false));
        }

        public virtual async Task<BankAccount> VerifyAsync(string customerId, string bankAccountId, BankAccountVerifyOptions verifyoptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<BankAccount>.MapFromJson(
                await Requestor.PostStringAsync(
                    this.ApplyAllParameters(verifyoptions, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}/verify"),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false));
        }
    }
}
