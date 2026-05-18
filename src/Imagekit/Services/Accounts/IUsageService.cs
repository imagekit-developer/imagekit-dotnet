using System;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Accounts.Usage;

namespace Imagekit.Services.Accounts;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IUsageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUsageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the account usage information between two dates. Note that the API response
    /// includes data from the start date while excluding data from the end date. In
    /// other words, the data covers the period starting from the specified start date
    /// up to, but not including, the end date.
    /// </summary>
    Task<UsageGetResponse> Get(
        UsageGetParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUsageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUsageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/accounts/usage</c>, but is otherwise the
    /// same as <see cref="IUsageService.Get(UsageGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UsageGetResponse>> Get(
        UsageGetParams parameters,
        CancellationToken cancellationToken = default
    );
}
