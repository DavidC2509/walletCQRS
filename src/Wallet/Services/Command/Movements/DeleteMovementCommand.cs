using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Services.Command.Movements
{
    public class DeleteMovementCommand : IRequest<bool>
    {
        public Guid MovementId { get; set; }

        public void SetMovementId(Guid movementId)
        {
            MovementId = movementId;
        }

    }
}
