using System.Threading.Tasks;

namespace ImagekitDiversion.Tests.Services.Files;

public class PurgeServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Cache_Works()
    {
        var response = await this.client.Files.Purge.Cache(
            new() { UrlValue = "https://ik.imagekit.io/your_imagekit_id/default-image.jpg" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Status_Works()
    {
        var response = await this.client.Files.Purge.Status(
            "requestId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
