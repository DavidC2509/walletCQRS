using Core.Domain.Domain;
using Core.Domain;
using AuthPermissions.BaseCode.CommonCode;
using MediatR;
using Template.Domain.MovementTransferAggregate.Events;


namespace Template.Domain.MovementTransferAggregate
{
    public class MovementTransfer : BaseEntity, IAggregateRoot, IDataTenantId, IDataKeyFilterReadWrite
    {

        public string DataKey { get; set; }
        public string NameAccountOrigin { get; set; }
        public Guid AccountOriginId { get; set; }
        public Guid MovementOriginId { get; set; }
        public string NameAccountDestiny { get; set; }
        public Guid AccountDestinyId { get; set; }
        public Guid MovementDestitnyId { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public MovementTransfer()
        {
            DataKey = string.Empty;
            NameAccountDestiny = string.Empty;
            NameAccountOrigin = string.Empty;
        }

        public MovementTransfer(Guid accountOriginId, Guid movementOriginId, string nameAccountOrigin,
        Guid MovementDestinyId, Guid accountDestinyId,
        string nameAccountDestiny, double amount, DateTime date)
        {
            DataKey = string.Empty;
            AccountOriginId = accountOriginId;
            NameAccountDestiny = nameAccountDestiny;
            NameAccountOrigin = nameAccountOrigin;
            MovementOriginId = movementOriginId;
            AccountDestinyId = accountDestinyId;
            MovementDestitnyId = MovementDestinyId;
            Amount = amount;
            Date = date;
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

        public void UpdateMovementTransfer(double amount, DateTime date)
        {
            Amount = amount;
            Date = date;
            NotificacionMovement();
        }

        public void DeleteOriginAccount()
        {
            var storeAccountUserEvent = new DeleteOriginMovementEvent(this);
            _domainEventsAwait.Add(storeAccountUserEvent);
        }


        internal void NotificacionMovement()
        {
            var storeAccountUserEvent = new NotificacionOriginMovementEvent(this);
            _domainEventsAwait.Add(storeAccountUserEvent);
        }

    }
}
