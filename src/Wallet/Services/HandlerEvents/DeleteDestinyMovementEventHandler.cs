using Core.Domain.Repository;
using MediatR;
using Template.Domain.AccountAggregate;
using Template.Domain.AccountAggregate.Events;
using Template.Domain.Specification;


namespace Template.Services.HandlerEvents
{
    public class DeleteDestinyMovementEventHandler : INotificationHandler<DeleteDestinyMovementEvent>
    {
        private IRepository<Account> _accountRepository;

        public DeleteDestinyMovementEventHandler(IRepository<Account> category)
        {
            _accountRepository = category;
        }

        public async Task Handle(DeleteDestinyMovementEvent notification, CancellationToken cancellationToken)
        {
            var spec = new AccountByIdSpec(notification.MovementTransfer.AccountDestinyId);
            var account = await _accountRepository.FirstOrDefaultAsync(spec, cancellationToken);
            account.DeleteMovement(notification.MovementTransfer.MovementDestitnyId);
            await _accountRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
