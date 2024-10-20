using Core.Cqrs.Domain.Repository;
using MediatR;
using Template.Domain.AccountAggregate;
using Template.Domain.AccountAggregate.Specification;
using Template.Domain.MovementAggregate;
using Template.Domain.MovementTransferAggregate.Events;

namespace Template.Services.HandlerEvents
{
    public class NotificacionOriginMovementEventHandler : INotificationHandler<NotificacionOriginMovementEvent>
    {
        private IRepository<Account> _accountRepository;
        private IRepository<Movement> _movementRepository;

        public NotificacionOriginMovementEventHandler(IRepository<Account> category, IRepository<Movement> movementRepository)
        {
            _accountRepository = category;
            _movementRepository = movementRepository;
        }
        public async Task Handle(NotificacionOriginMovementEvent notification, CancellationToken cancellationToken)
        {
            var spec = new AccountByIdSpec(notification.MovementTransfer.AccountOriginId);
            var account = await _accountRepository.FirstOrDefaultAsync(spec, cancellationToken);

            var movement = await _movementRepository.GetByIdAsync(notification.MovementTransfer.MovementOriginId);
            movement.UpdateMovement(
            notification.MovementTransfer.Amount, "Cambio Transferencia en Movimiento Origen",
            notification.MovementTransfer.Date, account.Salary);
            movement.NotificationMovementDestiny(notification.MovementTransfer);
            _movementRepository.Update(movement);
            await _accountRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
