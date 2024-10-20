using MediatR;

namespace Template.Services.Command.Movements
{
    public class DeleteMovementCommand : IRequest<bool>
    {
        public Guid MovementId { get; set; }

        public DeleteMovementCommand(Guid id)
        {
            MovementId = id;
        }

    }
}
