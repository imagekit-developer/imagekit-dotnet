using System;
using ImagekitDiversion.Core;
using ImagekitDiversion.Services.Api;

namespace ImagekitDiversion.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IApiService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IApiServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IApiService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IV1Service V1 { get; }

    IV2Service V2 { get; }
}

/// <summary>
/// A view of <see cref="IApiService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IApiServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IApiServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IV1ServiceWithRawResponse V1 { get; }

    IV2ServiceWithRawResponse V2 { get; }
}
