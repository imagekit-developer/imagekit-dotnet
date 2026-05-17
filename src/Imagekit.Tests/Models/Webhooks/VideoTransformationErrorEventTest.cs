using System;
using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.Webhooks;

namespace Imagekit.Tests.Models.Webhooks;

public class VideoTransformationErrorEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEvent
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
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
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

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        VideoTransformationErrorEventVideoTransformationErrorEventData expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
                },
            },
        };
        VideoTransformationErrorEventVideoTransformationErrorEventRequest expectedRequest = new()
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedRequest, model.Request);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEvent
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
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VideoTransformationErrorEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationErrorEvent
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
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VideoTransformationErrorEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        VideoTransformationErrorEventVideoTransformationErrorEventData expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
                },
            },
        };
        VideoTransformationErrorEventVideoTransformationErrorEventRequest expectedRequest = new()
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedRequest, deserialized.Request);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VideoTransformationErrorEvent
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
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
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
    public void CopyConstructor_Works()
    {
        var model = new VideoTransformationErrorEvent
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
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
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

        VideoTransformationErrorEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationErrorEventVideoTransformationErrorEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
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

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        VideoTransformationErrorEventVideoTransformationErrorEventData expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
                },
            },
        };
        VideoTransformationErrorEventVideoTransformationErrorEventRequest expectedRequest = new()
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("video.transformation.error");

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedRequest, model.Request);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventVideoTransformationErrorEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventVideoTransformationErrorEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        VideoTransformationErrorEventVideoTransformationErrorEventData expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
                },
            },
        };
        VideoTransformationErrorEventVideoTransformationErrorEventRequest expectedRequest = new()
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("video.transformation.error");

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedRequest, deserialized.Request);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
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
    public void CopyConstructor_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
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

        VideoTransformationErrorEventVideoTransformationErrorEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationErrorEventVideoTransformationErrorEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
                },
            },
        };

        VideoTransformationErrorEventVideoTransformationErrorEventDataAsset expectedAsset = new(
            "https://example.com"
        );
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation expectedTransformation =
            new()
            {
                Type =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
                },
            };

        Assert.Equal(expectedAsset, model.Asset);
        Assert.Equal(expectedTransformation, model.Transformation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventVideoTransformationErrorEventData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventVideoTransformationErrorEventData>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        VideoTransformationErrorEventVideoTransformationErrorEventDataAsset expectedAsset = new(
            "https://example.com"
        );
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation expectedTransformation =
            new()
            {
                Type =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
                },
            };

        Assert.Equal(expectedAsset, deserialized.Asset);
        Assert.Equal(expectedTransformation, deserialized.Transformation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
                },
            },
        };

        VideoTransformationErrorEventVideoTransformationErrorEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationErrorEventVideoTransformationErrorEventDataAssetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventDataAsset
        {
            Url = "https://example.com",
        };

        string expectedUrl = "https://example.com";

        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventDataAsset
        {
            Url = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventVideoTransformationErrorEventDataAsset>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventDataAsset
        {
            Url = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventVideoTransformationErrorEventDataAsset>(
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
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventDataAsset
        {
            Url = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventDataAsset
        {
            Url = "https://example.com",
        };

        VideoTransformationErrorEventVideoTransformationErrorEventDataAsset copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation
        {
            Type =
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
            Error = new(Reason.EncodingFailed),
            Options = new()
            {
                AudioCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
            },
        };

        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType
        > expectedType =
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation;
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError expectedError =
            new(Reason.EncodingFailed);
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions expectedOptions =
            new()
            {
                AudioCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
            };

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedOptions, model.Options);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation
        {
            Type =
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
            Error = new(Reason.EncodingFailed),
            Options = new()
            {
                AudioCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation
        {
            Type =
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
            Error = new(Reason.EncodingFailed),
            Options = new()
            {
                AudioCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType
        > expectedType =
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation;
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError expectedError =
            new(Reason.EncodingFailed);
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions expectedOptions =
            new()
            {
                AudioCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
            };

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedOptions, deserialized.Options);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation
        {
            Type =
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
            Error = new(Reason.EncodingFailed),
            Options = new()
            {
                AudioCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation
        {
            Type =
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation
        {
            Type =
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation
        {
            Type =
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,

            // Null should be interpreted as omitted for these properties
            Error = null,
            Options = null,
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation
        {
            Type =
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,

            // Null should be interpreted as omitted for these properties
            Error = null,
            Options = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation
        {
            Type =
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
            Error = new(Reason.EncodingFailed),
            Options = new()
            {
                AudioCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
            },
        };

        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationTypeTest
    : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.GifToVideo
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoThumbnail
    )]
    public void Validation_Works(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.GifToVideo
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoThumbnail
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType
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
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationErrorTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError
            {
                Reason = Reason.EncodingFailed,
            };

        ApiEnum<string, Reason> expectedReason = Reason.EncodingFailed;

        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError
            {
                Reason = Reason.EncodingFailed,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError
            {
                Reason = Reason.EncodingFailed,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, Reason> expectedReason = Reason.EncodingFailed;

        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError
            {
                Reason = Reason.EncodingFailed,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError
            {
                Reason = Reason.EncodingFailed,
            };

        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(Reason.EncodingFailed)]
    [InlineData(Reason.DownloadFailed)]
    [InlineData(Reason.InternalServerError)]
    public void Validation_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Reason.EncodingFailed)]
    [InlineData(Reason.DownloadFailed)]
    [InlineData(Reason.InternalServerError)]
    public void SerializationRoundtrip_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions
            {
                AudioCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
            };

        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec
        > expectedAudioCodec =
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac;
        bool expectedAutoRotate = true;
        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat
        > expectedFormat =
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4;
        long expectedQuality = 0;
        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol
        > expectedStreamProtocol =
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls;
        List<string> expectedVariants = ["string"];
        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec
        > expectedVideoCodec =
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264;

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
            new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions
            {
                AudioCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions
            {
                AudioCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec
        > expectedAudioCodec =
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac;
        bool expectedAutoRotate = true;
        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat
        > expectedFormat =
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4;
        long expectedQuality = 0;
        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol
        > expectedStreamProtocol =
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls;
        List<string> expectedVariants = ["string"];
        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec
        > expectedVideoCodec =
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264;

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
            new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions
            {
                AudioCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions
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
            new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions
            { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions
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
            new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions
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
            new VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions
            {
                AudioCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
            };

        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodecTest
    : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Opus
    )]
    public void Validation_Works(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Opus
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec
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
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormatTest
    : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Webm
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Jpg
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Png
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Webp
    )]
    public void Validation_Works(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Webm
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Jpg
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Png
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Webp
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat
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
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocolTest
    : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Dash
    )]
    public void Validation_Works(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Dash
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol
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
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodecTest
    : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.Vp9
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.Av1
    )]
    public void Validation_Works(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.Vp9
    )]
    [InlineData(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.Av1
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec
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
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationErrorEventVideoTransformationErrorEventRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventRequest
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
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventVideoTransformationErrorEventRequest>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventVideoTransformationErrorEventRequest>(
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
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventRequest
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
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventRequest
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
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventRequest
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
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventRequest
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
        var model = new VideoTransformationErrorEventVideoTransformationErrorEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        VideoTransformationErrorEventVideoTransformationErrorEventRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
