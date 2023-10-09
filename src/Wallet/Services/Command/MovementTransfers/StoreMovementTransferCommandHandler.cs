using Core.CommandAndQueryHandler;
using Core.Domain.Repository;
using Template.Domain.AccountAggregate;
using Template.Domain.ClassifiersAggregate;
using Template.Domain.ClassifiersAggregate.Specification;
using Template.Domain.MovementAggregate;
using Template.Domain.Specification;

namespace Template.Services.Command.MovementTransfers
{
    public class StoreMovementTransferCommandHandler : BaseCommandHandler<IRepository<MovementTransfer>, StoreMovementTransferCommand, bool>
    {

        private readonly IReadRepository<CategoryMovement> _categoryRepository;
        private readonly IRepository<Account> _accountRepository;

        public StoreMovementTransferCommandHandler(IRepository<MovementTransfer> repository
        , IReadRepository<CategoryMovement> categoryRepository, IRepository<Account> accountRepository) : base(repository)
        {
            _categoryRepository = categoryRepository;
            _accountRepository = accountRepository;
        }

        public async override Task<bool> Handle(StoreMovementTransferCommand request, CancellationToken cancellationToken)
        {
            var specOrigin = new AccountByIdSpec(request.AccountOrigin);
            var accountOrigin = await _accountRepository.FirstOrDefaultAsync(specOrigin, cancellationToken);


            var specDestiny = new AccountByIdSpec(request.AccountOrigin);
            var accountDestiny = await _accountRepository.FirstOrDefaultAsync(specDestiny, cancellationToken);

            var specCategory = new CategoryMovementTransferSpec();
            var categoryMovement = await _categoryRepository.FirstOrDefaultAsync(specCategory, cancellationToken);

            accountOrigin.AddMovement(categoryMovement, TypeMovement.ExitTransfer, request.Amount, "Transferencia de cuenta Salidad", DateTime.Now);
            accountDestiny.AddMovement(categoryMovement, TypeMovement.IncomeTransfer, request.Amount, "Transferencia de cuenta Entrada", DateTime.Now);

            _accountRepository.Update(accountOrigin);
            _accountRepository.Update(accountDestiny);

            await _accountRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            var movementTransfer = new MovementTransfer(accountOrigin.Movements.Last().Id, accountOrigin.Name,
            accountDestiny.Movements.Last().Id, accountDestiny.Name, request.Amount);

            _repository.Add(movementTransfer);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return true;
        }
    }
}
