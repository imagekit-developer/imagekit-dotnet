using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.SavedExtensions;

namespace ImagekitDiversion.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISavedExtensionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISavedExtensionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISavedExtensionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This API creates a new saved extension. Saved extensions allow you to save
    /// complex extension configurations (like AI tasks) and reuse them by referencing
    /// the ID in upload or update file APIs.
    ///
    /// <para>**Saved extension limit** \ You can create a maximum of 100 saved
    /// extensions per account. </para>
    /// </summary>
    Task<SavedExtension> Create(
        SavedExtensionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API returns details of a specific saved extension by ID.
    /// </summary>
    Task<SavedExtension> Retrieve(
        SavedExtensionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SavedExtensionRetrieveParams, CancellationToken)"/>
    Task<SavedExtension> Retrieve(
        string id,
        SavedExtensionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API updates an existing saved extension. You can update the name,
    /// description, or config.
    /// </summary>
    Task<SavedExtension> Update(
        SavedExtensionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SavedExtensionUpdateParams, CancellationToken)"/>
    Task<SavedExtension> Update(
        string id,
        SavedExtensionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API returns an array of all saved extensions for your account. Saved
    /// extensions allow you to save complex extension configurations and reuse them by
    /// referencing them by ID in upload or update file APIs.
    /// </summary>
    Task<List<SavedExtension>> List(
        SavedExtensionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API deletes a saved extension permanently.
    /// </summary>
    Task Delete(
        SavedExtensionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SavedExtensionDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        SavedExtensionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISavedExtensionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISavedExtensionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISavedExtensionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/saved-extensions</c>, but is otherwise the
    /// same as <see cref="ISavedExtensionService.Create(SavedExtensionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SavedExtension>> Create(
        SavedExtensionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/saved-extensions/{id}</c>, but is otherwise the
    /// same as <see cref="ISavedExtensionService.Retrieve(SavedExtensionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SavedExtension>> Retrieve(
        SavedExtensionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SavedExtensionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SavedExtension>> Retrieve(
        string id,
        SavedExtensionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/saved-extensions/{id}</c>, but is otherwise the
    /// same as <see cref="ISavedExtensionService.Update(SavedExtensionUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SavedExtension>> Update(
        SavedExtensionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SavedExtensionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<SavedExtension>> Update(
        string id,
        SavedExtensionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/saved-extensions</c>, but is otherwise the
    /// same as <see cref="ISavedExtensionService.List(SavedExtensionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<SavedExtension>>> List(
        SavedExtensionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/saved-extensions/{id}</c>, but is otherwise the
    /// same as <see cref="ISavedExtensionService.Delete(SavedExtensionDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        SavedExtensionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SavedExtensionDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        SavedExtensionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
