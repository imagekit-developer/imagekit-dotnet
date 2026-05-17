using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.SavedExtensions;
using Models = Imagekit.Models;

namespace Imagekit.Services;

/// <inheritdoc/>
public sealed class SavedExtensionService : ISavedExtensionService
{
    readonly Lazy<ISavedExtensionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISavedExtensionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public ISavedExtensionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SavedExtensionService(this._client.WithOptions(modifier));
    }

    public SavedExtensionService(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new SavedExtensionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<Models::SharedSavedExtension> Create(
        SavedExtensionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Models::SharedSavedExtension> Update(
        SavedExtensionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::SharedSavedExtension> Update(
        string id,
        SavedExtensionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<Models::SharedSavedExtension>> List(
        SavedExtensionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        SavedExtensionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        SavedExtensionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Models::SharedSavedExtension> Get(
        SavedExtensionGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::SharedSavedExtension> Get(
        string id,
        SavedExtensionGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SavedExtensionServiceWithRawResponse : ISavedExtensionServiceWithRawResponse
{
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISavedExtensionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SavedExtensionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SavedExtensionServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::SharedSavedExtension>> Create(
        SavedExtensionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SavedExtensionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var savedExtension = await response
                    .Deserialize<Models::SharedSavedExtension>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    savedExtension.Validate();
                }
                return savedExtension;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::SharedSavedExtension>> Update(
        SavedExtensionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImageKitInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SavedExtensionUpdateParams> request = new()
        {
            Method = ImageKitClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var savedExtension = await response
                    .Deserialize<Models::SharedSavedExtension>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    savedExtension.Validate();
                }
                return savedExtension;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::SharedSavedExtension>> Update(
        string id,
        SavedExtensionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<Models::SharedSavedExtension>>> List(
        SavedExtensionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SavedExtensionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var savedExtensions = await response
                    .Deserialize<List<Models::SharedSavedExtension>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in savedExtensions)
                    {
                        item.Validate();
                    }
                }
                return savedExtensions;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        SavedExtensionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImageKitInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SavedExtensionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        SavedExtensionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::SharedSavedExtension>> Get(
        SavedExtensionGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImageKitInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SavedExtensionGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var savedExtension = await response
                    .Deserialize<Models::SharedSavedExtension>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    savedExtension.Validate();
                }
                return savedExtension;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::SharedSavedExtension>> Get(
        string id,
        SavedExtensionGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { ID = id }, cancellationToken);
    }
}
