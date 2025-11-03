using System;
using System.Net.Http;
using Imagekit.Exceptions;

namespace Imagekit.Core;

public struct ClientOptions()
{
    public HttpClient HttpClient { get; set; } = new();

    Lazy<Uri> _baseUrl = new(() =>
        new Uri(
            Environment.GetEnvironmentVariable("IMAGE_KIT_BASE_URL") ?? "https://api.imagekit.io"
        )
    );
    public Uri BaseUrl
    {
        readonly get { return _baseUrl.Value; }
        set { _baseUrl = new(() => value); }
    }

    public TimeSpan Timeout { get; set; } = TimeSpan.FromMinutes(1);

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
