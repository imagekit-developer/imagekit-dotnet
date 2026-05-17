using System;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Files;
using Imagekit.Models.Files.Metadata;

namespace Imagekit.Services.Files;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMetadataService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMetadataServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMetadataService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// You can programmatically get image EXIF, pHash, and other metadata for uploaded
    /// files in the ImageKit.io media library using this API.
    ///
    /// <para>You can also get the metadata in upload API response by passing `metadata`
    /// in `responseFields` parameter. </para>
    /// </summary>
    Task<FileMetadata> Get(
        MetadataGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(MetadataGetParams, CancellationToken)"/>
    Task<FileMetadata> Get(
        string fileID,
        MetadataGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get image EXIF, pHash, and other metadata from ImageKit.io powered remote URL
    /// using this API.
    /// </summary>
    Task<FileMetadata> GetFromUrl(
        MetadataGetFromUrlParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMetadataService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMetadataServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMetadataServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/files/{fileId}/metadata</c>, but is otherwise the
    /// same as <see cref="IMetadataService.Get(MetadataGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileMetadata>> Get(
        MetadataGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(MetadataGetParams, CancellationToken)"/>
    Task<HttpResponse<FileMetadata>> Get(
        string fileID,
        MetadataGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/metadata</c>, but is otherwise the
    /// same as <see cref="IMetadataService.GetFromUrl(MetadataGetFromUrlParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileMetadata>> GetFromUrl(
        MetadataGetFromUrlParams parameters,
        CancellationToken cancellationToken = default
    );
}
