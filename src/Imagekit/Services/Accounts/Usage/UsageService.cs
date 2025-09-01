using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Imagekit.Models.Accounts.Usage;

namespace Imagekit.Services.Accounts.Usage;

public sealed class UsageService : IUsageService
{
    readonly IImageKitClient _client;

    public UsageService(IImageKitClient client)
    {
        _client = client;
    }

    public async Task<UsageGetResponse> Get(UsageGetParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<UsageGetResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
