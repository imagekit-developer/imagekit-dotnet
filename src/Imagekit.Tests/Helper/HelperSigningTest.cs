// Go source: tests/helper_signing_test.go
// Total test cases in Go: 10

using Imagekit;
using Imagekit.Models;

namespace Imagekit.Tests.Helper;

public class HelperSigningTest
{
    private static readonly ImageKitClient _client = new() { PrivateKey = "dummy-key" };

    [Fact]
    public void BuildUrl_SignedWithoutExpiresIn_AddsSignatureWithoutTimestamp()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/demo/",
                Src = "sdk-testing-files/future-search.png",
                Signed = true,
            }
        );

        Assert.Equal(
            "https://ik.imagekit.io/demo/sdk-testing-files/future-search.png?ik-s=32dbbbfc5f945c0403c71b54c38e76896ef2d6b0",
            url
        );
    }

    [Fact]
    public void BuildUrl_SignedWithExpiresIn_AddsTimestampParam()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/demo/",
                Src = "sdk-testing-files/future-search.png",
                Signed = true,
                ExpiresIn = 3600,
            }
        );

        Assert.Contains("ik-t", url);
    }

    [Fact]
    public void BuildUrl_ExpiresInAboveZeroWithSignedFalse_StillAddsTimestamp()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/demo/",
                Src = "sdk-testing-files/future-search.png",
                Signed = false,
                ExpiresIn = 3600,
            }
        );

        Assert.Contains("ik-t", url);
    }

    [Fact]
    public void BuildUrl_SignedWithSpecialCharFilename_EncodesAndSigns()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/demo/",
                Src = "sdk-testing-files/हिन्दी.png",
                Signed = true,
            }
        );

        Assert.Equal(
            "https://ik.imagekit.io/demo/sdk-testing-files/%E0%A4%B9%E0%A4%BF%E0%A4%A8%E0%A5%8D%E0%A4%A6%E0%A5%80.png?ik-s=3fff2f31da1f45e007adcdbe95f88c8c330e743c",
            url
        );
    }

    [Fact]
    public void BuildUrl_SignedWithTextOverlaySpecialChars_GeneratesSignedUrl()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/demo/",
                Src = "sdk-testing-files/हिन्दी.png",
                Transformation =
                [
                    new Transformation
                    {
                        Overlay = new TextOverlay("हिन्दी")
                        {
                            Transformation =
                            [
                                new TextOverlayTransformation
                                {
                                    FontColor = "red",
                                    FontSize = 32.0,
                                    FontFamily = "sdk-testing-files/Poppins-Regular_Q15GrYWmL.ttf",
                                },
                            ],
                        },
                    },
                ],
                Signed = true,
            }
        );

        Assert.Equal(
            "https://ik.imagekit.io/demo/sdk-testing-files/%E0%A4%B9%E0%A4%BF%E0%A4%A8%E0%A5%8D%E0%A4%A6%E0%A5%80.png?tr=l-text,ie-4KS54KS%2F4KSo4KWN4KSm4KWA,fs-32,ff-sdk-testing-files@@Poppins-Regular_Q15GrYWmL.ttf,co-red,l-end&ik-s=705e41579d368caa6530a4375355325277fcfe5c",
            url
        );
    }

    [Fact]
    public void BuildUrl_SignedWithPathPositionAndSpecialChars_GeneratesSignedUrl()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/demo/",
                Src = "sdk-testing-files/हिन्दी.png",
                Transformation =
                [
                    new Transformation
                    {
                        Overlay = new TextOverlay("हिन्दी")
                        {
                            Transformation =
                            [
                                new TextOverlayTransformation
                                {
                                    FontColor = "red",
                                    FontSize = 32.0,
                                    FontFamily = "sdk-testing-files/Poppins-Regular_Q15GrYWmL.ttf",
                                },
                            ],
                        },
                    },
                ],
                TransformationPosition = TransformationPosition.Path,
                Signed = true,
            }
        );

        Assert.Equal(
            "https://ik.imagekit.io/demo/tr:l-text,ie-4KS54KS%2F4KSo4KWN4KSm4KWA,fs-32,ff-sdk-testing-files@@Poppins-Regular_Q15GrYWmL.ttf,co-red,l-end/sdk-testing-files/%E0%A4%B9%E0%A4%BF%E0%A4%A8%E0%A5%8D%E0%A4%A6%E0%A5%80.png?ik-s=20958f6126fd67c90653f55a49f2b7bb938d9d1c",
            url
        );
    }

    [Fact]
    public void BuildUrl_SignedWithQueryParameters_IncludesQueryParamsInSignature()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/demo/",
                Src = "sdk-testing-files/future-search.png",
                QueryParameters = new System.Collections.Generic.Dictionary<string, string>
                {
                    ["version"] = "1.0",
                    ["cache"] = "false",
                },
                Signed = true,
            }
        );

        Assert.Equal(
            "https://ik.imagekit.io/demo/sdk-testing-files/future-search.png?cache=false&version=1.0&ik-s=03767bb6f0898c04e42f65714af65d937c696d66",
            url
        );
    }

    [Fact]
    public void BuildUrl_SignedWithTransformationsAndQueryParams_GeneratesSignedUrl()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/demo/",
                Src = "sdk-testing-files/future-search.png",
                Transformation = [new Transformation { Width = 300.0, Height = 200.0 }],
                QueryParameters = new System.Collections.Generic.Dictionary<string, string>
                {
                    ["version"] = "2.0",
                },
                Signed = true,
            }
        );

        Assert.Equal(
            "https://ik.imagekit.io/demo/sdk-testing-files/future-search.png?version=2.0&tr=w-300,h-200&ik-s=601d97a7834b7554f4dabf0d3fc3a219ceeb6b31",
            url
        );
    }

    [Fact]
    public void BuildUrl_SignedFalse_NoSignatureAdded()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/demo/",
                Src = "sdk-testing-files/future-search.png",
                Signed = false,
            }
        );

        Assert.Equal("https://ik.imagekit.io/demo/sdk-testing-files/future-search.png", url);
        Assert.DoesNotContain("ik-s=", url);
        Assert.DoesNotContain("ik-t=", url);
    }

    [Fact]
    public void BuildUrl_SignedWithPathPositionAndQueryParams_GeneratesSignedUrl()
    {
        var url = _client.Helper.BuildUrl(
            new SrcOptions
            {
                UrlEndpoint = "https://ik.imagekit.io/demo/",
                Src = "sdk-testing-files/future-search.png",
                Transformation = [new Transformation { Width = 300.0, Height = 200.0 }],
                TransformationPosition = TransformationPosition.Path,
                QueryParameters = new System.Collections.Generic.Dictionary<string, string>
                {
                    ["version"] = "2.0",
                },
                Signed = true,
            }
        );

        Assert.Equal(
            "https://ik.imagekit.io/demo/tr:w-300,h-200/sdk-testing-files/future-search.png?version=2.0&ik-s=dd1ee8f83d019bc59fd57a5fc4674a11eb8a3496",
            url
        );
    }
}
