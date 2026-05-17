using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.Accounts.UrlEndpoints;

namespace ImagekitDiversion.Services.Accounts;

/// <inheritdoc/>
public sealed class UrlEndpointService : IUrlEndpointService
{
    readonly Lazy<IUrlEndpointServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUrlEndpointServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImagekitDiversionClient _client;

    /// <inheritdoc/>
    public IUrlEndpointService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UrlEndpointService(this._client.WithOptions(modifier));
    }

    public UrlEndpointService(IImagekitDiversionClient client)
    {
        _client = client;

        _withRawResponse = new(() => new UrlEndpointServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<UrlEndpoint> Create(
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
    public async Task<UrlEndpoint> Retrieve(
        UrlEndpointRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UrlEndpoint> Retrieve(
        string id,
        UrlEndpointRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UrlEndpoint> Update(
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
    public Task<UrlEndpoint> Update(
        string id,
        UrlEndpointUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<UrlEndpoint>> List(
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
}

/// <inheritdoc/>
public sealed class UrlEndpointServiceWithRawResponse : IUrlEndpointServiceWithRawResponse
{
    readonly IImagekitDiversionClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUrlEndpointServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new UrlEndpointServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UrlEndpointServiceWithRawResponse(IImagekitDiversionClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UrlEndpoint>> Create(
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
                var urlEndpoint = await response
                    .Deserialize<UrlEndpoint>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    urlEndpoint.Validate();
                }
                return urlEndpoint;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UrlEndpoint>> Retrieve(
        UrlEndpointRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImagekitDiversionInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<UrlEndpointRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var urlEndpoint = await response
                    .Deserialize<UrlEndpoint>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    urlEndpoint.Validate();
                }
                return urlEndpoint;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UrlEndpoint>> Retrieve(
        string id,
        UrlEndpointRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UrlEndpoint>> Update(
        UrlEndpointUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImagekitDiversionInvalidDataException("'parameters.ID' cannot be null");
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
                var urlEndpoint = await response
                    .Deserialize<UrlEndpoint>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    urlEndpoint.Validate();
                }
                return urlEndpoint;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UrlEndpoint>> Update(
        string id,
        UrlEndpointUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<UrlEndpoint>>> List(
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
                var urlEndpoints = await response
                    .Deserialize<List<UrlEndpoint>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in urlEndpoints)
                    {
                        item.Validate();
                    }
                }
                return urlEndpoints;
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
            throw new ImagekitDiversionInvalidDataException("'parameters.ID' cannot be null");
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
}
