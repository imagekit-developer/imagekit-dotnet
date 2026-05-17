using System;
using Imagekit.Core;
using Imagekit.Services.Accounts;

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
        _usage = new(() => new UsageService(client));
        _origins = new(() => new OriginService(client));
        _urlEndpoints = new(() => new UrlEndpointService(client));
    }

    readonly Lazy<IUsageService> _usage;
    public IUsageService Usage
    {
        get { return _usage.Value; }
    }

    readonly Lazy<IOriginService> _origins;
    public IOriginService Origins
    {
        get { return _origins.Value; }
    }

    readonly Lazy<IUrlEndpointService> _urlEndpoints;
    public IUrlEndpointService UrlEndpoints
    {
        get { return _urlEndpoints.Value; }
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

        _usage = new(() => new UsageServiceWithRawResponse(client));
        _origins = new(() => new OriginServiceWithRawResponse(client));
        _urlEndpoints = new(() => new UrlEndpointServiceWithRawResponse(client));
    }

    readonly Lazy<IUsageServiceWithRawResponse> _usage;
    public IUsageServiceWithRawResponse Usage
    {
        get { return _usage.Value; }
    }

    readonly Lazy<IOriginServiceWithRawResponse> _origins;
    public IOriginServiceWithRawResponse Origins
    {
        get { return _origins.Value; }
    }

    readonly Lazy<IUrlEndpointServiceWithRawResponse> _urlEndpoints;
    public IUrlEndpointServiceWithRawResponse UrlEndpoints
    {
        get { return _urlEndpoints.Value; }
    }
}
