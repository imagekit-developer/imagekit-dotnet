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

public sealed class ImageKitClient : IImageKitClient
{
    public HttpClient HttpClient { get; init; } = new();

    Lazy<Uri> _baseUrl = new(() =>
        new Uri(
            Environment.GetEnvironmentVariable("IMAGE_KIT_BASE_URL") ?? "https://api.imagekit.io"
        )
    );
    public Uri BaseUrl
    {
        get { return _baseUrl.Value; }
        init { _baseUrl = new(() => value); }
    }

    Lazy<string> _privateKey = new(() =>
        Environment.GetEnvironmentVariable("IMAGEKIT_PRIVATE_API_KEY")
        ?? throw new ArgumentNullException(nameof(PrivateKey))
    );
    public string PrivateKey
    {
        get { return _privateKey.Value; }
        init { _privateKey = new(() => value); }
    }

    Lazy<string?> _password = new(() =>
        Environment.GetEnvironmentVariable("OPTIONAL_IMAGEKIT_IGNORES_THIS") ?? "do_not_set"
    );
    public string? Password
    {
        get { return _password.Value; }
        init { _password = new(() => value); }
    }

    Lazy<string?> _webhookSecret = new(() =>
        Environment.GetEnvironmentVariable("IMAGEKIT_WEBHOOK_SECRET")
    );
    public string? WebhookSecret
    {
        get { return _webhookSecret.Value; }
        init { _webhookSecret = new(() => value); }
    }

    readonly Lazy<ICustomMetadataFieldService> _customMetadataFields;
    public ICustomMetadataFieldService CustomMetadataFields
    {
        get { return _customMetadataFields.Value; }
    }

    readonly Lazy<IFileService> _files;
    public IFileService Files
    {
        get { return _files.Value; }
    }

    readonly Lazy<IAssetService> _assets;
    public IAssetService Assets
    {
        get { return _assets.Value; }
    }

    readonly Lazy<ICacheService> _cache;
    public ICacheService Cache
    {
        get { return _cache.Value; }
    }

    readonly Lazy<IFolderService> _folders;
    public IFolderService Folders
    {
        get { return _folders.Value; }
    }

    readonly Lazy<IAccountService> _accounts;
    public IAccountService Accounts
    {
        get { return _accounts.Value; }
    }

    readonly Lazy<IBetaService> _beta;
    public IBetaService Beta
    {
        get { return _beta.Value; }
    }

    readonly Lazy<IWebhookService> _webhooks;
    public IWebhookService Webhooks
    {
        get { return _webhooks.Value; }
    }

    public ImageKitClient()
    {
        _customMetadataFields = new(() => new CustomMetadataFieldService(this));
        _files = new(() => new FileService(this));
        _assets = new(() => new AssetService(this));
        _cache = new(() => new CacheService(this));
        _folders = new(() => new FolderService(this));
        _accounts = new(() => new AccountService(this));
        _beta = new(() => new BetaService(this));
        _webhooks = new(() => new WebhookService(this));
    }
}
