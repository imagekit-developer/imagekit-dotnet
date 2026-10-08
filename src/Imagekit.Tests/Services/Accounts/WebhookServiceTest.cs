using System.Threading.Tasks;
using Imagekit.Models.Accounts.Webhooks;

namespace Imagekit.Tests.Services.Accounts;

public class WebhookServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var webhook = await this.client.Accounts.Webhooks.Create(
            new()
            {
                Endpoint = "https://example.com/imagekit/webhooks",
                Events = [WebhookEventType.VideoTransformationReady, WebhookEventType.FileCreated],
            },
            TestContext.Current.CancellationToken
        );
        webhook.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var webhook = await this.client.Accounts.Webhooks.Update(
            "65f1c2a9e4b0a1b2c3d4e5f6",
            new(),
            TestContext.Current.CancellationToken
        );
        webhook.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var webhooks = await this.client.Accounts.Webhooks.List(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in webhooks)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Accounts.Webhooks.Delete(
            "65f1c2a9e4b0a1b2c3d4e5f6",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var webhook = await this.client.Accounts.Webhooks.Get(
            "65f1c2a9e4b0a1b2c3d4e5f6",
            new(),
            TestContext.Current.CancellationToken
        );
        webhook.Validate();
    }
}
