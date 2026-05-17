using System.Threading.Tasks;

namespace ImagekitDiversion.Tests.Services;

public class FileServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var files = await this.client.Files.List(new(), TestContext.Current.CancellationToken);
        foreach (var item in files)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Files.Delete("fileId", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task AddTags_Works()
    {
        var response = await this.client.Files.AddTags(
            new()
            {
                FileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
                Tags = ["t-shirt", "round-neck", "sale2019"],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Copy_Works()
    {
        var response = await this.client.Files.Copy(
            new()
            {
                DestinationPath = "/folder/to/copy/into/",
                SourceFilePath = "/path/to/file.jpg",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Move_Works()
    {
        var response = await this.client.Files.Move(
            new()
            {
                DestinationPath = "/folder/to/move/into/",
                SourceFilePath = "/path/to/file.jpg",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RemoveAITags_Works()
    {
        var response = await this.client.Files.RemoveAITags(
            new()
            {
                AITags = ["t-shirt", "round-neck", "sale2019"],
                FileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RemoveTags_Works()
    {
        var response = await this.client.Files.RemoveTags(
            new()
            {
                FileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
                Tags = ["t-shirt", "round-neck", "sale2019"],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Rename_Works()
    {
        var response = await this.client.Files.Rename(
            new() { FilePath = "/path/to/file.jpg", NewFileName = "newFileName.jpg" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveMetadata_Works()
    {
        var metadata = await this.client.Files.RetrieveMetadata(
            "fileId",
            new(),
            TestContext.Current.CancellationToken
        );
        metadata.Validate();
    }
}
