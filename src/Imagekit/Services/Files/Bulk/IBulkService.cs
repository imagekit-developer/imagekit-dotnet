using System.Threading.Tasks;
using Imagekit.Models.Files.Bulk;

namespace Imagekit.Services.Files.Bulk;

public interface IBulkService
{
    /// <summary>
    /// This API deletes multiple files and all their file versions permanently.
    ///
    /// Note: If a file or specific transformation has been requested in the past,
    /// then the response is cached. Deleting a file does not purge the cache. You
    /// can purge the cache using purge cache API.
    ///
    /// A maximum of 100 files can be deleted at a time.
    /// </summary>
    Task<BulkDeleteResponse> Delete(BulkDeleteParams parameters);

    /// <summary>
    /// This API adds tags to multiple files in bulk. A maximum of 50 files can be
    /// specified at a time.
    /// </summary>
    Task<BulkAddTagsResponse> AddTags(BulkAddTagsParams parameters);

    /// <summary>
    /// This API removes AITags from multiple files in bulk. A maximum of 50 files
    /// can be specified at a time.
    /// </summary>
    Task<BulkRemoveAITagsResponse> RemoveAITags(BulkRemoveAITagsParams parameters);

    /// <summary>
    /// This API removes tags from multiple files in bulk. A maximum of 50 files can
    /// be specified at a time.
    /// </summary>
    Task<BulkRemoveTagsResponse> RemoveTags(BulkRemoveTagsParams parameters);
}
