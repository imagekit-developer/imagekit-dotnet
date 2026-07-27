using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Accounts.UsageAnalytics;

namespace Imagekit.Services.Accounts;

/// <inheritdoc/>
public sealed class UsageAnalyticsService : IUsageAnalyticsService
{
    readonly Lazy<IUsageAnalyticsServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUsageAnalyticsServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public IUsageAnalyticsService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UsageAnalyticsService(this._client.WithOptions(modifier));
    }

    public UsageAnalyticsService(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new UsageAnalyticsServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<UsageAnalyticsResponse> Get(
        UsageAnalyticsGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class UsageAnalyticsServiceWithRawResponse : IUsageAnalyticsServiceWithRawResponse
{
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUsageAnalyticsServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new UsageAnalyticsServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UsageAnalyticsServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UsageAnalyticsResponse>> Get(
        UsageAnalyticsGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UsageAnalyticsGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var usageAnalyticsResponse = await response
                    .Deserialize<UsageAnalyticsResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    usageAnalyticsResponse.Validate();
                }
                return usageAnalyticsResponse;
            }
        );
    }
}
