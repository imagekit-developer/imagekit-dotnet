using System.Collections.Generic;
using Imagekit.Models;

namespace Imagekit.Services;

/// <summary>
/// Helper utilities for URL generation and authentication.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public interface IHelperService
{
    /// <summary>
    /// Builds an ImageKit delivery URL, optionally applying transformations and signing.
    /// </summary>
    string BuildUrl(SrcOptions options);

    /// <summary>
    /// Builds a transformation string from a list of transformations.
    /// </summary>
    string BuildTransformationString(IReadOnlyList<Transformation> transformations);

    /// <summary>
    /// Generates authentication parameters for a client-side file upload.
    /// </summary>
    /// <param name="token">A unique token for this upload request. If null, a UUID is generated.</param>
    /// <param name="expires">Unix timestamp (seconds) for expiry. If null or 0, defaults to now + 30 minutes.</param>
    AuthenticationParameters GetAuthenticationParameters(string? token = null, long? expires = null);
}
