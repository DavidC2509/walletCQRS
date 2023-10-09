namespace Core.Domain.Domain
{
    public abstract class BaseEntityNumber : IBaseEntity
    {
        public int Id { get; set; }

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
