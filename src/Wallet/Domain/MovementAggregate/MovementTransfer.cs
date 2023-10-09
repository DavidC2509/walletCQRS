using Core.Domain.Domain;
using Core.Domain;
using AuthPermissions.BaseCode.CommonCode;
using MediatR;
using Template.Domain.AccountAggregate;


namespace Template.Domain.MovementAggregate
{
    public class MovementTransfer : DomainEventEntity, IAggregateRoot, IDataTenantId, IDataKeyFilterReadWrite
    {

        public string DataKey { get; set; }
        public Guid MovementOriginId { get; set; }
        public Guid MovementDestitnyId { get; set; }
        public double Amount { get; set; }

        public MovementTransfer()
        {
            DataKey = string.Empty;
        }

        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();
        private List<INotification> _domainEvents = new();

        public IReadOnlyCollection<INotification> DomainEventsAwait => _domainEventsAwait.AsReadOnly();
        private List<INotification> _domainEventsAwait = new();

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public void ClearDomainEventsAwait()
        {
            _domainEventsAwait.Clear();
        }

    }
}
