using System.Threading.Tasks;

namespace Imagekit.Tests.Services;

public class DummyServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        await this.client.Dummy.Create(new(), TestContext.Current.CancellationToken);
    }
}
