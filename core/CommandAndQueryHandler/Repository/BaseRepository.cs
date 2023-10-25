using Ardalis.Specification;
using Core.Domain;
using Core.Domain.Domain;
using Core.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Ardalis.Specification.EntityFrameworkCore;
using Core.CommandAndQueryHandler.Database;
using Microsoft.AspNetCore.Identity;

namespace Core.CommandAndQueryHandler.Repository
{
    /// <summary>
    /// Clase base para los repositorios de comandos
    /// </summary>
    /// <typeparam name="TEntity">Entidad Root del agregado</typeparam>
    /// <typeparam name="TContext">Contexto de la base de datos</typeparam>
    public abstract class BaseRepository<TEntity, TContext,TUser> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
        where TUser : IdentityUser
        where TContext : DatabaseIdentity<TUser>
    {


        private readonly ISpecificationEvaluator specificationEvaluator;


        /// <summary>
        /// Contexto de la base de datos
        /// </summary>
        protected readonly TContext _context;

        /// <summary>
        /// Dataset de la entidad root del repositorio
        /// </summary>
        protected readonly DbSet<TEntity> _dataSet;

        /// <summary>
        /// DataSet de la entidad
        /// </summary>
        protected virtual DbSet<TEntity> DataSet { get => _dataSet; }

        public IUnitOfWork UnitOfWork => _context;


        public BaseRepository(TContext dbContext)
         : this(dbContext, SpecificationEvaluator.Default)
        {
        }


        /// <summary>
        /// Constructor de la clase base
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        protected BaseRepository(TContext context, ISpecificationEvaluator specificationEvaluator)
        {
            _context = context;
            _dataSet = _context.Set<TEntity>();
            this.specificationEvaluator = specificationEvaluator;
        }

        /// <summary>
        /// Añade una entidad a la unidad de trabajo.
        /// </summary>
        /// <param name="item">Item a añadir</param>
        /// <returns>Retorna la entidad añadida</returns>
        public TEntity Add(TEntity entity)
        {
                return DataSet
                    .Add(entity)
                    .Entity;
        }

        public virtual Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            DataSet.AddRange(entities);
            return Task.FromResult(entities);
        }

        public virtual Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            DataSet.UpdateRange(entities);

            return Task.FromResult(entities);
        }

        public virtual Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            DataSet.RemoveRange(entities);

            return Task.FromResult(entities);
        }

        /// <summary>
        /// Actualiza una entidad a la unidad de trabajo. 
        /// </summary>
        /// <param name="item">Item a actualizar</param>
        /// <returns>Retorna la entidad añadida</returns>
        public TEntity Update(TEntity entity)
        {
            var retVal = DataSet.Local.SingleOrDefault(i => i == entity);

            if (retVal == default)
            {
                retVal = DataSet
                        .Update(entity)
                        .Entity;
            }
            return retVal;
        }

        /// <summary>
        /// Elimina una entidad a la unidad de trabajo.
        /// </summary>
        /// <param name="item">Item a actualizar</param>
        /// <returns>Retorna la entidad añadida</returns>
        public void Delete(TEntity entity)
        {
            DataSet.Remove(entity);
        }

        public virtual async Task<TEntity?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
        {
            return await DataSet.FindAsync(new object[] { id }, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        [Obsolete]
        public virtual async Task<TEntity?> GetBySpecAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        [Obsolete]
        public virtual async Task<TResult?> GetBySpecAsync<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<TResult?> FirstOrDefaultAsync<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity?> SingleOrDefaultAsync(ISingleResultSpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(specification).SingleOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<TResult?> SingleOrDefaultAsync<TResult>(ISingleResultSpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(specification).SingleOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<List<TEntity>> ListAsync(CancellationToken cancellationToken = default)
        {
            return await DataSet.ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<List<TEntity>> ListAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            var queryResult = await ApplySpecification(specification).ToListAsync(cancellationToken);

            return specification.PostProcessingAction == null ? queryResult : specification.PostProcessingAction(queryResult).ToList();
        }

        /// <inheritdoc/>
        public virtual async Task<List<TResult>> ListAsync<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default)
        {
            var queryResult = await ApplySpecification(specification).ToListAsync(cancellationToken);

            return specification.PostProcessingAction == null ? queryResult : specification.PostProcessingAction(queryResult).ToList();
        }

        /// <inheritdoc/>
        public virtual async Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(specification, true).CountAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await DataSet.CountAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<bool> AnyAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(specification, true).AnyAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<bool> AnyAsync(CancellationToken cancellationToken = default)
        {
            return await DataSet.AnyAsync(cancellationToken);
        }

        /// <summary>
        /// Filters the entities  of <typeparamref name="T"/>, to those that match the encapsulated query logic of the
        /// <paramref name="specification"/>.
        /// </summary>
        /// <param name="specification">The encapsulated query logic.</param>
        /// <returns>The filtered entities as an <see cref="IQueryable{T}"/>.</returns>
        protected virtual IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification, bool evaluateCriteriaOnly = false)
        {
            return specificationEvaluator.GetQuery(DataSet.AsQueryable(), specification, evaluateCriteriaOnly);
        }

        /// <summary>
        /// Filters all entities of <typeparamref name="T" />, that matches the encapsulated query logic of the
        /// <paramref name="specification"/>, from the database.
        /// <para>
        /// Projects each entity into a new form, being <typeparamref name="TResult" />.
        /// </para>
        /// </summary>
        /// <typeparam name="TResult">The type of the value returned by the projection.</typeparam>
        /// <param name="specification">The encapsulated query logic.</param>
        /// <returns>The filtered projected entities as an <see cref="IQueryable{T}"/>.</returns>
        protected virtual IQueryable<TResult> ApplySpecification<TResult>(ISpecification<TEntity, TResult> specification)
        {
            return specificationEvaluator.GetQuery(DataSet.AsQueryable(), specification);
        }

        public IAsyncEnumerable<TEntity> AsAsyncEnumerable(ISpecification<TEntity> specification)
        {
            throw new NotImplementedException();
        }


    }
}
