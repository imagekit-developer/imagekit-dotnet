using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models;

namespace Imagekit.Tests.Models;

public class TransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Transformation
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
                        Radius = new TextOverlayTransformationRadiusUnionMember1(),
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
        };

        string expectedAIChangeBackground = "aiChangeBackground";
        AIDropShadow expectedAIDropShadow = new AIDropShadowUnionMember0();
        string expectedAIEdit = "aiEdit";
        ApiEnum<bool, AIRemoveBackground> expectedAIRemoveBackground = AIRemoveBackground.True;
        ApiEnum<bool, AIRemoveBackgroundExternal> expectedAIRemoveBackgroundExternal =
            AIRemoveBackgroundExternal.True;
        ApiEnum<bool, AIRetouch> expectedAIRetouch = AIRetouch.True;
        ApiEnum<bool, AIUpscale> expectedAIUpscale = AIUpscale.True;
        ApiEnum<bool, AIVariation> expectedAIVariation = AIVariation.True;
        AspectRatio expectedAspectRatio = "4:3";
        ApiEnum<string, AudioCodec> expectedAudioCodec = AudioCodec.Aac;
        string expectedBackground = "red";
        double expectedBlur = 10;
        string expectedBorder = "5_FF0000";
        string expectedColorize = "colorize";
        bool expectedColorProfile = true;
        string expectedColorReplace = "colorReplace";
        ApiEnum<bool, ContrastStretch> expectedContrastStretch = ContrastStretch.True;
        ApiEnum<string, Crop> expectedCrop = Crop.Force;
        ApiEnum<string, CropMode> expectedCropMode = CropMode.PadResize;
        string expectedDefaultImage = "defaultImage";
        string expectedDistort = "distort";
        double expectedDpr = 2;
        TransformationDuration expectedDuration = 0;
        EndOffset expectedEndOffset = 0;
        ApiEnum<string, TransformationFlip> expectedFlip = TransformationFlip.H;
        string expectedFocus = "center";
        ApiEnum<string, Format> expectedFormat = Format.Auto;
        TransformationGradient expectedGradient = new TransformationGradientUnionMember0();
        ApiEnum<bool, Grayscale> expectedGrayscale = Grayscale.True;
        TransformationHeight expectedHeight = 200;
        bool expectedLossless = true;
        bool expectedMetadata = true;
        string expectedNamed = "named";
        double expectedOpacity = 0;
        bool expectedOriginal = true;
        Overlay expectedOverlay = new TextOverlay()
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
                    Radius = new TextOverlayTransformationRadiusUnionMember1(),
                    Rotation = 0,
                    Typography = "typography",
                    Width = 0,
                },
            ],
        };
        Page expectedPage = 0;
        bool expectedProgressive = true;
        double expectedQuality = 80;
        TransformationRadius expectedRadius = 20;
        string expectedRaw = "raw";
        TransformationRotation expectedRotation = 90;
        Shadow expectedShadow = new ShadowUnionMember0();
        Sharpen expectedSharpen = new SharpenUnionMember0();
        StartOffset expectedStartOffset = 0;
        List<ApiEnum<string, StreamingResolution>> expectedStreamingResolutions =
        [
            StreamingResolution.V240,
        ];
        Trim expectedTrim = new TrimUnionMember0();
        UnsharpMask expectedUnsharpMask = new UnsharpMaskUnionMember0();
        ApiEnum<string, VideoCodec> expectedVideoCodec = VideoCodec.H264;
        TransformationWidth expectedWidth = 300;
        TransformationX expectedX = 0;
        TransformationXCenter expectedXCenter = 0;
        TransformationY expectedY = 0;
        TransformationYCenter expectedYCenter = 0;
        double expectedZoom = 0;

        Assert.Equal(expectedAIChangeBackground, model.AIChangeBackground);
        Assert.Equal(expectedAIDropShadow, model.AIDropShadow);
        Assert.Equal(expectedAIEdit, model.AIEdit);
        Assert.Equal(expectedAIRemoveBackground, model.AIRemoveBackground);
        Assert.Equal(expectedAIRemoveBackgroundExternal, model.AIRemoveBackgroundExternal);
        Assert.Equal(expectedAIRetouch, model.AIRetouch);
        Assert.Equal(expectedAIUpscale, model.AIUpscale);
        Assert.Equal(expectedAIVariation, model.AIVariation);
        Assert.Equal(expectedAspectRatio, model.AspectRatio);
        Assert.Equal(expectedAudioCodec, model.AudioCodec);
        Assert.Equal(expectedBackground, model.Background);
        Assert.Equal(expectedBlur, model.Blur);
        Assert.Equal(expectedBorder, model.Border);
        Assert.Equal(expectedColorize, model.Colorize);
        Assert.Equal(expectedColorProfile, model.ColorProfile);
        Assert.Equal(expectedColorReplace, model.ColorReplace);
        Assert.Equal(expectedContrastStretch, model.ContrastStretch);
        Assert.Equal(expectedCrop, model.Crop);
        Assert.Equal(expectedCropMode, model.CropMode);
        Assert.Equal(expectedDefaultImage, model.DefaultImage);
        Assert.Equal(expectedDistort, model.Distort);
        Assert.Equal(expectedDpr, model.Dpr);
        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedEndOffset, model.EndOffset);
        Assert.Equal(expectedFlip, model.Flip);
        Assert.Equal(expectedFocus, model.Focus);
        Assert.Equal(expectedFormat, model.Format);
        Assert.Equal(expectedGradient, model.Gradient);
        Assert.Equal(expectedGrayscale, model.Grayscale);
        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedLossless, model.Lossless);
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedNamed, model.Named);
        Assert.Equal(expectedOpacity, model.Opacity);
        Assert.Equal(expectedOriginal, model.Original);
        Assert.Equal(expectedOverlay, model.Overlay);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedProgressive, model.Progressive);
        Assert.Equal(expectedQuality, model.Quality);
        Assert.Equal(expectedRadius, model.Radius);
        Assert.Equal(expectedRaw, model.Raw);
        Assert.Equal(expectedRotation, model.Rotation);
        Assert.Equal(expectedShadow, model.Shadow);
        Assert.Equal(expectedSharpen, model.Sharpen);
        Assert.Equal(expectedStartOffset, model.StartOffset);
        Assert.NotNull(model.StreamingResolutions);
        Assert.Equal(expectedStreamingResolutions.Count, model.StreamingResolutions.Count);
        for (int i = 0; i < expectedStreamingResolutions.Count; i++)
        {
            Assert.Equal(expectedStreamingResolutions[i], model.StreamingResolutions[i]);
        }
        Assert.Equal(expectedTrim, model.Trim);
        Assert.Equal(expectedUnsharpMask, model.UnsharpMask);
        Assert.Equal(expectedVideoCodec, model.VideoCodec);
        Assert.Equal(expectedWidth, model.Width);
        Assert.Equal(expectedX, model.X);
        Assert.Equal(expectedXCenter, model.XCenter);
        Assert.Equal(expectedY, model.Y);
        Assert.Equal(expectedYCenter, model.YCenter);
        Assert.Equal(expectedZoom, model.Zoom);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Transformation
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
                        Radius = new TextOverlayTransformationRadiusUnionMember1(),
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Transformation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Transformation
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
                        Radius = new TextOverlayTransformationRadiusUnionMember1(),
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Transformation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAIChangeBackground = "aiChangeBackground";
        AIDropShadow expectedAIDropShadow = new AIDropShadowUnionMember0();
        string expectedAIEdit = "aiEdit";
        ApiEnum<bool, AIRemoveBackground> expectedAIRemoveBackground = AIRemoveBackground.True;
        ApiEnum<bool, AIRemoveBackgroundExternal> expectedAIRemoveBackgroundExternal =
            AIRemoveBackgroundExternal.True;
        ApiEnum<bool, AIRetouch> expectedAIRetouch = AIRetouch.True;
        ApiEnum<bool, AIUpscale> expectedAIUpscale = AIUpscale.True;
        ApiEnum<bool, AIVariation> expectedAIVariation = AIVariation.True;
        AspectRatio expectedAspectRatio = "4:3";
        ApiEnum<string, AudioCodec> expectedAudioCodec = AudioCodec.Aac;
        string expectedBackground = "red";
        double expectedBlur = 10;
        string expectedBorder = "5_FF0000";
        string expectedColorize = "colorize";
        bool expectedColorProfile = true;
        string expectedColorReplace = "colorReplace";
        ApiEnum<bool, ContrastStretch> expectedContrastStretch = ContrastStretch.True;
        ApiEnum<string, Crop> expectedCrop = Crop.Force;
        ApiEnum<string, CropMode> expectedCropMode = CropMode.PadResize;
        string expectedDefaultImage = "defaultImage";
        string expectedDistort = "distort";
        double expectedDpr = 2;
        TransformationDuration expectedDuration = 0;
        EndOffset expectedEndOffset = 0;
        ApiEnum<string, TransformationFlip> expectedFlip = TransformationFlip.H;
        string expectedFocus = "center";
        ApiEnum<string, Format> expectedFormat = Format.Auto;
        TransformationGradient expectedGradient = new TransformationGradientUnionMember0();
        ApiEnum<bool, Grayscale> expectedGrayscale = Grayscale.True;
        TransformationHeight expectedHeight = 200;
        bool expectedLossless = true;
        bool expectedMetadata = true;
        string expectedNamed = "named";
        double expectedOpacity = 0;
        bool expectedOriginal = true;
        Overlay expectedOverlay = new TextOverlay()
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
                    Radius = new TextOverlayTransformationRadiusUnionMember1(),
                    Rotation = 0,
                    Typography = "typography",
                    Width = 0,
                },
            ],
        };
        Page expectedPage = 0;
        bool expectedProgressive = true;
        double expectedQuality = 80;
        TransformationRadius expectedRadius = 20;
        string expectedRaw = "raw";
        TransformationRotation expectedRotation = 90;
        Shadow expectedShadow = new ShadowUnionMember0();
        Sharpen expectedSharpen = new SharpenUnionMember0();
        StartOffset expectedStartOffset = 0;
        List<ApiEnum<string, StreamingResolution>> expectedStreamingResolutions =
        [
            StreamingResolution.V240,
        ];
        Trim expectedTrim = new TrimUnionMember0();
        UnsharpMask expectedUnsharpMask = new UnsharpMaskUnionMember0();
        ApiEnum<string, VideoCodec> expectedVideoCodec = VideoCodec.H264;
        TransformationWidth expectedWidth = 300;
        TransformationX expectedX = 0;
        TransformationXCenter expectedXCenter = 0;
        TransformationY expectedY = 0;
        TransformationYCenter expectedYCenter = 0;
        double expectedZoom = 0;

        Assert.Equal(expectedAIChangeBackground, deserialized.AIChangeBackground);
        Assert.Equal(expectedAIDropShadow, deserialized.AIDropShadow);
        Assert.Equal(expectedAIEdit, deserialized.AIEdit);
        Assert.Equal(expectedAIRemoveBackground, deserialized.AIRemoveBackground);
        Assert.Equal(expectedAIRemoveBackgroundExternal, deserialized.AIRemoveBackgroundExternal);
        Assert.Equal(expectedAIRetouch, deserialized.AIRetouch);
        Assert.Equal(expectedAIUpscale, deserialized.AIUpscale);
        Assert.Equal(expectedAIVariation, deserialized.AIVariation);
        Assert.Equal(expectedAspectRatio, deserialized.AspectRatio);
        Assert.Equal(expectedAudioCodec, deserialized.AudioCodec);
        Assert.Equal(expectedBackground, deserialized.Background);
        Assert.Equal(expectedBlur, deserialized.Blur);
        Assert.Equal(expectedBorder, deserialized.Border);
        Assert.Equal(expectedColorize, deserialized.Colorize);
        Assert.Equal(expectedColorProfile, deserialized.ColorProfile);
        Assert.Equal(expectedColorReplace, deserialized.ColorReplace);
        Assert.Equal(expectedContrastStretch, deserialized.ContrastStretch);
        Assert.Equal(expectedCrop, deserialized.Crop);
        Assert.Equal(expectedCropMode, deserialized.CropMode);
        Assert.Equal(expectedDefaultImage, deserialized.DefaultImage);
        Assert.Equal(expectedDistort, deserialized.Distort);
        Assert.Equal(expectedDpr, deserialized.Dpr);
        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedEndOffset, deserialized.EndOffset);
        Assert.Equal(expectedFlip, deserialized.Flip);
        Assert.Equal(expectedFocus, deserialized.Focus);
        Assert.Equal(expectedFormat, deserialized.Format);
        Assert.Equal(expectedGradient, deserialized.Gradient);
        Assert.Equal(expectedGrayscale, deserialized.Grayscale);
        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedLossless, deserialized.Lossless);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.Equal(expectedNamed, deserialized.Named);
        Assert.Equal(expectedOpacity, deserialized.Opacity);
        Assert.Equal(expectedOriginal, deserialized.Original);
        Assert.Equal(expectedOverlay, deserialized.Overlay);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedProgressive, deserialized.Progressive);
        Assert.Equal(expectedQuality, deserialized.Quality);
        Assert.Equal(expectedRadius, deserialized.Radius);
        Assert.Equal(expectedRaw, deserialized.Raw);
        Assert.Equal(expectedRotation, deserialized.Rotation);
        Assert.Equal(expectedShadow, deserialized.Shadow);
        Assert.Equal(expectedSharpen, deserialized.Sharpen);
        Assert.Equal(expectedStartOffset, deserialized.StartOffset);
        Assert.NotNull(deserialized.StreamingResolutions);
        Assert.Equal(expectedStreamingResolutions.Count, deserialized.StreamingResolutions.Count);
        for (int i = 0; i < expectedStreamingResolutions.Count; i++)
        {
            Assert.Equal(expectedStreamingResolutions[i], deserialized.StreamingResolutions[i]);
        }
        Assert.Equal(expectedTrim, deserialized.Trim);
        Assert.Equal(expectedUnsharpMask, deserialized.UnsharpMask);
        Assert.Equal(expectedVideoCodec, deserialized.VideoCodec);
        Assert.Equal(expectedWidth, deserialized.Width);
        Assert.Equal(expectedX, deserialized.X);
        Assert.Equal(expectedXCenter, deserialized.XCenter);
        Assert.Equal(expectedY, deserialized.Y);
        Assert.Equal(expectedYCenter, deserialized.YCenter);
        Assert.Equal(expectedZoom, deserialized.Zoom);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Transformation
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
                        Radius = new TextOverlayTransformationRadiusUnionMember1(),
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Transformation { };

        Assert.Null(model.AIChangeBackground);
        Assert.False(model.RawData.ContainsKey("aiChangeBackground"));
        Assert.Null(model.AIDropShadow);
        Assert.False(model.RawData.ContainsKey("aiDropShadow"));
        Assert.Null(model.AIEdit);
        Assert.False(model.RawData.ContainsKey("aiEdit"));
        Assert.Null(model.AIRemoveBackground);
        Assert.False(model.RawData.ContainsKey("aiRemoveBackground"));
        Assert.Null(model.AIRemoveBackgroundExternal);
        Assert.False(model.RawData.ContainsKey("aiRemoveBackgroundExternal"));
        Assert.Null(model.AIRetouch);
        Assert.False(model.RawData.ContainsKey("aiRetouch"));
        Assert.Null(model.AIUpscale);
        Assert.False(model.RawData.ContainsKey("aiUpscale"));
        Assert.Null(model.AIVariation);
        Assert.False(model.RawData.ContainsKey("aiVariation"));
        Assert.Null(model.AspectRatio);
        Assert.False(model.RawData.ContainsKey("aspectRatio"));
        Assert.Null(model.AudioCodec);
        Assert.False(model.RawData.ContainsKey("audioCodec"));
        Assert.Null(model.Background);
        Assert.False(model.RawData.ContainsKey("background"));
        Assert.Null(model.Blur);
        Assert.False(model.RawData.ContainsKey("blur"));
        Assert.Null(model.Border);
        Assert.False(model.RawData.ContainsKey("border"));
        Assert.Null(model.Colorize);
        Assert.False(model.RawData.ContainsKey("colorize"));
        Assert.Null(model.ColorProfile);
        Assert.False(model.RawData.ContainsKey("colorProfile"));
        Assert.Null(model.ColorReplace);
        Assert.False(model.RawData.ContainsKey("colorReplace"));
        Assert.Null(model.ContrastStretch);
        Assert.False(model.RawData.ContainsKey("contrastStretch"));
        Assert.Null(model.Crop);
        Assert.False(model.RawData.ContainsKey("crop"));
        Assert.Null(model.CropMode);
        Assert.False(model.RawData.ContainsKey("cropMode"));
        Assert.Null(model.DefaultImage);
        Assert.False(model.RawData.ContainsKey("defaultImage"));
        Assert.Null(model.Distort);
        Assert.False(model.RawData.ContainsKey("distort"));
        Assert.Null(model.Dpr);
        Assert.False(model.RawData.ContainsKey("dpr"));
        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.EndOffset);
        Assert.False(model.RawData.ContainsKey("endOffset"));
        Assert.Null(model.Flip);
        Assert.False(model.RawData.ContainsKey("flip"));
        Assert.Null(model.Focus);
        Assert.False(model.RawData.ContainsKey("focus"));
        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.Gradient);
        Assert.False(model.RawData.ContainsKey("gradient"));
        Assert.Null(model.Grayscale);
        Assert.False(model.RawData.ContainsKey("grayscale"));
        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.Lossless);
        Assert.False(model.RawData.ContainsKey("lossless"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Named);
        Assert.False(model.RawData.ContainsKey("named"));
        Assert.Null(model.Opacity);
        Assert.False(model.RawData.ContainsKey("opacity"));
        Assert.Null(model.Original);
        Assert.False(model.RawData.ContainsKey("original"));
        Assert.Null(model.Overlay);
        Assert.False(model.RawData.ContainsKey("overlay"));
        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.Progressive);
        Assert.False(model.RawData.ContainsKey("progressive"));
        Assert.Null(model.Quality);
        Assert.False(model.RawData.ContainsKey("quality"));
        Assert.Null(model.Radius);
        Assert.False(model.RawData.ContainsKey("radius"));
        Assert.Null(model.Raw);
        Assert.False(model.RawData.ContainsKey("raw"));
        Assert.Null(model.Rotation);
        Assert.False(model.RawData.ContainsKey("rotation"));
        Assert.Null(model.Shadow);
        Assert.False(model.RawData.ContainsKey("shadow"));
        Assert.Null(model.Sharpen);
        Assert.False(model.RawData.ContainsKey("sharpen"));
        Assert.Null(model.StartOffset);
        Assert.False(model.RawData.ContainsKey("startOffset"));
        Assert.Null(model.StreamingResolutions);
        Assert.False(model.RawData.ContainsKey("streamingResolutions"));
        Assert.Null(model.Trim);
        Assert.False(model.RawData.ContainsKey("trim"));
        Assert.Null(model.UnsharpMask);
        Assert.False(model.RawData.ContainsKey("unsharpMask"));
        Assert.Null(model.VideoCodec);
        Assert.False(model.RawData.ContainsKey("videoCodec"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
        Assert.Null(model.X);
        Assert.False(model.RawData.ContainsKey("x"));
        Assert.Null(model.XCenter);
        Assert.False(model.RawData.ContainsKey("xCenter"));
        Assert.Null(model.Y);
        Assert.False(model.RawData.ContainsKey("y"));
        Assert.Null(model.YCenter);
        Assert.False(model.RawData.ContainsKey("yCenter"));
        Assert.Null(model.Zoom);
        Assert.False(model.RawData.ContainsKey("zoom"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Transformation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Transformation
        {
            // Null should be interpreted as omitted for these properties
            AIChangeBackground = null,
            AIDropShadow = null,
            AIEdit = null,
            AIRemoveBackground = null,
            AIRemoveBackgroundExternal = null,
            AIRetouch = null,
            AIUpscale = null,
            AIVariation = null,
            AspectRatio = null,
            AudioCodec = null,
            Background = null,
            Blur = null,
            Border = null,
            Colorize = null,
            ColorProfile = null,
            ColorReplace = null,
            ContrastStretch = null,
            Crop = null,
            CropMode = null,
            DefaultImage = null,
            Distort = null,
            Dpr = null,
            Duration = null,
            EndOffset = null,
            Flip = null,
            Focus = null,
            Format = null,
            Gradient = null,
            Grayscale = null,
            Height = null,
            Lossless = null,
            Metadata = null,
            Named = null,
            Opacity = null,
            Original = null,
            Overlay = null,
            Page = null,
            Progressive = null,
            Quality = null,
            Radius = null,
            Raw = null,
            Rotation = null,
            Shadow = null,
            Sharpen = null,
            StartOffset = null,
            StreamingResolutions = null,
            Trim = null,
            UnsharpMask = null,
            VideoCodec = null,
            Width = null,
            X = null,
            XCenter = null,
            Y = null,
            YCenter = null,
            Zoom = null,
        };

        Assert.Null(model.AIChangeBackground);
        Assert.False(model.RawData.ContainsKey("aiChangeBackground"));
        Assert.Null(model.AIDropShadow);
        Assert.False(model.RawData.ContainsKey("aiDropShadow"));
        Assert.Null(model.AIEdit);
        Assert.False(model.RawData.ContainsKey("aiEdit"));
        Assert.Null(model.AIRemoveBackground);
        Assert.False(model.RawData.ContainsKey("aiRemoveBackground"));
        Assert.Null(model.AIRemoveBackgroundExternal);
        Assert.False(model.RawData.ContainsKey("aiRemoveBackgroundExternal"));
        Assert.Null(model.AIRetouch);
        Assert.False(model.RawData.ContainsKey("aiRetouch"));
        Assert.Null(model.AIUpscale);
        Assert.False(model.RawData.ContainsKey("aiUpscale"));
        Assert.Null(model.AIVariation);
        Assert.False(model.RawData.ContainsKey("aiVariation"));
        Assert.Null(model.AspectRatio);
        Assert.False(model.RawData.ContainsKey("aspectRatio"));
        Assert.Null(model.AudioCodec);
        Assert.False(model.RawData.ContainsKey("audioCodec"));
        Assert.Null(model.Background);
        Assert.False(model.RawData.ContainsKey("background"));
        Assert.Null(model.Blur);
        Assert.False(model.RawData.ContainsKey("blur"));
        Assert.Null(model.Border);
        Assert.False(model.RawData.ContainsKey("border"));
        Assert.Null(model.Colorize);
        Assert.False(model.RawData.ContainsKey("colorize"));
        Assert.Null(model.ColorProfile);
        Assert.False(model.RawData.ContainsKey("colorProfile"));
        Assert.Null(model.ColorReplace);
        Assert.False(model.RawData.ContainsKey("colorReplace"));
        Assert.Null(model.ContrastStretch);
        Assert.False(model.RawData.ContainsKey("contrastStretch"));
        Assert.Null(model.Crop);
        Assert.False(model.RawData.ContainsKey("crop"));
        Assert.Null(model.CropMode);
        Assert.False(model.RawData.ContainsKey("cropMode"));
        Assert.Null(model.DefaultImage);
        Assert.False(model.RawData.ContainsKey("defaultImage"));
        Assert.Null(model.Distort);
        Assert.False(model.RawData.ContainsKey("distort"));
        Assert.Null(model.Dpr);
        Assert.False(model.RawData.ContainsKey("dpr"));
        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.EndOffset);
        Assert.False(model.RawData.ContainsKey("endOffset"));
        Assert.Null(model.Flip);
        Assert.False(model.RawData.ContainsKey("flip"));
        Assert.Null(model.Focus);
        Assert.False(model.RawData.ContainsKey("focus"));
        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.Gradient);
        Assert.False(model.RawData.ContainsKey("gradient"));
        Assert.Null(model.Grayscale);
        Assert.False(model.RawData.ContainsKey("grayscale"));
        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.Lossless);
        Assert.False(model.RawData.ContainsKey("lossless"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Named);
        Assert.False(model.RawData.ContainsKey("named"));
        Assert.Null(model.Opacity);
        Assert.False(model.RawData.ContainsKey("opacity"));
        Assert.Null(model.Original);
        Assert.False(model.RawData.ContainsKey("original"));
        Assert.Null(model.Overlay);
        Assert.False(model.RawData.ContainsKey("overlay"));
        Assert.Null(model.Page);
        Assert.False(model.RawData.ContainsKey("page"));
        Assert.Null(model.Progressive);
        Assert.False(model.RawData.ContainsKey("progressive"));
        Assert.Null(model.Quality);
        Assert.False(model.RawData.ContainsKey("quality"));
        Assert.Null(model.Radius);
        Assert.False(model.RawData.ContainsKey("radius"));
        Assert.Null(model.Raw);
        Assert.False(model.RawData.ContainsKey("raw"));
        Assert.Null(model.Rotation);
        Assert.False(model.RawData.ContainsKey("rotation"));
        Assert.Null(model.Shadow);
        Assert.False(model.RawData.ContainsKey("shadow"));
        Assert.Null(model.Sharpen);
        Assert.False(model.RawData.ContainsKey("sharpen"));
        Assert.Null(model.StartOffset);
        Assert.False(model.RawData.ContainsKey("startOffset"));
        Assert.Null(model.StreamingResolutions);
        Assert.False(model.RawData.ContainsKey("streamingResolutions"));
        Assert.Null(model.Trim);
        Assert.False(model.RawData.ContainsKey("trim"));
        Assert.Null(model.UnsharpMask);
        Assert.False(model.RawData.ContainsKey("unsharpMask"));
        Assert.Null(model.VideoCodec);
        Assert.False(model.RawData.ContainsKey("videoCodec"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
        Assert.Null(model.X);
        Assert.False(model.RawData.ContainsKey("x"));
        Assert.Null(model.XCenter);
        Assert.False(model.RawData.ContainsKey("xCenter"));
        Assert.Null(model.Y);
        Assert.False(model.RawData.ContainsKey("y"));
        Assert.Null(model.YCenter);
        Assert.False(model.RawData.ContainsKey("yCenter"));
        Assert.Null(model.Zoom);
        Assert.False(model.RawData.ContainsKey("zoom"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Transformation
        {
            // Null should be interpreted as omitted for these properties
            AIChangeBackground = null,
            AIDropShadow = null,
            AIEdit = null,
            AIRemoveBackground = null,
            AIRemoveBackgroundExternal = null,
            AIRetouch = null,
            AIUpscale = null,
            AIVariation = null,
            AspectRatio = null,
            AudioCodec = null,
            Background = null,
            Blur = null,
            Border = null,
            Colorize = null,
            ColorProfile = null,
            ColorReplace = null,
            ContrastStretch = null,
            Crop = null,
            CropMode = null,
            DefaultImage = null,
            Distort = null,
            Dpr = null,
            Duration = null,
            EndOffset = null,
            Flip = null,
            Focus = null,
            Format = null,
            Gradient = null,
            Grayscale = null,
            Height = null,
            Lossless = null,
            Metadata = null,
            Named = null,
            Opacity = null,
            Original = null,
            Overlay = null,
            Page = null,
            Progressive = null,
            Quality = null,
            Radius = null,
            Raw = null,
            Rotation = null,
            Shadow = null,
            Sharpen = null,
            StartOffset = null,
            StreamingResolutions = null,
            Trim = null,
            UnsharpMask = null,
            VideoCodec = null,
            Width = null,
            X = null,
            XCenter = null,
            Y = null,
            YCenter = null,
            Zoom = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Transformation
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
                        Radius = new TextOverlayTransformationRadiusUnionMember1(),
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
        };

        Transformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AIDropShadowTest : TestBase
{
    [Fact]
    public void TrueValidationWorks()
    {
        AIDropShadow value = new AIDropShadowUnionMember0();
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AIDropShadow value = "string";
        value.Validate();
    }

    [Fact]
    public void TrueSerializationRoundtripWorks()
    {
        AIDropShadow value = new AIDropShadowUnionMember0();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AIDropShadow>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AIDropShadow value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AIDropShadow>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AIDropShadowUnionMember0Test : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new AIDropShadowUnionMember0();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<AIDropShadowUnionMember0>(
            JsonSerializer.SerializeToElement(true),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<AIDropShadowUnionMember0>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new AIDropShadowUnionMember0();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AIDropShadowUnionMember0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<AIDropShadowUnionMember0>(
            JsonSerializer.SerializeToElement(true),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AIDropShadowUnionMember0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<AIDropShadowUnionMember0>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AIDropShadowUnionMember0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class AIRemoveBackgroundTest : TestBase
{
    [Theory]
    [InlineData(AIRemoveBackground.True)]
    public void Validation_Works(AIRemoveBackground rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, AIRemoveBackground> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, AIRemoveBackground>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AIRemoveBackground.True)]
    public void SerializationRoundtrip_Works(AIRemoveBackground rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, AIRemoveBackground> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, AIRemoveBackground>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, AIRemoveBackground>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, AIRemoveBackground>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AIRemoveBackgroundExternalTest : TestBase
{
    [Theory]
    [InlineData(AIRemoveBackgroundExternal.True)]
    public void Validation_Works(AIRemoveBackgroundExternal rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, AIRemoveBackgroundExternal> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, AIRemoveBackgroundExternal>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AIRemoveBackgroundExternal.True)]
    public void SerializationRoundtrip_Works(AIRemoveBackgroundExternal rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, AIRemoveBackgroundExternal> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, AIRemoveBackgroundExternal>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, AIRemoveBackgroundExternal>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, AIRemoveBackgroundExternal>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AIRetouchTest : TestBase
{
    [Theory]
    [InlineData(AIRetouch.True)]
    public void Validation_Works(AIRetouch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, AIRetouch> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, AIRetouch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AIRetouch.True)]
    public void SerializationRoundtrip_Works(AIRetouch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, AIRetouch> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, AIRetouch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, AIRetouch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, AIRetouch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AIUpscaleTest : TestBase
{
    [Theory]
    [InlineData(AIUpscale.True)]
    public void Validation_Works(AIUpscale rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, AIUpscale> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, AIUpscale>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AIUpscale.True)]
    public void SerializationRoundtrip_Works(AIUpscale rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, AIUpscale> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, AIUpscale>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, AIUpscale>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, AIUpscale>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AIVariationTest : TestBase
{
    [Theory]
    [InlineData(AIVariation.True)]
    public void Validation_Works(AIVariation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, AIVariation> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, AIVariation>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AIVariation.True)]
    public void SerializationRoundtrip_Works(AIVariation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, AIVariation> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, AIVariation>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, AIVariation>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, AIVariation>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AspectRatioTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        AspectRatio value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AspectRatio value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        AspectRatio value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AspectRatio>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AspectRatio value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AspectRatio>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AudioCodecTest : TestBase
{
    [Theory]
    [InlineData(AudioCodec.Aac)]
    [InlineData(AudioCodec.Opus)]
    [InlineData(AudioCodec.None)]
    public void Validation_Works(AudioCodec rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AudioCodec> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AudioCodec>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AudioCodec.Aac)]
    [InlineData(AudioCodec.Opus)]
    [InlineData(AudioCodec.None)]
    public void SerializationRoundtrip_Works(AudioCodec rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AudioCodec> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AudioCodec>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AudioCodec>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AudioCodec>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ContrastStretchTest : TestBase
{
    [Theory]
    [InlineData(ContrastStretch.True)]
    public void Validation_Works(ContrastStretch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, ContrastStretch> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, ContrastStretch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContrastStretch.True)]
    public void SerializationRoundtrip_Works(ContrastStretch rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, ContrastStretch> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, ContrastStretch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, ContrastStretch>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, ContrastStretch>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CropTest : TestBase
{
    [Theory]
    [InlineData(Crop.Force)]
    [InlineData(Crop.AtMax)]
    [InlineData(Crop.AtMaxEnlarge)]
    [InlineData(Crop.AtLeast)]
    [InlineData(Crop.MaintainRatio)]
    [InlineData(Crop.MaintainRatioNoEnlarge)]
    public void Validation_Works(Crop rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Crop> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Crop>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Crop.Force)]
    [InlineData(Crop.AtMax)]
    [InlineData(Crop.AtMaxEnlarge)]
    [InlineData(Crop.AtLeast)]
    [InlineData(Crop.MaintainRatio)]
    [InlineData(Crop.MaintainRatioNoEnlarge)]
    public void SerializationRoundtrip_Works(Crop rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Crop> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Crop>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Crop>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Crop>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CropModeTest : TestBase
{
    [Theory]
    [InlineData(CropMode.PadResize)]
    [InlineData(CropMode.Extract)]
    [InlineData(CropMode.PadExtract)]
    [InlineData(CropMode.PadResizeNoEnlarge)]
    [InlineData(CropMode.PadExtractNoShrink)]
    public void Validation_Works(CropMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CropMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CropMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CropMode.PadResize)]
    [InlineData(CropMode.Extract)]
    [InlineData(CropMode.PadExtract)]
    [InlineData(CropMode.PadResizeNoEnlarge)]
    [InlineData(CropMode.PadExtractNoShrink)]
    public void SerializationRoundtrip_Works(CropMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CropMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CropMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CropMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CropMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TransformationDurationTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        TransformationDuration value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        TransformationDuration value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        TransformationDuration value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationDuration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        TransformationDuration value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationDuration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EndOffsetTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        EndOffset value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        EndOffset value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        EndOffset value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EndOffset>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        EndOffset value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EndOffset>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TransformationFlipTest : TestBase
{
    [Theory]
    [InlineData(TransformationFlip.H)]
    [InlineData(TransformationFlip.V)]
    [InlineData(TransformationFlip.HV)]
    [InlineData(TransformationFlip.VH)]
    public void Validation_Works(TransformationFlip rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransformationFlip> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransformationFlip>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TransformationFlip.H)]
    [InlineData(TransformationFlip.V)]
    [InlineData(TransformationFlip.HV)]
    [InlineData(TransformationFlip.VH)]
    public void SerializationRoundtrip_Works(TransformationFlip rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransformationFlip> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransformationFlip>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransformationFlip>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransformationFlip>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FormatTest : TestBase
{
    [Theory]
    [InlineData(Format.Auto)]
    [InlineData(Format.Webp)]
    [InlineData(Format.Jpg)]
    [InlineData(Format.Jpeg)]
    [InlineData(Format.Png)]
    [InlineData(Format.Gif)]
    [InlineData(Format.Svg)]
    [InlineData(Format.Mp4)]
    [InlineData(Format.Webm)]
    [InlineData(Format.Avif)]
    [InlineData(Format.Orig)]
    public void Validation_Works(Format rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Format> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Format.Auto)]
    [InlineData(Format.Webp)]
    [InlineData(Format.Jpg)]
    [InlineData(Format.Jpeg)]
    [InlineData(Format.Png)]
    [InlineData(Format.Gif)]
    [InlineData(Format.Svg)]
    [InlineData(Format.Mp4)]
    [InlineData(Format.Webm)]
    [InlineData(Format.Avif)]
    [InlineData(Format.Orig)]
    public void SerializationRoundtrip_Works(Format rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Format> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TransformationGradientTest : TestBase
{
    [Fact]
    public void TrueValidationWorks()
    {
        TransformationGradient value = new TransformationGradientUnionMember0();
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        TransformationGradient value = "string";
        value.Validate();
    }

    [Fact]
    public void TrueSerializationRoundtripWorks()
    {
        TransformationGradient value = new TransformationGradientUnionMember0();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationGradient>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        TransformationGradient value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationGradient>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TransformationGradientUnionMember0Test : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new TransformationGradientUnionMember0();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<TransformationGradientUnionMember0>(
            JsonSerializer.SerializeToElement(true),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<TransformationGradientUnionMember0>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new TransformationGradientUnionMember0();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationGradientUnionMember0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<TransformationGradientUnionMember0>(
            JsonSerializer.SerializeToElement(true),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationGradientUnionMember0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<TransformationGradientUnionMember0>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationGradientUnionMember0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class GrayscaleTest : TestBase
{
    [Theory]
    [InlineData(Grayscale.True)]
    public void Validation_Works(Grayscale rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, Grayscale> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, Grayscale>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Grayscale.True)]
    public void SerializationRoundtrip_Works(Grayscale rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, Grayscale> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, Grayscale>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, Grayscale>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, Grayscale>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TransformationHeightTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        TransformationHeight value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        TransformationHeight value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        TransformationHeight value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationHeight>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        TransformationHeight value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationHeight>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        Page value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Page value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Page value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Page>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Page value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Page>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TransformationRadiusTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        TransformationRadius value = 0;
        value.Validate();
    }

    [Fact]
    public void MaxValidationWorks()
    {
        TransformationRadius value = new TransformationRadiusUnionMember1();
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        TransformationRadius value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        TransformationRadius value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationRadius>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MaxSerializationRoundtripWorks()
    {
        TransformationRadius value = new TransformationRadiusUnionMember1();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationRadius>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        TransformationRadius value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationRadius>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TransformationRadiusUnionMember1Test : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new TransformationRadiusUnionMember1();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<TransformationRadiusUnionMember1>(
            JsonSerializer.SerializeToElement("max"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<TransformationRadiusUnionMember1>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new TransformationRadiusUnionMember1();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationRadiusUnionMember1>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<TransformationRadiusUnionMember1>(
            JsonSerializer.SerializeToElement("max"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationRadiusUnionMember1>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<TransformationRadiusUnionMember1>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationRadiusUnionMember1>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class TransformationRotationTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        TransformationRotation value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        TransformationRotation value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        TransformationRotation value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationRotation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        TransformationRotation value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationRotation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ShadowTest : TestBase
{
    [Fact]
    public void TrueValidationWorks()
    {
        Shadow value = new ShadowUnionMember0();
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Shadow value = "string";
        value.Validate();
    }

    [Fact]
    public void TrueSerializationRoundtripWorks()
    {
        Shadow value = new ShadowUnionMember0();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Shadow>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Shadow value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Shadow>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ShadowUnionMember0Test : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new ShadowUnionMember0();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<ShadowUnionMember0>(
            JsonSerializer.SerializeToElement(true),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<ShadowUnionMember0>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new ShadowUnionMember0();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ShadowUnionMember0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<ShadowUnionMember0>(
            JsonSerializer.SerializeToElement(true),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ShadowUnionMember0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<ShadowUnionMember0>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ShadowUnionMember0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class SharpenTest : TestBase
{
    [Fact]
    public void TrueValidationWorks()
    {
        Sharpen value = new SharpenUnionMember0();
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        Sharpen value = 0;
        value.Validate();
    }

    [Fact]
    public void TrueSerializationRoundtripWorks()
    {
        Sharpen value = new SharpenUnionMember0();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sharpen>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Sharpen value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sharpen>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SharpenUnionMember0Test : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new SharpenUnionMember0();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<SharpenUnionMember0>(
            JsonSerializer.SerializeToElement(true),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<SharpenUnionMember0>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new SharpenUnionMember0();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SharpenUnionMember0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<SharpenUnionMember0>(
            JsonSerializer.SerializeToElement(true),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SharpenUnionMember0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<SharpenUnionMember0>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SharpenUnionMember0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class StartOffsetTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        StartOffset value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        StartOffset value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        StartOffset value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StartOffset>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        StartOffset value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StartOffset>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TrimTest : TestBase
{
    [Fact]
    public void TrueValidationWorks()
    {
        Trim value = new TrimUnionMember0();
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        Trim value = 0;
        value.Validate();
    }

    [Fact]
    public void TrueSerializationRoundtripWorks()
    {
        Trim value = new TrimUnionMember0();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Trim>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Trim value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Trim>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TrimUnionMember0Test : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new TrimUnionMember0();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<TrimUnionMember0>(
            JsonSerializer.SerializeToElement(true),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<TrimUnionMember0>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new TrimUnionMember0();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TrimUnionMember0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<TrimUnionMember0>(
            JsonSerializer.SerializeToElement(true),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TrimUnionMember0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<TrimUnionMember0>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TrimUnionMember0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class UnsharpMaskTest : TestBase
{
    [Fact]
    public void TrueValidationWorks()
    {
        UnsharpMask value = new UnsharpMaskUnionMember0();
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        UnsharpMask value = "string";
        value.Validate();
    }

    [Fact]
    public void TrueSerializationRoundtripWorks()
    {
        UnsharpMask value = new UnsharpMaskUnionMember0();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsharpMask>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        UnsharpMask value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsharpMask>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnsharpMaskUnionMember0Test : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new UnsharpMaskUnionMember0();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<UnsharpMaskUnionMember0>(
            JsonSerializer.SerializeToElement(true),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<UnsharpMaskUnionMember0>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new UnsharpMaskUnionMember0();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsharpMaskUnionMember0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UnsharpMaskUnionMember0>(
            JsonSerializer.SerializeToElement(true),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsharpMaskUnionMember0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UnsharpMaskUnionMember0>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsharpMaskUnionMember0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class VideoCodecTest : TestBase
{
    [Theory]
    [InlineData(VideoCodec.H264)]
    [InlineData(VideoCodec.Vp9)]
    [InlineData(VideoCodec.Av1)]
    [InlineData(VideoCodec.None)]
    public void Validation_Works(VideoCodec rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VideoCodec> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VideoCodec>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VideoCodec.H264)]
    [InlineData(VideoCodec.Vp9)]
    [InlineData(VideoCodec.Av1)]
    [InlineData(VideoCodec.None)]
    public void SerializationRoundtrip_Works(VideoCodec rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VideoCodec> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VideoCodec>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VideoCodec>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VideoCodec>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TransformationWidthTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        TransformationWidth value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        TransformationWidth value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        TransformationWidth value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationWidth>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        TransformationWidth value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationWidth>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TransformationXTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        TransformationX value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        TransformationX value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        TransformationX value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationX>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        TransformationX value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationX>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TransformationXCenterTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        TransformationXCenter value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        TransformationXCenter value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        TransformationXCenter value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationXCenter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        TransformationXCenter value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationXCenter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TransformationYTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        TransformationY value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        TransformationY value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        TransformationY value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationY>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        TransformationY value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationY>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TransformationYCenterTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        TransformationYCenter value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        TransformationYCenter value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        TransformationYCenter value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationYCenter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        TransformationYCenter value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationYCenter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
