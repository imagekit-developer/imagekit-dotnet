using System;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Webhooks = Imagekit.Models.Webhooks;

namespace Imagekit.Tests.Models.Webhooks;

public class ImageAsyncTransformationAcceptedEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Webhooks::ImageAsyncTransformationAcceptedEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type = Webhooks::Type.ImageTransformation,
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
        Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData expectedData =
            new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type = Webhooks::Type.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                },
            };
        Webhooks::Request expectedRequest = new()
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
        var model = new Webhooks::ImageAsyncTransformationAcceptedEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type = Webhooks::Type.ImageTransformation,
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
            JsonSerializer.Deserialize<Webhooks::ImageAsyncTransformationAcceptedEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Webhooks::ImageAsyncTransformationAcceptedEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type = Webhooks::Type.ImageTransformation,
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
            JsonSerializer.Deserialize<Webhooks::ImageAsyncTransformationAcceptedEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData expectedData =
            new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type = Webhooks::Type.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                },
            };
        Webhooks::Request expectedRequest = new()
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
        var model = new Webhooks::ImageAsyncTransformationAcceptedEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type = Webhooks::Type.ImageTransformation,
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
        var model = new Webhooks::ImageAsyncTransformationAcceptedEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type = Webhooks::Type.ImageTransformation,
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

        Webhooks::ImageAsyncTransformationAcceptedEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Data = new()
                {
                    Asset = new("https://example.com"),
                    Transformation = new()
                    {
                        Type = Webhooks::Type.ImageTransformation,
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
        Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData expectedData =
            new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type = Webhooks::Type.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                },
            };
        Webhooks::Request expectedRequest = new()
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "image.async-transformation.accepted"
        );

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedRequest, model.Request);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Data = new()
                {
                    Asset = new("https://example.com"),
                    Transformation = new()
                    {
                        Type = Webhooks::Type.ImageTransformation,
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
            JsonSerializer.Deserialize<Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Data = new()
                {
                    Asset = new("https://example.com"),
                    Transformation = new()
                    {
                        Type = Webhooks::Type.ImageTransformation,
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
            JsonSerializer.Deserialize<Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData expectedData =
            new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type = Webhooks::Type.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                },
            };
        Webhooks::Request expectedRequest = new()
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "image.async-transformation.accepted"
        );

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedRequest, deserialized.Request);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Data = new()
                {
                    Asset = new("https://example.com"),
                    Transformation = new()
                    {
                        Type = Webhooks::Type.ImageTransformation,
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
        var model =
            new Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Data = new()
                {
                    Asset = new("https://example.com"),
                    Transformation = new()
                    {
                        Type = Webhooks::Type.ImageTransformation,
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

        Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventDataTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type = Webhooks::Type.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                },
            };

        Webhooks::Asset expectedAsset = new("https://example.com");
        Webhooks::Transformation expectedTransformation = new()
        {
            Type = Webhooks::Type.ImageTransformation,
            Options = new() { Transformation = "transformation" },
        };

        Assert.Equal(expectedAsset, model.Asset);
        Assert.Equal(expectedTransformation, model.Transformation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type = Webhooks::Type.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                },
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type = Webhooks::Type.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                },
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        Webhooks::Asset expectedAsset = new("https://example.com");
        Webhooks::Transformation expectedTransformation = new()
        {
            Type = Webhooks::Type.ImageTransformation,
            Options = new() { Transformation = "transformation" },
        };

        Assert.Equal(expectedAsset, deserialized.Asset);
        Assert.Equal(expectedTransformation, deserialized.Transformation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type = Webhooks::Type.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                },
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type = Webhooks::Type.ImageTransformation,
                    Options = new() { Transformation = "transformation" },
                },
            };

        Webhooks::ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class AssetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Webhooks::Asset { Url = "https://example.com" };

        string expectedUrl = "https://example.com";

        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Webhooks::Asset { Url = "https://example.com" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::Asset>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Webhooks::Asset { Url = "https://example.com" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::Asset>(
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
        var model = new Webhooks::Asset { Url = "https://example.com" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Webhooks::Asset { Url = "https://example.com" };

        Webhooks::Asset copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Webhooks::Transformation
        {
            Type = Webhooks::Type.ImageTransformation,
            Options = new() { Transformation = "transformation" },
        };

        ApiEnum<string, Webhooks::Type> expectedType = Webhooks::Type.ImageTransformation;
        Webhooks::Options expectedOptions = new() { Transformation = "transformation" };

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedOptions, model.Options);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Webhooks::Transformation
        {
            Type = Webhooks::Type.ImageTransformation,
            Options = new() { Transformation = "transformation" },
        };

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
        var model = new Webhooks::Transformation
        {
            Type = Webhooks::Type.ImageTransformation,
            Options = new() { Transformation = "transformation" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::Transformation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Webhooks::Type> expectedType = Webhooks::Type.ImageTransformation;
        Webhooks::Options expectedOptions = new() { Transformation = "transformation" };

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedOptions, deserialized.Options);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Webhooks::Transformation
        {
            Type = Webhooks::Type.ImageTransformation,
            Options = new() { Transformation = "transformation" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Webhooks::Transformation { Type = Webhooks::Type.ImageTransformation };

        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Webhooks::Transformation { Type = Webhooks::Type.ImageTransformation };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Webhooks::Transformation
        {
            Type = Webhooks::Type.ImageTransformation,

            // Null should be interpreted as omitted for these properties
            Options = null,
        };

        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Webhooks::Transformation
        {
            Type = Webhooks::Type.ImageTransformation,

            // Null should be interpreted as omitted for these properties
            Options = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Webhooks::Transformation
        {
            Type = Webhooks::Type.ImageTransformation,
            Options = new() { Transformation = "transformation" },
        };

        Webhooks::Transformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Webhooks::Type.ImageTransformation)]
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
    [InlineData(Webhooks::Type.ImageTransformation)]
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

public class OptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Webhooks::Options { Transformation = "transformation" };

        string expectedTransformation = "transformation";

        Assert.Equal(expectedTransformation, model.Transformation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Webhooks::Options { Transformation = "transformation" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::Options>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Webhooks::Options { Transformation = "transformation" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::Options>(
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
        var model = new Webhooks::Options { Transformation = "transformation" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Webhooks::Options { };

        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Webhooks::Options { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Webhooks::Options
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
        var model = new Webhooks::Options
        {
            // Null should be interpreted as omitted for these properties
            Transformation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Webhooks::Options { Transformation = "transformation" };

        Webhooks::Options copied = new(model);

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
        var model = new Webhooks::Request
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
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
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::Request>(
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
        var model = new Webhooks::Request
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
        var model = new Webhooks::Request
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
        var model = new Webhooks::Request
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Webhooks::Request
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
        var model = new Webhooks::Request
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
        var model = new Webhooks::Request
        {
            Url = "https://example.com",
            XRequestID = "x_request_id",
            UserAgent = "user_agent",
        };

        Webhooks::Request copied = new(model);

        Assert.Equal(model, copied);
    }
}
