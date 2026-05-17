using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Services;

namespace ImagekitDiversion;

/// <summary>
/// A client for interacting with the Imagekit Diversion REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IImagekitDiversionClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Basic HTTP authentication. Allowed headers-- Authorization: Basic &lt;private_api_key&gt;
    /// | Authorization: Basic &lt;base64 hash of `private_api_key:`&gt; ImageKit
    /// API uses API keys to authenticate requests. You can view and manage your API
    /// keys in [the dashboard](https://imagekit.io/dashboard/developer/api-keys).
    /// All API requests must be made over HTTPS. Calls made over plain HTTP will
    /// fail. API requests without authentication will also fail.
    /// </summary>
    string Username { get; init; }

    /// <summary>
    /// Basic HTTP authentication. Allowed headers-- Authorization: Basic &lt;private_api_key&gt;
    /// | Authorization: Basic &lt;base64 hash of `private_api_key:`&gt; ImageKit
    /// API uses API keys to authenticate requests. You can view and manage your API
    /// keys in [the dashboard](https://imagekit.io/dashboard/developer/api-keys).
    /// All API requests must be made over HTTPS. Calls made over plain HTTP will
    /// fail. API requests without authentication will also fail.
    /// </summary>
    string Password { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IImagekitDiversionClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IImagekitDiversionClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDummyService Dummy { get; }

    IApiService Api { get; }

    ICustomMetadataFieldService CustomMetadataFields { get; }

    IFileService Files { get; }

    IFolderService Folder { get; }

    IBulkJobService BulkJobs { get; }

    IMetadataService Metadata { get; }

    ISavedExtensionService SavedExtensions { get; }

    IAccountService Accounts { get; }
}

/// <summary>
/// A view of <see cref="IImagekitDiversionClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IImagekitDiversionClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Basic HTTP authentication. Allowed headers-- Authorization: Basic &lt;private_api_key&gt;
    /// | Authorization: Basic &lt;base64 hash of `private_api_key:`&gt; ImageKit
    /// API uses API keys to authenticate requests. You can view and manage your API
    /// keys in [the dashboard](https://imagekit.io/dashboard/developer/api-keys).
    /// All API requests must be made over HTTPS. Calls made over plain HTTP will
    /// fail. API requests without authentication will also fail.
    /// </summary>
    string Username { get; init; }

    /// <summary>
    /// Basic HTTP authentication. Allowed headers-- Authorization: Basic &lt;private_api_key&gt;
    /// | Authorization: Basic &lt;base64 hash of `private_api_key:`&gt; ImageKit
    /// API uses API keys to authenticate requests. You can view and manage your API
    /// keys in [the dashboard](https://imagekit.io/dashboard/developer/api-keys).
    /// All API requests must be made over HTTPS. Calls made over plain HTTP will
    /// fail. API requests without authentication will also fail.
    /// </summary>
    string Password { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IImagekitDiversionClientWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    IDummyServiceWithRawResponse Dummy { get; }

    IApiServiceWithRawResponse Api { get; }

    ICustomMetadataFieldServiceWithRawResponse CustomMetadataFields { get; }

    IFileServiceWithRawResponse Files { get; }

    IFolderServiceWithRawResponse Folder { get; }

    IBulkJobServiceWithRawResponse BulkJobs { get; }

    IMetadataServiceWithRawResponse Metadata { get; }

    ISavedExtensionServiceWithRawResponse SavedExtensions { get; }

    IAccountServiceWithRawResponse Accounts { get; }

    /// <summary>
    /// Sends a request to the Imagekit Diversion REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
