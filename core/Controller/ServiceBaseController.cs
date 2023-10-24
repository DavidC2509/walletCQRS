using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Core.Domain.Exceptions;

namespace Core.Controller
{
    /// <summary>
    /// Clase base para los controladores del API
    /// </summary>
    public class ServiceBaseController : ControllerBase
    {
        /// <summary>
        /// Interfaz para el patrón mapeador
        /// </summary>
        public readonly IMapper _mapper;
        /// <summary>
        /// Interfaz para el patrón mediador
        /// </summary>
        public readonly IMediator _mediator;

        /// <summary>
        /// Constructor con inyección de dependencias
        /// </summary>
        /// <param name="mapper">Interfaz para el patrón mapeador</param>
        /// <param name="mediator">Interfaz para el patrón mediador</param>
        public ServiceBaseController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Constructor con inyección de dependencias
        /// </summary>        
        /// <param name="mediator">Interfaz para el patrón mediador</param>
        public ServiceBaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Ejecuta una acción que retorna un resultado en un contexto controlado
        /// </summary>
        /// <typeparam name="T">Tipo del valor devuelto</typeparam>
        /// <param name="method">Método a ejecutar para retornar el valor</param>
        /// <returns>ActionResult del valor devuelto</returns>
        public async Task<ActionResult<T>> ExecuteTransaction<T>(Func<Task<T>> method)
        {
            try
            {
                var result = await method();
                return typeof(Unit).Equals(GetType(result)) ? new EmptyResult() : result;
            }
            catch (SystemException ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Obtiene el tipo de datos de un objeto cualquiera de forma nullsafe.
        /// </summary>
        /// <typeparam name="T">Tipo de datos del objeto, inferido por parámetro</typeparam>
        /// <param name="object">objeto del que se desea obtener su tipo de datos</param>
        /// <returns>El objeto Type que representa el tipo de datos del parámetro</returns>
        private Type GetType<T>(T @object)
        {
            return typeof(T);
        }

        /// <summary>
        /// Ejecuta una acción que retorna un resultado en un contexto controlado
        /// </summary>
        /// <param name="method">Método a ejecutar para retornar el valor</param>
        /// <returns></returns>
        [NonAction]
        public async Task<ActionResult> ExecuteTransactionWithEmptyResult(Func<Task<Unit>> method)
        {
            try
            {
                await method();
                return new EmptyResult();
            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }

        }


        /// <summary>
        /// Ejecuta una acción que retorna un resultado en un contexto controlado, utilizando el patrón mediador de implementado en MediatR
        /// </summary>
        /// <typeparam name="TResponse">Tipo del valor devuelto</typeparam>
        /// <param name="request">Request a ser utilizado por el mediador</param>
        /// <returns>ActionResult del valor devuelto</returns>
        public Task<ActionResult<TResponse>> SendRequest<TResponse>(IRequest<TResponse> request)
        {
            return ExecuteTransaction(() => _mediator.Send(request));
        }

        /// <summary>
        /// Ejecuta una acción que no retorna resultado en un contexto controlado, utilizando el patrón mediador de implementado en MediatR
        /// </summary>
        /// <param name="request">Request a ser utilizado por el mediador</param>
        /// <returns>EmptyResult</returns>
        [NonAction]
        public Task<ActionResult> SendRequestNoResponse(IRequest request)
        {
            return ExecuteTransactionWithEmptyResult(() => (Task<Unit>)_mediator.Send(request));
        }

    }
}