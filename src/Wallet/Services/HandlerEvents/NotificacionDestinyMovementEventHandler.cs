using AutoMapper;
using Core.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.AccountAggregate;
using Template.Domain.ClassifiersAggregate;
using Template.Domain.ClassifiersAggregate.Events;
using Template.Domain.Interface;
using Template.Domain.MovementAggregate;
using Template.Domain.MovementAggregate.Events;
using Template.Domain.MovementTransferAggregate.Events;
using Template.Domain.Specification;
using Template.Domain.UserAggregate.Events;
using Template.Services.Services;

namespace Template.Services.HandlerEvents
{
    public class NotificacionDestinyMovementEventHandler : INotificationHandler<NotificacionDestinyMovementEvent>
    {
        private IRepository<Account> _accountRepository;
        private IRepository<Movement> _movementRepository;

        public NotificacionDestinyMovementEventHandler(IRepository<Account> category, IRepository<Movement> movementRepository)
        {
            _accountRepository = category;
            _movementRepository = movementRepository;
        }

        public async Task Handle(NotificacionDestinyMovementEvent notification, CancellationToken cancellationToken)
        {
            var spec = new AccountByIdSpec(notification.MovementTransfer.AccountDestinyId);
            var account = await _accountRepository.FirstOrDefaultAsync(spec, cancellationToken);
            var movement = await _movementRepository.GetByIdAsync(notification.MovementTransfer.MovementDestitnyId);
            movement.UpdateMovement(
            notification.MovementTransfer.Amount, "Cambio Transferencia en Movimiento Destino",
            notification.MovementTransfer.Date, account.Salary);
            _movementRepository.Update(movement);

            await _accountRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
