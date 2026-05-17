using System.Threading.Tasks;

namespace ImagekitDiversion.Tests.Services;

public class DummyServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Test_Works()
    {
        await this.client.Dummy.Test(new(), TestContext.Current.CancellationToken);
    }
}
