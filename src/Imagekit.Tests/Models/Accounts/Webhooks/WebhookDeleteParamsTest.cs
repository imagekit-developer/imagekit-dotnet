using System;
using Imagekit.Models.Accounts.Webhooks;

namespace Imagekit.Tests.Models.Accounts.Webhooks;

public class WebhookDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookDeleteParams { ID = "65f1c2a9e4b0a1b2c3d4e5f6" };

        string expectedID = "65f1c2a9e4b0a1b2c3d4e5f6";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        WebhookDeleteParams parameters = new() { ID = "65f1c2a9e4b0a1b2c3d4e5f6" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.imagekit.io/v1/accounts/webhooks/65f1c2a9e4b0a1b2c3d4e5f6"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookDeleteParams { ID = "65f1c2a9e4b0a1b2c3d4e5f6" };

        WebhookDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
