using Core.Cqrs.Domain.Domain;

namespace Template.Domain.ClassifiersAggregate
{
    public class CategoryGlobal : BaseEntity
    {
        public string Name { get; set; }

        public CategoryGlobal(string name)
        {
            Name = name;
        }
    }
}
