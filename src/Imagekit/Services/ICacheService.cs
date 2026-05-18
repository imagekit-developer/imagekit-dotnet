using System;
using Imagekit.Core;
using Imagekit.Services.Cache;

namespace Imagekit.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICacheService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICacheServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICacheService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IInvalidationService Invalidation { get; }
}

/// <summary>
/// A view of <see cref="ICacheService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICacheServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICacheServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IInvalidationServiceWithRawResponse Invalidation { get; }
}
