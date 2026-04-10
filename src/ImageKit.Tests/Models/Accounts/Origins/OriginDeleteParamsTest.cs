using System;
using ImageKit.Models.Accounts.Origins;

namespace ImageKit.Tests.Models.Accounts.Origins;

public class OriginDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new OriginDeleteParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        OriginDeleteParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key" });

        Assert.Equal(new Uri("https://api.imagekit.io/v1/accounts/origins/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new OriginDeleteParams { ID = "id" };

        OriginDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
