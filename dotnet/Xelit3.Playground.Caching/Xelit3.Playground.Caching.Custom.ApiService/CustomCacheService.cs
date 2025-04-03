using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Text;

namespace Xelit3.Playground.Caching.Hybrid.ApiService;

public class CustomCacheService
{

    private readonly IDistributedCache _distributedCache;
    private readonly IMemoryCache _memoryCache;


    public CustomCacheService(IDistributedCache distributedCache, IMemoryCache memoryCache)
    {
        _distributedCache = distributedCache;
        _memoryCache = memoryCache;
    }


    public async Task<string> GetLastExecTimeAsync()
    {
        var lastExec = await _distributedCache.GetAsync(Constants.LastExecKey);
        var objString = string.Empty;

        if (lastExec == null)
        {
            var objMem = _memoryCache.Get(Constants.LastExecKey);
            objString = objMem?.ToString();
        }
        else
        {
            objString = Encoding.UTF8.GetString(lastExec);
        }
        
        return objString;
    }

    public async Task SetLastExecTimeAsync(DateTimeOffset date)
    {
        var dateStr = date.ToString();
        await _distributedCache.SetAsync(Constants.LastExecKey, Encoding.UTF8.GetBytes(dateStr));
        _memoryCache.Set(Constants.LastExecKey, dateStr, new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
        });
    }
}
