namespace Infrastructure.Repositories.Cache;

public interface ICacheRepository
{
    object? GetFromCache(string key);
    void SetInCache(string key, object value, TimeSpan cacheTime);
    void Remove(string key);
}