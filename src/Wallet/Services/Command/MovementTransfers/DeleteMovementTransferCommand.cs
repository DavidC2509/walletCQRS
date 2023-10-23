
using System;
using MediatR;

namespace Template.Services.Command.MovementTransfers
{
    public class DeleteMovementTransferCommand : IRequest<bool>
    {
        public Guid MovementTransferId { get; set; }

        public DeleteMovementTransferCommand(Guid id)
        {
            MovementTransferId = id;
        }
    }
}