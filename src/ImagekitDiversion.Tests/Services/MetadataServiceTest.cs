using System.Threading.Tasks;

namespace ImagekitDiversion.Tests.Services;

public class MetadataServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var metadata = await this.client.Metadata.Retrieve(
            new() { UrlValue = "https://example.com" },
            TestContext.Current.CancellationToken
        );
        metadata.Validate();
    }
}
