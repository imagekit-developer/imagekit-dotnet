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
    /// Your ImageKit private API key (it starts with `private_`). You can view and
    /// manage API keys in the [dashboard](https://imagekit.io/dashboard/developer/api-keys).
    /// </summary>
    string PrivateAPIKey { get; init; }

    /// <summary>
    /// ImageKit Basic Auth only uses the username field and ignores the password.
    /// This field is unused.
    /// </summary>
    string? Password { get; init; }

    /// <summary>
    /// Your ImageKit webhook secret. This is used by the SDK to verify webhook signatures.
    /// It starts with a `whsec_` prefix. You can view and manage your webhook secret
    /// in the [dashboard](https://imagekit.io/dashboard/developer/webhooks). Treat
    /// the secret like a password, keep it private and do not expose it publicly.
    /// Learn more about [webhook verification](https://imagekit.io/docs/webhooks#verify-webhook-signature).
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
