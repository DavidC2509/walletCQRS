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
using Template.Services.Query.Users;

namespace Template.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/account")]
    public class AccountController : ServiceBaseController
    {
        public AccountController(IMediator mediator) : base(mediator) { }

        ///<summary>
        ///Listado Cuenta
        ///</summary>
        [HttpGet("list")]
        [Authorize]
        public Task<ActionResult<IEnumerable<AccountModel>>> ListAccount() => SendRequest(new ListAccountQuery());

        ///<summary>
        ///Obtener Cuenta
        ///</summary>
        [HttpGet("{id}")]
        [Authorize]
        public Task<ActionResult<AccountModel>> GetAccount(Guid id) => SendRequest(new AccountByIdQuery(id));

        ///<summary>
        ///Crear Cuenta
        ///</summary>
        [HttpPost()]
        [Authorize]
        public Task<ActionResult<bool>> StoreAccout([FromBody] StoreAccountCommand command) => SendRequest(command);


        ///<summary>
        ///Actualizar cuenta
        ///</summary>
        [HttpPut()]
        [Authorize]
        public Task<ActionResult<bool>> UpdateAccount([FromBody] UpdateAccountCommand command) => SendRequest(command);

    }
}
