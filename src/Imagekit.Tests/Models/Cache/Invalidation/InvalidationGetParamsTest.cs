using System;
using Imagekit.Models.Cache.Invalidation;

namespace Imagekit.Tests.Models.Cache.Invalidation;

public class InvalidationGetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvalidationGetParams { RequestID = "requestId" };

        string expectedRequestID = "requestId";

        Assert.Equal(expectedRequestID, parameters.RequestID);
    }

    [Fact]
    public void Url_Works()
    {
        InvalidationGetParams parameters = new() { RequestID = "requestId" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/files/purge/requestId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvalidationGetParams { RequestID = "requestId" };

        InvalidationGetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
