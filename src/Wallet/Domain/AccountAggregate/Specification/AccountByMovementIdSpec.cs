

using Ardalis.Specification;
using Template.Domain.AccountAggregate;

namespace Template.Domain.Specification

{
    public class AccountByMovementIdSpec : Specification<Account>
    {
        public AccountByMovementIdSpec(Guid id)
        {
            Query
            .Include(c => c.CategoryAccount);
        }
    }
}