using Core.Controller;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Template.Services.Command.Users;
using Template.Services.Models;
using Template.Services.Query.Users;

namespace Template.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    [ApiController]
    public class UserController : ServiceBaseController
    {
        public UserController(IMediator mediator) : base(mediator) { }

        ///<summary>
        ///Crear Factura
        ///</summary>
        [HttpPost()]
        public Task<ActionResult<IdentityResult>> StoreUser([FromBody] StoreUserCommand command) => SendRequest(command);


        ///<summary>
        ///Login
        ///</summary>
        [HttpPost("login")]
        public Task<ActionResult<LoginModels>> LoginUser([FromBody] LoginQuery command) => SendRequest(command);


        ///<summary>
        ///Login
        ///</summary>
        [HttpGet("info")]
        [Authorize]
        public Task<ActionResult<InfoUserModel>> InfoUser() => SendRequest(new InfoQuery());

    }
}
