using Core.Controller;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Template.Services.Command.CategoryMovements;
using Template.Services.Models;
using Template.Services.Query.CategoryMovements;
namespace Template.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/category-movement")]
    public class CategoryMovementController : ServiceBaseController
    {
        public CategoryMovementController(IMediator mediator) : base(mediator) { }


        [HttpGet("list")]
        [Authorize]
        public Task<ActionResult<IEnumerable<ClassifierModel>>> ListAccount() => SendRequest(new ListCategoryMovementQuery());

        [HttpGet("{id}")]
        [Authorize]
        public Task<ActionResult<ClassifierModel>> GetAccount(Guid id) => SendRequest(new CategoryMovementByIdQuery(id));


        ///<summary>
        ///Categoria movimiento
        ///</summary>
        [HttpPost()]
        [Authorize]
        public Task<ActionResult<bool>> StoreAccout([FromBody] StoreCategoryMovementCommand command) => SendRequest(command);


        ///<summary>
        ///Actualizar categoria movimiento
        ///</summary>
        [HttpPut()]
        [Authorize]
        public Task<ActionResult<bool>> UpdateAccount([FromBody] UpdateCategoryMovementCommand command) => SendRequest(command);

    }
}
