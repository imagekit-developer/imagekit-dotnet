using System;
using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.Webhooks;

namespace Imagekit.Tests.Models.Webhooks;

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
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
        VideoTransformationReadyEventVideoTransformationReadyEventData expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
        VideoTransformationReadyEventVideoTransformationReadyEventRequest expectedRequest = new()
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
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
        VideoTransformationReadyEventVideoTransformationReadyEventData expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
        VideoTransformationReadyEventVideoTransformationReadyEventRequest expectedRequest = new()
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
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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

public class VideoTransformationReadyEventVideoTransformationReadyEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEventVideoTransformationReadyEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
        VideoTransformationReadyEventVideoTransformationReadyEventData expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
        VideoTransformationReadyEventVideoTransformationReadyEventRequest expectedRequest = new()
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
            JsonSerializer.Deserialize<VideoTransformationReadyEventVideoTransformationReadyEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationReadyEventVideoTransformationReadyEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
            JsonSerializer.Deserialize<VideoTransformationReadyEventVideoTransformationReadyEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        VideoTransformationReadyEventVideoTransformationReadyEventData expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
        VideoTransformationReadyEventVideoTransformationReadyEventRequest expectedRequest = new()
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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

        VideoTransformationReadyEventVideoTransformationReadyEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationReadyEventVideoTransformationReadyEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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

        VideoTransformationReadyEventVideoTransformationReadyEventDataAsset expectedAsset = new(
            "https://example.com"
        );
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation expectedTransformation =
            new()
            {
                Type =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
            JsonSerializer.Deserialize<VideoTransformationReadyEventVideoTransformationReadyEventData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
            JsonSerializer.Deserialize<VideoTransformationReadyEventVideoTransformationReadyEventData>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        VideoTransformationReadyEventVideoTransformationReadyEventDataAsset expectedAsset = new(
            "https://example.com"
        );
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation expectedTransformation =
            new()
            {
                Type =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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

        VideoTransformationReadyEventVideoTransformationReadyEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationReadyEventVideoTransformationReadyEventDataAssetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventDataAsset
        {
            Url = "https://example.com",
        };

        string expectedUrl = "https://example.com";

        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventDataAsset
        {
            Url = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationReadyEventVideoTransformationReadyEventDataAsset>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventDataAsset
        {
            Url = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationReadyEventVideoTransformationReadyEventDataAsset>(
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventDataAsset
        {
            Url = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventDataAsset
        {
            Url = "https://example.com",
        };

        VideoTransformationReadyEventVideoTransformationReadyEventDataAsset copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation
        {
            Type =
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
            Options = new()
            {
                AudioCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType
        > expectedType =
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation;
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions expectedOptions =
            new()
            {
                AudioCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation
        {
            Type =
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
            Options = new()
            {
                AudioCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
            JsonSerializer.Deserialize<VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation
        {
            Type =
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
            Options = new()
            {
                AudioCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
            JsonSerializer.Deserialize<VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType
        > expectedType =
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation;
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions expectedOptions =
            new()
            {
                AudioCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation
        {
            Type =
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
            Options = new()
            {
                AudioCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation
        {
            Type =
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
        };

        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation
        {
            Type =
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation
        {
            Type =
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,

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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation
        {
            Type =
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,

            // Null should be interpreted as omitted for these properties
            Options = null,
            Output = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation
        {
            Type =
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
            Options = new()
            {
                AudioCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
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

        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationTypeTest
    : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.GifToVideo
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoThumbnail
    )]
    public void Validation_Works(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.GifToVideo
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoThumbnail
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType
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
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions
            {
                AudioCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
            };

        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec
        > expectedAudioCodec =
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac;
        bool expectedAutoRotate = true;
        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat
        > expectedFormat =
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4;
        long expectedQuality = 0;
        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol
        > expectedStreamProtocol =
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls;
        List<string> expectedVariants = ["string"];
        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec
        > expectedVideoCodec =
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264;

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
        var model =
            new VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions
            {
                AudioCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions
            {
                AudioCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec
        > expectedAudioCodec =
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac;
        bool expectedAutoRotate = true;
        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat
        > expectedFormat =
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4;
        long expectedQuality = 0;
        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol
        > expectedStreamProtocol =
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls;
        List<string> expectedVariants = ["string"];
        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec
        > expectedVideoCodec =
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264;

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
        var model =
            new VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions
            {
                AudioCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions
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
        var model =
            new VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions
            { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions
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
        var model =
            new VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions
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
        var model =
            new VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions
            {
                AudioCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
            };

        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodecTest
    : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Opus
    )]
    public void Validation_Works(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Opus
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec
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
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormatTest
    : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Webm
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Jpg
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Png
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Webp
    )]
    public void Validation_Works(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Webm
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Jpg
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Png
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Webp
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat
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
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocolTest
    : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Dash
    )]
    public void Validation_Works(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Dash
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol
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
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodecTest
    : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.Vp9
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.Av1
    )]
    public void Validation_Works(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.Vp9
    )]
    [InlineData(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.Av1
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec
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
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec
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

public class VideoTransformationReadyEventVideoTransformationReadyEventRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventRequest
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationReadyEventVideoTransformationReadyEventRequest>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationReadyEventVideoTransformationReadyEventRequest>(
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventRequest
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventRequest
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventRequest
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventRequest
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
        var model = new VideoTransformationReadyEventVideoTransformationReadyEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        VideoTransformationReadyEventVideoTransformationReadyEventRequest copied = new(model);

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
