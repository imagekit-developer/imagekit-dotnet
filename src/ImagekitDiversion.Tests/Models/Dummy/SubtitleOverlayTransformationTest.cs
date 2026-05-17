using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.Dummy;

namespace ImagekitDiversion.Tests.Models.Dummy;

public class SubtitleOverlayTransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubtitleOverlayTransformation
        {
            Background = "background",
            Color = "color",
            FontFamily = "fontFamily",
            FontOutline = "fontOutline",
            FontShadow = "fontShadow",
            FontSize = 0,
            Typography = Typography.B,
        };

        string expectedBackground = "background";
        string expectedColor = "color";
        string expectedFontFamily = "fontFamily";
        string expectedFontOutline = "fontOutline";
        string expectedFontShadow = "fontShadow";
        double expectedFontSize = 0;
        ApiEnum<string, Typography> expectedTypography = Typography.B;

        Assert.Equal(expectedBackground, model.Background);
        Assert.Equal(expectedColor, model.Color);
        Assert.Equal(expectedFontFamily, model.FontFamily);
        Assert.Equal(expectedFontOutline, model.FontOutline);
        Assert.Equal(expectedFontShadow, model.FontShadow);
        Assert.Equal(expectedFontSize, model.FontSize);
        Assert.Equal(expectedTypography, model.Typography);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubtitleOverlayTransformation
        {
            Background = "background",
            Color = "color",
            FontFamily = "fontFamily",
            FontOutline = "fontOutline",
            FontShadow = "fontShadow",
            FontSize = 0,
            Typography = Typography.B,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubtitleOverlayTransformation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubtitleOverlayTransformation
        {
            Background = "background",
            Color = "color",
            FontFamily = "fontFamily",
            FontOutline = "fontOutline",
            FontShadow = "fontShadow",
            FontSize = 0,
            Typography = Typography.B,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubtitleOverlayTransformation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBackground = "background";
        string expectedColor = "color";
        string expectedFontFamily = "fontFamily";
        string expectedFontOutline = "fontOutline";
        string expectedFontShadow = "fontShadow";
        double expectedFontSize = 0;
        ApiEnum<string, Typography> expectedTypography = Typography.B;

        Assert.Equal(expectedBackground, deserialized.Background);
        Assert.Equal(expectedColor, deserialized.Color);
        Assert.Equal(expectedFontFamily, deserialized.FontFamily);
        Assert.Equal(expectedFontOutline, deserialized.FontOutline);
        Assert.Equal(expectedFontShadow, deserialized.FontShadow);
        Assert.Equal(expectedFontSize, deserialized.FontSize);
        Assert.Equal(expectedTypography, deserialized.Typography);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubtitleOverlayTransformation
        {
            Background = "background",
            Color = "color",
            FontFamily = "fontFamily",
            FontOutline = "fontOutline",
            FontShadow = "fontShadow",
            FontSize = 0,
            Typography = Typography.B,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubtitleOverlayTransformation { };

        Assert.Null(model.Background);
        Assert.False(model.RawData.ContainsKey("background"));
        Assert.Null(model.Color);
        Assert.False(model.RawData.ContainsKey("color"));
        Assert.Null(model.FontFamily);
        Assert.False(model.RawData.ContainsKey("fontFamily"));
        Assert.Null(model.FontOutline);
        Assert.False(model.RawData.ContainsKey("fontOutline"));
        Assert.Null(model.FontShadow);
        Assert.False(model.RawData.ContainsKey("fontShadow"));
        Assert.Null(model.FontSize);
        Assert.False(model.RawData.ContainsKey("fontSize"));
        Assert.Null(model.Typography);
        Assert.False(model.RawData.ContainsKey("typography"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubtitleOverlayTransformation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubtitleOverlayTransformation
        {
            // Null should be interpreted as omitted for these properties
            Background = null,
            Color = null,
            FontFamily = null,
            FontOutline = null,
            FontShadow = null,
            FontSize = null,
            Typography = null,
        };

        Assert.Null(model.Background);
        Assert.False(model.RawData.ContainsKey("background"));
        Assert.Null(model.Color);
        Assert.False(model.RawData.ContainsKey("color"));
        Assert.Null(model.FontFamily);
        Assert.False(model.RawData.ContainsKey("fontFamily"));
        Assert.Null(model.FontOutline);
        Assert.False(model.RawData.ContainsKey("fontOutline"));
        Assert.Null(model.FontShadow);
        Assert.False(model.RawData.ContainsKey("fontShadow"));
        Assert.Null(model.FontSize);
        Assert.False(model.RawData.ContainsKey("fontSize"));
        Assert.Null(model.Typography);
        Assert.False(model.RawData.ContainsKey("typography"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubtitleOverlayTransformation
        {
            // Null should be interpreted as omitted for these properties
            Background = null,
            Color = null,
            FontFamily = null,
            FontOutline = null,
            FontShadow = null,
            FontSize = null,
            Typography = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubtitleOverlayTransformation
        {
            Background = "background",
            Color = "color",
            FontFamily = "fontFamily",
            FontOutline = "fontOutline",
            FontShadow = "fontShadow",
            FontSize = 0,
            Typography = Typography.B,
        };

        SubtitleOverlayTransformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypographyTest : TestBase
{
    [Theory]
    [InlineData(Typography.B)]
    [InlineData(Typography.I)]
    [InlineData(Typography.BI)]
    public void Validation_Works(Typography rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Typography> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Typography>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Typography.B)]
    [InlineData(Typography.I)]
    [InlineData(Typography.BI)]
    public void SerializationRoundtrip_Works(Typography rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Typography> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Typography>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Typography>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Typography>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
