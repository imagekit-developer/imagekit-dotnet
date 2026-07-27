using System;
using Imagekit.Models.Accounts.Origins;

namespace Imagekit.Tests.Models.Accounts.Origins;

public class OriginCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new OriginCreateParams
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
                UseIamRole = true,
            },
        };

        OriginRequest expectedOriginRequest = new S3()
        {
            AccessKey = "AKIATEST123",
            Bucket = "test-bucket",
            Name = "My S3 Origin",
            SecretKey = "secrettest123",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "images",
            UseIamRole = true,
        };

        Assert.Equal(expectedOriginRequest, parameters.OriginRequest);
    }

    [Fact]
    public void Url_Works()
    {
        OriginCreateParams parameters = new()
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
                UseIamRole = true,
            },
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/accounts/origins"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new OriginCreateParams
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
                UseIamRole = true,
            },
        };

        OriginCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
