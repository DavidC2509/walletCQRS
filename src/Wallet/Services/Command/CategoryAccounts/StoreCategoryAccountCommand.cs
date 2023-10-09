using MediatR;

namespace Template.Services.Command.CategoryAccounts
{
    public class StoreCategoryAccountCommand : IRequest<bool>
    {
        public required string Name { get; set; }
    }
}