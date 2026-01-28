using System.Net.Http;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Files.Metadata;
using Files = Imagekit.Models.Files;

namespace Imagekit.Services.Files.Metadata;

public sealed class MetadataService : IMetadataService
{
    readonly IImageKitClient _client;

    public MetadataService(IImageKitClient client)
    {
        _client = client;
    }

    public async Task<Files::Metadata> Get(MetadataGetParams parameters)
    {
        HttpRequest<MetadataGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var metadata = await response.Deserialize<Files::Metadata>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            metadata.Validate();
        }
        return metadata;
    }

    public async Task<Files::Metadata> GetFromURL(MetadataGetFromURLParams parameters)
    {
        HttpRequest<MetadataGetFromURLParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var metadata = await response.Deserialize<Files::Metadata>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            metadata.Validate();
        }
        return metadata;
    }
}
