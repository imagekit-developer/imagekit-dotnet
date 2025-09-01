using System.Threading.Tasks;

namespace Imagekit.Tests.Services.Assets;

public class AssetServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var assets = await this.client.Assets.List();
        foreach (var item in assets)
        {
            item.Validate();
        }
    }
}
