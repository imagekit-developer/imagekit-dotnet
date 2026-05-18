// Go source: tests/helper_overlay_test.go
// Total test cases in Go: 31 (TestOverlayTransformations: 12, TestOverlayEncoding: 19)

using Imagekit;
using Imagekit.Models;

namespace Imagekit.Tests.Helper;

public class HelperOverlayTest
{
    private static readonly ImageKitClient _client = new() { PrivateKey = "My Private API Key" };

    // --- TestOverlayTransformations ---

    [Fact]
    public void NoOverlay_JustWidth_PathPosition_GeneratesUrlWithTr()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/base-image.jpg",
            Transformation = [new Transformation { Width = 300.0 }],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/tr:w-300/base-image.jpg", url);
    }

    [Fact]
    public void TextOverlay_EmptyText_IgnoresOverlay()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/base-image.jpg",
            Transformation = [new Transformation { Overlay = new TextOverlay { Text = "" } }],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/base-image.jpg", url);
    }

    [Fact]
    public void ImageOverlay_EmptyInput_IgnoresOverlay()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/base-image.jpg",
            Transformation = [new Transformation { Overlay = new ImageOverlay { Input = "" } }],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/base-image.jpg", url);
    }

    [Fact]
    public void VideoOverlay_EmptyInput_IgnoresOverlay()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/base-image.jpg",
            Transformation = [new Transformation { Overlay = new VideoOverlay { Input = "" } }],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/base-image.jpg", url);
    }

    [Fact]
    public void SubtitleOverlay_EmptyInput_IgnoresOverlay()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/base-image.jpg",
            Transformation = [new Transformation { Overlay = new SubtitleOverlay { Input = "" } }],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/base-image.jpg", url);
    }

    [Fact]
    public void SolidColorOverlay_EmptyColor_IgnoresOverlay()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/base-image.jpg",
            Transformation = [new Transformation { Overlay = new SolidColorOverlay { Color = "" } }],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/base-image.jpg", url);
    }

    [Fact]
    public void TextOverlay_MinimalText_GeneratesUrlEncodedLayer()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/base-image.jpg",
            Transformation = [new Transformation { Overlay = new TextOverlay("Minimal Text") }],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/tr:l-text,i-Minimal%20Text,l-end/base-image.jpg",
            url
        );
    }

    [Fact]
    public void ImageOverlay_LogoPng_GeneratesLayer()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/base-image.jpg",
            Transformation = [new Transformation { Overlay = new ImageOverlay("logo.png") }],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/tr:l-image,i-logo.png,l-end/base-image.jpg",
            url
        );
    }

    [Fact]
    public void VideoOverlay_PlayPauseLoop_GeneratesLayer()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/base-video.mp4",
            Transformation = [new Transformation { Overlay = new VideoOverlay("play-pause-loop.mp4") }],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/tr:l-video,i-play-pause-loop.mp4,l-end/base-video.mp4",
            url
        );
    }

    [Fact]
    public void SubtitleOverlay_SubtitleSrt_GeneratesLayer()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/base-video.mp4",
            Transformation = [new Transformation { Overlay = new SubtitleOverlay("subtitle.srt") }],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/tr:l-subtitles,i-subtitle.srt,l-end/base-video.mp4",
            url
        );
    }

    [Fact]
    public void SolidColorOverlay_FF0000_GeneratesCanvasLayer()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/base-image.jpg",
            Transformation = [new Transformation { Overlay = new SolidColorOverlay("FF0000") }],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/tr:l-image,i-ik_canvas,bg-FF0000,l-end/base-image.jpg",
            url
        );
    }

    [Fact]
    public void MultipleComplexOverlaysWithNestedTransformations_GeneratesCorrectUrl()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/base-image.jpg",
            Transformation =
            [
                new Transformation
                {
                    Overlay = new TextOverlay("Every thing")
                    {
                        Position = new OverlayPosition { X = "10", Y = "20", Focus = Focus.Center },
                        Timing = new OverlayTiming { Start = 5.0, Duration = "10", End = 15.0 },
                        Transformation =
                        [
                            new TextOverlayTransformation
                            {
                                Width = "bw_mul_0.5",
                                FontSize = 20.0,
                                FontFamily = "Arial",
                                FontColor = "0000ff",
                                InnerAlignment = InnerAlignment.Left,
                                Padding = 5.0,
                                Alpha = 7.0,
                                Typography = "b",
                                Background = "red",
                                Radius = 10.0,
                                Rotation = "N45",
                                Flip = Flip.H,
                                LineHeight = 20.0,
                            },
                        ],
                    },
                },
                new Transformation
                {
                    Overlay = new ImageOverlay("logo.png")
                    {
                        Position = new OverlayPosition { X = "10", Y = "20", Focus = Focus.Center },
                        Timing = new OverlayTiming { Start = 5.0, Duration = "10", End = 15.0 },
                        Transformation =
                        [
                            new Transformation
                            {
                                Width = "bw_mul_0.5",
                                Height = "bh_mul_0.5",
                                Rotation = "N45",
                                Flip = TransformationFlip.H,
                                Overlay = new TextOverlay("Nested text overlay"),
                            },
                        ],
                    },
                },
                new Transformation
                {
                    Overlay = new VideoOverlay("play-pause-loop.mp4")
                    {
                        Position = new OverlayPosition { X = "10", Y = "20", Focus = Focus.Center },
                        Timing = new OverlayTiming { Start = 5.0, Duration = "10", End = 15.0 },
                        Transformation =
                        [
                            new Transformation
                            {
                                Width = "bw_mul_0.5",
                                Height = "bh_mul_0.5",
                                Rotation = "N45",
                                Flip = TransformationFlip.H,
                            },
                        ],
                    },
                },
                new Transformation
                {
                    Overlay = new SubtitleOverlay("subtitle.srt")
                    {
                        Position = new OverlayPosition { X = "10", Y = "20", Focus = Focus.Center },
                        Timing = new OverlayTiming { Start = 5.0, Duration = "10", End = 15.0 },
                        Transformation =
                        [
                            new SubtitleOverlayTransformation
                            {
                                Background = "red",
                                Color = "0000ff",
                                FontFamily = "Arial",
                                FontOutline = "2_A1CCDD50",
                                FontShadow = "A1CCDD_3",
                            },
                        ],
                    },
                },
                new Transformation
                {
                    Overlay = new SolidColorOverlay("FF0000")
                    {
                        Position = new OverlayPosition { X = "10", Y = "20", Focus = Focus.Center },
                        Timing = new OverlayTiming { Start = 5.0, Duration = "10", End = 15.0 },
                        Transformation =
                        [
                            new SolidColorOverlayTransformation
                            {
                                Width = "bw_mul_0.5",
                                Height = "bh_mul_0.5",
                                Alpha = 0.5,
                                Background = "red",
                                Gradient = new Default(),
                                Radius = new Max(),
                            },
                        ],
                    },
                },
            ],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/tr:l-text,i-Every%20thing,lx-10,ly-20,lfo-center,lso-5,leo-15,ldu-10,w-bw_mul_0.5,fs-20,ff-Arial,co-0000ff,ia-left,pa-5,al-7,tg-b,bg-red,r-10,rt-N45,fl-h,lh-20,l-end:l-image,i-logo.png,lx-10,ly-20,lfo-center,lso-5,leo-15,ldu-10,w-bw_mul_0.5,h-bh_mul_0.5,rt-N45,fl-h,l-text,i-Nested%20text%20overlay,l-end,l-end:l-video,i-play-pause-loop.mp4,lx-10,ly-20,lfo-center,lso-5,leo-15,ldu-10,w-bw_mul_0.5,h-bh_mul_0.5,rt-N45,fl-h,l-end:l-subtitles,i-subtitle.srt,lx-10,ly-20,lfo-center,lso-5,leo-15,ldu-10,bg-red,co-0000ff,ff-Arial,fol-2_A1CCDD50,fsh-A1CCDD_3,l-end:l-image,i-ik_canvas,bg-FF0000,lx-10,ly-20,lfo-center,lso-5,leo-15,ldu-10,w-bw_mul_0.5,h-bh_mul_0.5,al-0.5,bg-red,e-gradient,r-max,l-end/base-image.jpg",
            url
        );
    }

    // --- TestOverlayEncoding ---

    [Fact]
    public void ImageOverlay_SlashesInPath_ConvertedToDoubleAt()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/demo",
            Src = "/medium_cafe_B1iTdD0C.jpg",
            Transformation = [new Transformation { Overlay = new ImageOverlay("/customer_logo/nykaa.png") }],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/demo/tr:l-image,i-customer_logo@@nykaa.png,l-end/medium_cafe_B1iTdD0C.jpg",
            url
        );
    }

    [Fact]
    public void ImageOverlay_SpecialCharsInPath_UsesBase64Encoding()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/demo",
            Src = "/medium_cafe_B1iTdD0C.jpg",
            Transformation = [new Transformation { Overlay = new ImageOverlay("/customer_logo/Ñykaa.png") }],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/demo/tr:l-image,ie-Y3VzdG9tZXJfbG9nby%2FDkXlrYWEucG5n,l-end/medium_cafe_B1iTdD0C.jpg",
            url
        );
    }

    [Fact]
    public void TextOverlay_SimpleAscii_UsesPlainEncoding()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/demo",
            Src = "/medium_cafe_B1iTdD0C.jpg",
            Transformation = [new Transformation { Overlay = new TextOverlay("Manu") }],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/demo/tr:l-text,i-Manu,l-end/medium_cafe_B1iTdD0C.jpg",
            url
        );
    }

    [Fact]
    public void TextOverlay_FontFamilyWithSlash_ConvertedToDoubleAt()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/demo",
            Src = "/medium_cafe_B1iTdD0C.jpg",
            Transformation =
            [
                new Transformation
                {
                    Overlay = new TextOverlay("Manu")
                    {
                        Transformation =
                        [
                            new TextOverlayTransformation
                            {
                                FontFamily = "nested-path/Poppins-Regular_Q15GrYWmL.ttf",
                            },
                        ],
                    },
                },
            ],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/demo/tr:l-text,i-Manu,ff-nested-path@@Poppins-Regular_Q15GrYWmL.ttf,l-end/medium_cafe_B1iTdD0C.jpg",
            url
        );
    }

    [Fact]
    public void TextOverlay_SpacesAndSafeChars_UrlEncoded()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/demo",
            Src = "/medium_cafe_B1iTdD0C.jpg",
            Transformation = [new Transformation { Overlay = new TextOverlay("alnum123-._ ") }],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/demo/tr:l-text,i-alnum123-._%20,l-end/medium_cafe_B1iTdD0C.jpg",
            url
        );
    }

    [Fact]
    public void TextOverlay_UnicodeSpecialChars_UsesBase64()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/demo",
            Src = "/medium_cafe_B1iTdD0C.jpg",
            Transformation = [new Transformation { Overlay = new TextOverlay("Let's use ©, ®, ™, etc") }],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/demo/tr:l-text,ie-TGV0J3MgdXNlIMKpLCDCriwg4oSiLCBldGM%3D,l-end/medium_cafe_B1iTdD0C.jpg",
            url
        );
    }

    [Fact]
    public void TextOverlay_ExplicitPlainEncoding_UsesPlain()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/demo",
            Src = "/sample.jpg",
            Transformation =
            [
                new Transformation
                {
                    Overlay = new TextOverlay("HelloWorld") { Encoding = "plain" },
                },
            ],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/demo/tr:l-text,i-HelloWorld,l-end/sample.jpg",
            url
        );
    }

    [Fact]
    public void TextOverlay_ExplicitBase64Encoding_UsesBase64()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/demo",
            Src = "/sample.jpg",
            Transformation =
            [
                new Transformation
                {
                    Overlay = new TextOverlay("HelloWorld") { Encoding = "base64" },
                },
            ],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/demo/tr:l-text,ie-SGVsbG9Xb3JsZA%3D%3D,l-end/sample.jpg",
            url
        );
    }

    [Fact]
    public void ImageOverlay_ExplicitPlainEncoding_NormalizesSlashes()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/demo",
            Src = "/sample.jpg",
            Transformation =
            [
                new Transformation
                {
                    Overlay = new ImageOverlay("/customer/logo.png") { Encoding = "plain" },
                },
            ],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/demo/tr:l-image,i-customer@@logo.png,l-end/sample.jpg",
            url
        );
    }

    [Fact]
    public void ImageOverlay_ExplicitBase64Encoding_UsesBase64()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/demo",
            Src = "/sample.jpg",
            Transformation =
            [
                new Transformation
                {
                    Overlay = new ImageOverlay("/customer/logo.png") { Encoding = "base64" },
                },
            ],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/demo/tr:l-image,ie-Y3VzdG9tZXIvbG9nby5wbmc%3D,l-end/sample.jpg",
            url
        );
    }

    [Fact]
    public void VideoOverlay_ExplicitBase64Encoding_UsesBase64()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/demo",
            Src = "/sample.mp4",
            Transformation =
            [
                new Transformation
                {
                    Overlay = new VideoOverlay("/path/to/video.mp4") { Encoding = "base64" },
                },
            ],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/demo/tr:l-video,ie-cGF0aC90by92aWRlby5tcDQ%3D,l-end/sample.mp4",
            url
        );
    }

    [Fact]
    public void SubtitleOverlay_ExplicitPlainEncoding_NormalizesSlashes()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/demo",
            Src = "/sample.mp4",
            Transformation =
            [
                new Transformation
                {
                    Overlay = new SubtitleOverlay("/sub.srt") { Encoding = "plain" },
                },
            ],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/demo/tr:l-subtitles,i-sub.srt,l-end/sample.mp4",
            url
        );
    }

    [Fact]
    public void SubtitleOverlay_ExplicitBase64Encoding_UsesBase64()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/demo",
            Src = "/sample.mp4",
            Transformation =
            [
                new Transformation
                {
                    Overlay = new SubtitleOverlay("sub.srt") { Encoding = "base64" },
                },
            ],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/demo/tr:l-subtitles,ie-c3ViLnNydA%3D%3D,l-end/sample.mp4",
            url
        );
    }

    [Fact]
    public void TextOverlay_QueryPosition_EncodesInQueryParam()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/demo",
            Src = "/sample.jpg",
            Transformation = [new Transformation { Overlay = new TextOverlay("Minimal Text") }],
            TransformationPosition = TransformationPosition.Query,
        });

        Assert.Equal(
            "https://ik.imagekit.io/demo/sample.jpg?tr=l-text,i-Minimal%20Text,l-end",
            url
        );
    }

    [Fact]
    public void ImageOverlay_LayerModeMultiply_GeneratesLmMultiply()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/base-image.jpg",
            Transformation =
            [
                new Transformation
                {
                    Overlay = new ImageOverlay("logo.png") { LayerMode = LayerMode.Multiply },
                },
            ],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/tr:l-image,i-logo.png,lm-multiply,l-end/base-image.jpg",
            url
        );
    }

    [Fact]
    public void ImageOverlay_LayerModeCutter_GeneratesLmCutter()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/base-image.jpg",
            Transformation =
            [
                new Transformation
                {
                    Overlay = new ImageOverlay("mask.png") { LayerMode = LayerMode.Cutter },
                },
            ],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/tr:l-image,i-mask.png,lm-cutter,l-end/base-image.jpg",
            url
        );
    }

    [Fact]
    public void ImageOverlay_LayerModeCutout_GeneratesLmCutout()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/base-image.jpg",
            Transformation =
            [
                new Transformation
                {
                    Overlay = new ImageOverlay("shape.png") { LayerMode = LayerMode.Cutout },
                },
            ],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/tr:l-image,i-shape.png,lm-cutout,l-end/base-image.jpg",
            url
        );
    }

    [Fact]
    public void ImageOverlay_LayerModeDisplace_GeneratesLmDisplace()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/base-image.jpg",
            Transformation =
            [
                new Transformation
                {
                    Overlay = new ImageOverlay("displacement.png") { LayerMode = LayerMode.Displace },
                },
            ],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/tr:l-image,i-displacement.png,lm-displace,l-end/base-image.jpg",
            url
        );
    }

    [Fact]
    public void ImageOverlay_XCenterYCenterAnchorPoint_GeneratesCorrectPositionParams()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/base-image.jpg",
            Transformation =
            [
                new Transformation
                {
                    Overlay = new ImageOverlay("logo.png")
                    {
                        Position = new OverlayPosition
                        {
                            XCenter = 50.0,
                            YCenter = "bh_mul_0.5",
                            AnchorPoint = AnchorPoint.TopLeft,
                        },
                    },
                },
            ],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/tr:l-image,i-logo.png,lxc-50,lyc-bh_mul_0.5,lap-top_left,l-end/base-image.jpg",
            url
        );
    }
}

