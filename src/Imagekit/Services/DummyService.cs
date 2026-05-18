using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Dummy;

namespace Imagekit.Services;

/// <inheritdoc/>
public sealed class DummyService : IDummyService
{
    readonly Lazy<IDummyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDummyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public IDummyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DummyService(this._client.WithOptions(modifier));
    }

    public DummyService(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DummyServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task Create(
        DummyCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Create(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class DummyServiceWithRawResponse : IDummyServiceWithRawResponse
{
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDummyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DummyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DummyServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        DummyCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DummyCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
