﻿namespace AnalyticsDemo.Application.Interfaces
{
    /// <summary>
    /// caching layer for frequesntly access data.
    /// </summary>
    public interface ICacheService
    {
        Task<T?> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, TimeSpan? expiration = null);
        Task RemoveAsync(string key);
    }
}
