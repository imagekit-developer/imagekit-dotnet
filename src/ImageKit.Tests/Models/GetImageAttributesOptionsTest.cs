using System.Collections.Generic;
using System.Text.Json;
using ImageKit.Core;
using ImageKit.Models;

namespace ImageKit.Tests.Models;

public class GetImageAttributesOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GetImageAttributesOptions
        {
            Src = "/my-image.jpg",
            UrlEndpoint = "https://ik.imagekit.io/demo",
            ExpiresIn = 0,
            QueryParameters = new Dictionary<string, string>() { { "foo", "string" } },
            Signed = true,
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
            TransformationPosition = TransformationPosition.Path,
            DeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840],
            ImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384],
            Sizes = "(min-width: 768px) 50vw, 100vw",
            Width = 400,
        };

        string expectedSrc = "/my-image.jpg";
        string expectedUrlEndpoint = "https://ik.imagekit.io/demo";
        double expectedExpiresIn = 0;
        Dictionary<string, string> expectedQueryParameters = new() { { "foo", "string" } };
        bool expectedSigned = true;
        List<Transformation> expectedTransformation =
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
        ];
        ApiEnum<string, TransformationPosition> expectedTransformationPosition =
            TransformationPosition.Path;
        List<double> expectedDeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840];
        List<double> expectedImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384];
        string expectedSizes = "(min-width: 768px) 50vw, 100vw";
        double expectedWidth = 400;

        Assert.Equal(expectedSrc, model.Src);
        Assert.Equal(expectedUrlEndpoint, model.UrlEndpoint);
        Assert.Equal(expectedExpiresIn, model.ExpiresIn);
        Assert.NotNull(model.QueryParameters);
        Assert.Equal(expectedQueryParameters.Count, model.QueryParameters.Count);
        foreach (var item in expectedQueryParameters)
        {
            Assert.True(model.QueryParameters.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.QueryParameters[item.Key]);
        }
        Assert.Equal(expectedSigned, model.Signed);
        Assert.NotNull(model.Transformation);
        Assert.Equal(expectedTransformation.Count, model.Transformation.Count);
        for (int i = 0; i < expectedTransformation.Count; i++)
        {
            Assert.Equal(expectedTransformation[i], model.Transformation[i]);
        }
        Assert.Equal(expectedTransformationPosition, model.TransformationPosition);
        Assert.NotNull(model.DeviceBreakpoints);
        Assert.Equal(expectedDeviceBreakpoints.Count, model.DeviceBreakpoints.Count);
        for (int i = 0; i < expectedDeviceBreakpoints.Count; i++)
        {
            Assert.Equal(expectedDeviceBreakpoints[i], model.DeviceBreakpoints[i]);
        }
        Assert.NotNull(model.ImageBreakpoints);
        Assert.Equal(expectedImageBreakpoints.Count, model.ImageBreakpoints.Count);
        for (int i = 0; i < expectedImageBreakpoints.Count; i++)
        {
            Assert.Equal(expectedImageBreakpoints[i], model.ImageBreakpoints[i]);
        }
        Assert.Equal(expectedSizes, model.Sizes);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GetImageAttributesOptions
        {
            Src = "/my-image.jpg",
            UrlEndpoint = "https://ik.imagekit.io/demo",
            ExpiresIn = 0,
            QueryParameters = new Dictionary<string, string>() { { "foo", "string" } },
            Signed = true,
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
            TransformationPosition = TransformationPosition.Path,
            DeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840],
            ImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384],
            Sizes = "(min-width: 768px) 50vw, 100vw",
            Width = 400,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GetImageAttributesOptions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GetImageAttributesOptions
        {
            Src = "/my-image.jpg",
            UrlEndpoint = "https://ik.imagekit.io/demo",
            ExpiresIn = 0,
            QueryParameters = new Dictionary<string, string>() { { "foo", "string" } },
            Signed = true,
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
            TransformationPosition = TransformationPosition.Path,
            DeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840],
            ImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384],
            Sizes = "(min-width: 768px) 50vw, 100vw",
            Width = 400,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GetImageAttributesOptions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSrc = "/my-image.jpg";
        string expectedUrlEndpoint = "https://ik.imagekit.io/demo";
        double expectedExpiresIn = 0;
        Dictionary<string, string> expectedQueryParameters = new() { { "foo", "string" } };
        bool expectedSigned = true;
        List<Transformation> expectedTransformation =
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
        ];
        ApiEnum<string, TransformationPosition> expectedTransformationPosition =
            TransformationPosition.Path;
        List<double> expectedDeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840];
        List<double> expectedImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384];
        string expectedSizes = "(min-width: 768px) 50vw, 100vw";
        double expectedWidth = 400;

        Assert.Equal(expectedSrc, deserialized.Src);
        Assert.Equal(expectedUrlEndpoint, deserialized.UrlEndpoint);
        Assert.Equal(expectedExpiresIn, deserialized.ExpiresIn);
        Assert.NotNull(deserialized.QueryParameters);
        Assert.Equal(expectedQueryParameters.Count, deserialized.QueryParameters.Count);
        foreach (var item in expectedQueryParameters)
        {
            Assert.True(deserialized.QueryParameters.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.QueryParameters[item.Key]);
        }
        Assert.Equal(expectedSigned, deserialized.Signed);
        Assert.NotNull(deserialized.Transformation);
        Assert.Equal(expectedTransformation.Count, deserialized.Transformation.Count);
        for (int i = 0; i < expectedTransformation.Count; i++)
        {
            Assert.Equal(expectedTransformation[i], deserialized.Transformation[i]);
        }
        Assert.Equal(expectedTransformationPosition, deserialized.TransformationPosition);
        Assert.NotNull(deserialized.DeviceBreakpoints);
        Assert.Equal(expectedDeviceBreakpoints.Count, deserialized.DeviceBreakpoints.Count);
        for (int i = 0; i < expectedDeviceBreakpoints.Count; i++)
        {
            Assert.Equal(expectedDeviceBreakpoints[i], deserialized.DeviceBreakpoints[i]);
        }
        Assert.NotNull(deserialized.ImageBreakpoints);
        Assert.Equal(expectedImageBreakpoints.Count, deserialized.ImageBreakpoints.Count);
        for (int i = 0; i < expectedImageBreakpoints.Count; i++)
        {
            Assert.Equal(expectedImageBreakpoints[i], deserialized.ImageBreakpoints[i]);
        }
        Assert.Equal(expectedSizes, deserialized.Sizes);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GetImageAttributesOptions
        {
            Src = "/my-image.jpg",
            UrlEndpoint = "https://ik.imagekit.io/demo",
            ExpiresIn = 0,
            QueryParameters = new Dictionary<string, string>() { { "foo", "string" } },
            Signed = true,
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
            TransformationPosition = TransformationPosition.Path,
            DeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840],
            ImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384],
            Sizes = "(min-width: 768px) 50vw, 100vw",
            Width = 400,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GetImageAttributesOptions
        {
            Src = "/my-image.jpg",
            UrlEndpoint = "https://ik.imagekit.io/demo",
        };

        Assert.Null(model.ExpiresIn);
        Assert.False(model.RawData.ContainsKey("expiresIn"));
        Assert.Null(model.QueryParameters);
        Assert.False(model.RawData.ContainsKey("queryParameters"));
        Assert.Null(model.Signed);
        Assert.False(model.RawData.ContainsKey("signed"));
        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
        Assert.Null(model.TransformationPosition);
        Assert.False(model.RawData.ContainsKey("transformationPosition"));
        Assert.Null(model.DeviceBreakpoints);
        Assert.False(model.RawData.ContainsKey("deviceBreakpoints"));
        Assert.Null(model.ImageBreakpoints);
        Assert.False(model.RawData.ContainsKey("imageBreakpoints"));
        Assert.Null(model.Sizes);
        Assert.False(model.RawData.ContainsKey("sizes"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GetImageAttributesOptions
        {
            Src = "/my-image.jpg",
            UrlEndpoint = "https://ik.imagekit.io/demo",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GetImageAttributesOptions
        {
            Src = "/my-image.jpg",
            UrlEndpoint = "https://ik.imagekit.io/demo",

            // Null should be interpreted as omitted for these properties
            ExpiresIn = null,
            QueryParameters = null,
            Signed = null,
            Transformation = null,
            TransformationPosition = null,
            DeviceBreakpoints = null,
            ImageBreakpoints = null,
            Sizes = null,
            Width = null,
        };

        Assert.Null(model.ExpiresIn);
        Assert.False(model.RawData.ContainsKey("expiresIn"));
        Assert.Null(model.QueryParameters);
        Assert.False(model.RawData.ContainsKey("queryParameters"));
        Assert.Null(model.Signed);
        Assert.False(model.RawData.ContainsKey("signed"));
        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
        Assert.Null(model.TransformationPosition);
        Assert.False(model.RawData.ContainsKey("transformationPosition"));
        Assert.Null(model.DeviceBreakpoints);
        Assert.False(model.RawData.ContainsKey("deviceBreakpoints"));
        Assert.Null(model.ImageBreakpoints);
        Assert.False(model.RawData.ContainsKey("imageBreakpoints"));
        Assert.Null(model.Sizes);
        Assert.False(model.RawData.ContainsKey("sizes"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GetImageAttributesOptions
        {
            Src = "/my-image.jpg",
            UrlEndpoint = "https://ik.imagekit.io/demo",

            // Null should be interpreted as omitted for these properties
            ExpiresIn = null,
            QueryParameters = null,
            Signed = null,
            Transformation = null,
            TransformationPosition = null,
            DeviceBreakpoints = null,
            ImageBreakpoints = null,
            Sizes = null,
            Width = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GetImageAttributesOptions
        {
            Src = "/my-image.jpg",
            UrlEndpoint = "https://ik.imagekit.io/demo",
            ExpiresIn = 0,
            QueryParameters = new Dictionary<string, string>() { { "foo", "string" } },
            Signed = true,
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
            TransformationPosition = TransformationPosition.Path,
            DeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840],
            ImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384],
            Sizes = "(min-width: 768px) 50vw, 100vw",
            Width = 400,
        };

        GetImageAttributesOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntersectionMember1
        {
            DeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840],
            ImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384],
            Sizes = "(min-width: 768px) 50vw, 100vw",
            Width = 400,
        };

        List<double> expectedDeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840];
        List<double> expectedImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384];
        string expectedSizes = "(min-width: 768px) 50vw, 100vw";
        double expectedWidth = 400;

        Assert.NotNull(model.DeviceBreakpoints);
        Assert.Equal(expectedDeviceBreakpoints.Count, model.DeviceBreakpoints.Count);
        for (int i = 0; i < expectedDeviceBreakpoints.Count; i++)
        {
            Assert.Equal(expectedDeviceBreakpoints[i], model.DeviceBreakpoints[i]);
        }
        Assert.NotNull(model.ImageBreakpoints);
        Assert.Equal(expectedImageBreakpoints.Count, model.ImageBreakpoints.Count);
        for (int i = 0; i < expectedImageBreakpoints.Count; i++)
        {
            Assert.Equal(expectedImageBreakpoints[i], model.ImageBreakpoints[i]);
        }
        Assert.Equal(expectedSizes, model.Sizes);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntersectionMember1
        {
            DeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840],
            ImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384],
            Sizes = "(min-width: 768px) 50vw, 100vw",
            Width = 400,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntersectionMember1
        {
            DeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840],
            ImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384],
            Sizes = "(min-width: 768px) 50vw, 100vw",
            Width = 400,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<double> expectedDeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840];
        List<double> expectedImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384];
        string expectedSizes = "(min-width: 768px) 50vw, 100vw";
        double expectedWidth = 400;

        Assert.NotNull(deserialized.DeviceBreakpoints);
        Assert.Equal(expectedDeviceBreakpoints.Count, deserialized.DeviceBreakpoints.Count);
        for (int i = 0; i < expectedDeviceBreakpoints.Count; i++)
        {
            Assert.Equal(expectedDeviceBreakpoints[i], deserialized.DeviceBreakpoints[i]);
        }
        Assert.NotNull(deserialized.ImageBreakpoints);
        Assert.Equal(expectedImageBreakpoints.Count, deserialized.ImageBreakpoints.Count);
        for (int i = 0; i < expectedImageBreakpoints.Count; i++)
        {
            Assert.Equal(expectedImageBreakpoints[i], deserialized.ImageBreakpoints[i]);
        }
        Assert.Equal(expectedSizes, deserialized.Sizes);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntersectionMember1
        {
            DeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840],
            ImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384],
            Sizes = "(min-width: 768px) 50vw, 100vw",
            Width = 400,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IntersectionMember1 { };

        Assert.Null(model.DeviceBreakpoints);
        Assert.False(model.RawData.ContainsKey("deviceBreakpoints"));
        Assert.Null(model.ImageBreakpoints);
        Assert.False(model.RawData.ContainsKey("imageBreakpoints"));
        Assert.Null(model.Sizes);
        Assert.False(model.RawData.ContainsKey("sizes"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new IntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new IntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            DeviceBreakpoints = null,
            ImageBreakpoints = null,
            Sizes = null,
            Width = null,
        };

        Assert.Null(model.DeviceBreakpoints);
        Assert.False(model.RawData.ContainsKey("deviceBreakpoints"));
        Assert.Null(model.ImageBreakpoints);
        Assert.False(model.RawData.ContainsKey("imageBreakpoints"));
        Assert.Null(model.Sizes);
        Assert.False(model.RawData.ContainsKey("sizes"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            DeviceBreakpoints = null,
            ImageBreakpoints = null,
            Sizes = null,
            Width = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntersectionMember1
        {
            DeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840],
            ImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384],
            Sizes = "(min-width: 768px) 50vw, 100vw",
            Width = 400,
        };

        IntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}
