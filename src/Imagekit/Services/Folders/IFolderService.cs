using System.Threading.Tasks;
using Imagekit.Models.Folders;
using Imagekit.Services.Folders.Job;

namespace Imagekit.Services.Folders;

public interface IFolderService
{
    IJobService Job { get; }

    /// <summary>
    /// This will create a new folder. You can specify the folder name and location
    /// of the parent folder where this new folder should be created.
    /// </summary>
    Task<FolderCreateResponse> Create(FolderCreateParams parameters);

    /// <summary>
    /// This will delete a folder and all its contents permanently. The API returns
    /// an empty response.
    /// </summary>
    Task<FolderDeleteResponse> Delete(FolderDeleteParams parameters);

    /// <summary>
    /// This will copy one folder into another. The selected folder, its nested folders,
    /// files, and their versions (in `includeVersions` is set to true) are copied
    /// in this operation. Note: If any file at the destination has the same name
    /// as the source file, then the source file and its versions will be appended
    /// to the destination file version history.
    /// </summary>
    Task<FolderCopyResponse> Copy(FolderCopyParams parameters);

    /// <summary>
    /// This will move one folder into another. The selected folder, its nested folders,
    /// files, and their versions are moved in this operation. Note: If any file at
    /// the destination has the same name as the source file, then the source file
    /// and its versions will be appended to the destination file version history.
    /// </summary>
    Task<FolderMoveResponse> Move(FolderMoveParams parameters);

    /// <summary>
    /// This API allows you to rename an existing folder. The folder and all its nested
    /// assets and sub-folders will remain unchanged, but their paths will be updated
    /// to reflect the new folder name.
    /// </summary>
    Task<FolderRenameResponse> Rename(FolderRenameParams parameters);
}
