using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.Folders.Job;

namespace Imagekit.Services.Folders;

/// <inheritdoc/>
public sealed class JobService : IJobService
{
    readonly Lazy<IJobServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IJobServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public IJobService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new JobService(this._client.WithOptions(modifier));
    }

    public JobService(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() => new JobServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<JobGetResponse> Get(
        JobGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JobGetResponse> Get(
        string jobID,
        JobGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { JobID = jobID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class JobServiceWithRawResponse : IJobServiceWithRawResponse
{
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public IJobServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new JobServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public JobServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JobGetResponse>> Get(
        JobGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new ImageKitInvalidDataException("'parameters.JobID' cannot be null");
        }

        HttpRequest<JobGetParams> request = new() { Method = HttpMethod.Get, Params = parameters };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var job = await response.Deserialize<JobGetResponse>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    job.Validate();
                }
                return job;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JobGetResponse>> Get(
        string jobID,
        JobGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { JobID = jobID }, cancellationToken);
    }
}
