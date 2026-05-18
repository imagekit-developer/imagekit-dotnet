using System.Threading.Tasks;

namespace Imagekit.Tests.Services.Folders;

public class JobServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var job = await this.client.Folders.Job.Get(
            "jobId",
            new(),
            TestContext.Current.CancellationToken
        );
        job.Validate();
    }
}
