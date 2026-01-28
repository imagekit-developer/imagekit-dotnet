using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.CustomMetadataFields;

namespace Imagekit.Services.CustomMetadataFields;

public sealed class CustomMetadataFieldService : ICustomMetadataFieldService
{
    readonly IImageKitClient _client;

    public CustomMetadataFieldService(IImageKitClient client)
    {
        _client = client;
    }

    public async Task<CustomMetadataField> Create(CustomMetadataFieldCreateParams parameters)
    {
        HttpRequest<CustomMetadataFieldCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var customMetadataField = await response
            .Deserialize<CustomMetadataField>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customMetadataField.Validate();
        }
        return customMetadataField;
    }

    public async Task<CustomMetadataField> Update(CustomMetadataFieldUpdateParams parameters)
    {
        HttpRequest<CustomMetadataFieldUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var customMetadataField = await response
            .Deserialize<CustomMetadataField>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customMetadataField.Validate();
        }
        return customMetadataField;
    }

    public async Task<List<CustomMetadataField>> List(
        CustomMetadataFieldListParams? parameters = null
    )
    {
        parameters ??= new();

        HttpRequest<CustomMetadataFieldListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var customMetadataFields = await response
            .Deserialize<List<CustomMetadataField>>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            foreach (var item in customMetadataFields)
            {
                item.Validate();
            }
        }
        return customMetadataFields;
    }

    public async Task<CustomMetadataFieldDeleteResponse> Delete(
        CustomMetadataFieldDeleteParams parameters
    )
    {
        HttpRequest<CustomMetadataFieldDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var customMetadataField = await response
            .Deserialize<CustomMetadataFieldDeleteResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customMetadataField.Validate();
        }
        return customMetadataField;
    }
}
