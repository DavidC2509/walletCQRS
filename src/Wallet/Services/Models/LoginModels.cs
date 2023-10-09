using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Services.Models
{
    public class LoginModels
    {
        public string Token {  get; set; }
        public bool Result { get; set; } = false;

        public LoginModels(string token)
        {
            Token = token;
        }

        public LoginModels()
        {
            Token = string.Empty;
        }
    }
}
