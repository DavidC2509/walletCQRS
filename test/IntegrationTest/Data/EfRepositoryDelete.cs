// using TrackFinance.Core.TransactionAgregate;
// using TrackFinance.Core.TransactionAgregate.Enum;
// using Xunit;

// namespace TrackFinance.IntegrationTests.Data;
// public class EfRepositoryDelete : BaseEfRepoTestFixture
// {
//   [Fact]
//   public async Task DeletesItemAfterAddingIt()
//   {
//     // add a project
//     var repository = GetRepository();
//     var initialName = Guid.NewGuid().ToString();
//     var transaction = Transaction.CreateExpenses(initialName, 2000, TransactionDescriptionType.Education, DateTime.Now, 1);
//     await repository.AddAsync(transaction);

//     // delete the item
//     await repository.DeleteAsync(transaction);

//     // verify it's no longer there
//     Assert.DoesNotContain(await repository.ListAsync(),
//         project => project.Description == initialName);
//   }
// }
