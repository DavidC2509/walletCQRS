using MediatR;

namespace Template.Services.Command.Movements
{
    public class UpdateMovementCommand : IRequest<bool>
    {
        public Guid MovementId { get; set; }

        public string Descripcion { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public UpdateMovementCommand()
        {
            Descripcion = string.Empty;
        }

        public void SetMovementId(Guid movementId)
        {
            MovementId = movementId;
        }
    }
}