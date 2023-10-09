using Core.CommandAndQueryHandler;
using Core.Domain.Repository;
using Template.Domain.AccountAggregate;
using Template.Domain.ClassifiersAggregate;
using Template.Domain.Specification;

namespace Template.Services.Command.Accounts.Movements
{
    public class StoreMovementCommandHandler : BaseCommandHandler<IRepository<Account>, StoreMovementCommand, bool>
    {

        private readonly IReadRepository<CategoryMovement> _categoryRepository;

        public StoreMovementCommandHandler(IRepository<Account> repository
        , IReadRepository<CategoryMovement> categoryRepository) : base(repository)
        {
            _categoryRepository = categoryRepository;
        }

        public async override Task<bool> Handle(StoreMovementCommand request, CancellationToken cancellationToken)
        {
            var spec = new AccountByIdSpec(request.AccountId);
            var account = await _repository.FirstOrDefaultAsync(spec, cancellationToken);


            var categoryMovement = await _categoryRepository.GetByIdAsync(request.CategoryMovementId, cancellationToken);

            account.AddMovement(categoryMovement, request.TypeMovement, request.Amount, request.Descripcion,request.Date);

            _repository.Update(account);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
