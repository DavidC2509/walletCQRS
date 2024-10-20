

using Ardalis.Specification;

namespace Template.Domain.AccountAggregate.Specification

{
    public class AccountSpec : Specification<Account>
    {
        public AccountSpec()
        {
            Query.Include(c => c.CategoryAccount);
        }
    }
}