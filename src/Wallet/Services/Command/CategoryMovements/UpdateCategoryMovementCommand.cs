using MediatR;

namespace Template.Services.Command.CategoryMovements
{
    public class UpdateCategoryMovementCommand : IRequest<bool>
    {
        public required string Name { get; set; }
        public required Guid Id { get; set; }

    }
}