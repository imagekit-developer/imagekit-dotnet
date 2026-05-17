using System.Threading.Tasks;

namespace ImagekitDiversion.Tests.Services.Accounts;

public class UrlEndpointServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var urlEndpoint = await this.client.Accounts.UrlEndpoints.Create(
            new() { Description = "My custom URL endpoint" },
            TestContext.Current.CancellationToken
        );
        urlEndpoint.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var urlEndpoint = await this.client.Accounts.UrlEndpoints.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        urlEndpoint.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var urlEndpoint = await this.client.Accounts.UrlEndpoints.Update(
            "id",
            new() { Description = "My custom URL endpoint" },
            TestContext.Current.CancellationToken
        );
        urlEndpoint.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var urlEndpoints = await this.client.Accounts.UrlEndpoints.List(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in urlEndpoints)
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
}
