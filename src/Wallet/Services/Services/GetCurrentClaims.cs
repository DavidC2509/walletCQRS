﻿using System.Security.Claims;

namespace Template.Services.Services
{
    public static class GetCurrentClaims
    {
        public const string TenantClaimType = "TenantId";
        public const string GuidClaimType = "Guid";
        public const string NameClaimType = "Name";

        public static string GetTenantFromUser(ClaimsPrincipal user)
        {
            return user?.Claims.FirstOrDefault(x => x.Type == TenantClaimType)?.Value!;
        }

        public static string GetGuidFromUser(ClaimsPrincipal user)
        {
            return user?.Claims.FirstOrDefault(x => x.Type == GuidClaimType)?.Value!;
        }

        public static string GetNameFromUser(ClaimsPrincipal user)
        {
            return user?.Claims.FirstOrDefault(x => x.Type == NameClaimType)?.Value!;
        }
    }
}
