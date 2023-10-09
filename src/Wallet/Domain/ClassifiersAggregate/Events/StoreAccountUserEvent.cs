
using MediatR;
namespace Template.Domain.ClassifiersAggregate.Events
{
    public class StoreAccountUserEvent : INotification
    {
        public CategoryAccount CategoryAccount { get; set; }

        public StoreAccountUserEvent(CategoryAccount categoryAccount)
        {
            CategoryAccount = categoryAccount;
        }
    }
}