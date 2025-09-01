using System.Threading.Tasks;
using Imagekit.Models.Cache.Invalidation;

namespace Imagekit.Services.Cache.Invalidation;

public interface IInvalidationService
{
    /// <summary>
    /// This API will purge CDN cache and ImageKit.io's internal cache for a file.
    ///  Note: Purge cache is an asynchronous process and it may take some time to
    /// reflect the changes.
    /// </summary>
    Task<InvalidationCreateResponse> Create(InvalidationCreateParams parameters);

    /// <summary>
    /// This API returns the status of a purge cache request.
    /// </summary>
    Task<InvalidationGetResponse> Get(InvalidationGetParams parameters);
}
