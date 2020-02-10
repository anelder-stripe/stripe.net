namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Stripe.Infrastructure;

    public class WebhookEndpointService : Service<WebhookEndpoint>,
        ICreatable<WebhookEndpoint, WebhookEndpointCreateOptions>,
        IDeletable<WebhookEndpoint>,
        IListable<WebhookEndpoint, WebhookEndpointListOptions>,
        IRetrievable<WebhookEndpoint, WebhookEndpointGetOptions>,
        IUpdatable<WebhookEndpoint, WebhookEndpointUpdateOptions>
    {
        public WebhookEndpointService()
            : base(null)
        {
        }

        public WebhookEndpointService(IStripeClient client)
            : base(client)
        {
        }

        public override string BasePath => "/v1/webhook_endpoints";

        public virtual WebhookEndpoint Create(WebhookEndpointCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }

        public virtual Task<WebhookEndpoint> CreateAsync(WebhookEndpointCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateEntityAsync(options, requestOptions, cancellationToken);
        }

        public virtual WebhookEndpoint Delete(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions);
        }

        public virtual Task<WebhookEndpoint> DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.DeleteEntityAsync(id, null, requestOptions, cancellationToken);
        }

        public virtual WebhookEndpoint Get(string id, WebhookEndpointGetOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, options, requestOptions);
        }

        public virtual Task<WebhookEndpoint> GetAsync(string id, WebhookEndpointGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityAsync(id, options, requestOptions, cancellationToken);
        }

        public virtual StripeList<WebhookEndpoint> List(WebhookEndpointListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        public virtual Task<StripeList<WebhookEndpoint>> ListAsync(WebhookEndpointListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }

        public virtual IEnumerable<WebhookEndpoint> ListAutoPaging(WebhookEndpointListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntitiesAutoPaging(options, requestOptions);
        }

        public virtual WebhookEndpoint Update(string id, WebhookEndpointUpdateOptions options, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, options, requestOptions);
        }

        public virtual Task<WebhookEndpoint> UpdateAsync(string id, WebhookEndpointUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.UpdateEntityAsync(id, options, requestOptions, cancellationToken);
        }
    }
}
