using System.Collections.Generic;
using System.Text.Json;
using ImageKit.Core;
using ImageKit.Models;

namespace ImageKit.Tests.Models;

public class SolidColorOverlayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SolidColorOverlay
        {
            LayerMode = LayerMode.Multiply,
            Position = new()
            {
                Focus = Focus.Center,
                X = 0,
                Y = 0,
            },
            Timing = new()
            {
                Duration = 0,
                End = 0,
                Start = 0,
            },
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new UnionMember0(),
                    Height = 0,
                    Radius = 0,
                    Width = 0,
                },
            ],
        };

        ApiEnum<string, LayerMode> expectedLayerMode = LayerMode.Multiply;
        OverlayPosition expectedPosition = new()
        {
            Focus = Focus.Center,
            X = 0,
            Y = 0,
        };
        OverlayTiming expectedTiming = new()
        {
            Duration = 0,
            End = 0,
            Start = 0,
        };
        string expectedColor = "color";
        JsonElement expectedType = JsonSerializer.SerializeToElement("solidColor");
        List<SolidColorOverlayTransformation> expectedTransformation =
        [
            new()
            {
                Alpha = 1,
                Background = "background",
                Gradient = new UnionMember0(),
                Height = 0,
                Radius = 0,
                Width = 0,
            },
        ];

        Assert.Equal(expectedLayerMode, model.LayerMode);
        Assert.Equal(expectedPosition, model.Position);
        Assert.Equal(expectedTiming, model.Timing);
        Assert.Equal(expectedColor, model.Color);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
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
        var model = new SolidColorOverlay
        {
            LayerMode = LayerMode.Multiply,
            Position = new()
            {
                Focus = Focus.Center,
                X = 0,
                Y = 0,
            },
            Timing = new()
            {
                Duration = 0,
                End = 0,
                Start = 0,
            },
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new UnionMember0(),
                    Height = 0,
                    Radius = 0,
                    Width = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SolidColorOverlay>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SolidColorOverlay
        {
            LayerMode = LayerMode.Multiply,
            Position = new()
            {
                Focus = Focus.Center,
                X = 0,
                Y = 0,
            },
            Timing = new()
            {
                Duration = 0,
                End = 0,
                Start = 0,
            },
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new UnionMember0(),
                    Height = 0,
                    Radius = 0,
                    Width = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SolidColorOverlay>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, LayerMode> expectedLayerMode = LayerMode.Multiply;
        OverlayPosition expectedPosition = new()
        {
            Focus = Focus.Center,
            X = 0,
            Y = 0,
        };
        OverlayTiming expectedTiming = new()
        {
            Duration = 0,
            End = 0,
            Start = 0,
        };
        string expectedColor = "color";
        JsonElement expectedType = JsonSerializer.SerializeToElement("solidColor");
        List<SolidColorOverlayTransformation> expectedTransformation =
        [
            new()
            {
                Alpha = 1,
                Background = "background",
                Gradient = new UnionMember0(),
                Height = 0,
                Radius = 0,
                Width = 0,
            },
        ];

        Assert.Equal(expectedLayerMode, deserialized.LayerMode);
        Assert.Equal(expectedPosition, deserialized.Position);
        Assert.Equal(expectedTiming, deserialized.Timing);
        Assert.Equal(expectedColor, deserialized.Color);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
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
        var model = new SolidColorOverlay
        {
            LayerMode = LayerMode.Multiply,
            Position = new()
            {
                Focus = Focus.Center,
                X = 0,
                Y = 0,
            },
            Timing = new()
            {
                Duration = 0,
                End = 0,
                Start = 0,
            },
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new UnionMember0(),
                    Height = 0,
                    Radius = 0,
                    Width = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SolidColorOverlay { Color = "color" };

        Assert.Null(model.LayerMode);
        Assert.False(model.RawData.ContainsKey("layerMode"));
        Assert.Null(model.Position);
        Assert.False(model.RawData.ContainsKey("position"));
        Assert.Null(model.Timing);
        Assert.False(model.RawData.ContainsKey("timing"));
        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SolidColorOverlay { Color = "color" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SolidColorOverlay
        {
            Color = "color",

            // Null should be interpreted as omitted for these properties
            LayerMode = null,
            Position = null,
            Timing = null,
            Transformation = null,
        };

        Assert.Null(model.LayerMode);
        Assert.False(model.RawData.ContainsKey("layerMode"));
        Assert.Null(model.Position);
        Assert.False(model.RawData.ContainsKey("position"));
        Assert.Null(model.Timing);
        Assert.False(model.RawData.ContainsKey("timing"));
        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SolidColorOverlay
        {
            Color = "color",

            // Null should be interpreted as omitted for these properties
            LayerMode = null,
            Position = null,
            Timing = null,
            Transformation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SolidColorOverlay
        {
            LayerMode = LayerMode.Multiply,
            Position = new()
            {
                Focus = Focus.Center,
                X = 0,
                Y = 0,
            },
            Timing = new()
            {
                Duration = 0,
                End = 0,
                Start = 0,
            },
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new UnionMember0(),
                    Height = 0,
                    Radius = 0,
                    Width = 0,
                },
            ],
        };

        SolidColorOverlay copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SolidColorOverlayIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SolidColorOverlayIntersectionMember1
        {
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new UnionMember0(),
                    Height = 0,
                    Radius = 0,
                    Width = 0,
                },
            ],
        };

        string expectedColor = "color";
        JsonElement expectedType = JsonSerializer.SerializeToElement("solidColor");
        List<SolidColorOverlayTransformation> expectedTransformation =
        [
            new()
            {
                Alpha = 1,
                Background = "background",
                Gradient = new UnionMember0(),
                Height = 0,
                Radius = 0,
                Width = 0,
            },
        ];

        Assert.Equal(expectedColor, model.Color);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
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
        var model = new SolidColorOverlayIntersectionMember1
        {
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new UnionMember0(),
                    Height = 0,
                    Radius = 0,
                    Width = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SolidColorOverlayIntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SolidColorOverlayIntersectionMember1
        {
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new UnionMember0(),
                    Height = 0,
                    Radius = 0,
                    Width = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SolidColorOverlayIntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedColor = "color";
        JsonElement expectedType = JsonSerializer.SerializeToElement("solidColor");
        List<SolidColorOverlayTransformation> expectedTransformation =
        [
            new()
            {
                Alpha = 1,
                Background = "background",
                Gradient = new UnionMember0(),
                Height = 0,
                Radius = 0,
                Width = 0,
            },
        ];

        Assert.Equal(expectedColor, deserialized.Color);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
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
        var model = new SolidColorOverlayIntersectionMember1
        {
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new UnionMember0(),
                    Height = 0,
                    Radius = 0,
                    Width = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SolidColorOverlayIntersectionMember1 { Color = "color" };

        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SolidColorOverlayIntersectionMember1 { Color = "color" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SolidColorOverlayIntersectionMember1
        {
            Color = "color",

            // Null should be interpreted as omitted for these properties
            Transformation = null,
        };

        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SolidColorOverlayIntersectionMember1
        {
            Color = "color",

            // Null should be interpreted as omitted for these properties
            Transformation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SolidColorOverlayIntersectionMember1
        {
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new UnionMember0(),
                    Height = 0,
                    Radius = 0,
                    Width = 0,
                },
            ],
        };

        SolidColorOverlayIntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}
