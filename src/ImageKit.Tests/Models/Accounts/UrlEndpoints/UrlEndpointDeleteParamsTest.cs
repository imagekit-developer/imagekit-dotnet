using System;
using ImageKit.Models.Accounts.UrlEndpoints;

namespace ImageKit.Tests.Models.Accounts.UrlEndpoints;

public class UrlEndpointDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UrlEndpointDeleteParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        UrlEndpointDeleteParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/accounts/url-endpoints/id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UrlEndpointDeleteParams { ID = "id" };

        UrlEndpointDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
