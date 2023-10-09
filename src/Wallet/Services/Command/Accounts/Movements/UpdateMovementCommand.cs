using MediatR;

namespace Template.Services.Command.Accounts.Movements
{
    public class UpdateMovementCommand : IRequest<bool>
    {
        public Guid AccountId { get; set; }
        public Guid MovementId { get; set; }

        public string Descripcion { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public UpdateMovementCommand()
        {
            Descripcion = string.Empty;
        }
        
        public void SetAccountId(Guid accountId)
        {
            AccountId = accountId;
        }
        public void SetMovementId(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}