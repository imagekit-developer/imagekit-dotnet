using System.Threading.Tasks;

namespace Imagekit.Tests.Services.Files.Bulk;

public class BulkServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        var bulk = await this.client.Files.Bulk.Delete(new() { FileIDs = ["string"] });
        bulk.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task AddTags_Works()
    {
        var response = await this.client.Files.Bulk.AddTags(
            new() { FileIDs = ["string"], Tags = ["string"] }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RemoveAITags_Works()
    {
        var response = await this.client.Files.Bulk.RemoveAITags(
            new() { AITags = ["string"], FileIDs = ["string"] }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RemoveTags_Works()
    {
        var response = await this.client.Files.Bulk.RemoveTags(
            new() { FileIDs = ["string"], Tags = ["string"] }
        );
        response.Validate();
    }
}
