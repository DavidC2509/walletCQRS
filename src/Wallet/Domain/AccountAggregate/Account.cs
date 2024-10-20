using AuthPermissions.BaseCode.CommonCode;
using Core.Cqrs.Domain;
using Core.Cqrs.Domain.Domain;
using MediatR;
using Template.Domain.ClassifiersAggregate;

namespace Template.Domain.AccountAggregate
{
    public class Account : BaseEntity, IAggregateRoot, IDataTenantId, IDataKeyFilterReadWrite
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public CategoryAccount CategoryAccount { get; set; } = null!;
        public string DataKey { get; set; }


        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();
        private readonly List<INotification> _domainEvents = new();
        public IReadOnlyCollection<INotification> DomainEventsAwait => _domainEventsAwait.AsReadOnly();
        private readonly List<INotification> _domainEventsAwait = new();

        private Account()
        {
            DataKey = string.Empty;
            Name = string.Empty;
        }

        internal Account(string name, CategoryAccount categoryAccount, double salary) : this()
        {
            DataKey = string.Empty;
            Name = name;
            CategoryAccount = categoryAccount;
            Salary = salary;
        }


        public static Account CreateAccount(string name, CategoryAccount categoryAccount, double salary)
        => new(name, categoryAccount, salary);


        public void UpdateAccount(string name, double salary, CategoryAccount categoryAccount)
        {
            Name = name;
            Salary = salary;
            CategoryAccount = categoryAccount;
        }


        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public void ClearDomainEventsAwait()
        {
            _domainEventsAwait.Clear();
        }

        public void UpdateSalary(double amount, TypeMovement typeMovement)
        {
            if (typeMovement == TypeMovement.Income || typeMovement == TypeMovement.IncomeTransfer)
            {
                Salary += amount;
            }
            else
            {
                Salary -= amount;
            }
        }
    }
}
