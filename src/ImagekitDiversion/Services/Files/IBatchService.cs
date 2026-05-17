using System;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Files.Batch;

namespace ImagekitDiversion.Services.Files;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBatchService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBatchServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This API deletes multiple files and all their file versions permanently.
    ///
    /// <para>Note: If a file or specific transformation has been requested in the past,
    /// then the response is cached. Deleting a file does not purge the cache. You can
    /// purge the cache using purge cache API.</para>
    ///
    /// <para>A maximum of 100 files can be deleted at a time. </para>
    /// </summary>
    Task<BatchDeleteResponse> Delete(
        BatchDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBatchService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBatchServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBatchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/files/batch/deleteByFileIds</c>, but is otherwise the
    /// same as <see cref="IBatchService.Delete(BatchDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BatchDeleteResponse>> Delete(
        BatchDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
