using Core.Cqrs.Domain;
using Core.Cqrs.Domain.Domain;
using Core.Cqrs.Domain.Repository;
using Template.Command.Database;
using Template.Command.Repository;
using Template.Domain.UserAggregate;

namespace Template.Command
{
    public class EfRepository<T> : BaseRepository<T, DataBaseContext, User>, IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        public EfRepository(DataBaseContext context) : base(context) { }
    }
}
