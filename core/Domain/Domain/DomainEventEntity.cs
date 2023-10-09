using Core.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Domain.Domain
{
    /// <summary>
    /// Clase base para entidades con envio de eventos
    /// </summary>
    public abstract class DomainEventEntity : BaseEntity
    {
        /// <summary>
        /// HashCode de la entidad
        /// </summary>
        int? _requestedHashCode;


        /// <summary>
        /// Fecha de cómputo de del registro
        /// </summary>
        [JsonIgnore]
        [Column("dCompDate")]
        public DateTime Computed { get; set; }

        /// <summary>
        /// Listado de eventos de dominio pre-guardado
        /// </summary>        
        private List<INotification> _domainEventsPre = new();
        /// <summary>
        /// Listado de eventos de dominio pre-guardado
        /// </summary>
        [JsonIgnore]
        public IReadOnlyCollection<INotification> DomainEventsPre => _domainEventsPre.AsReadOnly();

        /// <summary>
        /// Listado de eventos de dominio post-guardado
        /// </summary>        
        private List<INotification> _domainEventsPost = new();

        /// <summary>
        /// Listado de eventos de dominio post-guardado
        /// </summary>
        [JsonIgnore]
        public IReadOnlyCollection<INotification> DomainEventsPost => _domainEventsPost.AsReadOnly();

        /// <summary>
        /// Se encarga de añadir un evento de dominio que será propagado tanto antes como despues del guardado
        /// </summary>
        /// <typeparam name="T">Cualquier clase que represente un evento e implemente INotification</typeparam>
        /// <param name="Event">Evento a añadir</param>
        protected void AddDomainEvent<T>(T Event) where T : INotification
        {
            PreSaveEventDomain<T> preEvent;
            PostSaveEventDomain<T> postEvent;

            preEvent = new PreSaveEventDomain<T>(Event);
            postEvent = new PostSaveEventDomain<T>(Event);

            _domainEventsPost = _domainEventsPost ?? new List<INotification>();
            _domainEventsPre = _domainEventsPre ?? new List<INotification>();


            _domainEventsPost.Add(postEvent);
            _domainEventsPre.Add(preEvent);
        }

        /// <summary>
        /// Limpia los eventos de dominio
        /// </summary>
        /// <param name="type">Determina cuales eventos se van a limpiar</param>
        public void ClearDomainEvents(DomainEventType type)
        {

            if (type == DomainEventType.PreSave)
            {
                _domainEventsPre?.Clear();
            }
            else if (type == DomainEventType.PostSave)
            {
                _domainEventsPost?.Clear();
            }
            else
            {
                _domainEventsPre?.Clear();
                _domainEventsPost?.Clear();

            }

        }

  

        /// <summary>
        /// Obtiene el Código hash
        /// </summary>
        /// <returns>Código hash del objeto</returns>
        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();

        }


   
        /// <summary>
        /// Determina los tipos de eventos sobre los que se aplicará una operación
        /// </summary>
        public enum DomainEventType
        {
            /// <summary>
            /// Se refiere a todos los eventos, tanto de pre-guardado como de postguardado
            /// </summary>
            All,
            /// <summary>
            /// Se refiere a los eventos de pre-guardado
            /// </summary>
            PreSave,
            /// <summary>
            /// Se refiere a los eventos de post-guardado
            /// </summary>
            PostSave
        }

    }
}