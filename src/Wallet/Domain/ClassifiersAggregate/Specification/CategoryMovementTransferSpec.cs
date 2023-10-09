using Ardalis.Specification;

namespace Template.Domain.ClassifiersAggregate.Specification

{
    public class CategoryMovementTransferSpec : Specification<CategoryMovement>
    {
        public CategoryMovementTransferSpec()
        {
            Query.Where(spec => spec.Name == "Transferencia");
        }
    }
}