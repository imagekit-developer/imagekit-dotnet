using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models;

namespace Imagekit.Tests.Models;

public class AITagTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AITag
        {
            Confidence = 0,
            Name = "name",
            Source = "source",
        };

        double expectedConfidence = 0;
        string expectedName = "name";
        string expectedSource = "source";

        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSource, model.Source);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AITag
        {
            Confidence = 0,
            Name = "name",
            Source = "source",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AITag>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AITag
        {
            Confidence = 0,
            Name = "name",
            Source = "source",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AITag>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedConfidence = 0;
        string expectedName = "name";
        string expectedSource = "source";

        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSource, deserialized.Source);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AITag
        {
            Confidence = 0,
            Name = "name",
            Source = "source",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AITag { };

        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AITag { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AITag
        {
            // Null should be interpreted as omitted for these properties
            Confidence = null,
            Name = null,
            Source = null,
        };

        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AITag
        {
            // Null should be interpreted as omitted for these properties
            Confidence = null,
            Name = null,
            Source = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AITag
        {
            Confidence = 0,
            Name = "name",
            Source = "source",
        };

        AITag copied = new(model);

        Assert.Equal(model, copied);
    }
}
