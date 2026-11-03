using System;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.Webhooks;

namespace Imagekit.Tests.Models.Webhooks;

public class ImageAsyncTransformationErrorEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageAsyncTransformationErrorEvent
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
                        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                    Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                    Options = new() { Transformation = "transformation" },
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
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData expectedData =
            new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                    Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                    Options = new() { Transformation = "transformation" },
                },
            };
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest expectedRequest =
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
        var model = new ImageAsyncTransformationErrorEvent
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
                        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                    Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                    Options = new() { Transformation = "transformation" },
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
        var deserialized = JsonSerializer.Deserialize<ImageAsyncTransformationErrorEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageAsyncTransformationErrorEvent
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
                        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                    Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                    Options = new() { Transformation = "transformation" },
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
        var deserialized = JsonSerializer.Deserialize<ImageAsyncTransformationErrorEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData expectedData =
            new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                    Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                    Options = new() { Transformation = "transformation" },
                },
            };
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest expectedRequest =
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
        var model = new ImageAsyncTransformationErrorEvent
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
                        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                    Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                    Options = new() { Transformation = "transformation" },
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
        var model = new ImageAsyncTransformationErrorEvent
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
                        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                    Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                    Options = new() { Transformation = "transformation" },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
        };

        ImageAsyncTransformationErrorEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                    Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                    Options = new() { Transformation = "transformation" },
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
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData expectedData =
            new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                    Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                    Options = new() { Transformation = "transformation" },
                },
            };
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest expectedRequest =
            new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            };
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "image.async-transformation.error"
        );

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedRequest, model.Request);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                    Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                    Options = new() { Transformation = "transformation" },
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
            JsonSerializer.Deserialize<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                    Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                    Options = new() { Transformation = "transformation" },
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
            JsonSerializer.Deserialize<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData expectedData =
            new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                    Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                    Options = new() { Transformation = "transformation" },
                },
            };
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest expectedRequest =
            new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            };
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "image.async-transformation.error"
        );

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedRequest, deserialized.Request);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                    Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                    Options = new() { Transformation = "transformation" },
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
        var model = new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                    Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                    Options = new() { Transformation = "transformation" },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
        };

        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                Options = new() { Transformation = "transformation" },
            },
        };

        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset expectedAsset =
            new("https://example.com");
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation expectedTransformation =
            new()
            {
                Type =
                    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                Options = new() { Transformation = "transformation" },
            };

        Assert.Equal(expectedAsset, model.Asset);
        Assert.Equal(expectedTransformation, model.Transformation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                Options = new() { Transformation = "transformation" },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                Options = new() { Transformation = "transformation" },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset expectedAsset =
            new("https://example.com");
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation expectedTransformation =
            new()
            {
                Type =
                    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                Options = new() { Transformation = "transformation" },
            };

        Assert.Equal(expectedAsset, deserialized.Asset);
        Assert.Equal(expectedTransformation, deserialized.Transformation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                Options = new() { Transformation = "transformation" },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                Options = new() { Transformation = "transformation" },
            },
        };

        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAssetTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset
            {
                Url = "https://example.com",
            };

        string expectedUrl = "https://example.com";

        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset
            {
                Url = "https://example.com",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset
            {
                Url = "https://example.com",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset>(
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
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset
            {
                Url = "https://example.com",
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset
            {
                Url = "https://example.com",
            };

        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation
            {
                Type =
                    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                Options = new() { Transformation = "transformation" },
            };

        ApiEnum<
            string,
            ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType
        > expectedType =
            ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation;
        Error expectedError = new() { Reason = Reason.DownloadFailed, Message = "message" };
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions expectedOptions =
            new() { Transformation = "transformation" };

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedOptions, model.Options);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation
            {
                Type =
                    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                Options = new() { Transformation = "transformation" },
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation
            {
                Type =
                    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                Options = new() { Transformation = "transformation" },
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType
        > expectedType =
            ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation;
        Error expectedError = new() { Reason = Reason.DownloadFailed, Message = "message" };
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions expectedOptions =
            new() { Transformation = "transformation" };

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedOptions, deserialized.Options);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation
            {
                Type =
                    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                Options = new() { Transformation = "transformation" },
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation
            {
                Type =
                    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
            };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation
            {
                Type =
                    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation
            {
                Type =
                    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,

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
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation
            {
                Type =
                    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,

                // Null should be interpreted as omitted for these properties
                Error = null,
                Options = null,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation
            {
                Type =
                    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
                Error = new() { Reason = Reason.DownloadFailed, Message = "message" },
                Options = new() { Transformation = "transformation" },
            };

        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationTypeTest
    : TestBase
{
    [Theory]
    [InlineData(
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation
    )]
    public void Validation_Works(
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation
    )]
    public void SerializationRoundtrip_Works(
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType
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
                ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Error { Reason = Reason.DownloadFailed, Message = "message" };

        ApiEnum<string, Reason> expectedReason = Reason.DownloadFailed;
        string expectedMessage = "message";

        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Error { Reason = Reason.DownloadFailed, Message = "message" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Error { Reason = Reason.DownloadFailed, Message = "message" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, Reason> expectedReason = Reason.DownloadFailed;
        string expectedMessage = "message";

        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Error { Reason = Reason.DownloadFailed, Message = "message" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Error { Reason = Reason.DownloadFailed };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Error { Reason = Reason.DownloadFailed };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Error
        {
            Reason = Reason.DownloadFailed,

            // Null should be interpreted as omitted for these properties
            Message = null,
        };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Error
        {
            Reason = Reason.DownloadFailed,

            // Null should be interpreted as omitted for these properties
            Message = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Error { Reason = Reason.DownloadFailed, Message = "message" };

        Error copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(Reason.DownloadFailed)]
    [InlineData(Reason.InvalidTransformation)]
    [InlineData(Reason.LimitExceeded)]
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
    [InlineData(Reason.DownloadFailed)]
    [InlineData(Reason.InvalidTransformation)]
    [InlineData(Reason.LimitExceeded)]
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

public class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptionsTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions
            {
                Transformation = "transformation",
            };

        string expectedTransformation = "transformation";

        Assert.Equal(expectedTransformation, model.Transformation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions
            {
                Transformation = "transformation",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions
            {
                Transformation = "transformation",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedTransformation = "transformation";

        Assert.Equal(expectedTransformation, deserialized.Transformation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions
            {
                Transformation = "transformation",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions
            { };

        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions
            { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions
            {
                // Null should be interpreted as omitted for these properties
                Transformation = null,
            };

        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions
            {
                // Null should be interpreted as omitted for these properties
                Transformation = null,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions
            {
                Transformation = "transformation",
            };

        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequestTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest
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
        var model = new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest>(
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
        var model = new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest
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
        var model = new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest
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
        var model = new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest
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
        var model = new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest
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
        var model = new ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}
