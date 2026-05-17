using System;
using System.Collections.Generic;
using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.Dummy;
using SavedExtensions = ImagekitDiversion.Models.SavedExtensions;

namespace ImagekitDiversion.Tests.Models.Dummy;

public class DummyTestParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DummyTestParams
        {
            BaseOverlay = new()
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
            },
            ExtensionConfig = new RemovedotBgExtension()
            {
                Options = new()
                {
                    AddShadow = true,
                    BgColor = "bg_color",
                    BgImageUrl = "bg_image_url",
                    Semitransparency = true,
                },
            },
            Extensions =
            [
                new RemovedotBgExtension()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                new AutoTaggingExtension()
                {
                    MaxTags = 5,
                    MinConfidence = 95,
                    Name = Name.GoogleAutoTagging,
                },
                new AutoDescriptionExtension(),
                new AITasksExtension(
                    [
                        new SelectTags()
                        {
                            Instruction = "What types of clothing items are visible in this image?",
                            MaxSelections = 1,
                            MinSelections = 0,
                            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                        },
                        new YesNo()
                        {
                            Instruction = "Is this a luxury or high-end fashion item?",
                            OnNo = new()
                            {
                                AddTags = ["luxury", "premium"],
                                RemoveTags = ["budget", "affordable"],
                                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                                UnsetMetadata = [new("price_range")],
                            },
                            OnUnknown = new()
                            {
                                AddTags = ["luxury", "premium"],
                                RemoveTags = ["budget", "affordable"],
                                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                                UnsetMetadata = [new("price_range")],
                            },
                            OnYes = new()
                            {
                                AddTags = ["luxury", "premium"],
                                RemoveTags = ["budget", "affordable"],
                                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                                UnsetMetadata = [new("price_range")],
                            },
                        },
                    ]
                ),
                new SavedExtension("ext_abc123"),
            ],
            GetImageAttributesOptions = new()
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
                TransformationPosition = TransformationPosition.Path,
                DeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840],
                ImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384],
                Sizes = "(min-width: 768px) 50vw, 100vw",
                Width = 400,
            },
            ImageOverlay = new()
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
            },
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
            OverlayPosition = new()
            {
                AnchorPoint = AnchorPoint.Top,
                Focus = Focus.Center,
                X = 0,
                XCenter = 0,
                Y = 0,
                YCenter = 0,
            },
            OverlayTiming = new()
            {
                Duration = 0,
                End = 0,
                Start = 0,
            },
            ResponsiveImageAttributes = new()
            {
                Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",
                Sizes = "100vw",
                SrcSet =
                    "https://ik.imagekit.io/demo/image.jpg?tr=w-640 640w, https://ik.imagekit.io/demo/image.jpg?tr=w-1080 1080w, https://ik.imagekit.io/demo/image.jpg?tr=w-1920 1920w",
                Width = 400,
            },
            SavedExtensions = new()
            {
                ID = "ext_abc123",
                Config = new RemovedotBgExtension()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "Analyzes vehicle images for type, condition, and quality assessment",
                Name = "Car Quality Analysis",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            SolidColorOverlay = new()
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
            },
            SolidColorOverlayTransformation = new()
            {
                Alpha = 1,
                Background = "background",
                Gradient = new Default(),
                Height = 0,
                Radius = new Max(),
                Width = 0,
            },
            SrcOptions = new()
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
                TransformationPosition = TransformationPosition.Path,
            },
            StreamingResolution = StreamingResolution.V240,
            SubtitleOverlay = new()
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
                        Background = "background",
                        Color = "color",
                        FontFamily = "fontFamily",
                        FontOutline = "fontOutline",
                        FontShadow = "fontShadow",
                        FontSize = 0,
                        Typography = Typography.B,
                    },
                ],
            },
            SubtitleOverlayTransformation = new()
            {
                Background = "background",
                Color = "color",
                FontFamily = "fontFamily",
                FontOutline = "fontOutline",
                FontShadow = "fontShadow",
                FontSize = 0,
                Typography = Typography.B,
            },
            TextOverlay = new()
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
            TextOverlayTransformation = new()
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
            Transformation = new()
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
            TransformationPosition = TransformationPosition.Path,
            VideoOverlay = new()
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
            },
        };

        BaseOverlay expectedBaseOverlay = new()
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
        };
        ExtensionConfig expectedExtensionConfig = new RemovedotBgExtension()
        {
            Options = new()
            {
                AddShadow = true,
                BgColor = "bg_color",
                BgImageUrl = "bg_image_url",
                Semitransparency = true,
            },
        };
        List<ExtensionsItem> expectedExtensions =
        [
            new RemovedotBgExtension()
            {
                Options = new()
                {
                    AddShadow = true,
                    BgColor = "bg_color",
                    BgImageUrl = "bg_image_url",
                    Semitransparency = true,
                },
            },
            new AutoTaggingExtension()
            {
                MaxTags = 5,
                MinConfidence = 95,
                Name = Name.GoogleAutoTagging,
            },
            new AutoDescriptionExtension(),
            new AITasksExtension(
                [
                    new SelectTags()
                    {
                        Instruction = "What types of clothing items are visible in this image?",
                        MaxSelections = 1,
                        MinSelections = 0,
                        Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                    },
                    new YesNo()
                    {
                        Instruction = "Is this a luxury or high-end fashion item?",
                        OnNo = new()
                        {
                            AddTags = ["luxury", "premium"],
                            RemoveTags = ["budget", "affordable"],
                            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                            UnsetMetadata = [new("price_range")],
                        },
                        OnUnknown = new()
                        {
                            AddTags = ["luxury", "premium"],
                            RemoveTags = ["budget", "affordable"],
                            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                            UnsetMetadata = [new("price_range")],
                        },
                        OnYes = new()
                        {
                            AddTags = ["luxury", "premium"],
                            RemoveTags = ["budget", "affordable"],
                            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                            UnsetMetadata = [new("price_range")],
                        },
                    },
                ]
            ),
            new SavedExtension("ext_abc123"),
        ];
        GetImageAttributesOptions expectedGetImageAttributesOptions = new()
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
            TransformationPosition = TransformationPosition.Path,
            DeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840],
            ImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384],
            Sizes = "(min-width: 768px) 50vw, 100vw",
            Width = 400,
        };
        ImageOverlay expectedImageOverlay = new()
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
        Overlay expectedOverlay = new Text()
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
        OverlayPosition expectedOverlayPosition = new()
        {
            AnchorPoint = AnchorPoint.Top,
            Focus = Focus.Center,
            X = 0,
            XCenter = 0,
            Y = 0,
            YCenter = 0,
        };
        OverlayTiming expectedOverlayTiming = new()
        {
            Duration = 0,
            End = 0,
            Start = 0,
        };
        ResponsiveImageAttributes expectedResponsiveImageAttributes = new()
        {
            Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",
            Sizes = "100vw",
            SrcSet =
                "https://ik.imagekit.io/demo/image.jpg?tr=w-640 640w, https://ik.imagekit.io/demo/image.jpg?tr=w-1080 1080w, https://ik.imagekit.io/demo/image.jpg?tr=w-1920 1920w",
            Width = 400,
        };
        SavedExtensions::SavedExtension expectedSavedExtensions = new()
        {
            ID = "ext_abc123",
            Config = new RemovedotBgExtension()
            {
                Options = new()
                {
                    AddShadow = true,
                    BgColor = "bg_color",
                    BgImageUrl = "bg_image_url",
                    Semitransparency = true,
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "Analyzes vehicle images for type, condition, and quality assessment",
            Name = "Car Quality Analysis",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        SolidColorOverlay expectedSolidColorOverlay = new()
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
        SolidColorOverlayTransformation expectedSolidColorOverlayTransformation = new()
        {
            Alpha = 1,
            Background = "background",
            Gradient = new Default(),
            Height = 0,
            Radius = new Max(),
            Width = 0,
        };
        SrcOptions expectedSrcOptions = new()
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
            TransformationPosition = TransformationPosition.Path,
        };
        ApiEnum<string, StreamingResolution> expectedStreamingResolution = StreamingResolution.V240;
        SubtitleOverlay expectedSubtitleOverlay = new()
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
        SubtitleOverlayTransformation expectedSubtitleOverlayTransformation = new()
        {
            Background = "background",
            Color = "color",
            FontFamily = "fontFamily",
            FontOutline = "fontOutline",
            FontShadow = "fontShadow",
            FontSize = 0,
            Typography = Typography.B,
        };
        TextOverlay expectedTextOverlay = new()
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
        };
        TextOverlayTransformation expectedTextOverlayTransformation = new()
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
        };
        Transformation expectedTransformation = new()
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
        };
        ApiEnum<string, TransformationPosition> expectedTransformationPosition =
            TransformationPosition.Path;
        VideoOverlay expectedVideoOverlay = new()
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

        Assert.Equal(expectedBaseOverlay, parameters.BaseOverlay);
        Assert.Equal(expectedExtensionConfig, parameters.ExtensionConfig);
        Assert.NotNull(parameters.Extensions);
        Assert.Equal(expectedExtensions.Count, parameters.Extensions.Count);
        for (int i = 0; i < expectedExtensions.Count; i++)
        {
            Assert.Equal(expectedExtensions[i], parameters.Extensions[i]);
        }
        Assert.Equal(expectedGetImageAttributesOptions, parameters.GetImageAttributesOptions);
        Assert.Equal(expectedImageOverlay, parameters.ImageOverlay);
        Assert.Equal(expectedOverlay, parameters.Overlay);
        Assert.Equal(expectedOverlayPosition, parameters.OverlayPosition);
        Assert.Equal(expectedOverlayTiming, parameters.OverlayTiming);
        Assert.Equal(expectedResponsiveImageAttributes, parameters.ResponsiveImageAttributes);
        Assert.Equal(expectedSavedExtensions, parameters.SavedExtensions);
        Assert.Equal(expectedSolidColorOverlay, parameters.SolidColorOverlay);
        Assert.Equal(
            expectedSolidColorOverlayTransformation,
            parameters.SolidColorOverlayTransformation
        );
        Assert.Equal(expectedSrcOptions, parameters.SrcOptions);
        Assert.Equal(expectedStreamingResolution, parameters.StreamingResolution);
        Assert.Equal(expectedSubtitleOverlay, parameters.SubtitleOverlay);
        Assert.Equal(
            expectedSubtitleOverlayTransformation,
            parameters.SubtitleOverlayTransformation
        );
        Assert.Equal(expectedTextOverlay, parameters.TextOverlay);
        Assert.Equal(expectedTextOverlayTransformation, parameters.TextOverlayTransformation);
        Assert.Equal(expectedTransformation, parameters.Transformation);
        Assert.Equal(expectedTransformationPosition, parameters.TransformationPosition);
        Assert.Equal(expectedVideoOverlay, parameters.VideoOverlay);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DummyTestParams { };

        Assert.Null(parameters.BaseOverlay);
        Assert.False(parameters.RawBodyData.ContainsKey("baseOverlay"));
        Assert.Null(parameters.ExtensionConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("extensionConfig"));
        Assert.Null(parameters.Extensions);
        Assert.False(parameters.RawBodyData.ContainsKey("extensions"));
        Assert.Null(parameters.GetImageAttributesOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("getImageAttributesOptions"));
        Assert.Null(parameters.ImageOverlay);
        Assert.False(parameters.RawBodyData.ContainsKey("imageOverlay"));
        Assert.Null(parameters.Overlay);
        Assert.False(parameters.RawBodyData.ContainsKey("overlay"));
        Assert.Null(parameters.OverlayPosition);
        Assert.False(parameters.RawBodyData.ContainsKey("overlayPosition"));
        Assert.Null(parameters.OverlayTiming);
        Assert.False(parameters.RawBodyData.ContainsKey("overlayTiming"));
        Assert.Null(parameters.ResponsiveImageAttributes);
        Assert.False(parameters.RawBodyData.ContainsKey("responsiveImageAttributes"));
        Assert.Null(parameters.SavedExtensions);
        Assert.False(parameters.RawBodyData.ContainsKey("savedExtensions"));
        Assert.Null(parameters.SolidColorOverlay);
        Assert.False(parameters.RawBodyData.ContainsKey("solidColorOverlay"));
        Assert.Null(parameters.SolidColorOverlayTransformation);
        Assert.False(parameters.RawBodyData.ContainsKey("solidColorOverlayTransformation"));
        Assert.Null(parameters.SrcOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("srcOptions"));
        Assert.Null(parameters.StreamingResolution);
        Assert.False(parameters.RawBodyData.ContainsKey("streamingResolution"));
        Assert.Null(parameters.SubtitleOverlay);
        Assert.False(parameters.RawBodyData.ContainsKey("subtitleOverlay"));
        Assert.Null(parameters.SubtitleOverlayTransformation);
        Assert.False(parameters.RawBodyData.ContainsKey("subtitleOverlayTransformation"));
        Assert.Null(parameters.TextOverlay);
        Assert.False(parameters.RawBodyData.ContainsKey("textOverlay"));
        Assert.Null(parameters.TextOverlayTransformation);
        Assert.False(parameters.RawBodyData.ContainsKey("textOverlayTransformation"));
        Assert.Null(parameters.Transformation);
        Assert.False(parameters.RawBodyData.ContainsKey("transformation"));
        Assert.Null(parameters.TransformationPosition);
        Assert.False(parameters.RawBodyData.ContainsKey("transformationPosition"));
        Assert.Null(parameters.VideoOverlay);
        Assert.False(parameters.RawBodyData.ContainsKey("videoOverlay"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DummyTestParams
        {
            // Null should be interpreted as omitted for these properties
            BaseOverlay = null,
            ExtensionConfig = null,
            Extensions = null,
            GetImageAttributesOptions = null,
            ImageOverlay = null,
            Overlay = null,
            OverlayPosition = null,
            OverlayTiming = null,
            ResponsiveImageAttributes = null,
            SavedExtensions = null,
            SolidColorOverlay = null,
            SolidColorOverlayTransformation = null,
            SrcOptions = null,
            StreamingResolution = null,
            SubtitleOverlay = null,
            SubtitleOverlayTransformation = null,
            TextOverlay = null,
            TextOverlayTransformation = null,
            Transformation = null,
            TransformationPosition = null,
            VideoOverlay = null,
        };

        Assert.Null(parameters.BaseOverlay);
        Assert.False(parameters.RawBodyData.ContainsKey("baseOverlay"));
        Assert.Null(parameters.ExtensionConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("extensionConfig"));
        Assert.Null(parameters.Extensions);
        Assert.False(parameters.RawBodyData.ContainsKey("extensions"));
        Assert.Null(parameters.GetImageAttributesOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("getImageAttributesOptions"));
        Assert.Null(parameters.ImageOverlay);
        Assert.False(parameters.RawBodyData.ContainsKey("imageOverlay"));
        Assert.Null(parameters.Overlay);
        Assert.False(parameters.RawBodyData.ContainsKey("overlay"));
        Assert.Null(parameters.OverlayPosition);
        Assert.False(parameters.RawBodyData.ContainsKey("overlayPosition"));
        Assert.Null(parameters.OverlayTiming);
        Assert.False(parameters.RawBodyData.ContainsKey("overlayTiming"));
        Assert.Null(parameters.ResponsiveImageAttributes);
        Assert.False(parameters.RawBodyData.ContainsKey("responsiveImageAttributes"));
        Assert.Null(parameters.SavedExtensions);
        Assert.False(parameters.RawBodyData.ContainsKey("savedExtensions"));
        Assert.Null(parameters.SolidColorOverlay);
        Assert.False(parameters.RawBodyData.ContainsKey("solidColorOverlay"));
        Assert.Null(parameters.SolidColorOverlayTransformation);
        Assert.False(parameters.RawBodyData.ContainsKey("solidColorOverlayTransformation"));
        Assert.Null(parameters.SrcOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("srcOptions"));
        Assert.Null(parameters.StreamingResolution);
        Assert.False(parameters.RawBodyData.ContainsKey("streamingResolution"));
        Assert.Null(parameters.SubtitleOverlay);
        Assert.False(parameters.RawBodyData.ContainsKey("subtitleOverlay"));
        Assert.Null(parameters.SubtitleOverlayTransformation);
        Assert.False(parameters.RawBodyData.ContainsKey("subtitleOverlayTransformation"));
        Assert.Null(parameters.TextOverlay);
        Assert.False(parameters.RawBodyData.ContainsKey("textOverlay"));
        Assert.Null(parameters.TextOverlayTransformation);
        Assert.False(parameters.RawBodyData.ContainsKey("textOverlayTransformation"));
        Assert.Null(parameters.Transformation);
        Assert.False(parameters.RawBodyData.ContainsKey("transformation"));
        Assert.Null(parameters.TransformationPosition);
        Assert.False(parameters.RawBodyData.ContainsKey("transformationPosition"));
        Assert.Null(parameters.VideoOverlay);
        Assert.False(parameters.RawBodyData.ContainsKey("videoOverlay"));
    }

    [Fact]
    public void Url_Works()
    {
        DummyTestParams parameters = new();

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/dummy/test"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DummyTestParams
        {
            BaseOverlay = new()
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
            },
            ExtensionConfig = new RemovedotBgExtension()
            {
                Options = new()
                {
                    AddShadow = true,
                    BgColor = "bg_color",
                    BgImageUrl = "bg_image_url",
                    Semitransparency = true,
                },
            },
            Extensions =
            [
                new RemovedotBgExtension()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                new AutoTaggingExtension()
                {
                    MaxTags = 5,
                    MinConfidence = 95,
                    Name = Name.GoogleAutoTagging,
                },
                new AutoDescriptionExtension(),
                new AITasksExtension(
                    [
                        new SelectTags()
                        {
                            Instruction = "What types of clothing items are visible in this image?",
                            MaxSelections = 1,
                            MinSelections = 0,
                            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                        },
                        new YesNo()
                        {
                            Instruction = "Is this a luxury or high-end fashion item?",
                            OnNo = new()
                            {
                                AddTags = ["luxury", "premium"],
                                RemoveTags = ["budget", "affordable"],
                                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                                UnsetMetadata = [new("price_range")],
                            },
                            OnUnknown = new()
                            {
                                AddTags = ["luxury", "premium"],
                                RemoveTags = ["budget", "affordable"],
                                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                                UnsetMetadata = [new("price_range")],
                            },
                            OnYes = new()
                            {
                                AddTags = ["luxury", "premium"],
                                RemoveTags = ["budget", "affordable"],
                                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                                UnsetMetadata = [new("price_range")],
                            },
                        },
                    ]
                ),
                new SavedExtension("ext_abc123"),
            ],
            GetImageAttributesOptions = new()
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
                TransformationPosition = TransformationPosition.Path,
                DeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840],
                ImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384],
                Sizes = "(min-width: 768px) 50vw, 100vw",
                Width = 400,
            },
            ImageOverlay = new()
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
            },
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
            OverlayPosition = new()
            {
                AnchorPoint = AnchorPoint.Top,
                Focus = Focus.Center,
                X = 0,
                XCenter = 0,
                Y = 0,
                YCenter = 0,
            },
            OverlayTiming = new()
            {
                Duration = 0,
                End = 0,
                Start = 0,
            },
            ResponsiveImageAttributes = new()
            {
                Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",
                Sizes = "100vw",
                SrcSet =
                    "https://ik.imagekit.io/demo/image.jpg?tr=w-640 640w, https://ik.imagekit.io/demo/image.jpg?tr=w-1080 1080w, https://ik.imagekit.io/demo/image.jpg?tr=w-1920 1920w",
                Width = 400,
            },
            SavedExtensions = new()
            {
                ID = "ext_abc123",
                Config = new RemovedotBgExtension()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "Analyzes vehicle images for type, condition, and quality assessment",
                Name = "Car Quality Analysis",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            SolidColorOverlay = new()
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
            },
            SolidColorOverlayTransformation = new()
            {
                Alpha = 1,
                Background = "background",
                Gradient = new Default(),
                Height = 0,
                Radius = new Max(),
                Width = 0,
            },
            SrcOptions = new()
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
                TransformationPosition = TransformationPosition.Path,
            },
            StreamingResolution = StreamingResolution.V240,
            SubtitleOverlay = new()
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
                        Background = "background",
                        Color = "color",
                        FontFamily = "fontFamily",
                        FontOutline = "fontOutline",
                        FontShadow = "fontShadow",
                        FontSize = 0,
                        Typography = Typography.B,
                    },
                ],
            },
            SubtitleOverlayTransformation = new()
            {
                Background = "background",
                Color = "color",
                FontFamily = "fontFamily",
                FontOutline = "fontOutline",
                FontShadow = "fontShadow",
                FontSize = 0,
                Typography = Typography.B,
            },
            TextOverlay = new()
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
            TextOverlayTransformation = new()
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
            Transformation = new()
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
            TransformationPosition = TransformationPosition.Path,
            VideoOverlay = new()
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
            },
        };

        DummyTestParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

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

public class GetImageAttributesOptionsGetImageAttributesOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GetImageAttributesOptionsGetImageAttributesOptions
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
        var model = new GetImageAttributesOptionsGetImageAttributesOptions
        {
            DeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840],
            ImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384],
            Sizes = "(min-width: 768px) 50vw, 100vw",
            Width = 400,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<GetImageAttributesOptionsGetImageAttributesOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GetImageAttributesOptionsGetImageAttributesOptions
        {
            DeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840],
            ImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384],
            Sizes = "(min-width: 768px) 50vw, 100vw",
            Width = 400,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<GetImageAttributesOptionsGetImageAttributesOptions>(
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
        var model = new GetImageAttributesOptionsGetImageAttributesOptions
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
        var model = new GetImageAttributesOptionsGetImageAttributesOptions { };

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
        var model = new GetImageAttributesOptionsGetImageAttributesOptions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GetImageAttributesOptionsGetImageAttributesOptions
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
        var model = new GetImageAttributesOptionsGetImageAttributesOptions
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
        var model = new GetImageAttributesOptionsGetImageAttributesOptions
        {
            DeviceBreakpoints = [640, 750, 828, 1080, 1200, 1920, 2048, 3840],
            ImageBreakpoints = [16, 32, 48, 64, 96, 128, 256, 384],
            Sizes = "(min-width: 768px) 50vw, 100vw",
            Width = 400,
        };

        GetImageAttributesOptionsGetImageAttributesOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResponsiveImageAttributesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ResponsiveImageAttributes
        {
            Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",
            Sizes = "100vw",
            SrcSet =
                "https://ik.imagekit.io/demo/image.jpg?tr=w-640 640w, https://ik.imagekit.io/demo/image.jpg?tr=w-1080 1080w, https://ik.imagekit.io/demo/image.jpg?tr=w-1920 1920w",
            Width = 400,
        };

        string expectedSrc = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840";
        string expectedSizes = "100vw";
        string expectedSrcSet =
            "https://ik.imagekit.io/demo/image.jpg?tr=w-640 640w, https://ik.imagekit.io/demo/image.jpg?tr=w-1080 1080w, https://ik.imagekit.io/demo/image.jpg?tr=w-1920 1920w";
        double expectedWidth = 400;

        Assert.Equal(expectedSrc, model.Src);
        Assert.Equal(expectedSizes, model.Sizes);
        Assert.Equal(expectedSrcSet, model.SrcSet);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ResponsiveImageAttributes
        {
            Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",
            Sizes = "100vw",
            SrcSet =
                "https://ik.imagekit.io/demo/image.jpg?tr=w-640 640w, https://ik.imagekit.io/demo/image.jpg?tr=w-1080 1080w, https://ik.imagekit.io/demo/image.jpg?tr=w-1920 1920w",
            Width = 400,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResponsiveImageAttributes>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ResponsiveImageAttributes
        {
            Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",
            Sizes = "100vw",
            SrcSet =
                "https://ik.imagekit.io/demo/image.jpg?tr=w-640 640w, https://ik.imagekit.io/demo/image.jpg?tr=w-1080 1080w, https://ik.imagekit.io/demo/image.jpg?tr=w-1920 1920w",
            Width = 400,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResponsiveImageAttributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSrc = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840";
        string expectedSizes = "100vw";
        string expectedSrcSet =
            "https://ik.imagekit.io/demo/image.jpg?tr=w-640 640w, https://ik.imagekit.io/demo/image.jpg?tr=w-1080 1080w, https://ik.imagekit.io/demo/image.jpg?tr=w-1920 1920w";
        double expectedWidth = 400;

        Assert.Equal(expectedSrc, deserialized.Src);
        Assert.Equal(expectedSizes, deserialized.Sizes);
        Assert.Equal(expectedSrcSet, deserialized.SrcSet);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ResponsiveImageAttributes
        {
            Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",
            Sizes = "100vw",
            SrcSet =
                "https://ik.imagekit.io/demo/image.jpg?tr=w-640 640w, https://ik.imagekit.io/demo/image.jpg?tr=w-1080 1080w, https://ik.imagekit.io/demo/image.jpg?tr=w-1920 1920w",
            Width = 400,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ResponsiveImageAttributes
        {
            Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",
        };

        Assert.Null(model.Sizes);
        Assert.False(model.RawData.ContainsKey("sizes"));
        Assert.Null(model.SrcSet);
        Assert.False(model.RawData.ContainsKey("srcSet"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ResponsiveImageAttributes
        {
            Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ResponsiveImageAttributes
        {
            Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",

            // Null should be interpreted as omitted for these properties
            Sizes = null,
            SrcSet = null,
            Width = null,
        };

        Assert.Null(model.Sizes);
        Assert.False(model.RawData.ContainsKey("sizes"));
        Assert.Null(model.SrcSet);
        Assert.False(model.RawData.ContainsKey("srcSet"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ResponsiveImageAttributes
        {
            Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",

            // Null should be interpreted as omitted for these properties
            Sizes = null,
            SrcSet = null,
            Width = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ResponsiveImageAttributes
        {
            Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",
            Sizes = "100vw",
            SrcSet =
                "https://ik.imagekit.io/demo/image.jpg?tr=w-640 640w, https://ik.imagekit.io/demo/image.jpg?tr=w-1080 1080w, https://ik.imagekit.io/demo/image.jpg?tr=w-1920 1920w",
            Width = 400,
        };

        ResponsiveImageAttributes copied = new(model);

        Assert.Equal(model, copied);
    }
}

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
        var model = new SolidColorOverlay
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
        var deserialized = JsonSerializer.Deserialize<SolidColorOverlay>(
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
        var model = new SolidColorOverlay
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

        SolidColorOverlay copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SolidColorOverlaySolidColorOverlayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SolidColorOverlaySolidColorOverlay
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
        var model = new SolidColorOverlaySolidColorOverlay
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
        var deserialized = JsonSerializer.Deserialize<SolidColorOverlaySolidColorOverlay>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SolidColorOverlaySolidColorOverlay
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
        var deserialized = JsonSerializer.Deserialize<SolidColorOverlaySolidColorOverlay>(
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
        var model = new SolidColorOverlaySolidColorOverlay
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
        var model = new SolidColorOverlaySolidColorOverlay { Color = "color" };

        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SolidColorOverlaySolidColorOverlay { Color = "color" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SolidColorOverlaySolidColorOverlay
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
        var model = new SolidColorOverlaySolidColorOverlay
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
        var model = new SolidColorOverlaySolidColorOverlay
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

        SolidColorOverlaySolidColorOverlay copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StreamingResolutionTest : TestBase
{
    [Theory]
    [InlineData(StreamingResolution.V240)]
    [InlineData(StreamingResolution.V360)]
    [InlineData(StreamingResolution.V480)]
    [InlineData(StreamingResolution.V720)]
    [InlineData(StreamingResolution.V1080)]
    [InlineData(StreamingResolution.V1440)]
    [InlineData(StreamingResolution.V2160)]
    public void Validation_Works(StreamingResolution rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StreamingResolution> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StreamingResolution>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StreamingResolution.V240)]
    [InlineData(StreamingResolution.V360)]
    [InlineData(StreamingResolution.V480)]
    [InlineData(StreamingResolution.V720)]
    [InlineData(StreamingResolution.V1080)]
    [InlineData(StreamingResolution.V1440)]
    [InlineData(StreamingResolution.V2160)]
    public void SerializationRoundtrip_Works(StreamingResolution rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StreamingResolution> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StreamingResolution>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StreamingResolution>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StreamingResolution>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

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
            Encoding = Encoding.Auto,
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
        ApiEnum<string, Encoding> expectedEncoding = Encoding.Auto;
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
            Encoding = Encoding.Auto,
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
            Encoding = Encoding.Auto,
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
        ApiEnum<string, Encoding> expectedEncoding = Encoding.Auto;
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
            Encoding = Encoding.Auto,
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
            Encoding = Encoding.Auto,
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
            Encoding = Encoding.Auto,
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
        ApiEnum<string, Encoding> expectedEncoding = Encoding.Auto;
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
            Encoding = Encoding.Auto,
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
            Encoding = Encoding.Auto,
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
        ApiEnum<string, Encoding> expectedEncoding = Encoding.Auto;
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
            Encoding = Encoding.Auto,
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
            Encoding = Encoding.Auto,
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
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
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
        ApiEnum<string, TextOverlayTextOverlayEncoding> expectedEncoding =
            TextOverlayTextOverlayEncoding.Auto;
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
        ApiEnum<string, TextOverlayTextOverlayEncoding> expectedEncoding =
            TextOverlayTextOverlayEncoding.Auto;
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
        };

        TextOverlay copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TextOverlayTextOverlayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TextOverlayTextOverlay
        {
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
        };

        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");
        ApiEnum<string, TextOverlayTextOverlayEncoding> expectedEncoding =
            TextOverlayTextOverlayEncoding.Auto;
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
        var model = new TextOverlayTextOverlay
        {
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextOverlayTextOverlay>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TextOverlayTextOverlay
        {
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextOverlayTextOverlay>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");
        ApiEnum<string, TextOverlayTextOverlayEncoding> expectedEncoding =
            TextOverlayTextOverlayEncoding.Auto;
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
        var model = new TextOverlayTextOverlay
        {
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TextOverlayTextOverlay { Text = "text" };

        Assert.Null(model.Encoding);
        Assert.False(model.RawData.ContainsKey("encoding"));
        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TextOverlayTextOverlay { Text = "text" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TextOverlayTextOverlay
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
        var model = new TextOverlayTextOverlay
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
        var model = new TextOverlayTextOverlay
        {
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
        };

        TextOverlayTextOverlay copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TextOverlayTextOverlayEncodingTest : TestBase
{
    [Theory]
    [InlineData(TextOverlayTextOverlayEncoding.Auto)]
    [InlineData(TextOverlayTextOverlayEncoding.Plain)]
    [InlineData(TextOverlayTextOverlayEncoding.Base64)]
    public void Validation_Works(TextOverlayTextOverlayEncoding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextOverlayTextOverlayEncoding> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TextOverlayTextOverlayEncoding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TextOverlayTextOverlayEncoding.Auto)]
    [InlineData(TextOverlayTextOverlayEncoding.Plain)]
    [InlineData(TextOverlayTextOverlayEncoding.Base64)]
    public void SerializationRoundtrip_Works(TextOverlayTextOverlayEncoding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextOverlayTextOverlayEncoding> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TextOverlayTextOverlayEncoding>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TextOverlayTextOverlayEncoding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TextOverlayTextOverlayEncoding>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
