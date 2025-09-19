using System;
using System.Net.Http;
using Imagekit.Services.Accounts;
using Imagekit.Services.Assets;
using Imagekit.Services.Beta;
using Imagekit.Services.Cache;
using Imagekit.Services.CustomMetadataFields;
using Imagekit.Services.Files;
using Imagekit.Services.Folders;
using Imagekit.Services.Webhooks;

namespace Imagekit;

public interface IImageKitClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    /// <summary>
    /// Your ImageKit private API key (starts with `private_`). You can find this
    /// in the [ImageKit dashboard](https://imagekit.io/dashboard/developer/api-keys).
    /// </summary>
    string PrivateKey { get; init; }

    /// <summary>
    /// Leave this field unset. ImageKit uses Basic Authentication scheme that requires
    /// the `private_key` as the username and empty string as the password. The password
    /// field is automatically managed by the SDK and should not be set.
    /// </summary>
    string? Password { get; init; }

    /// <summary>
    /// Your ImageKit webhook secret used by the SDK to verify webhook signatures
    /// for security. This secret starts with a `whsec_` prefix and is essential for
    /// webhook verification. You can view and manage your webhook secret in the
    /// [ImageKit dashboard](https://imagekit.io/dashboard/developer/webhooks).
    ///
    /// **Security Note**: Treat this secret like a password - keep it private and
    /// never expose it publicly. This field is optional and only required if you
    /// plan to use webhook signature verification. Learn more about [webhook verification](https://imagekit.io/docs/webhooks#verify-webhook-signature).
    /// </summary>
    string? WebhookSecret { get; init; }

    ICustomMetadataFieldService CustomMetadataFields { get; }

    IFileService Files { get; }

    IAssetService Assets { get; }

    ICacheService Cache { get; }

    IFolderService Folders { get; }

    IAccountService Accounts { get; }

    IBetaService Beta { get; }

    IWebhookService Webhooks { get; }
}
