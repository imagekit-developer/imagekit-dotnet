using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Accounts.URLEndpoints;

namespace Imagekit.Services.Accounts.URLEndpoints;

public sealed class URLEndpointService : IURLEndpointService
{
    readonly IImageKitClient _client;

    public URLEndpointService(IImageKitClient client)
    {
        _client = client;
    }

    public async Task<URLEndpointResponse> Create(URLEndpointCreateParams parameters)
    {
        HttpRequest<URLEndpointCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var urlEndpointResponse = await response
            .Deserialize<URLEndpointResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            urlEndpointResponse.Validate();
        }
        return urlEndpointResponse;
    }

    public async Task<URLEndpointResponse> Update(URLEndpointUpdateParams parameters)
    {
        HttpRequest<URLEndpointUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var urlEndpointResponse = await response
            .Deserialize<URLEndpointResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            urlEndpointResponse.Validate();
        }
        return urlEndpointResponse;
    }

    public async Task<List<URLEndpointResponse>> List(URLEndpointListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<URLEndpointListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var urlEndpointResponses = await response
            .Deserialize<List<URLEndpointResponse>>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            foreach (var item in urlEndpointResponses)
            {
                item.Validate();
            }
        }
        return urlEndpointResponses;
    }

    public async Task Delete(URLEndpointDeleteParams parameters)
    {
        HttpRequest<URLEndpointDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task<URLEndpointResponse> Get(URLEndpointGetParams parameters)
    {
        HttpRequest<URLEndpointGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var urlEndpointResponse = await response
            .Deserialize<URLEndpointResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            urlEndpointResponse.Validate();
        }
        return urlEndpointResponse;
    }
}
