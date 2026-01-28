using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ImageKit.Core;
using ImageKit.Models.Assets;

namespace ImageKit.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAssetService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAssetServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAssetService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This API can list all the uploaded files and folders in your ImageKit.io media
    /// library. In addition, you can fine-tune your query by specifying various filters
    /// by generating a query string in a Lucene-like syntax and provide this generated
    /// string as the value of the `searchQuery`.
    /// </summary>
    Task<List<AssetListResponse>> List(
        AssetListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAssetService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAssetServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAssetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/files`, but is otherwise the
    /// same as <see cref="IAssetService.List(AssetListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<AssetListResponse>>> List(
        AssetListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
