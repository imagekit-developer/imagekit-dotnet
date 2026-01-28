using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ImageKit.Core;
using ImageKit.Exceptions;
using ImageKit.Models.Accounts.Origins;

namespace ImageKit.Services.Accounts;

/// <inheritdoc/>
public sealed class OriginService : IOriginService
{
    readonly Lazy<IOriginServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOriginServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public IOriginService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OriginService(this._client.WithOptions(modifier));
    }

    public OriginService(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() => new OriginServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<OriginResponse> Create(
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
    public async Task<OriginResponse> Update(
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
    public Task<OriginResponse> Update(
        string id,
        OriginUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<OriginResponse>> List(
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

    /// <inheritdoc/>
    public async Task<OriginResponse> Get(
        OriginGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<OriginResponse> Get(
        string id,
        OriginGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class OriginServiceWithRawResponse : IOriginServiceWithRawResponse
{
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOriginServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OriginServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OriginServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OriginResponse>> Create(
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
                var originResponse = await response
                    .Deserialize<OriginResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    originResponse.Validate();
                }
                return originResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OriginResponse>> Update(
        OriginUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImageKitInvalidDataException("'parameters.ID' cannot be null");
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
                var originResponse = await response
                    .Deserialize<OriginResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    originResponse.Validate();
                }
                return originResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<OriginResponse>> Update(
        string id,
        OriginUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<OriginResponse>>> List(
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
                var originResponses = await response
                    .Deserialize<List<OriginResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in originResponses)
                    {
                        item.Validate();
                    }
                }
                return originResponses;
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
            throw new ImageKitInvalidDataException("'parameters.ID' cannot be null");
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

    /// <inheritdoc/>
    public async Task<HttpResponse<OriginResponse>> Get(
        OriginGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImageKitInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<OriginGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var originResponse = await response
                    .Deserialize<OriginResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    originResponse.Validate();
                }
                return originResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<OriginResponse>> Get(
        string id,
        OriginGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { ID = id }, cancellationToken);
    }
}
