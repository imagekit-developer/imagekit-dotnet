using System;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Files;
using Imagekit.Services.Files;

namespace Imagekit.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFileService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IBulkService Bulk { get; }

    IVersionService Versions { get; }

    IMetadataService Metadata { get; }

    /// <summary>
    /// This API updates the details or attributes of the current version of the file.
    /// You can update `tags`, `customCoordinates`, `customMetadata`, publication
    /// status, remove existing `AITags` and apply extensions using this API.
    /// </summary>
    Task<FileUpdateResponse> Update(
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(FileUpdateParams, CancellationToken)"/>
    Task<FileUpdateResponse> Update(
        string fileID,
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API deletes the file and all its file versions permanently.
    ///
    /// <para>Note: If a file or specific transformation has been requested in the past,
    /// then the response is cached. Deleting a file does not purge the cache. You can
    /// purge the cache using purge cache API. </para>
    /// </summary>
    Task Delete(FileDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(FileDeleteParams, CancellationToken)"/>
    Task Delete(
        string fileID,
        FileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This will copy a file from one folder to another.
    ///
    /// <para>Note: If any file at the destination has the same name as the source file,
    /// then the source file and its versions (if `includeFileVersions` is set to true)
    /// will be appended to the destination file version history. </para>
    /// </summary>
    Task<FileCopyResponse> Copy(
        FileCopyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API returns an object with details or attributes about the current version
    /// of the file.
    /// </summary>
    Task<File> Get(FileGetParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Get(FileGetParams, CancellationToken)"/>
    Task<File> Get(
        string fileID,
        FileGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This will move a file and all its versions from one folder to another.
    ///
    /// <para>Note: If any file at the destination has the same name as the source file,
    /// then the source file and its versions will be appended to the destination file. </para>
    /// </summary>
    Task<FileMoveResponse> Move(
        FileMoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// You can rename an already existing file in the media library using rename file
    /// API. This operation would rename all file versions of the file.
    ///
    /// <para>Note: The old URLs will stop working. The file/file version URLs cached on
    /// CDN will continue to work unless a purge is requested. </para>
    /// </summary>
    Task<FileRenameResponse> Rename(
        FileRenameParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// ImageKit.io allows you to upload files directly from both the server and client
    /// sides. For server-side uploads, private API key authentication is used. For
    /// client-side uploads, generate a one-time `token`, `signature`, and `expire` from
    /// your secure backend using private API. [Learn
    /// more](/docs/api-reference/upload-file/upload-file#how-to-implement-client-side-file-upload)
    /// about how to implement client-side file upload.
    ///
    /// <para>The [V2 API](/docs/api-reference/upload-file/upload-file-v2) enhances
    /// security by verifying the entire payload using JWT.</para>
    ///
    /// <para>**File size limit** \ On the free plan, the maximum upload file sizes are
    /// 25MB for images, audio, and raw files and 100MB for videos. On the Lite paid
    /// plan, these limits increase to 40MB for images, audio, and raw files and 300MB
    /// for videos, whereas on the Pro paid plan, these limits increase to 50MB for
    /// images, audio, and raw files and 2GB for videos. These limits can be further
    /// increased with enterprise plans.</para>
    ///
    /// <para>**Version limit** \ A file can have a maximum of 100 versions.</para>
    ///
    /// <para>**Demo applications**</para>
    ///
    /// <para>- A full-fledged [upload widget using
    /// Uppy](https://github.com/imagekit-samples/uppy-uploader), supporting file
    /// selections from local storage, URL, Dropbox, Google Drive, Instagram, and more.
    /// - [Quick start guides](/docs/quick-start-guides) for various frameworks and
    /// technologies. </para>
    /// </summary>
    Task<FileUploadResponse> Upload(
        FileUploadParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IBulkServiceWithRawResponse Bulk { get; }

    IVersionServiceWithRawResponse Versions { get; }

    IMetadataServiceWithRawResponse Metadata { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/files/{fileId}/details</c>, but is otherwise the
    /// same as <see cref="IFileService.Update(FileUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileUpdateResponse>> Update(
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(FileUpdateParams, CancellationToken)"/>
    Task<HttpResponse<FileUpdateResponse>> Update(
        string fileID,
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/files/{fileId}</c>, but is otherwise the
    /// same as <see cref="IFileService.Delete(FileDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(FileDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string fileID,
        FileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/files/copy</c>, but is otherwise the
    /// same as <see cref="IFileService.Copy(FileCopyParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileCopyResponse>> Copy(
        FileCopyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/files/{fileId}/details</c>, but is otherwise the
    /// same as <see cref="IFileService.Get(FileGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<File>> Get(
        FileGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(FileGetParams, CancellationToken)"/>
    Task<HttpResponse<File>> Get(
        string fileID,
        FileGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/files/move</c>, but is otherwise the
    /// same as <see cref="IFileService.Move(FileMoveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileMoveResponse>> Move(
        FileMoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/files/rename</c>, but is otherwise the
    /// same as <see cref="IFileService.Rename(FileRenameParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileRenameResponse>> Rename(
        FileRenameParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/files/upload</c>, but is otherwise the
    /// same as <see cref="IFileService.Upload(FileUploadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileUploadResponse>> Upload(
        FileUploadParams parameters,
        CancellationToken cancellationToken = default
    );
}
