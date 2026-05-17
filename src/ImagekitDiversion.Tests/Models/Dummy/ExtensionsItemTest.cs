using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Dummy;

namespace ImagekitDiversion.Tests.Models.Dummy;

public class ExtensionsItemTest : TestBase
{
    [Fact]
    public void RemovedotBgExtensionValidationWorks()
    {
        ExtensionsItem value = new RemovedotBgExtension()
        {
            Options = new()
            {
                AddShadow = true,
                BgColor = "bg_color",
                BgImageUrl = "bg_image_url",
                Semitransparency = true,
            },
        };
        value.Validate();
    }

    [Fact]
    public void AutoTaggingExtensionValidationWorks()
    {
        ExtensionsItem value = new AutoTaggingExtension()
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = Name.GoogleAutoTagging,
        };
        value.Validate();
    }

    [Fact]
    public void AutoDescriptionExtensionValidationWorks()
    {
        ExtensionsItem value = new AutoDescriptionExtension();
        value.Validate();
    }

    [Fact]
    public void AITasksExtensionValidationWorks()
    {
        ExtensionsItem value = new AITasksExtension(
            [
                new SelectTags()
                {
                    Instruction = "What types of clothing items are visible in this image?",
                    MaxSelections = 1,
                    MinSelections = 0,
                    Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void SavedExtensionValidationWorks()
    {
        ExtensionsItem value = new SavedExtension("ext_abc123");
        value.Validate();
    }

    [Fact]
    public void RemovedotBgExtensionSerializationRoundtripWorks()
    {
        ExtensionsItem value = new RemovedotBgExtension()
        {
            Options = new()
            {
                AddShadow = true,
                BgColor = "bg_color",
                BgImageUrl = "bg_image_url",
                Semitransparency = true,
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionsItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutoTaggingExtensionSerializationRoundtripWorks()
    {
        ExtensionsItem value = new AutoTaggingExtension()
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = Name.GoogleAutoTagging,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionsItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutoDescriptionExtensionSerializationRoundtripWorks()
    {
        ExtensionsItem value = new AutoDescriptionExtension();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionsItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AITasksExtensionSerializationRoundtripWorks()
    {
        ExtensionsItem value = new AITasksExtension(
            [
                new SelectTags()
                {
                    Instruction = "What types of clothing items are visible in this image?",
                    MaxSelections = 1,
                    MinSelections = 0,
                    Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionsItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SavedExtensionSerializationRoundtripWorks()
    {
        ExtensionsItem value = new SavedExtension("ext_abc123");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionsItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SavedExtensionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SavedExtension { ID = "ext_abc123" };

        string expectedID = "ext_abc123";
        JsonElement expectedName = JsonSerializer.SerializeToElement("saved-extension");

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SavedExtension { ID = "ext_abc123" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SavedExtension>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SavedExtension { ID = "ext_abc123" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SavedExtension>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "ext_abc123";
        JsonElement expectedName = JsonSerializer.SerializeToElement("saved-extension");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SavedExtension { ID = "ext_abc123" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SavedExtension { ID = "ext_abc123" };

        SavedExtension copied = new(model);

        Assert.Equal(model, copied);
    }
}
