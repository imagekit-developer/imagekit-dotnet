using System;
using Imagekit.Core;
using V2 = Imagekit.Services.Beta.V2;

namespace Imagekit.Services.Beta;

/// <inheritdoc/>
public sealed class V2Service : IV2Service
{
    readonly Lazy<IV2ServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IV2ServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public IV2Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V2Service(this._client.WithOptions(modifier));
    }

    public V2Service(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() => new V2ServiceWithRawResponse(client.WithRawResponse));
        _files = new(() => new V2::FileService(client));
    }

    readonly Lazy<V2::IFileService> _files;
    public V2::IFileService Files
    {
        get { return _files.Value; }
    }
}

/// <inheritdoc/>
public sealed class V2ServiceWithRawResponse : IV2ServiceWithRawResponse
{
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public IV2ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V2ServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public V2ServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;

        _files = new(() => new V2::FileServiceWithRawResponse(client));
    }

    readonly Lazy<V2::IFileServiceWithRawResponse> _files;
    public V2::IFileServiceWithRawResponse Files
    {
        get { return _files.Value; }
    }
}
