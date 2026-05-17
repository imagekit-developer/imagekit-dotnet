using System.Text;
using System.Threading.Tasks;

namespace ImagekitDiversion.Tests.Services.Api.V1;

public class FileServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Upload_Works()
    {
        var upload = await this.client.Api.V1.Files.Upload(
            new() { File = Encoding.UTF8.GetBytes("Example data"), FileName = "fileName" },
            TestContext.Current.CancellationToken
        );
        upload.Validate();
    }
}
