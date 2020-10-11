using System;
using System.Linq;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace NetCoreFramework.Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        protected ObjectCache Cache => MemoryCache.Default;

        public T GetData<T>(string key)
        {
            return (T)Cache[key];
        }

        public void Add<T>(string key, T data, int cacheTime = 60)
        {
            if (data == null)
                return;

            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime)
            };

            Cache.Add(new CacheItem(key, data), policy);
        }

        public bool IsExist(string key)
        {
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, 
                RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);

            var keysToDelete = Cache.Where(x => regex.IsMatch(x.Key)).Select(x => x.Key).ToList();

            foreach (var key in keysToDelete)
            {
                Remove(key);
            }
        }

        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }
    }
}