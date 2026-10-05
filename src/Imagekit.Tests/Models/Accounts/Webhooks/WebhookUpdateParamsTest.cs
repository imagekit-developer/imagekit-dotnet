using System;
using System.Collections.Generic;
using Imagekit.Core;
using Imagekit.Models.Accounts.Webhooks;

namespace Imagekit.Tests.Models.Accounts.Webhooks;

public class WebhookUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookUpdateParams
        {
            ID = "65f1c2a9e4b0a1b2c3d4e5f6",
            Enabled = false,
            Endpoint = "https://example.com/imagekit/webhooks",
            Events =
            [
                WebhookEventType.VideoTransformationReady,
                WebhookEventType.VideoTransformationError,
            ],
        };

        string expectedID = "65f1c2a9e4b0a1b2c3d4e5f6";
        bool expectedEnabled = false;
        string expectedEndpoint = "https://example.com/imagekit/webhooks";
        List<ApiEnum<string, WebhookEventType>> expectedEvents =
        [
            WebhookEventType.VideoTransformationReady,
            WebhookEventType.VideoTransformationError,
        ];

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedEnabled, parameters.Enabled);
        Assert.Equal(expectedEndpoint, parameters.Endpoint);
        Assert.NotNull(parameters.Events);
        Assert.Equal(expectedEvents.Count, parameters.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], parameters.Events[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookUpdateParams { ID = "65f1c2a9e4b0a1b2c3d4e5f6" };

        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.Endpoint);
        Assert.False(parameters.RawBodyData.ContainsKey("endpoint"));
        Assert.Null(parameters.Events);
        Assert.False(parameters.RawBodyData.ContainsKey("events"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WebhookUpdateParams
        {
            ID = "65f1c2a9e4b0a1b2c3d4e5f6",

            // Null should be interpreted as omitted for these properties
            Enabled = null,
            Endpoint = null,
            Events = null,
        };

        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.Endpoint);
        Assert.False(parameters.RawBodyData.ContainsKey("endpoint"));
        Assert.Null(parameters.Events);
        Assert.False(parameters.RawBodyData.ContainsKey("events"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookUpdateParams parameters = new() { ID = "65f1c2a9e4b0a1b2c3d4e5f6" };

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
        var parameters = new WebhookUpdateParams
        {
            ID = "65f1c2a9e4b0a1b2c3d4e5f6",
            Enabled = false,
            Endpoint = "https://example.com/imagekit/webhooks",
            Events =
            [
                WebhookEventType.VideoTransformationReady,
                WebhookEventType.VideoTransformationError,
            ],
        };

        WebhookUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
