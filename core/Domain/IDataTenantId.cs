using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Core.Domain
{
    public interface IDataTenantId
    {
        IReadOnlyCollection<INotification> DomainEvents { get; }
        IReadOnlyCollection<INotification> DomainEventsAwait { get; }

        void ClearDomainEvents();
        void ClearDomainEventsAwait();
    
    }
}
