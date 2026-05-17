using System;
using ImagekitDiversion.Models.Files.Purge;

namespace ImagekitDiversion.Tests.Models.Files.Purge;

public class PurgeStatusParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PurgeStatusParams { RequestID = "requestId" };

        string expectedRequestID = "requestId";

        Assert.Equal(expectedRequestID, parameters.RequestID);
    }

    [Fact]
    public void Url_Works()
    {
        PurgeStatusParams parameters = new() { RequestID = "requestId" };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/files/purge/requestId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PurgeStatusParams { RequestID = "requestId" };

        PurgeStatusParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
