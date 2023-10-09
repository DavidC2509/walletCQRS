using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Template.Domain.Interface;

namespace Template.Api.Middleware
{
    public class TokenProcessingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ICurrentUser _currentUser;

        public TokenProcessingMiddleware(RequestDelegate next, ICurrentUser currentUser)
        {
            _next = next;
            _currentUser = currentUser;
        }

        public async Task Invoke(HttpContext context)
        {
            // Verificar si existe un token en la cabecera de autorización
            string? token = context.Request.Headers["Authorization"].FirstOrDefault()?.Substring("Bearer ".Length);

            if (!string.IsNullOrEmpty(token))
            {

                // Procesar el token y obtener el TenantId
                var tenantId = ObtainTenantIdFromToken(token);

                // Establecer el TenantId en ITenantProvider
                _currentUser.SetTenantUser(tenantId!);
            }

            // Continuar con la cadena de middlewares
            await _next(context);
        }

        private static string? ObtainTenantIdFromToken(string token)
        {
            // Lógica para validar y decodificar el token, y obtener el TenantId
            // Puedes utilizar librerías como System.IdentityModel.Tokens.Jwt para decodificar tokens JWT

            // Ejemplo: Decodificar un token JWT
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            return jsonToken?.Claims.FirstOrDefault(c => c.Type == "TenantId")?.Value;
        }
    }

}