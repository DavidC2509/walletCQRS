using Core.Cqrs.Domain.Repository;
using MediatR;
using Template.Domain.AccountAggregate;
using Template.Domain.MovementAggregate.Events;

namespace Template.Services.HandlerEvents
{
    public class ModifiedSalaryAccountEventHandler : INotificationHandler<ModifiedSalaryAccountEvent>
    {
        private IRepository<Account> _repository;

        public ModifiedSalaryAccountEventHandler(IRepository<Account> category)
        {
            _repository = category;
        }

        public async Task Handle(ModifiedSalaryAccountEvent notification, CancellationToken cancellationToken)
        {
            var account = await _repository.GetByIdAsync(notification.AccountId);

            account.UpdateSalary(notification.Amount, notification.TypeMovement);

            _repository.Update(account);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
