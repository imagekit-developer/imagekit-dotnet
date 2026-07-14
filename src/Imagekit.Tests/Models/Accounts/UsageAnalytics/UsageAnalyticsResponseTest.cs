using System;
using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Accounts.UsageAnalytics;

namespace Imagekit.Tests.Models.Accounts.UsageAnalytics;

public class UsageAnalyticsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageAnalyticsResponse
        {
            BandwidthBytes = 0,
            Browser = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            Cache = new()
            {
                ErrorCount = 0,
                HitCount = 0,
                MissCount = 0,
            },
            Country = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Code = "code",
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Code = "code",
                        Name = "name",
                    },
                ],
            },
            Device = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            EndDate = "2019-12-27",
            ErrorReasons =
            [
                new()
                {
                    Name = "ENOENT - Resource not found at any upstream origin",
                    RequestCount = 0,
                },
            ],
            Extensions = [new() { Name = "remove-bg", OperationCount = 0 }],
            Format = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            GeneratedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequestCount = 0,
            StartDate = "2019-12-27",
            StatusCodes = [new() { Name = "200", RequestCount = 0 }],
            Top404Assets =
            [
                new()
                {
                    Name = "https://ik.imagekit.io/demo/products/discontinued-sku-4421.jpg",
                    RequestCount = 0,
                },
            ],
            TopImages = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopImageTransforms = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopOtherAssets = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopReferrers = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopUserAgents = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopVideos = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopVideoTransforms = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            UrlEndpoints = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            VideoProcessing =
            [
                new()
                {
                    Codec = "codec",
                    DurationSeconds = 0,
                    Resolution = "resolution",
                },
            ],
        };

        double expectedBandwidthBytes = 0;
        Browser expectedBrowser = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        UsageAnalyticsResponseCache expectedCache = new()
        {
            ErrorCount = 0,
            HitCount = 0,
            MissCount = 0,
        };
        Country expectedCountry = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Code = "code",
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Code = "code",
                    Name = "name",
                },
            ],
        };
        Device expectedDevice = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        string expectedEndDate = "2019-12-27";
        List<ErrorReason> expectedErrorReasons =
        [
            new() { Name = "ENOENT - Resource not found at any upstream origin", RequestCount = 0 },
        ];
        List<Extension> expectedExtensions = [new() { Name = "remove-bg", OperationCount = 0 }];
        Format expectedFormat = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        DateTimeOffset expectedGeneratedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedRequestCount = 0;
        string expectedStartDate = "2019-12-27";
        List<StatusCode> expectedStatusCodes = [new() { Name = "200", RequestCount = 0 }];
        List<Top404Asset> expectedTop404Assets =
        [
            new()
            {
                Name = "https://ik.imagekit.io/demo/products/discontinued-sku-4421.jpg",
                RequestCount = 0,
            },
        ];
        TopImages expectedTopImages = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        TopImageTransforms expectedTopImageTransforms = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        TopOtherAssets expectedTopOtherAssets = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        TopReferrers expectedTopReferrers = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        TopUserAgents expectedTopUserAgents = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        TopVideos expectedTopVideos = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        TopVideoTransforms expectedTopVideoTransforms = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        UsageAnalyticsResponseUrlEndpoints expectedUrlEndpoints = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        List<VideoProcessing> expectedVideoProcessing =
        [
            new()
            {
                Codec = "codec",
                DurationSeconds = 0,
                Resolution = "resolution",
            },
        ];

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedBrowser, model.Browser);
        Assert.Equal(expectedCache, model.Cache);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedDevice, model.Device);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedErrorReasons.Count, model.ErrorReasons.Count);
        for (int i = 0; i < expectedErrorReasons.Count; i++)
        {
            Assert.Equal(expectedErrorReasons[i], model.ErrorReasons[i]);
        }
        Assert.Equal(expectedExtensions.Count, model.Extensions.Count);
        for (int i = 0; i < expectedExtensions.Count; i++)
        {
            Assert.Equal(expectedExtensions[i], model.Extensions[i]);
        }
        Assert.Equal(expectedFormat, model.Format);
        Assert.Equal(expectedGeneratedAt, model.GeneratedAt);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedStartDate, model.StartDate);
        Assert.Equal(expectedStatusCodes.Count, model.StatusCodes.Count);
        for (int i = 0; i < expectedStatusCodes.Count; i++)
        {
            Assert.Equal(expectedStatusCodes[i], model.StatusCodes[i]);
        }
        Assert.Equal(expectedTop404Assets.Count, model.Top404Assets.Count);
        for (int i = 0; i < expectedTop404Assets.Count; i++)
        {
            Assert.Equal(expectedTop404Assets[i], model.Top404Assets[i]);
        }
        Assert.Equal(expectedTopImages, model.TopImages);
        Assert.Equal(expectedTopImageTransforms, model.TopImageTransforms);
        Assert.Equal(expectedTopOtherAssets, model.TopOtherAssets);
        Assert.Equal(expectedTopReferrers, model.TopReferrers);
        Assert.Equal(expectedTopUserAgents, model.TopUserAgents);
        Assert.Equal(expectedTopVideos, model.TopVideos);
        Assert.Equal(expectedTopVideoTransforms, model.TopVideoTransforms);
        Assert.Equal(expectedUrlEndpoints, model.UrlEndpoints);
        Assert.Equal(expectedVideoProcessing.Count, model.VideoProcessing.Count);
        for (int i = 0; i < expectedVideoProcessing.Count; i++)
        {
            Assert.Equal(expectedVideoProcessing[i], model.VideoProcessing[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageAnalyticsResponse
        {
            BandwidthBytes = 0,
            Browser = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            Cache = new()
            {
                ErrorCount = 0,
                HitCount = 0,
                MissCount = 0,
            },
            Country = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Code = "code",
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Code = "code",
                        Name = "name",
                    },
                ],
            },
            Device = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            EndDate = "2019-12-27",
            ErrorReasons =
            [
                new()
                {
                    Name = "ENOENT - Resource not found at any upstream origin",
                    RequestCount = 0,
                },
            ],
            Extensions = [new() { Name = "remove-bg", OperationCount = 0 }],
            Format = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            GeneratedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequestCount = 0,
            StartDate = "2019-12-27",
            StatusCodes = [new() { Name = "200", RequestCount = 0 }],
            Top404Assets =
            [
                new()
                {
                    Name = "https://ik.imagekit.io/demo/products/discontinued-sku-4421.jpg",
                    RequestCount = 0,
                },
            ],
            TopImages = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopImageTransforms = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopOtherAssets = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopReferrers = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopUserAgents = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopVideos = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopVideoTransforms = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            UrlEndpoints = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            VideoProcessing =
            [
                new()
                {
                    Codec = "codec",
                    DurationSeconds = 0,
                    Resolution = "resolution",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageAnalyticsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageAnalyticsResponse
        {
            BandwidthBytes = 0,
            Browser = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            Cache = new()
            {
                ErrorCount = 0,
                HitCount = 0,
                MissCount = 0,
            },
            Country = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Code = "code",
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Code = "code",
                        Name = "name",
                    },
                ],
            },
            Device = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            EndDate = "2019-12-27",
            ErrorReasons =
            [
                new()
                {
                    Name = "ENOENT - Resource not found at any upstream origin",
                    RequestCount = 0,
                },
            ],
            Extensions = [new() { Name = "remove-bg", OperationCount = 0 }],
            Format = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            GeneratedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequestCount = 0,
            StartDate = "2019-12-27",
            StatusCodes = [new() { Name = "200", RequestCount = 0 }],
            Top404Assets =
            [
                new()
                {
                    Name = "https://ik.imagekit.io/demo/products/discontinued-sku-4421.jpg",
                    RequestCount = 0,
                },
            ],
            TopImages = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopImageTransforms = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopOtherAssets = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopReferrers = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopUserAgents = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopVideos = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopVideoTransforms = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            UrlEndpoints = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            VideoProcessing =
            [
                new()
                {
                    Codec = "codec",
                    DurationSeconds = 0,
                    Resolution = "resolution",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageAnalyticsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        Browser expectedBrowser = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        UsageAnalyticsResponseCache expectedCache = new()
        {
            ErrorCount = 0,
            HitCount = 0,
            MissCount = 0,
        };
        Country expectedCountry = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Code = "code",
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Code = "code",
                    Name = "name",
                },
            ],
        };
        Device expectedDevice = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        string expectedEndDate = "2019-12-27";
        List<ErrorReason> expectedErrorReasons =
        [
            new() { Name = "ENOENT - Resource not found at any upstream origin", RequestCount = 0 },
        ];
        List<Extension> expectedExtensions = [new() { Name = "remove-bg", OperationCount = 0 }];
        Format expectedFormat = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        DateTimeOffset expectedGeneratedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedRequestCount = 0;
        string expectedStartDate = "2019-12-27";
        List<StatusCode> expectedStatusCodes = [new() { Name = "200", RequestCount = 0 }];
        List<Top404Asset> expectedTop404Assets =
        [
            new()
            {
                Name = "https://ik.imagekit.io/demo/products/discontinued-sku-4421.jpg",
                RequestCount = 0,
            },
        ];
        TopImages expectedTopImages = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        TopImageTransforms expectedTopImageTransforms = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        TopOtherAssets expectedTopOtherAssets = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        TopReferrers expectedTopReferrers = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        TopUserAgents expectedTopUserAgents = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        TopVideos expectedTopVideos = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        TopVideoTransforms expectedTopVideoTransforms = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        UsageAnalyticsResponseUrlEndpoints expectedUrlEndpoints = new()
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };
        List<VideoProcessing> expectedVideoProcessing =
        [
            new()
            {
                Codec = "codec",
                DurationSeconds = 0,
                Resolution = "resolution",
            },
        ];

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedBrowser, deserialized.Browser);
        Assert.Equal(expectedCache, deserialized.Cache);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedDevice, deserialized.Device);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedErrorReasons.Count, deserialized.ErrorReasons.Count);
        for (int i = 0; i < expectedErrorReasons.Count; i++)
        {
            Assert.Equal(expectedErrorReasons[i], deserialized.ErrorReasons[i]);
        }
        Assert.Equal(expectedExtensions.Count, deserialized.Extensions.Count);
        for (int i = 0; i < expectedExtensions.Count; i++)
        {
            Assert.Equal(expectedExtensions[i], deserialized.Extensions[i]);
        }
        Assert.Equal(expectedFormat, deserialized.Format);
        Assert.Equal(expectedGeneratedAt, deserialized.GeneratedAt);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
        Assert.Equal(expectedStatusCodes.Count, deserialized.StatusCodes.Count);
        for (int i = 0; i < expectedStatusCodes.Count; i++)
        {
            Assert.Equal(expectedStatusCodes[i], deserialized.StatusCodes[i]);
        }
        Assert.Equal(expectedTop404Assets.Count, deserialized.Top404Assets.Count);
        for (int i = 0; i < expectedTop404Assets.Count; i++)
        {
            Assert.Equal(expectedTop404Assets[i], deserialized.Top404Assets[i]);
        }
        Assert.Equal(expectedTopImages, deserialized.TopImages);
        Assert.Equal(expectedTopImageTransforms, deserialized.TopImageTransforms);
        Assert.Equal(expectedTopOtherAssets, deserialized.TopOtherAssets);
        Assert.Equal(expectedTopReferrers, deserialized.TopReferrers);
        Assert.Equal(expectedTopUserAgents, deserialized.TopUserAgents);
        Assert.Equal(expectedTopVideos, deserialized.TopVideos);
        Assert.Equal(expectedTopVideoTransforms, deserialized.TopVideoTransforms);
        Assert.Equal(expectedUrlEndpoints, deserialized.UrlEndpoints);
        Assert.Equal(expectedVideoProcessing.Count, deserialized.VideoProcessing.Count);
        for (int i = 0; i < expectedVideoProcessing.Count; i++)
        {
            Assert.Equal(expectedVideoProcessing[i], deserialized.VideoProcessing[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageAnalyticsResponse
        {
            BandwidthBytes = 0,
            Browser = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            Cache = new()
            {
                ErrorCount = 0,
                HitCount = 0,
                MissCount = 0,
            },
            Country = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Code = "code",
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Code = "code",
                        Name = "name",
                    },
                ],
            },
            Device = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            EndDate = "2019-12-27",
            ErrorReasons =
            [
                new()
                {
                    Name = "ENOENT - Resource not found at any upstream origin",
                    RequestCount = 0,
                },
            ],
            Extensions = [new() { Name = "remove-bg", OperationCount = 0 }],
            Format = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            GeneratedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequestCount = 0,
            StartDate = "2019-12-27",
            StatusCodes = [new() { Name = "200", RequestCount = 0 }],
            Top404Assets =
            [
                new()
                {
                    Name = "https://ik.imagekit.io/demo/products/discontinued-sku-4421.jpg",
                    RequestCount = 0,
                },
            ],
            TopImages = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopImageTransforms = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopOtherAssets = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopReferrers = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopUserAgents = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopVideos = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopVideoTransforms = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            UrlEndpoints = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            VideoProcessing =
            [
                new()
                {
                    Codec = "codec",
                    DurationSeconds = 0,
                    Resolution = "resolution",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageAnalyticsResponse
        {
            BandwidthBytes = 0,
            Browser = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            Cache = new()
            {
                ErrorCount = 0,
                HitCount = 0,
                MissCount = 0,
            },
            Country = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Code = "code",
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Code = "code",
                        Name = "name",
                    },
                ],
            },
            Device = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            EndDate = "2019-12-27",
            ErrorReasons =
            [
                new()
                {
                    Name = "ENOENT - Resource not found at any upstream origin",
                    RequestCount = 0,
                },
            ],
            Extensions = [new() { Name = "remove-bg", OperationCount = 0 }],
            Format = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            GeneratedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequestCount = 0,
            StartDate = "2019-12-27",
            StatusCodes = [new() { Name = "200", RequestCount = 0 }],
            Top404Assets =
            [
                new()
                {
                    Name = "https://ik.imagekit.io/demo/products/discontinued-sku-4421.jpg",
                    RequestCount = 0,
                },
            ],
            TopImages = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopImageTransforms = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopOtherAssets = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopReferrers = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopUserAgents = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopVideos = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            TopVideoTransforms = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            UrlEndpoints = new()
            {
                ByBandwidth =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
                ByRequests =
                [
                    new()
                    {
                        BandwidthBytes = 0,
                        RequestCount = 0,
                        Name = "name",
                    },
                ],
            },
            VideoProcessing =
            [
                new()
                {
                    Codec = "codec",
                    DurationSeconds = 0,
                    Resolution = "resolution",
                },
            ],
        };

        UsageAnalyticsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BrowserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Browser
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        List<ByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<ByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, model.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], model.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, model.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], model.ByRequests[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Browser
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Browser>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Browser
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Browser>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<ByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, deserialized.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], deserialized.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, deserialized.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], deserialized.ByRequests[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Browser
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Browser
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        Browser copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ByBandwidthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ByBandwidth>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ByBandwidth>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        ByBandwidth copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BrowserByBandwidthEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrowserByBandwidthEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrowserByBandwidthEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserByBandwidthEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrowserByBandwidthEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserByBandwidthEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrowserByBandwidthEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrowserByBandwidthEntry { Name = "name" };

        BrowserByBandwidthEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ByRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ByRequest>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ByRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        ByRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BrowserByRequestsEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrowserByRequestsEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrowserByRequestsEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserByRequestsEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrowserByRequestsEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserByRequestsEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrowserByRequestsEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrowserByRequestsEntry { Name = "name" };

        BrowserByRequestsEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UsageAnalyticsResponseCacheTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageAnalyticsResponseCache
        {
            ErrorCount = 0,
            HitCount = 0,
            MissCount = 0,
        };

        double expectedErrorCount = 0;
        double expectedHitCount = 0;
        double expectedMissCount = 0;

        Assert.Equal(expectedErrorCount, model.ErrorCount);
        Assert.Equal(expectedHitCount, model.HitCount);
        Assert.Equal(expectedMissCount, model.MissCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageAnalyticsResponseCache
        {
            ErrorCount = 0,
            HitCount = 0,
            MissCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageAnalyticsResponseCache>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageAnalyticsResponseCache
        {
            ErrorCount = 0,
            HitCount = 0,
            MissCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageAnalyticsResponseCache>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedErrorCount = 0;
        double expectedHitCount = 0;
        double expectedMissCount = 0;

        Assert.Equal(expectedErrorCount, deserialized.ErrorCount);
        Assert.Equal(expectedHitCount, deserialized.HitCount);
        Assert.Equal(expectedMissCount, deserialized.MissCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageAnalyticsResponseCache
        {
            ErrorCount = 0,
            HitCount = 0,
            MissCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageAnalyticsResponseCache
        {
            ErrorCount = 0,
            HitCount = 0,
            MissCount = 0,
        };

        UsageAnalyticsResponseCache copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CountryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Country
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Code = "code",
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Code = "code",
                    Name = "name",
                },
            ],
        };

        List<CountryByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Code = "code",
                Name = "name",
            },
        ];
        List<CountryByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Code = "code",
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, model.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], model.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, model.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], model.ByRequests[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Country
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Code = "code",
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Code = "code",
                    Name = "name",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Country>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Country
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Code = "code",
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Code = "code",
                    Name = "name",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Country>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CountryByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Code = "code",
                Name = "name",
            },
        ];
        List<CountryByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Code = "code",
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, deserialized.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], deserialized.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, deserialized.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], deserialized.ByRequests[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Country
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Code = "code",
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Code = "code",
                    Name = "name",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Country
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Code = "code",
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Code = "code",
                    Name = "name",
                },
            ],
        };

        Country copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CountryByBandwidthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CountryByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Code = "code",
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedCode = "code";
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CountryByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Code = "code",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CountryByBandwidth>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CountryByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Code = "code",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CountryByBandwidth>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedCode = "code";
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CountryByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Code = "code",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CountryByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Code = "code",
            Name = "name",
        };

        CountryByBandwidth copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CountryByBandwidthEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CountryByBandwidthEntry { Code = "code", Name = "name" };

        string expectedCode = "code";
        string expectedName = "name";

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CountryByBandwidthEntry { Code = "code", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CountryByBandwidthEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CountryByBandwidthEntry { Code = "code", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CountryByBandwidthEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCode = "code";
        string expectedName = "name";

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CountryByBandwidthEntry { Code = "code", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CountryByBandwidthEntry { Code = "code", Name = "name" };

        CountryByBandwidthEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CountryByRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CountryByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Code = "code",
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedCode = "code";
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CountryByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Code = "code",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CountryByRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CountryByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Code = "code",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CountryByRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedCode = "code";
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CountryByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Code = "code",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CountryByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Code = "code",
            Name = "name",
        };

        CountryByRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CountryByRequestsEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CountryByRequestsEntry { Code = "code", Name = "name" };

        string expectedCode = "code";
        string expectedName = "name";

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CountryByRequestsEntry { Code = "code", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CountryByRequestsEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CountryByRequestsEntry { Code = "code", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CountryByRequestsEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCode = "code";
        string expectedName = "name";

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CountryByRequestsEntry { Code = "code", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CountryByRequestsEntry { Code = "code", Name = "name" };

        CountryByRequestsEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeviceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Device
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        List<DeviceByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<DeviceByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, model.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], model.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, model.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], model.ByRequests[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Device
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Device>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Device
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Device>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<DeviceByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<DeviceByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, deserialized.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], deserialized.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, deserialized.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], deserialized.ByRequests[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Device
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Device
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        Device copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeviceByBandwidthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeviceByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeviceByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeviceByBandwidth>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeviceByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeviceByBandwidth>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeviceByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeviceByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        DeviceByBandwidth copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeviceByBandwidthEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeviceByBandwidthEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeviceByBandwidthEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeviceByBandwidthEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeviceByBandwidthEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeviceByBandwidthEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeviceByBandwidthEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeviceByBandwidthEntry { Name = "name" };

        DeviceByBandwidthEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeviceByRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeviceByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeviceByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeviceByRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeviceByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeviceByRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeviceByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeviceByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        DeviceByRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeviceByRequestsEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeviceByRequestsEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeviceByRequestsEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeviceByRequestsEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeviceByRequestsEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeviceByRequestsEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeviceByRequestsEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeviceByRequestsEntry { Name = "name" };

        DeviceByRequestsEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ErrorReasonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ErrorReason
        {
            Name = "ENOENT - Resource not found at any upstream origin",
            RequestCount = 0,
        };

        string expectedName = "ENOENT - Resource not found at any upstream origin";
        double expectedRequestCount = 0;

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRequestCount, model.RequestCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ErrorReason
        {
            Name = "ENOENT - Resource not found at any upstream origin",
            RequestCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorReason>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ErrorReason
        {
            Name = "ENOENT - Resource not found at any upstream origin",
            RequestCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorReason>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "ENOENT - Resource not found at any upstream origin";
        double expectedRequestCount = 0;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ErrorReason
        {
            Name = "ENOENT - Resource not found at any upstream origin",
            RequestCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ErrorReason
        {
            Name = "ENOENT - Resource not found at any upstream origin",
            RequestCount = 0,
        };

        ErrorReason copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtensionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Extension { Name = "remove-bg", OperationCount = 0 };

        string expectedName = "remove-bg";
        double expectedOperationCount = 0;

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOperationCount, model.OperationCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Extension { Name = "remove-bg", OperationCount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Extension>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Extension { Name = "remove-bg", OperationCount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Extension>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "remove-bg";
        double expectedOperationCount = 0;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOperationCount, deserialized.OperationCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Extension { Name = "remove-bg", OperationCount = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Extension { Name = "remove-bg", OperationCount = 0 };

        Extension copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormatTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Format
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        List<FormatByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<FormatByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, model.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], model.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, model.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], model.ByRequests[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Format
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Format>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Format
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Format>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<FormatByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<FormatByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, deserialized.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], deserialized.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, deserialized.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], deserialized.ByRequests[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Format
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Format
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        Format copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormatByBandwidthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormatByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FormatByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormatByBandwidth>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormatByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormatByBandwidth>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FormatByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FormatByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        FormatByBandwidth copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormatByBandwidthEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormatByBandwidthEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FormatByBandwidthEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormatByBandwidthEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormatByBandwidthEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormatByBandwidthEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FormatByBandwidthEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FormatByBandwidthEntry { Name = "name" };

        FormatByBandwidthEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormatByRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormatByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FormatByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormatByRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormatByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormatByRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FormatByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FormatByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        FormatByRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormatByRequestsEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormatByRequestsEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FormatByRequestsEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormatByRequestsEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormatByRequestsEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormatByRequestsEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FormatByRequestsEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FormatByRequestsEntry { Name = "name" };

        FormatByRequestsEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusCodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StatusCode { Name = "200", RequestCount = 0 };

        string expectedName = "200";
        double expectedRequestCount = 0;

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRequestCount, model.RequestCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StatusCode { Name = "200", RequestCount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StatusCode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StatusCode { Name = "200", RequestCount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StatusCode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "200";
        double expectedRequestCount = 0;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StatusCode { Name = "200", RequestCount = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StatusCode { Name = "200", RequestCount = 0 };

        StatusCode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class Top404AssetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Top404Asset
        {
            Name = "https://ik.imagekit.io/demo/products/discontinued-sku-4421.jpg",
            RequestCount = 0,
        };

        string expectedName = "https://ik.imagekit.io/demo/products/discontinued-sku-4421.jpg";
        double expectedRequestCount = 0;

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRequestCount, model.RequestCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Top404Asset
        {
            Name = "https://ik.imagekit.io/demo/products/discontinued-sku-4421.jpg",
            RequestCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Top404Asset>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Top404Asset
        {
            Name = "https://ik.imagekit.io/demo/products/discontinued-sku-4421.jpg",
            RequestCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Top404Asset>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "https://ik.imagekit.io/demo/products/discontinued-sku-4421.jpg";
        double expectedRequestCount = 0;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Top404Asset
        {
            Name = "https://ik.imagekit.io/demo/products/discontinued-sku-4421.jpg",
            RequestCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Top404Asset
        {
            Name = "https://ik.imagekit.io/demo/products/discontinued-sku-4421.jpg",
            RequestCount = 0,
        };

        Top404Asset copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopImagesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopImages
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        List<TopImagesByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<TopImagesByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, model.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], model.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, model.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], model.ByRequests[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopImages
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImages>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopImages
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImages>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<TopImagesByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<TopImagesByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, deserialized.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], deserialized.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, deserialized.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], deserialized.ByRequests[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopImages
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopImages
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        TopImages copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopImagesByBandwidthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopImagesByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopImagesByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImagesByBandwidth>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopImagesByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImagesByBandwidth>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopImagesByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopImagesByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        TopImagesByBandwidth copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopImagesByBandwidthEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopImagesByBandwidthEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopImagesByBandwidthEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImagesByBandwidthEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopImagesByBandwidthEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImagesByBandwidthEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopImagesByBandwidthEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopImagesByBandwidthEntry { Name = "name" };

        TopImagesByBandwidthEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopImagesByRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopImagesByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopImagesByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImagesByRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopImagesByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImagesByRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopImagesByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopImagesByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        TopImagesByRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopImagesByRequestsEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopImagesByRequestsEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopImagesByRequestsEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImagesByRequestsEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopImagesByRequestsEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImagesByRequestsEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopImagesByRequestsEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopImagesByRequestsEntry { Name = "name" };

        TopImagesByRequestsEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopImageTransformsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopImageTransforms
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        List<TopImageTransformsByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<TopImageTransformsByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, model.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], model.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, model.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], model.ByRequests[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopImageTransforms
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImageTransforms>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopImageTransforms
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImageTransforms>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<TopImageTransformsByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<TopImageTransformsByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, deserialized.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], deserialized.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, deserialized.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], deserialized.ByRequests[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopImageTransforms
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopImageTransforms
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        TopImageTransforms copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopImageTransformsByBandwidthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopImageTransformsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopImageTransformsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImageTransformsByBandwidth>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopImageTransformsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImageTransformsByBandwidth>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopImageTransformsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopImageTransformsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        TopImageTransformsByBandwidth copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopImageTransformsByBandwidthEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopImageTransformsByBandwidthEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopImageTransformsByBandwidthEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImageTransformsByBandwidthEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopImageTransformsByBandwidthEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImageTransformsByBandwidthEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopImageTransformsByBandwidthEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopImageTransformsByBandwidthEntry { Name = "name" };

        TopImageTransformsByBandwidthEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopImageTransformsByRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopImageTransformsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopImageTransformsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImageTransformsByRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopImageTransformsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImageTransformsByRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopImageTransformsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopImageTransformsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        TopImageTransformsByRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopImageTransformsByRequestsEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopImageTransformsByRequestsEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopImageTransformsByRequestsEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImageTransformsByRequestsEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopImageTransformsByRequestsEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopImageTransformsByRequestsEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopImageTransformsByRequestsEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopImageTransformsByRequestsEntry { Name = "name" };

        TopImageTransformsByRequestsEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopOtherAssetsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopOtherAssets
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        List<TopOtherAssetsByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<TopOtherAssetsByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, model.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], model.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, model.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], model.ByRequests[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopOtherAssets
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopOtherAssets>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopOtherAssets
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopOtherAssets>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<TopOtherAssetsByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<TopOtherAssetsByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, deserialized.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], deserialized.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, deserialized.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], deserialized.ByRequests[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopOtherAssets
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopOtherAssets
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        TopOtherAssets copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopOtherAssetsByBandwidthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopOtherAssetsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopOtherAssetsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopOtherAssetsByBandwidth>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopOtherAssetsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopOtherAssetsByBandwidth>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopOtherAssetsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopOtherAssetsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        TopOtherAssetsByBandwidth copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopOtherAssetsByBandwidthEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopOtherAssetsByBandwidthEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopOtherAssetsByBandwidthEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopOtherAssetsByBandwidthEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopOtherAssetsByBandwidthEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopOtherAssetsByBandwidthEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopOtherAssetsByBandwidthEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopOtherAssetsByBandwidthEntry { Name = "name" };

        TopOtherAssetsByBandwidthEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopOtherAssetsByRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopOtherAssetsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopOtherAssetsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopOtherAssetsByRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopOtherAssetsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopOtherAssetsByRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopOtherAssetsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopOtherAssetsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        TopOtherAssetsByRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopOtherAssetsByRequestsEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopOtherAssetsByRequestsEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopOtherAssetsByRequestsEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopOtherAssetsByRequestsEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopOtherAssetsByRequestsEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopOtherAssetsByRequestsEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopOtherAssetsByRequestsEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopOtherAssetsByRequestsEntry { Name = "name" };

        TopOtherAssetsByRequestsEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopReferrersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopReferrers
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        List<TopReferrersByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<TopReferrersByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, model.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], model.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, model.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], model.ByRequests[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopReferrers
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopReferrers>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopReferrers
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopReferrers>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<TopReferrersByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<TopReferrersByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, deserialized.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], deserialized.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, deserialized.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], deserialized.ByRequests[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopReferrers
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopReferrers
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        TopReferrers copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopReferrersByBandwidthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopReferrersByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopReferrersByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopReferrersByBandwidth>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopReferrersByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopReferrersByBandwidth>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopReferrersByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopReferrersByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        TopReferrersByBandwidth copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopReferrersByBandwidthEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopReferrersByBandwidthEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopReferrersByBandwidthEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopReferrersByBandwidthEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopReferrersByBandwidthEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopReferrersByBandwidthEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopReferrersByBandwidthEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopReferrersByBandwidthEntry { Name = "name" };

        TopReferrersByBandwidthEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopReferrersByRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopReferrersByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopReferrersByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopReferrersByRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopReferrersByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopReferrersByRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopReferrersByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopReferrersByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        TopReferrersByRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopReferrersByRequestsEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopReferrersByRequestsEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopReferrersByRequestsEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopReferrersByRequestsEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopReferrersByRequestsEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopReferrersByRequestsEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopReferrersByRequestsEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopReferrersByRequestsEntry { Name = "name" };

        TopReferrersByRequestsEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopUserAgentsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopUserAgents
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        List<TopUserAgentsByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<TopUserAgentsByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, model.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], model.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, model.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], model.ByRequests[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopUserAgents
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopUserAgents>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopUserAgents
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopUserAgents>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<TopUserAgentsByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<TopUserAgentsByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, deserialized.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], deserialized.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, deserialized.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], deserialized.ByRequests[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopUserAgents
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopUserAgents
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        TopUserAgents copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopUserAgentsByBandwidthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopUserAgentsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopUserAgentsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopUserAgentsByBandwidth>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopUserAgentsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopUserAgentsByBandwidth>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopUserAgentsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopUserAgentsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        TopUserAgentsByBandwidth copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopUserAgentsByBandwidthEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopUserAgentsByBandwidthEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopUserAgentsByBandwidthEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopUserAgentsByBandwidthEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopUserAgentsByBandwidthEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopUserAgentsByBandwidthEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopUserAgentsByBandwidthEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopUserAgentsByBandwidthEntry { Name = "name" };

        TopUserAgentsByBandwidthEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopUserAgentsByRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopUserAgentsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopUserAgentsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopUserAgentsByRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopUserAgentsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopUserAgentsByRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopUserAgentsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopUserAgentsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        TopUserAgentsByRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopUserAgentsByRequestsEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopUserAgentsByRequestsEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopUserAgentsByRequestsEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopUserAgentsByRequestsEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopUserAgentsByRequestsEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopUserAgentsByRequestsEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopUserAgentsByRequestsEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopUserAgentsByRequestsEntry { Name = "name" };

        TopUserAgentsByRequestsEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopVideosTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopVideos
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        List<TopVideosByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<TopVideosByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, model.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], model.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, model.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], model.ByRequests[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopVideos
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideos>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopVideos
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideos>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<TopVideosByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<TopVideosByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, deserialized.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], deserialized.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, deserialized.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], deserialized.ByRequests[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopVideos
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopVideos
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        TopVideos copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopVideosByBandwidthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopVideosByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopVideosByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideosByBandwidth>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopVideosByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideosByBandwidth>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopVideosByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopVideosByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        TopVideosByBandwidth copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopVideosByBandwidthEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopVideosByBandwidthEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopVideosByBandwidthEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideosByBandwidthEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopVideosByBandwidthEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideosByBandwidthEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopVideosByBandwidthEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopVideosByBandwidthEntry { Name = "name" };

        TopVideosByBandwidthEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopVideosByRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopVideosByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopVideosByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideosByRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopVideosByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideosByRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopVideosByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopVideosByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        TopVideosByRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopVideosByRequestsEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopVideosByRequestsEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopVideosByRequestsEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideosByRequestsEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopVideosByRequestsEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideosByRequestsEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopVideosByRequestsEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopVideosByRequestsEntry { Name = "name" };

        TopVideosByRequestsEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopVideoTransformsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopVideoTransforms
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        List<TopVideoTransformsByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<TopVideoTransformsByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, model.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], model.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, model.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], model.ByRequests[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopVideoTransforms
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideoTransforms>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopVideoTransforms
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideoTransforms>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<TopVideoTransformsByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<TopVideoTransformsByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, deserialized.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], deserialized.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, deserialized.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], deserialized.ByRequests[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopVideoTransforms
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopVideoTransforms
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        TopVideoTransforms copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopVideoTransformsByBandwidthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopVideoTransformsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopVideoTransformsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideoTransformsByBandwidth>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopVideoTransformsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideoTransformsByBandwidth>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopVideoTransformsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopVideoTransformsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        TopVideoTransformsByBandwidth copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopVideoTransformsByBandwidthEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopVideoTransformsByBandwidthEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopVideoTransformsByBandwidthEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideoTransformsByBandwidthEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopVideoTransformsByBandwidthEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideoTransformsByBandwidthEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopVideoTransformsByBandwidthEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopVideoTransformsByBandwidthEntry { Name = "name" };

        TopVideoTransformsByBandwidthEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopVideoTransformsByRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopVideoTransformsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopVideoTransformsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideoTransformsByRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopVideoTransformsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideoTransformsByRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopVideoTransformsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopVideoTransformsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        TopVideoTransformsByRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopVideoTransformsByRequestsEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopVideoTransformsByRequestsEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopVideoTransformsByRequestsEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideoTransformsByRequestsEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopVideoTransformsByRequestsEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopVideoTransformsByRequestsEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopVideoTransformsByRequestsEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopVideoTransformsByRequestsEntry { Name = "name" };

        TopVideoTransformsByRequestsEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UsageAnalyticsResponseUrlEndpointsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageAnalyticsResponseUrlEndpoints
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        List<UsageAnalyticsResponseUrlEndpointsByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<UsageAnalyticsResponseUrlEndpointsByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, model.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], model.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, model.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], model.ByRequests[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageAnalyticsResponseUrlEndpoints
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageAnalyticsResponseUrlEndpoints>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageAnalyticsResponseUrlEndpoints
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageAnalyticsResponseUrlEndpoints>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<UsageAnalyticsResponseUrlEndpointsByBandwidth> expectedByBandwidth =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];
        List<UsageAnalyticsResponseUrlEndpointsByRequest> expectedByRequests =
        [
            new()
            {
                BandwidthBytes = 0,
                RequestCount = 0,
                Name = "name",
            },
        ];

        Assert.Equal(expectedByBandwidth.Count, deserialized.ByBandwidth.Count);
        for (int i = 0; i < expectedByBandwidth.Count; i++)
        {
            Assert.Equal(expectedByBandwidth[i], deserialized.ByBandwidth[i]);
        }
        Assert.Equal(expectedByRequests.Count, deserialized.ByRequests.Count);
        for (int i = 0; i < expectedByRequests.Count; i++)
        {
            Assert.Equal(expectedByRequests[i], deserialized.ByRequests[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageAnalyticsResponseUrlEndpoints
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageAnalyticsResponseUrlEndpoints
        {
            ByBandwidth =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
            ByRequests =
            [
                new()
                {
                    BandwidthBytes = 0,
                    RequestCount = 0,
                    Name = "name",
                },
            ],
        };

        UsageAnalyticsResponseUrlEndpoints copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UsageAnalyticsResponseUrlEndpointsByBandwidthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageAnalyticsResponseUrlEndpointsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageAnalyticsResponseUrlEndpointsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UsageAnalyticsResponseUrlEndpointsByBandwidth>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageAnalyticsResponseUrlEndpointsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UsageAnalyticsResponseUrlEndpointsByBandwidth>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageAnalyticsResponseUrlEndpointsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageAnalyticsResponseUrlEndpointsByBandwidth
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        UsageAnalyticsResponseUrlEndpointsByBandwidth copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UrlEndpointsByBandwidthEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UrlEndpointsByBandwidthEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UrlEndpointsByBandwidthEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointsByBandwidthEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UrlEndpointsByBandwidthEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointsByBandwidthEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UrlEndpointsByBandwidthEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UrlEndpointsByBandwidthEntry { Name = "name" };

        UrlEndpointsByBandwidthEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UsageAnalyticsResponseUrlEndpointsByRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageAnalyticsResponseUrlEndpointsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageAnalyticsResponseUrlEndpointsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageAnalyticsResponseUrlEndpointsByRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageAnalyticsResponseUrlEndpointsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageAnalyticsResponseUrlEndpointsByRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;
        string expectedName = "name";

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageAnalyticsResponseUrlEndpointsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageAnalyticsResponseUrlEndpointsByRequest
        {
            BandwidthBytes = 0,
            RequestCount = 0,
            Name = "name",
        };

        UsageAnalyticsResponseUrlEndpointsByRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UrlEndpointsByRequestsEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UrlEndpointsByRequestsEntry { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UrlEndpointsByRequestsEntry { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointsByRequestsEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UrlEndpointsByRequestsEntry { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointsByRequestsEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UrlEndpointsByRequestsEntry { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UrlEndpointsByRequestsEntry { Name = "name" };

        UrlEndpointsByRequestsEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoProcessingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoProcessing
        {
            Codec = "codec",
            DurationSeconds = 0,
            Resolution = "resolution",
        };

        string expectedCodec = "codec";
        double expectedDurationSeconds = 0;
        string expectedResolution = "resolution";

        Assert.Equal(expectedCodec, model.Codec);
        Assert.Equal(expectedDurationSeconds, model.DurationSeconds);
        Assert.Equal(expectedResolution, model.Resolution);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoProcessing
        {
            Codec = "codec",
            DurationSeconds = 0,
            Resolution = "resolution",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VideoProcessing>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoProcessing
        {
            Codec = "codec",
            DurationSeconds = 0,
            Resolution = "resolution",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VideoProcessing>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCodec = "codec";
        double expectedDurationSeconds = 0;
        string expectedResolution = "resolution";

        Assert.Equal(expectedCodec, deserialized.Codec);
        Assert.Equal(expectedDurationSeconds, deserialized.DurationSeconds);
        Assert.Equal(expectedResolution, deserialized.Resolution);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VideoProcessing
        {
            Codec = "codec",
            DurationSeconds = 0,
            Resolution = "resolution",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoProcessing
        {
            Codec = "codec",
            DurationSeconds = 0,
            Resolution = "resolution",
        };

        VideoProcessing copied = new(model);

        Assert.Equal(model, copied);
    }
}
