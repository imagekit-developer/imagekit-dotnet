using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Dummy;

namespace ImagekitDiversion.Tests.Models.Dummy;

public class ExtensionConfigTest : TestBase
{
    [Fact]
    public void RemovedotBgExtensionValidationWorks()
    {
        ExtensionConfig value = new RemovedotBgExtension()
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
        ExtensionConfig value = new AutoTaggingExtension()
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
        ExtensionConfig value = new AutoDescriptionExtension();
        value.Validate();
    }

    [Fact]
    public void AITasksExtensionValidationWorks()
    {
        ExtensionConfig value = new AITasksExtension(
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
    public void RemovedotBgExtensionSerializationRoundtripWorks()
    {
        ExtensionConfig value = new RemovedotBgExtension()
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
        var deserialized = JsonSerializer.Deserialize<ExtensionConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutoTaggingExtensionSerializationRoundtripWorks()
    {
        ExtensionConfig value = new AutoTaggingExtension()
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = Name.GoogleAutoTagging,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutoDescriptionExtensionSerializationRoundtripWorks()
    {
        ExtensionConfig value = new AutoDescriptionExtension();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AITasksExtensionSerializationRoundtripWorks()
    {
        ExtensionConfig value = new AITasksExtension(
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
        var deserialized = JsonSerializer.Deserialize<ExtensionConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
