using System.Threading.Tasks;
using ImagekitDiversion.Models.Accounts.Origins;

namespace ImagekitDiversion.Tests.Services.Accounts;

public class OriginServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var origin = await this.client.Accounts.Origins.Create(
            new()
            {
                OriginRequest = new OriginRequestS3()
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
        origin.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var origin = await this.client.Accounts.Origins.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        origin.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var origin = await this.client.Accounts.Origins.Update(
            "id",
            new()
            {
                OriginRequest = new OriginRequestS3()
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
        origin.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var origins = await this.client.Accounts.Origins.List(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in origins)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Accounts.Origins.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
