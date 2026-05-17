using System;
using ImagekitDiversion.Models.Files.Purge;

namespace ImagekitDiversion.Tests.Models.Files.Purge;

public class PurgeCacheParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PurgeCacheParams
        {
            UrlValue = "https://ik.imagekit.io/your_imagekit_id/default-image.jpg",
        };

        string expectedUrlValue = "https://ik.imagekit.io/your_imagekit_id/default-image.jpg";

        Assert.Equal(expectedUrlValue, parameters.UrlValue);
    }

    [Fact]
    public void Url_Works()
    {
        PurgeCacheParams parameters = new()
        {
            UrlValue = "https://ik.imagekit.io/your_imagekit_id/default-image.jpg",
        };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/files/purge"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PurgeCacheParams
        {
            UrlValue = "https://ik.imagekit.io/your_imagekit_id/default-image.jpg",
        };

        PurgeCacheParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
