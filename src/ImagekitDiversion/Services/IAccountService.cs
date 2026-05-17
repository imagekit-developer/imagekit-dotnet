using System;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Accounts;
using ImagekitDiversion.Services.Accounts;

namespace ImagekitDiversion.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAccountServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IOriginService Origins { get; }

    IUrlEndpointService UrlEndpoints { get; }

    /// <summary>
    /// Get the account usage information between two dates. Note that the API response
    /// includes data from the start date while excluding data from the end date. In
    /// other words, the data covers the period starting from the specified start date
    /// up to, but not including, the end date.
    /// </summary>
    Task<AccountGetUsageResponse> GetUsage(
        AccountGetUsageParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAccountService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAccountServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IOriginServiceWithRawResponse Origins { get; }

    IUrlEndpointServiceWithRawResponse UrlEndpoints { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/accounts/usage</c>, but is otherwise the
    /// same as <see cref="IAccountService.GetUsage(AccountGetUsageParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountGetUsageResponse>> GetUsage(
        AccountGetUsageParams parameters,
        CancellationToken cancellationToken = default
    );
}
