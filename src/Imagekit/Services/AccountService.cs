using System;
using Imagekit.Core;
using Accounts = Imagekit.Services.Accounts;

namespace Imagekit.Services;

/// <inheritdoc/>
public sealed class AccountService : IAccountService
{
    readonly Lazy<IAccountServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccountServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public IAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountService(this._client.WithOptions(modifier));
    }

    public AccountService(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AccountServiceWithRawResponse(client.WithRawResponse));
        _usage = new(() => new Accounts::UsageService(client));
        _usageAnalytics = new(() => new Accounts::UsageAnalyticsService(client));
        _origins = new(() => new Accounts::OriginService(client));
        _urlEndpoints = new(() => new Accounts::UrlEndpointService(client));
        _webhooks = new(() => new Accounts::WebhookService(client));
    }

    readonly Lazy<Accounts::IUsageService> _usage;
    public Accounts::IUsageService Usage
    {
        get { return _usage.Value; }
    }

    readonly Lazy<Accounts::IUsageAnalyticsService> _usageAnalytics;
    public Accounts::IUsageAnalyticsService UsageAnalytics
    {
        get { return _usageAnalytics.Value; }
    }

    readonly Lazy<Accounts::IOriginService> _origins;
    public Accounts::IOriginService Origins
    {
        get { return _origins.Value; }
    }

    readonly Lazy<Accounts::IUrlEndpointService> _urlEndpoints;
    public Accounts::IUrlEndpointService UrlEndpoints
    {
        get { return _urlEndpoints.Value; }
    }

    readonly Lazy<Accounts::IWebhookService> _webhooks;
    public Accounts::IWebhookService Webhooks
    {
        get { return _webhooks.Value; }
    }
}

/// <inheritdoc/>
public sealed class AccountServiceWithRawResponse : IAccountServiceWithRawResponse
{
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccountServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AccountServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;

        _usage = new(() => new Accounts::UsageServiceWithRawResponse(client));
        _usageAnalytics = new(() => new Accounts::UsageAnalyticsServiceWithRawResponse(client));
        _origins = new(() => new Accounts::OriginServiceWithRawResponse(client));
        _urlEndpoints = new(() => new Accounts::UrlEndpointServiceWithRawResponse(client));
        _webhooks = new(() => new Accounts::WebhookServiceWithRawResponse(client));
    }

    readonly Lazy<Accounts::IUsageServiceWithRawResponse> _usage;
    public Accounts::IUsageServiceWithRawResponse Usage
    {
        get { return _usage.Value; }
    }

    readonly Lazy<Accounts::IUsageAnalyticsServiceWithRawResponse> _usageAnalytics;
    public Accounts::IUsageAnalyticsServiceWithRawResponse UsageAnalytics
    {
        get { return _usageAnalytics.Value; }
    }

    readonly Lazy<Accounts::IOriginServiceWithRawResponse> _origins;
    public Accounts::IOriginServiceWithRawResponse Origins
    {
        get { return _origins.Value; }
    }

    readonly Lazy<Accounts::IUrlEndpointServiceWithRawResponse> _urlEndpoints;
    public Accounts::IUrlEndpointServiceWithRawResponse UrlEndpoints
    {
        get { return _urlEndpoints.Value; }
    }

    readonly Lazy<Accounts::IWebhookServiceWithRawResponse> _webhooks;
    public Accounts::IWebhookServiceWithRawResponse Webhooks
    {
        get { return _webhooks.Value; }
    }
}
