

using Template.Domain.AccountAggregate;
using Template.Domain.ClassifiersAggregate;
using Xunit;

namespace IntegrationTests.Data; 
public class EfCategoryAdd : BaseEfRepoTestFixture
{
    [Fact]
    public async Task CreateAccount()
    {
        var repositoryCategory = GetRepositoryGeneric<CategoryAccount>();
        var categoryAccount = new CategoryAccount("Categoria Test");

        var repositoryAccount = GetAccount();

        var account = Account.CreateAccount("Test Account", categoryAccount,100);

        repositoryCategory.Add(categoryAccount);

        await repositoryCategory.UnitOfWork.SaveEntitiesAsync();

        repositoryAccount.Add(account);

        await repositoryAccount.UnitOfWork.SaveEntitiesAsync();

        var newAccount = (await repositoryAccount.ListAsync())
                        .FirstOrDefault();

        Assert.Equal("Test Account", newAccount?.Name);
        Assert.True(newAccount != null);
    }
}
