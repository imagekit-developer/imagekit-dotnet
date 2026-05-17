using System;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Files;
using ImagekitDiversion.Models.Metadata;

namespace ImagekitDiversion.Services;

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
    /// Get image EXIF, pHash, and other metadata from ImageKit.io powered remote URL
    /// using this API.
    /// </summary>
    Task<FileMetadata> Retrieve(
        MetadataRetrieveParams parameters,
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
    /// Returns a raw HTTP response for <c>get /v1/metadata</c>, but is otherwise the
    /// same as <see cref="IMetadataService.Retrieve(MetadataRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileMetadata>> Retrieve(
        MetadataRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}
