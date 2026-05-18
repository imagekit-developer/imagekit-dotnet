using System;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Cache.Invalidation;

namespace Imagekit.Services.Cache;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInvalidationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInvalidationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvalidationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This API will purge CDN cache and ImageKit.io's internal cache for a file.  Note:
    /// Purge cache is an asynchronous process and it may take some time to reflect the changes.
    ///
    /// </summary>
    Task<InvalidationCreateResponse> Create(
        InvalidationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API returns the status of a purge cache request.
    /// </summary>
    Task<InvalidationGetResponse> Get(
        InvalidationGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(InvalidationGetParams, CancellationToken)"/>
    Task<InvalidationGetResponse> Get(
        string requestID,
        InvalidationGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInvalidationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInvalidationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvalidationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/files/purge</c>, but is otherwise the
    /// same as <see cref="IInvalidationService.Create(InvalidationCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvalidationCreateResponse>> Create(
        InvalidationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/files/purge/{requestId}</c>, but is otherwise the
    /// same as <see cref="IInvalidationService.Get(InvalidationGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvalidationGetResponse>> Get(
        InvalidationGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(InvalidationGetParams, CancellationToken)"/>
    Task<HttpResponse<InvalidationGetResponse>> Get(
        string requestID,
        InvalidationGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
