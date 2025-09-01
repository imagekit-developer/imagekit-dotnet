using System.Threading.Tasks;

namespace Imagekit.Tests.Services.Beta.V2.Files;

public class FileServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Upload_Works()
    {
        var response = await this.client.Beta.V2.Files.Upload(
            new() { File = "a value", FileName = "fileName" }
        );
        response.Validate();
    }
}
