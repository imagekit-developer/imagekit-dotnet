using System;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.Webhooks;

namespace Imagekit.Tests.Models.Webhooks;

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
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventData expectedData = new()
        {
            FileID = "fileId",
            Name = "name",
            Url = "https://example.com",
        };
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest expectedRequest =
            new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
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
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
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
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
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
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventData expectedData = new()
        {
            FileID = "fileId",
            Name = "name",
            Url = "https://example.com",
        };
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest expectedRequest =
            new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
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
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
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
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        UploadPostTransformSuccessEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPostTransformSuccessEventUploadPostTransformSuccessEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadPostTransformSuccessEventUploadPostTransformSuccessEvent
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
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventData expectedData = new()
        {
            FileID = "fileId",
            Name = "name",
            Url = "https://example.com",
        };
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest expectedRequest =
            new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
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
        var model = new UploadPostTransformSuccessEventUploadPostTransformSuccessEvent
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
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformSuccessEventUploadPostTransformSuccessEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadPostTransformSuccessEventUploadPostTransformSuccessEvent
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
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformSuccessEventUploadPostTransformSuccessEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventData expectedData = new()
        {
            FileID = "fileId",
            Name = "name",
            Url = "https://example.com",
        };
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest expectedRequest =
            new()
            {
                Transformation = new()
                {
                    Type =
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
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
        var model = new UploadPostTransformSuccessEventUploadPostTransformSuccessEvent
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
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
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
        var model = new UploadPostTransformSuccessEventUploadPostTransformSuccessEvent
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
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                    Protocol =
                        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };

        UploadPostTransformSuccessEventUploadPostTransformSuccessEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPostTransformSuccessEventUploadPostTransformSuccessEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadPostTransformSuccessEventUploadPostTransformSuccessEventData
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
        var model = new UploadPostTransformSuccessEventUploadPostTransformSuccessEventData
        {
            FileID = "fileId",
            Name = "name",
            Url = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformSuccessEventUploadPostTransformSuccessEventData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadPostTransformSuccessEventUploadPostTransformSuccessEventData
        {
            FileID = "fileId",
            Name = "name",
            Url = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformSuccessEventUploadPostTransformSuccessEventData>(
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
        var model = new UploadPostTransformSuccessEventUploadPostTransformSuccessEventData
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
        var model = new UploadPostTransformSuccessEventUploadPostTransformSuccessEventData
        {
            FileID = "fileId",
            Name = "name",
            Url = "https://example.com",
        };

        UploadPostTransformSuccessEventUploadPostTransformSuccessEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation expectedTransformation =
            new()
            {
                Type =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
                Value = "value",
            };
        string expectedXRequestID = "x_request_id";

        Assert.Equal(expectedTransformation, model.Transformation);
        Assert.Equal(expectedXRequestID, model.XRequestID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation expectedTransformation =
            new()
            {
                Type =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
                Value = "value",
            };
        string expectedXRequestID = "x_request_id";

        Assert.Equal(expectedTransformation, deserialized.Transformation);
        Assert.Equal(expectedXRequestID, deserialized.XRequestID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest
        {
            Transformation = new()
            {
                Type =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
                Value = "value",
            },
            XRequestID = "x_request_id",
        };

        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation
            {
                Type =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
                Value = "value",
            };

        ApiEnum<
            string,
            UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType
        > expectedType =
            UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation;
        ApiEnum<
            string,
            UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol
        > expectedProtocol =
            UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls;
        string expectedValue = "value";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedProtocol, model.Protocol);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation
            {
                Type =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
                Value = "value",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation
            {
                Type =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
                Value = "value",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType
        > expectedType =
            UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation;
        ApiEnum<
            string,
            UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol
        > expectedProtocol =
            UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls;
        string expectedValue = "value";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedProtocol, deserialized.Protocol);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation
            {
                Type =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
                Value = "value",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation
            {
                Type =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
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
            new UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation
            {
                Type =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation
            {
                Type =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,

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
            new UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation
            {
                Type =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,

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
            new UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation
            {
                Type =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
                Protocol =
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
                Value = "value",
            };

        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationTypeTest
    : TestBase
{
    [Theory]
    [InlineData(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation
    )]
    [InlineData(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Abs
    )]
    [InlineData(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.GifToVideo
    )]
    [InlineData(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Thumbnail
    )]
    public void Validation_Works(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation
    )]
    [InlineData(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Abs
    )]
    [InlineData(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.GifToVideo
    )]
    [InlineData(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Thumbnail
    )]
    public void SerializationRoundtrip_Works(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType
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
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocolTest
    : TestBase
{
    [Theory]
    [InlineData(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls
    )]
    [InlineData(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Dash
    )]
    public void Validation_Works(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls
    )]
    [InlineData(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Dash
    )]
    public void SerializationRoundtrip_Works(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol
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
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
