using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ImageKit.Core;
using ImageKit.Models.Folders;
using ImageKit.Services.Folders;

namespace ImageKit.Services;

/// <inheritdoc/>
public sealed class FolderService : IFolderService
{
    readonly Lazy<IFolderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFolderServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public IFolderService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FolderService(this._client.WithOptions(modifier));
    }

    public FolderService(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FolderServiceWithRawResponse(client.WithRawResponse));
        _job = new(() => new JobService(client));
    }

    readonly Lazy<IJobService> _job;
    public IJobService Job
    {
        get { return _job.Value; }
    }

    /// <inheritdoc/>
    public async Task<FolderCreateResponse> Create(
        FolderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FolderDeleteResponse> Delete(
        FolderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FolderCopyResponse> Copy(
        FolderCopyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Copy(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FolderMoveResponse> Move(
        FolderMoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Move(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FolderRenameResponse> Rename(
        FolderRenameParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Rename(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class FolderServiceWithRawResponse : IFolderServiceWithRawResponse
{
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFolderServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FolderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FolderServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;

        _job = new(() => new JobServiceWithRawResponse(client));
    }

    readonly Lazy<IJobServiceWithRawResponse> _job;
    public IJobServiceWithRawResponse Job
    {
        get { return _job.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FolderCreateResponse>> Create(
        FolderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FolderCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var folder = await response
                    .Deserialize<FolderCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    folder.Validate();
                }
                return folder;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FolderDeleteResponse>> Delete(
        FolderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FolderDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var folder = await response
                    .Deserialize<FolderDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    folder.Validate();
                }
                return folder;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FolderCopyResponse>> Copy(
        FolderCopyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FolderCopyParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<FolderCopyResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FolderMoveResponse>> Move(
        FolderMoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FolderMoveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<FolderMoveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FolderRenameResponse>> Rename(
        FolderRenameParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FolderRenameParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<FolderRenameResponse>(token)
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
