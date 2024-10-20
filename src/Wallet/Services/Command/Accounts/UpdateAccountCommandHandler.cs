using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.AccountAggregate;
using Template.Domain.ClassifiersAggregate;

namespace Template.Services.Command.Accounts
{
    public class UpdateAccountCommandHandler : BaseCommandHandler<IRepository<Account>, UpdateAccountCommand, bool>
    {

        private readonly IReadRepository<CategoryAccount> _categoryRepository;

        public UpdateAccountCommandHandler(IRepository<Account> repository, IReadRepository<CategoryAccount> categoryRepository) : base(repository)
        {
            _categoryRepository = categoryRepository;
        }

        public async override Task<bool> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {

            var categoryAccount = await _categoryRepository.GetByIdAsync(request.CategoryAccountId);
            var account = await _repository.GetByIdAsync(request.Id);
            account.UpdateAccount(request.Name, request.Salary, categoryAccount);
            _repository.Update(account);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
