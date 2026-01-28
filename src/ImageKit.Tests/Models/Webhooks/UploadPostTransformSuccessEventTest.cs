using System;
using System.Text.Json;
using ImageKit.Core;
using ImageKit.Exceptions;
using ImageKit.Models.Webhooks;

namespace ImageKit.Tests.Models.Webhooks;

public class UploadPostTransformSuccessEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadPostTransformSuccessEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        UploadPostTransformSuccessEventIntersectionMember1Data expectedData = new()
        {
            FileID = "fileId",
            Name = "name",
            Url = "https://example.com",
        };
        UploadPostTransformSuccessEventIntersectionMember1Request expectedRequest = new()
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
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
        var model = new UploadPostTransformSuccessEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UploadPostTransformSuccessEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadPostTransformSuccessEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UploadPostTransformSuccessEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        UploadPostTransformSuccessEventIntersectionMember1Data expectedData = new()
        {
            FileID = "fileId",
            Name = "name",
            Url = "https://example.com",
        };
        UploadPostTransformSuccessEventIntersectionMember1Request expectedRequest = new()
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
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
        var model = new UploadPostTransformSuccessEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
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
        var model = new UploadPostTransformSuccessEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        UploadPostTransformSuccessEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPostTransformSuccessEventIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        UploadPostTransformSuccessEventIntersectionMember1Data expectedData = new()
        {
            FileID = "fileId",
            Name = "name",
            Url = "https://example.com",
        };
        UploadPostTransformSuccessEventIntersectionMember1Request expectedRequest = new()
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "upload.post-transform.success"
        );

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedRequest, model.Request);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformSuccessEventIntersectionMember1>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformSuccessEventIntersectionMember1>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        UploadPostTransformSuccessEventIntersectionMember1Data expectedData = new()
        {
            FileID = "fileId",
            Name = "name",
            Url = "https://example.com",
        };
        UploadPostTransformSuccessEventIntersectionMember1Request expectedRequest = new()
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "upload.post-transform.success"
        );

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedRequest, deserialized.Request);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
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
        var model = new UploadPostTransformSuccessEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        UploadPostTransformSuccessEventIntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPostTransformSuccessEventIntersectionMember1DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1Data
        {
            FileID = "fileId",
            Name = "name",
            Url = "https://example.com",
        };

        string expectedFileID = "fileId";
        string expectedName = "name";
        string expectedUrl = "https://example.com";

        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1Data
        {
            FileID = "fileId",
            Name = "name",
            Url = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformSuccessEventIntersectionMember1Data>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1Data
        {
            FileID = "fileId",
            Name = "name",
            Url = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformSuccessEventIntersectionMember1Data>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedFileID = "fileId";
        string expectedName = "name";
        string expectedUrl = "https://example.com";

        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1Data
        {
            FileID = "fileId",
            Name = "name",
            Url = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1Data
        {
            FileID = "fileId",
            Name = "name",
            Url = "https://example.com",
        };

        UploadPostTransformSuccessEventIntersectionMember1Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPostTransformSuccessEventIntersectionMember1RequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1Request
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        UploadPostTransformSuccessEventIntersectionMember1RequestTransformation expectedTransformation =
            new()
            {
                Type =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
                Value = "value",
            };
        string expectedXRequestID = "x_request_id";

        Assert.Equal(expectedTransformation, model.Transformation);
        Assert.Equal(expectedXRequestID, model.XRequestID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1Request
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformSuccessEventIntersectionMember1Request>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1Request
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformSuccessEventIntersectionMember1Request>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        UploadPostTransformSuccessEventIntersectionMember1RequestTransformation expectedTransformation =
            new()
            {
                Type =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
                Value = "value",
            };
        string expectedXRequestID = "x_request_id";

        Assert.Equal(expectedTransformation, deserialized.Transformation);
        Assert.Equal(expectedXRequestID, deserialized.XRequestID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1Request
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1Request
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        UploadPostTransformSuccessEventIntersectionMember1Request copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPostTransformSuccessEventIntersectionMember1RequestTransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1RequestTransformation
        {
            Type =
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
            Protocol =
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
            Value = "value",
        };

        ApiEnum<
            string,
            UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType
        > expectedType =
            UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation;
        ApiEnum<
            string,
            UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol
        > expectedProtocol =
            UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls;
        string expectedValue = "value";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedProtocol, model.Protocol);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1RequestTransformation
        {
            Type =
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
            Protocol =
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformSuccessEventIntersectionMember1RequestTransformation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1RequestTransformation
        {
            Type =
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
            Protocol =
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformSuccessEventIntersectionMember1RequestTransformation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType
        > expectedType =
            UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation;
        ApiEnum<
            string,
            UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol
        > expectedProtocol =
            UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls;
        string expectedValue = "value";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedProtocol, deserialized.Protocol);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1RequestTransformation
        {
            Type =
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
            Protocol =
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1RequestTransformation
        {
            Type =
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
        };

        Assert.Null(model.Protocol);
        Assert.False(model.RawData.ContainsKey("protocol"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1RequestTransformation
        {
            Type =
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1RequestTransformation
        {
            Type =
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,

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
        var model = new UploadPostTransformSuccessEventIntersectionMember1RequestTransformation
        {
            Type =
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,

            // Null should be interpreted as omitted for these properties
            Protocol = null,
            Value = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UploadPostTransformSuccessEventIntersectionMember1RequestTransformation
        {
            Type =
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
            Protocol =
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
            Value = "value",
        };

        UploadPostTransformSuccessEventIntersectionMember1RequestTransformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPostTransformSuccessEventIntersectionMember1RequestTransformationTypeTest
    : TestBase
{
    [Theory]
    [InlineData(
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation
    )]
    [InlineData(UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Abs)]
    [InlineData(
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.GifToVideo
    )]
    [InlineData(
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Thumbnail
    )]
    public void Validation_Works(
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation
    )]
    [InlineData(UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Abs)]
    [InlineData(
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.GifToVideo
    )]
    [InlineData(
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Thumbnail
    )]
    public void SerializationRoundtrip_Works(
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType
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
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocolTest
    : TestBase
{
    [Theory]
    [InlineData(
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls
    )]
    [InlineData(
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Dash
    )]
    public void Validation_Works(
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls
    )]
    [InlineData(
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Dash
    )]
    public void SerializationRoundtrip_Works(
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol
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
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
