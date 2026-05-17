using System;
using ImagekitDiversion.Models.Accounts.Origins;

namespace ImagekitDiversion.Tests.Models.Accounts.Origins;

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

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/accounts/origins/id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new OriginDeleteParams { ID = "id" };

        OriginDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
