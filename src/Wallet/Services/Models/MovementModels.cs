
namespace Template.Services.Models
{
    public class MovementModel
    {
        public string Descripcion { get; set; }
        public double Amount { get; set; }
        public Guid AccountId { get; set; }
        public ClassifierModel CategoryMovement { get; set; }
        public TypeMovement TypeMovement { get; set; }
        public DateTime Date { get; set; }
        public MovementModel()
        {
            Descripcion = string.Empty;
            CategoryMovement = new();
            TypeMovement = new();
        }
    }
}