using System.Net.Http;
using System.Threading.Tasks;
using Imagekit.Core;
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
        HttpRequest<FileUploadParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<FileUploadResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
