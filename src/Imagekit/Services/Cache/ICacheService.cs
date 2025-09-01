using Imagekit.Services.Cache.Invalidation;

namespace Imagekit.Services.Cache;

public interface ICacheService
{
    IInvalidationService Invalidation { get; }
}
