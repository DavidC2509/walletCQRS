using MediatR;
using Template.Services.Models;

namespace Template.Services.Query.AccountQuery
{
    public class ListAccountQuery : IRequest<IEnumerable<AccountModel>>
    {

    }
}
