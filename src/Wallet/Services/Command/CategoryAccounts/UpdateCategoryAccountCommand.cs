using MediatR;

namespace Template.Services.Command.CategoryAccounts
{
    public class UpdateCategoryAccountCommand : IRequest<bool>
    {
        public required string Name { get; set; }
        public required Guid Id { get; set; }

    }
}