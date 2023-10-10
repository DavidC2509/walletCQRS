
using MediatR;
using Template.Domain.MovementAggregate;
namespace Template.Domain.AccountAggregate.Events
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