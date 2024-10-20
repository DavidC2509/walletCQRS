using AutoMapper;
using Core.Cqrs.Domain.Repository;
using MediatR;
using Template.Domain.ClassifiersAggregate;
using Template.Domain.Interface;
using Template.Domain.UserAggregate.Events;

namespace Template.Services.HandlerEvents
{
    public class AddCategoryDefaultEventHandler : INotificationHandler<AddCategoryDefaultEvent>
    {
        private IRepository<CategoryAccount> _category;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;

        public AddCategoryDefaultEventHandler(IRepository<CategoryAccount> category, IMapper mapper, ICurrentUser currentUser)
        {
            _category = category;

            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task Handle(AddCategoryDefaultEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Entro a guardar Categoria");
            _currentUser.SetTenantUser(notification.TenantId);
            Console.WriteLine("El tenantId es " + notification.TenantId);

            var _data = new DiccionaryDefaultData();
            List<CategoryAccount> category = _mapper.Map<List<CategoryAccount>>(_data.typeCategory);
            category[0].StoreAccountUser();
            Console.WriteLine("Agrego una cuenta");

            await _category.AddRangeAsync(category, cancellationToken);
            await _category.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            Console.WriteLine("Guardar");

        }
    }
}
