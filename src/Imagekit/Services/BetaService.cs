using System;
using Imagekit.Core;
using Imagekit.Services.Beta;

namespace Imagekit.Services;

/// <inheritdoc/>
public sealed class BetaService : IBetaService
{
    readonly Lazy<IBetaServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBetaServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public IBetaService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BetaService(this._client.WithOptions(modifier));
    }

    public BetaService(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BetaServiceWithRawResponse(client.WithRawResponse));
        _v2 = new(() => new V2Service(client));
    }

    readonly Lazy<IV2Service> _v2;
    public IV2Service V2
    {
        get { return _v2.Value; }
    }
}

/// <inheritdoc/>
public sealed class BetaServiceWithRawResponse : IBetaServiceWithRawResponse
{
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBetaServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BetaServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BetaServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;

        _v2 = new(() => new V2ServiceWithRawResponse(client));
    }

    readonly Lazy<IV2ServiceWithRawResponse> _v2;
    public IV2ServiceWithRawResponse V2
    {
        get { return _v2.Value; }
    }
}
