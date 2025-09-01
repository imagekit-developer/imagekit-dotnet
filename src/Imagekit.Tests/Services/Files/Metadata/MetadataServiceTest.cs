using System.Threading.Tasks;

namespace Imagekit.Tests.Services.Files.Metadata;

public class MetadataServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Get_Works()
    {
        var metadata = await this.client.Files.Metadata.Get(new() { FileID = "fileId" });
        metadata.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetFromURL_Works()
    {
        var metadata = await this.client.Files.Metadata.GetFromURL(
            new() { URL = "https://example.com" }
        );
        metadata.Validate();
    }
}
