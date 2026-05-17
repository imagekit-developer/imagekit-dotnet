using System.Threading.Tasks;

namespace Imagekit.Tests.Services;

public class FolderServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var folder = await this.client.Folders.Create(
            new() { FolderName = "summer", ParentFolderPath = "/product/images/" },
            TestContext.Current.CancellationToken
        );
        folder.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var folder = await this.client.Folders.Delete(
            new() { FolderPath = "/folder/to/delete/" },
            TestContext.Current.CancellationToken
        );
        folder.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Copy_Works()
    {
        var response = await this.client.Folders.Copy(
            new()
            {
                DestinationPath = "/path/of/destination/folder",
                SourceFolderPath = "/path/of/source/folder",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Move_Works()
    {
        var response = await this.client.Folders.Move(
            new()
            {
                DestinationPath = "/path/of/destination/folder",
                SourceFolderPath = "/path/of/source/folder",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Rename_Works()
    {
        var response = await this.client.Folders.Rename(
            new() { FolderPath = "/path/of/folder", NewFolderName = "new-folder-name" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
