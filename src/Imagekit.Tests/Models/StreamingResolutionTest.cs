using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models;

namespace Imagekit.Tests.Models;

public class StreamingResolutionTest : TestBase
{
    [Theory]
    [InlineData(StreamingResolution.V240)]
    [InlineData(StreamingResolution.V360)]
    [InlineData(StreamingResolution.V480)]
    [InlineData(StreamingResolution.V720)]
    [InlineData(StreamingResolution.V1080)]
    [InlineData(StreamingResolution.V1440)]
    [InlineData(StreamingResolution.V2160)]
    public void Validation_Works(StreamingResolution rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StreamingResolution> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StreamingResolution>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StreamingResolution.V240)]
    [InlineData(StreamingResolution.V360)]
    [InlineData(StreamingResolution.V480)]
    [InlineData(StreamingResolution.V720)]
    [InlineData(StreamingResolution.V1080)]
    [InlineData(StreamingResolution.V1440)]
    [InlineData(StreamingResolution.V2160)]
    public void SerializationRoundtrip_Works(StreamingResolution rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StreamingResolution> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StreamingResolution>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StreamingResolution>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StreamingResolution>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
