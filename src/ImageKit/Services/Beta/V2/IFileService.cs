using System;
using System.Threading;
using System.Threading.Tasks;
using ImageKit.Core;
using ImageKit.Models.Beta.V2.Files;

namespace ImageKit.Services.Beta.V2;

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

    /// <summary>
    /// The V2 API enhances security by verifying the entire payload using JWT. This API
    /// is in beta.
    ///
    /// <para>ImageKit.io allows you to upload files directly from both the server and
    /// client sides. For server-side uploads, private API key authentication is used.
    /// For client-side uploads, generate a one-time `token` from your secure backend
    /// using private API. [Learn
    /// more](/docs/api-reference/upload-file/upload-file-v2#how-to-implement-secure-client-side-file-upload)
    /// about how to implement secure client-side file upload.</para>
    ///
    /// <para>**File size limit** \ On the free plan, the maximum upload file sizes are
    /// 25MB for images, audio, and raw files, and 100MB for videos. On the Lite paid
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

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v2/files/upload</c>, but is otherwise the
    /// same as <see cref="IFileService.Upload(FileUploadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileUploadResponse>> Upload(
        FileUploadParams parameters,
        CancellationToken cancellationToken = default
    );
}
