using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Accounts;
using ImagekitDiversion.Services.Accounts;

namespace ImagekitDiversion.Services;

/// <inheritdoc/>
public sealed class AccountService : IAccountService
{
    readonly Lazy<IAccountServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccountServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImagekitDiversionClient _client;

    /// <inheritdoc/>
    public IAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountService(this._client.WithOptions(modifier));
    }

    public AccountService(IImagekitDiversionClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AccountServiceWithRawResponse(client.WithRawResponse));
        _origins = new(() => new OriginService(client));
        _urlEndpoints = new(() => new UrlEndpointService(client));
    }

    readonly Lazy<IOriginService> _origins;
    public IOriginService Origins
    {
        get { return _origins.Value; }
    }

    readonly Lazy<IUrlEndpointService> _urlEndpoints;
    public IUrlEndpointService UrlEndpoints
    {
        get { return _urlEndpoints.Value; }
    }

    /// <inheritdoc/>
    public async Task<AccountGetUsageResponse> GetUsage(
        AccountGetUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetUsage(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AccountServiceWithRawResponse : IAccountServiceWithRawResponse
{
    readonly IImagekitDiversionClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccountServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AccountServiceWithRawResponse(IImagekitDiversionClientWithRawResponse client)
    {
        _client = client;

        _origins = new(() => new OriginServiceWithRawResponse(client));
        _urlEndpoints = new(() => new UrlEndpointServiceWithRawResponse(client));
    }

    readonly Lazy<IOriginServiceWithRawResponse> _origins;
    public IOriginServiceWithRawResponse Origins
    {
        get { return _origins.Value; }
    }

    readonly Lazy<IUrlEndpointServiceWithRawResponse> _urlEndpoints;
    public IUrlEndpointServiceWithRawResponse UrlEndpoints
    {
        get { return _urlEndpoints.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountGetUsageResponse>> GetUsage(
        AccountGetUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AccountGetUsageParams> request = new()
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
                    .Deserialize<AccountGetUsageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
