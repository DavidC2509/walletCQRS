using Core.Cqrs.CommandAndQueryHandler;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Template.Domain.UserAggregate;
using Template.Services.Models;

namespace Template.Services.Query.Users
{
    public class LoginQueryHandler : BaseSimpleHandler<LoginQuery, LoginModels>
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User? _user;

        public LoginQueryHandler(UserManager<User> userManager, IConfiguration configuration) : base()
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public override async Task<LoginModels> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            LoginModels login = new();
            _user = await _userManager.FindByNameAsync(request.UserName!);
            var result = _user != null && await _userManager.CheckPasswordAsync(_user, request.Password!);
            if (result)
            {
                login.Token = CreateTokenAsync();
            }
            login.Result = result;
            return login;

        }

        public string CreateTokenAsync()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtConfig = _configuration.GetSection("jwtConfig");
            var key = Encoding.UTF8.GetBytes(jwtConfig["Secret"]!);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private List<Claim> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim("Name", _user.UserName!),
                new Claim("TenantId", _user.TenantId),
                new Claim("Guid", _user.Id)

        };


            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtConfig");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expiresIn"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
    }
}