using System.Text.Json;
using ImageKit.Core;
using ImageKit.Exceptions;
using ImageKit.Models;

namespace ImageKit.Tests.Models;

public class TextOverlayTransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TextOverlayTransformation
        {
            Alpha = 1,
            Background = "background",
            Flip = Flip.H,
            FontColor = "fontColor",
            FontFamily = "fontFamily",
            FontSize = 0,
            InnerAlignment = InnerAlignment.Left,
            LineHeight = 0,
            Padding = 0,
            Radius = 0,
            Rotation = 0,
            Typography = "typography",
            Width = 0,
        };

        double expectedAlpha = 1;
        string expectedBackground = "background";
        ApiEnum<string, Flip> expectedFlip = Flip.H;
        string expectedFontColor = "fontColor";
        string expectedFontFamily = "fontFamily";
        FontSize expectedFontSize = 0;
        ApiEnum<string, InnerAlignment> expectedInnerAlignment = InnerAlignment.Left;
        LineHeight expectedLineHeight = 0;
        Padding expectedPadding = 0;
        TextOverlayTransformationRadius expectedRadius = 0;
        Rotation expectedRotation = 0;
        string expectedTypography = "typography";
        TextOverlayTransformationWidth expectedWidth = 0;

        Assert.Equal(expectedAlpha, model.Alpha);
        Assert.Equal(expectedBackground, model.Background);
        Assert.Equal(expectedFlip, model.Flip);
        Assert.Equal(expectedFontColor, model.FontColor);
        Assert.Equal(expectedFontFamily, model.FontFamily);
        Assert.Equal(expectedFontSize, model.FontSize);
        Assert.Equal(expectedInnerAlignment, model.InnerAlignment);
        Assert.Equal(expectedLineHeight, model.LineHeight);
        Assert.Equal(expectedPadding, model.Padding);
        Assert.Equal(expectedRadius, model.Radius);
        Assert.Equal(expectedRotation, model.Rotation);
        Assert.Equal(expectedTypography, model.Typography);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TextOverlayTransformation
        {
            Alpha = 1,
            Background = "background",
            Flip = Flip.H,
            FontColor = "fontColor",
            FontFamily = "fontFamily",
            FontSize = 0,
            InnerAlignment = InnerAlignment.Left,
            LineHeight = 0,
            Padding = 0,
            Radius = 0,
            Rotation = 0,
            Typography = "typography",
            Width = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextOverlayTransformation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TextOverlayTransformation
        {
            Alpha = 1,
            Background = "background",
            Flip = Flip.H,
            FontColor = "fontColor",
            FontFamily = "fontFamily",
            FontSize = 0,
            InnerAlignment = InnerAlignment.Left,
            LineHeight = 0,
            Padding = 0,
            Radius = 0,
            Rotation = 0,
            Typography = "typography",
            Width = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextOverlayTransformation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAlpha = 1;
        string expectedBackground = "background";
        ApiEnum<string, Flip> expectedFlip = Flip.H;
        string expectedFontColor = "fontColor";
        string expectedFontFamily = "fontFamily";
        FontSize expectedFontSize = 0;
        ApiEnum<string, InnerAlignment> expectedInnerAlignment = InnerAlignment.Left;
        LineHeight expectedLineHeight = 0;
        Padding expectedPadding = 0;
        TextOverlayTransformationRadius expectedRadius = 0;
        Rotation expectedRotation = 0;
        string expectedTypography = "typography";
        TextOverlayTransformationWidth expectedWidth = 0;

        Assert.Equal(expectedAlpha, deserialized.Alpha);
        Assert.Equal(expectedBackground, deserialized.Background);
        Assert.Equal(expectedFlip, deserialized.Flip);
        Assert.Equal(expectedFontColor, deserialized.FontColor);
        Assert.Equal(expectedFontFamily, deserialized.FontFamily);
        Assert.Equal(expectedFontSize, deserialized.FontSize);
        Assert.Equal(expectedInnerAlignment, deserialized.InnerAlignment);
        Assert.Equal(expectedLineHeight, deserialized.LineHeight);
        Assert.Equal(expectedPadding, deserialized.Padding);
        Assert.Equal(expectedRadius, deserialized.Radius);
        Assert.Equal(expectedRotation, deserialized.Rotation);
        Assert.Equal(expectedTypography, deserialized.Typography);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TextOverlayTransformation
        {
            Alpha = 1,
            Background = "background",
            Flip = Flip.H,
            FontColor = "fontColor",
            FontFamily = "fontFamily",
            FontSize = 0,
            InnerAlignment = InnerAlignment.Left,
            LineHeight = 0,
            Padding = 0,
            Radius = 0,
            Rotation = 0,
            Typography = "typography",
            Width = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TextOverlayTransformation { };

        Assert.Null(model.Alpha);
        Assert.False(model.RawData.ContainsKey("alpha"));
        Assert.Null(model.Background);
        Assert.False(model.RawData.ContainsKey("background"));
        Assert.Null(model.Flip);
        Assert.False(model.RawData.ContainsKey("flip"));
        Assert.Null(model.FontColor);
        Assert.False(model.RawData.ContainsKey("fontColor"));
        Assert.Null(model.FontFamily);
        Assert.False(model.RawData.ContainsKey("fontFamily"));
        Assert.Null(model.FontSize);
        Assert.False(model.RawData.ContainsKey("fontSize"));
        Assert.Null(model.InnerAlignment);
        Assert.False(model.RawData.ContainsKey("innerAlignment"));
        Assert.Null(model.LineHeight);
        Assert.False(model.RawData.ContainsKey("lineHeight"));
        Assert.Null(model.Padding);
        Assert.False(model.RawData.ContainsKey("padding"));
        Assert.Null(model.Radius);
        Assert.False(model.RawData.ContainsKey("radius"));
        Assert.Null(model.Rotation);
        Assert.False(model.RawData.ContainsKey("rotation"));
        Assert.Null(model.Typography);
        Assert.False(model.RawData.ContainsKey("typography"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TextOverlayTransformation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TextOverlayTransformation
        {
            // Null should be interpreted as omitted for these properties
            Alpha = null,
            Background = null,
            Flip = null,
            FontColor = null,
            FontFamily = null,
            FontSize = null,
            InnerAlignment = null,
            LineHeight = null,
            Padding = null,
            Radius = null,
            Rotation = null,
            Typography = null,
            Width = null,
        };

        Assert.Null(model.Alpha);
        Assert.False(model.RawData.ContainsKey("alpha"));
        Assert.Null(model.Background);
        Assert.False(model.RawData.ContainsKey("background"));
        Assert.Null(model.Flip);
        Assert.False(model.RawData.ContainsKey("flip"));
        Assert.Null(model.FontColor);
        Assert.False(model.RawData.ContainsKey("fontColor"));
        Assert.Null(model.FontFamily);
        Assert.False(model.RawData.ContainsKey("fontFamily"));
        Assert.Null(model.FontSize);
        Assert.False(model.RawData.ContainsKey("fontSize"));
        Assert.Null(model.InnerAlignment);
        Assert.False(model.RawData.ContainsKey("innerAlignment"));
        Assert.Null(model.LineHeight);
        Assert.False(model.RawData.ContainsKey("lineHeight"));
        Assert.Null(model.Padding);
        Assert.False(model.RawData.ContainsKey("padding"));
        Assert.Null(model.Radius);
        Assert.False(model.RawData.ContainsKey("radius"));
        Assert.Null(model.Rotation);
        Assert.False(model.RawData.ContainsKey("rotation"));
        Assert.Null(model.Typography);
        Assert.False(model.RawData.ContainsKey("typography"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TextOverlayTransformation
        {
            // Null should be interpreted as omitted for these properties
            Alpha = null,
            Background = null,
            Flip = null,
            FontColor = null,
            FontFamily = null,
            FontSize = null,
            InnerAlignment = null,
            LineHeight = null,
            Padding = null,
            Radius = null,
            Rotation = null,
            Typography = null,
            Width = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TextOverlayTransformation
        {
            Alpha = 1,
            Background = "background",
            Flip = Flip.H,
            FontColor = "fontColor",
            FontFamily = "fontFamily",
            FontSize = 0,
            InnerAlignment = InnerAlignment.Left,
            LineHeight = 0,
            Padding = 0,
            Radius = 0,
            Rotation = 0,
            Typography = "typography",
            Width = 0,
        };

        TextOverlayTransformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FlipTest : TestBase
{
    [Theory]
    [InlineData(Flip.H)]
    [InlineData(Flip.V)]
    [InlineData(Flip.HV)]
    [InlineData(Flip.VH)]
    public void Validation_Works(Flip rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Flip> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Flip>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Flip.H)]
    [InlineData(Flip.V)]
    [InlineData(Flip.HV)]
    [InlineData(Flip.VH)]
    public void SerializationRoundtrip_Works(Flip rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Flip> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Flip>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Flip>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Flip>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FontSizeTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        FontSize value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        FontSize value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        FontSize value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FontSize>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        FontSize value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FontSize>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InnerAlignmentTest : TestBase
{
    [Theory]
    [InlineData(InnerAlignment.Left)]
    [InlineData(InnerAlignment.Right)]
    [InlineData(InnerAlignment.Center)]
    public void Validation_Works(InnerAlignment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InnerAlignment> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InnerAlignment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InnerAlignment.Left)]
    [InlineData(InnerAlignment.Right)]
    [InlineData(InnerAlignment.Center)]
    public void SerializationRoundtrip_Works(InnerAlignment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InnerAlignment> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InnerAlignment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InnerAlignment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InnerAlignment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class LineHeightTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        LineHeight value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        LineHeight value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        LineHeight value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LineHeight>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        LineHeight value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LineHeight>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PaddingTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        Padding value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Padding value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Padding value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Padding>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Padding value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Padding>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TextOverlayTransformationRadiusTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        TextOverlayTransformationRadius value = 0;
        value.Validate();
    }

    [Fact]
    public void MaxValidationWorks()
    {
        TextOverlayTransformationRadius value = new TextOverlayTransformationRadiusUnionMember1();
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        TextOverlayTransformationRadius value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        TextOverlayTransformationRadius value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextOverlayTransformationRadius>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MaxSerializationRoundtripWorks()
    {
        TextOverlayTransformationRadius value = new TextOverlayTransformationRadiusUnionMember1();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextOverlayTransformationRadius>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        TextOverlayTransformationRadius value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextOverlayTransformationRadius>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TextOverlayTransformationRadiusUnionMember1Test : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new TextOverlayTransformationRadiusUnionMember1();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<TextOverlayTransformationRadiusUnionMember1>(
            JsonSerializer.SerializeToElement("max"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<TextOverlayTransformationRadiusUnionMember1>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new TextOverlayTransformationRadiusUnionMember1();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextOverlayTransformationRadiusUnionMember1>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<TextOverlayTransformationRadiusUnionMember1>(
            JsonSerializer.SerializeToElement("max"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextOverlayTransformationRadiusUnionMember1>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<TextOverlayTransformationRadiusUnionMember1>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextOverlayTransformationRadiusUnionMember1>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class RotationTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        Rotation value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Rotation value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Rotation value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rotation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Rotation value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rotation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TextOverlayTransformationWidthTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        TextOverlayTransformationWidth value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        TextOverlayTransformationWidth value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        TextOverlayTransformationWidth value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextOverlayTransformationWidth>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        TextOverlayTransformationWidth value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextOverlayTransformationWidth>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
