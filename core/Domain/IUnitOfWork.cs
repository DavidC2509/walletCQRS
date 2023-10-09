namespace Core.Domain
{
    /// <summary>
    /// Interfaz de abstracción para el patrón de unidad de trabajo
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Guarda los datos de todas las entidades traqueadas por la unidad de trabajo
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns>Retorna Verdadero en caso de haber completado con éxito la operación</returns>
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
