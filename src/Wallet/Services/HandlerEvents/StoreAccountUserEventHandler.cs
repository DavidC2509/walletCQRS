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
using Template.Domain.UserAggregate.Events;
using Template.Services.Services;

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
            var account = new Account("Efectivo", notification.CategoryAccount);
            _category.Add(account);
            await _category.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
