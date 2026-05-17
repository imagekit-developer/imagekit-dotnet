using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.Dummy;

namespace ImagekitDiversion.Tests.Models.Dummy;

public class AutoTaggingExtensionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutoTaggingExtension
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = Name.GoogleAutoTagging,
        };

        long expectedMaxTags = 0;
        long expectedMinConfidence = 0;
        ApiEnum<string, Name> expectedName = Name.GoogleAutoTagging;

        Assert.Equal(expectedMaxTags, model.MaxTags);
        Assert.Equal(expectedMinConfidence, model.MinConfidence);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutoTaggingExtension
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = Name.GoogleAutoTagging,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutoTaggingExtension>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutoTaggingExtension
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = Name.GoogleAutoTagging,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutoTaggingExtension>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedMaxTags = 0;
        long expectedMinConfidence = 0;
        ApiEnum<string, Name> expectedName = Name.GoogleAutoTagging;

        Assert.Equal(expectedMaxTags, deserialized.MaxTags);
        Assert.Equal(expectedMinConfidence, deserialized.MinConfidence);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutoTaggingExtension
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = Name.GoogleAutoTagging,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutoTaggingExtension
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = Name.GoogleAutoTagging,
        };

        AutoTaggingExtension copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NameTest : TestBase
{
    [Theory]
    [InlineData(Name.GoogleAutoTagging)]
    [InlineData(Name.AwsAutoTagging)]
    public void Validation_Works(Name rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Name> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Name>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Name.GoogleAutoTagging)]
    [InlineData(Name.AwsAutoTagging)]
    public void SerializationRoundtrip_Works(Name rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Name> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Name>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Name>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Name>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
