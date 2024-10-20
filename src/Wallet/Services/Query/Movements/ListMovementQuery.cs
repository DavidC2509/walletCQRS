using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Services.Models;

namespace Template.Services.Query.Movements
{
    public class ListMovementQuery : IRequest<IEnumerable<MovementModel>>
    {
        [FromQuery(Name = "startDate")]
        public DateTime? StartDate { get; set; } = null;

        [FromQuery(Name = "endDate")]
        public DateTime? EndDate { get; set; } = null;

        [FromQuery(Name = "typeMovement")]
        public TypeMovement? TypeMpvement { get; set; } = null;

        [FromQuery(Name = "accountId")]
        public Guid? AccountId { get; set; } = null;
    }
}
