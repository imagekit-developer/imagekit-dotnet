using System;
using ImageKit.Models.Accounts.Origins;

namespace ImageKit.Tests.Models.Accounts.Origins;

public class OriginGetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new OriginGetParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        OriginGetParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/accounts/origins/id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new OriginGetParams { ID = "id" };

        OriginGetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
