using Scietec.Combine.Cache;
using Alva.ArTextBook.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alva.ArTextBook.Utils
{
    public static class CacheUtils
    {
        #region COMMON
        private static SimpleCache _cache;
        public static void Init()
        {
            _cache = new SimpleCache();
        }

        public static void Destory()
        {
            _cache?.Dispose();
        }

        public static void Set(String key,
           CacheObjectGen objGen, object para, int timeout)
        {
            _cache.Set(key, objGen, para, timeout);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="timeout">分钟,小于等于0，永远不清理</param>
        public static void Set(String key, object obj, int timeout)
        {
            _cache.Set(key, obj, timeout);
        }

        public static void Set(String key, object obj)
        {
            _cache.Set(key, obj, 20);
        }

        public static object Get(string key)
        {
            return _cache.Get(key);
        }

        public static T Get<T>(string key)
        {
            return (T)_cache.Get(key);
        }

        public static void Remove(string key)
        {
            _cache.Set(key, null, 1);
        }
        #endregion
    }
}
