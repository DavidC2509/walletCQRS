

using Ardalis.Specification;
using Template.Domain.AccountAggregate;
using Template.Domain.MovementAggregate;

namespace Template.Domain.Specification

{
    public class MovementByIdSpec : Specification<Movement>
    {
        public MovementByIdSpec(Guid id)
        {
            Query
            .Where(c => c.Id.Equals(id))
            .Include(c => c.CategoryMovement);
        }
    }
}