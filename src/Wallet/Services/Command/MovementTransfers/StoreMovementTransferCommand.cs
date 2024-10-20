using MediatR;

namespace Template.Services.Command.MovementTransfers
{
    public class StoreMovementTransferCommand : IRequest<bool>
    {
        public Guid AccountOrigin { get; set; }
        public Guid AccountDestiny { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

    }
}