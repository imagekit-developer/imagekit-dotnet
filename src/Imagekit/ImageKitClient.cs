using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Services;

namespace Imagekit;

/// <inheritdoc/>
public sealed class ImageKitClient : IImageKitClient
{
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string PrivateKey
    {
        get { return this._options.PrivateKey; }
        init { this._options.PrivateKey = value; }
    }

    /// <inheritdoc/>
    public string? Password
    {
        get { return this._options.Password; }
        init { this._options.Password = value; }
    }

    /// <inheritdoc/>
    public string? WebhookSecret
    {
        get { return this._options.WebhookSecret; }
        init { this._options.WebhookSecret = value; }
    }

    readonly Lazy<IImageKitClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IImageKitClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public IImageKitClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ImageKitClient(modifier(this._options));
    }

    readonly Lazy<IDummyService> _dummy;
    public IDummyService Dummy
    {
        get { return _dummy.Value; }
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

    readonly Lazy<ISavedExtensionService> _savedExtensions;
    public ISavedExtensionService SavedExtensions
    {
        get { return _savedExtensions.Value; }
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

    public void Dispose() => this.HttpClient.Dispose();

    public ImageKitClient()
    {
        _options = new();

        _withRawResponse = new(() => new ImageKitClientWithRawResponse(this._options));
        _dummy = new(() => new DummyService(this));
        _customMetadataFields = new(() => new CustomMetadataFieldService(this));
        _files = new(() => new FileService(this));
        _savedExtensions = new(() => new SavedExtensionService(this));
        _assets = new(() => new AssetService(this));
        _cache = new(() => new CacheService(this));
        _folders = new(() => new FolderService(this));
        _accounts = new(() => new AccountService(this));
        _beta = new(() => new BetaService(this));
        _webhooks = new(() => new WebhookService(this));
    }

    public ImageKitClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}

/// <inheritdoc/>
public sealed class ImageKitClientWithRawResponse : IImageKitClientWithRawResponse
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    internal static HttpMethod PatchMethod = new("PATCH");

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string PrivateKey
    {
        get { return this._options.PrivateKey; }
        init { this._options.PrivateKey = value; }
    }

    /// <inheritdoc/>
    public string? Password
    {
        get { return this._options.Password; }
        init { this._options.Password = value; }
    }

    /// <inheritdoc/>
    public string? WebhookSecret
    {
        get { return this._options.WebhookSecret; }
        init { this._options.WebhookSecret = value; }
    }

    /// <inheritdoc/>
    public IImageKitClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ImageKitClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<IDummyServiceWithRawResponse> _dummy;
    public IDummyServiceWithRawResponse Dummy
    {
        get { return _dummy.Value; }
    }

    readonly Lazy<ICustomMetadataFieldServiceWithRawResponse> _customMetadataFields;
    public ICustomMetadataFieldServiceWithRawResponse CustomMetadataFields
    {
        get { return _customMetadataFields.Value; }
    }

    readonly Lazy<IFileServiceWithRawResponse> _files;
    public IFileServiceWithRawResponse Files
    {
        get { return _files.Value; }
    }

    readonly Lazy<ISavedExtensionServiceWithRawResponse> _savedExtensions;
    public ISavedExtensionServiceWithRawResponse SavedExtensions
    {
        get { return _savedExtensions.Value; }
    }

    readonly Lazy<IAssetServiceWithRawResponse> _assets;
    public IAssetServiceWithRawResponse Assets
    {
        get { return _assets.Value; }
    }

    readonly Lazy<ICacheServiceWithRawResponse> _cache;
    public ICacheServiceWithRawResponse Cache
    {
        get { return _cache.Value; }
    }

    readonly Lazy<IFolderServiceWithRawResponse> _folders;
    public IFolderServiceWithRawResponse Folders
    {
        get { return _folders.Value; }
    }

    readonly Lazy<IAccountServiceWithRawResponse> _accounts;
    public IAccountServiceWithRawResponse Accounts
    {
        get { return _accounts.Value; }
    }

    readonly Lazy<IBetaServiceWithRawResponse> _beta;
    public IBetaServiceWithRawResponse Beta
    {
        get { return _beta.Value; }
    }

    readonly Lazy<IWebhookServiceWithRawResponse> _webhooks;
    public IWebhookServiceWithRawResponse Webhooks
    {
        get { return _webhooks.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, retries, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw ImageKitExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new ImageKitIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        int retryCount,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        if (!requestMessage.Headers.Contains("x-stainless-retry-count"))
        {
            requestMessage.Headers.Add("x-stainless-retry-count", retryCount.ToString());
        }
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
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
        catch (HttpRequestException e)
        {
            throw new ImageKitIOException("I/O exception", e);
        }
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (
            apiBackoff != null
            && apiBackoff > TimeSpan.Zero
            && apiBackoff < TimeSpan.FromMinutes(1)
        )
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is ImageKitIOException;
    }

    public void Dispose() => this.HttpClient.Dispose();

    public ImageKitClientWithRawResponse()
    {
        _options = new();

        _dummy = new(() => new DummyServiceWithRawResponse(this));
        _customMetadataFields = new(() => new CustomMetadataFieldServiceWithRawResponse(this));
        _files = new(() => new FileServiceWithRawResponse(this));
        _savedExtensions = new(() => new SavedExtensionServiceWithRawResponse(this));
        _assets = new(() => new AssetServiceWithRawResponse(this));
        _cache = new(() => new CacheServiceWithRawResponse(this));
        _folders = new(() => new FolderServiceWithRawResponse(this));
        _accounts = new(() => new AccountServiceWithRawResponse(this));
        _beta = new(() => new BetaServiceWithRawResponse(this));
        _webhooks = new(() => new WebhookServiceWithRawResponse(this));
    }

    public ImageKitClientWithRawResponse(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
