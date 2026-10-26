using System.Threading.Tasks;

namespace Imagekit.Tests.Services;

public class TagServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var tags = await this.client.Tags.List(new(), TestContext.Current.CancellationToken);
        tags.Validate();
    }
}
