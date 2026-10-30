using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Tags;

namespace Imagekit.Services;

/// <inheritdoc/>
public sealed class TagService : ITagService
{
    readonly Lazy<ITagServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITagServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public ITagService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TagService(this._client.WithOptions(modifier));
    }

    public TagService(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TagServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<TagListPage> List(
        TagListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TagServiceWithRawResponse : ITagServiceWithRawResponse
{
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITagServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TagServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TagServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TagListPage>> List(
        TagListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TagListParams> request = new() { Method = HttpMethod.Get, Params = parameters };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<TagListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new TagListPage(this, parameters, page);
            }
        );
    }
}
