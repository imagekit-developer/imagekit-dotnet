using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Files;
using Imagekit.Models.Files.Versions;

namespace Imagekit.Services.Files.Versions;

public sealed class VersionService : IVersionService
{
    readonly IImageKitClient _client;

    public VersionService(IImageKitClient client)
    {
        _client = client;
    }

    public async Task<List<File>> List(VersionListParams parameters)
    {
        HttpRequest<VersionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var files = await response.Deserialize<List<File>>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            foreach (var item in files)
            {
                item.Validate();
            }
        }
        return files;
    }

    public async Task<VersionDeleteResponse> Delete(VersionDeleteParams parameters)
    {
        HttpRequest<VersionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var version = await response.Deserialize<VersionDeleteResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            version.Validate();
        }
        return version;
    }

    public async Task<File> Get(VersionGetParams parameters)
    {
        HttpRequest<VersionGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var file = await response.Deserialize<File>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            file.Validate();
        }
        return file;
    }

    public async Task<File> Restore(VersionRestoreParams parameters)
    {
        HttpRequest<VersionRestoreParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var file = await response.Deserialize<File>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            file.Validate();
        }
        return file;
    }
}
