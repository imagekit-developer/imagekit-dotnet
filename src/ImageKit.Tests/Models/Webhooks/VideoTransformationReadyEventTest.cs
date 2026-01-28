using System;
using System.Collections.Generic;
using System.Text.Json;
using ImageKit.Core;
using ImageKit.Exceptions;
using ImageKit.Models.Webhooks;

namespace ImageKit.Tests.Models.Webhooks;

public class VideoTransformationReadyEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { DownloadDuration = 0, EncodingDuration = 0 },
        };

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        VideoTransformationReadyEventIntersectionMember1Data expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
                Output = new()
                {
                    Url = "https://example.com",
                    VideoMetadata = new()
                    {
                        Bitrate = 0,
                        Duration = 0,
                        Height = 0,
                        Width = 0,
                    },
                },
            },
        };
        VideoTransformationReadyEventIntersectionMember1Request expectedRequest = new()
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };
        Timings expectedTimings = new() { DownloadDuration = 0, EncodingDuration = 0 };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedRequest, model.Request);
        Assert.Equal(expectedTimings, model.Timings);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { DownloadDuration = 0, EncodingDuration = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VideoTransformationReadyEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationReadyEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { DownloadDuration = 0, EncodingDuration = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VideoTransformationReadyEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        VideoTransformationReadyEventIntersectionMember1Data expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
                Output = new()
                {
                    Url = "https://example.com",
                    VideoMetadata = new()
                    {
                        Bitrate = 0,
                        Duration = 0,
                        Height = 0,
                        Width = 0,
                    },
                },
            },
        };
        VideoTransformationReadyEventIntersectionMember1Request expectedRequest = new()
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };
        Timings expectedTimings = new() { DownloadDuration = 0, EncodingDuration = 0 };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedRequest, deserialized.Request);
        Assert.Equal(expectedTimings, deserialized.Timings);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VideoTransformationReadyEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { DownloadDuration = 0, EncodingDuration = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VideoTransformationReadyEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
        };

        Assert.Null(model.Timings);
        Assert.False(model.RawData.ContainsKey("timings"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VideoTransformationReadyEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VideoTransformationReadyEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },

            // Null should be interpreted as omitted for these properties
            Timings = null,
        };

        Assert.Null(model.Timings);
        Assert.False(model.RawData.ContainsKey("timings"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VideoTransformationReadyEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },

            // Null should be interpreted as omitted for these properties
            Timings = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoTransformationReadyEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { DownloadDuration = 0, EncodingDuration = 0 },
        };

        VideoTransformationReadyEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationReadyEventIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { DownloadDuration = 0, EncodingDuration = 0 },
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        VideoTransformationReadyEventIntersectionMember1Data expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
                Output = new()
                {
                    Url = "https://example.com",
                    VideoMetadata = new()
                    {
                        Bitrate = 0,
                        Duration = 0,
                        Height = 0,
                        Width = 0,
                    },
                },
            },
        };
        VideoTransformationReadyEventIntersectionMember1Request expectedRequest = new()
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("video.transformation.ready");
        Timings expectedTimings = new() { DownloadDuration = 0, EncodingDuration = 0 };

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedRequest, model.Request);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedTimings, model.Timings);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { DownloadDuration = 0, EncodingDuration = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationReadyEventIntersectionMember1>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { DownloadDuration = 0, EncodingDuration = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationReadyEventIntersectionMember1>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        VideoTransformationReadyEventIntersectionMember1Data expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
                Output = new()
                {
                    Url = "https://example.com",
                    VideoMetadata = new()
                    {
                        Bitrate = 0,
                        Duration = 0,
                        Height = 0,
                        Width = 0,
                    },
                },
            },
        };
        VideoTransformationReadyEventIntersectionMember1Request expectedRequest = new()
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("video.transformation.ready");
        Timings expectedTimings = new() { DownloadDuration = 0, EncodingDuration = 0 };

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedRequest, deserialized.Request);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedTimings, deserialized.Timings);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { DownloadDuration = 0, EncodingDuration = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
        };

        Assert.Null(model.Timings);
        Assert.False(model.RawData.ContainsKey("timings"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },

            // Null should be interpreted as omitted for these properties
            Timings = null,
        };

        Assert.Null(model.Timings);
        Assert.False(model.RawData.ContainsKey("timings"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },

            // Null should be interpreted as omitted for these properties
            Timings = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { DownloadDuration = 0, EncodingDuration = 0 },
        };

        VideoTransformationReadyEventIntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationReadyEventIntersectionMember1DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1Data
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
                Output = new()
                {
                    Url = "https://example.com",
                    VideoMetadata = new()
                    {
                        Bitrate = 0,
                        Duration = 0,
                        Height = 0,
                        Width = 0,
                    },
                },
            },
        };

        VideoTransformationReadyEventIntersectionMember1DataAsset expectedAsset = new(
            "https://example.com"
        );
        VideoTransformationReadyEventIntersectionMember1DataTransformation expectedTransformation =
            new()
            {
                Type =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
                Output = new()
                {
                    Url = "https://example.com",
                    VideoMetadata = new()
                    {
                        Bitrate = 0,
                        Duration = 0,
                        Height = 0,
                        Width = 0,
                    },
                },
            };

        Assert.Equal(expectedAsset, model.Asset);
        Assert.Equal(expectedTransformation, model.Transformation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1Data
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
                Output = new()
                {
                    Url = "https://example.com",
                    VideoMetadata = new()
                    {
                        Bitrate = 0,
                        Duration = 0,
                        Height = 0,
                        Width = 0,
                    },
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationReadyEventIntersectionMember1Data>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1Data
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
                Output = new()
                {
                    Url = "https://example.com",
                    VideoMetadata = new()
                    {
                        Bitrate = 0,
                        Duration = 0,
                        Height = 0,
                        Width = 0,
                    },
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationReadyEventIntersectionMember1Data>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        VideoTransformationReadyEventIntersectionMember1DataAsset expectedAsset = new(
            "https://example.com"
        );
        VideoTransformationReadyEventIntersectionMember1DataTransformation expectedTransformation =
            new()
            {
                Type =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
                Output = new()
                {
                    Url = "https://example.com",
                    VideoMetadata = new()
                    {
                        Bitrate = 0,
                        Duration = 0,
                        Height = 0,
                        Width = 0,
                    },
                },
            };

        Assert.Equal(expectedAsset, deserialized.Asset);
        Assert.Equal(expectedTransformation, deserialized.Transformation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1Data
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
                Output = new()
                {
                    Url = "https://example.com",
                    VideoMetadata = new()
                    {
                        Bitrate = 0,
                        Duration = 0,
                        Height = 0,
                        Width = 0,
                    },
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1Data
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
                Output = new()
                {
                    Url = "https://example.com",
                    VideoMetadata = new()
                    {
                        Bitrate = 0,
                        Duration = 0,
                        Height = 0,
                        Width = 0,
                    },
                },
            },
        };

        VideoTransformationReadyEventIntersectionMember1Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationReadyEventIntersectionMember1DataAssetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataAsset
        {
            Url = "https://example.com",
        };

        string expectedUrl = "https://example.com";

        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataAsset
        {
            Url = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationReadyEventIntersectionMember1DataAsset>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataAsset
        {
            Url = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationReadyEventIntersectionMember1DataAsset>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedUrl = "https://example.com";

        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataAsset
        {
            Url = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataAsset
        {
            Url = "https://example.com",
        };

        VideoTransformationReadyEventIntersectionMember1DataAsset copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationReadyEventIntersectionMember1DataTransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataTransformation
        {
            Type =
                VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
            Options = new()
            {
                AudioCodec =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
            },
            Output = new()
            {
                Url = "https://example.com",
                VideoMetadata = new()
                {
                    Bitrate = 0,
                    Duration = 0,
                    Height = 0,
                    Width = 0,
                },
            },
        };

        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationType
        > expectedType =
            VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation;
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptions expectedOptions =
            new()
            {
                AudioCodec =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
            };
        Output expectedOutput = new()
        {
            Url = "https://example.com",
            VideoMetadata = new()
            {
                Bitrate = 0,
                Duration = 0,
                Height = 0,
                Width = 0,
            },
        };

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedOptions, model.Options);
        Assert.Equal(expectedOutput, model.Output);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataTransformation
        {
            Type =
                VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
            Options = new()
            {
                AudioCodec =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
            },
            Output = new()
            {
                Url = "https://example.com",
                VideoMetadata = new()
                {
                    Bitrate = 0,
                    Duration = 0,
                    Height = 0,
                    Width = 0,
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationReadyEventIntersectionMember1DataTransformation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataTransformation
        {
            Type =
                VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
            Options = new()
            {
                AudioCodec =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
            },
            Output = new()
            {
                Url = "https://example.com",
                VideoMetadata = new()
                {
                    Bitrate = 0,
                    Duration = 0,
                    Height = 0,
                    Width = 0,
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationReadyEventIntersectionMember1DataTransformation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationType
        > expectedType =
            VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation;
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptions expectedOptions =
            new()
            {
                AudioCodec =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
            };
        Output expectedOutput = new()
        {
            Url = "https://example.com",
            VideoMetadata = new()
            {
                Bitrate = 0,
                Duration = 0,
                Height = 0,
                Width = 0,
            },
        };

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedOptions, deserialized.Options);
        Assert.Equal(expectedOutput, deserialized.Output);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataTransformation
        {
            Type =
                VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
            Options = new()
            {
                AudioCodec =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
            },
            Output = new()
            {
                Url = "https://example.com",
                VideoMetadata = new()
                {
                    Bitrate = 0,
                    Duration = 0,
                    Height = 0,
                    Width = 0,
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataTransformation
        {
            Type =
                VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
        };

        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataTransformation
        {
            Type =
                VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataTransformation
        {
            Type =
                VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,

            // Null should be interpreted as omitted for these properties
            Options = null,
            Output = null,
        };

        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataTransformation
        {
            Type =
                VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,

            // Null should be interpreted as omitted for these properties
            Options = null,
            Output = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataTransformation
        {
            Type =
                VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
            Options = new()
            {
                AudioCodec =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
            },
            Output = new()
            {
                Url = "https://example.com",
                VideoMetadata = new()
                {
                    Bitrate = 0,
                    Duration = 0,
                    Height = 0,
                    Width = 0,
                },
            },
        };

        VideoTransformationReadyEventIntersectionMember1DataTransformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationReadyEventIntersectionMember1DataTransformationTypeTest : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation
    )]
    [InlineData(VideoTransformationReadyEventIntersectionMember1DataTransformationType.GifToVideo)]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoThumbnail
    )]
    public void Validation_Works(
        VideoTransformationReadyEventIntersectionMember1DataTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationType
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, VideoTransformationReadyEventIntersectionMember1DataTransformationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation
    )]
    [InlineData(VideoTransformationReadyEventIntersectionMember1DataTransformationType.GifToVideo)]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoThumbnail
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationReadyEventIntersectionMember1DataTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationType
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VideoTransformationReadyEventIntersectionMember1DataTransformationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, VideoTransformationReadyEventIntersectionMember1DataTransformationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VideoTransformationReadyEventIntersectionMember1DataTransformationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataTransformationOptions
        {
            AudioCodec =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
            AutoRotate = true,
            Format =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
            Quality = 0,
            StreamProtocol =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
            Variants = ["string"],
            VideoCodec =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
        };

        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec
        > expectedAudioCodec =
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac;
        bool expectedAutoRotate = true;
        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat
        > expectedFormat =
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4;
        long expectedQuality = 0;
        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol
        > expectedStreamProtocol =
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls;
        List<string> expectedVariants = ["string"];
        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec
        > expectedVideoCodec =
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264;

        Assert.Equal(expectedAudioCodec, model.AudioCodec);
        Assert.Equal(expectedAutoRotate, model.AutoRotate);
        Assert.Equal(expectedFormat, model.Format);
        Assert.Equal(expectedQuality, model.Quality);
        Assert.Equal(expectedStreamProtocol, model.StreamProtocol);
        Assert.NotNull(model.Variants);
        Assert.Equal(expectedVariants.Count, model.Variants.Count);
        for (int i = 0; i < expectedVariants.Count; i++)
        {
            Assert.Equal(expectedVariants[i], model.Variants[i]);
        }
        Assert.Equal(expectedVideoCodec, model.VideoCodec);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataTransformationOptions
        {
            AudioCodec =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
            AutoRotate = true,
            Format =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
            Quality = 0,
            StreamProtocol =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
            Variants = ["string"],
            VideoCodec =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationReadyEventIntersectionMember1DataTransformationOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataTransformationOptions
        {
            AudioCodec =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
            AutoRotate = true,
            Format =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
            Quality = 0,
            StreamProtocol =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
            Variants = ["string"],
            VideoCodec =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationReadyEventIntersectionMember1DataTransformationOptions>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec
        > expectedAudioCodec =
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac;
        bool expectedAutoRotate = true;
        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat
        > expectedFormat =
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4;
        long expectedQuality = 0;
        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol
        > expectedStreamProtocol =
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls;
        List<string> expectedVariants = ["string"];
        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec
        > expectedVideoCodec =
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264;

        Assert.Equal(expectedAudioCodec, deserialized.AudioCodec);
        Assert.Equal(expectedAutoRotate, deserialized.AutoRotate);
        Assert.Equal(expectedFormat, deserialized.Format);
        Assert.Equal(expectedQuality, deserialized.Quality);
        Assert.Equal(expectedStreamProtocol, deserialized.StreamProtocol);
        Assert.NotNull(deserialized.Variants);
        Assert.Equal(expectedVariants.Count, deserialized.Variants.Count);
        for (int i = 0; i < expectedVariants.Count; i++)
        {
            Assert.Equal(expectedVariants[i], deserialized.Variants[i]);
        }
        Assert.Equal(expectedVideoCodec, deserialized.VideoCodec);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataTransformationOptions
        {
            AudioCodec =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
            AutoRotate = true,
            Format =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
            Quality = 0,
            StreamProtocol =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
            Variants = ["string"],
            VideoCodec =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataTransformationOptions
        { };

        Assert.Null(model.AudioCodec);
        Assert.False(model.RawData.ContainsKey("audio_codec"));
        Assert.Null(model.AutoRotate);
        Assert.False(model.RawData.ContainsKey("auto_rotate"));
        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.Quality);
        Assert.False(model.RawData.ContainsKey("quality"));
        Assert.Null(model.StreamProtocol);
        Assert.False(model.RawData.ContainsKey("stream_protocol"));
        Assert.Null(model.Variants);
        Assert.False(model.RawData.ContainsKey("variants"));
        Assert.Null(model.VideoCodec);
        Assert.False(model.RawData.ContainsKey("video_codec"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataTransformationOptions
        { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataTransformationOptions
        {
            // Null should be interpreted as omitted for these properties
            AudioCodec = null,
            AutoRotate = null,
            Format = null,
            Quality = null,
            StreamProtocol = null,
            Variants = null,
            VideoCodec = null,
        };

        Assert.Null(model.AudioCodec);
        Assert.False(model.RawData.ContainsKey("audio_codec"));
        Assert.Null(model.AutoRotate);
        Assert.False(model.RawData.ContainsKey("auto_rotate"));
        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.Quality);
        Assert.False(model.RawData.ContainsKey("quality"));
        Assert.Null(model.StreamProtocol);
        Assert.False(model.RawData.ContainsKey("stream_protocol"));
        Assert.Null(model.Variants);
        Assert.False(model.RawData.ContainsKey("variants"));
        Assert.Null(model.VideoCodec);
        Assert.False(model.RawData.ContainsKey("video_codec"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataTransformationOptions
        {
            // Null should be interpreted as omitted for these properties
            AudioCodec = null,
            AutoRotate = null,
            Format = null,
            Quality = null,
            StreamProtocol = null,
            Variants = null,
            VideoCodec = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1DataTransformationOptions
        {
            AudioCodec =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
            AutoRotate = true,
            Format =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
            Quality = 0,
            StreamProtocol =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
            Variants = ["string"],
            VideoCodec =
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
        };

        VideoTransformationReadyEventIntersectionMember1DataTransformationOptions copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodecTest
    : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac
    )]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Opus
    )]
    public void Validation_Works(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac
    )]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Opus
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormatTest
    : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4
    )]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Webm
    )]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Jpg
    )]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Png
    )]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Webp
    )]
    public void Validation_Works(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4
    )]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Webm
    )]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Jpg
    )]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Png
    )]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Webp
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocolTest
    : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls
    )]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Dash
    )]
    public void Validation_Works(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls
    )]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Dash
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodecTest
    : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264
    )]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.Vp9
    )]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.Av1
    )]
    public void Validation_Works(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264
    )]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.Vp9
    )]
    [InlineData(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.Av1
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Output
        {
            Url = "https://example.com",
            VideoMetadata = new()
            {
                Bitrate = 0,
                Duration = 0,
                Height = 0,
                Width = 0,
            },
        };

        string expectedUrl = "https://example.com";
        VideoMetadata expectedVideoMetadata = new()
        {
            Bitrate = 0,
            Duration = 0,
            Height = 0,
            Width = 0,
        };

        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedVideoMetadata, model.VideoMetadata);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Output
        {
            Url = "https://example.com",
            VideoMetadata = new()
            {
                Bitrate = 0,
                Duration = 0,
                Height = 0,
                Width = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Output>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Output
        {
            Url = "https://example.com",
            VideoMetadata = new()
            {
                Bitrate = 0,
                Duration = 0,
                Height = 0,
                Width = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Output>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedUrl = "https://example.com";
        VideoMetadata expectedVideoMetadata = new()
        {
            Bitrate = 0,
            Duration = 0,
            Height = 0,
            Width = 0,
        };

        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedVideoMetadata, deserialized.VideoMetadata);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Output
        {
            Url = "https://example.com",
            VideoMetadata = new()
            {
                Bitrate = 0,
                Duration = 0,
                Height = 0,
                Width = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Output { Url = "https://example.com" };

        Assert.Null(model.VideoMetadata);
        Assert.False(model.RawData.ContainsKey("video_metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Output { Url = "https://example.com" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Output
        {
            Url = "https://example.com",

            // Null should be interpreted as omitted for these properties
            VideoMetadata = null,
        };

        Assert.Null(model.VideoMetadata);
        Assert.False(model.RawData.ContainsKey("video_metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Output
        {
            Url = "https://example.com",

            // Null should be interpreted as omitted for these properties
            VideoMetadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Output
        {
            Url = "https://example.com",
            VideoMetadata = new()
            {
                Bitrate = 0,
                Duration = 0,
                Height = 0,
                Width = 0,
            },
        };

        Output copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoMetadata
        {
            Bitrate = 0,
            Duration = 0,
            Height = 0,
            Width = 0,
        };

        long expectedBitrate = 0;
        double expectedDuration = 0;
        long expectedHeight = 0;
        long expectedWidth = 0;

        Assert.Equal(expectedBitrate, model.Bitrate);
        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoMetadata
        {
            Bitrate = 0,
            Duration = 0,
            Height = 0,
            Width = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VideoMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoMetadata
        {
            Bitrate = 0,
            Duration = 0,
            Height = 0,
            Width = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VideoMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedBitrate = 0;
        double expectedDuration = 0;
        long expectedHeight = 0;
        long expectedWidth = 0;

        Assert.Equal(expectedBitrate, deserialized.Bitrate);
        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VideoMetadata
        {
            Bitrate = 0,
            Duration = 0,
            Height = 0,
            Width = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoMetadata
        {
            Bitrate = 0,
            Duration = 0,
            Height = 0,
            Width = 0,
        };

        VideoMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationReadyEventIntersectionMember1RequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1Request
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        string expectedUrl = "https://example.com";
        string expectedXRequestID = "x_request_id";
        string expectedUserAgent = "user_agent";

        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedXRequestID, model.XRequestID);
        Assert.Equal(expectedUserAgent, model.UserAgent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1Request
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationReadyEventIntersectionMember1Request>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1Request
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationReadyEventIntersectionMember1Request>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedUrl = "https://example.com";
        string expectedXRequestID = "x_request_id";
        string expectedUserAgent = "user_agent";

        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedXRequestID, deserialized.XRequestID);
        Assert.Equal(expectedUserAgent, deserialized.UserAgent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1Request
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1Request
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
        };

        Assert.Null(model.UserAgent);
        Assert.False(model.RawData.ContainsKey("user_agent"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1Request
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1Request
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",

            // Null should be interpreted as omitted for these properties
            UserAgent = null,
        };

        Assert.Null(model.UserAgent);
        Assert.False(model.RawData.ContainsKey("user_agent"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1Request
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",

            // Null should be interpreted as omitted for these properties
            UserAgent = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoTransformationReadyEventIntersectionMember1Request
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        VideoTransformationReadyEventIntersectionMember1Request copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TimingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Timings { DownloadDuration = 0, EncodingDuration = 0 };

        long expectedDownloadDuration = 0;
        long expectedEncodingDuration = 0;

        Assert.Equal(expectedDownloadDuration, model.DownloadDuration);
        Assert.Equal(expectedEncodingDuration, model.EncodingDuration);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Timings { DownloadDuration = 0, EncodingDuration = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Timings>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Timings { DownloadDuration = 0, EncodingDuration = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Timings>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDownloadDuration = 0;
        long expectedEncodingDuration = 0;

        Assert.Equal(expectedDownloadDuration, deserialized.DownloadDuration);
        Assert.Equal(expectedEncodingDuration, deserialized.EncodingDuration);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Timings { DownloadDuration = 0, EncodingDuration = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Timings { };

        Assert.Null(model.DownloadDuration);
        Assert.False(model.RawData.ContainsKey("download_duration"));
        Assert.Null(model.EncodingDuration);
        Assert.False(model.RawData.ContainsKey("encoding_duration"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Timings { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Timings
        {
            // Null should be interpreted as omitted for these properties
            DownloadDuration = null,
            EncodingDuration = null,
        };

        Assert.Null(model.DownloadDuration);
        Assert.False(model.RawData.ContainsKey("download_duration"));
        Assert.Null(model.EncodingDuration);
        Assert.False(model.RawData.ContainsKey("encoding_duration"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Timings
        {
            // Null should be interpreted as omitted for these properties
            DownloadDuration = null,
            EncodingDuration = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Timings { DownloadDuration = 0, EncodingDuration = 0 };

        Timings copied = new(model);

        Assert.Equal(model, copied);
    }
}
