
using MediatR;
namespace Template.Domain.MovementAggregate.Events
{
    public class ModifiedSalaryAccountEvent : INotification
    {
        public Guid AccountId { get; set; }
        public TypeMovement TypeMovement { get; set; }
        public double Amount { get; set; }

        public ModifiedSalaryAccountEvent(Guid accountId, TypeMovement typeMovement, double amount)
        {
            AccountId = accountId;
            TypeMovement = typeMovement;
            Amount = amount;
        }
    }
}