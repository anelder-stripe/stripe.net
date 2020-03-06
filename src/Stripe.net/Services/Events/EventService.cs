namespace Stripe
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class EventService : Service<Event>,
        IListable<Event, EventListOptions>,
        IRetrievable<Event, EventGetOptions>
    {
        public EventService()
            : base(null)
        {
        }

        public EventService(IStripeClient client)
            : base(client)
        {
        }

        public override string BasePath => "/v1/events";

        public virtual Event Get(string eventId, EventGetOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetEntity(eventId, options, requestOptions);
        }

        public virtual Task<Event> GetAsync(string eventId, EventGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.GetEntityAsync(eventId, options, requestOptions, cancellationToken);
        }

        public virtual StripeList<Event> List(EventListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        public virtual Task<StripeList<Event>> ListAsync(EventListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }

        public virtual IEnumerable<Event> ListAutoPaging(EventListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntitiesAutoPaging(options, requestOptions);
        }
    }
}
