using MediatR;
using Template.Services.Models;

namespace Template.Services.Query.Movements
{
    public class ListMovementQuery : IRequest<IEnumerable<MovementModel>>
    {
    
    }
}
