using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Accounts.Webhooks;

namespace Imagekit.Services.Accounts;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IWebhookService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWebhookServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new webhook and returns the created object, including the generated
    /// signing `secret`.
    ///
    /// <para>ImageKit sends a `POST` request to the webhook `endpoint` whenever one of
    /// the subscribed `events` occurs. Use the `secret` to verify the signature of each
    /// request. Learn more about [webhooks](https://imagekit.io/docs/webhooks).</para>
    ///
    /// <para>You can create up to 3 webhooks per account. </para>
    /// </summary>
    Task<Webhook> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates the webhook identified by `id` and returns the updated object. Only the
    /// fields included in the request body are changed.
    ///
    /// <para>When `events` is provided, it replaces the existing list of subscribed
    /// events. The signing `secret` can't be changed. </para>
    /// </summary>
    Task<Webhook> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WebhookUpdateParams, CancellationToken)"/>
    Task<Webhook> Update(
        string id,
        WebhookUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns an array of all webhooks configured for your account.
    /// </summary>
    Task<List<Webhook>> List(
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently deletes the webhook identified by `id`. ImageKit stops sending
    /// events to its endpoint.
    /// </summary>
    Task Delete(WebhookDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(WebhookDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the webhook identified by `id`.
    /// </summary>
    Task<Webhook> Get(WebhookGetParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Get(WebhookGetParams, CancellationToken)"/>
    Task<Webhook> Get(
        string id,
        WebhookGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWebhookService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWebhookServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/accounts/webhooks</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Create(WebhookCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Webhook>> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/accounts/webhooks/{id}</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Update(WebhookUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Webhook>> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WebhookUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Webhook>> Update(
        string id,
        WebhookUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/accounts/webhooks</c>, but is otherwise the
    /// same as <see cref="IWebhookService.List(WebhookListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<Webhook>>> List(
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/accounts/webhooks/{id}</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Delete(WebhookDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(WebhookDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/accounts/webhooks/{id}</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Get(WebhookGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Webhook>> Get(
        WebhookGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(WebhookGetParams, CancellationToken)"/>
    Task<HttpResponse<Webhook>> Get(
        string id,
        WebhookGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
