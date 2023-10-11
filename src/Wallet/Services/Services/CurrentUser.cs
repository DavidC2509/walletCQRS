using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Interface;

namespace Template.Services.Services
{
    public class CurrentUser : ICurrentUser
    {
        private readonly HttpContext _httpContext;
        private string? _tenantId { get; set; }

        public CurrentUser(IHttpContextAccessor contextAccessor)
        {
            _httpContext = contextAccessor.HttpContext!;
        }

        public string GetGuidUser()
        {
            return GetCurrentClaims.GetGuidFromUser(_httpContext.User);
        }
        public string GetTenantUser()
        {
            return _tenantId ?? GetCurrentClaims.GetTenantFromUser(_httpContext.User);
        }

        public string GetNameUser()
        {
            return GetCurrentClaims.GetNameFromUser(_httpContext.User);
        }

        public void SetTenantUser(string tenantId)
        {
            _tenantId = tenantId;
        }
    }
}
