using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.MovementTransferAggregate;

namespace Template.Services.Command.MovementTransfers
{
    public class DeleteMovementTransferCommandHandler : BaseCommandHandler<IRepository<MovementTransfer>, DeleteMovementTransferCommand, bool>
    {


        public DeleteMovementTransferCommandHandler(IRepository<MovementTransfer> repository) : base(repository)
        {
        }

        public async override Task<bool> Handle(DeleteMovementTransferCommand request, CancellationToken cancellationToken)
        {
            var movementTransfer = await _repository.GetByIdAsync(request.MovementTransferId);
            movementTransfer.DeleteOriginAccount();
            _repository.Delete(movementTransfer);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
