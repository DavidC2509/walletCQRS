
using MediatR;
using Template.Domain.MovementAggregate;
namespace Template.Domain.AccountAggregate.Events
{
    public class DeleteDestinyMovementEvent : INotification
    {
        public MovementTransfer MovementTransfer { get; set; }

        public DeleteDestinyMovementEvent(MovementTransfer movementTransfer)
        {
            MovementTransfer = movementTransfer;
        }
    }
}