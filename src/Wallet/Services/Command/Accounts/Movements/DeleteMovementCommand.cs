using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Services.Command.Accounts.Movements
{
    public class DeleteMovementCommand : IRequest<bool>
    {
        public Guid AccountId { get; set; }
        public Guid MovementId { get; set; }

    
        public void SetAccountId(Guid accountId)
        {
            AccountId = accountId;
        }
        public void SetMovementId(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
