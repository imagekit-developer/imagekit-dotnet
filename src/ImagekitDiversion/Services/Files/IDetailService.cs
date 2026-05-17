using System;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Files.Details;

namespace ImagekitDiversion.Services.Files;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDetailService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDetailServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDetailService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This API returns an object with details or attributes about the current version
    /// of the file.
    /// </summary>
    Task<FileDetails> Retrieve(
        DetailRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DetailRetrieveParams, CancellationToken)"/>
    Task<FileDetails> Retrieve(
        string fileID,
        DetailRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API updates the details or attributes of the current version of the file.
    /// You can update `tags`, `customCoordinates`, `customMetadata`, publication
    /// status, remove existing `AITags` and apply extensions using this API.
    /// </summary>
    Task<DetailUpdateResponse> Update(
        DetailUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DetailUpdateParams, CancellationToken)"/>
    Task<DetailUpdateResponse> Update(
        string fileID,
        DetailUpdateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDetailService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDetailServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDetailServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/files/{fileId}/details</c>, but is otherwise the
    /// same as <see cref="IDetailService.Retrieve(DetailRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileDetails>> Retrieve(
        DetailRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DetailRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<FileDetails>> Retrieve(
        string fileID,
        DetailRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/files/{fileId}/details</c>, but is otherwise the
    /// same as <see cref="IDetailService.Update(DetailUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DetailUpdateResponse>> Update(
        DetailUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DetailUpdateParams, CancellationToken)"/>
    Task<HttpResponse<DetailUpdateResponse>> Update(
        string fileID,
        DetailUpdateParams parameters,
        CancellationToken cancellationToken = default
    );
}
