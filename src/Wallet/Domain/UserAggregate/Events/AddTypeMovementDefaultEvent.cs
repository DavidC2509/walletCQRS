

using MediatR;

namespace Template.Domain.UserAggregate.Events
{
    public class AddCategoryMovementDefaultEvent : INotification
    {
        public string TenantId { get; set; }

        public AddCategoryMovementDefaultEvent(string tenantId)
        {
            TenantId = tenantId;
        }
    }
}
