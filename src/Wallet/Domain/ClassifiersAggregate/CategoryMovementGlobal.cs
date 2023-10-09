using Core.Domain.Domain;
using Core.Domain;


namespace Template.Domain.ClassifiersAggregate
{
    public class CategoryMovementGlobal : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }

        public CategoryMovementGlobal(string name)
        {
            Name = name;
        }
    }
}
