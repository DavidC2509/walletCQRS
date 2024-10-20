namespace Template.Services.Models
{
    public class LoginModels
    {
        public string Token { get; set; }
        public bool Result { get; set; } = false;

        public LoginModels()
        {
            Token = string.Empty;
        }
    }
}
