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
using Template.Domain.MovementTransferAggregate;
using Template.Domain.UserAggregate;

namespace Template.Services.Command.MovementTransfers
{
    public class UpdateMovementTransferCommandHandler : BaseCommandHandler<IRepository<MovementTransfer>, UpdateMovementTransferCommand, bool>
    {


        public UpdateMovementTransferCommandHandler(IRepository<MovementTransfer> repository) : base(repository)
        {
        }

        public async override Task<bool> Handle(UpdateMovementTransferCommand request, CancellationToken cancellationToken)
        {

            var movementTransfer = await _repository.GetByIdAsync(request.MovementTransferId);
            movementTransfer.UpdateMovementTransfer(request.Amount, request.Date);
            _repository.Update(movementTransfer);
            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
