using MediatR;

namespace Core.Domain.Events
{

    /// <summary>
    /// Clase que representa un evento de dominio lanzado antes de salvar los cambios a la capa persistente
    /// </summary>
    /// <typeparam name="T">Cualquier clase que represente un evento de dominio e implemente INotification</typeparam>
    public class PreSaveEventDomain<T> : BaseSaveEventDomain<T> where T : INotification
    {
        /// <summary>
        /// Genera una neuva instancia de la clase
        /// </summary>
        /// <param name="Event">Data del evento asociado</param>
        public PreSaveEventDomain(T _data) : base(_data)
        {
        }
    }

}
