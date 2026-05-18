// Go source: tests/helper_advanced_transformations_test.go
// Total test cases in Go: 20 (TestAITransformations: 10, TestParameterSpecificTransformations: 10)

using System.Collections.Generic;
using Imagekit;
using Imagekit.Models;

namespace Imagekit.Tests.Helper;

public class HelperAdvancedTransformationsTest
{
    private static readonly ImageKitClient _client = new() { PrivateKey = "My Private API Key" };

    // --- TestAITransformations ---

    [Fact]
    public void AIRemoveBackground_True_GeneratesEBgremove()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path1.jpg",
                Transformation = [new Transformation { AIRemoveBackground = true }],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path1.jpg?tr=e-bgremove", url);
    }

    [Fact]
    public void AIRemoveBackgroundExternal_True_GeneratesERemovedotbg()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path1.jpg",
                Transformation = [new Transformation { AIRemoveBackgroundExternal = true }],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/test_path1.jpg?tr=e-removedotbg",
            url
        );
    }

    [Fact]
    public void AIDropShadow_True_GeneratesEDropshadow()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path1.jpg",
                Transformation = [new Transformation { AIDropShadow = new AIDropShadowDefault() }],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/test_path1.jpg?tr=e-dropshadow",
            url
        );
    }

    [Fact]
    public void Gradient_True_GeneratesEGradient()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path1.jpg",
                Transformation =
                [
                    new Transformation { Gradient = new TransformationGradientDefault() },
                ],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path1.jpg?tr=e-gradient", url);
    }

    [Fact]
    public void AIRemoveBackground_NotSet_OmitsTrParam()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path1.jpg",
                Transformation = [new Transformation()],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path1.jpg", url);
    }

    [Fact]
    public void AIRemoveBackgroundExternal_NotSet_OmitsTrParam()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path1.jpg",
                Transformation = [new Transformation()],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path1.jpg", url);
    }

    [Fact]
    public void AIDropShadow_WithCustomParams_GeneratesEDropshadowWithParams()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path1.jpg",
                Transformation = [new Transformation { AIDropShadow = "custom-shadow-params" }],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/test_path1.jpg?tr=e-dropshadow-custom-shadow-params",
            url
        );
    }

    [Fact]
    public void Gradient_WithParams_GeneratesEGradientWithParams()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path1.jpg",
                Transformation =
                [
                    new Transformation { Gradient = "ld-top_from-green_to-00FF0010_sp-1" },
                ],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/test_path1.jpg?tr=e-gradient-ld-top_from-green_to-00FF0010_sp-1",
            url
        );
    }

    [Fact]
    public void AIRemoveBackground_WithWidthAndHeight_IncludesAllTransforms()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path1.jpg",
                Transformation =
                [
                    new Transformation
                    {
                        Width = 300.0,
                        Height = 200.0,
                        AIRemoveBackground = true,
                    },
                ],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/test_path1.jpg?tr=w-300,h-200,e-bgremove",
            url
        );
    }

    [Fact]
    public void AIRemoveBackground_WithDropShadow_IncludesBothTransforms()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path1.jpg",
                Transformation =
                [
                    new Transformation
                    {
                        AIRemoveBackground = true,
                        AIDropShadow = new AIDropShadowDefault(),
                    },
                ],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/test_path1.jpg?tr=e-bgremove,e-dropshadow",
            url
        );
    }

    // --- TestParameterSpecificTransformations ---

    [Fact]
    public void Width_NumberValue_GeneratesWParam()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path1.jpg",
                Transformation = [new Transformation { Width = 400.0 }],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path1.jpg?tr=w-400", url);
    }

    [Fact]
    public void Height_StringValue_GeneratesHParam()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path1.jpg",
                Transformation = [new Transformation { Height = "300" }],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path1.jpg?tr=h-300", url);
    }

    [Fact]
    public void AspectRatio_ColonFormat_GeneratesArParam()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path1.jpg",
                Transformation = [new Transformation { AspectRatio = "4:3" }],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path1.jpg?tr=ar-4:3", url);
    }

    [Fact]
    public void Quality_NumberValue_GeneratesQParam()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path1.jpg",
                Transformation = [new Transformation { Quality = 80.0 }],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path1.jpg?tr=q-80", url);
    }

    [Fact]
    public void Transformation_SkipsUndefinedOrEmptyParameters()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path1.jpg",
                Transformation = [new Transformation { Width = 300.0 }],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path1.jpg?tr=w-300", url);
    }

    [Fact]
    public void Trim_BooleanValue_GeneratesTrueParam()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path1.jpg",
                Transformation = [new Transformation { Trim = new TrimDefault() }],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path1.jpg?tr=t-true", url);
    }

    [Fact]
    public void DefaultImage_EmptyString_OmitsTrParam()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path1.jpg",
                Transformation = [new Transformation { DefaultImage = "" }],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path1.jpg", url);
    }

    [Fact]
    public void ComplexTransformationCombination_GeneratesCorrectUrl()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path1.jpg",
                Transformation =
                [
                    new Transformation
                    {
                        Width = 300.0,
                        Height = 200.0,
                        Quality = 85.0,
                        Border = "5_FF0000",
                    },
                ],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/test_path1.jpg?tr=w-300,h-200,q-85,b-5_FF0000",
            url
        );
    }

    [Fact]
    public void Radius_PerCornerStringValue_GeneratesRParam()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path1.jpg",
                Transformation = [new Transformation { Radius = "10_10_max_10" }],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/test_path1.jpg?tr=r-10_10_max_10",
            url
        );
    }

    [Fact]
    public void AllTransformations_BigTest_GeneratesCorrectUrl()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
                Src = "/test_path.jpg",
                Transformation =
                [
                    new Transformation
                    {
                        Height = 300.0,
                        Width = 400.0,
                        AspectRatio = "4-3",
                        Quality = 40.0,
                        Crop = Crop.Force,
                        CropMode = CropMode.Extract,
                        Focus = "left",
                        Format = Format.Jpeg,
                        Radius = 50.0,
                        Background = "A94D34",
                        Border = "5-A94D34",
                        Rotation = 90.0,
                        Blur = 10.0,
                        Named = "some_name",
                        Progressive = true,
                        Lossless = true,
                        Trim = 5.0,
                        Metadata = true,
                        ColorProfile = true,
                        DefaultImage = "/folder/file.jpg/",
                        Dpr = 3.0,
                        X = 10.0,
                        Y = 20.0,
                        XCenter = 30.0,
                        YCenter = 40.0,
                        Flip = TransformationFlip.H,
                        Opacity = 0.8,
                        Zoom = 2.0,
                        VideoCodec = VideoCodec.H264,
                        AudioCodec = AudioCodec.Aac,
                        StartOffset = 5.0,
                        EndOffset = 15.0,
                        Duration = 10.0,
                        StreamingResolutions =
                        [
                            StreamingResolution.V1440,
                            StreamingResolution.V1080,
                        ],
                        Grayscale = true,
                        AIUpscale = true,
                        AIRetouch = true,
                        AIVariation = true,
                        AIRemoveBackground = true,
                        ContrastStretch = true,
                        AIDropShadow = new AIDropShadowDefault(),
                        AIChangeBackground = "prompt-car",
                        AIEdit = "prompt-make it vintage",
                        Shadow = "bl-15_st-40_x-10_y-N5",
                        Sharpen = 10.0,
                        UnsharpMask = "2-2-0.8-0.024",
                        Gradient = "from-red_to-white",
                        ColorReplace = "FF0000_100_0000FF",
                        Colorize = "co-red_in-50",
                        Distort = "a-45",
                        Original = true,
                        Page = "2_4",
                        Raw = "h-200,w-300,l-image,i-logo.png,l-end",
                    },
                ],
                TransformationPosition = TransformationPosition.Query,
            }
        );

        Assert.Equal(
            "https://ik.imagekit.io/test_url_endpoint/test_path.jpg?tr=w-400,h-300,q-40,ar-4-3,c-force,cm-extract,fo-left,f-jpeg,r-50,bg-A94D34,b-5-A94D34,cr-FF0000_100_0000FF,di-folder@@file.jpg,dpr-3,x-10,y-20,xc-30,yc-40,o-0.8,z-2,rt-90,bl-10,n-some_name,pr-true,lo-true,fl-h,t-5,md-true,cp-true,vc-h264,ac-aac,so-5,eo-15,du-10,sr-1440_1080,e-grayscale,e-upscale,e-retouch,e-genvar,e-bgremove,e-contrast,e-dropshadow,e-changebg-prompt-car,e-edit-prompt-make it vintage,e-shadow-bl-15_st-40_x-10_y-N5,e-sharpen-10,e-usm-2-2-0.8-0.024,e-gradient-from-red_to-white,e-colorize-co-red_in-50,e-distort-a-45,orig-true,pg-2_4,h-200,w-300,l-image,i-logo.png,l-end",
            url
        );
    }
}
