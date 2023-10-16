
using MediatR;
using Template.Domain.MovementTransferAggregate;
namespace Template.Domain.MovementAggregate.Events
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