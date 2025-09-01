using System.Threading.Tasks;

namespace Imagekit.Tests.Services.Files.Versions;

public class VersionServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var files = await this.client.Files.Versions.List(new() { FileID = "fileId" });
        foreach (var item in files)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        var version = await this.client.Files.Versions.Delete(
            new() { FileID = "fileId", VersionID = "versionId" }
        );
        version.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Get_Works()
    {
        var file = await this.client.Files.Versions.Get(
            new() { FileID = "fileId", VersionID = "versionId" }
        );
        file.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Restore_Works()
    {
        var file = await this.client.Files.Versions.Restore(
            new() { FileID = "fileId", VersionID = "versionId" }
        );
        file.Validate();
    }
}
