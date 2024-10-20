

using Ardalis.Specification;

namespace Template.Domain.AccountAggregate.Specification

{
    public class AccountByIdSpec : Specification<Account>
    {
        public AccountByIdSpec(Guid id)
        {
            Query
            .Where(c => c.Id.Equals(id))
            .Include(c => c.CategoryAccount);
        }
    }
}