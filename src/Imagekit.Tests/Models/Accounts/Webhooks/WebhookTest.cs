using System;
using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Accounts.Webhooks;

namespace Imagekit.Tests.Models.Accounts.Webhooks;

public class WebhookTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Webhook
        {
            ID = "65f1c2a9e4b0a1b2c3d4e5f6",
            CreatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z"),
            Enabled = true,
            Endpoint = "https://example.com/imagekit/webhooks",
            Events = [WebhookEventType.VideoTransformationReady, WebhookEventType.FileCreated],
            Secret = "whsec_WvVlXdM3rcNkRNJ1u4H8Qq0GmZ2FEb7p",
            UpdatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z"),
        };

        string expectedID = "65f1c2a9e4b0a1b2c3d4e5f6";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z");
        bool expectedEnabled = true;
        string expectedEndpoint = "https://example.com/imagekit/webhooks";
        List<ApiEnum<string, WebhookEventType>> expectedEvents =
        [
            WebhookEventType.VideoTransformationReady,
            WebhookEventType.FileCreated,
        ];
        string expectedSecret = "whsec_WvVlXdM3rcNkRNJ1u4H8Qq0GmZ2FEb7p";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedEndpoint, model.Endpoint);
        Assert.Equal(expectedEvents.Count, model.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], model.Events[i]);
        }
        Assert.Equal(expectedSecret, model.Secret);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Webhook
        {
            ID = "65f1c2a9e4b0a1b2c3d4e5f6",
            CreatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z"),
            Enabled = true,
            Endpoint = "https://example.com/imagekit/webhooks",
            Events = [WebhookEventType.VideoTransformationReady, WebhookEventType.FileCreated],
            Secret = "whsec_WvVlXdM3rcNkRNJ1u4H8Qq0GmZ2FEb7p",
            UpdatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhook>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Webhook
        {
            ID = "65f1c2a9e4b0a1b2c3d4e5f6",
            CreatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z"),
            Enabled = true,
            Endpoint = "https://example.com/imagekit/webhooks",
            Events = [WebhookEventType.VideoTransformationReady, WebhookEventType.FileCreated],
            Secret = "whsec_WvVlXdM3rcNkRNJ1u4H8Qq0GmZ2FEb7p",
            UpdatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhook>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "65f1c2a9e4b0a1b2c3d4e5f6";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z");
        bool expectedEnabled = true;
        string expectedEndpoint = "https://example.com/imagekit/webhooks";
        List<ApiEnum<string, WebhookEventType>> expectedEvents =
        [
            WebhookEventType.VideoTransformationReady,
            WebhookEventType.FileCreated,
        ];
        string expectedSecret = "whsec_WvVlXdM3rcNkRNJ1u4H8Qq0GmZ2FEb7p";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedEndpoint, deserialized.Endpoint);
        Assert.Equal(expectedEvents.Count, deserialized.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], deserialized.Events[i]);
        }
        Assert.Equal(expectedSecret, deserialized.Secret);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Webhook
        {
            ID = "65f1c2a9e4b0a1b2c3d4e5f6",
            CreatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z"),
            Enabled = true,
            Endpoint = "https://example.com/imagekit/webhooks",
            Events = [WebhookEventType.VideoTransformationReady, WebhookEventType.FileCreated],
            Secret = "whsec_WvVlXdM3rcNkRNJ1u4H8Qq0GmZ2FEb7p",
            UpdatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Webhook
        {
            ID = "65f1c2a9e4b0a1b2c3d4e5f6",
            CreatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z"),
            Enabled = true,
            Endpoint = "https://example.com/imagekit/webhooks",
            Events = [WebhookEventType.VideoTransformationReady, WebhookEventType.FileCreated],
            Secret = "whsec_WvVlXdM3rcNkRNJ1u4H8Qq0GmZ2FEb7p",
            UpdatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z"),
        };

        Webhook copied = new(model);

        Assert.Equal(model, copied);
    }
}
