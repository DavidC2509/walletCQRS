

using Core.Domain;
using Core.Domain.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Template.Domain.UserAggregate.Events;

namespace Template.Domain.UserAggregate
{
    public class User : IdentityUser,IAggregateRoot, IBaseEntity, IDataTenantId
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string TenantId { get; set; }

        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();
        private List<INotification> _domainEvents = new();

        public IReadOnlyCollection<INotification> DomainEventsAwait => _domainEventsAwait.AsReadOnly();
        private List<INotification> _domainEventsAwait = new();

        public User(string firstName, string? lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            TenantId = string.Empty;
        }


        public void GenerateRandomTenantId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            TenantId = new string(Enumerable.Repeat(chars, 5)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }

        public void AddCategoryDefaultEvent()
        {
            var categoryDefaultEvent = new AddCategoryDefaultEvent(TenantId);
            _domainEventsAwait.Add(categoryDefaultEvent);
        }

        public void AddCategoryMovementDefaultEvent()
        {
            var CategoryMovementDefaultEvent = new AddCategoryMovementDefaultEvent(TenantId);
            _domainEventsAwait.Add(CategoryMovementDefaultEvent);
        }

        public bool IsTransient()
        {
            return Id == default;
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
