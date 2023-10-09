using MediatR;
using Template.Services.Models;

namespace Template.Services.Query.Accounts
{
    public class ListAccountQuery : IRequest<IEnumerable<AccountModel>>
    {
    
    }
}
