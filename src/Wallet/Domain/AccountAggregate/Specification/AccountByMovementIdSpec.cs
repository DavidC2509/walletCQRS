

using Ardalis.Specification;

namespace Template.Domain.AccountAggregate.Specification

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