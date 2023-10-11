using Ardalis.EFCore.Extensions;
using AuthPermissions.BaseCode.CommonCode;
using AuthPermissions.BaseCode.DataLayer.EfCode;
using Core.CommandAndQueryHandler.Database;
using Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;
using System.Reflection;
using Template.Command.Interceptor;
using Template.Domain.AccountAggregate;
using Template.Domain.ClassifiersAggregate;
using Template.Domain.Events;
using Template.Domain.Interface;
using Template.Domain.MovementAggregate;
using Template.Domain.UserAggregate;

namespace Template.Command.Database
{
    public class DataBaseContext : DatabaseIdentity<User>, IUnitOfWork
    {

        private readonly ICurrentUser _currentUser;
        public DataBaseContext(IMediator mediator, ICurrentUser currentUser) : base(mediator)
        {
            _currentUser = currentUser;
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options, IMediator mediator, ICurrentUser currentUser)
            : base(options, mediator)
        {
            _currentUser = currentUser;

        }

        public override string Owner => "wallet";
        public override string TablePrefix => "wallet";


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            Expression<Func<IDataKeyFilterReadWrite, bool>> tenantFilter = entity => entity.DataKey == _currentUser.GetTenantUser();
            modelBuilder.AddQueryFilters(tenantFilter);
            base.OnModelCreating(modelBuilder);

        }

        public new async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await this.SaveChangesAsync(cancellationToken);

            return true;
        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<IDataKeyFilterReadWrite> entry in
                   ChangeTracker
                       .Entries<IDataKeyFilterReadWrite>())
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity.DataKey.IsNullOrEmpty())
                        entry.Entity.DataKey = _currentUser.GetTenantUser();
                }
            }

            await EventDispacher();
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            // dispatch events only if save was successful

            return result;
        }


        public async Task EventDispacher()
        {
            var entitiesWithEvents = ChangeTracker.Entries<IDataTenantId>()
              .Select(e => e.Entity)
              .Where(e => e.DomainEvents.Any())
                .ToArray();
            _mediator.DispatchAndClearEvents(entitiesWithEvents);

            var entitiesWithEventsAwait = ChangeTracker.Entries<IDataTenantId>()
            .Select(e => e.Entity)
             .Where(e => e.DomainEventsAwait.Any())
               .ToArray();

            await _mediator.DispatchAndClearEventsAwait(entitiesWithEventsAwait);
        }


        public DbSet<CategoryAccount> CategoryAccounts => Set<CategoryAccount>();
        public DbSet<CategoryMovement> CategoryMovements => Set<CategoryMovement>();
        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<MovementTransfer> MovementTransferts => Set<MovementTransfer>();

    }
}
