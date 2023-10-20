using MediatR;

namespace Template.Services.Command.Accounts
{
    public class StoreAccountCommand : IRequest<bool>
    {
        public required string Name { get; set; }
        public double Salary { get; set; }
        public required Guid CategoryAccountId { get; set; }
    }
}