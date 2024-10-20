using Core.Cqrs.Domain.Repository;
using MediatR;
using Template.Domain.AccountAggregate;
using Template.Domain.ClassifiersAggregate.Events;

namespace Template.Services.HandlerEvents
{
    public class StoreAccountUserEventHandler : INotificationHandler<StoreAccountUserEvent>
    {
        private IRepository<Account> _category;

        public StoreAccountUserEventHandler(IRepository<Account> category)
        {
            _category = category;
        }

        public async Task Handle(StoreAccountUserEvent notification, CancellationToken cancellationToken)
        {
            var account = Account.CreateAccount("Efectivo", notification.CategoryAccount, 0);
            _category.Add(account);
            await _category.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
