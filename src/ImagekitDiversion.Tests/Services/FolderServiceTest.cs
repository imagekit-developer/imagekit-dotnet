using System.Threading.Tasks;

namespace ImagekitDiversion.Tests.Services;

public class FolderServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var folder = await this.client.Folder.Create(
            new() { FolderName = "summer", ParentFolderPath = "/product/images/" },
            TestContext.Current.CancellationToken
        );
        folder.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var folder = await this.client.Folder.Delete(
            new() { FolderPath = "/folder/to/delete/" },
            TestContext.Current.CancellationToken
        );
        folder.Validate();
    }
}
