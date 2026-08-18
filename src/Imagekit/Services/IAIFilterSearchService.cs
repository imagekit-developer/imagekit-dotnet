using System;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.AIFilterSearch;

namespace Imagekit.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAIFilterSearchService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAIFilterSearchServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAIFilterSearchService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Convert a natural-language prompt into a structured ImageKit media-library
    /// search query. The response returns a `searchQuery` string (the same Lucene-like
    /// syntax accepted by the list and search assets API) plus suggested filter
    /// parameters. This endpoint only generates the query; it does not execute the
    /// search.
    /// </summary>
    Task<AIFilterSearchCreateResponse> Create(
        AIFilterSearchCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAIFilterSearchService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAIFilterSearchServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAIFilterSearchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/ai-filter-search</c>, but is otherwise the
    /// same as <see cref="IAIFilterSearchService.Create(AIFilterSearchCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AIFilterSearchCreateResponse>> Create(
        AIFilterSearchCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
