using Ardalis.Specification;
using Core.Domain.Repository;
using MediatR;

namespace Core.CommandAndQueryHandler
{
    /// <summary>
    /// Clase base para handlers de consultas
    /// </summary>
    /// <typeparam name="TRepository">Repositorio a utilizar</typeparam>
    /// <typeparam name="TRequst">Clase comando</typeparam>
    /// <typeparam name="TResponse">Clase respuesta</typeparam>
    public abstract class BaseSimpleHandler< TRequst, TResponse> :
        IRequestHandler<TRequst, TResponse>
        where TRequst : IRequest<TResponse>
        where TResponse : class
    {
      

        /// <summary>
        /// Constructor con inyección de dependencias
        /// </summary>
        /// <param name="repository">Referencia al repositorio</param>
        public BaseSimpleHandler()
        {
        }

        /// <summary>
        /// Se encarga de hestionar el comando
        /// </summary>
        /// <param name="request">Solicitud del comando</param>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns></returns>
        public abstract Task<TResponse> Handle(TRequst request, CancellationToken cancellationToken);

    }
}
