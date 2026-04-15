using System;
using ImageKit.Models.Cache.Invalidation;

namespace ImageKit.Tests.Models.Cache.Invalidation;

public class InvalidationCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvalidationCreateParams
        {
            UrlValue = "https://ik.imagekit.io/your_imagekit_id/default-image.jpg",
        };

        string expectedUrlValue = "https://ik.imagekit.io/your_imagekit_id/default-image.jpg";

        Assert.Equal(expectedUrlValue, parameters.UrlValue);
    }

    [Fact]
    public void Url_Works()
    {
        InvalidationCreateParams parameters = new()
        {
            UrlValue = "https://ik.imagekit.io/your_imagekit_id/default-image.jpg",
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/files/purge"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvalidationCreateParams
        {
            UrlValue = "https://ik.imagekit.io/your_imagekit_id/default-image.jpg",
        };

        InvalidationCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
