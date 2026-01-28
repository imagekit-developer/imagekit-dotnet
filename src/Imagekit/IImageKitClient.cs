using System;
using System.Net.Http;
using System.Threading.Tasks;
using Imagekit.Core;
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

    ICustomMetadataFieldService CustomMetadataFields { get; }

    IFileService Files { get; }

    IAssetService Assets { get; }

    ICacheService Cache { get; }

    IFolderService Folders { get; }

    IAccountService Accounts { get; }

    IBetaService Beta { get; }

    IWebhookService Webhooks { get; }

    Task<HttpResponse> Execute<T>(HttpRequest<T> request)
        where T : ParamsBase;
}
