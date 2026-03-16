using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ImageKit.Core;
using ImageKit.Models.Accounts.Origins;

namespace ImageKit.Services.Accounts;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IOriginService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IOriginServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOriginService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// **Note:** This API is currently in beta.   Creates a new origin and returns the
    /// origin object.
    /// </summary>
    Task<OriginResponse> Create(
        OriginCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Note:** This API is currently in beta.   Updates the origin identified by `id`
    /// and returns the updated origin object.
    /// </summary>
    Task<OriginResponse> Update(
        OriginUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(OriginUpdateParams, CancellationToken)"/>
    Task<OriginResponse> Update(
        string id,
        OriginUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Note:** This API is currently in beta.   Returns an array of all configured
    /// origins for the current account.
    /// </summary>
    Task<List<OriginResponse>> List(
        OriginListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Note:** This API is currently in beta.   Permanently removes the origin
    /// identified by `id`. If the origin is in use by any URL‑endpoints, the API will
    /// return an error.
    /// </summary>
    Task Delete(OriginDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(OriginDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        OriginDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Note:** This API is currently in beta.   Retrieves the origin identified by
    /// `id`.
    /// </summary>
    Task<OriginResponse> Get(
        OriginGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(OriginGetParams, CancellationToken)"/>
    Task<OriginResponse> Get(
        string id,
        OriginGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IOriginService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IOriginServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOriginServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/accounts/origins</c>, but is otherwise the
    /// same as <see cref="IOriginService.Create(OriginCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OriginResponse>> Create(
        OriginCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/accounts/origins/{id}</c>, but is otherwise the
    /// same as <see cref="IOriginService.Update(OriginUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OriginResponse>> Update(
        OriginUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(OriginUpdateParams, CancellationToken)"/>
    Task<HttpResponse<OriginResponse>> Update(
        string id,
        OriginUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/accounts/origins</c>, but is otherwise the
    /// same as <see cref="IOriginService.List(OriginListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<OriginResponse>>> List(
        OriginListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/accounts/origins/{id}</c>, but is otherwise the
    /// same as <see cref="IOriginService.Delete(OriginDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        OriginDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(OriginDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        OriginDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/accounts/origins/{id}</c>, but is otherwise the
    /// same as <see cref="IOriginService.Get(OriginGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OriginResponse>> Get(
        OriginGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(OriginGetParams, CancellationToken)"/>
    Task<HttpResponse<OriginResponse>> Get(
        string id,
        OriginGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
