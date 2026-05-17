using System;
using ImagekitDiversion.Core;
using V1 = ImagekitDiversion.Services.Api.V1;

namespace ImagekitDiversion.Services.Api;

/// <inheritdoc/>
public sealed class V1Service : IV1Service
{
    readonly Lazy<IV1ServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IV1ServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImagekitDiversionClient _client;

    /// <inheritdoc/>
    public IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V1Service(this._client.WithOptions(modifier));
    }

    public V1Service(IImagekitDiversionClient client)
    {
        _client = client;

        _withRawResponse = new(() => new V1ServiceWithRawResponse(client.WithRawResponse));
        _files = new(() => new V1::FileService(client));
    }

    readonly Lazy<V1::IFileService> _files;
    public V1::IFileService Files
    {
        get { return _files.Value; }
    }
}

/// <inheritdoc/>
public sealed class V1ServiceWithRawResponse : IV1ServiceWithRawResponse
{
    readonly IImagekitDiversionClientWithRawResponse _client;

    /// <inheritdoc/>
    public IV1ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V1ServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public V1ServiceWithRawResponse(IImagekitDiversionClientWithRawResponse client)
    {
        _client = client;

        _files = new(() => new V1::FileServiceWithRawResponse(client));
    }

    readonly Lazy<V1::IFileServiceWithRawResponse> _files;
    public V1::IFileServiceWithRawResponse Files
    {
        get { return _files.Value; }
    }
}
