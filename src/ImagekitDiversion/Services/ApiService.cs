using System;
using ImagekitDiversion.Core;
using ImagekitDiversion.Services.Api;

namespace ImagekitDiversion.Services;

/// <inheritdoc/>
public sealed class ApiService : IApiService
{
    readonly Lazy<IApiServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IApiServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImagekitDiversionClient _client;

    /// <inheritdoc/>
    public IApiService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ApiService(this._client.WithOptions(modifier));
    }

    public ApiService(IImagekitDiversionClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ApiServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
        _v2 = new(() => new V2Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }

    readonly Lazy<IV2Service> _v2;
    public IV2Service V2
    {
        get { return _v2.Value; }
    }
}

/// <inheritdoc/>
public sealed class ApiServiceWithRawResponse : IApiServiceWithRawResponse
{
    readonly IImagekitDiversionClientWithRawResponse _client;

    /// <inheritdoc/>
    public IApiServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ApiServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ApiServiceWithRawResponse(IImagekitDiversionClientWithRawResponse client)
    {
        _client = client;

        _v1 = new(() => new V1ServiceWithRawResponse(client));
        _v2 = new(() => new V2ServiceWithRawResponse(client));
    }

    readonly Lazy<IV1ServiceWithRawResponse> _v1;
    public IV1ServiceWithRawResponse V1
    {
        get { return _v1.Value; }
    }

    readonly Lazy<IV2ServiceWithRawResponse> _v2;
    public IV2ServiceWithRawResponse V2
    {
        get { return _v2.Value; }
    }
}
