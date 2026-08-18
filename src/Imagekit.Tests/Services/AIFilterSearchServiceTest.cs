using System.Threading.Tasks;

namespace Imagekit.Tests.Services;

public class AIFilterSearchServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var aiFilterSearch = await this.client.AIFilterSearch.Create(
            new() { Prompt = "red dresses tagged summer uploaded last month" },
            TestContext.Current.CancellationToken
        );
        aiFilterSearch.Validate();
    }
}
