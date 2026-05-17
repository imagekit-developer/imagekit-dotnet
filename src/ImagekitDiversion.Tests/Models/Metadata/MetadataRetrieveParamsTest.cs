using System;
using ImagekitDiversion.Models.Metadata;

namespace ImagekitDiversion.Tests.Models.Metadata;

public class MetadataRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MetadataRetrieveParams { UrlValue = "https://example.com" };

        string expectedUrlValue = "https://example.com";

        Assert.Equal(expectedUrlValue, parameters.UrlValue);
    }

    [Fact]
    public void Url_Works()
    {
        MetadataRetrieveParams parameters = new() { UrlValue = "https://example.com" };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

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
        var parameters = new MetadataRetrieveParams { UrlValue = "https://example.com" };

        MetadataRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
