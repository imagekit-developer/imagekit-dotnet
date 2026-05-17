using System.Threading.Tasks;

namespace ImagekitDiversion.Tests.Services;

public class AccountServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetUsage_Works()
    {
        var response = await this.client.Accounts.GetUsage(
            new() { EndDate = "2019-12-27", StartDate = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
