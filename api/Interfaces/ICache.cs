namespace Interfaces
{
    public interface ICache
    {
       bool TryGetValue<TItem>(object key, out TItem value);
       TItem Set<TItem>(object key, TItem value);
       void Remove(object key);
    }
}
