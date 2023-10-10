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
using Template.Domain.MovementAggregate;
using Template.Domain.UserAggregate;

namespace Template.Services.Command.MovementTransfers
{
    public class DeleteMovementTransferCommandHandler : BaseCommandHandler<IRepository<MovementTransfer>, DeleteMovementTransferCommand, bool>
    {


        public DeleteMovementTransferCommandHandler(IRepository<MovementTransfer> repository) : base(repository)
        {
        }

        public async override Task<bool> Handle(DeleteMovementTransferCommand request, CancellationToken cancellationToken)
        {

            var movementTransfer = await _repository.GetByIdAsync(request.MovementTransferId);
            _repository.Delete(movementTransfer);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
