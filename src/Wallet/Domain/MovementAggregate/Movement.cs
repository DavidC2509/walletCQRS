using Core.Domain.Domain;
using Core.Domain;
using MediatR;
using AuthPermissions.BaseCode.CommonCode;
using Template.Domain.ClassifiersAggregate;
using Template.Domain.MovementTransferAggregate;
using Template.Domain.MovementAggregate.Events;

namespace Template.Domain.MovementAggregate
{
    public class Movement : BaseEntity, IAggregateRoot, IDataTenantId, IDataKeyFilterReadWrite
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

        public string DataKey { get; set; }

        private List<INotification> _domainEventsAwait = new();

        public Movement()
        {
            Descripcion = string.Empty;
            CategoryMovement = new CategoryMovement();
            TypeMovement = new TypeMovement();
            DataKey = string.Empty;
        }

        public Movement(CategoryMovement categoryMovement, TypeMovement typeMovement, double amount,
        string descripcion, DateTime date, Guid accountId)
        {
            CategoryMovement = categoryMovement;
            TypeMovement = typeMovement;
            Amount = amount;
            Descripcion = descripcion;
            Date = date;
            AccountId = accountId;
            DataKey = string.Empty;
            ModifiedSalary();
        }

        public static Movement AddMovement(CategoryMovement categoryMovement, TypeMovement typeMovement,
                double amount, string descripcion, DateTime date, Guid accountId, double Salary)
        {
            if (typeMovement == TypeMovement.Exit || typeMovement == TypeMovement.ExitTransfer)
            {
                if (Salary < amount) throw new InvalidOperationException("No tiene Salario suficiente para la salidad");
            }
            return new Movement(categoryMovement, typeMovement, amount, descripcion, date, accountId);
        }

        public void UpdateMovement(double amount, string descripcion, DateTime date, double salary)
        {

            if (TypeMovement == TypeMovement.Income || TypeMovement == TypeMovement.IncomeTransfer)
            {
                ValidateUpdateIncome(amount, salary);
            }
            else
            {
                ValidateUpdateExit(amount, salary);
            }
            ModifiedSalary();
            Amount = amount;
            Descripcion = descripcion;
            Date = date;
        }

        internal void ValidateUpdateIncome(double amount, double salary)
        {
            if (amount < Amount)
            {
                double amountDiference = Amount - amount;

                if (salary < amountDiference) throw new InvalidOperationException("No puedes Modificar el ingreso menor de eso p    or falto de Salario");
            }
        }

        internal void ValidateUpdateExit(double amount, double salary)
        {
            if (amount > Amount)
            {
                double amountDiference = amount - Amount;

                if (amountDiference > salary) throw new InvalidOperationException("No puedes Modificar la salida mayor al total Salario");
            }
        }

        public void DeleteMovement(double salary)
        {

            if ((TypeMovement == TypeMovement.Income || TypeMovement == TypeMovement.IncomeTransfer) && Amount > salary)
            {
                TypeMovement = TypeMovement.Exit;
                if (Amount > salary) throw new InvalidOperationException("No puedes Modificar la salida mayor al total Salario");
            }
            else
            {
                TypeMovement = TypeMovement.Income;
            }
            ModifiedSalary();
        }

        public void ModifiedSalary()
        {
            var modifiedSalary = new ModifiedSalaryAccountEvent(AccountId, TypeMovement, Amount);
            _domainEventsAwait.Add(modifiedSalary);
        }

        public void NotificationMovementDestiny(MovementTransfer movementTransfer)
        {
            var storeAccountUserEvent = new NotificacionDestinyMovementEvent(movementTransfer);
            _domainEventsAwait.Add(storeAccountUserEvent);
        }

        public void DeleteMovementDestiny(MovementTransfer movementTransfer)
        {
            var storeAccountUserEvent = new DeleteDestinyMovementEvent(movementTransfer);
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
