using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Accounts.Contract;

namespace Imagekit.Services.Accounts;

/// <inheritdoc/>
public sealed class ContractService : IContractService
{
    readonly Lazy<IContractServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IContractServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public IContractService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ContractService(this._client.WithOptions(modifier));
    }

    public ContractService(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ContractServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ContractGetResponse> Get(
        ContractGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ContractServiceWithRawResponse : IContractServiceWithRawResponse
{
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public IContractServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ContractServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ContractServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ContractGetResponse>> Get(
        ContractGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ContractGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var contract = await response
                    .Deserialize<ContractGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    contract.Validate();
                }
                return contract;
            }
        );
    }
}
