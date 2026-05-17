using System.Threading.Tasks;

namespace ImagekitDiversion.Tests.Services.Files;

public class VersionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var fileDetails = await this.client.Files.Versions.Retrieve(
            "versionId",
            new() { FileID = "fileId" },
            TestContext.Current.CancellationToken
        );
        fileDetails.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var fileDetails = await this.client.Files.Versions.List(
            "fileId",
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in fileDetails)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var version = await this.client.Files.Versions.Delete(
            "versionId",
            new() { FileID = "fileId" },
            TestContext.Current.CancellationToken
        );
        version.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Restore_Works()
    {
        var fileDetails = await this.client.Files.Versions.Restore(
            "versionId",
            new() { FileID = "fileId" },
            TestContext.Current.CancellationToken
        );
        fileDetails.Validate();
    }
}
