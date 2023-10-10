using AutoMapper;
using Core.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.AccountAggregate;
using Template.Domain.AccountAggregate.Events;
using Template.Domain.ClassifiersAggregate;
using Template.Domain.ClassifiersAggregate.Events;
using Template.Domain.Interface;
using Template.Domain.MovementAggregate.Events;
using Template.Domain.Specification;
using Template.Domain.UserAggregate.Events;
using Template.Services.Services;

namespace Template.Services.HandlerEvents
{
    public class NotificacionDestinyMovementEventHandler : INotificationHandler<NotificacionDestinyMovementEvent>
    {
        private IRepository<Account> _accountRepository;

        public NotificacionDestinyMovementEventHandler(IRepository<Account> category)
        {
            _accountRepository = category;
        }

        public async Task Handle(NotificacionDestinyMovementEvent notification, CancellationToken cancellationToken)
        {
            var spec = new AccountByIdSpec(notification.MovementTransfer.AccountDestinyId);
            var account = await _accountRepository.FirstOrDefaultAsync(spec, cancellationToken);
            account.UpdateMovement(notification.MovementTransfer.MovementDestitnyId,
            notification.MovementTransfer.Amount, "Cambio Transferencia en Movimiento Destino",
            notification.MovementTransfer.Date);
            await _accountRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
