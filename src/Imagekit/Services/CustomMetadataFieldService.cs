using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.CustomMetadataFields;

namespace Imagekit.Services;

/// <inheritdoc/>
public sealed class CustomMetadataFieldService : ICustomMetadataFieldService
{
    readonly Lazy<ICustomMetadataFieldServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICustomMetadataFieldServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public ICustomMetadataFieldService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CustomMetadataFieldService(this._client.WithOptions(modifier));
    }

    public CustomMetadataFieldService(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CustomMetadataFieldServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CustomMetadataField> Create(
        CustomMetadataFieldCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CustomMetadataField> Update(
        CustomMetadataFieldUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomMetadataField> Update(
        string id,
        CustomMetadataFieldUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<CustomMetadataField>> List(
        CustomMetadataFieldListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CustomMetadataFieldDeleteResponse> Delete(
        CustomMetadataFieldDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomMetadataFieldDeleteResponse> Delete(
        string id,
        CustomMetadataFieldDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CustomMetadataFieldServiceWithRawResponse
    : ICustomMetadataFieldServiceWithRawResponse
{
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICustomMetadataFieldServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CustomMetadataFieldServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CustomMetadataFieldServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomMetadataField>> Create(
        CustomMetadataFieldCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CustomMetadataFieldCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customMetadataField = await response
                    .Deserialize<CustomMetadataField>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customMetadataField.Validate();
                }
                return customMetadataField;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomMetadataField>> Update(
        CustomMetadataFieldUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImageKitInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CustomMetadataFieldUpdateParams> request = new()
        {
            Method = ImageKitClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customMetadataField = await response
                    .Deserialize<CustomMetadataField>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customMetadataField.Validate();
                }
                return customMetadataField;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CustomMetadataField>> Update(
        string id,
        CustomMetadataFieldUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<CustomMetadataField>>> List(
        CustomMetadataFieldListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CustomMetadataFieldListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customMetadataFields = await response
                    .Deserialize<List<CustomMetadataField>>(token)
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
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomMetadataFieldDeleteResponse>> Delete(
        CustomMetadataFieldDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImageKitInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CustomMetadataFieldDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customMetadataField = await response
                    .Deserialize<CustomMetadataFieldDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customMetadataField.Validate();
                }
                return customMetadataField;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CustomMetadataFieldDeleteResponse>> Delete(
        string id,
        CustomMetadataFieldDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }
}
