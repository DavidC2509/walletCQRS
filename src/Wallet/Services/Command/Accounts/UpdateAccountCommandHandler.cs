using AutoMapper;
using Core.CommandAndQueryHandler;
using Core.Domain.Repository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.AccountAggregate;
using Template.Domain.ClassifiersAggregate;
using Template.Domain.UserAggregate;

namespace Template.Services.Command.Accounts
{
    public class UpdateAccountCommandHandler : BaseCommandHandler<IRepository<Account>, UpdateAccountCommand, bool>
    {

        private readonly IReadRepository<CategoryAccount> _categoryRepository;

        public UpdateAccountCommandHandler(IRepository<Account> repository, IReadRepository<CategoryAccount> categoryRepository) : base(repository)
        {
            _categoryRepository = categoryRepository;
        }

        public async override Task<bool> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {

            var categoryAccount = await _categoryRepository.GetByIdAsync(request.CategoryAccountId);
            var account = await _repository.GetByIdAsync(request.Id);
            account.UpdateAccount(request.Name, categoryAccount);
            _repository.Update(account);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
