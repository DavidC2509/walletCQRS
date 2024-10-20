

using Ardalis.Specification;
using Core.Cqrs.Domain;

namespace Core.Domain.Repository
{
    /// <summary>
    /// <para>
    /// A <see cref="IReadRepository{T}" /> can be used to query instances of <typeparamref name="T" />.
    /// An <see cref="ISpecification{T}"/> (or derived) is used to encapsulate the LINQ queries against the database.
    /// </para>
    /// </summary>
    /// <typeparam name="T">The type of entity being operated on by this repository.</typeparam>
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
    {

    }
}