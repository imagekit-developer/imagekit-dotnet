using System;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Webhooks = Imagekit.Models.Webhooks;

namespace Imagekit.Tests.Models.Webhooks;

public class UploadPostTransformErrorEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Webhooks::UploadPostTransformErrorEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(new Webhooks::Error("encoding_failed")),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type = Webhooks::Type.Transformation,
                    Protocol = Webhooks::Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEventData expectedData =
            new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(new Webhooks::Error("encoding_failed")),
                Url = "https://example.com",
            };
        Webhooks::Request expectedRequest = new()
        {
            Transformation = new()
            {
                Type = Webhooks::Type.Transformation,
                Protocol = Webhooks::Protocol.Hls,
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
        var model = new Webhooks::UploadPostTransformErrorEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(new Webhooks::Error("encoding_failed")),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type = Webhooks::Type.Transformation,
                    Protocol = Webhooks::Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UploadPostTransformErrorEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Webhooks::UploadPostTransformErrorEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(new Webhooks::Error("encoding_failed")),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type = Webhooks::Type.Transformation,
                    Protocol = Webhooks::Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UploadPostTransformErrorEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEventData expectedData =
            new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(new Webhooks::Error("encoding_failed")),
                Url = "https://example.com",
            };
        Webhooks::Request expectedRequest = new()
        {
            Transformation = new()
            {
                Type = Webhooks::Type.Transformation,
                Protocol = Webhooks::Protocol.Hls,
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
        var model = new Webhooks::UploadPostTransformErrorEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(new Webhooks::Error("encoding_failed")),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type = Webhooks::Type.Transformation,
                    Protocol = Webhooks::Protocol.Hls,
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
        var model = new Webhooks::UploadPostTransformErrorEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(new Webhooks::Error("encoding_failed")),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type = Webhooks::Type.Transformation,
                    Protocol = Webhooks::Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        Webhooks::UploadPostTransformErrorEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPostTransformErrorEventUploadPostTransformErrorEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(new Webhooks::Error("encoding_failed")),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type = Webhooks::Type.Transformation,
                    Protocol = Webhooks::Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEventData expectedData =
            new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(new Webhooks::Error("encoding_failed")),
                Url = "https://example.com",
            };
        Webhooks::Request expectedRequest = new()
        {
            Transformation = new()
            {
                Type = Webhooks::Type.Transformation,
                Protocol = Webhooks::Protocol.Hls,
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
        var model = new Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(new Webhooks::Error("encoding_failed")),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type = Webhooks::Type.Transformation,
                    Protocol = Webhooks::Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(new Webhooks::Error("encoding_failed")),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type = Webhooks::Type.Transformation,
                    Protocol = Webhooks::Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEventData expectedData =
            new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(new Webhooks::Error("encoding_failed")),
                Url = "https://example.com",
            };
        Webhooks::Request expectedRequest = new()
        {
            Transformation = new()
            {
                Type = Webhooks::Type.Transformation,
                Protocol = Webhooks::Protocol.Hls,
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
        var model = new Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(new Webhooks::Error("encoding_failed")),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type = Webhooks::Type.Transformation,
                    Protocol = Webhooks::Protocol.Hls,
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
        var model = new Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(new Webhooks::Error("encoding_failed")),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type = Webhooks::Type.Transformation,
                    Protocol = Webhooks::Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPostTransformErrorEventUploadPostTransformErrorEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEventData
        {
            FileID = "fileId",
            Name = "name",
            Path = "path",
            Transformation = new(new Webhooks::Error("encoding_failed")),
            Url = "https://example.com",
        };

        string expectedFileID = "fileId";
        string expectedName = "name";
        string expectedPath = "path";
        Webhooks::Transformation expectedTransformation = new(
            new Webhooks::Error("encoding_failed")
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
        var model = new Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEventData
        {
            FileID = "fileId",
            Name = "name",
            Path = "path",
            Transformation = new(new Webhooks::Error("encoding_failed")),
            Url = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEventData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEventData
        {
            FileID = "fileId",
            Name = "name",
            Path = "path",
            Transformation = new(new Webhooks::Error("encoding_failed")),
            Url = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEventData>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedFileID = "fileId";
        string expectedName = "name";
        string expectedPath = "path";
        Webhooks::Transformation expectedTransformation = new(
            new Webhooks::Error("encoding_failed")
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
        var model = new Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEventData
        {
            FileID = "fileId",
            Name = "name",
            Path = "path",
            Transformation = new(new Webhooks::Error("encoding_failed")),
            Url = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEventData
        {
            FileID = "fileId",
            Name = "name",
            Path = "path",
            Transformation = new(new Webhooks::Error("encoding_failed")),
            Url = "https://example.com",
        };

        Webhooks::UploadPostTransformErrorEventUploadPostTransformErrorEventData copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class TransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Webhooks::Transformation { Error = new("encoding_failed") };

        Webhooks::Error expectedError = new("encoding_failed");

        Assert.Equal(expectedError, model.Error);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Webhooks::Transformation { Error = new("encoding_failed") };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::Transformation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Webhooks::Transformation { Error = new("encoding_failed") };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::Transformation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Webhooks::Error expectedError = new("encoding_failed");

        Assert.Equal(expectedError, deserialized.Error);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Webhooks::Transformation { Error = new("encoding_failed") };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Webhooks::Transformation { Error = new("encoding_failed") };

        Webhooks::Transformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Webhooks::Error { Reason = "encoding_failed" };

        string expectedReason = "encoding_failed";

        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Webhooks::Error { Reason = "encoding_failed" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::Error>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Webhooks::Error { Reason = "encoding_failed" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::Error>(
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
        var model = new Webhooks::Error { Reason = "encoding_failed" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Webhooks::Error { Reason = "encoding_failed" };

        Webhooks::Error copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Webhooks::Request
        {
            Transformation = new()
            {
                Type = Webhooks::Type.Transformation,
                Protocol = Webhooks::Protocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        Webhooks::RequestTransformation expectedTransformation = new()
        {
            Type = Webhooks::Type.Transformation,
            Protocol = Webhooks::Protocol.Hls,
            Value = "value",
        };
        string expectedXRequestID = "x_request_id";

        Assert.Equal(expectedTransformation, model.Transformation);
        Assert.Equal(expectedXRequestID, model.XRequestID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Webhooks::Request
        {
            Transformation = new()
            {
                Type = Webhooks::Type.Transformation,
                Protocol = Webhooks::Protocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::Request>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Webhooks::Request
        {
            Transformation = new()
            {
                Type = Webhooks::Type.Transformation,
                Protocol = Webhooks::Protocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::Request>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Webhooks::RequestTransformation expectedTransformation = new()
        {
            Type = Webhooks::Type.Transformation,
            Protocol = Webhooks::Protocol.Hls,
            Value = "value",
        };
        string expectedXRequestID = "x_request_id";

        Assert.Equal(expectedTransformation, deserialized.Transformation);
        Assert.Equal(expectedXRequestID, deserialized.XRequestID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Webhooks::Request
        {
            Transformation = new()
            {
                Type = Webhooks::Type.Transformation,
                Protocol = Webhooks::Protocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Webhooks::Request
        {
            Transformation = new()
            {
                Type = Webhooks::Type.Transformation,
                Protocol = Webhooks::Protocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        Webhooks::Request copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RequestTransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Webhooks::RequestTransformation
        {
            Type = Webhooks::Type.Transformation,
            Protocol = Webhooks::Protocol.Hls,
            Value = "value",
        };

        ApiEnum<string, Webhooks::Type> expectedType = Webhooks::Type.Transformation;
        ApiEnum<string, Webhooks::Protocol> expectedProtocol = Webhooks::Protocol.Hls;
        string expectedValue = "value";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedProtocol, model.Protocol);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Webhooks::RequestTransformation
        {
            Type = Webhooks::Type.Transformation,
            Protocol = Webhooks::Protocol.Hls,
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::RequestTransformation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Webhooks::RequestTransformation
        {
            Type = Webhooks::Type.Transformation,
            Protocol = Webhooks::Protocol.Hls,
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::RequestTransformation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Webhooks::Type> expectedType = Webhooks::Type.Transformation;
        ApiEnum<string, Webhooks::Protocol> expectedProtocol = Webhooks::Protocol.Hls;
        string expectedValue = "value";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedProtocol, deserialized.Protocol);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Webhooks::RequestTransformation
        {
            Type = Webhooks::Type.Transformation,
            Protocol = Webhooks::Protocol.Hls,
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Webhooks::RequestTransformation { Type = Webhooks::Type.Transformation };

        Assert.Null(model.Protocol);
        Assert.False(model.RawData.ContainsKey("protocol"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Webhooks::RequestTransformation { Type = Webhooks::Type.Transformation };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Webhooks::RequestTransformation
        {
            Type = Webhooks::Type.Transformation,

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
        var model = new Webhooks::RequestTransformation
        {
            Type = Webhooks::Type.Transformation,

            // Null should be interpreted as omitted for these properties
            Protocol = null,
            Value = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Webhooks::RequestTransformation
        {
            Type = Webhooks::Type.Transformation,
            Protocol = Webhooks::Protocol.Hls,
            Value = "value",
        };

        Webhooks::RequestTransformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Webhooks::Type.Transformation)]
    [InlineData(Webhooks::Type.Abs)]
    [InlineData(Webhooks::Type.GifToVideo)]
    [InlineData(Webhooks::Type.Thumbnail)]
    public void Validation_Works(Webhooks::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Webhooks::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Webhooks::Type.Transformation)]
    [InlineData(Webhooks::Type.Abs)]
    [InlineData(Webhooks::Type.GifToVideo)]
    [InlineData(Webhooks::Type.Thumbnail)]
    public void SerializationRoundtrip_Works(Webhooks::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Webhooks::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ProtocolTest : TestBase
{
    [Theory]
    [InlineData(Webhooks::Protocol.Hls)]
    [InlineData(Webhooks::Protocol.Dash)]
    public void Validation_Works(Webhooks::Protocol rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Webhooks::Protocol> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Protocol>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Webhooks::Protocol.Hls)]
    [InlineData(Webhooks::Protocol.Dash)]
    public void SerializationRoundtrip_Works(Webhooks::Protocol rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Webhooks::Protocol> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Protocol>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Protocol>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Webhooks::Protocol>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
