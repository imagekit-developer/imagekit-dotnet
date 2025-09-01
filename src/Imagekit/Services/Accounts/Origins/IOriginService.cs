using System.Collections.Generic;
using System.Threading.Tasks;
using Imagekit.Models.Accounts.Origins;

namespace Imagekit.Services.Accounts.Origins;

public interface IOriginService
{
    /// <summary>
    /// **Note:** This API is currently in beta.   Creates a new origin and returns
    /// the origin object.
    /// </summary>
    Task<OriginResponse> Create(OriginCreateParams parameters);

    /// <summary>
    /// **Note:** This API is currently in beta.   Updates the origin identified
    /// by `id` and returns the updated origin object.
    /// </summary>
    Task<OriginResponse> Update(OriginUpdateParams parameters);

    /// <summary>
    /// **Note:** This API is currently in beta.   Returns an array of all configured
    /// origins for the current account.
    /// </summary>
    Task<List<OriginResponse>> List(OriginListParams? parameters = null);

    /// <summary>
    /// **Note:** This API is currently in beta.   Permanently removes the origin
    /// identified by `id`. If the origin is in use by any URL‑endpoints, the API
    /// will return an error.
    /// </summary>
    Task Delete(OriginDeleteParams parameters);

    /// <summary>
    /// **Note:** This API is currently in beta.   Retrieves the origin identified
    /// by `id`.
    /// </summary>
    Task<OriginResponse> Get(OriginGetParams parameters);
}
