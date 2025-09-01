using System.Threading.Tasks;

namespace Imagekit.Tests.Services.Files;

public class FileServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var file = await this.client.Files.Update(new() { FileID = "fileId" });
        file.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Files.Delete(new() { FileID = "fileId" });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Copy_Works()
    {
        var response = await this.client.Files.Copy(
            new()
            {
                DestinationPath = "/folder/to/copy/into/",
                SourceFilePath = "/path/to/file.jpg",
            }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Get_Works()
    {
        var file = await this.client.Files.Get(new() { FileID = "fileId" });
        file.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Move_Works()
    {
        var response = await this.client.Files.Move(
            new()
            {
                DestinationPath = "/folder/to/move/into/",
                SourceFilePath = "/path/to/file.jpg",
            }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Rename_Works()
    {
        var response = await this.client.Files.Rename(
            new() { FilePath = "/path/to/file.jpg", NewFileName = "newFileName.jpg" }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Upload_Works()
    {
        var response = await this.client.Files.Upload(
            new() { File = "a value", FileName = "fileName" }
        );
        response.Validate();
    }
}
