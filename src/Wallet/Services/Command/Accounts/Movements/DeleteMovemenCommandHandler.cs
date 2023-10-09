using Core.CommandAndQueryHandler;
using Core.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.AccountAggregate;
using Template.Domain.Specification;

namespace Template.Services.Command.Accounts.Movements
{
    public class DeleteMovemenCommandHandler : BaseCommandHandler<IRepository<Account>, DeleteMovementCommand, bool>
    {


        public DeleteMovemenCommandHandler(IRepository<Account> repository) : base(repository)
        {
        }

        public async override Task<bool> Handle(DeleteMovementCommand request, CancellationToken cancellationToken)
        {
            var spec = new AccountByIdSpec(request.AccountId);
            var account = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
            account.DeleteMovement(request.MovementId);
            _repository.Update(account);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
