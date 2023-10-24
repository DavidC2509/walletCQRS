// using Microsoft.EntityFrameworkCore;
// using TrackFinance.Core.TransactionAgregate;
// using TrackFinance.Core.TransactionAgregate.Enum;
// using Xunit;

// namespace TrackFinance.IntegrationTests.Data;
// public class EfRepositoryUpdate : BaseEfRepoTestFixture
// {
//   [Fact]
//   public async Task UpdatesItemAfterAddingIt()
//   {
//     // add a project
//     var repository = GetRepository();
//     var initialName = Guid.NewGuid().ToString();
//     var transaction = Transaction.CreateExpenses(initialName, 2000, TransactionDescriptionType.Education, DateTime.Now, 1);

//     await repository.AddAsync(transaction);

//     // detach the item so we get a different instance
//     _dbContext.Entry(transaction).State = EntityState.Detached;

//     // fetch the item and update its title
//     var newTransaction = (await repository.ListAsync())
//         .FirstOrDefault(project => project.Description == initialName);
//     if (newTransaction == null)
//     {
//       Assert.NotNull(newTransaction);
//       return;
//     }
//     Assert.NotSame(transaction, newTransaction);
//     var newName = Guid.NewGuid().ToString();
//     newTransaction.UpdateDescription(newName);

//     // Update the item
//     await repository.UpdateAsync(newTransaction);

//     // Fetch the updated item
//     var updatedItem = (await repository.ListAsync())
//         .FirstOrDefault(project => project.Description == newName);

//     Assert.NotNull(updatedItem);
//     Assert.NotEqual(transaction.Description, updatedItem?.Description);
//     Assert.Equal(transaction.Amount, updatedItem?.Amount);
//     Assert.Equal(newTransaction.Id, updatedItem?.Id);
//   }
// }
