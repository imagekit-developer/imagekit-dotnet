using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models;

namespace Imagekit.Tests.Models;

public class SubtitleOverlayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubtitleOverlay
        {
            LayerMode = LayerMode.Multiply,
            Position = new()
            {
                AnchorPoint = AnchorPoint.Top,
                Focus = Focus.Center,
                X = 0,
                XCenter = 0,
                Y = 0,
                YCenter = 0,
            },
            Timing = new()
            {
                Duration = 0,
                End = 0,
                Start = 0,
            },
            Input = "input",
            Encoding = SubtitleOverlaySubtitleOverlayEncoding.Auto,
            Transformation =
            [
                new()
                {
                    Background = "background",
                    Color = "color",
                    FontFamily = "fontFamily",
                    FontOutline = "fontOutline",
                    FontShadow = "fontShadow",
                    FontSize = 0,
                    Typography = Typography.B,
                },
            ],
        };

        ApiEnum<string, LayerMode> expectedLayerMode = LayerMode.Multiply;
        OverlayPosition expectedPosition = new()
        {
            AnchorPoint = AnchorPoint.Top,
            Focus = Focus.Center,
            X = 0,
            XCenter = 0,
            Y = 0,
            YCenter = 0,
        };
        OverlayTiming expectedTiming = new()
        {
            Duration = 0,
            End = 0,
            Start = 0,
        };
        string expectedInput = "input";
        JsonElement expectedType = JsonSerializer.SerializeToElement("subtitle");
        ApiEnum<string, SubtitleOverlaySubtitleOverlayEncoding> expectedEncoding =
            SubtitleOverlaySubtitleOverlayEncoding.Auto;
        List<SubtitleOverlayTransformation> expectedTransformation =
        [
            new()
            {
                Background = "background",
                Color = "color",
                FontFamily = "fontFamily",
                FontOutline = "fontOutline",
                FontShadow = "fontShadow",
                FontSize = 0,
                Typography = Typography.B,
            },
        ];

        Assert.Equal(expectedLayerMode, model.LayerMode);
        Assert.Equal(expectedPosition, model.Position);
        Assert.Equal(expectedTiming, model.Timing);
        Assert.Equal(expectedInput, model.Input);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedEncoding, model.Encoding);
        Assert.NotNull(model.Transformation);
        Assert.Equal(expectedTransformation.Count, model.Transformation.Count);
        for (int i = 0; i < expectedTransformation.Count; i++)
        {
            Assert.Equal(expectedTransformation[i], model.Transformation[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubtitleOverlay
        {
            LayerMode = LayerMode.Multiply,
            Position = new()
            {
                AnchorPoint = AnchorPoint.Top,
                Focus = Focus.Center,
                X = 0,
                XCenter = 0,
                Y = 0,
                YCenter = 0,
            },
            Timing = new()
            {
                Duration = 0,
                End = 0,
                Start = 0,
            },
            Input = "input",
            Encoding = SubtitleOverlaySubtitleOverlayEncoding.Auto,
            Transformation =
            [
                new()
                {
                    Background = "background",
                    Color = "color",
                    FontFamily = "fontFamily",
                    FontOutline = "fontOutline",
                    FontShadow = "fontShadow",
                    FontSize = 0,
                    Typography = Typography.B,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubtitleOverlay>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubtitleOverlay
        {
            LayerMode = LayerMode.Multiply,
            Position = new()
            {
                AnchorPoint = AnchorPoint.Top,
                Focus = Focus.Center,
                X = 0,
                XCenter = 0,
                Y = 0,
                YCenter = 0,
            },
            Timing = new()
            {
                Duration = 0,
                End = 0,
                Start = 0,
            },
            Input = "input",
            Encoding = SubtitleOverlaySubtitleOverlayEncoding.Auto,
            Transformation =
            [
                new()
                {
                    Background = "background",
                    Color = "color",
                    FontFamily = "fontFamily",
                    FontOutline = "fontOutline",
                    FontShadow = "fontShadow",
                    FontSize = 0,
                    Typography = Typography.B,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubtitleOverlay>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, LayerMode> expectedLayerMode = LayerMode.Multiply;
        OverlayPosition expectedPosition = new()
        {
            AnchorPoint = AnchorPoint.Top,
            Focus = Focus.Center,
            X = 0,
            XCenter = 0,
            Y = 0,
            YCenter = 0,
        };
        OverlayTiming expectedTiming = new()
        {
            Duration = 0,
            End = 0,
            Start = 0,
        };
        string expectedInput = "input";
        JsonElement expectedType = JsonSerializer.SerializeToElement("subtitle");
        ApiEnum<string, SubtitleOverlaySubtitleOverlayEncoding> expectedEncoding =
            SubtitleOverlaySubtitleOverlayEncoding.Auto;
        List<SubtitleOverlayTransformation> expectedTransformation =
        [
            new()
            {
                Background = "background",
                Color = "color",
                FontFamily = "fontFamily",
                FontOutline = "fontOutline",
                FontShadow = "fontShadow",
                FontSize = 0,
                Typography = Typography.B,
            },
        ];

        Assert.Equal(expectedLayerMode, deserialized.LayerMode);
        Assert.Equal(expectedPosition, deserialized.Position);
        Assert.Equal(expectedTiming, deserialized.Timing);
        Assert.Equal(expectedInput, deserialized.Input);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedEncoding, deserialized.Encoding);
        Assert.NotNull(deserialized.Transformation);
        Assert.Equal(expectedTransformation.Count, deserialized.Transformation.Count);
        for (int i = 0; i < expectedTransformation.Count; i++)
        {
            Assert.Equal(expectedTransformation[i], deserialized.Transformation[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubtitleOverlay
        {
            LayerMode = LayerMode.Multiply,
            Position = new()
            {
                AnchorPoint = AnchorPoint.Top,
                Focus = Focus.Center,
                X = 0,
                XCenter = 0,
                Y = 0,
                YCenter = 0,
            },
            Timing = new()
            {
                Duration = 0,
                End = 0,
                Start = 0,
            },
            Input = "input",
            Encoding = SubtitleOverlaySubtitleOverlayEncoding.Auto,
            Transformation =
            [
                new()
                {
                    Background = "background",
                    Color = "color",
                    FontFamily = "fontFamily",
                    FontOutline = "fontOutline",
                    FontShadow = "fontShadow",
                    FontSize = 0,
                    Typography = Typography.B,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubtitleOverlay { Input = "input" };

        Assert.Null(model.LayerMode);
        Assert.False(model.RawData.ContainsKey("layerMode"));
        Assert.Null(model.Position);
        Assert.False(model.RawData.ContainsKey("position"));
        Assert.Null(model.Timing);
        Assert.False(model.RawData.ContainsKey("timing"));
        Assert.Null(model.Encoding);
        Assert.False(model.RawData.ContainsKey("encoding"));
        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubtitleOverlay { Input = "input" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubtitleOverlay
        {
            Input = "input",

            // Null should be interpreted as omitted for these properties
            LayerMode = null,
            Position = null,
            Timing = null,
            Encoding = null,
            Transformation = null,
        };

        Assert.Null(model.LayerMode);
        Assert.False(model.RawData.ContainsKey("layerMode"));
        Assert.Null(model.Position);
        Assert.False(model.RawData.ContainsKey("position"));
        Assert.Null(model.Timing);
        Assert.False(model.RawData.ContainsKey("timing"));
        Assert.Null(model.Encoding);
        Assert.False(model.RawData.ContainsKey("encoding"));
        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubtitleOverlay
        {
            Input = "input",

            // Null should be interpreted as omitted for these properties
            LayerMode = null,
            Position = null,
            Timing = null,
            Encoding = null,
            Transformation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubtitleOverlay
        {
            LayerMode = LayerMode.Multiply,
            Position = new()
            {
                AnchorPoint = AnchorPoint.Top,
                Focus = Focus.Center,
                X = 0,
                XCenter = 0,
                Y = 0,
                YCenter = 0,
            },
            Timing = new()
            {
                Duration = 0,
                End = 0,
                Start = 0,
            },
            Input = "input",
            Encoding = SubtitleOverlaySubtitleOverlayEncoding.Auto,
            Transformation =
            [
                new()
                {
                    Background = "background",
                    Color = "color",
                    FontFamily = "fontFamily",
                    FontOutline = "fontOutline",
                    FontShadow = "fontShadow",
                    FontSize = 0,
                    Typography = Typography.B,
                },
            ],
        };

        SubtitleOverlay copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubtitleOverlaySubtitleOverlayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubtitleOverlaySubtitleOverlay
        {
            Input = "input",
            Encoding = SubtitleOverlaySubtitleOverlayEncoding.Auto,
            Transformation =
            [
                new()
                {
                    Background = "background",
                    Color = "color",
                    FontFamily = "fontFamily",
                    FontOutline = "fontOutline",
                    FontShadow = "fontShadow",
                    FontSize = 0,
                    Typography = Typography.B,
                },
            ],
        };

        string expectedInput = "input";
        JsonElement expectedType = JsonSerializer.SerializeToElement("subtitle");
        ApiEnum<string, SubtitleOverlaySubtitleOverlayEncoding> expectedEncoding =
            SubtitleOverlaySubtitleOverlayEncoding.Auto;
        List<SubtitleOverlayTransformation> expectedTransformation =
        [
            new()
            {
                Background = "background",
                Color = "color",
                FontFamily = "fontFamily",
                FontOutline = "fontOutline",
                FontShadow = "fontShadow",
                FontSize = 0,
                Typography = Typography.B,
            },
        ];

        Assert.Equal(expectedInput, model.Input);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedEncoding, model.Encoding);
        Assert.NotNull(model.Transformation);
        Assert.Equal(expectedTransformation.Count, model.Transformation.Count);
        for (int i = 0; i < expectedTransformation.Count; i++)
        {
            Assert.Equal(expectedTransformation[i], model.Transformation[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubtitleOverlaySubtitleOverlay
        {
            Input = "input",
            Encoding = SubtitleOverlaySubtitleOverlayEncoding.Auto,
            Transformation =
            [
                new()
                {
                    Background = "background",
                    Color = "color",
                    FontFamily = "fontFamily",
                    FontOutline = "fontOutline",
                    FontShadow = "fontShadow",
                    FontSize = 0,
                    Typography = Typography.B,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubtitleOverlaySubtitleOverlay>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubtitleOverlaySubtitleOverlay
        {
            Input = "input",
            Encoding = SubtitleOverlaySubtitleOverlayEncoding.Auto,
            Transformation =
            [
                new()
                {
                    Background = "background",
                    Color = "color",
                    FontFamily = "fontFamily",
                    FontOutline = "fontOutline",
                    FontShadow = "fontShadow",
                    FontSize = 0,
                    Typography = Typography.B,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubtitleOverlaySubtitleOverlay>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInput = "input";
        JsonElement expectedType = JsonSerializer.SerializeToElement("subtitle");
        ApiEnum<string, SubtitleOverlaySubtitleOverlayEncoding> expectedEncoding =
            SubtitleOverlaySubtitleOverlayEncoding.Auto;
        List<SubtitleOverlayTransformation> expectedTransformation =
        [
            new()
            {
                Background = "background",
                Color = "color",
                FontFamily = "fontFamily",
                FontOutline = "fontOutline",
                FontShadow = "fontShadow",
                FontSize = 0,
                Typography = Typography.B,
            },
        ];

        Assert.Equal(expectedInput, deserialized.Input);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedEncoding, deserialized.Encoding);
        Assert.NotNull(deserialized.Transformation);
        Assert.Equal(expectedTransformation.Count, deserialized.Transformation.Count);
        for (int i = 0; i < expectedTransformation.Count; i++)
        {
            Assert.Equal(expectedTransformation[i], deserialized.Transformation[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubtitleOverlaySubtitleOverlay
        {
            Input = "input",
            Encoding = SubtitleOverlaySubtitleOverlayEncoding.Auto,
            Transformation =
            [
                new()
                {
                    Background = "background",
                    Color = "color",
                    FontFamily = "fontFamily",
                    FontOutline = "fontOutline",
                    FontShadow = "fontShadow",
                    FontSize = 0,
                    Typography = Typography.B,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubtitleOverlaySubtitleOverlay { Input = "input" };

        Assert.Null(model.Encoding);
        Assert.False(model.RawData.ContainsKey("encoding"));
        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubtitleOverlaySubtitleOverlay { Input = "input" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubtitleOverlaySubtitleOverlay
        {
            Input = "input",

            // Null should be interpreted as omitted for these properties
            Encoding = null,
            Transformation = null,
        };

        Assert.Null(model.Encoding);
        Assert.False(model.RawData.ContainsKey("encoding"));
        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubtitleOverlaySubtitleOverlay
        {
            Input = "input",

            // Null should be interpreted as omitted for these properties
            Encoding = null,
            Transformation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubtitleOverlaySubtitleOverlay
        {
            Input = "input",
            Encoding = SubtitleOverlaySubtitleOverlayEncoding.Auto,
            Transformation =
            [
                new()
                {
                    Background = "background",
                    Color = "color",
                    FontFamily = "fontFamily",
                    FontOutline = "fontOutline",
                    FontShadow = "fontShadow",
                    FontSize = 0,
                    Typography = Typography.B,
                },
            ],
        };

        SubtitleOverlaySubtitleOverlay copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubtitleOverlaySubtitleOverlayEncodingTest : TestBase
{
    [Theory]
    [InlineData(SubtitleOverlaySubtitleOverlayEncoding.Auto)]
    [InlineData(SubtitleOverlaySubtitleOverlayEncoding.Plain)]
    [InlineData(SubtitleOverlaySubtitleOverlayEncoding.Base64)]
    public void Validation_Works(SubtitleOverlaySubtitleOverlayEncoding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubtitleOverlaySubtitleOverlayEncoding> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubtitleOverlaySubtitleOverlayEncoding>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubtitleOverlaySubtitleOverlayEncoding.Auto)]
    [InlineData(SubtitleOverlaySubtitleOverlayEncoding.Plain)]
    [InlineData(SubtitleOverlaySubtitleOverlayEncoding.Base64)]
    public void SerializationRoundtrip_Works(SubtitleOverlaySubtitleOverlayEncoding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubtitleOverlaySubtitleOverlayEncoding> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubtitleOverlaySubtitleOverlayEncoding>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubtitleOverlaySubtitleOverlayEncoding>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubtitleOverlaySubtitleOverlayEncoding>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
