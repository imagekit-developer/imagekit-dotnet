using System;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Dummy;

namespace Imagekit.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDummyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDummyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDummyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Internal test endpoint for SDK generation purposes only. This endpoint
    /// demonstrates usage of all shared models defined in the Stainless configuration
    /// and is not intended for public consumption.
    /// </summary>
    Task Create(
        DummyCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDummyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDummyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDummyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/dummy/test</c>, but is otherwise the
    /// same as <see cref="IDummyService.Create(DummyCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        DummyCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
