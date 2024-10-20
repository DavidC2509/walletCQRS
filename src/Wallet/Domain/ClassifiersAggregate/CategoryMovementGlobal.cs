using Core.Cqrs.Domain.Domain;


namespace Template.Domain.ClassifiersAggregate
{
    public class CategoryMovementGlobal : BaseEntity
    {
        public string Name { get; set; }

        public CategoryMovementGlobal(string name)
        {
            Name = name;
        }
    }
}
