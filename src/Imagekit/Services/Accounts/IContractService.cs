using System;
using System.Threading;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Accounts.Contract;

namespace Imagekit.Services.Accounts;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IContractService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IContractServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IContractService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the account's contract terms and the usage consumed against them in the
    /// current contract term. Bandwidth is in bytes; video processing units, extension
    /// units and purge cache requests are counts.
    ///
    /// <para>For an agency account, consumption includes the child accounts billed to
    /// it. A child account billed to its parent cannot call this endpoint; call it with
    /// the parent account's credentials instead.</para>
    ///
    /// <para>Contract terms are read live; consumption is refreshed periodically, not
    /// on every request. Use `asOf` to check how fresh it is. Contracts of one month or
    /// less are reported as `hasContract: false`. The response is cached for 5 minutes
    /// per account.</para>
    ///
    /// <para>Requires an API key with account management access. </para>
    /// </summary>
    Task<ContractGetResponse> Get(
        ContractGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IContractService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IContractServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IContractServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/accounts/contract</c>, but is otherwise the
    /// same as <see cref="IContractService.Get(ContractGetParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ContractGetResponse>> Get(
        ContractGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
