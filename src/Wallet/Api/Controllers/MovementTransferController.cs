
using Core.Controller;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Template.Services.Command.MovementTransfers;
using Template.Services.Models;
using Template.Services.Query.MovementTransfers;

namespace Template.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/movement-transfer")]
    public class MovementTransferController : ServiceBaseController
    {
        public MovementTransferController(IMediator mediator) : base(mediator) { }

        ///<summary>
        ///Listado Cuenta
        ///</summary>
        [HttpGet("list")]
        [Authorize]
        public Task<ActionResult<IEnumerable<MovementTransferModel>>> ListAccount() => SendRequest(new ListMovementTransferQuery());



        ///<summary>
        ///Crear movimiento transferencia
        ///</summary>
        [HttpPost()]
        [Authorize]
        public Task<ActionResult<bool>> StoreMovementTransfer([FromBody] StoreMovementTransferCommand command) => SendRequest(command);


        ///<summary>
        ///Actualizar movimiento transferencia
        ///</summary>
        [HttpPut("{idMovementTransfer}")]
        [Authorize]
        public Task<ActionResult<bool>> UpdateMovementTransfer(Guid idMovementTransfer, [FromBody] UpdateMovementTransferCommand command)
        {
            command.SetMovementTransferId(idMovementTransfer);

            return SendRequest(command);
        }

        ///<summary>
        ///Eleminar movimiento
        ///</summary>
        [HttpDelete("{idMovementTransfer}")]
        [Authorize]
        public Task<ActionResult<bool>> DeleteTransferMovement(Guid idMovementTransfer, [FromBody] DeleteMovementTransferCommand command)
        {
            command.SetMovementTransferId(idMovementTransfer);
            return SendRequest(command);
        }


    }
}
