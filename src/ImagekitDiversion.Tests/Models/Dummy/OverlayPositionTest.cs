using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.Dummy;

namespace ImagekitDiversion.Tests.Models.Dummy;

public class OverlayPositionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OverlayPosition
        {
            AnchorPoint = AnchorPoint.Top,
            Focus = Focus.Center,
            X = 0,
            XCenter = 0,
            Y = 0,
            YCenter = 0,
        };

        ApiEnum<string, AnchorPoint> expectedAnchorPoint = AnchorPoint.Top;
        ApiEnum<string, Focus> expectedFocus = Focus.Center;
        X expectedX = 0;
        XCenter expectedXCenter = 0;
        Y expectedY = 0;
        YCenter expectedYCenter = 0;

        Assert.Equal(expectedAnchorPoint, model.AnchorPoint);
        Assert.Equal(expectedFocus, model.Focus);
        Assert.Equal(expectedX, model.X);
        Assert.Equal(expectedXCenter, model.XCenter);
        Assert.Equal(expectedY, model.Y);
        Assert.Equal(expectedYCenter, model.YCenter);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OverlayPosition
        {
            AnchorPoint = AnchorPoint.Top,
            Focus = Focus.Center,
            X = 0,
            XCenter = 0,
            Y = 0,
            YCenter = 0,
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
            AnchorPoint = AnchorPoint.Top,
            Focus = Focus.Center,
            X = 0,
            XCenter = 0,
            Y = 0,
            YCenter = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OverlayPosition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AnchorPoint> expectedAnchorPoint = AnchorPoint.Top;
        ApiEnum<string, Focus> expectedFocus = Focus.Center;
        X expectedX = 0;
        XCenter expectedXCenter = 0;
        Y expectedY = 0;
        YCenter expectedYCenter = 0;

        Assert.Equal(expectedAnchorPoint, deserialized.AnchorPoint);
        Assert.Equal(expectedFocus, deserialized.Focus);
        Assert.Equal(expectedX, deserialized.X);
        Assert.Equal(expectedXCenter, deserialized.XCenter);
        Assert.Equal(expectedY, deserialized.Y);
        Assert.Equal(expectedYCenter, deserialized.YCenter);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OverlayPosition
        {
            AnchorPoint = AnchorPoint.Top,
            Focus = Focus.Center,
            X = 0,
            XCenter = 0,
            Y = 0,
            YCenter = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OverlayPosition { };

        Assert.Null(model.AnchorPoint);
        Assert.False(model.RawData.ContainsKey("anchorPoint"));
        Assert.Null(model.Focus);
        Assert.False(model.RawData.ContainsKey("focus"));
        Assert.Null(model.X);
        Assert.False(model.RawData.ContainsKey("x"));
        Assert.Null(model.XCenter);
        Assert.False(model.RawData.ContainsKey("xCenter"));
        Assert.Null(model.Y);
        Assert.False(model.RawData.ContainsKey("y"));
        Assert.Null(model.YCenter);
        Assert.False(model.RawData.ContainsKey("yCenter"));
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
            AnchorPoint = null,
            Focus = null,
            X = null,
            XCenter = null,
            Y = null,
            YCenter = null,
        };

        Assert.Null(model.AnchorPoint);
        Assert.False(model.RawData.ContainsKey("anchorPoint"));
        Assert.Null(model.Focus);
        Assert.False(model.RawData.ContainsKey("focus"));
        Assert.Null(model.X);
        Assert.False(model.RawData.ContainsKey("x"));
        Assert.Null(model.XCenter);
        Assert.False(model.RawData.ContainsKey("xCenter"));
        Assert.Null(model.Y);
        Assert.False(model.RawData.ContainsKey("y"));
        Assert.Null(model.YCenter);
        Assert.False(model.RawData.ContainsKey("yCenter"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OverlayPosition
        {
            // Null should be interpreted as omitted for these properties
            AnchorPoint = null,
            Focus = null,
            X = null,
            XCenter = null,
            Y = null,
            YCenter = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OverlayPosition
        {
            AnchorPoint = AnchorPoint.Top,
            Focus = Focus.Center,
            X = 0,
            XCenter = 0,
            Y = 0,
            YCenter = 0,
        };

        OverlayPosition copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AnchorPointTest : TestBase
{
    [Theory]
    [InlineData(AnchorPoint.Top)]
    [InlineData(AnchorPoint.Left)]
    [InlineData(AnchorPoint.Right)]
    [InlineData(AnchorPoint.Bottom)]
    [InlineData(AnchorPoint.TopLeft)]
    [InlineData(AnchorPoint.TopRight)]
    [InlineData(AnchorPoint.BottomLeft)]
    [InlineData(AnchorPoint.BottomRight)]
    [InlineData(AnchorPoint.Center)]
    public void Validation_Works(AnchorPoint rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AnchorPoint> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AnchorPoint>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AnchorPoint.Top)]
    [InlineData(AnchorPoint.Left)]
    [InlineData(AnchorPoint.Right)]
    [InlineData(AnchorPoint.Bottom)]
    [InlineData(AnchorPoint.TopLeft)]
    [InlineData(AnchorPoint.TopRight)]
    [InlineData(AnchorPoint.BottomLeft)]
    [InlineData(AnchorPoint.BottomRight)]
    [InlineData(AnchorPoint.Center)]
    public void SerializationRoundtrip_Works(AnchorPoint rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AnchorPoint> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AnchorPoint>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AnchorPoint>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AnchorPoint>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
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

public class XCenterTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        XCenter value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        XCenter value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        XCenter value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<XCenter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        XCenter value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<XCenter>(
            element,
            ModelBase.SerializerOptions
        );

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

public class YCenterTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        YCenter value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        YCenter value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        YCenter value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<YCenter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        YCenter value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<YCenter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
