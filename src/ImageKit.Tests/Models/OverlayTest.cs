using System.Text.Json;
using ImageKit.Core;
using ImageKit.Models;

namespace ImageKit.Tests.Models;

public class OverlayTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
    {
        Overlay value = new TextOverlay()
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
            Input = "input",
            Encoding = Encoding.Auto,
            Transformation =
            [
                new()
                {
                    AIChangeBackground = "aiChangeBackground",
                    AIDropShadow = new AIDropShadowUnionMember0(),
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
                    Gradient = new TransformationGradientUnionMember0(),
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
                    },
                    Page = 0,
                    Progressive = true,
                    Quality = 80,
                    Radius = 20,
                    Raw = "raw",
                    Rotation = 90,
                    Shadow = new ShadowUnionMember0(),
                    Sharpen = new SharpenUnionMember0(),
                    StartOffset = 0,
                    StreamingResolutions = [StreamingResolution.V240],
                    Trim = new TrimUnionMember0(),
                    UnsharpMask = new UnsharpMaskUnionMember0(),
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
            Input = "input",
            Encoding = VideoOverlayIntersectionMember1Encoding.Auto,
            Transformation =
            [
                new()
                {
                    AIChangeBackground = "aiChangeBackground",
                    AIDropShadow = new AIDropShadowUnionMember0(),
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
                    Gradient = new TransformationGradientUnionMember0(),
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
                    },
                    Page = 0,
                    Progressive = true,
                    Quality = 80,
                    Radius = 20,
                    Raw = "raw",
                    Rotation = 90,
                    Shadow = new ShadowUnionMember0(),
                    Sharpen = new SharpenUnionMember0(),
                    StartOffset = 0,
                    StreamingResolutions = [StreamingResolution.V240],
                    Trim = new TrimUnionMember0(),
                    UnsharpMask = new UnsharpMaskUnionMember0(),
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
        Overlay value = new SubtitleOverlay()
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
            Input = "input",
            Encoding = SubtitleOverlayIntersectionMember1Encoding.Auto,
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
        Overlay value = new SolidColorOverlay()
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
        value.Validate();
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        Overlay value = new TextOverlay()
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
            Input = "input",
            Encoding = Encoding.Auto,
            Transformation =
            [
                new()
                {
                    AIChangeBackground = "aiChangeBackground",
                    AIDropShadow = new AIDropShadowUnionMember0(),
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
                    Gradient = new TransformationGradientUnionMember0(),
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
                    },
                    Page = 0,
                    Progressive = true,
                    Quality = 80,
                    Radius = 20,
                    Raw = "raw",
                    Rotation = 90,
                    Shadow = new ShadowUnionMember0(),
                    Sharpen = new SharpenUnionMember0(),
                    StartOffset = 0,
                    StreamingResolutions = [StreamingResolution.V240],
                    Trim = new TrimUnionMember0(),
                    UnsharpMask = new UnsharpMaskUnionMember0(),
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
            Input = "input",
            Encoding = VideoOverlayIntersectionMember1Encoding.Auto,
            Transformation =
            [
                new()
                {
                    AIChangeBackground = "aiChangeBackground",
                    AIDropShadow = new AIDropShadowUnionMember0(),
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
                    Gradient = new TransformationGradientUnionMember0(),
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
                    },
                    Page = 0,
                    Progressive = true,
                    Quality = 80,
                    Radius = 20,
                    Raw = "raw",
                    Rotation = 90,
                    Shadow = new ShadowUnionMember0(),
                    Sharpen = new SharpenUnionMember0(),
                    StartOffset = 0,
                    StreamingResolutions = [StreamingResolution.V240],
                    Trim = new TrimUnionMember0(),
                    UnsharpMask = new UnsharpMaskUnionMember0(),
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
        Overlay value = new SubtitleOverlay()
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
            Input = "input",
            Encoding = SubtitleOverlayIntersectionMember1Encoding.Auto,
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
        Overlay value = new SolidColorOverlay()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Overlay>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
