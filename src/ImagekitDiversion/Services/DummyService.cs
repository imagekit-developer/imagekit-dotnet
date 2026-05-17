using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using Dummy = ImagekitDiversion.Models.Dummy;

namespace ImagekitDiversion.Services;

/// <inheritdoc/>
public sealed class DummyService : IDummyService
{
    readonly Lazy<IDummyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDummyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImagekitDiversionClient _client;

    /// <inheritdoc/>
    public IDummyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DummyService(this._client.WithOptions(modifier));
    }

    public DummyService(IImagekitDiversionClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DummyServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task Test(
        Dummy::DummyTestParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Test(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class DummyServiceWithRawResponse : IDummyServiceWithRawResponse
{
    readonly IImagekitDiversionClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDummyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DummyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DummyServiceWithRawResponse(IImagekitDiversionClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Test(
        Dummy::DummyTestParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Dummy::DummyTestParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
