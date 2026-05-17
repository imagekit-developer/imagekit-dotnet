using System;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Files.Purge;

namespace ImagekitDiversion.Services.Files;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPurgeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPurgeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPurgeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This API will purge CDN cache and ImageKit.io's internal cache for a file.  Note:
    /// Purge cache is an asynchronous process and it may take some time to reflect the changes.
    ///
    /// </summary>
    Task<PurgeCacheResponse> Cache(
        PurgeCacheParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API returns the status of a purge cache request.
    /// </summary>
    Task<PurgeStatusResponse> Status(
        PurgeStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Status(PurgeStatusParams, CancellationToken)"/>
    Task<PurgeStatusResponse> Status(
        string requestID,
        PurgeStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPurgeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPurgeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPurgeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/files/purge</c>, but is otherwise the
    /// same as <see cref="IPurgeService.Cache(PurgeCacheParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PurgeCacheResponse>> Cache(
        PurgeCacheParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/files/purge/{requestId}</c>, but is otherwise the
    /// same as <see cref="IPurgeService.Status(PurgeStatusParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PurgeStatusResponse>> Status(
        PurgeStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Status(PurgeStatusParams, CancellationToken)"/>
    Task<HttpResponse<PurgeStatusResponse>> Status(
        string requestID,
        PurgeStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
