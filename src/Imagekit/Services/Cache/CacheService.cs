using System;
using Imagekit.Services.Cache.Invalidation;

namespace Imagekit.Services.Cache;

public sealed class CacheService : ICacheService
{
    public CacheService(IImageKitClient client)
    {
        _invalidation = new(() => new InvalidationService(client));
    }

    readonly Lazy<IInvalidationService> _invalidation;
    public IInvalidationService Invalidation
    {
        get { return _invalidation.Value; }
    }
}
