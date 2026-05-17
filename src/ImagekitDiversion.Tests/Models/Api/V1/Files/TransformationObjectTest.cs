using System.Collections.Generic;
using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.Api.V1.Files;

namespace ImagekitDiversion.Tests.Models.Api.V1.Files;

public class TransformationObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TransformationObject
        {
            Post =
            [
                new Thumbnail() { Value = "w-150,h-150" },
                new Abs() { Protocol = Protocol.Dash, Value = "sr-240_360_480_720_1080" },
            ],
            Pre = "w-300,h-300,q-80",
        };

        List<Post> expectedPost =
        [
            new Thumbnail() { Value = "w-150,h-150" },
            new Abs() { Protocol = Protocol.Dash, Value = "sr-240_360_480_720_1080" },
        ];
        string expectedPre = "w-300,h-300,q-80";

        Assert.NotNull(model.Post);
        Assert.Equal(expectedPost.Count, model.Post.Count);
        for (int i = 0; i < expectedPost.Count; i++)
        {
            Assert.Equal(expectedPost[i], model.Post[i]);
        }
        Assert.Equal(expectedPre, model.Pre);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TransformationObject
        {
            Post =
            [
                new Thumbnail() { Value = "w-150,h-150" },
                new Abs() { Protocol = Protocol.Dash, Value = "sr-240_360_480_720_1080" },
            ],
            Pre = "w-300,h-300,q-80",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationObject>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TransformationObject
        {
            Post =
            [
                new Thumbnail() { Value = "w-150,h-150" },
                new Abs() { Protocol = Protocol.Dash, Value = "sr-240_360_480_720_1080" },
            ],
            Pre = "w-300,h-300,q-80",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransformationObject>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Post> expectedPost =
        [
            new Thumbnail() { Value = "w-150,h-150" },
            new Abs() { Protocol = Protocol.Dash, Value = "sr-240_360_480_720_1080" },
        ];
        string expectedPre = "w-300,h-300,q-80";

        Assert.NotNull(deserialized.Post);
        Assert.Equal(expectedPost.Count, deserialized.Post.Count);
        for (int i = 0; i < expectedPost.Count; i++)
        {
            Assert.Equal(expectedPost[i], deserialized.Post[i]);
        }
        Assert.Equal(expectedPre, deserialized.Pre);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TransformationObject
        {
            Post =
            [
                new Thumbnail() { Value = "w-150,h-150" },
                new Abs() { Protocol = Protocol.Dash, Value = "sr-240_360_480_720_1080" },
            ],
            Pre = "w-300,h-300,q-80",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TransformationObject { };

        Assert.Null(model.Post);
        Assert.False(model.RawData.ContainsKey("post"));
        Assert.Null(model.Pre);
        Assert.False(model.RawData.ContainsKey("pre"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TransformationObject { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TransformationObject
        {
            // Null should be interpreted as omitted for these properties
            Post = null,
            Pre = null,
        };

        Assert.Null(model.Post);
        Assert.False(model.RawData.ContainsKey("post"));
        Assert.Null(model.Pre);
        Assert.False(model.RawData.ContainsKey("pre"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TransformationObject
        {
            // Null should be interpreted as omitted for these properties
            Post = null,
            Pre = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TransformationObject
        {
            Post =
            [
                new Thumbnail() { Value = "w-150,h-150" },
                new Abs() { Protocol = Protocol.Dash, Value = "sr-240_360_480_720_1080" },
            ],
            Pre = "w-300,h-300,q-80",
        };

        TransformationObject copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PostTest : TestBase
{
    [Fact]
    public void TransformationValidationWorks()
    {
        Post value = new Transformation("w-400,h-400,q-70");
        value.Validate();
    }

    [Fact]
    public void GifToVideoValidationWorks()
    {
        Post value = new GifToVideo() { Value = "q-90" };
        value.Validate();
    }

    [Fact]
    public void ThumbnailValidationWorks()
    {
        Post value = new Thumbnail() { Value = "w-150,h-150" };
        value.Validate();
    }

    [Fact]
    public void AbsValidationWorks()
    {
        Post value = new Abs() { Protocol = Protocol.Hls, Value = "sr-240_360_480_720_1080" };
        value.Validate();
    }

    [Fact]
    public void TransformationSerializationRoundtripWorks()
    {
        Post value = new Transformation("w-400,h-400,q-70");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Post>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GifToVideoSerializationRoundtripWorks()
    {
        Post value = new GifToVideo() { Value = "q-90" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Post>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThumbnailSerializationRoundtripWorks()
    {
        Post value = new Thumbnail() { Value = "w-150,h-150" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Post>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AbsSerializationRoundtripWorks()
    {
        Post value = new Abs() { Protocol = Protocol.Hls, Value = "sr-240_360_480_720_1080" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Post>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Transformation { ValueValue = "w-400,h-400,q-70" };

        JsonElement expectedType = JsonSerializer.SerializeToElement("transformation");
        string expectedValueValue = "w-400,h-400,q-70";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedValueValue, model.ValueValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Transformation { ValueValue = "w-400,h-400,q-70" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Transformation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Transformation { ValueValue = "w-400,h-400,q-70" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Transformation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("transformation");
        string expectedValueValue = "w-400,h-400,q-70";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedValueValue, deserialized.ValueValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Transformation { ValueValue = "w-400,h-400,q-70" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Transformation { ValueValue = "w-400,h-400,q-70" };

        Transformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GifToVideoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GifToVideo { Value = "q-90" };

        JsonElement expectedType = JsonSerializer.SerializeToElement("gif-to-video");
        string expectedValue = "q-90";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GifToVideo { Value = "q-90" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GifToVideo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GifToVideo { Value = "q-90" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GifToVideo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("gif-to-video");
        string expectedValue = "q-90";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GifToVideo { Value = "q-90" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GifToVideo { };

        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GifToVideo { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GifToVideo
        {
            // Null should be interpreted as omitted for these properties
            Value = null,
        };

        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GifToVideo
        {
            // Null should be interpreted as omitted for these properties
            Value = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GifToVideo { Value = "q-90" };

        GifToVideo copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ThumbnailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Thumbnail { Value = "w-150,h-150" };

        JsonElement expectedType = JsonSerializer.SerializeToElement("thumbnail");
        string expectedValue = "w-150,h-150";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Thumbnail { Value = "w-150,h-150" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Thumbnail>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Thumbnail { Value = "w-150,h-150" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Thumbnail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("thumbnail");
        string expectedValue = "w-150,h-150";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Thumbnail { Value = "w-150,h-150" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Thumbnail { };

        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Thumbnail { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Thumbnail
        {
            // Null should be interpreted as omitted for these properties
            Value = null,
        };

        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Thumbnail
        {
            // Null should be interpreted as omitted for these properties
            Value = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Thumbnail { Value = "w-150,h-150" };

        Thumbnail copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AbsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Abs { Protocol = Protocol.Hls, Value = "sr-240_360_480_720_1080" };

        ApiEnum<string, Protocol> expectedProtocol = Protocol.Hls;
        JsonElement expectedType = JsonSerializer.SerializeToElement("abs");
        string expectedValue = "sr-240_360_480_720_1080";

        Assert.Equal(expectedProtocol, model.Protocol);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Abs { Protocol = Protocol.Hls, Value = "sr-240_360_480_720_1080" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Abs>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Abs { Protocol = Protocol.Hls, Value = "sr-240_360_480_720_1080" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Abs>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, Protocol> expectedProtocol = Protocol.Hls;
        JsonElement expectedType = JsonSerializer.SerializeToElement("abs");
        string expectedValue = "sr-240_360_480_720_1080";

        Assert.Equal(expectedProtocol, deserialized.Protocol);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Abs { Protocol = Protocol.Hls, Value = "sr-240_360_480_720_1080" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Abs { Protocol = Protocol.Hls, Value = "sr-240_360_480_720_1080" };

        Abs copied = new(model);

        Assert.Equal(model, copied);
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
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
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
