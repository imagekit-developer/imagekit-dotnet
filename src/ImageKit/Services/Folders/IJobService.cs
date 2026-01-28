using System;
using System.Threading;
using System.Threading.Tasks;
using ImageKit.Core;
using ImageKit.Models.Folders.Job;

namespace ImageKit.Services.Folders;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IJobService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IJobServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJobService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This API returns the status of a bulk job like copy and move folder operations.
    /// </summary>
    Task<JobGetResponse> Get(
        JobGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(JobGetParams, CancellationToken)"/>
    Task<JobGetResponse> Get(
        string jobID,
        JobGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IJobService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IJobServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJobServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/bulkJobs/{jobId}`, but is otherwise the
    /// same as <see cref="IJobService.Get(JobGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JobGetResponse>> Get(
        JobGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(JobGetParams, CancellationToken)"/>
    Task<HttpResponse<JobGetResponse>> Get(
        string jobID,
        JobGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
