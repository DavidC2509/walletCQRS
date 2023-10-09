namespace Core.Domain
{
    public interface IAggregateChild<TRoot> where TRoot : IAggregateRoot
    {
    }
}