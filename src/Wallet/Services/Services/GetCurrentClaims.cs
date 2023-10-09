using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Template.Services.Services
{
    public static class GetCurrentClaims
    {
        public const string TenantClaimType = "TenantId";

        public static string GetTenantFromUser(ClaimsPrincipal user)
        {
            return user?.Claims.FirstOrDefault(x => x.Type == TenantClaimType)?.Value!;
        }
    }
}
