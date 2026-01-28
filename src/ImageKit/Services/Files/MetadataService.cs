using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ImageKit.Core;
using ImageKit.Exceptions;
using ImageKit.Models.Files;
using ImageKit.Models.Files.Metadata;

namespace ImageKit.Services.Files;

/// <inheritdoc/>
public sealed class MetadataService : IMetadataService
{
    readonly Lazy<IMetadataServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMetadataServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public IMetadataService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MetadataService(this._client.WithOptions(modifier));
    }

    public MetadataService(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MetadataServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<FileMetadata> Get(
        MetadataGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FileMetadata> Get(
        string fileID,
        MetadataGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FileMetadata> GetFromUrl(
        MetadataGetFromUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetFromUrl(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MetadataServiceWithRawResponse : IMetadataServiceWithRawResponse
{
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMetadataServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MetadataServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MetadataServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FileMetadata>> Get(
        MetadataGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FileID == null)
        {
            throw new ImageKitInvalidDataException("'parameters.FileID' cannot be null");
        }

        HttpRequest<MetadataGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var metadata = await response
                    .Deserialize<FileMetadata>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    metadata.Validate();
                }
                return metadata;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FileMetadata>> Get(
        string fileID,
        MetadataGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FileMetadata>> GetFromUrl(
        MetadataGetFromUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MetadataGetFromUrlParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var metadata = await response
                    .Deserialize<FileMetadata>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    metadata.Validate();
                }
                return metadata;
            }
        );
    }
}
