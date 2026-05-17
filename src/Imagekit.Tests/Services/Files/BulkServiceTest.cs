using System.Threading.Tasks;

namespace Imagekit.Tests.Services.Files;

public class BulkServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var bulk = await this.client.Files.Bulk.Delete(
            new() { FileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"] },
            TestContext.Current.CancellationToken
        );
        bulk.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task AddTags_Works()
    {
        var response = await this.client.Files.Bulk.AddTags(
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
    public async Task RemoveAITags_Works()
    {
        var response = await this.client.Files.Bulk.RemoveAITags(
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
        var response = await this.client.Files.Bulk.RemoveTags(
            new()
            {
                FileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
                Tags = ["t-shirt", "round-neck", "sale2019"],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
