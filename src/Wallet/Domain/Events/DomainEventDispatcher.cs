using Core.Cqrs.Domain;
using MediatR;

namespace Template.Domain.Events
{
    public static class DomainEventDispatcher
    {
        public static void DispatchAndClearEvents(this IMediator mediator, IEnumerable<IDataTenantId> entitiesWithEvents)
        {
            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.DomainEvents.ToArray();
                entity.ClearDomainEvents();
                foreach (var domainEvent in events)
                {
                    mediator.Publish(domainEvent);
                }
            }
        }

        public static async Task DispatchAndClearEventsAwait(this IMediator mediator, IEnumerable<IDataTenantId> entitiesWithEvents)
        {
            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.DomainEventsAwait.ToArray();
                entity.ClearDomainEventsAwait();
                foreach (var domainEvent in events)
                {
                    await mediator.Publish(domainEvent);
                }
            }
        }
    }
}
