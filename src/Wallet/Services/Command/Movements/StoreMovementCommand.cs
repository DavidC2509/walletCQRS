using MediatR;

namespace Template.Services.Command.Movements
{
    public class StoreMovementCommand : IRequest<bool>
    {
        public Guid AccountId { get; set; }
        public string Descripcion { get; set; }
        public double Amount { get; set; }
        public Guid CategoryMovementId { get; set; }
        public TypeMovement TypeMovement { get; set; }
        public DateTime Date { get; set; }

        public StoreMovementCommand()
        {
            Descripcion = string.Empty;
        }

        public void SetAccountId(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}