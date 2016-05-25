using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using DevZa.Logger;

namespace DevZa.Caching
{
    public class MemoryCacheManager<T> : ICacheManager<T>
    {
        private static IZaLogger _log = LoggerFactory.GetLogger<MemoryCacheManager<T>>();

        private  static MemoryCache _cache = new MemoryCache((typeof(T).FullName));

        private  double _cacheTime = 30;

        public MemoryCacheManager()
        {
            
        }

        public MemoryCacheManager(double cacheTime)
        {
            UpdateDefaultCacheTime(cacheTime);
        }

        public T GetCacheObject(string key,Func<string,T> getFunc )
        {
            return GetCacheObject(key, getFunc, _cacheTime);
        }

        public T GetCacheObject(string key, Func<string, T> getFunc, double cacheTime)
        {
            if (!_cache.Contains(key))
            {
                _log.DebugParm("Cache Not Exist Load from Function",key);
                var policy = CacheItemPolicy(cacheTime);
                var obj = getFunc(key);
                if (obj == null) return default(T);
                _cache.Add(key, obj, policy);
            }

            return (T)_cache[key];
        }

        public void RemoveCacheObject(string key)
        {
            _cache.Remove(key);
        }

        public void UpdateDefaultCacheTime(double cacheTime)
        {
            _cacheTime = cacheTime;
        }

        public void AddCacheObject(string key, T inputObject)
        {
            if (!_cache.Contains(key))
                _cache.Add(key, inputObject, CacheItemPolicy(_cacheTime) );
        }

        public void UpdateCacheObject(string key, T inputObject)
        {
            RemoveCacheObject(key);
            AddCacheObject(key,inputObject);
        }

        public void ClearAll()
        {
            _cache = new MemoryCache((typeof(T).FullName));
        }

        public List<T> GetAllObjects()
        {
            return _cache.Select(t => (T) t.Value).ToList();
        }


        private static CacheItemPolicy CacheItemPolicy(double cacheTime)
        {
            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            return policy;
        }
    }
}