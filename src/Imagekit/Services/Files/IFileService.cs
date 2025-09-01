using System.Threading.Tasks;
using Imagekit.Models.Files;
using Imagekit.Services.Files.Bulk;
using Imagekit.Services.Files.Metadata;
using Imagekit.Services.Files.Versions;

namespace Imagekit.Services.Files;

public interface IFileService
{
    IBulkService Bulk { get; }

    IVersionService Versions { get; }

    IMetadataService Metadata { get; }

    /// <summary>
    /// This API updates the details or attributes of the current version of the
    /// file. You can update `tags`, `customCoordinates`, `customMetadata`, publication
    /// status, remove existing `AITags` and apply extensions using this API.
    /// </summary>
    Task<FileUpdateResponse> Update(FileUpdateParams parameters);

    /// <summary>
    /// This API deletes the file and all its file versions permanently.
    ///
    /// Note: If a file or specific transformation has been requested in the past,
    /// then the response is cached. Deleting a file does not purge the cache. You
    /// can purge the cache using purge cache API.
    /// </summary>
    Task Delete(FileDeleteParams parameters);

    /// <summary>
    /// This will copy a file from one folder to another.
    ///
    /// Note: If any file at the destination has the same name as the source file,
    /// then the source file and its versions (if `includeFileVersions` is set to
    /// true) will be appended to the destination file version history.
    /// </summary>
    Task<FileCopyResponse> Copy(FileCopyParams parameters);

    /// <summary>
    /// This API returns an object with details or attributes about the current version
    /// of the file.
    /// </summary>
    Task<File> Get(FileGetParams parameters);

    /// <summary>
    /// This will move a file and all its versions from one folder to another.
    ///
    /// Note: If any file at the destination has the same name as the source file,
    /// then the source file and its versions will be appended to the destination
    /// file.
    /// </summary>
    Task<FileMoveResponse> Move(FileMoveParams parameters);

    /// <summary>
    /// You can rename an already existing file in the media library using rename
    /// file API. This operation would rename all file versions of the file.
    ///
    /// Note: The old URLs will stop working. The file/file version URLs cached on
    /// CDN will continue to work unless a purge is requested.
    /// </summary>
    Task<FileRenameResponse> Rename(FileRenameParams parameters);

    /// <summary>
    /// ImageKit.io allows you to upload files directly from both the server and client
    /// sides. For server-side uploads, private API key authentication is used. For
    /// client-side uploads, generate a one-time `token`, `signature`, and `expire`
    /// from your secure backend using private API. [Learn more](/docs/api-reference/upload-file/upload-file#how-to-implement-client-side-file-upload)
    /// about how to implement client-side file upload.
    ///
    /// The [V2 API](/docs/api-reference/upload-file/upload-file-v2) enhances security
    /// by verifying the entire payload using JWT.
    ///
    /// **File size limit** \ On the free plan, the maximum upload file sizes are
    /// 20MB for images, audio, and raw files and 100MB for videos. On the paid plan,
    /// these limits increase to 40MB for images, audio, and raw files and 2GB for
    /// videos. These limits can be further increased with higher-tier plans.
    ///
    /// **Version limit** \ A file can have a maximum of 100 versions.
    ///
    /// **Demo applications**
    ///
    /// - A full-fledged [upload widget using Uppy](https://github.com/imagekit-samples/uppy-uploader),
    /// supporting file selections from local storage, URL, Dropbox, Google Drive,
    /// Instagram, and more. - [Quick start guides](/docs/quick-start-guides) for
    /// various frameworks and technologies.
    /// </summary>
    Task<FileUploadResponse> Upload(FileUploadParams parameters);
}
