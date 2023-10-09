using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Domain
{
    public interface IBaseEntity
    {
       bool IsTransient();
    }
}
