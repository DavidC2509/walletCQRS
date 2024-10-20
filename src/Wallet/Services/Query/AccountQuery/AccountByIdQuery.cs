using MediatR;
using Template.Services.Models;

namespace Template.Services.Query.AccountQuery
{
    public class AccountByIdQuery : IRequest<AccountModel>
    {
        public Guid Id { get; set; }

        public AccountByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
