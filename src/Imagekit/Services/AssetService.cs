using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Assets;

namespace Imagekit.Services;

/// <inheritdoc/>
public sealed class AssetService : IAssetService
{
    readonly Lazy<IAssetServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAssetServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public IAssetService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AssetService(this._client.WithOptions(modifier));
    }

    public AssetService(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AssetServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<AssetListResponse>> List(
        AssetListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AssetServiceWithRawResponse : IAssetServiceWithRawResponse
{
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAssetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AssetServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AssetServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<AssetListResponse>>> List(
        AssetListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AssetListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var assets = await response
                    .Deserialize<List<AssetListResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in assets)
                    {
                        item.Validate();
                    }
                }
                return assets;
            }
        );
    }
}
