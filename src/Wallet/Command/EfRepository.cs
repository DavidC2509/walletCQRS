using Core.Domain.Repository;
using Core.Domain;
using Core.CommandAndQueryHandler.Repository;
using Core.Domain.Domain;
using Template.Command.Database;
using Template.Domain.UserAggregate;

namespace Template.Command
{
    public class EfRepository<T> : BaseRepository<T, DataBaseContext,User>, IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        public EfRepository(DataBaseContext context) : base(context) { }
    }
}
