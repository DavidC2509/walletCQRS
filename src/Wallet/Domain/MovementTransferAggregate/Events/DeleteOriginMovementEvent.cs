
using MediatR;
namespace Template.Domain.MovementTransferAggregate.Events
{
    public class DeleteOriginMovementEvent : INotification
    {
        public MovementTransfer MovementTransfer { get; set; }

        public DeleteOriginMovementEvent(MovementTransfer movementTransfer)
        {
            MovementTransfer = movementTransfer;
        }
    }
}