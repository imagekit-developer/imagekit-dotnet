using System;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Folders;
using Imagekit.Services.Folders;

namespace Imagekit.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFolderService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFolderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFolderService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IJobService Job { get; }

    /// <summary>
    /// This will create a new folder. You can specify the folder name and location of
    /// the parent folder where this new folder should be created.
    /// </summary>
    Task<FolderCreateResponse> Create(
        FolderCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This will delete a folder and all its contents permanently. The API returns an
    /// empty response.
    /// </summary>
    Task<FolderDeleteResponse> Delete(
        FolderDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This will copy one folder into another. The selected folder, its nested folders,
    /// files, and their versions (in `includeVersions` is set to true) are copied in
    /// this operation. Note: If any file at the destination has the same name as the
    /// source file, then the source file and its versions will be appended to the
    /// destination file version history.
    /// </summary>
    Task<FolderCopyResponse> Copy(
        FolderCopyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This will move one folder into another. The selected folder, its nested folders,
    /// files, and their versions are moved in this operation. Note: If any file at the
    /// destination has the same name as the source file, then the source file and its
    /// versions will be appended to the destination file version history.
    /// </summary>
    Task<FolderMoveResponse> Move(
        FolderMoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API allows you to rename an existing folder. The folder and all its nested
    /// assets and sub-folders will remain unchanged, but their paths will be updated to
    /// reflect the new folder name.
    /// </summary>
    Task<FolderRenameResponse> Rename(
        FolderRenameParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFolderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFolderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFolderServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IJobServiceWithRawResponse Job { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/folder</c>, but is otherwise the
    /// same as <see cref="IFolderService.Create(FolderCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FolderCreateResponse>> Create(
        FolderCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/folder</c>, but is otherwise the
    /// same as <see cref="IFolderService.Delete(FolderDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FolderDeleteResponse>> Delete(
        FolderDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/bulkJobs/copyFolder</c>, but is otherwise the
    /// same as <see cref="IFolderService.Copy(FolderCopyParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FolderCopyResponse>> Copy(
        FolderCopyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/bulkJobs/moveFolder</c>, but is otherwise the
    /// same as <see cref="IFolderService.Move(FolderMoveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FolderMoveResponse>> Move(
        FolderMoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/bulkJobs/renameFolder</c>, but is otherwise the
    /// same as <see cref="IFolderService.Rename(FolderRenameParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FolderRenameResponse>> Rename(
        FolderRenameParams parameters,
        CancellationToken cancellationToken = default
    );
}
