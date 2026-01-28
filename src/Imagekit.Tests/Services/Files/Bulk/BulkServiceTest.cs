using System.Threading.Tasks;

namespace Imagekit.Tests.Services.Files.Bulk;

public class BulkServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        var bulk = await this.client.Files.Bulk.Delete(
            new() { FileIDs = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"] }
        );
        bulk.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task AddTags_Works()
    {
        var response = await this.client.Files.Bulk.AddTags(
            new()
            {
                FileIDs = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
                Tags = ["t-shirt", "round-neck", "sale2019"],
            }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RemoveAITags_Works()
    {
        var response = await this.client.Files.Bulk.RemoveAITags(
            new()
            {
                AITags = ["t-shirt", "round-neck", "sale2019"],
                FileIDs = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
            }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RemoveTags_Works()
    {
        var response = await this.client.Files.Bulk.RemoveTags(
            new()
            {
                FileIDs = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
                Tags = ["t-shirt", "round-neck", "sale2019"],
            }
        );
        response.Validate();
    }
}
