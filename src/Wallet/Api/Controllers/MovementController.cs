using Core.Controller;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Template.Services.Command.Accounts;
using Template.Services.Command.Movements;
using Template.Services.Command.Users;
using Template.Services.Models;
using Template.Services.Query.Accounts;
using Template.Services.Query.Movements;
using Template.Services.Query.Users;

namespace Template.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/movement")]
    public class MovementController : ServiceBaseController
    {
        public MovementController(IMediator mediator) : base(mediator) { }

        ///<summary>
        ///Listado Movimiento
        ///</summary>
        [HttpGet("list")]
        [Authorize]
        public Task<ActionResult<IEnumerable<MovementModel>>> ListAccount([FromQuery] ListMovementQuery query) => SendRequest(query);

        ///<summary>
        ///Obtener Movimiento
        ///</summary>
        [HttpGet("{id}")]
        [Authorize]
        public Task<ActionResult<MovementModel>> GetAccount(Guid id) => SendRequest(new MovementByIdQuery(id));



        ///<summary>
        ///Crear movimiento
        ///</summary>
        [HttpPost("account/{id}")]
        [Authorize]
        public Task<ActionResult<bool>> StoreMovement(Guid id, [FromBody] StoreMovementCommand command)
        {
            command.SetAccountId(id);
            return SendRequest(command);
        }


        ///<summary>
        ///Actualizar movimiento
        ///</summary>
        [HttpPut("{idMovement}")]
        [Authorize]
        public Task<ActionResult<bool>> UpdateMovement(Guid idMovement, [FromBody] UpdateMovementCommand command)
        {
            command.SetMovementId(idMovement);
            return SendRequest(command);
        }


        ///<summary>
        ///Eleminar movimiento
        ///</summary>
        [HttpDelete("{idMovement}")]
        [Authorize]
        public Task<ActionResult<bool>> DeleteMovement(Guid idMovement) => SendRequest(new DeleteMovementCommand(idMovement));

    }
}
