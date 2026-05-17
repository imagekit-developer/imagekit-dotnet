using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Files;
using ImagekitDiversion.Services.Files;

namespace ImagekitDiversion.Services;

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

    IDetailService Details { get; }

    IBatchService Batch { get; }

    IVersionService Versions { get; }

    IPurgeService Purge { get; }

    /// <summary>
    /// This API can list all the uploaded files and folders in your ImageKit.io media
    /// library. In addition, you can fine-tune your query by specifying various filters
    /// by generating a query string in a Lucene-like syntax and provide this generated
    /// string as the value of the `searchQuery`.
    /// </summary>
    Task<List<FileListResponse>> List(
        FileListParams? parameters = null,
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
    /// This API adds tags to multiple files in bulk. A maximum of 50 files can be
    /// specified at a time.
    /// </summary>
    Task<FileAddTagsResponse> AddTags(
        FileAddTagsParams parameters,
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
    /// This API removes AITags from multiple files in bulk. A maximum of 50 files can
    /// be specified at a time.
    /// </summary>
    Task<FileRemoveAITagsResponse> RemoveAITags(
        FileRemoveAITagsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API removes tags from multiple files in bulk. A maximum of 50 files can be
    /// specified at a time.
    /// </summary>
    Task<FileRemoveTagsResponse> RemoveTags(
        FileRemoveTagsParams parameters,
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
    /// You can programmatically get image EXIF, pHash, and other metadata for uploaded
    /// files in the ImageKit.io media library using this API.
    ///
    /// <para>You can also get the metadata in upload API response by passing `metadata`
    /// in `responseFields` parameter. </para>
    /// </summary>
    Task<FileMetadata> RetrieveMetadata(
        FileRetrieveMetadataParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveMetadata(FileRetrieveMetadataParams, CancellationToken)"/>
    Task<FileMetadata> RetrieveMetadata(
        string fileID,
        FileRetrieveMetadataParams? parameters = null,
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

    IDetailServiceWithRawResponse Details { get; }

    IBatchServiceWithRawResponse Batch { get; }

    IVersionServiceWithRawResponse Versions { get; }

    IPurgeServiceWithRawResponse Purge { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/files</c>, but is otherwise the
    /// same as <see cref="IFileService.List(FileListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<FileListResponse>>> List(
        FileListParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /v1/files/addTags</c>, but is otherwise the
    /// same as <see cref="IFileService.AddTags(FileAddTagsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileAddTagsResponse>> AddTags(
        FileAddTagsParams parameters,
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
    /// Returns a raw HTTP response for <c>post /v1/files/move</c>, but is otherwise the
    /// same as <see cref="IFileService.Move(FileMoveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileMoveResponse>> Move(
        FileMoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/files/removeAITags</c>, but is otherwise the
    /// same as <see cref="IFileService.RemoveAITags(FileRemoveAITagsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileRemoveAITagsResponse>> RemoveAITags(
        FileRemoveAITagsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/files/removeTags</c>, but is otherwise the
    /// same as <see cref="IFileService.RemoveTags(FileRemoveTagsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileRemoveTagsResponse>> RemoveTags(
        FileRemoveTagsParams parameters,
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
    /// Returns a raw HTTP response for <c>get /v1/files/{fileId}/metadata</c>, but is otherwise the
    /// same as <see cref="IFileService.RetrieveMetadata(FileRetrieveMetadataParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileMetadata>> RetrieveMetadata(
        FileRetrieveMetadataParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveMetadata(FileRetrieveMetadataParams, CancellationToken)"/>
    Task<HttpResponse<FileMetadata>> RetrieveMetadata(
        string fileID,
        FileRetrieveMetadataParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
