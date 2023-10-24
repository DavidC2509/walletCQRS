

using Ardalis.Specification;
using Template.Domain.AccountAggregate;
using Template.Domain.MovementAggregate;

namespace Template.Domain.Specification

{
    public class MovementListSpec : Specification<Movement>
    {
        public MovementListSpec(DateTime? dateInit, DateTime? dateEnd, Guid? accountId, TypeMovement? typeMovement)
        {
            Query
           .Where(c =>
            dateInit == null || dateEnd == null ||
            (Convert.ToDateTime(c.Date.ToString("d")) >= dateInit && Convert.ToDateTime(c.Date.ToString("d")) <= dateEnd)
        )
        // Filtrar por accountId si accountId no es nulo
        .Where(c => accountId == null || c.AccountId == accountId)
        // Filtrar por typeMovement si typeMovement no es nulo
        .Where(c => typeMovement == null || c.TypeMovement == typeMovement)
        // Incluir datos relacionados de CategoryMovement
        .Include(c => c.CategoryMovement);
        }
    }
}