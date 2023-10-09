using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.CommandAndQueryHandler
{
    /// <summary>
    /// Clase base para handlers de comandos
    /// </summary>
    /// <typeparam name="TRepository">Repositorio a utilizar</typeparam>
    /// <typeparam name="TRequest">Clase comando</typeparam>
    /// <typeparam name="TResponse">Clase respuesta</typeparam>
    public abstract class BaseCommandHandler<TRepository, TRequest, TResponse> :
        IRequestHandler<TRequest, TResponse>
        where TRepository : class
        where TRequest : IRequest<TResponse>
        

    {
        /// <summary>
        /// Referencia al repositorio
        /// </summary>
        protected readonly TRepository _repository;

        /// <summary>
        /// Constructor con inyección de dependencias
        /// </summary>
        /// <param name="repository">Referencia al repositorio</param>
        public BaseCommandHandler(TRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Se encarga de hestionar el comando
        /// </summary>
        /// <param name="request">Solicitud del comando</param>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns></returns>
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}