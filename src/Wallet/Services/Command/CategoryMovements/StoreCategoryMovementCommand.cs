using MediatR;

namespace Template.Services.Command.CategoryMovements
{
    public class StoreCategoryMovementCommand : IRequest<bool>
    {
        public required string Name { get; set; }
    }
}