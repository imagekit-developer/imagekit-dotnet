using System.Threading.Tasks;

namespace Imagekit.Tests.Services;

public class AssetServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var assets = await this.client.Assets.List(new(), TestContext.Current.CancellationToken);
        foreach (var item in assets)
        {
            item.Validate();
        }
    }
}
