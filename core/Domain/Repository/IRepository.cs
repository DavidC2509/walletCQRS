using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    /// <summary>
    /// Interfaz base para las interfaces de repositorios de agregados. Trabaja sobre el root del agregado
    /// </summary>
    /// <typeparam name="TEntity">Entidad Root del agregado</typeparam>
    public interface IRepository<TEntity> : IReadRepository<TEntity> where TEntity : class, IAggregateRoot 
    {
        /// <summary>
        /// Objeto que implementa el patron de unidad de trabajo
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Añade una entidad a la unidad de trajajo
        /// </summary>
        /// <param name="entity">Entidad a añadir</param>
        /// <returns>Retorna una referencia a la entidad ya añadida</returns>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Actualiza una entidad a la unidad de trajajo
        /// </summary>
        /// <param name="entity">Entidad a añadir</param>
        /// <returns>Retorna una referencia a la entidad ya añadida</returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Adds the given entities in the database
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the <typeparamref name="IEnumerable<T>" />.
        /// </returns>
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);


        /// <summary>
        /// Updates the given entities in the database
        /// </summary>
        /// <param name="entities">The entities to update.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);


        /// <summary>
        /// Removes the given entities in the database
        /// </summary>
        /// <param name="entities">The entities to remove.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Elimina una entidad a la unidad de trajajo
        /// </summary>
        /// <param name="entity">Entidad a añadir</param>
        /// <returns>Retorna una referencia a la entidad ya añadida</returns>
        void Delete(TEntity entity);
    }
}
