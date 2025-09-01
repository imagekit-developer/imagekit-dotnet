using System.Collections.Generic;
using System.Threading.Tasks;
using Imagekit.Models.Files;
using Imagekit.Models.Files.Versions;

namespace Imagekit.Services.Files.Versions;

public interface IVersionService
{
    /// <summary>
    /// This API returns details of all versions of a file.
    /// </summary>
    Task<List<File>> List(VersionListParams parameters);

    /// <summary>
    /// This API deletes a non-current file version permanently. The API returns
    /// an empty response.
    ///
    /// Note: If you want to delete all versions of a file, use the delete file API.
    /// </summary>
    Task<VersionDeleteResponse> Delete(VersionDeleteParams parameters);

    /// <summary>
    /// This API returns an object with details or attributes of a file version.
    /// </summary>
    Task<File> Get(VersionGetParams parameters);

    /// <summary>
    /// This API restores a file version as the current file version.
    /// </summary>
    Task<File> Restore(VersionRestoreParams parameters);
}
