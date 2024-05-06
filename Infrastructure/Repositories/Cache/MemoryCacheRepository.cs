using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repositories.Cache;

public class MemoryCacheRepository(IMemoryCache memoryCache) : ICacheRepository
{
    private readonly IMemoryCache _memoryCache = memoryCache;

    public object? GetFromCache(string key)=> _memoryCache.Get(key);

    public void SetInCache(string key, object value, TimeSpan cacheTime)
    {
        _memoryCache.CreateEntry(key);
        _memoryCache.Set(key, value, cacheTime);
    }

    public void Remove(string key) => _memoryCache.Remove(key);
}