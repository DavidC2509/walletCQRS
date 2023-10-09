using MediatR;
using Template.Services.Models;

namespace Template.Services.Query.CategoryAccounts
{
    public class ListCategoryAccountQuery : IRequest<IEnumerable<ClassifierModel>>
    {

    }
}