using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.Accounts.Origins;

namespace ImagekitDiversion.Services.Accounts;

/// <inheritdoc/>
public sealed class OriginService : IOriginService
{
    readonly Lazy<IOriginServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOriginServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImagekitDiversionClient _client;

    /// <inheritdoc/>
    public IOriginService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OriginService(this._client.WithOptions(modifier));
    }

    public OriginService(IImagekitDiversionClient client)
    {
        _client = client;

        _withRawResponse = new(() => new OriginServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Origin> Create(
        OriginCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Origin> Retrieve(
        OriginRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Origin> Retrieve(
        string id,
        OriginRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Origin> Update(
        OriginUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Origin> Update(
        string id,
        OriginUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<Origin>> List(
        OriginListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(OriginDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        OriginDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class OriginServiceWithRawResponse : IOriginServiceWithRawResponse
{
    readonly IImagekitDiversionClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOriginServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OriginServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OriginServiceWithRawResponse(IImagekitDiversionClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Origin>> Create(
        OriginCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<OriginCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var origin = await response.Deserialize<Origin>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    origin.Validate();
                }
                return origin;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Origin>> Retrieve(
        OriginRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImagekitDiversionInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<OriginRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var origin = await response.Deserialize<Origin>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    origin.Validate();
                }
                return origin;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Origin>> Retrieve(
        string id,
        OriginRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Origin>> Update(
        OriginUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImagekitDiversionInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<OriginUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var origin = await response.Deserialize<Origin>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    origin.Validate();
                }
                return origin;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Origin>> Update(
        string id,
        OriginUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<Origin>>> List(
        OriginListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<OriginListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var origins = await response.Deserialize<List<Origin>>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in origins)
                    {
                        item.Validate();
                    }
                }
                return origins;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        OriginDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImagekitDiversionInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<OriginDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        OriginDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }
}
