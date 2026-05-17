using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Files.Purge;

namespace ImagekitDiversion.Tests.Models.Files.Purge;

public class PurgeCacheResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PurgeCacheResponse { RequestID = "requestId" };

        string expectedRequestID = "requestId";

        Assert.Equal(expectedRequestID, model.RequestID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PurgeCacheResponse { RequestID = "requestId" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PurgeCacheResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PurgeCacheResponse { RequestID = "requestId" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PurgeCacheResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRequestID = "requestId";

        Assert.Equal(expectedRequestID, deserialized.RequestID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PurgeCacheResponse { RequestID = "requestId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PurgeCacheResponse { };

        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("requestId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PurgeCacheResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PurgeCacheResponse
        {
            // Null should be interpreted as omitted for these properties
            RequestID = null,
        };

        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("requestId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PurgeCacheResponse
        {
            // Null should be interpreted as omitted for these properties
            RequestID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PurgeCacheResponse { RequestID = "requestId" };

        PurgeCacheResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
