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
using Template.Domain.MovementTransferAggregate.Events;
using Template.Domain.Specification;
using Template.Domain.UserAggregate.Events;
using Template.Services.Services;

namespace Template.Services.HandlerEvents
{
    public class DeleteOriginMovementEventHandler : INotificationHandler<DeleteOriginMovementEvent>
    {
        private IReadRepository<Account> _accountRepository;
        private IRepository<Movement> _movementRepository;

        public DeleteOriginMovementEventHandler(IReadRepository<Account> category, IRepository<Movement> movementRepository)
        {
            _accountRepository = category;
            _movementRepository = movementRepository;
        }

        public async Task Handle(DeleteOriginMovementEvent notification, CancellationToken cancellationToken)
        {
            var spec = new AccountByIdSpec(notification.MovementTransfer.AccountOriginId);
            var account = await _accountRepository.FirstOrDefaultAsync(spec, cancellationToken);

            var movement = await _movementRepository.GetByIdAsync(notification.MovementTransfer.MovementOriginId);
            movement.DeleteMovement(account.Salary);
            movement.DeleteMovementDestiny(notification.MovementTransfer);
            _movementRepository.Delete(movement);
            await _movementRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
