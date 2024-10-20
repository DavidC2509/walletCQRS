using Core.Cqrs.Domain.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Core.CommandAndQueryHandler
{
    public static class MediatorExtension
    {
        /// <summary>
        /// Método de extensión. Se encarga de publicar los eventos de pre-guardado
        /// </summary>
        /// <param name="mediator">Instancia para generar la extensión</param>
        /// <param name="context">Contexto de base de datos</param>
        /// <returns></returns>
        public static async Task DispatchDomainEventsPreSaveAsync(this IMediator mediator, DbContext context)
        {
            var domainEntities = context.ChangeTracker
                .Entries<DomainEventEntity>()
                .Where(x => x.Entity.DomainEventsPre != null && x.Entity.DomainEventsPre.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEventsPre)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents(DomainEventEntity.DomainEventType.PreSave));

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }

        /// <summary>
        /// Método de extensión. Se encarga de publicar los eventos de post-guardado
        /// </summary>
        /// <param name="mediator">Instancia para generar la extensión</param>
        /// <param name="context">Contexto de base de datos</param>
        /// <returns></returns>
        public static async Task DispatchDomainEventsPostSaveAsync(this IMediator mediator, DbContext context)
        {
            var domainEntities = context.ChangeTracker
                .Entries<DomainEventEntity>()
                .Where(x => x.Entity.DomainEventsPost != null && x.Entity.DomainEventsPost.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEventsPost)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents(DomainEventEntity.DomainEventType.PostSave));

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}
