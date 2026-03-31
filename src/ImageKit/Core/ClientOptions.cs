using System;
using System.Net.Http;
using ImageKit.Exceptions;

namespace ImageKit.Core;

/// <summary>
/// A class representing the SDK client configuration.
/// </summary>
public record struct ClientOptions()
{
    /// <summary>
    /// The default value used for <see cref="MaxRetries"/>.
    /// </summary>
    public static readonly int DefaultMaxRetries = 2;

    /// <summary>
    /// The default value used for <see cref="Timeout"/>.
    /// </summary>
    public static readonly TimeSpan DefaultTimeout = TimeSpan.FromMinutes(1);

    /// <summary>
    /// The HTTP client to use for making requests in the SDK.
    /// </summary>
    public HttpClient HttpClient { get; set; } =
        new(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.Available });

    Lazy<string> _baseUrl = new(() =>
        Environment.GetEnvironmentVariable("IMAGE_KIT_BASE_URL") ?? EnvironmentUrl.Production
    );

    /// <summary>
    /// The base URL to use for every request.
    ///
    /// <para>Defaults to the production environment: <see cref="EnvironmentUrl.Production"/></para>
    /// </summary>
    public string BaseUrl
    {
        readonly get { return _baseUrl.Value; }
        set { _baseUrl = new(() => value); }
    }

    /// <summary>
    /// Whether to validate response bodies before returning them.
    ///
    /// <para>Defaults to false, which means the shape of the response body will not be validated upfront.
    /// Instead, validation will only occur for the parts of the response body that are accessed.</para>
    ///
    /// <para>Note that when set to true, the response body is only validated if the response is
    /// deserialized. Methods that don't eagerly deserialize the response, such as those on
    /// <see cref="IImageKitClient.WithRawResponse"/>, don't perform validation until deserialization
    /// is triggered.</para>
    /// </summary>
    public bool ResponseValidation { get; set; } = false;

    /// <summary>
    /// The maximum number of times to retry failed requests, with a short exponential backoff between requests.
    ///
    /// <para>
    /// Only the following error types are retried:
    /// <list type="bullet">
    ///   <item>Connection errors (for example, due to a network connectivity problem)</item>
    ///   <item>408 Request Timeout</item>
    ///   <item>409 Conflict</item>
    ///   <item>429 Rate Limit</item>
    ///   <item>5xx Internal</item>
    /// </list>
    /// </para>
    ///
    /// <para>The API may also explicitly instruct the SDK to retry or not retry a request.</para>
    ///
    /// <para>Defaults to 2 when null. Set to 0 to
    /// disable retries, which also ignores API instructions to retry.</para>
    /// </summary>
    public int? MaxRetries { get; set; } = null;

    /// <summary>
    /// Sets the maximum time allowed for a complete HTTP call, not including retries.
    ///
    /// <para>This includes resolving DNS, connecting, writing the request body, server processing, as
    /// well as reading the response body.</para>
    ///
    /// <para>Defaults to <c>TimeSpan.FromMinutes(1)</c> when null.</para>
    /// </summary>
    public TimeSpan? Timeout { get; set; } = null;

    /// <summary>
    /// Your ImageKit private API key (starts with `private_`). You can find this
    /// in the [ImageKit dashboard](https://imagekit.io/dashboard/developer/api-keys).
    /// </summary>
    Lazy<string> _privateKey = new(() =>
        Environment.GetEnvironmentVariable("IMAGEKIT_PRIVATE_KEY")
        ?? throw new ImageKitInvalidDataException(
            string.Format("{0} cannot be null", nameof(PrivateKey)),
            new ArgumentNullException(nameof(PrivateKey))
        )
    );

    /// <summary>
    /// Your ImageKit private API key (starts with `private_`). You can find this
    /// in the [ImageKit dashboard](https://imagekit.io/dashboard/developer/api-keys).
    /// </summary>
    public string PrivateKey
    {
        readonly get { return _privateKey.Value; }
        set { _privateKey = new(() => value); }
    }

    /// <summary>
    /// ImageKit uses your API key as username and ignores the password.  The SDK
    /// sets a dummy value. You can ignore this field.
    /// </summary>
    Lazy<string?> _password = new(() =>
        Environment.GetEnvironmentVariable("OPTIONAL_IMAGEKIT_IGNORES_THIS") ?? "do_not_set"
    );

    /// <summary>
    /// ImageKit uses your API key as username and ignores the password.  The SDK
    /// sets a dummy value. You can ignore this field.
    /// </summary>
    public string? Password
    {
        readonly get { return _password.Value; }
        set { _password = new(() => value); }
    }

    /// <summary>
    /// Your ImageKit webhook secret for verifying webhook signatures (starts with
    /// `whsec_`). You can find this in the [ImageKit dashboard](https://imagekit.io/dashboard/developer/webhooks).
    /// Only required if you're using webhooks.
    /// </summary>
    Lazy<string?> _webhookSecret = new(() =>
        Environment.GetEnvironmentVariable("IMAGEKIT_WEBHOOK_SECRET")
    );

    /// <summary>
    /// Your ImageKit webhook secret for verifying webhook signatures (starts with
    /// `whsec_`). You can find this in the [ImageKit dashboard](https://imagekit.io/dashboard/developer/webhooks).
    /// Only required if you're using webhooks.
    /// </summary>
    public string? WebhookSecret
    {
        readonly get { return _webhookSecret.Value; }
        set { _webhookSecret = new(() => value); }
    }
}
