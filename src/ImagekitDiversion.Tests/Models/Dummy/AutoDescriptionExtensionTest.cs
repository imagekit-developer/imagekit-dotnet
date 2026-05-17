using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Dummy;

namespace ImagekitDiversion.Tests.Models.Dummy;

public class AutoDescriptionExtensionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutoDescriptionExtension { };

        JsonElement expectedName = JsonSerializer.SerializeToElement("ai-auto-description");

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutoDescriptionExtension { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutoDescriptionExtension>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutoDescriptionExtension { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutoDescriptionExtension>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.SerializeToElement("ai-auto-description");

        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutoDescriptionExtension { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutoDescriptionExtension { };

        AutoDescriptionExtension copied = new(model);

        Assert.Equal(model, copied);
    }
}
