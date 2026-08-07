using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.NamedTransformations;
using Models = Imagekit.Models;

namespace Imagekit.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface INamedTransformationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INamedTransformationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INamedTransformationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new named transformation and returns the created object.
    ///
    /// <para>A named transformation is a short, reusable name for a transformation
    /// string. Use it in image and video URLs as `tr:n-&lt;name&gt;`, and update the
    /// underlying transformation later without changing existing URLs. Learn more about
    /// [named
    /// transformations](https://imagekit.io/docs/transformations#named-transformations).</para>
    ///
    /// <para>You can create up to 250 named transformations per account. </para>
    /// </summary>
    Task<Models::NamedTransformation> Create(
        NamedTransformationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates the named transformation identified by `id` and returns the updated
    /// object. Only the fields present in the request body are updated; other fields
    /// stay unchanged.
    ///
    /// <para>Renaming or disabling a named transformation fails with a `409` error if
    /// it is still referenced (via the `n-&lt;name&gt;` token) by another enabled named
    /// transformation, or by an upload pre-transformation/post-transformation setting.
    /// References from disabled named transformations don't count. This check is
    /// best-effort and can't detect references in your own application code or in
    /// previously generated URLs. </para>
    /// </summary>
    Task<Models::NamedTransformation> Update(
        NamedTransformationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(NamedTransformationUpdateParams, CancellationToken)"/>
    Task<Models::NamedTransformation> Update(
        string id,
        NamedTransformationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns an array of all named transformations configured for your account.
    /// </summary>
    Task<List<Models::NamedTransformation>> List(
        NamedTransformationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently deletes the named transformation identified by `id` and returns the
    /// deleted object.
    ///
    /// <para>Deletion fails with a `409` error if the named transformation is still
    /// referenced (via the `n-&lt;name&gt;` token) by another enabled named
    /// transformation, or by an upload pre-transformation/post-transformation setting.
    /// References from disabled named transformations don't count. This check is
    /// best-effort and can't detect references in your own application code or in
    /// previously generated URLs. </para>
    /// </summary>
    Task<Models::NamedTransformation> Delete(
        NamedTransformationDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(NamedTransformationDeleteParams, CancellationToken)"/>
    Task<Models::NamedTransformation> Delete(
        string id,
        NamedTransformationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the named transformation identified by `id`.
    /// </summary>
    Task<Models::NamedTransformation> Get(
        NamedTransformationGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(NamedTransformationGetParams, CancellationToken)"/>
    Task<Models::NamedTransformation> Get(
        string id,
        NamedTransformationGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="INamedTransformationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INamedTransformationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INamedTransformationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/named-transformations</c>, but is otherwise the
    /// same as <see cref="INamedTransformationService.Create(NamedTransformationCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Models::NamedTransformation>> Create(
        NamedTransformationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/named-transformations/{id}</c>, but is otherwise the
    /// same as <see cref="INamedTransformationService.Update(NamedTransformationUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Models::NamedTransformation>> Update(
        NamedTransformationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(NamedTransformationUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Models::NamedTransformation>> Update(
        string id,
        NamedTransformationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/named-transformations</c>, but is otherwise the
    /// same as <see cref="INamedTransformationService.List(NamedTransformationListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<Models::NamedTransformation>>> List(
        NamedTransformationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/named-transformations/{id}</c>, but is otherwise the
    /// same as <see cref="INamedTransformationService.Delete(NamedTransformationDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Models::NamedTransformation>> Delete(
        NamedTransformationDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(NamedTransformationDeleteParams, CancellationToken)"/>
    Task<HttpResponse<Models::NamedTransformation>> Delete(
        string id,
        NamedTransformationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/named-transformations/{id}</c>, but is otherwise the
    /// same as <see cref="INamedTransformationService.Get(NamedTransformationGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Models::NamedTransformation>> Get(
        NamedTransformationGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(NamedTransformationGetParams, CancellationToken)"/>
    Task<HttpResponse<Models::NamedTransformation>> Get(
        string id,
        NamedTransformationGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
