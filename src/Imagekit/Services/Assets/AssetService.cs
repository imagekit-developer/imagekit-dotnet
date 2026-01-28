using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Assets;

namespace Imagekit.Services.Assets;

public sealed class AssetService : IAssetService
{
    readonly IImageKitClient _client;

    public AssetService(IImageKitClient client)
    {
        _client = client;
    }

    public async Task<List<AssetListResponse>> List(AssetListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<AssetListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var assets = await response.Deserialize<List<AssetListResponse>>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            foreach (var item in assets)
            {
                item.Validate();
            }
        }
        return assets;
    }
}
