
using MediatR;

namespace Template.Services.Command.MovementTransfers
{
    public class UpdateMovementTransferCommand : IRequest<bool>
    {
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public Guid MovementTransferId { get; set; }

        public void SetMovementTransferId(Guid movementTransferId)
        {
            MovementTransferId = movementTransferId;
        }
    }
}