using Core.CommandAndQueryHandler;
using Core.Domain.Repository;
using Template.Domain.AccountAggregate;
using Template.Domain.ClassifiersAggregate;

namespace Template.Services.Command.CategoryAccounts
{
    public class StoreCategoryAccountCommandHandler : BaseCommandHandler<IRepository<CategoryAccount>, StoreCategoryAccountCommand, bool>
    {


        public StoreCategoryAccountCommandHandler(IRepository<CategoryAccount> repository) : base(repository)
        {
        }

        public async override Task<bool> Handle(StoreCategoryAccountCommand request, CancellationToken cancellationToken)
        {

            var categoryAccount = new CategoryAccount(request.Name);
            _repository.Add(categoryAccount);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
