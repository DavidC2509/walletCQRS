using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.MovementTransferAggregate;

namespace Template.Services.Command.MovementTransfers
{
    public class UpdateMovementTransferCommandHandler : BaseCommandHandler<IRepository<MovementTransfer>, UpdateMovementTransferCommand, bool>
    {


        public UpdateMovementTransferCommandHandler(IRepository<MovementTransfer> repository) : base(repository)
        {
        }

        public async override Task<bool> Handle(UpdateMovementTransferCommand request, CancellationToken cancellationToken)
        {

            var movementTransfer = await _repository.GetByIdAsync(request.MovementTransferId);
            movementTransfer.UpdateMovementTransfer(request.Amount, request.Date);
            _repository.Update(movementTransfer);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
