using System;
using System.Threading.Tasks;

namespace Imagekit.Tests.Services.Accounts.Usage;

public class UsageServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Get_Works()
    {
        var usage = await this.client.Accounts.Usage.Get(
            new()
            {
                EndDate = DateOnly.Parse("2019-12-27"),
                StartDate = DateOnly.Parse("2019-12-27"),
            }
        );
        usage.Validate();
    }
}
