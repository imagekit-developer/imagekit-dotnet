using System.Collections.Generic;
using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.Dummy;

namespace ImagekitDiversion.Tests.Models.Dummy;

public class OverlayTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
    {
        Overlay value = new Text()
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
            Encoding = TextTextOverlayEncoding.Auto,
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
        };
        value.Validate();
    }

    [Fact]
    public void ImageValidationWorks()
    {
        Overlay value = new ImageOverlay()
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
            Encoding = ImageOverlayImageOverlayEncoding.Auto,
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
                    Overlay = new Text()
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
                        Encoding = TextTextOverlayEncoding.Auto,
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
                    StreamingResolutions = [TransformationStreamingResolution.V240],
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
        value.Validate();
    }

    [Fact]
    public void VideoValidationWorks()
    {
        Overlay value = new VideoOverlay()
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
            Encoding = VideoOverlayVideoOverlayEncoding.Auto,
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
                    Overlay = new Text()
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
                        Encoding = TextTextOverlayEncoding.Auto,
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
                    StreamingResolutions = [TransformationStreamingResolution.V240],
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
        value.Validate();
    }

    [Fact]
    public void SubtitleValidationWorks()
    {
        Overlay value = new Subtitle()
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
            Encoding = SubtitleSubtitleOverlayEncoding.Auto,
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
        value.Validate();
    }

    [Fact]
    public void SolidColorValidationWorks()
    {
        Overlay value = new SolidColor()
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
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new Default(),
                    Height = 0,
                    Radius = new Max(),
                    Width = 0,
                },
            ],
        };
        value.Validate();
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        Overlay value = new Text()
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
            Encoding = TextTextOverlayEncoding.Auto,
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
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Overlay>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageSerializationRoundtripWorks()
    {
        Overlay value = new ImageOverlay()
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
            Encoding = ImageOverlayImageOverlayEncoding.Auto,
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
                    Overlay = new Text()
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
                        Encoding = TextTextOverlayEncoding.Auto,
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
                    StreamingResolutions = [TransformationStreamingResolution.V240],
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Overlay>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VideoSerializationRoundtripWorks()
    {
        Overlay value = new VideoOverlay()
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
            Encoding = VideoOverlayVideoOverlayEncoding.Auto,
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
                    Overlay = new Text()
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
                        Encoding = TextTextOverlayEncoding.Auto,
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
                    StreamingResolutions = [TransformationStreamingResolution.V240],
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Overlay>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SubtitleSerializationRoundtripWorks()
    {
        Overlay value = new Subtitle()
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
            Encoding = SubtitleSubtitleOverlayEncoding.Auto,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Overlay>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SolidColorSerializationRoundtripWorks()
    {
        Overlay value = new SolidColor()
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
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new Default(),
                    Height = 0,
                    Radius = new Max(),
                    Width = 0,
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Overlay>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TextTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Text
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
            TextValue = "text",
            Encoding = TextTextOverlayEncoding.Auto,
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
        string expectedTextValue = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");
        ApiEnum<string, TextTextOverlayEncoding> expectedEncoding = TextTextOverlayEncoding.Auto;
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
                Radius = new TextOverlayTransformationRadiusMax(),
                Rotation = 0,
                Typography = "typography",
                Width = 0,
            },
        ];

        Assert.Equal(expectedLayerMode, model.LayerMode);
        Assert.Equal(expectedPosition, model.Position);
        Assert.Equal(expectedTiming, model.Timing);
        Assert.Equal(expectedTextValue, model.TextValue);
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
        var model = new Text
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
            TextValue = "text",
            Encoding = TextTextOverlayEncoding.Auto,
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Text>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Text
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
            TextValue = "text",
            Encoding = TextTextOverlayEncoding.Auto,
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Text>(element, ModelBase.SerializerOptions);
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
        string expectedTextValue = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");
        ApiEnum<string, TextTextOverlayEncoding> expectedEncoding = TextTextOverlayEncoding.Auto;
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
                Radius = new TextOverlayTransformationRadiusMax(),
                Rotation = 0,
                Typography = "typography",
                Width = 0,
            },
        ];

        Assert.Equal(expectedLayerMode, deserialized.LayerMode);
        Assert.Equal(expectedPosition, deserialized.Position);
        Assert.Equal(expectedTiming, deserialized.Timing);
        Assert.Equal(expectedTextValue, deserialized.TextValue);
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
        var model = new Text
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
            TextValue = "text",
            Encoding = TextTextOverlayEncoding.Auto,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Text { TextValue = "text" };

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
        var model = new Text { TextValue = "text" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Text
        {
            TextValue = "text",

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
        var model = new Text
        {
            TextValue = "text",

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
        var model = new Text
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
            TextValue = "text",
            Encoding = TextTextOverlayEncoding.Auto,
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
        };

        Text copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TextTextOverlayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TextTextOverlay
        {
            Text = "text",
            Encoding = TextTextOverlayEncoding.Auto,
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
        };

        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");
        ApiEnum<string, TextTextOverlayEncoding> expectedEncoding = TextTextOverlayEncoding.Auto;
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
                Radius = new TextOverlayTransformationRadiusMax(),
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
        var model = new TextTextOverlay
        {
            Text = "text",
            Encoding = TextTextOverlayEncoding.Auto,
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextTextOverlay>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TextTextOverlay
        {
            Text = "text",
            Encoding = TextTextOverlayEncoding.Auto,
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextTextOverlay>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");
        ApiEnum<string, TextTextOverlayEncoding> expectedEncoding = TextTextOverlayEncoding.Auto;
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
                Radius = new TextOverlayTransformationRadiusMax(),
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
        var model = new TextTextOverlay
        {
            Text = "text",
            Encoding = TextTextOverlayEncoding.Auto,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TextTextOverlay { Text = "text" };

        Assert.Null(model.Encoding);
        Assert.False(model.RawData.ContainsKey("encoding"));
        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TextTextOverlay { Text = "text" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TextTextOverlay
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
        var model = new TextTextOverlay
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
        var model = new TextTextOverlay
        {
            Text = "text",
            Encoding = TextTextOverlayEncoding.Auto,
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
        };

        TextTextOverlay copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TextTextOverlayEncodingTest : TestBase
{
    [Theory]
    [InlineData(TextTextOverlayEncoding.Auto)]
    [InlineData(TextTextOverlayEncoding.Plain)]
    [InlineData(TextTextOverlayEncoding.Base64)]
    public void Validation_Works(TextTextOverlayEncoding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextTextOverlayEncoding> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TextTextOverlayEncoding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TextTextOverlayEncoding.Auto)]
    [InlineData(TextTextOverlayEncoding.Plain)]
    [InlineData(TextTextOverlayEncoding.Base64)]
    public void SerializationRoundtrip_Works(TextTextOverlayEncoding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextTextOverlayEncoding> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TextTextOverlayEncoding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TextTextOverlayEncoding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TextTextOverlayEncoding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SubtitleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subtitle
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
            Encoding = SubtitleSubtitleOverlayEncoding.Auto,
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
        ApiEnum<string, SubtitleSubtitleOverlayEncoding> expectedEncoding =
            SubtitleSubtitleOverlayEncoding.Auto;
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
        var model = new Subtitle
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
            Encoding = SubtitleSubtitleOverlayEncoding.Auto,
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
        var deserialized = JsonSerializer.Deserialize<Subtitle>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subtitle
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
            Encoding = SubtitleSubtitleOverlayEncoding.Auto,
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
        var deserialized = JsonSerializer.Deserialize<Subtitle>(
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
        ApiEnum<string, SubtitleSubtitleOverlayEncoding> expectedEncoding =
            SubtitleSubtitleOverlayEncoding.Auto;
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
        var model = new Subtitle
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
            Encoding = SubtitleSubtitleOverlayEncoding.Auto,
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
        var model = new Subtitle { Input = "input" };

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
        var model = new Subtitle { Input = "input" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subtitle
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
        var model = new Subtitle
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
        var model = new Subtitle
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
            Encoding = SubtitleSubtitleOverlayEncoding.Auto,
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

        Subtitle copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubtitleSubtitleOverlayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubtitleSubtitleOverlay
        {
            Input = "input",
            Encoding = SubtitleSubtitleOverlayEncoding.Auto,
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
        ApiEnum<string, SubtitleSubtitleOverlayEncoding> expectedEncoding =
            SubtitleSubtitleOverlayEncoding.Auto;
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
        var model = new SubtitleSubtitleOverlay
        {
            Input = "input",
            Encoding = SubtitleSubtitleOverlayEncoding.Auto,
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
        var deserialized = JsonSerializer.Deserialize<SubtitleSubtitleOverlay>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubtitleSubtitleOverlay
        {
            Input = "input",
            Encoding = SubtitleSubtitleOverlayEncoding.Auto,
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
        var deserialized = JsonSerializer.Deserialize<SubtitleSubtitleOverlay>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInput = "input";
        JsonElement expectedType = JsonSerializer.SerializeToElement("subtitle");
        ApiEnum<string, SubtitleSubtitleOverlayEncoding> expectedEncoding =
            SubtitleSubtitleOverlayEncoding.Auto;
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
        var model = new SubtitleSubtitleOverlay
        {
            Input = "input",
            Encoding = SubtitleSubtitleOverlayEncoding.Auto,
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
        var model = new SubtitleSubtitleOverlay { Input = "input" };

        Assert.Null(model.Encoding);
        Assert.False(model.RawData.ContainsKey("encoding"));
        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubtitleSubtitleOverlay { Input = "input" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubtitleSubtitleOverlay
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
        var model = new SubtitleSubtitleOverlay
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
        var model = new SubtitleSubtitleOverlay
        {
            Input = "input",
            Encoding = SubtitleSubtitleOverlayEncoding.Auto,
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

        SubtitleSubtitleOverlay copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubtitleSubtitleOverlayEncodingTest : TestBase
{
    [Theory]
    [InlineData(SubtitleSubtitleOverlayEncoding.Auto)]
    [InlineData(SubtitleSubtitleOverlayEncoding.Plain)]
    [InlineData(SubtitleSubtitleOverlayEncoding.Base64)]
    public void Validation_Works(SubtitleSubtitleOverlayEncoding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubtitleSubtitleOverlayEncoding> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubtitleSubtitleOverlayEncoding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubtitleSubtitleOverlayEncoding.Auto)]
    [InlineData(SubtitleSubtitleOverlayEncoding.Plain)]
    [InlineData(SubtitleSubtitleOverlayEncoding.Base64)]
    public void SerializationRoundtrip_Works(SubtitleSubtitleOverlayEncoding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubtitleSubtitleOverlayEncoding> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubtitleSubtitleOverlayEncoding>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubtitleSubtitleOverlayEncoding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubtitleSubtitleOverlayEncoding>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SolidColorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SolidColor
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
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new Default(),
                    Height = 0,
                    Radius = new Max(),
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
        string expectedColor = "color";
        JsonElement expectedType = JsonSerializer.SerializeToElement("solidColor");
        List<SolidColorOverlayTransformation> expectedTransformation =
        [
            new()
            {
                Alpha = 1,
                Background = "background",
                Gradient = new Default(),
                Height = 0,
                Radius = new Max(),
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
        var model = new SolidColor
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
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new Default(),
                    Height = 0,
                    Radius = new Max(),
                    Width = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SolidColor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SolidColor
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
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new Default(),
                    Height = 0,
                    Radius = new Max(),
                    Width = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SolidColor>(
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
        string expectedColor = "color";
        JsonElement expectedType = JsonSerializer.SerializeToElement("solidColor");
        List<SolidColorOverlayTransformation> expectedTransformation =
        [
            new()
            {
                Alpha = 1,
                Background = "background",
                Gradient = new Default(),
                Height = 0,
                Radius = new Max(),
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
        var model = new SolidColor
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
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new Default(),
                    Height = 0,
                    Radius = new Max(),
                    Width = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SolidColor { Color = "color" };

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
        var model = new SolidColor { Color = "color" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SolidColor
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
        var model = new SolidColor
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
        var model = new SolidColor
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
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new Default(),
                    Height = 0,
                    Radius = new Max(),
                    Width = 0,
                },
            ],
        };

        SolidColor copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SolidColorSolidColorOverlayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SolidColorSolidColorOverlay
        {
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new Default(),
                    Height = 0,
                    Radius = new Max(),
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
                Gradient = new Default(),
                Height = 0,
                Radius = new Max(),
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
        var model = new SolidColorSolidColorOverlay
        {
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new Default(),
                    Height = 0,
                    Radius = new Max(),
                    Width = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SolidColorSolidColorOverlay>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SolidColorSolidColorOverlay
        {
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new Default(),
                    Height = 0,
                    Radius = new Max(),
                    Width = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SolidColorSolidColorOverlay>(
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
                Gradient = new Default(),
                Height = 0,
                Radius = new Max(),
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
        var model = new SolidColorSolidColorOverlay
        {
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new Default(),
                    Height = 0,
                    Radius = new Max(),
                    Width = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SolidColorSolidColorOverlay { Color = "color" };

        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SolidColorSolidColorOverlay { Color = "color" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SolidColorSolidColorOverlay
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
        var model = new SolidColorSolidColorOverlay
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
        var model = new SolidColorSolidColorOverlay
        {
            Color = "color",
            Transformation =
            [
                new()
                {
                    Alpha = 1,
                    Background = "background",
                    Gradient = new Default(),
                    Height = 0,
                    Radius = new Max(),
                    Width = 0,
                },
            ],
        };

        SolidColorSolidColorOverlay copied = new(model);

        Assert.Equal(model, copied);
    }
}
