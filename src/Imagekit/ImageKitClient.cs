using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Exceptions;
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
    readonly ClientOptions _options = new();

    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    public Uri BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    public TimeSpan Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    public string PrivateKey
    {
        get { return this._options.PrivateKey; }
        init { this._options.PrivateKey = value; }
    }

    public string? Password
    {
        get { return this._options.Password; }
        init { this._options.Password = value; }
    }

    public string? WebhookSecret
    {
        get { return this._options.WebhookSecret; }
        init { this._options.WebhookSecret = value; }
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

    public async Task<HttpResponse> Execute<T>(HttpRequest<T> request)
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(request.Method, request.Params.Url(this))
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this);
        using CancellationTokenSource cts = new(this.Timeout);
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e1)
        {
            throw new ImageKitIOException("I/O exception", e1);
        }
        if (!responseMessage.IsSuccessStatusCode)
        {
            try
            {
                throw ImageKitExceptionFactory.CreateApiException(
                    responseMessage.StatusCode,
                    await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false)
                );
            }
            catch (HttpRequestException e)
            {
                throw new ImageKitIOException("I/O Exception", e);
            }
            finally
            {
                responseMessage.Dispose();
            }
        }
        return new() { Message = responseMessage };
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
