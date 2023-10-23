using MediatR;
using Template.Services.Models;

namespace Template.Services.Query.MovementTransfers
{
    public class MovementTransferByIdQuery : IRequest<MovementTransferModel>
    {
        public Guid Id { get; set; }

        public MovementTransferByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
