using System.Threading.Tasks;

namespace Imagekit.Tests.Services.Folders;

public class FolderServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var folder = await this.client.Folders.Create(
            new() { FolderName = "summer", ParentFolderPath = "/product/images/" }
        );
        folder.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        var folder = await this.client.Folders.Delete(new() { FolderPath = "/folder/to/delete/" });
        folder.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Copy_Works()
    {
        var response = await this.client.Folders.Copy(
            new()
            {
                DestinationPath = "/path/of/destination/folder",
                SourceFolderPath = "/path/of/source/folder",
            }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Move_Works()
    {
        var response = await this.client.Folders.Move(
            new()
            {
                DestinationPath = "/path/of/destination/folder",
                SourceFolderPath = "/path/of/source/folder",
            }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Rename_Works()
    {
        var response = await this.client.Folders.Rename(
            new() { FolderPath = "/path/of/folder", NewFolderName = "new-folder-name" }
        );
        response.Validate();
    }
}
