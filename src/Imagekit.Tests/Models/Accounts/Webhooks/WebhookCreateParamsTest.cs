using System;
using System.Collections.Generic;
using Imagekit.Core;
using Imagekit.Models.Accounts.Webhooks;

namespace Imagekit.Tests.Models.Accounts.Webhooks;

public class WebhookCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookCreateParams
        {
            Endpoint = "https://example.com/imagekit/webhooks",
            Events = [WebhookEventType.VideoTransformationReady, WebhookEventType.FileCreated],
            Enabled = true,
        };

        string expectedEndpoint = "https://example.com/imagekit/webhooks";
        List<ApiEnum<string, WebhookEventType>> expectedEvents =
        [
            WebhookEventType.VideoTransformationReady,
            WebhookEventType.FileCreated,
        ];
        bool expectedEnabled = true;

        Assert.Equal(expectedEndpoint, parameters.Endpoint);
        Assert.Equal(expectedEvents.Count, parameters.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], parameters.Events[i]);
        }
        Assert.Equal(expectedEnabled, parameters.Enabled);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookCreateParams
        {
            Endpoint = "https://example.com/imagekit/webhooks",
            Events = [WebhookEventType.VideoTransformationReady, WebhookEventType.FileCreated],
        };

        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WebhookCreateParams
        {
            Endpoint = "https://example.com/imagekit/webhooks",
            Events = [WebhookEventType.VideoTransformationReady, WebhookEventType.FileCreated],

            // Null should be interpreted as omitted for these properties
            Enabled = null,
        };

        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookCreateParams parameters = new()
        {
            Endpoint = "https://example.com/imagekit/webhooks",
            Events = [WebhookEventType.VideoTransformationReady, WebhookEventType.FileCreated],
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/accounts/webhooks"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookCreateParams
        {
            Endpoint = "https://example.com/imagekit/webhooks",
            Events = [WebhookEventType.VideoTransformationReady, WebhookEventType.FileCreated],
            Enabled = true,
        };

        WebhookCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
