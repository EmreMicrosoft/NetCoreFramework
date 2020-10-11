namespace NetCoreFramework.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T GetData<T>(string key);
        void Add<T>(string key, T data, int cacheTime);
        // void Add(string key, object data, int cacheTime);
        bool IsExist(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
        void Clear();
    }
}