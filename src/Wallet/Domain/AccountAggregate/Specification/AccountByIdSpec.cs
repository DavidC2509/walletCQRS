

using Ardalis.Specification;
using Template.Domain.AccountAggregate;

namespace Template.Domain.Specification

{
    public class AccountByIdSpec : Specification<Account>
    {
        public AccountByIdSpec(Guid id)
        {
            Query
            .Where(c => c.Id.Equals(id))
            .Include(c => c.CategoryAccount)
            .Include(z => z.Movements);
        }
    }
}