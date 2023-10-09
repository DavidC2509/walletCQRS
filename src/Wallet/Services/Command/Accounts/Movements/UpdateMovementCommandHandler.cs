using Core.CommandAndQueryHandler;
using Core.Domain.Repository;
using Template.Domain.AccountAggregate;
using Template.Domain.ClassifiersAggregate;
using Template.Domain.Specification;

namespace Template.Services.Command.Accounts.Movements
{
    public class UpdateMovementCommandHandler : BaseCommandHandler<IRepository<Account>, UpdateMovementCommand, bool>
    {


        public UpdateMovementCommandHandler(IRepository<Account> repository) : base(repository)
        {
        }

        public async override Task<bool> Handle(UpdateMovementCommand request, CancellationToken cancellationToken)
        {
            var spec = new AccountByIdSpec(request.AccountId);
            var account = await _repository.FirstOrDefaultAsync(spec, cancellationToken);


            account.UpdateMovement(request.MovementId,request.Amount, request.Descripcion, request.Date);

            _repository.Update(account);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
