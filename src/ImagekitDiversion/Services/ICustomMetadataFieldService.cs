using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.CustomMetadataFields;

namespace ImagekitDiversion.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICustomMetadataFieldService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICustomMetadataFieldServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomMetadataFieldService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This API creates a new custom metadata field. Once a custom metadata field is
    /// created either through this API or using the dashboard UI, its value can be set
    /// on the assets. The value of a field for an asset can be set using the media
    /// library UI or programmatically through upload or update assets API.
    /// </summary>
    Task<CustomMetadataField> Create(
        CustomMetadataFieldCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API updates the label or schema of an existing custom metadata field.
    /// </summary>
    Task<CustomMetadataField> Update(
        CustomMetadataFieldUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CustomMetadataFieldUpdateParams, CancellationToken)"/>
    Task<CustomMetadataField> Update(
        string id,
        CustomMetadataFieldUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API returns the array of created custom metadata field objects. By default
    /// the API returns only non deleted field objects, but you can include deleted
    /// fields in the API response.
    ///
    /// <para>You can also filter results by a specific folder path to retrieve custom
    /// metadata fields applicable at that location. This path-specific filtering is
    /// useful when using the **Path policy** feature to determine which custom metadata
    /// fields are selected for a given path. </para>
    /// </summary>
    Task<List<CustomMetadataField>> List(
        CustomMetadataFieldListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API deletes a custom metadata field. Even after deleting a custom metadata
    /// field, you cannot create any new custom metadata field with the same name.
    /// </summary>
    Task<CustomMetadataFieldDeleteResponse> Delete(
        CustomMetadataFieldDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CustomMetadataFieldDeleteParams, CancellationToken)"/>
    Task<CustomMetadataFieldDeleteResponse> Delete(
        string id,
        CustomMetadataFieldDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICustomMetadataFieldService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICustomMetadataFieldServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomMetadataFieldServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/customMetadataFields</c>, but is otherwise the
    /// same as <see cref="ICustomMetadataFieldService.Create(CustomMetadataFieldCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomMetadataField>> Create(
        CustomMetadataFieldCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/customMetadataFields/{id}</c>, but is otherwise the
    /// same as <see cref="ICustomMetadataFieldService.Update(CustomMetadataFieldUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomMetadataField>> Update(
        CustomMetadataFieldUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CustomMetadataFieldUpdateParams, CancellationToken)"/>
    Task<HttpResponse<CustomMetadataField>> Update(
        string id,
        CustomMetadataFieldUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/customMetadataFields</c>, but is otherwise the
    /// same as <see cref="ICustomMetadataFieldService.List(CustomMetadataFieldListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<CustomMetadataField>>> List(
        CustomMetadataFieldListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/customMetadataFields/{id}</c>, but is otherwise the
    /// same as <see cref="ICustomMetadataFieldService.Delete(CustomMetadataFieldDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomMetadataFieldDeleteResponse>> Delete(
        CustomMetadataFieldDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CustomMetadataFieldDeleteParams, CancellationToken)"/>
    Task<HttpResponse<CustomMetadataFieldDeleteResponse>> Delete(
        string id,
        CustomMetadataFieldDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
