using System.Threading.Tasks;

namespace ImagekitDiversion.Tests.Services;

public class BulkJobServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CopyFolder_Works()
    {
        var job = await this.client.BulkJobs.CopyFolder(
            new()
            {
                DestinationPath = "/path/of/destination/folder",
                SourceFolderPath = "/path/of/source/folder",
            },
            TestContext.Current.CancellationToken
        );
        job.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task MoveFolder_Works()
    {
        var job = await this.client.BulkJobs.MoveFolder(
            new()
            {
                DestinationPath = "/path/of/destination/folder",
                SourceFolderPath = "/path/of/source/folder",
            },
            TestContext.Current.CancellationToken
        );
        job.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RenameFolder_Works()
    {
        var job = await this.client.BulkJobs.RenameFolder(
            new() { FolderPath = "/path/of/folder", NewFolderName = "new-folder-name" },
            TestContext.Current.CancellationToken
        );
        job.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveStatus_Works()
    {
        var response = await this.client.BulkJobs.RetrieveStatus(
            "jobId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
