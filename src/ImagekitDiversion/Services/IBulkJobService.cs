using System;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.BulkJobs;

namespace ImagekitDiversion.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBulkJobService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBulkJobServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBulkJobService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This will copy one folder into another. The selected folder, its nested folders,
    /// files, and their versions (in `includeVersions` is set to true) are copied in
    /// this operation. Note: If any file at the destination has the same name as the
    /// source file, then the source file and its versions will be appended to the
    /// destination file version history.
    /// </summary>
    Task<Job> CopyFolder(
        BulkJobCopyFolderParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This will move one folder into another. The selected folder, its nested folders,
    /// files, and their versions are moved in this operation. Note: If any file at the
    /// destination has the same name as the source file, then the source file and its
    /// versions will be appended to the destination file version history.
    /// </summary>
    Task<Job> MoveFolder(
        BulkJobMoveFolderParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API allows you to rename an existing folder. The folder and all its nested
    /// assets and sub-folders will remain unchanged, but their paths will be updated to
    /// reflect the new folder name.
    /// </summary>
    Task<Job> RenameFolder(
        BulkJobRenameFolderParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API returns the status of a bulk job like copy and move folder operations.
    /// </summary>
    Task<BulkJobRetrieveStatusResponse> RetrieveStatus(
        BulkJobRetrieveStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveStatus(BulkJobRetrieveStatusParams, CancellationToken)"/>
    Task<BulkJobRetrieveStatusResponse> RetrieveStatus(
        string jobID,
        BulkJobRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBulkJobService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBulkJobServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBulkJobServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/bulkJobs/copyFolder</c>, but is otherwise the
    /// same as <see cref="IBulkJobService.CopyFolder(BulkJobCopyFolderParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Job>> CopyFolder(
        BulkJobCopyFolderParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/bulkJobs/moveFolder</c>, but is otherwise the
    /// same as <see cref="IBulkJobService.MoveFolder(BulkJobMoveFolderParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Job>> MoveFolder(
        BulkJobMoveFolderParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/bulkJobs/renameFolder</c>, but is otherwise the
    /// same as <see cref="IBulkJobService.RenameFolder(BulkJobRenameFolderParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Job>> RenameFolder(
        BulkJobRenameFolderParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/bulkJobs/{jobId}</c>, but is otherwise the
    /// same as <see cref="IBulkJobService.RetrieveStatus(BulkJobRetrieveStatusParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BulkJobRetrieveStatusResponse>> RetrieveStatus(
        BulkJobRetrieveStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveStatus(BulkJobRetrieveStatusParams, CancellationToken)"/>
    Task<HttpResponse<BulkJobRetrieveStatusResponse>> RetrieveStatus(
        string jobID,
        BulkJobRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
