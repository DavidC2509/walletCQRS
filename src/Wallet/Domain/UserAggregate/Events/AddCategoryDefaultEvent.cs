

using MediatR;

namespace Template.Domain.UserAggregate.Events
{
    public class AddCategoryDefaultEvent : INotification
    {
        public string TenantId { get; set; }

        public AddCategoryDefaultEvent(string tenantId)
        {
            TenantId = tenantId;
        }
    }
}
