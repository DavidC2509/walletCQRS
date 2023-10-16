
using MediatR;
namespace Template.Domain.MovementTransferAggregate.Events
{
    public class NotificacionOriginMovementEvent : INotification
    {
        public MovementTransfer MovementTransfer { get; set; }

        public NotificacionOriginMovementEvent(MovementTransfer movementTransfer)
        {
            MovementTransfer = movementTransfer;
        }
    }
}