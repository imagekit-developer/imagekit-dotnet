using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.Cache.Invalidation;

namespace Imagekit.Services.Cache;

/// <inheritdoc/>
public sealed class InvalidationService : IInvalidationService
{
    readonly Lazy<IInvalidationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInvalidationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public IInvalidationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvalidationService(this._client.WithOptions(modifier));
    }

    public InvalidationService(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new InvalidationServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<InvalidationCreateResponse> Create(
        InvalidationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<InvalidationGetResponse> Get(
        InvalidationGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InvalidationGetResponse> Get(
        string requestID,
        InvalidationGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { RequestID = requestID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class InvalidationServiceWithRawResponse : IInvalidationServiceWithRawResponse
{
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInvalidationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InvalidationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InvalidationServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvalidationCreateResponse>> Create(
        InvalidationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InvalidationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invalidation = await response
                    .Deserialize<InvalidationCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invalidation.Validate();
                }
                return invalidation;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvalidationGetResponse>> Get(
        InvalidationGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RequestID == null)
        {
            throw new ImageKitInvalidDataException("'parameters.RequestID' cannot be null");
        }

        HttpRequest<InvalidationGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invalidation = await response
                    .Deserialize<InvalidationGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invalidation.Validate();
                }
                return invalidation;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InvalidationGetResponse>> Get(
        string requestID,
        InvalidationGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { RequestID = requestID }, cancellationToken);
    }
}
