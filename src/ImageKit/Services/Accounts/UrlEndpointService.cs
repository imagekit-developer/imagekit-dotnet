using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ImageKit.Core;
using ImageKit.Exceptions;
using ImageKit.Models.Accounts.UrlEndpoints;

namespace ImageKit.Services.Accounts;

/// <inheritdoc/>
public sealed class UrlEndpointService : IUrlEndpointService
{
    readonly Lazy<IUrlEndpointServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUrlEndpointServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public IUrlEndpointService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UrlEndpointService(this._client.WithOptions(modifier));
    }

    public UrlEndpointService(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() => new UrlEndpointServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<UrlEndpointResponse> Create(
        UrlEndpointCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<UrlEndpointResponse> Update(
        UrlEndpointUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UrlEndpointResponse> Update(
        string id,
        UrlEndpointUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<UrlEndpointResponse>> List(
        UrlEndpointListParams? parameters = null,
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
        UrlEndpointDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        UrlEndpointDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<UrlEndpointResponse> Get(
        UrlEndpointGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UrlEndpointResponse> Get(
        string id,
        UrlEndpointGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class UrlEndpointServiceWithRawResponse : IUrlEndpointServiceWithRawResponse
{
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUrlEndpointServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new UrlEndpointServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UrlEndpointServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UrlEndpointResponse>> Create(
        UrlEndpointCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UrlEndpointCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var urlEndpointResponse = await response
                    .Deserialize<UrlEndpointResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    urlEndpointResponse.Validate();
                }
                return urlEndpointResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UrlEndpointResponse>> Update(
        UrlEndpointUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImageKitInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<UrlEndpointUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var urlEndpointResponse = await response
                    .Deserialize<UrlEndpointResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    urlEndpointResponse.Validate();
                }
                return urlEndpointResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UrlEndpointResponse>> Update(
        string id,
        UrlEndpointUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<UrlEndpointResponse>>> List(
        UrlEndpointListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UrlEndpointListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var urlEndpointResponses = await response
                    .Deserialize<List<UrlEndpointResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in urlEndpointResponses)
                    {
                        item.Validate();
                    }
                }
                return urlEndpointResponses;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        UrlEndpointDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImageKitInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<UrlEndpointDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        UrlEndpointDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UrlEndpointResponse>> Get(
        UrlEndpointGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImageKitInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<UrlEndpointGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var urlEndpointResponse = await response
                    .Deserialize<UrlEndpointResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    urlEndpointResponse.Validate();
                }
                return urlEndpointResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UrlEndpointResponse>> Get(
        string id,
        UrlEndpointGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { ID = id }, cancellationToken);
    }
}
