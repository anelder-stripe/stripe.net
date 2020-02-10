namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Stripe.Infrastructure;

    public class PersonService : ServiceNested<Person>,
        INestedCreatable<Person, PersonCreateOptions>,
        INestedListable<Person, PersonListOptions>,
        INestedRetrievable<Person, PersonGetOptions>,
        INestedUpdatable<Person, PersonUpdateOptions>
    {
        public PersonService()
            : base(null)
        {
        }

        public PersonService(IStripeClient client)
            : base(client)
        {
        }

        public override string BasePath => "/v1/accounts/{PARENT_ID}/persons";

        public virtual Person Create(string parentId, PersonCreateOptions options = null, RequestOptions requestOptions = null)
        {
            return this.CreateNestedEntity(parentId, options, requestOptions);
        }

        public virtual Task<Person> CreateAsync(string parentId, PersonCreateOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateNestedEntityAsync(parentId, options, requestOptions, cancellationToken);
        }

        public virtual Person Delete(string parentId, string id, RequestOptions requestOptions = null)
        {
            return this.DeleteNestedEntity(parentId, id, null, requestOptions);
        }

        public virtual Task<Person> DeleteAsync(string parentId, string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.DeleteNestedEntityAsync(parentId, id, null, requestOptions, cancellationToken);
        }

        public virtual Person Get(string parentId, string id, PersonGetOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetNestedEntity(parentId, id, options, requestOptions);
        }

        public virtual Task<Person> GetAsync(string parentId, string id, PersonGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetNestedEntityAsync(parentId, id, options, requestOptions, cancellationToken);
        }

        public virtual StripeList<Person> List(string parentId, PersonListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListNestedEntities(parentId, options, requestOptions);
        }

        public virtual Task<StripeList<Person>> ListAsync(string parentId, PersonListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.ListNestedEntitiesAsync(parentId, options, requestOptions, cancellationToken);
        }

        public virtual IEnumerable<Person> ListAutoPaging(string parentId, PersonListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListNestedEntitiesAutoPaging(parentId, options, requestOptions);
        }

        public virtual Person Update(string parentId, string id, PersonUpdateOptions options, RequestOptions requestOptions = null)
        {
            return this.UpdateNestedEntity(parentId, id, options, requestOptions);
        }

        public virtual Task<Person> UpdateAsync(string parentId, string id, PersonUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.UpdateNestedEntityAsync(parentId, id, options, requestOptions, cancellationToken);
        }
    }
}
