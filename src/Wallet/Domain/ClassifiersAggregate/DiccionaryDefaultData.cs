namespace Template.Domain.ClassifiersAggregate
{
    public class DiccionaryDefaultData
    {
        public IList<CategoryGlobal> typeCategory { get; set; } = new List<CategoryGlobal>();
        public IList<CategoryMovementGlobal> CategoryMovement { get; set; } = new List<CategoryMovementGlobal>();

        public DiccionaryDefaultData()
        {
            AddCategoryDefault();
            AddMovementDefault();
        }

        public void AddCategoryDefault()
        {
            typeCategory.Add(new CategoryGlobal("Dinero en efectivo"));
            typeCategory.Add(new CategoryGlobal("Debajo Colchon"));
            typeCategory.Add(new CategoryGlobal("Alcancia"));
        }

        public void AddMovementDefault()
        {
            CategoryMovement.Add(new CategoryMovementGlobal("Transferencia"));
            CategoryMovement.Add(new CategoryMovementGlobal("Alimentación"));
            CategoryMovement.Add(new CategoryMovementGlobal("Transporte"));
            CategoryMovement.Add(new CategoryMovementGlobal("Mantenimiento"));

        }
    }
}
