using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.Files.Details;

namespace ImagekitDiversion.Services.Files;

/// <inheritdoc/>
public sealed class DetailService : IDetailService
{
    readonly Lazy<IDetailServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDetailServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImagekitDiversionClient _client;

    /// <inheritdoc/>
    public IDetailService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DetailService(this._client.WithOptions(modifier));
    }

    public DetailService(IImagekitDiversionClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DetailServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<FileDetails> Retrieve(
        DetailRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FileDetails> Retrieve(
        string fileID,
        DetailRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DetailUpdateResponse> Update(
        DetailUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DetailUpdateResponse> Update(
        string fileID,
        DetailUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { FileID = fileID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class DetailServiceWithRawResponse : IDetailServiceWithRawResponse
{
    readonly IImagekitDiversionClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDetailServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DetailServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DetailServiceWithRawResponse(IImagekitDiversionClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FileDetails>> Retrieve(
        DetailRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FileID == null)
        {
            throw new ImagekitDiversionInvalidDataException("'parameters.FileID' cannot be null");
        }

        HttpRequest<DetailRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var fileDetails = await response
                    .Deserialize<FileDetails>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    fileDetails.Validate();
                }
                return fileDetails;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FileDetails>> Retrieve(
        string fileID,
        DetailRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DetailUpdateResponse>> Update(
        DetailUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FileID == null)
        {
            throw new ImagekitDiversionInvalidDataException("'parameters.FileID' cannot be null");
        }

        HttpRequest<DetailUpdateParams> request = new()
        {
            Method = ImagekitDiversionClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var detail = await response
                    .Deserialize<DetailUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    detail.Validate();
                }
                return detail;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DetailUpdateResponse>> Update(
        string fileID,
        DetailUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { FileID = fileID }, cancellationToken);
    }
}
