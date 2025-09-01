using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Imagekit.Models.Folders.Job;

namespace Imagekit.Services.Folders.Job;

public sealed class JobService : IJobService
{
    readonly IImageKitClient _client;

    public JobService(IImageKitClient client)
    {
        _client = client;
    }

    public async Task<JobGetResponse> Get(JobGetParams parameters)
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

        return JsonSerializer.Deserialize<JobGetResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
