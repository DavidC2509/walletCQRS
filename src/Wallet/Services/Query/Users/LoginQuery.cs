using MediatR;
using System.ComponentModel.DataAnnotations;
using Template.Services.Models;

namespace Template.Services.Query.Users
{
    public class LoginQuery : IRequest<LoginModels>
    {
        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
    }
}
