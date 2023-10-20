using MediatR;

namespace Template.Services.Command.Accounts
{
    public class UpdateAccountCommand : IRequest<bool>
    {
        public required string Name { get; set; }
        public required Guid CategoryAccountId { get; set; }
        public required Guid Id {get; set;}
    }
}