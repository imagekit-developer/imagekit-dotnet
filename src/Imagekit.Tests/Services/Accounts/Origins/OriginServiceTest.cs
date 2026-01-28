using System.Threading.Tasks;
using Imagekit.Models.Accounts.Origins.OriginRequestProperties;

namespace Imagekit.Tests.Services.Accounts.Origins;

public class OriginServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var originResponse = await this.client.Accounts.Origins.Create(
            new()
            {
                Origin = new S3()
                {
                    AccessKey = "AKIATEST123",
                    Bucket = "test-bucket",
                    Name = "My S3 Origin",
                    SecretKey = "secrettest123",
                    BaseURLForCanonicalHeader = "https://cdn.example.com",
                    IncludeCanonicalHeader = false,
                    Prefix = "images",
                },
            }
        );
        originResponse.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var originResponse = await this.client.Accounts.Origins.Update(
            new()
            {
                ID = "id",
                Origin = new S3()
                {
                    AccessKey = "AKIATEST123",
                    Bucket = "test-bucket",
                    Name = "My S3 Origin",
                    SecretKey = "secrettest123",
                    BaseURLForCanonicalHeader = "https://cdn.example.com",
                    IncludeCanonicalHeader = false,
                    Prefix = "images",
                },
            }
        );
        originResponse.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var originResponses = await this.client.Accounts.Origins.List();
        foreach (var item in originResponses)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Accounts.Origins.Delete(new() { ID = "id" });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Get_Works()
    {
        var originResponse = await this.client.Accounts.Origins.Get(new() { ID = "id" });
        originResponse.Validate();
    }
}
