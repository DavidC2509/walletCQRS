
// using Core.Controller;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;

// namespace Template.Api.Controllers
// {
//     [Produces("application/json")]
//     [Route("api/movement-transfer")]
//     public class MovementTransferController : ServiceBaseController
//     {
//         public MovementTransferController(IMediator mediator) : base(mediator) { }

//         ///<summary>
//         ///Listado Cuenta
//         ///</summary>
//         [HttpGet("list")]
//         [Authorize]
//         public Task<ActionResult<IEnumerable<AccountModel>>> ListAccount() => SendRequest(new ListAccountQuery());

//         ///<summary>
//         ///Obtener Cuenta
//         ///</summary>
//         [HttpGet("{id}")]
//         [Authorize]
//         public Task<ActionResult<AccountModel>> GetAccount(Guid id) => SendRequest(new AccountByIdQuery(id));

//         ///<summary>
//         ///Crear Cuenta
//         ///</summary>
//         [HttpPost()]
//         [Authorize]
//         public Task<ActionResult<bool>> StoreAccout([FromBody] StoreAccountCommand command) => SendRequest(command);


//         ///<summary>
//         ///Actualizar cuenta
//         ///</summary>
//         [HttpPut()]
//         [Authorize]
//         public Task<ActionResult<bool>> UpdateAccount([FromBody] UpdateAccountCommand command) => SendRequest(command);




    

//     }
// }
