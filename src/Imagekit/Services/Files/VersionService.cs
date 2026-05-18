using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.Files;
using Imagekit.Models.Files.Versions;

namespace Imagekit.Services.Files;

/// <inheritdoc/>
public sealed class VersionService : IVersionService
{
    readonly Lazy<IVersionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVersionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public IVersionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VersionService(this._client.WithOptions(modifier));
    }

    public VersionService(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() => new VersionServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<File>> List(
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
    public Task<List<File>> List(
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
    public async Task<File> Get(
        VersionGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<File> Get(
        string versionID,
        VersionGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Get(parameters with { VersionID = versionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<File> Restore(
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
    public Task<File> Restore(
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
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVersionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VersionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VersionServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<File>>> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FileID == null)
        {
            throw new ImageKitInvalidDataException("'parameters.FileID' cannot be null");
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
                var files = await response.Deserialize<List<File>>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in files)
                    {
                        item.Validate();
                    }
                }
                return files;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<File>>> List(
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
            throw new ImageKitInvalidDataException("'parameters.VersionID' cannot be null");
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
    public async Task<HttpResponse<File>> Get(
        VersionGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VersionID == null)
        {
            throw new ImageKitInvalidDataException("'parameters.VersionID' cannot be null");
        }

        HttpRequest<VersionGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var file = await response.Deserialize<File>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    file.Validate();
                }
                return file;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<File>> Get(
        string versionID,
        VersionGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Get(parameters with { VersionID = versionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<File>> Restore(
        VersionRestoreParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VersionID == null)
        {
            throw new ImageKitInvalidDataException("'parameters.VersionID' cannot be null");
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
                var file = await response.Deserialize<File>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    file.Validate();
                }
                return file;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<File>> Restore(
        string versionID,
        VersionRestoreParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Restore(parameters with { VersionID = versionID }, cancellationToken);
    }
}
