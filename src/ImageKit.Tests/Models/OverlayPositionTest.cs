using System.Text.Json;
using ImageKit.Core;
using ImageKit.Exceptions;
using ImageKit.Models;

namespace ImageKit.Tests.Models;

public class OverlayPositionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OverlayPosition
        {
            Focus = Focus.Center,
            X = 0,
            Y = 0,
        };

        ApiEnum<string, Focus> expectedFocus = Focus.Center;
        X expectedX = 0;
        Y expectedY = 0;

        Assert.Equal(expectedFocus, model.Focus);
        Assert.Equal(expectedX, model.X);
        Assert.Equal(expectedY, model.Y);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OverlayPosition
        {
            Focus = Focus.Center,
            X = 0,
            Y = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OverlayPosition>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OverlayPosition
        {
            Focus = Focus.Center,
            X = 0,
            Y = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OverlayPosition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Focus> expectedFocus = Focus.Center;
        X expectedX = 0;
        Y expectedY = 0;

        Assert.Equal(expectedFocus, deserialized.Focus);
        Assert.Equal(expectedX, deserialized.X);
        Assert.Equal(expectedY, deserialized.Y);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OverlayPosition
        {
            Focus = Focus.Center,
            X = 0,
            Y = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OverlayPosition { };

        Assert.Null(model.Focus);
        Assert.False(model.RawData.ContainsKey("focus"));
        Assert.Null(model.X);
        Assert.False(model.RawData.ContainsKey("x"));
        Assert.Null(model.Y);
        Assert.False(model.RawData.ContainsKey("y"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OverlayPosition { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OverlayPosition
        {
            // Null should be interpreted as omitted for these properties
            Focus = null,
            X = null,
            Y = null,
        };

        Assert.Null(model.Focus);
        Assert.False(model.RawData.ContainsKey("focus"));
        Assert.Null(model.X);
        Assert.False(model.RawData.ContainsKey("x"));
        Assert.Null(model.Y);
        Assert.False(model.RawData.ContainsKey("y"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OverlayPosition
        {
            // Null should be interpreted as omitted for these properties
            Focus = null,
            X = null,
            Y = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OverlayPosition
        {
            Focus = Focus.Center,
            X = 0,
            Y = 0,
        };

        OverlayPosition copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FocusTest : TestBase
{
    [Theory]
    [InlineData(Focus.Center)]
    [InlineData(Focus.Top)]
    [InlineData(Focus.Left)]
    [InlineData(Focus.Bottom)]
    [InlineData(Focus.Right)]
    [InlineData(Focus.TopLeft)]
    [InlineData(Focus.TopRight)]
    [InlineData(Focus.BottomLeft)]
    [InlineData(Focus.BottomRight)]
    public void Validation_Works(Focus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Focus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Focus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Focus.Center)]
    [InlineData(Focus.Top)]
    [InlineData(Focus.Left)]
    [InlineData(Focus.Bottom)]
    [InlineData(Focus.Right)]
    [InlineData(Focus.TopLeft)]
    [InlineData(Focus.TopRight)]
    [InlineData(Focus.BottomLeft)]
    [InlineData(Focus.BottomRight)]
    public void SerializationRoundtrip_Works(Focus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Focus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Focus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Focus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Focus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class XTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        X value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        X value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        X value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<X>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        X value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<X>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class YTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        Y value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Y value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Y value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Y>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Y value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Y>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
