using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Files;
using ImagekitDiversion.Models.Metadata;

namespace ImagekitDiversion.Services;

/// <inheritdoc/>
public sealed class MetadataService : IMetadataService
{
    readonly Lazy<IMetadataServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMetadataServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImagekitDiversionClient _client;

    /// <inheritdoc/>
    public IMetadataService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MetadataService(this._client.WithOptions(modifier));
    }

    public MetadataService(IImagekitDiversionClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MetadataServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<FileMetadata> Retrieve(
        MetadataRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MetadataServiceWithRawResponse : IMetadataServiceWithRawResponse
{
    readonly IImagekitDiversionClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMetadataServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MetadataServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MetadataServiceWithRawResponse(IImagekitDiversionClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FileMetadata>> Retrieve(
        MetadataRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MetadataRetrieveParams> request = new()
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
