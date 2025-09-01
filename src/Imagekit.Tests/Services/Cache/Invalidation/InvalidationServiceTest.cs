using System.Threading.Tasks;

namespace Imagekit.Tests.Services.Cache.Invalidation;

public class InvalidationServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var invalidation = await this.client.Cache.Invalidation.Create(
            new() { URL = "https://ik.imagekit.io/your_imagekit_id/default-image.jpg" }
        );
        invalidation.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Get_Works()
    {
        var invalidation = await this.client.Cache.Invalidation.Get(
            new() { RequestID = "requestId" }
        );
        invalidation.Validate();
    }
}
