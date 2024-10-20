using Core.Cqrs.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Template.Command.Database
{
    public abstract class DatabaseIdentity<TUser> : IdentityDbContext<TUser>, IUnitOfWork where TUser : IdentityUser
    {
        /// <summary>
        /// Objeto mediadador para manejar eventos.
        /// </summary>
        protected readonly IMediator _mediator;
        /// <summary>
        /// Owner de la base de datos. Debe sobreescribirse en la clase base para devolver el owner deseado
        /// </summary>
        public abstract string Owner { get; }
        /// <summary>
        /// Prefijo a aplicar a todas las tablas. Debe sobreescribirse en la clase base para devolver el owner deseado
        /// </summary>
        public abstract string TablePrefix { get; }


        /// <summary>
        /// Constructor para injección de dependencias
        /// </summary>
        /// <param name="session">Objeto con la info de sesión del usuario logueado</param>
        /// <param name="mediator">Objeto mediadador para manejar eventos.</param>
        public DatabaseIdentity(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Constructor para injección de dependencias
        /// </summary>
        /// <param name="options">Opciones de contexto</param>
        /// <param name="session">Objeto con la info de sesión del usuario logueado</param>
        /// <param name="mediator">Objeto mediadador para manejar eventos.</param>
        public DatabaseIdentity(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }


        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

}
