using System.Threading.Tasks;

namespace ImageKit.Tests.Services;

public class AssetServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var assets = await this.client.Assets.List(new(), TestContext.Current.CancellationToken);
        foreach (var item in assets)
        {
            item.Validate();
        }
    }
}
