using System;
using System.Threading;
using System.Threading.Tasks;
using ImageKit.Core;
using ImageKit.Models.Files.Bulk;

namespace ImageKit.Services.Files;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBulkService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBulkServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBulkService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This API deletes multiple files and all their file versions permanently.
    ///
    /// <para>Note: If a file or specific transformation has been requested in the
    /// past, then the response is cached. Deleting a file does not purge the cache.
    /// You can purge the cache using purge cache API.</para>
    ///
    /// <para>A maximum of 100 files can be deleted at a time.</para>
    /// </summary>
    Task<BulkDeleteResponse> Delete(
        BulkDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API adds tags to multiple files in bulk. A maximum of 50 files can be
    /// specified at a time.
    /// </summary>
    Task<BulkAddTagsResponse> AddTags(
        BulkAddTagsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API removes AITags from multiple files in bulk. A maximum of 50 files
    /// can be specified at a time.
    /// </summary>
    Task<BulkRemoveAITagsResponse> RemoveAITags(
        BulkRemoveAITagsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API removes tags from multiple files in bulk. A maximum of 50 files
    /// can be specified at a time.
    /// </summary>
    Task<BulkRemoveTagsResponse> RemoveTags(
        BulkRemoveTagsParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBulkService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBulkServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBulkServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/files/batch/deleteByFileIds`, but is otherwise the
    /// same as <see cref="IBulkService.Delete(BulkDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BulkDeleteResponse>> Delete(
        BulkDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/files/addTags`, but is otherwise the
    /// same as <see cref="IBulkService.AddTags(BulkAddTagsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BulkAddTagsResponse>> AddTags(
        BulkAddTagsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/files/removeAITags`, but is otherwise the
    /// same as <see cref="IBulkService.RemoveAITags(BulkRemoveAITagsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BulkRemoveAITagsResponse>> RemoveAITags(
        BulkRemoveAITagsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/files/removeTags`, but is otherwise the
    /// same as <see cref="IBulkService.RemoveTags(BulkRemoveTagsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BulkRemoveTagsResponse>> RemoveTags(
        BulkRemoveTagsParams parameters,
        CancellationToken cancellationToken = default
    );
}
