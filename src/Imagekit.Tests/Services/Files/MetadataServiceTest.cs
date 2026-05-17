using System.Threading.Tasks;

namespace Imagekit.Tests.Services.Files;

public class MetadataServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var metadata = await this.client.Files.Metadata.Get(
            "fileId",
            new(),
            TestContext.Current.CancellationToken
        );
        metadata.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetFromUrl_Works()
    {
        var metadata = await this.client.Files.Metadata.GetFromUrl(
            new() { UrlValue = "https://example.com" },
            TestContext.Current.CancellationToken
        );
        metadata.Validate();
    }
}
