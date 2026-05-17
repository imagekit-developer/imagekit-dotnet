using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.Files.Purge;

namespace ImagekitDiversion.Services.Files;

/// <inheritdoc/>
public sealed class PurgeService : IPurgeService
{
    readonly Lazy<IPurgeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPurgeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImagekitDiversionClient _client;

    /// <inheritdoc/>
    public IPurgeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PurgeService(this._client.WithOptions(modifier));
    }

    public PurgeService(IImagekitDiversionClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PurgeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<PurgeCacheResponse> Cache(
        PurgeCacheParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cache(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PurgeStatusResponse> Status(
        PurgeStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Status(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PurgeStatusResponse> Status(
        string requestID,
        PurgeStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Status(parameters with { RequestID = requestID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PurgeServiceWithRawResponse : IPurgeServiceWithRawResponse
{
    readonly IImagekitDiversionClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPurgeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PurgeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PurgeServiceWithRawResponse(IImagekitDiversionClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PurgeCacheResponse>> Cache(
        PurgeCacheParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PurgeCacheParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<PurgeCacheResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PurgeStatusResponse>> Status(
        PurgeStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RequestID == null)
        {
            throw new ImagekitDiversionInvalidDataException(
                "'parameters.RequestID' cannot be null"
            );
        }

        HttpRequest<PurgeStatusParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<PurgeStatusResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PurgeStatusResponse>> Status(
        string requestID,
        PurgeStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Status(parameters with { RequestID = requestID }, cancellationToken);
    }
}
