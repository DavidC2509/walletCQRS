using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MediatR;
using Template.Domain.Interface;
using Template.Command.Database;
using Template.Domain.AccountAggregate;
using Template.Command;
using Core.Domain.Domain;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using Template.Services.Services;

namespace IntegrationTests.Data;
public abstract class BaseEfRepoTestFixture
{
  protected DataBaseContext _dbContext;

  protected BaseEfRepoTestFixture()
  {
    var options = CreateNewContextOptions();
    var mockMediator = new Mock<IMediator>();
    var httpContext = new Mock<IHttpContextAccessor>();
    var mockCurrentUser = new CurrentUser(httpContext.Object);
    mockCurrentUser.SetTenantUser("TestTenant");
    _dbContext = new DataBaseContext(options, mockMediator.Object,mockCurrentUser);
  }

  protected static DbContextOptions<DataBaseContext> CreateNewContextOptions()
  {
    // Create a fresh service provider, and therefore a fresh
    // InMemory database instance.
    var serviceProvider = new ServiceCollection()
        .AddEntityFrameworkInMemoryDatabase()
        .BuildServiceProvider();

    // Create a new options instance telling the context to use an
    // InMemory database and the new service provider.
    var builder = new DbContextOptionsBuilder<DataBaseContext>();
    builder.UseInMemoryDatabase("cleanarchitecture")
           .UseInternalServiceProvider(serviceProvider);

    return builder.Options;
  }

  protected EfRepository<Account> GetAccount()
  {
    return new EfRepository<Account>(_dbContext);
  }

    public EfRepository<T> GetRepositoryGeneric<T>() where T : BaseEntity, IAggregateRoot
    {
        return new EfRepository<T>(_dbContext);
    }
}
