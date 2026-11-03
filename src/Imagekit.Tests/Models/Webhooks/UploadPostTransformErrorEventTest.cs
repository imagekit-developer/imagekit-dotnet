using System;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.Webhooks;

namespace Imagekit.Tests.Models.Webhooks;

public class UploadPostTransformErrorEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadPostTransformErrorEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                        "encoding_failed"
                    )
                ),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                    Protocol = Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        UploadPostTransformErrorEventUploadPostTransformErrorEventData expectedData = new()
        {
            FileID = "fileId",
            Name = "name",
            Path = "path",
            Transformation = new(
                new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                    "encoding_failed"
                )
            ),
            Url = "https://example.com",
        };
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequest expectedRequest = new()
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                Protocol = Protocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
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
        var model = new UploadPostTransformErrorEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                        "encoding_failed"
                    )
                ),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                    Protocol = Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UploadPostTransformErrorEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadPostTransformErrorEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                        "encoding_failed"
                    )
                ),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                    Protocol = Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UploadPostTransformErrorEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        UploadPostTransformErrorEventUploadPostTransformErrorEventData expectedData = new()
        {
            FileID = "fileId",
            Name = "name",
            Path = "path",
            Transformation = new(
                new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                    "encoding_failed"
                )
            ),
            Url = "https://example.com",
        };
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequest expectedRequest = new()
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                Protocol = Protocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
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
        var model = new UploadPostTransformErrorEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                        "encoding_failed"
                    )
                ),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                    Protocol = Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UploadPostTransformErrorEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                        "encoding_failed"
                    )
                ),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                    Protocol = Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        UploadPostTransformErrorEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPostTransformErrorEventUploadPostTransformErrorEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                        "encoding_failed"
                    )
                ),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                    Protocol = Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        UploadPostTransformErrorEventUploadPostTransformErrorEventData expectedData = new()
        {
            FileID = "fileId",
            Name = "name",
            Path = "path",
            Transformation = new(
                new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                    "encoding_failed"
                )
            ),
            Url = "https://example.com",
        };
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequest expectedRequest = new()
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                Protocol = Protocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("upload.post-transform.error");

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedRequest, model.Request);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                        "encoding_failed"
                    )
                ),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                    Protocol = Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformErrorEventUploadPostTransformErrorEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                        "encoding_failed"
                    )
                ),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                    Protocol = Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformErrorEventUploadPostTransformErrorEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        UploadPostTransformErrorEventUploadPostTransformErrorEventData expectedData = new()
        {
            FileID = "fileId",
            Name = "name",
            Path = "path",
            Transformation = new(
                new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                    "encoding_failed"
                )
            ),
            Url = "https://example.com",
        };
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequest expectedRequest = new()
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                Protocol = Protocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("upload.post-transform.error");

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedRequest, deserialized.Request);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                        "encoding_failed"
                    )
                ),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                    Protocol = Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                        "encoding_failed"
                    )
                ),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                    Protocol = Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        UploadPostTransformErrorEventUploadPostTransformErrorEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPostTransformErrorEventUploadPostTransformErrorEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEventData
        {
            FileID = "fileId",
            Name = "name",
            Path = "path",
            Transformation = new(
                new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                    "encoding_failed"
                )
            ),
            Url = "https://example.com",
        };

        string expectedFileID = "fileId";
        string expectedName = "name";
        string expectedPath = "path";
        UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation expectedTransformation =
            new(
                new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                    "encoding_failed"
                )
            );
        string expectedUrl = "https://example.com";

        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedTransformation, model.Transformation);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEventData
        {
            FileID = "fileId",
            Name = "name",
            Path = "path",
            Transformation = new(
                new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                    "encoding_failed"
                )
            ),
            Url = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformErrorEventUploadPostTransformErrorEventData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEventData
        {
            FileID = "fileId",
            Name = "name",
            Path = "path",
            Transformation = new(
                new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                    "encoding_failed"
                )
            ),
            Url = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformErrorEventUploadPostTransformErrorEventData>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedFileID = "fileId";
        string expectedName = "name";
        string expectedPath = "path";
        UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation expectedTransformation =
            new(
                new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                    "encoding_failed"
                )
            );
        string expectedUrl = "https://example.com";

        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedTransformation, deserialized.Transformation);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEventData
        {
            FileID = "fileId",
            Name = "name",
            Path = "path",
            Transformation = new(
                new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                    "encoding_failed"
                )
            ),
            Url = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEventData
        {
            FileID = "fileId",
            Name = "name",
            Path = "path",
            Transformation = new(
                new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
                    "encoding_failed"
                )
            ),
            Url = "https://example.com",
        };

        UploadPostTransformErrorEventUploadPostTransformErrorEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation
        {
            Error = new("encoding_failed"),
        };

        UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError expectedError =
            new("encoding_failed");

        Assert.Equal(expectedError, model.Error);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation
        {
            Error = new("encoding_failed"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation
        {
            Error = new("encoding_failed"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError expectedError =
            new("encoding_failed");

        Assert.Equal(expectedError, deserialized.Error);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation
        {
            Error = new("encoding_failed"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation
        {
            Error = new("encoding_failed"),
        };

        UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationErrorTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError
            {
                Reason = "encoding_failed",
            };

        string expectedReason = "encoding_failed";

        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError
            {
                Reason = "encoding_failed",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError
            {
                Reason = "encoding_failed",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedReason = "encoding_failed";

        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError
            {
                Reason = "encoding_failed",
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError
            {
                Reason = "encoding_failed",
            };

        UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEventRequest
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                Protocol = Protocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation expectedTransformation =
            new()
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                Protocol = Protocol.Hls,
                Value = "value",
            };
        string expectedXRequestID = "x_request_id";

        Assert.Equal(expectedTransformation, model.Transformation);
        Assert.Equal(expectedXRequestID, model.XRequestID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEventRequest
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                Protocol = Protocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformErrorEventUploadPostTransformErrorEventRequest>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEventRequest
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                Protocol = Protocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformErrorEventUploadPostTransformErrorEventRequest>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation expectedTransformation =
            new()
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                Protocol = Protocol.Hls,
                Value = "value",
            };
        string expectedXRequestID = "x_request_id";

        Assert.Equal(expectedTransformation, deserialized.Transformation);
        Assert.Equal(expectedXRequestID, deserialized.XRequestID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEventRequest
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                Protocol = Protocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UploadPostTransformErrorEventUploadPostTransformErrorEventRequest
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                Protocol = Protocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        UploadPostTransformErrorEventUploadPostTransformErrorEventRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                Protocol = Protocol.Hls,
                Value = "value",
            };

        ApiEnum<
            string,
            UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType
        > expectedType =
            UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation;
        ApiEnum<string, Protocol> expectedProtocol = Protocol.Hls;
        string expectedValue = "value";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedProtocol, model.Protocol);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                Protocol = Protocol.Hls,
                Value = "value",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                Protocol = Protocol.Hls,
                Value = "value",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType
        > expectedType =
            UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation;
        ApiEnum<string, Protocol> expectedProtocol = Protocol.Hls;
        string expectedValue = "value";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedProtocol, deserialized.Protocol);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                Protocol = Protocol.Hls,
                Value = "value",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
            };

        Assert.Null(model.Protocol);
        Assert.False(model.RawData.ContainsKey("protocol"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,

                // Null should be interpreted as omitted for these properties
                Protocol = null,
                Value = null,
            };

        Assert.Null(model.Protocol);
        Assert.False(model.RawData.ContainsKey("protocol"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model =
            new UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,

                // Null should be interpreted as omitted for these properties
                Protocol = null,
                Value = null,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation
            {
                Type =
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
                Protocol = Protocol.Hls,
                Value = "value",
            };

        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationTypeTest
    : TestBase
{
    [Theory]
    [InlineData(
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation
    )]
    [InlineData(
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Abs
    )]
    [InlineData(
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.GifToVideo
    )]
    [InlineData(
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Thumbnail
    )]
    public void Validation_Works(
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation
    )]
    [InlineData(
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Abs
    )]
    [InlineData(
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.GifToVideo
    )]
    [InlineData(
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Thumbnail
    )]
    public void SerializationRoundtrip_Works(
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType
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
                UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProtocolTest : TestBase
{
    [Theory]
    [InlineData(Protocol.Hls)]
    [InlineData(Protocol.Dash)]
    public void Validation_Works(Protocol rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Protocol> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Protocol>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Protocol.Hls)]
    [InlineData(Protocol.Dash)]
    public void SerializationRoundtrip_Works(Protocol rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Protocol> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Protocol>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Protocol>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Protocol>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
