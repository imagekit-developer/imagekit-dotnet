using System;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.Webhooks;

namespace Imagekit.Tests.Models.Webhooks;

public class ImageAsyncTransformationReadyEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageAsyncTransformationReadyEvent
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
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { ProcessingDuration = 0, QueueDuration = 0 },
        };

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData expectedData =
            new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
                    },
                },
            };
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest expectedRequest =
            new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            };
        Timings expectedTimings = new() { ProcessingDuration = 0, QueueDuration = 0 };

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
        var model = new ImageAsyncTransformationReadyEvent
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
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { ProcessingDuration = 0, QueueDuration = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageAsyncTransformationReadyEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageAsyncTransformationReadyEvent
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
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { ProcessingDuration = 0, QueueDuration = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageAsyncTransformationReadyEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData expectedData =
            new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
                    },
                },
            };
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest expectedRequest =
            new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            };
        Timings expectedTimings = new() { ProcessingDuration = 0, QueueDuration = 0 };

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
        var model = new ImageAsyncTransformationReadyEvent
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
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { ProcessingDuration = 0, QueueDuration = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ImageAsyncTransformationReadyEvent
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
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
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
        var model = new ImageAsyncTransformationReadyEvent
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
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
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
        var model = new ImageAsyncTransformationReadyEvent
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
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
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
        var model = new ImageAsyncTransformationReadyEvent
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
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
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
        var model = new ImageAsyncTransformationReadyEvent
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
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { ProcessingDuration = 0, QueueDuration = 0 },
        };

        ImageAsyncTransformationReadyEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { ProcessingDuration = 0, QueueDuration = 0 },
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData expectedData =
            new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
                    },
                },
            };
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest expectedRequest =
            new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            };
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "image.async-transformation.ready"
        );
        Timings expectedTimings = new() { ProcessingDuration = 0, QueueDuration = 0 };

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedRequest, model.Request);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedTimings, model.Timings);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { ProcessingDuration = 0, QueueDuration = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { ProcessingDuration = 0, QueueDuration = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData expectedData =
            new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
                    },
                },
            };
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest expectedRequest =
            new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            };
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "image.async-transformation.ready"
        );
        Timings expectedTimings = new() { ProcessingDuration = 0, QueueDuration = 0 };

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedRequest, deserialized.Request);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedTimings, deserialized.Timings);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { ProcessingDuration = 0, QueueDuration = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
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
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
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
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
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
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
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
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                    Output = new()
                    {
                        Url = "https://example.com",
                        ImageMetadata = new() { Size = 0, Format = "format" },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { ProcessingDuration = 0, QueueDuration = 0 },
        };

        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                Options = new() { Transformation = "transformation" },
                Output = new()
                {
                    Url = "https://example.com",
                    ImageMetadata = new() { Size = 0, Format = "format" },
                },
            },
        };

        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset expectedAsset =
            new("https://example.com");
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation expectedTransformation =
            new()
            {
                Type =
                    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                Options = new() { Transformation = "transformation" },
                Output = new()
                {
                    Url = "https://example.com",
                    ImageMetadata = new() { Size = 0, Format = "format" },
                },
            };

        Assert.Equal(expectedAsset, model.Asset);
        Assert.Equal(expectedTransformation, model.Transformation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                Options = new() { Transformation = "transformation" },
                Output = new()
                {
                    Url = "https://example.com",
                    ImageMetadata = new() { Size = 0, Format = "format" },
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                Options = new() { Transformation = "transformation" },
                Output = new()
                {
                    Url = "https://example.com",
                    ImageMetadata = new() { Size = 0, Format = "format" },
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset expectedAsset =
            new("https://example.com");
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation expectedTransformation =
            new()
            {
                Type =
                    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                Options = new() { Transformation = "transformation" },
                Output = new()
                {
                    Url = "https://example.com",
                    ImageMetadata = new() { Size = 0, Format = "format" },
                },
            };

        Assert.Equal(expectedAsset, deserialized.Asset);
        Assert.Equal(expectedTransformation, deserialized.Transformation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                Options = new() { Transformation = "transformation" },
                Output = new()
                {
                    Url = "https://example.com",
                    ImageMetadata = new() { Size = 0, Format = "format" },
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData
        {
            Asset = new("https://example.com"),
            Transformation = new()
            {
                Type =
                    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                Options = new() { Transformation = "transformation" },
                Output = new()
                {
                    Url = "https://example.com",
                    ImageMetadata = new() { Size = 0, Format = "format" },
                },
            },
        };

        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAssetTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset
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
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset
            {
                Url = "https://example.com",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset
            {
                Url = "https://example.com",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset>(
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
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset
            {
                Url = "https://example.com",
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset
            {
                Url = "https://example.com",
            };

        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation
            {
                Type =
                    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                Options = new() { Transformation = "transformation" },
                Output = new()
                {
                    Url = "https://example.com",
                    ImageMetadata = new() { Size = 0, Format = "format" },
                },
            };

        ApiEnum<
            string,
            ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType
        > expectedType =
            ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation;
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions expectedOptions =
            new() { Transformation = "transformation" };
        Output expectedOutput = new()
        {
            Url = "https://example.com",
            ImageMetadata = new() { Size = 0, Format = "format" },
        };

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedOptions, model.Options);
        Assert.Equal(expectedOutput, model.Output);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation
            {
                Type =
                    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                Options = new() { Transformation = "transformation" },
                Output = new()
                {
                    Url = "https://example.com",
                    ImageMetadata = new() { Size = 0, Format = "format" },
                },
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation
            {
                Type =
                    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                Options = new() { Transformation = "transformation" },
                Output = new()
                {
                    Url = "https://example.com",
                    ImageMetadata = new() { Size = 0, Format = "format" },
                },
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType
        > expectedType =
            ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation;
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions expectedOptions =
            new() { Transformation = "transformation" };
        Output expectedOutput = new()
        {
            Url = "https://example.com",
            ImageMetadata = new() { Size = 0, Format = "format" },
        };

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedOptions, deserialized.Options);
        Assert.Equal(expectedOutput, deserialized.Output);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation
            {
                Type =
                    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                Options = new() { Transformation = "transformation" },
                Output = new()
                {
                    Url = "https://example.com",
                    ImageMetadata = new() { Size = 0, Format = "format" },
                },
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation
            {
                Type =
                    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
            };

        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation
            {
                Type =
                    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation
            {
                Type =
                    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,

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
        var model =
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation
            {
                Type =
                    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,

                // Null should be interpreted as omitted for these properties
                Options = null,
                Output = null,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation
            {
                Type =
                    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
                Options = new() { Transformation = "transformation" },
                Output = new()
                {
                    Url = "https://example.com",
                    ImageMetadata = new() { Size = 0, Format = "format" },
                },
            };

        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationTypeTest
    : TestBase
{
    [Theory]
    [InlineData(
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation
    )]
    public void Validation_Works(
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation
    )]
    public void SerializationRoundtrip_Works(
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType
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
                ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptionsTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions
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
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions
            {
                Transformation = "transformation",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions
            {
                Transformation = "transformation",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions>(
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
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions
            {
                Transformation = "transformation",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions
            { };

        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions
            { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions
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
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions
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
            new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions
            {
                Transformation = "transformation",
            };

        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions copied =
            new(model);

        Assert.Equal(model, copied);
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
            ImageMetadata = new() { Size = 0, Format = "format" },
        };

        string expectedUrl = "https://example.com";
        ImageMetadata expectedImageMetadata = new() { Size = 0, Format = "format" };

        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedImageMetadata, model.ImageMetadata);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Output
        {
            Url = "https://example.com",
            ImageMetadata = new() { Size = 0, Format = "format" },
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
            ImageMetadata = new() { Size = 0, Format = "format" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Output>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedUrl = "https://example.com";
        ImageMetadata expectedImageMetadata = new() { Size = 0, Format = "format" };

        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedImageMetadata, deserialized.ImageMetadata);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Output
        {
            Url = "https://example.com",
            ImageMetadata = new() { Size = 0, Format = "format" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Output { Url = "https://example.com" };

        Assert.Null(model.ImageMetadata);
        Assert.False(model.RawData.ContainsKey("image_metadata"));
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
            ImageMetadata = null,
        };

        Assert.Null(model.ImageMetadata);
        Assert.False(model.RawData.ContainsKey("image_metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Output
        {
            Url = "https://example.com",

            // Null should be interpreted as omitted for these properties
            ImageMetadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Output
        {
            Url = "https://example.com",
            ImageMetadata = new() { Size = 0, Format = "format" },
        };

        Output copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageMetadata { Size = 0, Format = "format" };

        long expectedSize = 0;
        string expectedFormat = "format";

        Assert.Equal(expectedSize, model.Size);
        Assert.Equal(expectedFormat, model.Format);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImageMetadata { Size = 0, Format = "format" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageMetadata { Size = 0, Format = "format" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedSize = 0;
        string expectedFormat = "format";

        Assert.Equal(expectedSize, deserialized.Size);
        Assert.Equal(expectedFormat, deserialized.Format);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImageMetadata { Size = 0, Format = "format" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ImageMetadata { Size = 0 };

        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ImageMetadata { Size = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ImageMetadata
        {
            Size = 0,

            // Null should be interpreted as omitted for these properties
            Format = null,
        };

        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ImageMetadata
        {
            Size = 0,

            // Null should be interpreted as omitted for these properties
            Format = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ImageMetadata { Size = 0, Format = "format" };

        ImageMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequestTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest
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
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest>(
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
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest
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
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest
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
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest
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
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest
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
        var model = new ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class TimingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Timings { ProcessingDuration = 0, QueueDuration = 0 };

        long expectedProcessingDuration = 0;
        long expectedQueueDuration = 0;

        Assert.Equal(expectedProcessingDuration, model.ProcessingDuration);
        Assert.Equal(expectedQueueDuration, model.QueueDuration);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Timings { ProcessingDuration = 0, QueueDuration = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Timings>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Timings { ProcessingDuration = 0, QueueDuration = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Timings>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedProcessingDuration = 0;
        long expectedQueueDuration = 0;

        Assert.Equal(expectedProcessingDuration, deserialized.ProcessingDuration);
        Assert.Equal(expectedQueueDuration, deserialized.QueueDuration);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Timings { ProcessingDuration = 0, QueueDuration = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Timings { };

        Assert.Null(model.ProcessingDuration);
        Assert.False(model.RawData.ContainsKey("processing_duration"));
        Assert.Null(model.QueueDuration);
        Assert.False(model.RawData.ContainsKey("queue_duration"));
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
            ProcessingDuration = null,
            QueueDuration = null,
        };

        Assert.Null(model.ProcessingDuration);
        Assert.False(model.RawData.ContainsKey("processing_duration"));
        Assert.Null(model.QueueDuration);
        Assert.False(model.RawData.ContainsKey("queue_duration"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Timings
        {
            // Null should be interpreted as omitted for these properties
            ProcessingDuration = null,
            QueueDuration = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Timings { ProcessingDuration = 0, QueueDuration = 0 };

        Timings copied = new(model);

        Assert.Equal(model, copied);
    }
}
