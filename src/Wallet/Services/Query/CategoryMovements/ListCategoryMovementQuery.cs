using MediatR;
using Template.Services.Models;

namespace Template.Services.Query.CategoryMovements
{
    public class ListCategoryMovementQuery : IRequest<IEnumerable<ClassifierModel>>
    {

    }
}