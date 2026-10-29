using System;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Tags;

namespace Imagekit.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITagService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITagServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITagService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This API lists the distinct tags in use across your media library, with the
    /// number of assets each tag is applied to and when it was last used. Tags are
    /// matched case-insensitively, so `Summer` and `summer` are one entry: `name` is
    /// the lowercased form and `label` is the spelling that was used most recently.
    ///
    /// <para>Use `tagSource` and `fileType` to list only the tags in use on matching
    /// assets. `lastUsedAt` and the `ASC_LAST_USED` / `DESC_LAST_USED` sorts follow
    /// those filters, while `assetCount` always counts every asset carrying the tag.
    /// Use `search` or `prefix` to narrow the listing and `cursor` to page through it.</para>
    ///
    /// <para>Tag counts are updated asynchronously. Changes to a file's tags usually
    /// appear in this list within about a minute, but can take longer during heavy
    /// tagging activity, so a tag you just added or removed may not be reflected
    /// immediately. </para>
    /// </summary>
    Task<TagListResponse> List(
        TagListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITagService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITagServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITagServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/tags</c>, but is otherwise the
    /// same as <see cref="ITagService.List(TagListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TagListResponse>> List(
        TagListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
