using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.AccountAggregate;
using Template.Domain.ClassifiersAggregate;

namespace Template.Services.Command.Accounts
{
    public class StoreAccountCommandHandler : BaseCommandHandler<IRepository<Account>, StoreAccountCommand, bool>
    {

        private readonly IReadRepository<CategoryAccount> _categoryRepository;

        public StoreAccountCommandHandler(IRepository<Account> repository, IReadRepository<CategoryAccount> categoryRepository) : base(repository)
        {
            _categoryRepository = categoryRepository;
        }

        public async override Task<bool> Handle(StoreAccountCommand request, CancellationToken cancellationToken)
        {

            var categoryAccount = await _categoryRepository.GetByIdAsync(request.CategoryAccountId);
            var account = Account.CreateAccount(request.Name, categoryAccount, request.Salary);
            _repository.Add(account);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
