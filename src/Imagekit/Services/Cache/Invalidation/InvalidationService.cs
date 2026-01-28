using System.Net.Http;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Cache.Invalidation;

namespace Imagekit.Services.Cache.Invalidation;

public sealed class InvalidationService : IInvalidationService
{
    readonly IImageKitClient _client;

    public InvalidationService(IImageKitClient client)
    {
        _client = client;
    }

    public async Task<InvalidationCreateResponse> Create(InvalidationCreateParams parameters)
    {
        HttpRequest<InvalidationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var invalidation = await response
            .Deserialize<InvalidationCreateResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invalidation.Validate();
        }
        return invalidation;
    }

    public async Task<InvalidationGetResponse> Get(InvalidationGetParams parameters)
    {
        HttpRequest<InvalidationGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var invalidation = await response
            .Deserialize<InvalidationGetResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invalidation.Validate();
        }
        return invalidation;
    }
}
