using Core.Domain.Domain;
using Core.Domain;
using MediatR;
using AuthPermissions.BaseCode.CommonCode;
using Template.Domain.ClassifiersAggregate;

namespace Template.Domain.AccountAggregate
{
    public class Movement : DomainEventEntity, IAggregateChild<Account>, IDataTenantId
    {

        public string Descripcion { get; set; }
        public double Amount { get; set; }
        public Guid AccountId { get; set; }
        public CategoryMovement CategoryMovement { get; set; }
        public TypeMovement TypeMovement { get; set; }
        public DateTime Date { get; set; }

        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();
        private List<INotification> _domainEvents = new();

        public IReadOnlyCollection<INotification> DomainEventsAwait => _domainEventsAwait.AsReadOnly();
        private List<INotification> _domainEventsAwait = new();

        public Movement()
        {
            Descripcion = string.Empty;
            CategoryMovement = new CategoryMovement();
            TypeMovement = new TypeMovement();
        }

        public Movement(CategoryMovement categoryMovement, TypeMovement typeMovement, double amount, string descripcion, DateTime date)
        {
            CategoryMovement = categoryMovement;
            TypeMovement = typeMovement;
            Amount = amount;
            Descripcion = descripcion;
            Date = date;
        }

        public void UpdateMovement(double amount, string descripcion, DateTime date)
        {
            Amount = amount;
            Descripcion = descripcion;
            Date = date;
        }

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
