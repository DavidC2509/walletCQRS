using AutoMapper;
using Core.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.ClassifiersAggregate;
using Template.Domain.Interface;
using Template.Domain.UserAggregate.Events;
using Template.Services.Services;

namespace Template.Services.HandlerEvents
{
    public class AddCategoryMovementDefaultEventHandler : INotificationHandler<AddCategoryDefaultEvent>
    {
        private IRepository<CategoryMovement> _categoryMovement;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;

        public AddCategoryMovementDefaultEventHandler(IRepository<CategoryMovement> categoryMovement, IMapper mapper, ICurrentUser currentUser)
        {
            _categoryMovement = categoryMovement;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task Handle(AddCategoryDefaultEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Entro a guardar Categoria");
            _currentUser.SetTenantUser(notification.TenantId);
            Console.WriteLine("El tenantId es " + notification.TenantId);

            var _data = new DiccionaryDefaultData();
            List<CategoryMovement> movement = _mapper.Map<List<CategoryMovement>>(_data.CategoryMovement);
            Console.WriteLine("Agrego una cuenta");

            await _categoryMovement.AddRangeAsync(movement, cancellationToken);
            await _categoryMovement.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            Console.WriteLine("Guardar");

        }
    }
}
