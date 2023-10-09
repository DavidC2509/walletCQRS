using MediatR;

namespace Core.Domain.Events
{

    /// <summary>
    /// Clase que representa un evento de dominio lanzado despues de salvar los cambios a la capa persistente
    /// </summary>
    /// <typeparam name="T">Cualquier clase que represente un evento de dominio e implemente INotification</typeparam>
    public class PostSaveEventDomain<T> : BaseSaveEventDomain<T> where T : INotification
    {
        /// <summary>
        /// Genera una neuva instancia de la clase
        /// </summary>
        /// <param name="Event">Data del evento asociado</param>
        public PostSaveEventDomain(T _data) : base(_data)
        {
        }
    }

}
