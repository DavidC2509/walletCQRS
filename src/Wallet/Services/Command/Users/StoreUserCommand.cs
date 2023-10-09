using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Template.Services.Command.Users
{
    public class StoreUserCommand : IRequest<IdentityResult>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public StoreUserCommand(string? firstName, string? lastName, string userName, string password, string? email, string? phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
