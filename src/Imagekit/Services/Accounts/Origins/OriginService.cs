using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Accounts.Origins;

namespace Imagekit.Services.Accounts.Origins;

public sealed class OriginService : IOriginService
{
    readonly IImageKitClient _client;

    public OriginService(IImageKitClient client)
    {
        _client = client;
    }

    public async Task<OriginResponse> Create(OriginCreateParams parameters)
    {
        HttpRequest<OriginCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var originResponse = await response.Deserialize<OriginResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            originResponse.Validate();
        }
        return originResponse;
    }

    public async Task<OriginResponse> Update(OriginUpdateParams parameters)
    {
        HttpRequest<OriginUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var originResponse = await response.Deserialize<OriginResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            originResponse.Validate();
        }
        return originResponse;
    }

    public async Task<List<OriginResponse>> List(OriginListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<OriginListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var originResponses = await response
            .Deserialize<List<OriginResponse>>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            foreach (var item in originResponses)
            {
                item.Validate();
            }
        }
        return originResponses;
    }

    public async Task Delete(OriginDeleteParams parameters)
    {
        HttpRequest<OriginDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task<OriginResponse> Get(OriginGetParams parameters)
    {
        HttpRequest<OriginGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var originResponse = await response.Deserialize<OriginResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            originResponse.Validate();
        }
        return originResponse;
    }
}
