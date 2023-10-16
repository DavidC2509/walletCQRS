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
using Template.Domain.MovementAggregate.Events;
using Template.Domain.UserAggregate.Events;
using Template.Services.Services;

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
