using System.Threading.Tasks;

namespace ImageKit.Tests.Services.Files;

public class VersionServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var files = await this.client.Files.Versions.List(
            "fileId",
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in files)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        var version = await this.client.Files.Versions.Delete(
            "versionId",
            new() { FileID = "fileId" },
            TestContext.Current.CancellationToken
        );
        version.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Get_Works()
    {
        var file = await this.client.Files.Versions.Get(
            "versionId",
            new() { FileID = "fileId" },
            TestContext.Current.CancellationToken
        );
        file.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Restore_Works()
    {
        var file = await this.client.Files.Versions.Restore(
            "versionId",
            new() { FileID = "fileId" },
            TestContext.Current.CancellationToken
        );
        file.Validate();
    }
}
