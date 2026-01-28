using System;
using System.Net.Http;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Folders;
using Imagekit.Services.Folders.Job;

namespace Imagekit.Services.Folders;

public sealed class FolderService : IFolderService
{
    readonly IImageKitClient _client;

    public FolderService(IImageKitClient client)
    {
        _client = client;
        _job = new(() => new JobService(client));
    }

    readonly Lazy<IJobService> _job;
    public IJobService Job
    {
        get { return _job.Value; }
    }

    public async Task<FolderCreateResponse> Create(FolderCreateParams parameters)
    {
        HttpRequest<FolderCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var folder = await response.Deserialize<FolderCreateResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            folder.Validate();
        }
        return folder;
    }

    public async Task<FolderDeleteResponse> Delete(FolderDeleteParams parameters)
    {
        HttpRequest<FolderDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var folder = await response.Deserialize<FolderDeleteResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            folder.Validate();
        }
        return folder;
    }

    public async Task<FolderCopyResponse> Copy(FolderCopyParams parameters)
    {
        HttpRequest<FolderCopyParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<FolderCopyResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<FolderMoveResponse> Move(FolderMoveParams parameters)
    {
        HttpRequest<FolderMoveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<FolderMoveResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<FolderRenameResponse> Rename(FolderRenameParams parameters)
    {
        HttpRequest<FolderRenameParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<FolderRenameResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
