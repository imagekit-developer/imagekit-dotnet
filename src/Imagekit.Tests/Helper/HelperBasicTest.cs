// Go source: tests/helper_basic_test.go
// Total test cases in Go: 21

using System.Collections.Generic;
using Imagekit;
using Imagekit.Models;


namespace Imagekit.Tests.Helper;

public class HelperBasicTest
{
    private static readonly ImageKitClient _client = new() { PrivateKey = "My Private API Key" };

    [Fact]
    public void BuildUrl_EmptySrc_ReturnsEmpty()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "",
            TransformationPosition = TransformationPosition.Query,
        });

        Assert.Equal("", url);
    }

    [Fact]
    public void BuildUrl_SrcIsSlash_GeneratesValidUrl()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/",
            TransformationPosition = TransformationPosition.Query,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/", url);
    }

    [Fact]
    public void BuildUrl_SrcWithoutTransformation_GeneratesValidUrl()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/test_path.jpg",
            TransformationPosition = TransformationPosition.Query,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path.jpg", url);
    }

    [Fact]
    public void BuildUrl_AbsoluteSrcWithoutTransformation_ReturnsAbsoluteUrl()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "https://ik.imagekit.io/test_url_endpoint/test_path_alt.jpg",
            TransformationPosition = TransformationPosition.Query,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path_alt.jpg", url);
    }

    [Fact]
    public void BuildUrl_UndefinedTransformationWithQuery_GeneratesValidUrl()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/test_path_alt.jpg",
            TransformationPosition = TransformationPosition.Query,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path_alt.jpg", url);
    }

    [Fact]
    public void BuildUrl_DefaultPositionIsQuery()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/test_path.jpg",
            Transformation =
            [
                new Transformation { Width = "400", Height = "300" },
                new Transformation { Rotation = 90.0 },
            ],
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path.jpg?tr=w-400,h-300:rt-90", url);
    }

    [Fact]
    public void BuildUrl_TransformationPositionPath_EmbedsTrInPath()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/test_path.jpg",
            Transformation = [new Transformation { Width = "400", Height = "300" }],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/tr:w-400,h-300/test_path.jpg", url);
    }

    [Fact]
    public void BuildUrl_WithTransformationPositionQuery_AddsQueryParam()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/test_path.jpg",
            Transformation = [new Transformation { Width = "400", Height = "300" }],
            TransformationPosition = TransformationPosition.Query,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path.jpg?tr=w-400,h-300", url);
    }

    [Fact]
    public void BuildUrl_AbsoluteSrcWithPathPosition_ForcesTrAsQuery()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "https://my.custom.domain.com/test_path.jpg",
            Transformation = [new Transformation { Width = "400", Height = "300" }],
            TransformationPosition = TransformationPosition.Path,
        });

        Assert.Equal("https://my.custom.domain.com/test_path.jpg?tr=w-400,h-300", url);
    }

    [Fact]
    public void BuildUrl_NonDefaultUrlEndpoint_GeneratesCorrectUrl()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/imagekit_id/new-endpoint/",
            Src = "/test_path.jpg",
            Transformation = [new Transformation { Width = "400", Height = "300" }],
        });

        Assert.Equal("https://ik.imagekit.io/imagekit_id/new-endpoint/test_path.jpg?tr=w-400,h-300", url);
    }

    [Fact]
    public void BuildUrl_MultipleLeadingSlashesInSrc_NormalizesSrc()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "///test_path.jpg",
            Transformation = [new Transformation { Width = "400", Height = "300" }],
            TransformationPosition = TransformationPosition.Query,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path.jpg?tr=w-400,h-300", url);
    }

    [Fact]
    public void BuildUrl_OverriddenUrlEndpoint_UsesNewEndpoint()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint_alt",
            Src = "/test_path.jpg",
            Transformation = [new Transformation { Width = "400", Height = "300" }],
            TransformationPosition = TransformationPosition.Query,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint_alt/test_path.jpg?tr=w-400,h-300", url);
    }

    [Fact]
    public void BuildUrl_QueryPositionExplicit_AddsQueryParam()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/test_path.jpg",
            Transformation = [new Transformation { Width = "400", Height = "300" }],
            TransformationPosition = TransformationPosition.Query,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path.jpg?tr=w-400,h-300", url);
    }

    [Fact]
    public void BuildUrl_AbsoluteSrcWithTransformation_AddsQueryParam()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "https://ik.imagekit.io/test_url_endpoint/test_path_alt.jpg",
            Transformation = [new Transformation { Width = "400", Height = "300" }],
            TransformationPosition = TransformationPosition.Query,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path_alt.jpg?tr=w-400,h-300", url);
    }

    [Fact]
    public void BuildUrl_MergesExistingAndNewQueryParams()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "https://ik.imagekit.io/test_url_endpoint/test_path_alt.jpg?t1=v1",
            Transformation = [new Transformation { Width = "400", Height = "300" }],
            QueryParameters = new Dictionary<string, string> { ["t2"] = "v2", ["t3"] = "v3" },
            TransformationPosition = TransformationPosition.Query,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path_alt.jpg?t1=v1&t2=v2&t3=v3&tr=w-400,h-300", url);
    }

    [Fact]
    public void BuildUrl_ChainedTransformations_UsesColonDelimiter()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/test_path.jpg",
            Transformation =
            [
                new Transformation { Width = "400", Height = "300" },
                new Transformation { Rotation = "90" },
            ],
            TransformationPosition = TransformationPosition.Query,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path.jpg?tr=w-400,h-300:rt-90", url);
    }

    [Fact]
    public void BuildUrl_ChainedTransformationsWithRaw_AddsRawAtEnd()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/test_path.jpg",
            Transformation =
            [
                new Transformation { Width = "400", Height = "300" },
                new Transformation { Raw = "rndm_trnsf-abcd" },
            ],
            TransformationPosition = TransformationPosition.Query,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path.jpg?tr=w-400,h-300:rndm_trnsf-abcd", url);
    }

    [Fact]
    public void BuildUrl_BorderTransformation_IncludesBorderParam()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/test_path.jpg",
            Transformation = [new Transformation { Width = "400", Height = "300", Border = "20_FF0000" }],
            TransformationPosition = TransformationPosition.Query,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path.jpg?tr=w-400,h-300,b-20_FF0000", url);
    }

    [Fact]
    public void BuildUrl_EmptyRawTransformation_OmitsTrParam()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/test_url_endpoint",
            Src = "/test_path.jpg",
            Transformation = [new Transformation { Raw = "" }],
            TransformationPosition = TransformationPosition.Query,
        });

        Assert.Equal("https://ik.imagekit.io/test_url_endpoint/test_path.jpg", url);
    }

    [Fact]
    public void BuildUrl_CnameUrlEndpoint_GeneratesValidUrl()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://custom.domain.com",
            Src = "/test_path.jpg",
            TransformationPosition = TransformationPosition.Query,
        });

        Assert.Equal("https://custom.domain.com/test_path.jpg", url);
    }

    [Fact]
    public void BuildUrl_CnameWithUrlPattern_GeneratesValidUrl()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://custom.domain.com/url-pattern",
            Src = "/test_path.jpg",
            TransformationPosition = TransformationPosition.Query,
        });

        Assert.Equal("https://custom.domain.com/url-pattern/test_path.jpg", url);
    }

    [Fact]
    public void BuildUrl_WithCropQualityFormat_GeneratesCorrectQueryString()
    {
        var url = _client.Helper.BuildUrl(new SrcOptions
        {
            UrlEndpoint = "https://ik.imagekit.io/your_imagekit_id",
            Src = "/path/to/image.jpg",
            Transformation =
            [
                new Transformation
                {
                    Width = 400,
                    Height = 300,
                    Crop = Crop.MaintainRatio,
                    Quality = 80,
                    Format = Format.Webp,
                },
            ],
        });

        Assert.Equal(
            "https://ik.imagekit.io/your_imagekit_id/path/to/image.jpg?tr=w-400,h-300,q-80,c-maintain_ratio,f-webp",
            url
        );
    }
}

