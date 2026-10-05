using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.Accounts.Webhooks;

namespace Imagekit.Tests.Models.Accounts.Webhooks;

public class WebhookEventTypeTest : TestBase
{
    [Theory]
    [InlineData(WebhookEventType.VideoTransformationAccepted)]
    [InlineData(WebhookEventType.VideoTransformationReady)]
    [InlineData(WebhookEventType.VideoTransformationError)]
    [InlineData(WebhookEventType.UploadPreTransformSuccess)]
    [InlineData(WebhookEventType.UploadPreTransformError)]
    [InlineData(WebhookEventType.UploadPostTransformSuccess)]
    [InlineData(WebhookEventType.UploadPostTransformError)]
    [InlineData(WebhookEventType.FileCreated)]
    [InlineData(WebhookEventType.FileUpdated)]
    [InlineData(WebhookEventType.FileDeleted)]
    [InlineData(WebhookEventType.FileVersionCreated)]
    [InlineData(WebhookEventType.FileVersionDeleted)]
    public void Validation_Works(WebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookEventType.VideoTransformationAccepted)]
    [InlineData(WebhookEventType.VideoTransformationReady)]
    [InlineData(WebhookEventType.VideoTransformationError)]
    [InlineData(WebhookEventType.UploadPreTransformSuccess)]
    [InlineData(WebhookEventType.UploadPreTransformError)]
    [InlineData(WebhookEventType.UploadPostTransformSuccess)]
    [InlineData(WebhookEventType.UploadPostTransformError)]
    [InlineData(WebhookEventType.FileCreated)]
    [InlineData(WebhookEventType.FileUpdated)]
    [InlineData(WebhookEventType.FileDeleted)]
    [InlineData(WebhookEventType.FileVersionCreated)]
    [InlineData(WebhookEventType.FileVersionDeleted)]
    public void SerializationRoundtrip_Works(WebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
