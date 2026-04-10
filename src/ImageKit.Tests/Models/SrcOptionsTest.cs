using System.Collections.Generic;
using System.Text.Json;
using ImageKit.Core;
using ImageKit.Models;

namespace ImageKit.Tests.Models;

public class SrcOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SrcOptions
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SrcOptions
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SrcOptions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SrcOptions
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SrcOptions>(
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SrcOptions
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SrcOptions
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
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SrcOptions
        {
            Src = "/my-image.jpg",
            UrlEndpoint = "https://ik.imagekit.io/demo",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SrcOptions
        {
            Src = "/my-image.jpg",
            UrlEndpoint = "https://ik.imagekit.io/demo",

            // Null should be interpreted as omitted for these properties
            ExpiresIn = null,
            QueryParameters = null,
            Signed = null,
            Transformation = null,
            TransformationPosition = null,
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
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SrcOptions
        {
            Src = "/my-image.jpg",
            UrlEndpoint = "https://ik.imagekit.io/demo",

            // Null should be interpreted as omitted for these properties
            ExpiresIn = null,
            QueryParameters = null,
            Signed = null,
            Transformation = null,
            TransformationPosition = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SrcOptions
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
        };

        SrcOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}
