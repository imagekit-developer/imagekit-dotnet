using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.AIFilterSearch;

namespace Imagekit.Services;

/// <inheritdoc/>
public sealed class AIFilterSearchService : IAIFilterSearchService
{
    readonly Lazy<IAIFilterSearchServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAIFilterSearchServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public IAIFilterSearchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AIFilterSearchService(this._client.WithOptions(modifier));
    }

    public AIFilterSearchService(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AIFilterSearchServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<AIFilterSearchCreateResponse> Create(
        AIFilterSearchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AIFilterSearchServiceWithRawResponse : IAIFilterSearchServiceWithRawResponse
{
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAIFilterSearchServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AIFilterSearchServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AIFilterSearchServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AIFilterSearchCreateResponse>> Create(
        AIFilterSearchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AIFilterSearchCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var aiFilterSearch = await response
                    .Deserialize<AIFilterSearchCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    aiFilterSearch.Validate();
                }
                return aiFilterSearch;
            }
        );
    }
}
