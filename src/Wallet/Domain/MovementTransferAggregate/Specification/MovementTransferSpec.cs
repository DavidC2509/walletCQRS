

using Ardalis.Specification;
using Template.Domain.AccountAggregate;
using Template.Domain.MovementAggregate;
using Template.Domain.MovementTransferAggregate;

namespace Template.Domain.Specification

{
    public class MovementTransferListSpec : Specification<MovementTransfer>
    {
        public MovementTransferListSpec(DateTime? dateInit, DateTime? dateEnd, Guid? accountId)
        {
            Query
           .Where(c =>
            dateInit == null || dateEnd == null ||
            (Convert.ToDateTime(c.Date.ToString("d")) >= dateInit && Convert.ToDateTime(c.Date.ToString("d")) <= dateEnd)
        )
        .Where(c => accountId == null || c.AccountOriginId == accountId)
        .Where(c => accountId == null || c.AccountDestinyId == accountId);

        }
    }
}