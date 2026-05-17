using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.BulkJobs;

namespace ImagekitDiversion.Services;

/// <inheritdoc/>
public sealed class BulkJobService : IBulkJobService
{
    readonly Lazy<IBulkJobServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBulkJobServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImagekitDiversionClient _client;

    /// <inheritdoc/>
    public IBulkJobService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BulkJobService(this._client.WithOptions(modifier));
    }

    public BulkJobService(IImagekitDiversionClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BulkJobServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Job> CopyFolder(
        BulkJobCopyFolderParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CopyFolder(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Job> MoveFolder(
        BulkJobMoveFolderParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.MoveFolder(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Job> RenameFolder(
        BulkJobRenameFolderParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RenameFolder(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BulkJobRetrieveStatusResponse> RetrieveStatus(
        BulkJobRetrieveStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveStatus(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BulkJobRetrieveStatusResponse> RetrieveStatus(
        string jobID,
        BulkJobRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveStatus(parameters with { JobID = jobID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class BulkJobServiceWithRawResponse : IBulkJobServiceWithRawResponse
{
    readonly IImagekitDiversionClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBulkJobServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BulkJobServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BulkJobServiceWithRawResponse(IImagekitDiversionClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Job>> CopyFolder(
        BulkJobCopyFolderParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BulkJobCopyFolderParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var job = await response.Deserialize<Job>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    job.Validate();
                }
                return job;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Job>> MoveFolder(
        BulkJobMoveFolderParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BulkJobMoveFolderParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var job = await response.Deserialize<Job>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    job.Validate();
                }
                return job;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Job>> RenameFolder(
        BulkJobRenameFolderParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BulkJobRenameFolderParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var job = await response.Deserialize<Job>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    job.Validate();
                }
                return job;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BulkJobRetrieveStatusResponse>> RetrieveStatus(
        BulkJobRetrieveStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new ImagekitDiversionInvalidDataException("'parameters.JobID' cannot be null");
        }

        HttpRequest<BulkJobRetrieveStatusParams> request = new()
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
                    .Deserialize<BulkJobRetrieveStatusResponse>(token)
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
    public Task<HttpResponse<BulkJobRetrieveStatusResponse>> RetrieveStatus(
        string jobID,
        BulkJobRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveStatus(parameters with { JobID = jobID }, cancellationToken);
    }
}
