using System.Threading.Tasks;
using Imagekit.Models.Beta.V2.Files;

namespace Imagekit.Services.Beta.V2.Files;

public interface IFileService
{
    /// <summary>
    /// The V2 API enhances security by verifying the entire payload using JWT. This
    /// API is in beta.
    ///
    /// ImageKit.io allows you to upload files directly from both the server and client
    /// sides. For server-side uploads, private API key authentication is used. For
    /// client-side uploads, generate a one-time `token` from your secure backend
    /// using private API. [Learn more](/docs/api-reference/upload-file/upload-file-v2#how-to-implement-secure-client-side-file-upload)
    /// about how to implement secure client-side file upload.
    ///
    /// **File size limit** \ On the free plan, the maximum upload file sizes are
    /// 20MB for images, audio, and raw files, and 100MB for videos. On the paid plan,
    /// these limits increase to 40MB for images, audio, and raw files, and 2GB for
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
