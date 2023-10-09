
namespace Template.Services.Models
{
    public class AccountModel
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public CategoryAccountModel CategoryAccount { get; set; }
        public string DataKey { get; set; }

        public AccountModel()
        {
            Name = string.Empty;
            DataKey = string.Empty;
            CategoryAccount = new CategoryAccountModel();
        }
    }

    public class CategoryAccountModel
    {
        public string Name { get; set; }

        public CategoryAccountModel()
        {
            Name = string.Empty;
        }
    }

}