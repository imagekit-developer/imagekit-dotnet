using System;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Webhooks;

namespace Imagekit.Tests.Models.Webhooks;

public class UploadPreTransformErrorEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadPreTransformErrorEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                        "encoding_failed"
                    )
                ),
            },
            Request = new() { Transformation = "transformation", XRequestID = "x_request_id" },
        };

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        UploadPreTransformErrorEventIntersectionMember1Data expectedData = new()
        {
            Name = "name",
            Path = "path",
            Transformation = new(
                new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                    "encoding_failed"
                )
            ),
        };
        UploadPreTransformErrorEventIntersectionMember1Request expectedRequest = new()
        {
            Transformation = "transformation",
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
        var model = new UploadPreTransformErrorEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                        "encoding_failed"
                    )
                ),
            },
            Request = new() { Transformation = "transformation", XRequestID = "x_request_id" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UploadPreTransformErrorEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadPreTransformErrorEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                        "encoding_failed"
                    )
                ),
            },
            Request = new() { Transformation = "transformation", XRequestID = "x_request_id" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UploadPreTransformErrorEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        UploadPreTransformErrorEventIntersectionMember1Data expectedData = new()
        {
            Name = "name",
            Path = "path",
            Transformation = new(
                new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                    "encoding_failed"
                )
            ),
        };
        UploadPreTransformErrorEventIntersectionMember1Request expectedRequest = new()
        {
            Transformation = "transformation",
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
        var model = new UploadPreTransformErrorEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                        "encoding_failed"
                    )
                ),
            },
            Request = new() { Transformation = "transformation", XRequestID = "x_request_id" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UploadPreTransformErrorEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                        "encoding_failed"
                    )
                ),
            },
            Request = new() { Transformation = "transformation", XRequestID = "x_request_id" },
        };

        UploadPreTransformErrorEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPreTransformErrorEventIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                        "encoding_failed"
                    )
                ),
            },
            Request = new() { Transformation = "transformation", XRequestID = "x_request_id" },
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        UploadPreTransformErrorEventIntersectionMember1Data expectedData = new()
        {
            Name = "name",
            Path = "path",
            Transformation = new(
                new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                    "encoding_failed"
                )
            ),
        };
        UploadPreTransformErrorEventIntersectionMember1Request expectedRequest = new()
        {
            Transformation = "transformation",
            XRequestID = "x_request_id",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("upload.pre-transform.error");

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedRequest, model.Request);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                        "encoding_failed"
                    )
                ),
            },
            Request = new() { Transformation = "transformation", XRequestID = "x_request_id" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPreTransformErrorEventIntersectionMember1>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                        "encoding_failed"
                    )
                ),
            },
            Request = new() { Transformation = "transformation", XRequestID = "x_request_id" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPreTransformErrorEventIntersectionMember1>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        UploadPreTransformErrorEventIntersectionMember1Data expectedData = new()
        {
            Name = "name",
            Path = "path",
            Transformation = new(
                new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                    "encoding_failed"
                )
            ),
        };
        UploadPreTransformErrorEventIntersectionMember1Request expectedRequest = new()
        {
            Transformation = "transformation",
            XRequestID = "x_request_id",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("upload.pre-transform.error");

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedRequest, deserialized.Request);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                        "encoding_failed"
                    )
                ),
            },
            Request = new() { Transformation = "transformation", XRequestID = "x_request_id" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Name = "name",
                Path = "path",
                Transformation = new(
                    new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                        "encoding_failed"
                    )
                ),
            },
            Request = new() { Transformation = "transformation", XRequestID = "x_request_id" },
        };

        UploadPreTransformErrorEventIntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPreTransformErrorEventIntersectionMember1DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1Data
        {
            Name = "name",
            Path = "path",
            Transformation = new(
                new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                    "encoding_failed"
                )
            ),
        };

        string expectedName = "name";
        string expectedPath = "path";
        UploadPreTransformErrorEventIntersectionMember1DataTransformation expectedTransformation =
            new(
                new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                    "encoding_failed"
                )
            );

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedTransformation, model.Transformation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1Data
        {
            Name = "name",
            Path = "path",
            Transformation = new(
                new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                    "encoding_failed"
                )
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPreTransformErrorEventIntersectionMember1Data>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1Data
        {
            Name = "name",
            Path = "path",
            Transformation = new(
                new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                    "encoding_failed"
                )
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPreTransformErrorEventIntersectionMember1Data>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        string expectedPath = "path";
        UploadPreTransformErrorEventIntersectionMember1DataTransformation expectedTransformation =
            new(
                new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                    "encoding_failed"
                )
            );

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedTransformation, deserialized.Transformation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1Data
        {
            Name = "name",
            Path = "path",
            Transformation = new(
                new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                    "encoding_failed"
                )
            ),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1Data
        {
            Name = "name",
            Path = "path",
            Transformation = new(
                new UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                    "encoding_failed"
                )
            ),
        };

        UploadPreTransformErrorEventIntersectionMember1Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPreTransformErrorEventIntersectionMember1DataTransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1DataTransformation
        {
            Error = new("encoding_failed"),
        };

        UploadPreTransformErrorEventIntersectionMember1DataTransformationError expectedError = new(
            "encoding_failed"
        );

        Assert.Equal(expectedError, model.Error);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1DataTransformation
        {
            Error = new("encoding_failed"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPreTransformErrorEventIntersectionMember1DataTransformation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1DataTransformation
        {
            Error = new("encoding_failed"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPreTransformErrorEventIntersectionMember1DataTransformation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        UploadPreTransformErrorEventIntersectionMember1DataTransformationError expectedError = new(
            "encoding_failed"
        );

        Assert.Equal(expectedError, deserialized.Error);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1DataTransformation
        {
            Error = new("encoding_failed"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1DataTransformation
        {
            Error = new("encoding_failed"),
        };

        UploadPreTransformErrorEventIntersectionMember1DataTransformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPreTransformErrorEventIntersectionMember1DataTransformationErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1DataTransformationError
        {
            Reason = "encoding_failed",
        };

        string expectedReason = "encoding_failed";

        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1DataTransformationError
        {
            Reason = "encoding_failed",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPreTransformErrorEventIntersectionMember1DataTransformationError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1DataTransformationError
        {
            Reason = "encoding_failed",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPreTransformErrorEventIntersectionMember1DataTransformationError>(
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
        var model = new UploadPreTransformErrorEventIntersectionMember1DataTransformationError
        {
            Reason = "encoding_failed",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1DataTransformationError
        {
            Reason = "encoding_failed",
        };

        UploadPreTransformErrorEventIntersectionMember1DataTransformationError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPreTransformErrorEventIntersectionMember1RequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1Request
        {
            Transformation = "transformation",
            XRequestID = "x_request_id",
        };

        string expectedTransformation = "transformation";
        string expectedXRequestID = "x_request_id";

        Assert.Equal(expectedTransformation, model.Transformation);
        Assert.Equal(expectedXRequestID, model.XRequestID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1Request
        {
            Transformation = "transformation",
            XRequestID = "x_request_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPreTransformErrorEventIntersectionMember1Request>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1Request
        {
            Transformation = "transformation",
            XRequestID = "x_request_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPreTransformErrorEventIntersectionMember1Request>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedTransformation = "transformation";
        string expectedXRequestID = "x_request_id";

        Assert.Equal(expectedTransformation, deserialized.Transformation);
        Assert.Equal(expectedXRequestID, deserialized.XRequestID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1Request
        {
            Transformation = "transformation",
            XRequestID = "x_request_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UploadPreTransformErrorEventIntersectionMember1Request
        {
            Transformation = "transformation",
            XRequestID = "x_request_id",
        };

        UploadPreTransformErrorEventIntersectionMember1Request copied = new(model);

        Assert.Equal(model, copied);
    }
}
