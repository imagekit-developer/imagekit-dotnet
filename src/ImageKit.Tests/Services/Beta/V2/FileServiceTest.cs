using System.Text;
using System.Threading.Tasks;

namespace ImageKit.Tests.Services.Beta.V2;

public class FileServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Upload_Works()
    {
        var response = await this.client.Beta.V2.Files.Upload(
            new() { File = Encoding.UTF8.GetBytes("text"), FileName = "fileName" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
