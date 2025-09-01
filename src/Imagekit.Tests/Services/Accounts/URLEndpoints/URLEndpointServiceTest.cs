using System.Threading.Tasks;

namespace Imagekit.Tests.Services.Accounts.URLEndpoints;

public class URLEndpointServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var urlEndpointResponse = await this.client.Accounts.URLEndpoints.Create(
            new() { Description = "My custom URL endpoint" }
        );
        urlEndpointResponse.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var urlEndpointResponse = await this.client.Accounts.URLEndpoints.Update(
            new() { ID = "id", Description = "My custom URL endpoint" }
        );
        urlEndpointResponse.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var urlEndpointResponses = await this.client.Accounts.URLEndpoints.List();
        foreach (var item in urlEndpointResponses)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Accounts.URLEndpoints.Delete(new() { ID = "id" });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Get_Works()
    {
        var urlEndpointResponse = await this.client.Accounts.URLEndpoints.Get(new() { ID = "id" });
        urlEndpointResponse.Validate();
    }
}
