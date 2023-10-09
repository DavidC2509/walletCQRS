

using Ardalis.Specification;
using Template.Domain.AccountAggregate;

namespace Template.Domain.Specification

{
    public class AccountSpec : Specification<Account>
    {
        public AccountSpec()
        {
            Query.Include(c => c.CategoryAccount).Include(z => z.Movements);
        }
    }
}