using System.Threading.Tasks;

namespace Imagekit.Tests.Services;

public class NamedTransformationServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var namedTransformation = await this.client.NamedTransformations.Create(
            new() { Name = "small_thumbnail", Transformation = "w-150,h-150,fo-center,cm-resize" },
            TestContext.Current.CancellationToken
        );
        namedTransformation.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var namedTransformation = await this.client.NamedTransformations.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        namedTransformation.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var namedTransformations = await this.client.NamedTransformations.List(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in namedTransformations)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var namedTransformation = await this.client.NamedTransformations.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        namedTransformation.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var namedTransformation = await this.client.NamedTransformations.Get(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        namedTransformation.Validate();
    }
}
