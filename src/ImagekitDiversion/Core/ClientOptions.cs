using System;
using System.Net.Http;
using ImagekitDiversion.Exceptions;

namespace ImagekitDiversion.Core;

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
    ///
    /// <para>Note: The HttpClient has a built-in timeout, which defaults to 100 seconds.
    /// When passing a custom HttpClient, this timeout may conflict with the SDK's
    /// own timeout handler and cause premature cancellation.</para>
    /// </summary>
    public HttpClient HttpClient { get; set; } =
        new(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.Available })
        {
            Timeout = global::System.Threading.Timeout.InfiniteTimeSpan,
        };

    Lazy<string> _baseUrl = new(() =>
        Environment.GetEnvironmentVariable("IMAGEKIT_DIVERSION_BASE_URL")
        ?? EnvironmentUrl.Production
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
    /// <see cref="IImagekitDiversionClient.WithRawResponse"/>, don't perform validation until deserialization
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
    /// Basic HTTP authentication. Allowed headers-- Authorization: Basic &lt;private_api_key&gt;
    /// | Authorization: Basic &lt;base64 hash of `private_api_key:`&gt; ImageKit
    /// API uses API keys to authenticate requests. You can view and manage your API
    /// keys in [the dashboard](https://imagekit.io/dashboard/developer/api-keys).
    /// All API requests must be made over HTTPS. Calls made over plain HTTP will
    /// fail. API requests without authentication will also fail.
    /// </summary>
    Lazy<string> _username = new(() =>
        Environment.GetEnvironmentVariable("IMAGEKIT_DIVERSION_USERNAME")
        ?? throw new ImagekitDiversionInvalidDataException(
            string.Format("{0} cannot be null", nameof(Username)),
            new ArgumentNullException(nameof(Username))
        )
    );

    /// <summary>
    /// Basic HTTP authentication. Allowed headers-- Authorization: Basic &lt;private_api_key&gt;
    /// | Authorization: Basic &lt;base64 hash of `private_api_key:`&gt; ImageKit
    /// API uses API keys to authenticate requests. You can view and manage your API
    /// keys in [the dashboard](https://imagekit.io/dashboard/developer/api-keys).
    /// All API requests must be made over HTTPS. Calls made over plain HTTP will
    /// fail. API requests without authentication will also fail.
    /// </summary>
    public string Username
    {
        readonly get { return _username.Value; }
        set { _username = new(() => value); }
    }

    /// <summary>
    /// Basic HTTP authentication. Allowed headers-- Authorization: Basic &lt;private_api_key&gt;
    /// | Authorization: Basic &lt;base64 hash of `private_api_key:`&gt; ImageKit
    /// API uses API keys to authenticate requests. You can view and manage your API
    /// keys in [the dashboard](https://imagekit.io/dashboard/developer/api-keys).
    /// All API requests must be made over HTTPS. Calls made over plain HTTP will
    /// fail. API requests without authentication will also fail.
    /// </summary>
    Lazy<string> _password = new(() =>
        Environment.GetEnvironmentVariable("IMAGEKIT_DIVERSION_PASSWORD")
        ?? throw new ImagekitDiversionInvalidDataException(
            string.Format("{0} cannot be null", nameof(Password)),
            new ArgumentNullException(nameof(Password))
        )
    );

    /// <summary>
    /// Basic HTTP authentication. Allowed headers-- Authorization: Basic &lt;private_api_key&gt;
    /// | Authorization: Basic &lt;base64 hash of `private_api_key:`&gt; ImageKit
    /// API uses API keys to authenticate requests. You can view and manage your API
    /// keys in [the dashboard](https://imagekit.io/dashboard/developer/api-keys).
    /// All API requests must be made over HTTPS. Calls made over plain HTTP will
    /// fail. API requests without authentication will also fail.
    /// </summary>
    public string Password
    {
        readonly get { return _password.Value; }
        set { _password = new(() => value); }
    }
}
