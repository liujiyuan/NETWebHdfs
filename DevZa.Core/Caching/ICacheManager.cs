using System;
using System.Collections.Generic;

namespace DevZa.Caching
{
    public interface ICacheManager<T>
    {
        T GetCacheObject(string key, Func<string,T> getFunc);

        T GetCacheObject(string key, Func<string, T> getFunc, double cacheTime);

        List<T> GetAllObjects();

        void RemoveCacheObject(string key);

        void UpdateDefaultCacheTime(double cachetime);

        void AddCacheObject(string key, T inputObject);

        void UpdateCacheObject(string key, T inputObject);

        void ClearAll();
    }
}
