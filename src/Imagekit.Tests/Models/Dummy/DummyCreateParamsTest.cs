using System;
using System.Collections.Generic;
using Imagekit.Core;
using Imagekit.Models;
using Imagekit.Models.Dummy;

namespace Imagekit.Tests.Models.Dummy;

public class DummyCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DummyCreateParams
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
            ExtensionConfig = new RemoveBg()
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
                new ExtensionItemRemoveBg()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                new ExtensionItemAutoTaggingExtension()
                {
                    MaxTags = 5,
                    MinConfidence = 95,
                    Name = ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging,
                },
                new ExtensionItemAIAutoDescription(),
                new ExtensionItemAITasks(
                    [
                        new ExtensionItemAITasksTaskSelectTags()
                        {
                            Instruction = "What types of clothing items are visible in this image?",
                            MaxSelections = 1,
                            MinSelections = 0,
                            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                        },
                        new ExtensionItemAITasksTaskYesNo()
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
                    },
                ],
            },
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
                Config = new RemoveBg()
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
                        Gradient = new UnionMember0(),
                        Height = 0,
                        Radius = new UnionMember1(),
                        Width = 0,
                    },
                ],
            },
            SolidColorOverlayTransformation = new()
            {
                Alpha = 1,
                Background = "background",
                Gradient = new UnionMember0(),
                Height = 0,
                Radius = new UnionMember1(),
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
                        Radius = new TextOverlayTransformationRadiusUnionMember1(),
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
                Radius = new TextOverlayTransformationRadiusUnionMember1(),
                Rotation = 0,
                Typography = "typography",
                Width = 0,
            },
            Transformation = new()
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
        ExtensionConfig expectedExtensionConfig = new RemoveBg()
        {
            Options = new()
            {
                AddShadow = true,
                BgColor = "bg_color",
                BgImageUrl = "bg_image_url",
                Semitransparency = true,
            },
        };
        List<ExtensionItem> expectedExtensions =
        [
            new ExtensionItemRemoveBg()
            {
                Options = new()
                {
                    AddShadow = true,
                    BgColor = "bg_color",
                    BgImageUrl = "bg_image_url",
                    Semitransparency = true,
                },
            },
            new ExtensionItemAutoTaggingExtension()
            {
                MaxTags = 5,
                MinConfidence = 95,
                Name = ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging,
            },
            new ExtensionItemAIAutoDescription(),
            new ExtensionItemAITasks(
                [
                    new ExtensionItemAITasksTaskSelectTags()
                    {
                        Instruction = "What types of clothing items are visible in this image?",
                        MaxSelections = 1,
                        MinSelections = 0,
                        Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                    },
                    new ExtensionItemAITasksTaskYesNo()
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
                },
            ],
        };
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
        SharedSavedExtension expectedSavedExtensions = new()
        {
            ID = "ext_abc123",
            Config = new RemoveBg()
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
                    Gradient = new UnionMember0(),
                    Height = 0,
                    Radius = new UnionMember1(),
                    Width = 0,
                },
            ],
        };
        SolidColorOverlayTransformation expectedSolidColorOverlayTransformation = new()
        {
            Alpha = 1,
            Background = "background",
            Gradient = new UnionMember0(),
            Height = 0,
            Radius = new UnionMember1(),
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
                    Radius = new TextOverlayTransformationRadiusUnionMember1(),
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
            Radius = new TextOverlayTransformationRadiusUnionMember1(),
            Rotation = 0,
            Typography = "typography",
            Width = 0,
        };
        Transformation expectedTransformation = new()
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
        var parameters = new DummyCreateParams { };

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
        var parameters = new DummyCreateParams
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
        DummyCreateParams parameters = new();

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/dummy/test"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DummyCreateParams
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
            ExtensionConfig = new RemoveBg()
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
                new ExtensionItemRemoveBg()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                new ExtensionItemAutoTaggingExtension()
                {
                    MaxTags = 5,
                    MinConfidence = 95,
                    Name = ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging,
                },
                new ExtensionItemAIAutoDescription(),
                new ExtensionItemAITasks(
                    [
                        new ExtensionItemAITasksTaskSelectTags()
                        {
                            Instruction = "What types of clothing items are visible in this image?",
                            MaxSelections = 1,
                            MinSelections = 0,
                            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                        },
                        new ExtensionItemAITasksTaskYesNo()
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
                    },
                ],
            },
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
                Config = new RemoveBg()
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
                        Gradient = new UnionMember0(),
                        Height = 0,
                        Radius = new UnionMember1(),
                        Width = 0,
                    },
                ],
            },
            SolidColorOverlayTransformation = new()
            {
                Alpha = 1,
                Background = "background",
                Gradient = new UnionMember0(),
                Height = 0,
                Radius = new UnionMember1(),
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
                        Radius = new TextOverlayTransformationRadiusUnionMember1(),
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
                Radius = new TextOverlayTransformationRadiusUnionMember1(),
                Rotation = 0,
                Typography = "typography",
                Width = 0,
            },
            Transformation = new()
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
                    },
                ],
            },
        };

        DummyCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
