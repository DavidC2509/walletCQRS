using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Interface
{
    public interface ICurrentUser
    {
        string GetTenantUser();
        void SetTenantUser(string tenantId);

    }
}
