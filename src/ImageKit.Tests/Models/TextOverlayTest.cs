using System.Collections.Generic;
using System.Text.Json;
using ImageKit.Core;
using ImageKit.Exceptions;
using ImageKit.Models;

namespace ImageKit.Tests.Models;

public class TextOverlayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TextOverlay
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
            Text = "text",
            Encoding = TextOverlayIntersectionMember1Encoding.Auto,
            Transformation =
            [
                new()
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
        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");
        ApiEnum<string, TextOverlayIntersectionMember1Encoding> expectedEncoding =
            TextOverlayIntersectionMember1Encoding.Auto;
        List<TextOverlayTransformation> expectedTransformation =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedLayerMode, model.LayerMode);
        Assert.Equal(expectedPosition, model.Position);
        Assert.Equal(expectedTiming, model.Timing);
        Assert.Equal(expectedText, model.Text);
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
        var model = new TextOverlay
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
            Text = "text",
            Encoding = TextOverlayIntersectionMember1Encoding.Auto,
            Transformation =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextOverlay>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TextOverlay
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
            Text = "text",
            Encoding = TextOverlayIntersectionMember1Encoding.Auto,
            Transformation =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextOverlay>(
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
        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");
        ApiEnum<string, TextOverlayIntersectionMember1Encoding> expectedEncoding =
            TextOverlayIntersectionMember1Encoding.Auto;
        List<TextOverlayTransformation> expectedTransformation =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedLayerMode, deserialized.LayerMode);
        Assert.Equal(expectedPosition, deserialized.Position);
        Assert.Equal(expectedTiming, deserialized.Timing);
        Assert.Equal(expectedText, deserialized.Text);
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
        var model = new TextOverlay
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
            Text = "text",
            Encoding = TextOverlayIntersectionMember1Encoding.Auto,
            Transformation =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TextOverlay { Text = "text" };

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
        var model = new TextOverlay { Text = "text" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TextOverlay
        {
            Text = "text",

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
        var model = new TextOverlay
        {
            Text = "text",

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
        var model = new TextOverlay
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
            Text = "text",
            Encoding = TextOverlayIntersectionMember1Encoding.Auto,
            Transformation =
            [
                new()
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
                },
            ],
        };

        TextOverlay copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TextOverlayIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TextOverlayIntersectionMember1
        {
            Text = "text",
            Encoding = TextOverlayIntersectionMember1Encoding.Auto,
            Transformation =
            [
                new()
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
                },
            ],
        };

        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");
        ApiEnum<string, TextOverlayIntersectionMember1Encoding> expectedEncoding =
            TextOverlayIntersectionMember1Encoding.Auto;
        List<TextOverlayTransformation> expectedTransformation =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedText, model.Text);
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
        var model = new TextOverlayIntersectionMember1
        {
            Text = "text",
            Encoding = TextOverlayIntersectionMember1Encoding.Auto,
            Transformation =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextOverlayIntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TextOverlayIntersectionMember1
        {
            Text = "text",
            Encoding = TextOverlayIntersectionMember1Encoding.Auto,
            Transformation =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextOverlayIntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");
        ApiEnum<string, TextOverlayIntersectionMember1Encoding> expectedEncoding =
            TextOverlayIntersectionMember1Encoding.Auto;
        List<TextOverlayTransformation> expectedTransformation =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedText, deserialized.Text);
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
        var model = new TextOverlayIntersectionMember1
        {
            Text = "text",
            Encoding = TextOverlayIntersectionMember1Encoding.Auto,
            Transformation =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TextOverlayIntersectionMember1 { Text = "text" };

        Assert.Null(model.Encoding);
        Assert.False(model.RawData.ContainsKey("encoding"));
        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TextOverlayIntersectionMember1 { Text = "text" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TextOverlayIntersectionMember1
        {
            Text = "text",

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
        var model = new TextOverlayIntersectionMember1
        {
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Encoding = null,
            Transformation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TextOverlayIntersectionMember1
        {
            Text = "text",
            Encoding = TextOverlayIntersectionMember1Encoding.Auto,
            Transformation =
            [
                new()
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
                },
            ],
        };

        TextOverlayIntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TextOverlayIntersectionMember1EncodingTest : TestBase
{
    [Theory]
    [InlineData(TextOverlayIntersectionMember1Encoding.Auto)]
    [InlineData(TextOverlayIntersectionMember1Encoding.Plain)]
    [InlineData(TextOverlayIntersectionMember1Encoding.Base64)]
    public void Validation_Works(TextOverlayIntersectionMember1Encoding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextOverlayIntersectionMember1Encoding> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TextOverlayIntersectionMember1Encoding>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TextOverlayIntersectionMember1Encoding.Auto)]
    [InlineData(TextOverlayIntersectionMember1Encoding.Plain)]
    [InlineData(TextOverlayIntersectionMember1Encoding.Base64)]
    public void SerializationRoundtrip_Works(TextOverlayIntersectionMember1Encoding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextOverlayIntersectionMember1Encoding> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TextOverlayIntersectionMember1Encoding>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TextOverlayIntersectionMember1Encoding>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TextOverlayIntersectionMember1Encoding>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
