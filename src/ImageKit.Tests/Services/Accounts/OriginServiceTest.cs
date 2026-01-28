using System.Threading.Tasks;
using ImageKit.Models.Accounts.Origins;

namespace ImageKit.Tests.Services.Accounts;

public class OriginServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var originResponse = await this.client.Accounts.Origins.Create(
            new()
            {
                OriginRequest = new S3()
                {
                    AccessKey = "AKIATEST123",
                    Bucket = "test-bucket",
                    Name = "My S3 Origin",
                    SecretKey = "secrettest123",
                    BaseUrlForCanonicalHeader = "https://cdn.example.com",
                    IncludeCanonicalHeader = false,
                    Prefix = "images",
                },
            },
            TestContext.Current.CancellationToken
        );
        originResponse.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var originResponse = await this.client.Accounts.Origins.Update(
            "id",
            new()
            {
                OriginRequest = new S3()
                {
                    AccessKey = "AKIATEST123",
                    Bucket = "test-bucket",
                    Name = "My S3 Origin",
                    SecretKey = "secrettest123",
                    BaseUrlForCanonicalHeader = "https://cdn.example.com",
                    IncludeCanonicalHeader = false,
                    Prefix = "images",
                },
            },
            TestContext.Current.CancellationToken
        );
        originResponse.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var originResponses = await this.client.Accounts.Origins.List(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in originResponses)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Accounts.Origins.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Get_Works()
    {
        var originResponse = await this.client.Accounts.Origins.Get(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        originResponse.Validate();
    }
}
