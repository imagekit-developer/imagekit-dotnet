using System.Threading.Tasks;

namespace Imagekit.Tests.Services.Folders.Job;

public class JobServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Get_Works()
    {
        var job = await this.client.Folders.Job.Get(new() { JobID = "jobId" });
        job.Validate();
    }
}
