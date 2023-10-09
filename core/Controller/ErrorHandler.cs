using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Controller
{
    /// <summary>
    /// Handler para los errores de los controladores
    /// </summary>
    public class ErrorHandler
    {
        /// <summary>
        /// Procesa una excepción
        /// </summary>
        /// <param name="ex">Excepción elevada</param>
        /// <param name="context">Contexto http de la ejecución</param>
        public static void Process(Exception ex, HttpContext context)
        {
            var _logger = context.RequestServices.GetRequiredService<ILogger<ErrorHandler>>();
            _logger.LogError(ex, $"-Fecha y hora: {{{DateTime.Now:dd/MM/yyyy HH:mm:ss.FFFFFF}}}\n      -Petición: [{context.Request.Method}] {context.Request.Path}\n      -Query: {context.Request.QueryString}\n      -Authorization: {context.Request.Headers["Authorization"]}");
        }
    }
}
