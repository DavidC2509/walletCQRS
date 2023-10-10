
using MediatR;
namespace Template.Domain.MovementAggregate.Events
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