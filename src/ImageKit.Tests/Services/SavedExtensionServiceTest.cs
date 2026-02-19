using System.Threading.Tasks;
using Models = ImageKit.Models;

namespace ImageKit.Tests.Services;

public class SavedExtensionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var savedExtension = await this.client.SavedExtensions.Create(
            new()
            {
                Config = new Models::RemoveBg()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                Description = "Analyzes vehicle images for type, condition, and quality assessment",
                Name = "Car Quality Analysis",
            },
            TestContext.Current.CancellationToken
        );
        savedExtension.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var savedExtension = await this.client.SavedExtensions.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        savedExtension.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var savedExtensions = await this.client.SavedExtensions.List(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in savedExtensions)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.SavedExtensions.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var savedExtension = await this.client.SavedExtensions.Get(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        savedExtension.Validate();
    }
}
