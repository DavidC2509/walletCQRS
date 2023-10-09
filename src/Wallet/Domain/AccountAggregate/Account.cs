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

namespace Template.Domain.AccountAggregate
{
    public class Account : BaseEntity, IAggregateRoot, IDataTenantId, IDataKeyFilterReadWrite
    {
        public string Name { get; set; }
        public double Salary => CalculateSalary();
        public CategoryAccount CategoryAccount { get; set; }
        public string DataKey { get; set; }
        /// <summary>
        /// Listado de Movimientos
        /// </summary>
        private List<Movement> _movement;
        public IReadOnlyList<Movement> Movements => _movement;

        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();
        private readonly List<INotification> _domainEvents = new();
        public IReadOnlyCollection<INotification> DomainEventsAwait => _domainEventsAwait.AsReadOnly();
        private readonly List<INotification> _domainEventsAwait = new();

        public Account()
        {
            DataKey = string.Empty;
            Name = string.Empty;
            CategoryAccount = new CategoryAccount();
            _movement = new List<Movement>();

        }



        public Account(string name, CategoryAccount categoryAccount, double salary = 0)
        {
            DataKey = string.Empty;
            Name = name;
            CategoryAccount = categoryAccount;
            _movement = new List<Movement>();
        }


        public double CalculateSalary()
        {
            double Salary = 0;
            _movement.ForEach(mov =>
            {
                if (mov.TypeMovement == TypeMovement.Income)
                {
                    Salary += mov.Amount;
                }
                else
                {
                    Salary -= mov.Amount;
                }
            });
            return Salary;
        }

        public void AddMovement(CategoryMovement categoryMovement, TypeMovement typeMovement,
        double amount, string descripcion, DateTime date)
        {
            if (typeMovement == TypeMovement.Exit && typeMovement == TypeMovement.ExitTransfer)
            {
                if (Salary < amount) throw new InvalidOperationException("No tiene Salario suficiente para la salidad");
            }
            _movement.Add(new Movement(categoryMovement, typeMovement, amount, descripcion, date));
        }

        public void UpdateMovement(Guid movementId, double amount, string descripcion, DateTime date)
        {
            var movement = _movement.Find(x => x.Id == movementId)!;

            if (movement.TypeMovement == TypeMovement.Income)
            {
                ValidateUpdateTypeIncome(movement, amount);
            }
            else
            {
                ValidateUpdateTypeExit(movement, amount);
            }
            movement?.UpdateMovement(amount, descripcion, date);
        }

        internal void ValidateUpdateTypeIncome(Movement movement, double amount)
        {
            if (amount < movement.Amount)
            {
                double amountDiference = movement.Amount - amount;

                if (Salary < amountDiference) throw new InvalidOperationException("No puedes Modificar el ingreso menor de eso p    or falto de Salario");
            }
        }

        internal void ValidateUpdateTypeExit(Movement movement, double amount)
        {
            if (amount > movement.Amount)
            {
                double amountDiference = amount - movement.Amount;

                if (amountDiference > Salary) throw new InvalidOperationException("No puedes Modificar la salida mayor al total Salario");
            }
        }



        public void DeleteMovement(Guid movementId)
        {
            var movement = _movement.Find(x => x.Id == movementId)!;

            if (movement.TypeMovement == TypeMovement.Income || movement.Amount > Salary) throw new InvalidOperationException("No puedes Modificar la salida mayor al total Salario");

            _movement.Remove(movement);

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


    }
}
