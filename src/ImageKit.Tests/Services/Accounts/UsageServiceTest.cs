using System.Threading.Tasks;

namespace ImageKit.Tests.Services.Accounts;

public class UsageServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Get_Works()
    {
        var usage = await this.client.Accounts.Usage.Get(
            new() { EndDate = "2019-12-27", StartDate = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        usage.Validate();
    }
}
