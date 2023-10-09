using MediatR;

namespace Core.Domain.Events
{
    /// <summary>
    /// Clase base para los eventos de dominio PreSave y PostSave 
    /// </summary>
    /// <typeparam name="T">Cualquier clase que represente un evento e implemente INotification</typeparam>
    public abstract class BaseSaveEventDomain<T> : INotification where T : INotification
    {
        /// <summary>
        /// Constructor base
        /// </summary>
        /// <param name="Event">Data del evento asociado</param>
        public BaseSaveEventDomain(T Event)
        {
            EventData = Event;
        }

        /// <summary>
        /// Datos particulares del evento
        /// </summary>
        public T EventData { get; set; }
    }

}
