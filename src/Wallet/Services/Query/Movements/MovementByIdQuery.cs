using MediatR;
using Template.Services.Models;

namespace Template.Services.Query.Movements
{
    public class MovementByIdQuery : IRequest<MovementModel>
    {
        public Guid Id { get; set; }

        public MovementByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
