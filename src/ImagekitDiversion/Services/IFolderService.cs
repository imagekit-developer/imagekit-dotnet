using System;
using System.Threading;
using System.Threading.Tasks;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Folder;

namespace ImagekitDiversion.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFolderService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFolderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFolderService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This will create a new folder. You can specify the folder name and location of
    /// the parent folder where this new folder should be created.
    /// </summary>
    Task<FolderCreateResponse> Create(
        FolderCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This will delete a folder and all its contents permanently. The API returns an
    /// empty response.
    /// </summary>
    Task<FolderDeleteResponse> Delete(
        FolderDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFolderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFolderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFolderServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/folder</c>, but is otherwise the
    /// same as <see cref="IFolderService.Create(FolderCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FolderCreateResponse>> Create(
        FolderCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/folder</c>, but is otherwise the
    /// same as <see cref="IFolderService.Delete(FolderDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FolderDeleteResponse>> Delete(
        FolderDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
