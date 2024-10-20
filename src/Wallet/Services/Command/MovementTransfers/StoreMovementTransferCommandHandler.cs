using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.AccountAggregate;
using Template.Domain.AccountAggregate.Specification;
using Template.Domain.ClassifiersAggregate;
using Template.Domain.ClassifiersAggregate.Specification;
using Template.Domain.MovementAggregate;
using Template.Domain.MovementTransferAggregate;

namespace Template.Services.Command.MovementTransfers
{
    public class StoreMovementTransferCommandHandler : BaseCommandHandler<IRepository<MovementTransfer>, StoreMovementTransferCommand, bool>
    {

        private readonly IReadRepository<CategoryMovement> _categoryRepository;
        private readonly IReadRepository<Account> _accountRepository;
        private readonly IRepository<Movement> _movementRepository;

        public StoreMovementTransferCommandHandler(IRepository<MovementTransfer> repository
        , IReadRepository<CategoryMovement> categoryRepository, IReadRepository<Account> accountRepository,
        IRepository<Movement> movementRepository) : base(repository)
        {
            _categoryRepository = categoryRepository;
            _accountRepository = accountRepository;
            _movementRepository = movementRepository;
        }

        public async override Task<bool> Handle(StoreMovementTransferCommand request, CancellationToken cancellationToken)
        {
            var specOrigin = new AccountByIdSpec(request.AccountOrigin);
            var accountOrigin = await _accountRepository.FirstOrDefaultAsync(specOrigin, cancellationToken);


            var specDestiny = new AccountByIdSpec(request.AccountDestiny);
            var accountDestiny = await _accountRepository.FirstOrDefaultAsync(specDestiny, cancellationToken);

            var specCategory = new CategoryMovementTransferSpec();
            var categoryMovement = await _categoryRepository.FirstOrDefaultAsync(specCategory, cancellationToken);

            var movementOrigin = Movement.AddMovement(categoryMovement, TypeMovement.ExitTransfer, request.Amount, "Transferencia de cuenta Salidad",
            request.Date, request.AccountOrigin, accountOrigin.Salary);
            var movementDestiny = Movement.AddMovement(categoryMovement, TypeMovement.IncomeTransfer, request.Amount, "Transferencia de cuenta Entrada",
            request.Date, request.AccountDestiny, accountDestiny.Salary);

            _movementRepository.Add(movementOrigin);
            _movementRepository.Add(movementDestiny);

            await _movementRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            var movementTransfer = new MovementTransfer(accountOrigin.Id, movementOrigin.Id, accountOrigin.Name,
            accountDestiny.Id, movementDestiny.Id, accountDestiny.Name, request.Amount, request.Date);

            _repository.Add(movementTransfer);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return true;
        }
    }
}
