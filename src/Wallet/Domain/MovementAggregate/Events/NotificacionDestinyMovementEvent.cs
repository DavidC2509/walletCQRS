
using MediatR;
using Template.Domain.MovementTransferAggregate;
namespace Template.Domain.MovementAggregate.Events
{
    public class NotificacionDestinyMovementEvent : INotification
    {
        public MovementTransfer MovementTransfer { get; set; }

        public NotificacionDestinyMovementEvent(MovementTransfer movementTransfer)
        {
            MovementTransfer = movementTransfer;
        }
    }
}