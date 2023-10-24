using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Services.Models;

namespace Template.Services.Query.MovementTransfers
{
    public class ListMovementTransferQuery : IRequest<IEnumerable<MovementTransferModel>>
    {
        [FromQuery(Name = "startDate")]
        public DateTime? StartDate { get; set; } = null;

        [FromQuery(Name = "endDate")]
        public DateTime? EndDate { get; set; } = null;

        [FromQuery(Name = "accountId")]
        public Guid? AccountId { get; set; } = null;
    }
}