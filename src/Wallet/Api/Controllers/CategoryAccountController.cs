using ControllerCqrs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Template.Services.Command.CategoryAccounts;
using Template.Services.Models;
using Template.Services.Query.CategoryAccounts;

namespace Template.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/category-account")]
    public class CategoryAccountController : ServiceBaseController
    {
        public CategoryAccountController(IMediator mediator) : base(mediator) { }


        [HttpGet("list")]
        [Authorize]
        public Task<ActionResult<IEnumerable<ClassifierModel>>> ListAccount() => SendRequest(new ListCategoryAccountQuery());


        [HttpGet("{id}")]
        [Authorize]
        public Task<ActionResult<ClassifierModel>> GetAccount(Guid id) => SendRequest(new CategoryAccountByIdQuery(id));



        ///<summary>
        ///Categoria cuenta
        ///</summary>
        [HttpPost()]
        [Authorize]
        public Task<ActionResult<bool>> StoreAccout([FromBody] StoreCategoryAccountCommand command) => SendRequest(command);


        ///<summary>
        ///Actualizar categoria cuenta
        ///</summary>
        [HttpPut()]
        [Authorize]
        public Task<ActionResult<bool>> UpdateAccount([FromBody] UpdateCategoryAccountCommand command) => SendRequest(command);

    }
}
