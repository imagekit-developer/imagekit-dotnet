using System;
using ImageKit.Core;
using ImageKit.Services.Cache;

namespace ImageKit.Services;

/// <inheritdoc/>
public sealed class CacheService : ICacheService
{
    readonly Lazy<ICacheServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICacheServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public ICacheService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CacheService(this._client.WithOptions(modifier));
    }

    public CacheService(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CacheServiceWithRawResponse(client.WithRawResponse));
        _invalidation = new(() => new InvalidationService(client));
    }

    readonly Lazy<IInvalidationService> _invalidation;
    public IInvalidationService Invalidation
    {
        get { return _invalidation.Value; }
    }
}

/// <inheritdoc/>
public sealed class CacheServiceWithRawResponse : ICacheServiceWithRawResponse
{
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICacheServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CacheServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CacheServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;

        _invalidation = new(() => new InvalidationServiceWithRawResponse(client));
    }

    readonly Lazy<IInvalidationServiceWithRawResponse> _invalidation;
    public IInvalidationServiceWithRawResponse Invalidation
    {
        get { return _invalidation.Value; }
    }
}
