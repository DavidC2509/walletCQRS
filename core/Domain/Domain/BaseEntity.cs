namespace Core.Domain.Domain
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Determinate is ententy is asigned
        /// </summary>
        /// <returns>true or false is asignade</returns>
        public bool IsTransient()
        {
            return Id == default;
        }
    }
}
