using MediatR;
using Template.Services.Models;

namespace Template.Services.Query.MovementTransfers
{
    public class ListMovementTransferQuery : IRequest<IEnumerable<MovementTransferModel>>
    {

    }
}