
namespace Template.Services.Models
{
    public class AccountModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public ClassifierModel CategoryAccount { get; set; }
        public string DataKey { get; set; }

        public AccountModel()
        {
            Name = string.Empty;
            DataKey = string.Empty;
            CategoryAccount = new ClassifierModel();
        }
    }

}