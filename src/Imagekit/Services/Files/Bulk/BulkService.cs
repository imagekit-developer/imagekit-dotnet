using System.Net.Http;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Files.Bulk;

namespace Imagekit.Services.Files.Bulk;

public sealed class BulkService : IBulkService
{
    readonly IImageKitClient _client;

    public BulkService(IImageKitClient client)
    {
        _client = client;
    }

    public async Task<BulkDeleteResponse> Delete(BulkDeleteParams parameters)
    {
        HttpRequest<BulkDeleteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var bulk = await response.Deserialize<BulkDeleteResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            bulk.Validate();
        }
        return bulk;
    }

    public async Task<BulkAddTagsResponse> AddTags(BulkAddTagsParams parameters)
    {
        HttpRequest<BulkAddTagsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<BulkAddTagsResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<BulkRemoveAITagsResponse> RemoveAITags(BulkRemoveAITagsParams parameters)
    {
        HttpRequest<BulkRemoveAITagsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<BulkRemoveAITagsResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<BulkRemoveTagsResponse> RemoveTags(BulkRemoveTagsParams parameters)
    {
        HttpRequest<BulkRemoveTagsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<BulkRemoveTagsResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
