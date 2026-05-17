using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Files;
using Imagekit.Models.Files.Versions;

namespace Imagekit.Services.Files;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IVersionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVersionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVersionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This API returns details of all versions of a file.
    /// </summary>
    Task<List<File>> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(VersionListParams, CancellationToken)"/>
    Task<List<File>> List(
        string fileID,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API deletes a non-current file version permanently. The API returns an
    /// empty response.
    ///
    /// <para>Note: If you want to delete all versions of a file, use the delete file
    /// API. </para>
    /// </summary>
    Task<VersionDeleteResponse> Delete(
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(VersionDeleteParams, CancellationToken)"/>
    Task<VersionDeleteResponse> Delete(
        string versionID,
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API returns an object with details or attributes of a file version.
    /// </summary>
    Task<File> Get(VersionGetParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Get(VersionGetParams, CancellationToken)"/>
    Task<File> Get(
        string versionID,
        VersionGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API restores a file version as the current file version.
    /// </summary>
    Task<File> Restore(
        VersionRestoreParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Restore(VersionRestoreParams, CancellationToken)"/>
    Task<File> Restore(
        string versionID,
        VersionRestoreParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IVersionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVersionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVersionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/files/{fileId}/versions</c>, but is otherwise the
    /// same as <see cref="IVersionService.List(VersionListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<File>>> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(VersionListParams, CancellationToken)"/>
    Task<HttpResponse<List<File>>> List(
        string fileID,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/files/{fileId}/versions/{versionId}</c>, but is otherwise the
    /// same as <see cref="IVersionService.Delete(VersionDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VersionDeleteResponse>> Delete(
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(VersionDeleteParams, CancellationToken)"/>
    Task<HttpResponse<VersionDeleteResponse>> Delete(
        string versionID,
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/files/{fileId}/versions/{versionId}</c>, but is otherwise the
    /// same as <see cref="IVersionService.Get(VersionGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<File>> Get(
        VersionGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(VersionGetParams, CancellationToken)"/>
    Task<HttpResponse<File>> Get(
        string versionID,
        VersionGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/files/{fileId}/versions/{versionId}/restore</c>, but is otherwise the
    /// same as <see cref="IVersionService.Restore(VersionRestoreParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<File>> Restore(
        VersionRestoreParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Restore(VersionRestoreParams, CancellationToken)"/>
    Task<HttpResponse<File>> Restore(
        string versionID,
        VersionRestoreParams parameters,
        CancellationToken cancellationToken = default
    );
}
