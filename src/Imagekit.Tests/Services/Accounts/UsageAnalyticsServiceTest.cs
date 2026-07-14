using System.Threading.Tasks;

namespace Imagekit.Tests.Services.Accounts;

public class UsageAnalyticsServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var usageAnalyticsResponse = await this.client.Accounts.UsageAnalytics.Get(
            new() { EndDate = "2019-12-27", StartDate = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        usageAnalyticsResponse.Validate();
    }
}
