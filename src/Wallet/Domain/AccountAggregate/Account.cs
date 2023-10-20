using Core.Domain.Domain;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.ClassifiersAggregate;
using MediatR;
using AuthPermissions.BaseCode.CommonCode;
using Template.Domain.MovementTransferAggregate;

namespace Template.Domain.AccountAggregate
{
    public class Account : BaseEntity, IAggregateRoot, IDataTenantId, IDataKeyFilterReadWrite
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public CategoryAccount CategoryAccount { get; set; }
        public string DataKey { get; set; }


        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();
        private readonly List<INotification> _domainEvents = new();
        public IReadOnlyCollection<INotification> DomainEventsAwait => _domainEventsAwait.AsReadOnly();
        private readonly List<INotification> _domainEventsAwait = new();

        public Account()
        {
            DataKey = string.Empty;
            Name = string.Empty;
            CategoryAccount = new CategoryAccount();

        }



        public Account(string name, CategoryAccount categoryAccount, double salary)
        {
            DataKey = string.Empty;
            Name = name;
            CategoryAccount = categoryAccount;
            Salary = salary;
        }

        public void UpdateAccount(string name, CategoryAccount categoryAccount)
        {
            Name = name;
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
