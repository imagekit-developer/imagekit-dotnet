using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ImageKit.Core;
using ImageKit.Services;

namespace ImageKit;

/// <summary>
/// A client for interacting with the Image Kit REST API.
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
public interface IImageKitClient : IDisposable
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
    /// Your ImageKit private API key (starts with `private_`). You can find this
    /// in the [ImageKit dashboard](https://imagekit.io/dashboard/developer/api-keys).
    /// </summary>
    string PrivateKey { get; init; }

    /// <summary>
    /// ImageKit uses your API key as username and ignores the password.  The SDK
    /// sets a dummy value. You can ignore this field.
    /// </summary>
    string? Password { get; init; }

    /// <summary>
    /// Your ImageKit webhook secret for verifying webhook signatures (starts with
    /// `whsec_`). You can find this in the [ImageKit dashboard](https://imagekit.io/dashboard/developer/webhooks).
    /// Only required if you're using webhooks.
    /// </summary>
    string? WebhookSecret { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IImageKitClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IImageKitClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICustomMetadataFieldService CustomMetadataFields { get; }

    IFileService Files { get; }

    ISavedExtensionService SavedExtensions { get; }

    IAssetService Assets { get; }

    ICacheService Cache { get; }

    IFolderService Folders { get; }

    IAccountService Accounts { get; }

    IBetaService Beta { get; }

    IWebhookService Webhooks { get; }
}

/// <summary>
/// A view of <see cref="IImageKitClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IImageKitClientWithRawResponse : IDisposable
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
    /// Your ImageKit private API key (starts with `private_`). You can find this
    /// in the [ImageKit dashboard](https://imagekit.io/dashboard/developer/api-keys).
    /// </summary>
    string PrivateKey { get; init; }

    /// <summary>
    /// ImageKit uses your API key as username and ignores the password.  The SDK
    /// sets a dummy value. You can ignore this field.
    /// </summary>
    string? Password { get; init; }

    /// <summary>
    /// Your ImageKit webhook secret for verifying webhook signatures (starts with
    /// `whsec_`). You can find this in the [ImageKit dashboard](https://imagekit.io/dashboard/developer/webhooks).
    /// Only required if you're using webhooks.
    /// </summary>
    string? WebhookSecret { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IImageKitClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICustomMetadataFieldServiceWithRawResponse CustomMetadataFields { get; }

    IFileServiceWithRawResponse Files { get; }

    ISavedExtensionServiceWithRawResponse SavedExtensions { get; }

    IAssetServiceWithRawResponse Assets { get; }

    ICacheServiceWithRawResponse Cache { get; }

    IFolderServiceWithRawResponse Folders { get; }

    IAccountServiceWithRawResponse Accounts { get; }

    IBetaServiceWithRawResponse Beta { get; }

    IWebhookServiceWithRawResponse Webhooks { get; }

    /// <summary>
    /// Sends a request to the Image Kit REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
