using System;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Accounts.UsageAnalytics;

namespace Imagekit.Services.Accounts;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IUsageAnalyticsService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUsageAnalyticsServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageAnalyticsService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// **Note:** This API is currently in beta.
    ///
    /// <para>Get the account analytics data between two dates. The response covers the
    /// period from the start date to the end date, both dates inclusive. Both dates are
    /// interpreted as UTC calendar days.</para>
    ///
    /// <para>The returned data is scoped to the requesting account only. Unlike
    /// `/v1/accounts/usage`, an agency account's analytics are not aggregated across
    /// its child accounts.</para>
    ///
    /// <para>The response is cached for 5 minutes per account and date range. Use
    /// `generatedAt` to check how fresh the returned data is. </para>
    /// </summary>
    Task<UsageAnalyticsResponse> Get(
        UsageAnalyticsGetParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUsageAnalyticsService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUsageAnalyticsServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageAnalyticsServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/accounts/usage-analytics</c>, but is otherwise the
    /// same as <see cref="IUsageAnalyticsService.Get(UsageAnalyticsGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UsageAnalyticsResponse>> Get(
        UsageAnalyticsGetParams parameters,
        CancellationToken cancellationToken = default
    );
}
