using System.Threading.Tasks;

namespace Imagekit.Tests.Services.Cache;

public class InvalidationServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var invalidation = await this.client.Cache.Invalidation.Create(
            new() { UrlValue = "https://ik.imagekit.io/your_imagekit_id/default-image.jpg" },
            TestContext.Current.CancellationToken
        );
        invalidation.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var invalidation = await this.client.Cache.Invalidation.Get(
            "requestId",
            new(),
            TestContext.Current.CancellationToken
        );
        invalidation.Validate();
    }
}
