using System.Threading.Tasks;

namespace ImagekitDiversion.Tests.Services.Files;

public class BatchServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var batch = await this.client.Files.Batch.Delete(
            new() { FileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"] },
            TestContext.Current.CancellationToken
        );
        batch.Validate();
    }
}
