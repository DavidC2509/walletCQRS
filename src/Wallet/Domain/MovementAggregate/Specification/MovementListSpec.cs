

using Ardalis.Specification;

namespace Template.Domain.MovementAggregate.Specification

{
    public class MovementListSpec : Specification<Movement>
    {
        public MovementListSpec(DateTime? dateInit, DateTime? dateEnd, Guid? accountId, TypeMovement? typeMovement)
        {
            Query
           .Where(c =>
            dateInit == null || dateEnd == null ||
           c.Date >= dateInit && c.Date <= dateEnd
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