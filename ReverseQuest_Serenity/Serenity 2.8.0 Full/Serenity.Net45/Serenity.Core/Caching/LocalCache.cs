﻿
namespace Serenity
{
    using Serenity.Abstractions;
    using System;

    /// <summary>
    /// Contains helper functions to access currently registered ILocalCache provider.
    /// </summary>
    public static class LocalCache
    {
        /// <summary>
        /// Use to skip Dependency.Resolve calls only when performance is critical
        /// </summary>
        public static ILocalCache StaticProvider;

        public static ILocalCache Provider
        {
            get
            {
                return StaticProvider ?? Dependency.Resolve<ILocalCache>();
            }
        }

        /// <summary>
        /// Adds a value to cache with a given key
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <param name="expiration">Expire time (Use TimeSpan.Zero to hold value with no expiration)</param>
        public static void Add(string key, object value, TimeSpan expiration)
        {
            Provider.Add(key, value, expiration);
        }

        /// <summary>
        /// Reads the value with specified key from the local cache. If it doesn't exists in cache, calls the loader 
        /// function to generate value (from database etc.) and adds it to the cache. If loader returns a null value, 
        /// it is written to the cache as DBNull.Value.
        /// </summary>
        /// <typeparam name="TItem">Data type</typeparam>
        /// <param name="cacheKey">Key</param>
        /// <param name="expiration">Expiration (TimeSpan.Zero means no expiration)</param>
        /// <param name="loader">Loader function that will be called if item doesn't exist in the cache.</param>
        public static TItem Get<TItem>(string cacheKey, TimeSpan expiration, Func<TItem> loader)
            where TItem : class
        {
            var cachedObj = Provider.Get<object>(cacheKey);
            
            if (cachedObj == DBNull.Value)
            {
                return null;
            }

            if (cachedObj == null)
            {
                var item = loader();
                Add(cacheKey, (object) item ?? DBNull.Value, expiration);
                return item;
            }

            return (TItem) cachedObj;
        }

        /// <summary>
        /// Reads the value of given type with specified key from the local cache. If the value doesn't exist or not
        /// of given type, it returns null.
        /// </summary>
        /// <typeparam name="TItem">Expected type</typeparam>
        /// <param name="cacheKey">Key</param>
        public static TItem TryGet<TItem>(string cacheKey)
            where TItem : class
        {
            return Provider.Get<object>(cacheKey) as TItem;
        }

        /// <summary>
        /// Removes the value with specified key from the local cache. If the value doesn't exist, no error is raised.
        /// </summary>
        /// <param name="cacheKey">Key</param>
        public static object Remove(string cacheKey)
        {
            return Provider.Remove(cacheKey);
        }

        /// <summary>
        /// Removes all items from the cache (avoid expect unit tests).
        /// </summary>
        public static void RemoveAll()
        {
            Provider.RemoveAll();
        }
    }
}