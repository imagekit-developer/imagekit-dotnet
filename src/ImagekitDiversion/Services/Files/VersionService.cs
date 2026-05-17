using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.Files.Details;
using ImagekitDiversion.Models.Files.Versions;

namespace ImagekitDiversion.Services.Files;

/// <inheritdoc/>
public sealed class VersionService : IVersionService
{
    readonly Lazy<IVersionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVersionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImagekitDiversionClient _client;

    /// <inheritdoc/>
    public IVersionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VersionService(this._client.WithOptions(modifier));
    }

    public VersionService(IImagekitDiversionClient client)
    {
        _client = client;

        _withRawResponse = new(() => new VersionServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<FileDetails> Retrieve(
        VersionRetrieveParams parameters,
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
        string versionID,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { VersionID = versionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<FileDetails>> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<FileDetails>> List(
        string fileID,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VersionDeleteResponse> Delete(
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<VersionDeleteResponse> Delete(
        string versionID,
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { VersionID = versionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FileDetails> Restore(
        VersionRestoreParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Restore(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FileDetails> Restore(
        string versionID,
        VersionRestoreParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Restore(parameters with { VersionID = versionID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class VersionServiceWithRawResponse : IVersionServiceWithRawResponse
{
    readonly IImagekitDiversionClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVersionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VersionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VersionServiceWithRawResponse(IImagekitDiversionClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FileDetails>> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VersionID == null)
        {
            throw new ImagekitDiversionInvalidDataException(
                "'parameters.VersionID' cannot be null"
            );
        }

        HttpRequest<VersionRetrieveParams> request = new()
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
        string versionID,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { VersionID = versionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<FileDetails>>> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FileID == null)
        {
            throw new ImagekitDiversionInvalidDataException("'parameters.FileID' cannot be null");
        }

        HttpRequest<VersionListParams> request = new()
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
                    .Deserialize<List<FileDetails>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in fileDetails)
                    {
                        item.Validate();
                    }
                }
                return fileDetails;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<FileDetails>>> List(
        string fileID,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VersionDeleteResponse>> Delete(
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VersionID == null)
        {
            throw new ImagekitDiversionInvalidDataException(
                "'parameters.VersionID' cannot be null"
            );
        }

        HttpRequest<VersionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var version = await response
                    .Deserialize<VersionDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    version.Validate();
                }
                return version;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<VersionDeleteResponse>> Delete(
        string versionID,
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { VersionID = versionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FileDetails>> Restore(
        VersionRestoreParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VersionID == null)
        {
            throw new ImagekitDiversionInvalidDataException(
                "'parameters.VersionID' cannot be null"
            );
        }

        HttpRequest<VersionRestoreParams> request = new()
        {
            Method = HttpMethod.Put,
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
    public Task<HttpResponse<FileDetails>> Restore(
        string versionID,
        VersionRestoreParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Restore(parameters with { VersionID = versionID }, cancellationToken);
    }
}
