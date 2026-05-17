using System;
using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.Webhooks;

namespace Imagekit.Tests.Models.Webhooks;

public class VideoTransformationAcceptedEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationAcceptedEvent
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
                        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec = AudioCodec.Aac,
                        AutoRotate = true,
                        Format = Format.Mp4,
                        Quality = 0,
                        StreamProtocol = StreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec = VideoCodec.H264,
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
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventData expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec = AudioCodec.Aac,
                    AutoRotate = true,
                    Format = Format.Mp4,
                    Quality = 0,
                    StreamProtocol = StreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec = VideoCodec.H264,
                },
            },
        };
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest expectedRequest =
            new()
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
        var model = new VideoTransformationAcceptedEvent
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
                        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec = AudioCodec.Aac,
                        AutoRotate = true,
                        Format = Format.Mp4,
                        Quality = 0,
                        StreamProtocol = StreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec = VideoCodec.H264,
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
        var deserialized = JsonSerializer.Deserialize<VideoTransformationAcceptedEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationAcceptedEvent
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
                        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec = AudioCodec.Aac,
                        AutoRotate = true,
                        Format = Format.Mp4,
                        Quality = 0,
                        StreamProtocol = StreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec = VideoCodec.H264,
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
        var deserialized = JsonSerializer.Deserialize<VideoTransformationAcceptedEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventData expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec = AudioCodec.Aac,
                    AutoRotate = true,
                    Format = Format.Mp4,
                    Quality = 0,
                    StreamProtocol = StreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec = VideoCodec.H264,
                },
            },
        };
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest expectedRequest =
            new()
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
        var model = new VideoTransformationAcceptedEvent
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
                        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec = AudioCodec.Aac,
                        AutoRotate = true,
                        Format = Format.Mp4,
                        Quality = 0,
                        StreamProtocol = StreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec = VideoCodec.H264,
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
        var model = new VideoTransformationAcceptedEvent
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
                        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec = AudioCodec.Aac,
                        AutoRotate = true,
                        Format = Format.Mp4,
                        Quality = 0,
                        StreamProtocol = StreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec = VideoCodec.H264,
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

        VideoTransformationAcceptedEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationAcceptedEventVideoTransformationAcceptedEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationAcceptedEventVideoTransformationAcceptedEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec = AudioCodec.Aac,
                        AutoRotate = true,
                        Format = Format.Mp4,
                        Quality = 0,
                        StreamProtocol = StreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec = VideoCodec.H264,
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
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventData expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec = AudioCodec.Aac,
                    AutoRotate = true,
                    Format = Format.Mp4,
                    Quality = 0,
                    StreamProtocol = StreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec = VideoCodec.H264,
                },
            },
        };
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest expectedRequest =
            new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            };
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "video.transformation.accepted"
        );

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedRequest, model.Request);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoTransformationAcceptedEventVideoTransformationAcceptedEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec = AudioCodec.Aac,
                        AutoRotate = true,
                        Format = Format.Mp4,
                        Quality = 0,
                        StreamProtocol = StreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec = VideoCodec.H264,
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
            JsonSerializer.Deserialize<VideoTransformationAcceptedEventVideoTransformationAcceptedEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationAcceptedEventVideoTransformationAcceptedEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec = AudioCodec.Aac,
                        AutoRotate = true,
                        Format = Format.Mp4,
                        Quality = 0,
                        StreamProtocol = StreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec = VideoCodec.H264,
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
            JsonSerializer.Deserialize<VideoTransformationAcceptedEventVideoTransformationAcceptedEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventData expectedData = new()
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec = AudioCodec.Aac,
                    AutoRotate = true,
                    Format = Format.Mp4,
                    Quality = 0,
                    StreamProtocol = StreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec = VideoCodec.H264,
                },
            },
        };
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest expectedRequest =
            new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            };
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "video.transformation.accepted"
        );

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedRequest, deserialized.Request);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VideoTransformationAcceptedEventVideoTransformationAcceptedEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec = AudioCodec.Aac,
                        AutoRotate = true,
                        Format = Format.Mp4,
                        Quality = 0,
                        StreamProtocol = StreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec = VideoCodec.H264,
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
        var model = new VideoTransformationAcceptedEventVideoTransformationAcceptedEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec = AudioCodec.Aac,
                        AutoRotate = true,
                        Format = Format.Mp4,
                        Quality = 0,
                        StreamProtocol = StreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec = VideoCodec.H264,
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

        VideoTransformationAcceptedEventVideoTransformationAcceptedEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationAcceptedEventVideoTransformationAcceptedEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec = AudioCodec.Aac,
                    AutoRotate = true,
                    Format = Format.Mp4,
                    Quality = 0,
                    StreamProtocol = StreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec = VideoCodec.H264,
                },
            },
        };

        Asset expectedAsset = new("https://example.com");
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation expectedTransformation =
            new()
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec = AudioCodec.Aac,
                    AutoRotate = true,
                    Format = Format.Mp4,
                    Quality = 0,
                    StreamProtocol = StreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec = VideoCodec.H264,
                },
            };

        Assert.Equal(expectedAsset, model.Asset);
        Assert.Equal(expectedTransformation, model.Transformation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoTransformationAcceptedEventVideoTransformationAcceptedEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec = AudioCodec.Aac,
                    AutoRotate = true,
                    Format = Format.Mp4,
                    Quality = 0,
                    StreamProtocol = StreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec = VideoCodec.H264,
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationAcceptedEventVideoTransformationAcceptedEventData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationAcceptedEventVideoTransformationAcceptedEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec = AudioCodec.Aac,
                    AutoRotate = true,
                    Format = Format.Mp4,
                    Quality = 0,
                    StreamProtocol = StreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec = VideoCodec.H264,
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationAcceptedEventVideoTransformationAcceptedEventData>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        Asset expectedAsset = new("https://example.com");
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation expectedTransformation =
            new()
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec = AudioCodec.Aac,
                    AutoRotate = true,
                    Format = Format.Mp4,
                    Quality = 0,
                    StreamProtocol = StreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec = VideoCodec.H264,
                },
            };

        Assert.Equal(expectedAsset, deserialized.Asset);
        Assert.Equal(expectedTransformation, deserialized.Transformation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VideoTransformationAcceptedEventVideoTransformationAcceptedEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec = AudioCodec.Aac,
                    AutoRotate = true,
                    Format = Format.Mp4,
                    Quality = 0,
                    StreamProtocol = StreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec = VideoCodec.H264,
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoTransformationAcceptedEventVideoTransformationAcceptedEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec = AudioCodec.Aac,
                    AutoRotate = true,
                    Format = Format.Mp4,
                    Quality = 0,
                    StreamProtocol = StreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec = VideoCodec.H264,
                },
            },
        };

        VideoTransformationAcceptedEventVideoTransformationAcceptedEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AssetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Asset { Url = "https://example.com" };

        string expectedUrl = "https://example.com";

        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Asset { Url = "https://example.com" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Asset>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Asset { Url = "https://example.com" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Asset>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedUrl = "https://example.com";

        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Asset { Url = "https://example.com" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Asset { Url = "https://example.com" };

        Asset copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec = AudioCodec.Aac,
                    AutoRotate = true,
                    Format = Format.Mp4,
                    Quality = 0,
                    StreamProtocol = StreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec = VideoCodec.H264,
                },
            };

        ApiEnum<
            string,
            VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType
        > expectedType =
            VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation;
        Options expectedOptions = new()
        {
            AudioCodec = AudioCodec.Aac,
            AutoRotate = true,
            Format = Format.Mp4,
            Quality = 0,
            StreamProtocol = StreamProtocol.Hls,
            Variants = ["string"],
            VideoCodec = VideoCodec.H264,
        };

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedOptions, model.Options);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec = AudioCodec.Aac,
                    AutoRotate = true,
                    Format = Format.Mp4,
                    Quality = 0,
                    StreamProtocol = StreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec = VideoCodec.H264,
                },
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec = AudioCodec.Aac,
                    AutoRotate = true,
                    Format = Format.Mp4,
                    Quality = 0,
                    StreamProtocol = StreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec = VideoCodec.H264,
                },
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType
        > expectedType =
            VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation;
        Options expectedOptions = new()
        {
            AudioCodec = AudioCodec.Aac,
            AutoRotate = true,
            Format = Format.Mp4,
            Quality = 0,
            StreamProtocol = StreamProtocol.Hls,
            Variants = ["string"],
            VideoCodec = VideoCodec.H264,
        };

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedOptions, deserialized.Options);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec = AudioCodec.Aac,
                    AutoRotate = true,
                    Format = Format.Mp4,
                    Quality = 0,
                    StreamProtocol = StreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec = VideoCodec.H264,
                },
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
            };

        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,

                // Null should be interpreted as omitted for these properties
                Options = null,
            };

        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model =
            new VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,

                // Null should be interpreted as omitted for these properties
                Options = null,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation
            {
                Type =
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
                Options = new()
                {
                    AudioCodec = AudioCodec.Aac,
                    AutoRotate = true,
                    Format = Format.Mp4,
                    Quality = 0,
                    StreamProtocol = StreamProtocol.Hls,
                    Variants = ["string"],
                    VideoCodec = VideoCodec.H264,
                },
            };

        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationTypeTest
    : TestBase
{
    [Theory]
    [InlineData(
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation
    )]
    [InlineData(
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.GifToVideo
    )]
    [InlineData(
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoThumbnail
    )]
    public void Validation_Works(
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation
    )]
    [InlineData(
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.GifToVideo
    )]
    [InlineData(
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoThumbnail
    )]
    public void SerializationRoundtrip_Works(
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType
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
                VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Options
        {
            AudioCodec = AudioCodec.Aac,
            AutoRotate = true,
            Format = Format.Mp4,
            Quality = 0,
            StreamProtocol = StreamProtocol.Hls,
            Variants = ["string"],
            VideoCodec = VideoCodec.H264,
        };

        ApiEnum<string, AudioCodec> expectedAudioCodec = AudioCodec.Aac;
        bool expectedAutoRotate = true;
        ApiEnum<string, Format> expectedFormat = Format.Mp4;
        long expectedQuality = 0;
        ApiEnum<string, StreamProtocol> expectedStreamProtocol = StreamProtocol.Hls;
        List<string> expectedVariants = ["string"];
        ApiEnum<string, VideoCodec> expectedVideoCodec = VideoCodec.H264;

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
        var model = new Options
        {
            AudioCodec = AudioCodec.Aac,
            AutoRotate = true,
            Format = Format.Mp4,
            Quality = 0,
            StreamProtocol = StreamProtocol.Hls,
            Variants = ["string"],
            VideoCodec = VideoCodec.H264,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Options>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Options
        {
            AudioCodec = AudioCodec.Aac,
            AutoRotate = true,
            Format = Format.Mp4,
            Quality = 0,
            StreamProtocol = StreamProtocol.Hls,
            Variants = ["string"],
            VideoCodec = VideoCodec.H264,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Options>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AudioCodec> expectedAudioCodec = AudioCodec.Aac;
        bool expectedAutoRotate = true;
        ApiEnum<string, Format> expectedFormat = Format.Mp4;
        long expectedQuality = 0;
        ApiEnum<string, StreamProtocol> expectedStreamProtocol = StreamProtocol.Hls;
        List<string> expectedVariants = ["string"];
        ApiEnum<string, VideoCodec> expectedVideoCodec = VideoCodec.H264;

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
        var model = new Options
        {
            AudioCodec = AudioCodec.Aac,
            AutoRotate = true,
            Format = Format.Mp4,
            Quality = 0,
            StreamProtocol = StreamProtocol.Hls,
            Variants = ["string"],
            VideoCodec = VideoCodec.H264,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Options { };

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
        var model = new Options { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Options
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
        var model = new Options
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
        var model = new Options
        {
            AudioCodec = AudioCodec.Aac,
            AutoRotate = true,
            Format = Format.Mp4,
            Quality = 0,
            StreamProtocol = StreamProtocol.Hls,
            Variants = ["string"],
            VideoCodec = VideoCodec.H264,
        };

        Options copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AudioCodecTest : TestBase
{
    [Theory]
    [InlineData(AudioCodec.Aac)]
    [InlineData(AudioCodec.Opus)]
    public void Validation_Works(AudioCodec rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AudioCodec> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AudioCodec>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AudioCodec.Aac)]
    [InlineData(AudioCodec.Opus)]
    public void SerializationRoundtrip_Works(AudioCodec rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AudioCodec> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AudioCodec>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AudioCodec>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AudioCodec>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FormatTest : TestBase
{
    [Theory]
    [InlineData(Format.Mp4)]
    [InlineData(Format.Webm)]
    [InlineData(Format.Jpg)]
    [InlineData(Format.Png)]
    [InlineData(Format.Webp)]
    public void Validation_Works(Format rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Format> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Format.Mp4)]
    [InlineData(Format.Webm)]
    [InlineData(Format.Jpg)]
    [InlineData(Format.Png)]
    [InlineData(Format.Webp)]
    public void SerializationRoundtrip_Works(Format rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Format> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StreamProtocolTest : TestBase
{
    [Theory]
    [InlineData(StreamProtocol.Hls)]
    [InlineData(StreamProtocol.Dash)]
    public void Validation_Works(StreamProtocol rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StreamProtocol> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StreamProtocol>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StreamProtocol.Hls)]
    [InlineData(StreamProtocol.Dash)]
    public void SerializationRoundtrip_Works(StreamProtocol rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StreamProtocol> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StreamProtocol>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StreamProtocol>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StreamProtocol>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VideoCodecTest : TestBase
{
    [Theory]
    [InlineData(VideoCodec.H264)]
    [InlineData(VideoCodec.Vp9)]
    [InlineData(VideoCodec.Av1)]
    public void Validation_Works(VideoCodec rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VideoCodec> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VideoCodec>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VideoCodec.H264)]
    [InlineData(VideoCodec.Vp9)]
    [InlineData(VideoCodec.Av1)]
    public void SerializationRoundtrip_Works(VideoCodec rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VideoCodec> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VideoCodec>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VideoCodec>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VideoCodec>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest
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
        var model = new VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest>(
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
        var model = new VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest
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
        var model = new VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest
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
        var model = new VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest
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
        var model = new VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest
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
        var model = new VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
