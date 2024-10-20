

using Ardalis.Specification;

namespace Template.Domain.MovementTransferAggregate.Specification

{
    public class MovementTransferListSpec : Specification<MovementTransfer>
    {
        public MovementTransferListSpec(DateTime? dateInit, DateTime? dateEnd, Guid? accountId)
        {
            Query
           .Where(c =>
            dateInit == null || dateEnd == null ||
            Convert.ToDateTime(c.Date.ToString("d")) >= dateInit && Convert.ToDateTime(c.Date.ToString("d")) <= dateEnd
        )
        .Where(c => accountId == null || c.AccountOriginId == accountId)
        .Where(c => accountId == null || c.AccountDestinyId == accountId);

        }
    }
}