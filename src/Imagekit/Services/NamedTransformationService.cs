using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.NamedTransformations;
using Models = Imagekit.Models;

namespace Imagekit.Services;

/// <inheritdoc/>
public sealed class NamedTransformationService : INamedTransformationService
{
    readonly Lazy<INamedTransformationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INamedTransformationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IImageKitClient _client;

    /// <inheritdoc/>
    public INamedTransformationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new NamedTransformationService(this._client.WithOptions(modifier));
    }

    public NamedTransformationService(IImageKitClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new NamedTransformationServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<Models::NamedTransformation> Create(
        NamedTransformationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Models::NamedTransformation> Update(
        NamedTransformationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::NamedTransformation> Update(
        string id,
        NamedTransformationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<Models::NamedTransformation>> List(
        NamedTransformationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Models::NamedTransformation> Delete(
        NamedTransformationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::NamedTransformation> Delete(
        string id,
        NamedTransformationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::NamedTransformation> Get(
        NamedTransformationGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::NamedTransformation> Get(
        string id,
        NamedTransformationGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class NamedTransformationServiceWithRawResponse
    : INamedTransformationServiceWithRawResponse
{
    readonly IImageKitClientWithRawResponse _client;

    /// <inheritdoc/>
    public INamedTransformationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NamedTransformationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NamedTransformationServiceWithRawResponse(IImageKitClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::NamedTransformation>> Create(
        NamedTransformationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<NamedTransformationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var namedTransformation = await response
                    .Deserialize<Models::NamedTransformation>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    namedTransformation.Validate();
                }
                return namedTransformation;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::NamedTransformation>> Update(
        NamedTransformationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImageKitInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<NamedTransformationUpdateParams> request = new()
        {
            Method = ImageKitClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var namedTransformation = await response
                    .Deserialize<Models::NamedTransformation>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    namedTransformation.Validate();
                }
                return namedTransformation;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::NamedTransformation>> Update(
        string id,
        NamedTransformationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<Models::NamedTransformation>>> List(
        NamedTransformationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NamedTransformationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var namedTransformations = await response
                    .Deserialize<List<Models::NamedTransformation>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in namedTransformations)
                    {
                        item.Validate();
                    }
                }
                return namedTransformations;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::NamedTransformation>> Delete(
        NamedTransformationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImageKitInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<NamedTransformationDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var namedTransformation = await response
                    .Deserialize<Models::NamedTransformation>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    namedTransformation.Validate();
                }
                return namedTransformation;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::NamedTransformation>> Delete(
        string id,
        NamedTransformationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::NamedTransformation>> Get(
        NamedTransformationGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ImageKitInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<NamedTransformationGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var namedTransformation = await response
                    .Deserialize<Models::NamedTransformation>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    namedTransformation.Validate();
                }
                return namedTransformation;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::NamedTransformation>> Get(
        string id,
        NamedTransformationGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { ID = id }, cancellationToken);
    }
}
