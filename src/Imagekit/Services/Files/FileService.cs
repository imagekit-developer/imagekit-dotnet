using System;
using System.Net.Http;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Files;
using Imagekit.Services.Files.Bulk;
using Imagekit.Services.Files.Metadata;
using Imagekit.Services.Files.Versions;

namespace Imagekit.Services.Files;

public sealed class FileService : IFileService
{
    readonly IImageKitClient _client;

    public FileService(IImageKitClient client)
    {
        _client = client;
        _bulk = new(() => new BulkService(client));
        _versions = new(() => new VersionService(client));
        _metadata = new(() => new MetadataService(client));
    }

    readonly Lazy<IBulkService> _bulk;
    public IBulkService Bulk
    {
        get { return _bulk.Value; }
    }

    readonly Lazy<IVersionService> _versions;
    public IVersionService Versions
    {
        get { return _versions.Value; }
    }

    readonly Lazy<IMetadataService> _metadata;
    public IMetadataService Metadata
    {
        get { return _metadata.Value; }
    }

    public async Task<FileUpdateResponse> Update(FileUpdateParams parameters)
    {
        HttpRequest<FileUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var file = await response.Deserialize<FileUpdateResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            file.Validate();
        }
        return file;
    }

    public async Task Delete(FileDeleteParams parameters)
    {
        HttpRequest<FileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task<FileCopyResponse> Copy(FileCopyParams parameters)
    {
        HttpRequest<FileCopyParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<FileCopyResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<File> Get(FileGetParams parameters)
    {
        HttpRequest<FileGetParams> request = new() { Method = HttpMethod.Get, Params = parameters };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var file = await response.Deserialize<File>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            file.Validate();
        }
        return file;
    }

    public async Task<FileMoveResponse> Move(FileMoveParams parameters)
    {
        HttpRequest<FileMoveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<FileMoveResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<FileRenameResponse> Rename(FileRenameParams parameters)
    {
        HttpRequest<FileRenameParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<FileRenameResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
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
