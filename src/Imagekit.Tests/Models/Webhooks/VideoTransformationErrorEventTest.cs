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
                        VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
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
        VideoTransformationErrorEventIntersectionMember1Data expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
            },
        };
        VideoTransformationErrorEventIntersectionMember1Request expectedRequest = new()
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
                        VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
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
                        VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
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
        VideoTransformationErrorEventIntersectionMember1Data expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
            },
        };
        VideoTransformationErrorEventIntersectionMember1Request expectedRequest = new()
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
                        VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
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
                        VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
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

public class VideoTransformationErrorEventIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
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
        VideoTransformationErrorEventIntersectionMember1Data expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
            },
        };
        VideoTransformationErrorEventIntersectionMember1Request expectedRequest = new()
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
        var model = new VideoTransformationErrorEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
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
            JsonSerializer.Deserialize<VideoTransformationErrorEventIntersectionMember1>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
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
            JsonSerializer.Deserialize<VideoTransformationErrorEventIntersectionMember1>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        VideoTransformationErrorEventIntersectionMember1Data expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
            },
        };
        VideoTransformationErrorEventIntersectionMember1Request expectedRequest = new()
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
        var model = new VideoTransformationErrorEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
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
        var model = new VideoTransformationErrorEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Error = new(Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
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

        VideoTransformationErrorEventIntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationErrorEventIntersectionMember1DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1Data
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
            },
        };

        VideoTransformationErrorEventIntersectionMember1DataAsset expectedAsset = new(
            "https://example.com"
        );
        VideoTransformationErrorEventIntersectionMember1DataTransformation expectedTransformation =
            new()
            {
                Type =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
            };

        Assert.Equal(expectedAsset, model.Asset);
        Assert.Equal(expectedTransformation, model.Transformation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1Data
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventIntersectionMember1Data>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1Data
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventIntersectionMember1Data>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        VideoTransformationErrorEventIntersectionMember1DataAsset expectedAsset = new(
            "https://example.com"
        );
        VideoTransformationErrorEventIntersectionMember1DataTransformation expectedTransformation =
            new()
            {
                Type =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
            };

        Assert.Equal(expectedAsset, deserialized.Asset);
        Assert.Equal(expectedTransformation, deserialized.Transformation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1Data
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1Data
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                Error = new(Reason.EncodingFailed),
                Options = new()
                {
                    AudioCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                    AutoRotate = true,
                    Format =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                    Quality = 0,
                    StreamProtocol =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec =
                        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                },
            },
        };

        VideoTransformationErrorEventIntersectionMember1Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationErrorEventIntersectionMember1DataAssetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataAsset
        {
            Url = "https://example.com",
        };

        string expectedUrl = "https://example.com";

        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataAsset
        {
            Url = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventIntersectionMember1DataAsset>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataAsset
        {
            Url = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventIntersectionMember1DataAsset>(
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
        var model = new VideoTransformationErrorEventIntersectionMember1DataAsset
        {
            Url = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataAsset
        {
            Url = "https://example.com",
        };

        VideoTransformationErrorEventIntersectionMember1DataAsset copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationErrorEventIntersectionMember1DataTransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformation
        {
            Type =
                VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
            Error = new(Reason.EncodingFailed),
            Options = new()
            {
                AudioCodec =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
            },
        };

        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationType
        > expectedType =
            VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation;
        VideoTransformationErrorEventIntersectionMember1DataTransformationError expectedError = new(
            Reason.EncodingFailed
        );
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptions expectedOptions =
            new()
            {
                AudioCodec =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
            };

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedOptions, model.Options);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformation
        {
            Type =
                VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
            Error = new(Reason.EncodingFailed),
            Options = new()
            {
                AudioCodec =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventIntersectionMember1DataTransformation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformation
        {
            Type =
                VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
            Error = new(Reason.EncodingFailed),
            Options = new()
            {
                AudioCodec =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventIntersectionMember1DataTransformation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationType
        > expectedType =
            VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation;
        VideoTransformationErrorEventIntersectionMember1DataTransformationError expectedError = new(
            Reason.EncodingFailed
        );
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptions expectedOptions =
            new()
            {
                AudioCodec =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
            };

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedOptions, deserialized.Options);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformation
        {
            Type =
                VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
            Error = new(Reason.EncodingFailed),
            Options = new()
            {
                AudioCodec =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformation
        {
            Type =
                VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformation
        {
            Type =
                VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformation
        {
            Type =
                VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,

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
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformation
        {
            Type =
                VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,

            // Null should be interpreted as omitted for these properties
            Error = null,
            Options = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformation
        {
            Type =
                VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
            Error = new(Reason.EncodingFailed),
            Options = new()
            {
                AudioCodec =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                AutoRotate = true,
                Format =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                Quality = 0,
                StreamProtocol =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                Variants = ["string"],
                VideoCodec =
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
            },
        };

        VideoTransformationErrorEventIntersectionMember1DataTransformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationErrorEventIntersectionMember1DataTransformationTypeTest : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation
    )]
    [InlineData(VideoTransformationErrorEventIntersectionMember1DataTransformationType.GifToVideo)]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoThumbnail
    )]
    public void Validation_Works(
        VideoTransformationErrorEventIntersectionMember1DataTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationType
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, VideoTransformationErrorEventIntersectionMember1DataTransformationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation
    )]
    [InlineData(VideoTransformationErrorEventIntersectionMember1DataTransformationType.GifToVideo)]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoThumbnail
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationErrorEventIntersectionMember1DataTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationType
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VideoTransformationErrorEventIntersectionMember1DataTransformationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, VideoTransformationErrorEventIntersectionMember1DataTransformationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VideoTransformationErrorEventIntersectionMember1DataTransformationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationErrorEventIntersectionMember1DataTransformationErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformationError
        {
            Reason = Reason.EncodingFailed,
        };

        ApiEnum<string, Reason> expectedReason = Reason.EncodingFailed;

        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformationError
        {
            Reason = Reason.EncodingFailed,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventIntersectionMember1DataTransformationError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformationError
        {
            Reason = Reason.EncodingFailed,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventIntersectionMember1DataTransformationError>(
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
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformationError
        {
            Reason = Reason.EncodingFailed,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformationError
        {
            Reason = Reason.EncodingFailed,
        };

        VideoTransformationErrorEventIntersectionMember1DataTransformationError copied = new(model);

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

public class VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformationOptions
        {
            AudioCodec =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
            AutoRotate = true,
            Format =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
            Quality = 0,
            StreamProtocol =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
            Variants = ["string"],
            VideoCodec =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
        };

        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec
        > expectedAudioCodec =
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac;
        bool expectedAutoRotate = true;
        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat
        > expectedFormat =
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4;
        long expectedQuality = 0;
        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol
        > expectedStreamProtocol =
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls;
        List<string> expectedVariants = ["string"];
        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec
        > expectedVideoCodec =
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264;

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
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformationOptions
        {
            AudioCodec =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
            AutoRotate = true,
            Format =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
            Quality = 0,
            StreamProtocol =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
            Variants = ["string"],
            VideoCodec =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventIntersectionMember1DataTransformationOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformationOptions
        {
            AudioCodec =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
            AutoRotate = true,
            Format =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
            Quality = 0,
            StreamProtocol =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
            Variants = ["string"],
            VideoCodec =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventIntersectionMember1DataTransformationOptions>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec
        > expectedAudioCodec =
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac;
        bool expectedAutoRotate = true;
        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat
        > expectedFormat =
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4;
        long expectedQuality = 0;
        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol
        > expectedStreamProtocol =
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls;
        List<string> expectedVariants = ["string"];
        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec
        > expectedVideoCodec =
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264;

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
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformationOptions
        {
            AudioCodec =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
            AutoRotate = true,
            Format =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
            Quality = 0,
            StreamProtocol =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
            Variants = ["string"],
            VideoCodec =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformationOptions
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
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformationOptions
        { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformationOptions
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
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformationOptions
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
        var model = new VideoTransformationErrorEventIntersectionMember1DataTransformationOptions
        {
            AudioCodec =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
            AutoRotate = true,
            Format =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
            Quality = 0,
            StreamProtocol =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
            Variants = ["string"],
            VideoCodec =
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
        };

        VideoTransformationErrorEventIntersectionMember1DataTransformationOptions copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodecTest
    : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac
    )]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Opus
    )]
    public void Validation_Works(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac
    )]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Opus
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec
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
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormatTest
    : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4
    )]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Webm
    )]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Jpg
    )]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Png
    )]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Webp
    )]
    public void Validation_Works(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4
    )]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Webm
    )]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Jpg
    )]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Png
    )]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Webp
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat
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
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocolTest
    : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls
    )]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Dash
    )]
    public void Validation_Works(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls
    )]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Dash
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol
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
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodecTest
    : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264
    )]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.Vp9
    )]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.Av1
    )]
    public void Validation_Works(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264
    )]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.Vp9
    )]
    [InlineData(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.Av1
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec
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
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationErrorEventIntersectionMember1RequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1Request
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
        var model = new VideoTransformationErrorEventIntersectionMember1Request
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventIntersectionMember1Request>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1Request
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationErrorEventIntersectionMember1Request>(
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
        var model = new VideoTransformationErrorEventIntersectionMember1Request
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
        var model = new VideoTransformationErrorEventIntersectionMember1Request
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
        var model = new VideoTransformationErrorEventIntersectionMember1Request
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VideoTransformationErrorEventIntersectionMember1Request
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
        var model = new VideoTransformationErrorEventIntersectionMember1Request
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
        var model = new VideoTransformationErrorEventIntersectionMember1Request
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        VideoTransformationErrorEventIntersectionMember1Request copied = new(model);

        Assert.Equal(model, copied);
    }
}
