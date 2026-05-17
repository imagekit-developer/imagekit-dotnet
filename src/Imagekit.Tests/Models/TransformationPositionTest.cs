using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models;

namespace Imagekit.Tests.Models;

public class TransformationPositionTest : TestBase
{
    [Theory]
    [InlineData(TransformationPosition.Path)]
    [InlineData(TransformationPosition.Query)]
    public void Validation_Works(TransformationPosition rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransformationPosition> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransformationPosition>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TransformationPosition.Path)]
    [InlineData(TransformationPosition.Query)]
    public void SerializationRoundtrip_Works(TransformationPosition rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransformationPosition> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransformationPosition>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransformationPosition>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransformationPosition>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
