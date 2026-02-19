using System.Threading.Tasks;

namespace ImageKit.Tests.Services.Accounts;

public class UrlEndpointServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var urlEndpointResponse = await this.client.Accounts.UrlEndpoints.Create(
            new() { Description = "My custom URL endpoint" },
            TestContext.Current.CancellationToken
        );
        urlEndpointResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var urlEndpointResponse = await this.client.Accounts.UrlEndpoints.Update(
            "id",
            new() { Description = "My custom URL endpoint" },
            TestContext.Current.CancellationToken
        );
        urlEndpointResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var urlEndpointResponses = await this.client.Accounts.UrlEndpoints.List(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in urlEndpointResponses)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Accounts.UrlEndpoints.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var urlEndpointResponse = await this.client.Accounts.UrlEndpoints.Get(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        urlEndpointResponse.Validate();
    }
}
