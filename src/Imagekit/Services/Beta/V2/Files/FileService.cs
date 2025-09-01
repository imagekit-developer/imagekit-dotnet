using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Imagekit.Models.Beta.V2.Files;

namespace Imagekit.Services.Beta.V2.Files;

public sealed class FileService : IFileService
{
    readonly IImageKitClient _client;

    public FileService(IImageKitClient client)
    {
        _client = client;
    }

    public async Task<FileUploadResponse> Upload(FileUploadParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Post, parameters.Url(this._client))
        {
            Content = parameters.BodyContent(),
        };
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

        return JsonSerializer.Deserialize<FileUploadResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
