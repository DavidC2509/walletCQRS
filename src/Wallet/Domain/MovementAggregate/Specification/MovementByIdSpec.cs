

using Ardalis.Specification;

namespace Template.Domain.MovementAggregate.Specification

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