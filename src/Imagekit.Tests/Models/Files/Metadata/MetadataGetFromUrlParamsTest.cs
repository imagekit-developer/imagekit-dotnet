using System;
using Imagekit.Models.Files.Metadata;

namespace Imagekit.Tests.Models.Files.Metadata;

public class MetadataGetFromUrlParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MetadataGetFromUrlParams { UrlValue = "https://example.com" };

        string expectedUrlValue = "https://example.com";

        Assert.Equal(expectedUrlValue, parameters.UrlValue);
    }

    [Fact]
    public void Url_Works()
    {
        MetadataGetFromUrlParams parameters = new() { UrlValue = "https://example.com" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.imagekit.io/v1/metadata?url=https%3a%2f%2fexample.com"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MetadataGetFromUrlParams { UrlValue = "https://example.com" };

        MetadataGetFromUrlParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
