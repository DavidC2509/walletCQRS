

using AuthPermissions.BaseCode.CommonCode;
using Core.Domain;
using Core.Domain.Domain;
using MediatR;
using Template.Domain.ClassifiersAggregate.Events;

namespace Template.Domain.ClassifiersAggregate
{
    public class CategoryAccount : BaseEntity, IAggregateRoot, IDataTenantId, IDataKeyFilterReadWrite
    {
        public string Name { get; set; }

        public string DataKey { get; set; }

        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();
        private List<INotification> _domainEvents = new();



        public IReadOnlyCollection<INotification> DomainEventsAwait => _domainEventsAwait.AsReadOnly();
        private List<INotification> _domainEventsAwait = new();

        public CategoryAccount()
        {
            Name = string.Empty;
            DataKey = string.Empty;
        }
        public CategoryAccount(string name)
        {
            Name = name;
            DataKey = string.Empty;
        }


        public void UpdateCategoryAccount(string name)
        {
            Name = name;

        }

        public void StoreAccountUser()
        {
            var storeAccountUserEvent = new StoreAccountUserEvent(this);
            _domainEventsAwait.Add(storeAccountUserEvent);
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
