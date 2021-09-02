using Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Domain.Storage
{
    public class MemoryCache: ICache
    {
        private readonly IMemoryCache _cache;

        public MemoryCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public bool TryGetValue<TItem>(object key, out TItem value)
        {
            return _cache.TryGetValue(key,out value);
        }

        public TItem Set<TItem>(object key, TItem value)
        {
           return _cache.Set(key, value);
        }

        public void Remove(object key)
        {
            _cache.Remove(key);
        }
    }
}
