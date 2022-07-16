using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Specifications.Abstraction;
using StackExchange.Redis;

namespace Infrastructure.Implementation
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDatabase _database;
        public ResponseCacheService(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task<string> GetCachedResponseAsync(string cacheKey)
        {
            var chacedResponse = await _database.StringGetAsync(cacheKey);
            if(chacedResponse.IsNullOrEmpty){
                return null;
            }
            return chacedResponse;
        }

        public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive)
        {
            if(response == null){
                return;
            }

            var options = new JsonSerializerOptions{
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var serializedResponse = JsonSerializer.Serialize(response, options);
            await _database.StringSetAsync(cacheKey, serializedResponse,timeToLive);
        }
    }
}