using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.SavedExtensions;

namespace ImagekitDiversion.Services;

/// <inheritdoc/>
public sealed class SavedExtensionService : ISavedExtensionService
{
    readonly Lazy<ISavedExtensionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISavedExtensionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImagekitDiversionClient _client;

    /// <inheritdoc/>
    public ISavedExtensionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SavedExtensionService(this._client.WithOptions(modifier));
    }

    public SavedExtensionService(IImagekitDiversionClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new SavedExtensionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<SavedExtension> Create(
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
    public async Task<SavedExtension> Retrieve(
        SavedExtensionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SavedExtension> Retrieve(
        string id,
        SavedExtensionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SavedExtension> Update(
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
    public Task<SavedExtension> Update(
        string id,
        SavedExtensionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<SavedExtension>> List(
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
}

/// <inheritdoc/>
public sealed class SavedExtensionServiceWithRawResponse : ISavedExtensionServiceWithRawResponse
{
    readonly IImagekitDiversionClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISavedExtensionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SavedExtensionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SavedExtensionServiceWithRawResponse(IImagekitDiversionClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SavedExtension>> Create(
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
                    .Deserialize<SavedExtension>(token)
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
    public async Task<HttpResponse<SavedExtension>> Retrieve(
        SavedExtensionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImagekitDiversionInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SavedExtensionRetrieveParams> request = new()
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
                    .Deserialize<SavedExtension>(token)
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
    public Task<HttpResponse<SavedExtension>> Retrieve(
        string id,
        SavedExtensionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SavedExtension>> Update(
        SavedExtensionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImagekitDiversionInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SavedExtensionUpdateParams> request = new()
        {
            Method = ImagekitDiversionClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var savedExtension = await response
                    .Deserialize<SavedExtension>(token)
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
    public Task<HttpResponse<SavedExtension>> Update(
        string id,
        SavedExtensionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<SavedExtension>>> List(
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
                    .Deserialize<List<SavedExtension>>(token)
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
            throw new ImagekitDiversionInvalidDataException("'parameters.ID' cannot be null");
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
}
