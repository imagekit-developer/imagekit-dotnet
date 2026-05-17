using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models;

namespace Imagekit.Tests.Models;

public class ImageOverlayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageOverlay
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
            Encoding = Encoding.Auto,
            Transformation =
            [
                new()
                {
                    AIChangeBackground = "aiChangeBackground",
                    AIDropShadow = new AIDropShadowDefault(),
                    AIEdit = "aiEdit",
                    AIRemoveBackground = AIRemoveBackground.True,
                    AIRemoveBackgroundExternal = AIRemoveBackgroundExternal.True,
                    AIRetouch = AIRetouch.True,
                    AIUpscale = AIUpscale.True,
                    AIVariation = AIVariation.True,
                    AspectRatio = "4:3",
                    AudioCodec = AudioCodec.Aac,
                    Background = "red",
                    Blur = 10,
                    Border = "5_FF0000",
                    Colorize = "colorize",
                    ColorProfile = true,
                    ColorReplace = "colorReplace",
                    ContrastStretch = ContrastStretch.True,
                    Crop = Crop.Force,
                    CropMode = CropMode.PadResize,
                    DefaultImage = "defaultImage",
                    Distort = "distort",
                    Dpr = 2,
                    Duration = 0,
                    EndOffset = 0,
                    Flip = TransformationFlip.H,
                    Focus = "center",
                    Format = Format.Auto,
                    Gradient = new TransformationGradientDefault(),
                    Grayscale = Grayscale.True,
                    Height = 200,
                    Lossless = true,
                    Metadata = true,
                    Named = "named",
                    Opacity = 0,
                    Original = true,
                    Overlay = new TextOverlay()
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
                        Encoding = TextOverlayTextOverlayEncoding.Auto,
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
                                Radius = new TextOverlayTransformationRadiusMax(),
                                Rotation = 0,
                                Typography = "typography",
                                Width = 0,
                            },
                        ],
                    },
                    Page = 0,
                    Progressive = true,
                    Quality = 80,
                    Radius = 20,
                    Raw = "raw",
                    Rotation = 90,
                    Shadow = new ShadowDefault(),
                    Sharpen = new SharpenDefault(),
                    StartOffset = 0,
                    StreamingResolutions = [StreamingResolution.V240],
                    Trim = new TrimDefault(),
                    UnsharpMask = new UnsharpMaskDefault(),
                    VideoCodec = VideoCodec.H264,
                    Width = 300,
                    X = 0,
                    XCenter = 0,
                    Y = 0,
                    YCenter = 0,
                    Zoom = 0,
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
        JsonElement expectedType = JsonSerializer.SerializeToElement("image");
        ApiEnum<string, Encoding> expectedEncoding = Encoding.Auto;
        List<Transformation> expectedTransformation =
        [
            new()
            {
                AIChangeBackground = "aiChangeBackground",
                AIDropShadow = new AIDropShadowDefault(),
                AIEdit = "aiEdit",
                AIRemoveBackground = AIRemoveBackground.True,
                AIRemoveBackgroundExternal = AIRemoveBackgroundExternal.True,
                AIRetouch = AIRetouch.True,
                AIUpscale = AIUpscale.True,
                AIVariation = AIVariation.True,
                AspectRatio = "4:3",
                AudioCodec = AudioCodec.Aac,
                Background = "red",
                Blur = 10,
                Border = "5_FF0000",
                Colorize = "colorize",
                ColorProfile = true,
                ColorReplace = "colorReplace",
                ContrastStretch = ContrastStretch.True,
                Crop = Crop.Force,
                CropMode = CropMode.PadResize,
                DefaultImage = "defaultImage",
                Distort = "distort",
                Dpr = 2,
                Duration = 0,
                EndOffset = 0,
                Flip = TransformationFlip.H,
                Focus = "center",
                Format = Format.Auto,
                Gradient = new TransformationGradientDefault(),
                Grayscale = Grayscale.True,
                Height = 200,
                Lossless = true,
                Metadata = true,
                Named = "named",
                Opacity = 0,
                Original = true,
                Overlay = new TextOverlay()
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
                    Encoding = TextOverlayTextOverlayEncoding.Auto,
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
                            Radius = new TextOverlayTransformationRadiusMax(),
                            Rotation = 0,
                            Typography = "typography",
                            Width = 0,
                        },
                    ],
                },
                Page = 0,
                Progressive = true,
                Quality = 80,
                Radius = 20,
                Raw = "raw",
                Rotation = 90,
                Shadow = new ShadowDefault(),
                Sharpen = new SharpenDefault(),
                StartOffset = 0,
                StreamingResolutions = [StreamingResolution.V240],
                Trim = new TrimDefault(),
                UnsharpMask = new UnsharpMaskDefault(),
                VideoCodec = VideoCodec.H264,
                Width = 300,
                X = 0,
                XCenter = 0,
                Y = 0,
                YCenter = 0,
                Zoom = 0,
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
        var model = new ImageOverlay
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
            Encoding = Encoding.Auto,
            Transformation =
            [
                new()
                {
                    AIChangeBackground = "aiChangeBackground",
                    AIDropShadow = new AIDropShadowDefault(),
                    AIEdit = "aiEdit",
                    AIRemoveBackground = AIRemoveBackground.True,
                    AIRemoveBackgroundExternal = AIRemoveBackgroundExternal.True,
                    AIRetouch = AIRetouch.True,
                    AIUpscale = AIUpscale.True,
                    AIVariation = AIVariation.True,
                    AspectRatio = "4:3",
                    AudioCodec = AudioCodec.Aac,
                    Background = "red",
                    Blur = 10,
                    Border = "5_FF0000",
                    Colorize = "colorize",
                    ColorProfile = true,
                    ColorReplace = "colorReplace",
                    ContrastStretch = ContrastStretch.True,
                    Crop = Crop.Force,
                    CropMode = CropMode.PadResize,
                    DefaultImage = "defaultImage",
                    Distort = "distort",
                    Dpr = 2,
                    Duration = 0,
                    EndOffset = 0,
                    Flip = TransformationFlip.H,
                    Focus = "center",
                    Format = Format.Auto,
                    Gradient = new TransformationGradientDefault(),
                    Grayscale = Grayscale.True,
                    Height = 200,
                    Lossless = true,
                    Metadata = true,
                    Named = "named",
                    Opacity = 0,
                    Original = true,
                    Overlay = new TextOverlay()
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
                        Encoding = TextOverlayTextOverlayEncoding.Auto,
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
                                Radius = new TextOverlayTransformationRadiusMax(),
                                Rotation = 0,
                                Typography = "typography",
                                Width = 0,
                            },
                        ],
                    },
                    Page = 0,
                    Progressive = true,
                    Quality = 80,
                    Radius = 20,
                    Raw = "raw",
                    Rotation = 90,
                    Shadow = new ShadowDefault(),
                    Sharpen = new SharpenDefault(),
                    StartOffset = 0,
                    StreamingResolutions = [StreamingResolution.V240],
                    Trim = new TrimDefault(),
                    UnsharpMask = new UnsharpMaskDefault(),
                    VideoCodec = VideoCodec.H264,
                    Width = 300,
                    X = 0,
                    XCenter = 0,
                    Y = 0,
                    YCenter = 0,
                    Zoom = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageOverlay>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageOverlay
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
            Encoding = Encoding.Auto,
            Transformation =
            [
                new()
                {
                    AIChangeBackground = "aiChangeBackground",
                    AIDropShadow = new AIDropShadowDefault(),
                    AIEdit = "aiEdit",
                    AIRemoveBackground = AIRemoveBackground.True,
                    AIRemoveBackgroundExternal = AIRemoveBackgroundExternal.True,
                    AIRetouch = AIRetouch.True,
                    AIUpscale = AIUpscale.True,
                    AIVariation = AIVariation.True,
                    AspectRatio = "4:3",
                    AudioCodec = AudioCodec.Aac,
                    Background = "red",
                    Blur = 10,
                    Border = "5_FF0000",
                    Colorize = "colorize",
                    ColorProfile = true,
                    ColorReplace = "colorReplace",
                    ContrastStretch = ContrastStretch.True,
                    Crop = Crop.Force,
                    CropMode = CropMode.PadResize,
                    DefaultImage = "defaultImage",
                    Distort = "distort",
                    Dpr = 2,
                    Duration = 0,
                    EndOffset = 0,
                    Flip = TransformationFlip.H,
                    Focus = "center",
                    Format = Format.Auto,
                    Gradient = new TransformationGradientDefault(),
                    Grayscale = Grayscale.True,
                    Height = 200,
                    Lossless = true,
                    Metadata = true,
                    Named = "named",
                    Opacity = 0,
                    Original = true,
                    Overlay = new TextOverlay()
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
                        Encoding = TextOverlayTextOverlayEncoding.Auto,
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
                                Radius = new TextOverlayTransformationRadiusMax(),
                                Rotation = 0,
                                Typography = "typography",
                                Width = 0,
                            },
                        ],
                    },
                    Page = 0,
                    Progressive = true,
                    Quality = 80,
                    Radius = 20,
                    Raw = "raw",
                    Rotation = 90,
                    Shadow = new ShadowDefault(),
                    Sharpen = new SharpenDefault(),
                    StartOffset = 0,
                    StreamingResolutions = [StreamingResolution.V240],
                    Trim = new TrimDefault(),
                    UnsharpMask = new UnsharpMaskDefault(),
                    VideoCodec = VideoCodec.H264,
                    Width = 300,
                    X = 0,
                    XCenter = 0,
                    Y = 0,
                    YCenter = 0,
                    Zoom = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageOverlay>(
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
        JsonElement expectedType = JsonSerializer.SerializeToElement("image");
        ApiEnum<string, Encoding> expectedEncoding = Encoding.Auto;
        List<Transformation> expectedTransformation =
        [
            new()
            {
                AIChangeBackground = "aiChangeBackground",
                AIDropShadow = new AIDropShadowDefault(),
                AIEdit = "aiEdit",
                AIRemoveBackground = AIRemoveBackground.True,
                AIRemoveBackgroundExternal = AIRemoveBackgroundExternal.True,
                AIRetouch = AIRetouch.True,
                AIUpscale = AIUpscale.True,
                AIVariation = AIVariation.True,
                AspectRatio = "4:3",
                AudioCodec = AudioCodec.Aac,
                Background = "red",
                Blur = 10,
                Border = "5_FF0000",
                Colorize = "colorize",
                ColorProfile = true,
                ColorReplace = "colorReplace",
                ContrastStretch = ContrastStretch.True,
                Crop = Crop.Force,
                CropMode = CropMode.PadResize,
                DefaultImage = "defaultImage",
                Distort = "distort",
                Dpr = 2,
                Duration = 0,
                EndOffset = 0,
                Flip = TransformationFlip.H,
                Focus = "center",
                Format = Format.Auto,
                Gradient = new TransformationGradientDefault(),
                Grayscale = Grayscale.True,
                Height = 200,
                Lossless = true,
                Metadata = true,
                Named = "named",
                Opacity = 0,
                Original = true,
                Overlay = new TextOverlay()
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
                    Encoding = TextOverlayTextOverlayEncoding.Auto,
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
                            Radius = new TextOverlayTransformationRadiusMax(),
                            Rotation = 0,
                            Typography = "typography",
                            Width = 0,
                        },
                    ],
                },
                Page = 0,
                Progressive = true,
                Quality = 80,
                Radius = 20,
                Raw = "raw",
                Rotation = 90,
                Shadow = new ShadowDefault(),
                Sharpen = new SharpenDefault(),
                StartOffset = 0,
                StreamingResolutions = [StreamingResolution.V240],
                Trim = new TrimDefault(),
                UnsharpMask = new UnsharpMaskDefault(),
                VideoCodec = VideoCodec.H264,
                Width = 300,
                X = 0,
                XCenter = 0,
                Y = 0,
                YCenter = 0,
                Zoom = 0,
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
        var model = new ImageOverlay
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
            Encoding = Encoding.Auto,
            Transformation =
            [
                new()
                {
                    AIChangeBackground = "aiChangeBackground",
                    AIDropShadow = new AIDropShadowDefault(),
                    AIEdit = "aiEdit",
                    AIRemoveBackground = AIRemoveBackground.True,
                    AIRemoveBackgroundExternal = AIRemoveBackgroundExternal.True,
                    AIRetouch = AIRetouch.True,
                    AIUpscale = AIUpscale.True,
                    AIVariation = AIVariation.True,
                    AspectRatio = "4:3",
                    AudioCodec = AudioCodec.Aac,
                    Background = "red",
                    Blur = 10,
                    Border = "5_FF0000",
                    Colorize = "colorize",
                    ColorProfile = true,
                    ColorReplace = "colorReplace",
                    ContrastStretch = ContrastStretch.True,
                    Crop = Crop.Force,
                    CropMode = CropMode.PadResize,
                    DefaultImage = "defaultImage",
                    Distort = "distort",
                    Dpr = 2,
                    Duration = 0,
                    EndOffset = 0,
                    Flip = TransformationFlip.H,
                    Focus = "center",
                    Format = Format.Auto,
                    Gradient = new TransformationGradientDefault(),
                    Grayscale = Grayscale.True,
                    Height = 200,
                    Lossless = true,
                    Metadata = true,
                    Named = "named",
                    Opacity = 0,
                    Original = true,
                    Overlay = new TextOverlay()
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
                        Encoding = TextOverlayTextOverlayEncoding.Auto,
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
                                Radius = new TextOverlayTransformationRadiusMax(),
                                Rotation = 0,
                                Typography = "typography",
                                Width = 0,
                            },
                        ],
                    },
                    Page = 0,
                    Progressive = true,
                    Quality = 80,
                    Radius = 20,
                    Raw = "raw",
                    Rotation = 90,
                    Shadow = new ShadowDefault(),
                    Sharpen = new SharpenDefault(),
                    StartOffset = 0,
                    StreamingResolutions = [StreamingResolution.V240],
                    Trim = new TrimDefault(),
                    UnsharpMask = new UnsharpMaskDefault(),
                    VideoCodec = VideoCodec.H264,
                    Width = 300,
                    X = 0,
                    XCenter = 0,
                    Y = 0,
                    YCenter = 0,
                    Zoom = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ImageOverlay { Input = "input" };

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
        var model = new ImageOverlay { Input = "input" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ImageOverlay
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
        var model = new ImageOverlay
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
        var model = new ImageOverlay
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
            Encoding = Encoding.Auto,
            Transformation =
            [
                new()
                {
                    AIChangeBackground = "aiChangeBackground",
                    AIDropShadow = new AIDropShadowDefault(),
                    AIEdit = "aiEdit",
                    AIRemoveBackground = AIRemoveBackground.True,
                    AIRemoveBackgroundExternal = AIRemoveBackgroundExternal.True,
                    AIRetouch = AIRetouch.True,
                    AIUpscale = AIUpscale.True,
                    AIVariation = AIVariation.True,
                    AspectRatio = "4:3",
                    AudioCodec = AudioCodec.Aac,
                    Background = "red",
                    Blur = 10,
                    Border = "5_FF0000",
                    Colorize = "colorize",
                    ColorProfile = true,
                    ColorReplace = "colorReplace",
                    ContrastStretch = ContrastStretch.True,
                    Crop = Crop.Force,
                    CropMode = CropMode.PadResize,
                    DefaultImage = "defaultImage",
                    Distort = "distort",
                    Dpr = 2,
                    Duration = 0,
                    EndOffset = 0,
                    Flip = TransformationFlip.H,
                    Focus = "center",
                    Format = Format.Auto,
                    Gradient = new TransformationGradientDefault(),
                    Grayscale = Grayscale.True,
                    Height = 200,
                    Lossless = true,
                    Metadata = true,
                    Named = "named",
                    Opacity = 0,
                    Original = true,
                    Overlay = new TextOverlay()
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
                        Encoding = TextOverlayTextOverlayEncoding.Auto,
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
                                Radius = new TextOverlayTransformationRadiusMax(),
                                Rotation = 0,
                                Typography = "typography",
                                Width = 0,
                            },
                        ],
                    },
                    Page = 0,
                    Progressive = true,
                    Quality = 80,
                    Radius = 20,
                    Raw = "raw",
                    Rotation = 90,
                    Shadow = new ShadowDefault(),
                    Sharpen = new SharpenDefault(),
                    StartOffset = 0,
                    StreamingResolutions = [StreamingResolution.V240],
                    Trim = new TrimDefault(),
                    UnsharpMask = new UnsharpMaskDefault(),
                    VideoCodec = VideoCodec.H264,
                    Width = 300,
                    X = 0,
                    XCenter = 0,
                    Y = 0,
                    YCenter = 0,
                    Zoom = 0,
                },
            ],
        };

        ImageOverlay copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageOverlayImageOverlayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageOverlayImageOverlay
        {
            Input = "input",
            Encoding = Encoding.Auto,
            Transformation =
            [
                new()
                {
                    AIChangeBackground = "aiChangeBackground",
                    AIDropShadow = new AIDropShadowDefault(),
                    AIEdit = "aiEdit",
                    AIRemoveBackground = AIRemoveBackground.True,
                    AIRemoveBackgroundExternal = AIRemoveBackgroundExternal.True,
                    AIRetouch = AIRetouch.True,
                    AIUpscale = AIUpscale.True,
                    AIVariation = AIVariation.True,
                    AspectRatio = "4:3",
                    AudioCodec = AudioCodec.Aac,
                    Background = "red",
                    Blur = 10,
                    Border = "5_FF0000",
                    Colorize = "colorize",
                    ColorProfile = true,
                    ColorReplace = "colorReplace",
                    ContrastStretch = ContrastStretch.True,
                    Crop = Crop.Force,
                    CropMode = CropMode.PadResize,
                    DefaultImage = "defaultImage",
                    Distort = "distort",
                    Dpr = 2,
                    Duration = 0,
                    EndOffset = 0,
                    Flip = TransformationFlip.H,
                    Focus = "center",
                    Format = Format.Auto,
                    Gradient = new TransformationGradientDefault(),
                    Grayscale = Grayscale.True,
                    Height = 200,
                    Lossless = true,
                    Metadata = true,
                    Named = "named",
                    Opacity = 0,
                    Original = true,
                    Overlay = new TextOverlay()
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
                        Encoding = TextOverlayTextOverlayEncoding.Auto,
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
                                Radius = new TextOverlayTransformationRadiusMax(),
                                Rotation = 0,
                                Typography = "typography",
                                Width = 0,
                            },
                        ],
                    },
                    Page = 0,
                    Progressive = true,
                    Quality = 80,
                    Radius = 20,
                    Raw = "raw",
                    Rotation = 90,
                    Shadow = new ShadowDefault(),
                    Sharpen = new SharpenDefault(),
                    StartOffset = 0,
                    StreamingResolutions = [StreamingResolution.V240],
                    Trim = new TrimDefault(),
                    UnsharpMask = new UnsharpMaskDefault(),
                    VideoCodec = VideoCodec.H264,
                    Width = 300,
                    X = 0,
                    XCenter = 0,
                    Y = 0,
                    YCenter = 0,
                    Zoom = 0,
                },
            ],
        };

        string expectedInput = "input";
        JsonElement expectedType = JsonSerializer.SerializeToElement("image");
        ApiEnum<string, Encoding> expectedEncoding = Encoding.Auto;
        List<Transformation> expectedTransformation =
        [
            new()
            {
                AIChangeBackground = "aiChangeBackground",
                AIDropShadow = new AIDropShadowDefault(),
                AIEdit = "aiEdit",
                AIRemoveBackground = AIRemoveBackground.True,
                AIRemoveBackgroundExternal = AIRemoveBackgroundExternal.True,
                AIRetouch = AIRetouch.True,
                AIUpscale = AIUpscale.True,
                AIVariation = AIVariation.True,
                AspectRatio = "4:3",
                AudioCodec = AudioCodec.Aac,
                Background = "red",
                Blur = 10,
                Border = "5_FF0000",
                Colorize = "colorize",
                ColorProfile = true,
                ColorReplace = "colorReplace",
                ContrastStretch = ContrastStretch.True,
                Crop = Crop.Force,
                CropMode = CropMode.PadResize,
                DefaultImage = "defaultImage",
                Distort = "distort",
                Dpr = 2,
                Duration = 0,
                EndOffset = 0,
                Flip = TransformationFlip.H,
                Focus = "center",
                Format = Format.Auto,
                Gradient = new TransformationGradientDefault(),
                Grayscale = Grayscale.True,
                Height = 200,
                Lossless = true,
                Metadata = true,
                Named = "named",
                Opacity = 0,
                Original = true,
                Overlay = new TextOverlay()
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
                    Encoding = TextOverlayTextOverlayEncoding.Auto,
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
                            Radius = new TextOverlayTransformationRadiusMax(),
                            Rotation = 0,
                            Typography = "typography",
                            Width = 0,
                        },
                    ],
                },
                Page = 0,
                Progressive = true,
                Quality = 80,
                Radius = 20,
                Raw = "raw",
                Rotation = 90,
                Shadow = new ShadowDefault(),
                Sharpen = new SharpenDefault(),
                StartOffset = 0,
                StreamingResolutions = [StreamingResolution.V240],
                Trim = new TrimDefault(),
                UnsharpMask = new UnsharpMaskDefault(),
                VideoCodec = VideoCodec.H264,
                Width = 300,
                X = 0,
                XCenter = 0,
                Y = 0,
                YCenter = 0,
                Zoom = 0,
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
        var model = new ImageOverlayImageOverlay
        {
            Input = "input",
            Encoding = Encoding.Auto,
            Transformation =
            [
                new()
                {
                    AIChangeBackground = "aiChangeBackground",
                    AIDropShadow = new AIDropShadowDefault(),
                    AIEdit = "aiEdit",
                    AIRemoveBackground = AIRemoveBackground.True,
                    AIRemoveBackgroundExternal = AIRemoveBackgroundExternal.True,
                    AIRetouch = AIRetouch.True,
                    AIUpscale = AIUpscale.True,
                    AIVariation = AIVariation.True,
                    AspectRatio = "4:3",
                    AudioCodec = AudioCodec.Aac,
                    Background = "red",
                    Blur = 10,
                    Border = "5_FF0000",
                    Colorize = "colorize",
                    ColorProfile = true,
                    ColorReplace = "colorReplace",
                    ContrastStretch = ContrastStretch.True,
                    Crop = Crop.Force,
                    CropMode = CropMode.PadResize,
                    DefaultImage = "defaultImage",
                    Distort = "distort",
                    Dpr = 2,
                    Duration = 0,
                    EndOffset = 0,
                    Flip = TransformationFlip.H,
                    Focus = "center",
                    Format = Format.Auto,
                    Gradient = new TransformationGradientDefault(),
                    Grayscale = Grayscale.True,
                    Height = 200,
                    Lossless = true,
                    Metadata = true,
                    Named = "named",
                    Opacity = 0,
                    Original = true,
                    Overlay = new TextOverlay()
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
                        Encoding = TextOverlayTextOverlayEncoding.Auto,
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
                                Radius = new TextOverlayTransformationRadiusMax(),
                                Rotation = 0,
                                Typography = "typography",
                                Width = 0,
                            },
                        ],
                    },
                    Page = 0,
                    Progressive = true,
                    Quality = 80,
                    Radius = 20,
                    Raw = "raw",
                    Rotation = 90,
                    Shadow = new ShadowDefault(),
                    Sharpen = new SharpenDefault(),
                    StartOffset = 0,
                    StreamingResolutions = [StreamingResolution.V240],
                    Trim = new TrimDefault(),
                    UnsharpMask = new UnsharpMaskDefault(),
                    VideoCodec = VideoCodec.H264,
                    Width = 300,
                    X = 0,
                    XCenter = 0,
                    Y = 0,
                    YCenter = 0,
                    Zoom = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageOverlayImageOverlay>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageOverlayImageOverlay
        {
            Input = "input",
            Encoding = Encoding.Auto,
            Transformation =
            [
                new()
                {
                    AIChangeBackground = "aiChangeBackground",
                    AIDropShadow = new AIDropShadowDefault(),
                    AIEdit = "aiEdit",
                    AIRemoveBackground = AIRemoveBackground.True,
                    AIRemoveBackgroundExternal = AIRemoveBackgroundExternal.True,
                    AIRetouch = AIRetouch.True,
                    AIUpscale = AIUpscale.True,
                    AIVariation = AIVariation.True,
                    AspectRatio = "4:3",
                    AudioCodec = AudioCodec.Aac,
                    Background = "red",
                    Blur = 10,
                    Border = "5_FF0000",
                    Colorize = "colorize",
                    ColorProfile = true,
                    ColorReplace = "colorReplace",
                    ContrastStretch = ContrastStretch.True,
                    Crop = Crop.Force,
                    CropMode = CropMode.PadResize,
                    DefaultImage = "defaultImage",
                    Distort = "distort",
                    Dpr = 2,
                    Duration = 0,
                    EndOffset = 0,
                    Flip = TransformationFlip.H,
                    Focus = "center",
                    Format = Format.Auto,
                    Gradient = new TransformationGradientDefault(),
                    Grayscale = Grayscale.True,
                    Height = 200,
                    Lossless = true,
                    Metadata = true,
                    Named = "named",
                    Opacity = 0,
                    Original = true,
                    Overlay = new TextOverlay()
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
                        Encoding = TextOverlayTextOverlayEncoding.Auto,
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
                                Radius = new TextOverlayTransformationRadiusMax(),
                                Rotation = 0,
                                Typography = "typography",
                                Width = 0,
                            },
                        ],
                    },
                    Page = 0,
                    Progressive = true,
                    Quality = 80,
                    Radius = 20,
                    Raw = "raw",
                    Rotation = 90,
                    Shadow = new ShadowDefault(),
                    Sharpen = new SharpenDefault(),
                    StartOffset = 0,
                    StreamingResolutions = [StreamingResolution.V240],
                    Trim = new TrimDefault(),
                    UnsharpMask = new UnsharpMaskDefault(),
                    VideoCodec = VideoCodec.H264,
                    Width = 300,
                    X = 0,
                    XCenter = 0,
                    Y = 0,
                    YCenter = 0,
                    Zoom = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageOverlayImageOverlay>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInput = "input";
        JsonElement expectedType = JsonSerializer.SerializeToElement("image");
        ApiEnum<string, Encoding> expectedEncoding = Encoding.Auto;
        List<Transformation> expectedTransformation =
        [
            new()
            {
                AIChangeBackground = "aiChangeBackground",
                AIDropShadow = new AIDropShadowDefault(),
                AIEdit = "aiEdit",
                AIRemoveBackground = AIRemoveBackground.True,
                AIRemoveBackgroundExternal = AIRemoveBackgroundExternal.True,
                AIRetouch = AIRetouch.True,
                AIUpscale = AIUpscale.True,
                AIVariation = AIVariation.True,
                AspectRatio = "4:3",
                AudioCodec = AudioCodec.Aac,
                Background = "red",
                Blur = 10,
                Border = "5_FF0000",
                Colorize = "colorize",
                ColorProfile = true,
                ColorReplace = "colorReplace",
                ContrastStretch = ContrastStretch.True,
                Crop = Crop.Force,
                CropMode = CropMode.PadResize,
                DefaultImage = "defaultImage",
                Distort = "distort",
                Dpr = 2,
                Duration = 0,
                EndOffset = 0,
                Flip = TransformationFlip.H,
                Focus = "center",
                Format = Format.Auto,
                Gradient = new TransformationGradientDefault(),
                Grayscale = Grayscale.True,
                Height = 200,
                Lossless = true,
                Metadata = true,
                Named = "named",
                Opacity = 0,
                Original = true,
                Overlay = new TextOverlay()
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
                    Encoding = TextOverlayTextOverlayEncoding.Auto,
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
                            Radius = new TextOverlayTransformationRadiusMax(),
                            Rotation = 0,
                            Typography = "typography",
                            Width = 0,
                        },
                    ],
                },
                Page = 0,
                Progressive = true,
                Quality = 80,
                Radius = 20,
                Raw = "raw",
                Rotation = 90,
                Shadow = new ShadowDefault(),
                Sharpen = new SharpenDefault(),
                StartOffset = 0,
                StreamingResolutions = [StreamingResolution.V240],
                Trim = new TrimDefault(),
                UnsharpMask = new UnsharpMaskDefault(),
                VideoCodec = VideoCodec.H264,
                Width = 300,
                X = 0,
                XCenter = 0,
                Y = 0,
                YCenter = 0,
                Zoom = 0,
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
        var model = new ImageOverlayImageOverlay
        {
            Input = "input",
            Encoding = Encoding.Auto,
            Transformation =
            [
                new()
                {
                    AIChangeBackground = "aiChangeBackground",
                    AIDropShadow = new AIDropShadowDefault(),
                    AIEdit = "aiEdit",
                    AIRemoveBackground = AIRemoveBackground.True,
                    AIRemoveBackgroundExternal = AIRemoveBackgroundExternal.True,
                    AIRetouch = AIRetouch.True,
                    AIUpscale = AIUpscale.True,
                    AIVariation = AIVariation.True,
                    AspectRatio = "4:3",
                    AudioCodec = AudioCodec.Aac,
                    Background = "red",
                    Blur = 10,
                    Border = "5_FF0000",
                    Colorize = "colorize",
                    ColorProfile = true,
                    ColorReplace = "colorReplace",
                    ContrastStretch = ContrastStretch.True,
                    Crop = Crop.Force,
                    CropMode = CropMode.PadResize,
                    DefaultImage = "defaultImage",
                    Distort = "distort",
                    Dpr = 2,
                    Duration = 0,
                    EndOffset = 0,
                    Flip = TransformationFlip.H,
                    Focus = "center",
                    Format = Format.Auto,
                    Gradient = new TransformationGradientDefault(),
                    Grayscale = Grayscale.True,
                    Height = 200,
                    Lossless = true,
                    Metadata = true,
                    Named = "named",
                    Opacity = 0,
                    Original = true,
                    Overlay = new TextOverlay()
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
                        Encoding = TextOverlayTextOverlayEncoding.Auto,
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
                                Radius = new TextOverlayTransformationRadiusMax(),
                                Rotation = 0,
                                Typography = "typography",
                                Width = 0,
                            },
                        ],
                    },
                    Page = 0,
                    Progressive = true,
                    Quality = 80,
                    Radius = 20,
                    Raw = "raw",
                    Rotation = 90,
                    Shadow = new ShadowDefault(),
                    Sharpen = new SharpenDefault(),
                    StartOffset = 0,
                    StreamingResolutions = [StreamingResolution.V240],
                    Trim = new TrimDefault(),
                    UnsharpMask = new UnsharpMaskDefault(),
                    VideoCodec = VideoCodec.H264,
                    Width = 300,
                    X = 0,
                    XCenter = 0,
                    Y = 0,
                    YCenter = 0,
                    Zoom = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ImageOverlayImageOverlay { Input = "input" };

        Assert.Null(model.Encoding);
        Assert.False(model.RawData.ContainsKey("encoding"));
        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ImageOverlayImageOverlay { Input = "input" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ImageOverlayImageOverlay
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
        var model = new ImageOverlayImageOverlay
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
        var model = new ImageOverlayImageOverlay
        {
            Input = "input",
            Encoding = Encoding.Auto,
            Transformation =
            [
                new()
                {
                    AIChangeBackground = "aiChangeBackground",
                    AIDropShadow = new AIDropShadowDefault(),
                    AIEdit = "aiEdit",
                    AIRemoveBackground = AIRemoveBackground.True,
                    AIRemoveBackgroundExternal = AIRemoveBackgroundExternal.True,
                    AIRetouch = AIRetouch.True,
                    AIUpscale = AIUpscale.True,
                    AIVariation = AIVariation.True,
                    AspectRatio = "4:3",
                    AudioCodec = AudioCodec.Aac,
                    Background = "red",
                    Blur = 10,
                    Border = "5_FF0000",
                    Colorize = "colorize",
                    ColorProfile = true,
                    ColorReplace = "colorReplace",
                    ContrastStretch = ContrastStretch.True,
                    Crop = Crop.Force,
                    CropMode = CropMode.PadResize,
                    DefaultImage = "defaultImage",
                    Distort = "distort",
                    Dpr = 2,
                    Duration = 0,
                    EndOffset = 0,
                    Flip = TransformationFlip.H,
                    Focus = "center",
                    Format = Format.Auto,
                    Gradient = new TransformationGradientDefault(),
                    Grayscale = Grayscale.True,
                    Height = 200,
                    Lossless = true,
                    Metadata = true,
                    Named = "named",
                    Opacity = 0,
                    Original = true,
                    Overlay = new TextOverlay()
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
                        Encoding = TextOverlayTextOverlayEncoding.Auto,
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
                                Radius = new TextOverlayTransformationRadiusMax(),
                                Rotation = 0,
                                Typography = "typography",
                                Width = 0,
                            },
                        ],
                    },
                    Page = 0,
                    Progressive = true,
                    Quality = 80,
                    Radius = 20,
                    Raw = "raw",
                    Rotation = 90,
                    Shadow = new ShadowDefault(),
                    Sharpen = new SharpenDefault(),
                    StartOffset = 0,
                    StreamingResolutions = [StreamingResolution.V240],
                    Trim = new TrimDefault(),
                    UnsharpMask = new UnsharpMaskDefault(),
                    VideoCodec = VideoCodec.H264,
                    Width = 300,
                    X = 0,
                    XCenter = 0,
                    Y = 0,
                    YCenter = 0,
                    Zoom = 0,
                },
            ],
        };

        ImageOverlayImageOverlay copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EncodingTest : TestBase
{
    [Theory]
    [InlineData(Encoding.Auto)]
    [InlineData(Encoding.Plain)]
    [InlineData(Encoding.Base64)]
    public void Validation_Works(Encoding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Encoding> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Encoding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Encoding.Auto)]
    [InlineData(Encoding.Plain)]
    [InlineData(Encoding.Base64)]
    public void SerializationRoundtrip_Works(Encoding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Encoding> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Encoding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Encoding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Encoding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
