using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.ClassifiersAggregate;

namespace Template.Services.Command.CategoryAccounts
{
    public class UpdateCategoryAccountCommandHandler : BaseCommandHandler<IRepository<CategoryAccount>, UpdateCategoryAccountCommand, bool>
    {


        public UpdateCategoryAccountCommandHandler(IRepository<CategoryAccount> repository) : base(repository)
        {
        }

        public async override Task<bool> Handle(UpdateCategoryAccountCommand request, CancellationToken cancellationToken)
        {

            var categoryAccount = await _repository.GetByIdAsync(request.Id);
            categoryAccount.UpdateCategoryAccount(request.Name);
            _repository.Update(categoryAccount);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
