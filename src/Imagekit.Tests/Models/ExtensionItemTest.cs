using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models;

namespace Imagekit.Tests.Models;

public class ExtensionItemTest : TestBase
{
    [Fact]
    public void RemoveBgValidationWorks()
    {
        ExtensionItem value = new ExtensionItemRemoveBg()
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
        ExtensionItem value = new ExtensionItemAutoTaggingExtension()
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging,
        };
        value.Validate();
    }

    [Fact]
    public void AIAutoDescriptionValidationWorks()
    {
        ExtensionItem value = new ExtensionItemAIAutoDescription();
        value.Validate();
    }

    [Fact]
    public void AITasksValidationWorks()
    {
        ExtensionItem value = new ExtensionItemAITasks(
            [
                new ExtensionItemAITasksTaskSelectTags()
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
        ExtensionItem value = new SavedExtension("ext_abc123");
        value.Validate();
    }

    [Fact]
    public void RemoveBgSerializationRoundtripWorks()
    {
        ExtensionItem value = new ExtensionItemRemoveBg()
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
        var deserialized = JsonSerializer.Deserialize<ExtensionItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutoTaggingExtensionSerializationRoundtripWorks()
    {
        ExtensionItem value = new ExtensionItemAutoTaggingExtension()
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AIAutoDescriptionSerializationRoundtripWorks()
    {
        ExtensionItem value = new ExtensionItemAIAutoDescription();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AITasksSerializationRoundtripWorks()
    {
        ExtensionItem value = new ExtensionItemAITasks(
            [
                new ExtensionItemAITasksTaskSelectTags()
                {
                    Instruction = "What types of clothing items are visible in this image?",
                    MaxSelections = 1,
                    MinSelections = 0,
                    Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SavedExtensionSerializationRoundtripWorks()
    {
        ExtensionItem value = new SavedExtension("ext_abc123");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExtensionItemRemoveBgTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtensionItemRemoveBg
        {
            Options = new()
            {
                AddShadow = true,
                BgColor = "bg_color",
                BgImageUrl = "bg_image_url",
                Semitransparency = true,
            },
        };

        JsonElement expectedName = JsonSerializer.SerializeToElement("remove-bg");
        ExtensionItemRemoveBgOptions expectedOptions = new()
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.Equal(expectedOptions, model.Options);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtensionItemRemoveBg
        {
            Options = new()
            {
                AddShadow = true,
                BgColor = "bg_color",
                BgImageUrl = "bg_image_url",
                Semitransparency = true,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemRemoveBg>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtensionItemRemoveBg
        {
            Options = new()
            {
                AddShadow = true,
                BgColor = "bg_color",
                BgImageUrl = "bg_image_url",
                Semitransparency = true,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemRemoveBg>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.SerializeToElement("remove-bg");
        ExtensionItemRemoveBgOptions expectedOptions = new()
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.Equal(expectedOptions, deserialized.Options);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtensionItemRemoveBg
        {
            Options = new()
            {
                AddShadow = true,
                BgColor = "bg_color",
                BgImageUrl = "bg_image_url",
                Semitransparency = true,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtensionItemRemoveBg { };

        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtensionItemRemoveBg { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExtensionItemRemoveBg
        {
            // Null should be interpreted as omitted for these properties
            Options = null,
        };

        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtensionItemRemoveBg
        {
            // Null should be interpreted as omitted for these properties
            Options = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtensionItemRemoveBg
        {
            Options = new()
            {
                AddShadow = true,
                BgColor = "bg_color",
                BgImageUrl = "bg_image_url",
                Semitransparency = true,
            },
        };

        ExtensionItemRemoveBg copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtensionItemRemoveBgOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtensionItemRemoveBgOptions
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        bool expectedAddShadow = true;
        string expectedBgColor = "bg_color";
        string expectedBgImageUrl = "bg_image_url";
        bool expectedSemitransparency = true;

        Assert.Equal(expectedAddShadow, model.AddShadow);
        Assert.Equal(expectedBgColor, model.BgColor);
        Assert.Equal(expectedBgImageUrl, model.BgImageUrl);
        Assert.Equal(expectedSemitransparency, model.Semitransparency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtensionItemRemoveBgOptions
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemRemoveBgOptions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtensionItemRemoveBgOptions
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemRemoveBgOptions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAddShadow = true;
        string expectedBgColor = "bg_color";
        string expectedBgImageUrl = "bg_image_url";
        bool expectedSemitransparency = true;

        Assert.Equal(expectedAddShadow, deserialized.AddShadow);
        Assert.Equal(expectedBgColor, deserialized.BgColor);
        Assert.Equal(expectedBgImageUrl, deserialized.BgImageUrl);
        Assert.Equal(expectedSemitransparency, deserialized.Semitransparency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtensionItemRemoveBgOptions
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtensionItemRemoveBgOptions { };

        Assert.Null(model.AddShadow);
        Assert.False(model.RawData.ContainsKey("add_shadow"));
        Assert.Null(model.BgColor);
        Assert.False(model.RawData.ContainsKey("bg_color"));
        Assert.Null(model.BgImageUrl);
        Assert.False(model.RawData.ContainsKey("bg_image_url"));
        Assert.Null(model.Semitransparency);
        Assert.False(model.RawData.ContainsKey("semitransparency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtensionItemRemoveBgOptions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExtensionItemRemoveBgOptions
        {
            // Null should be interpreted as omitted for these properties
            AddShadow = null,
            BgColor = null,
            BgImageUrl = null,
            Semitransparency = null,
        };

        Assert.Null(model.AddShadow);
        Assert.False(model.RawData.ContainsKey("add_shadow"));
        Assert.Null(model.BgColor);
        Assert.False(model.RawData.ContainsKey("bg_color"));
        Assert.Null(model.BgImageUrl);
        Assert.False(model.RawData.ContainsKey("bg_image_url"));
        Assert.Null(model.Semitransparency);
        Assert.False(model.RawData.ContainsKey("semitransparency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtensionItemRemoveBgOptions
        {
            // Null should be interpreted as omitted for these properties
            AddShadow = null,
            BgColor = null,
            BgImageUrl = null,
            Semitransparency = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtensionItemRemoveBgOptions
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        ExtensionItemRemoveBgOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtensionItemAutoTaggingExtensionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtensionItemAutoTaggingExtension
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging,
        };

        long expectedMaxTags = 0;
        long expectedMinConfidence = 0;
        ApiEnum<string, ExtensionItemAutoTaggingExtensionName> expectedName =
            ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging;

        Assert.Equal(expectedMaxTags, model.MaxTags);
        Assert.Equal(expectedMinConfidence, model.MinConfidence);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtensionItemAutoTaggingExtension
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAutoTaggingExtension>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtensionItemAutoTaggingExtension
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAutoTaggingExtension>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedMaxTags = 0;
        long expectedMinConfidence = 0;
        ApiEnum<string, ExtensionItemAutoTaggingExtensionName> expectedName =
            ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging;

        Assert.Equal(expectedMaxTags, deserialized.MaxTags);
        Assert.Equal(expectedMinConfidence, deserialized.MinConfidence);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtensionItemAutoTaggingExtension
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtensionItemAutoTaggingExtension
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging,
        };

        ExtensionItemAutoTaggingExtension copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtensionItemAutoTaggingExtensionNameTest : TestBase
{
    [Theory]
    [InlineData(ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging)]
    [InlineData(ExtensionItemAutoTaggingExtensionName.AwsAutoTagging)]
    public void Validation_Works(ExtensionItemAutoTaggingExtensionName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtensionItemAutoTaggingExtensionName> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExtensionItemAutoTaggingExtensionName>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging)]
    [InlineData(ExtensionItemAutoTaggingExtensionName.AwsAutoTagging)]
    public void SerializationRoundtrip_Works(ExtensionItemAutoTaggingExtensionName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtensionItemAutoTaggingExtensionName> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExtensionItemAutoTaggingExtensionName>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExtensionItemAutoTaggingExtensionName>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExtensionItemAutoTaggingExtensionName>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ExtensionItemAIAutoDescriptionTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new ExtensionItemAIAutoDescription();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<ExtensionItemAIAutoDescription>(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "name": "ai-auto-description"
                }
                """
            ),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<ExtensionItemAIAutoDescription>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new ExtensionItemAIAutoDescription();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAIAutoDescription>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<ExtensionItemAIAutoDescription>(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "name": "ai-auto-description"
                }
                """
            ),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAIAutoDescription>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<ExtensionItemAIAutoDescription>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAIAutoDescription>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class ExtensionItemAITasksTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtensionItemAITasks
        {
            Tasks =
            [
                new ExtensionItemAITasksTaskSelectTags()
                {
                    Instruction = "What types of clothing items are visible in this image?",
                    MaxSelections = 1,
                    MinSelections = 0,
                    Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                },
            ],
        };

        JsonElement expectedName = JsonSerializer.SerializeToElement("ai-tasks");
        List<ExtensionItemAITasksTask> expectedTasks =
        [
            new ExtensionItemAITasksTaskSelectTags()
            {
                Instruction = "What types of clothing items are visible in this image?",
                MaxSelections = 1,
                MinSelections = 0,
                Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
            },
        ];

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.Equal(expectedTasks.Count, model.Tasks.Count);
        for (int i = 0; i < expectedTasks.Count; i++)
        {
            Assert.Equal(expectedTasks[i], model.Tasks[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtensionItemAITasks
        {
            Tasks =
            [
                new ExtensionItemAITasksTaskSelectTags()
                {
                    Instruction = "What types of clothing items are visible in this image?",
                    MaxSelections = 1,
                    MinSelections = 0,
                    Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasks>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtensionItemAITasks
        {
            Tasks =
            [
                new ExtensionItemAITasksTaskSelectTags()
                {
                    Instruction = "What types of clothing items are visible in this image?",
                    MaxSelections = 1,
                    MinSelections = 0,
                    Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasks>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.SerializeToElement("ai-tasks");
        List<ExtensionItemAITasksTask> expectedTasks =
        [
            new ExtensionItemAITasksTaskSelectTags()
            {
                Instruction = "What types of clothing items are visible in this image?",
                MaxSelections = 1,
                MinSelections = 0,
                Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
            },
        ];

        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.Equal(expectedTasks.Count, deserialized.Tasks.Count);
        for (int i = 0; i < expectedTasks.Count; i++)
        {
            Assert.Equal(expectedTasks[i], deserialized.Tasks[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtensionItemAITasks
        {
            Tasks =
            [
                new ExtensionItemAITasksTaskSelectTags()
                {
                    Instruction = "What types of clothing items are visible in this image?",
                    MaxSelections = 1,
                    MinSelections = 0,
                    Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtensionItemAITasks
        {
            Tasks =
            [
                new ExtensionItemAITasksTaskSelectTags()
                {
                    Instruction = "What types of clothing items are visible in this image?",
                    MaxSelections = 1,
                    MinSelections = 0,
                    Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                },
            ],
        };

        ExtensionItemAITasks copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtensionItemAITasksTaskTest : TestBase
{
    [Fact]
    public void SelectTagsValidationWorks()
    {
        ExtensionItemAITasksTask value = new ExtensionItemAITasksTaskSelectTags()
        {
            Instruction = "What types of clothing items are visible in this image?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
        };
        value.Validate();
    }

    [Fact]
    public void SelectMetadataValidationWorks()
    {
        ExtensionItemAITasksTask value = new ExtensionItemAITasksTaskSelectMetadata()
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["red", "blue", "green", "black", "white"],
        };
        value.Validate();
    }

    [Fact]
    public void YesNoValidationWorks()
    {
        ExtensionItemAITasksTask value = new ExtensionItemAITasksTaskYesNo()
        {
            Instruction = "Is this a luxury or high-end fashion item?",
            OnNo = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
            OnUnknown = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
            OnYes = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
        };
        value.Validate();
    }

    [Fact]
    public void SelectTagsSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTask value = new ExtensionItemAITasksTaskSelectTags()
        {
            Instruction = "What types of clothing items are visible in this image?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasksTask>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SelectMetadataSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTask value = new ExtensionItemAITasksTaskSelectMetadata()
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["red", "blue", "green", "black", "white"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasksTask>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void YesNoSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTask value = new ExtensionItemAITasksTaskYesNo()
        {
            Instruction = "Is this a luxury or high-end fashion item?",
            OnNo = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
            OnUnknown = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
            OnYes = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasksTask>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExtensionItemAITasksTaskSelectTagsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskSelectTags
        {
            Instruction = "What types of clothing items are visible in this image?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
        };

        string expectedInstruction = "What types of clothing items are visible in this image?";
        JsonElement expectedType = JsonSerializer.SerializeToElement("select_tags");
        long expectedMaxSelections = 1;
        long expectedMinSelections = 0;
        List<string> expectedVocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"];

        Assert.Equal(expectedInstruction, model.Instruction);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedMaxSelections, model.MaxSelections);
        Assert.Equal(expectedMinSelections, model.MinSelections);
        Assert.NotNull(model.Vocabulary);
        Assert.Equal(expectedVocabulary.Count, model.Vocabulary.Count);
        for (int i = 0; i < expectedVocabulary.Count; i++)
        {
            Assert.Equal(expectedVocabulary[i], model.Vocabulary[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskSelectTags
        {
            Instruction = "What types of clothing items are visible in this image?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasksTaskSelectTags>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtensionItemAITasksTaskSelectTags
        {
            Instruction = "What types of clothing items are visible in this image?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasksTaskSelectTags>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInstruction = "What types of clothing items are visible in this image?";
        JsonElement expectedType = JsonSerializer.SerializeToElement("select_tags");
        long expectedMaxSelections = 1;
        long expectedMinSelections = 0;
        List<string> expectedVocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"];

        Assert.Equal(expectedInstruction, deserialized.Instruction);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedMaxSelections, deserialized.MaxSelections);
        Assert.Equal(expectedMinSelections, deserialized.MinSelections);
        Assert.NotNull(deserialized.Vocabulary);
        Assert.Equal(expectedVocabulary.Count, deserialized.Vocabulary.Count);
        for (int i = 0; i < expectedVocabulary.Count; i++)
        {
            Assert.Equal(expectedVocabulary[i], deserialized.Vocabulary[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtensionItemAITasksTaskSelectTags
        {
            Instruction = "What types of clothing items are visible in this image?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtensionItemAITasksTaskSelectTags
        {
            Instruction = "What types of clothing items are visible in this image?",
        };

        Assert.Null(model.MaxSelections);
        Assert.False(model.RawData.ContainsKey("max_selections"));
        Assert.Null(model.MinSelections);
        Assert.False(model.RawData.ContainsKey("min_selections"));
        Assert.Null(model.Vocabulary);
        Assert.False(model.RawData.ContainsKey("vocabulary"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtensionItemAITasksTaskSelectTags
        {
            Instruction = "What types of clothing items are visible in this image?",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExtensionItemAITasksTaskSelectTags
        {
            Instruction = "What types of clothing items are visible in this image?",

            // Null should be interpreted as omitted for these properties
            MaxSelections = null,
            MinSelections = null,
            Vocabulary = null,
        };

        Assert.Null(model.MaxSelections);
        Assert.False(model.RawData.ContainsKey("max_selections"));
        Assert.Null(model.MinSelections);
        Assert.False(model.RawData.ContainsKey("min_selections"));
        Assert.Null(model.Vocabulary);
        Assert.False(model.RawData.ContainsKey("vocabulary"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtensionItemAITasksTaskSelectTags
        {
            Instruction = "What types of clothing items are visible in this image?",

            // Null should be interpreted as omitted for these properties
            MaxSelections = null,
            MinSelections = null,
            Vocabulary = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtensionItemAITasksTaskSelectTags
        {
            Instruction = "What types of clothing items are visible in this image?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
        };

        ExtensionItemAITasksTaskSelectTags copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtensionItemAITasksTaskSelectMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskSelectMetadata
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["red", "blue", "green", "black", "white"],
        };

        string expectedField = "primary_color";
        string expectedInstruction = "What is the primary color of the clothing?";
        JsonElement expectedType = JsonSerializer.SerializeToElement("select_metadata");
        long expectedMaxSelections = 1;
        long expectedMinSelections = 0;
        List<ExtensionItemAITasksTaskSelectMetadataVocabulary> expectedVocabulary =
        [
            "red",
            "blue",
            "green",
            "black",
            "white",
        ];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedInstruction, model.Instruction);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedMaxSelections, model.MaxSelections);
        Assert.Equal(expectedMinSelections, model.MinSelections);
        Assert.NotNull(model.Vocabulary);
        Assert.Equal(expectedVocabulary.Count, model.Vocabulary.Count);
        for (int i = 0; i < expectedVocabulary.Count; i++)
        {
            Assert.Equal(expectedVocabulary[i], model.Vocabulary[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskSelectMetadata
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["red", "blue", "green", "black", "white"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasksTaskSelectMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtensionItemAITasksTaskSelectMetadata
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["red", "blue", "green", "black", "white"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasksTaskSelectMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedField = "primary_color";
        string expectedInstruction = "What is the primary color of the clothing?";
        JsonElement expectedType = JsonSerializer.SerializeToElement("select_metadata");
        long expectedMaxSelections = 1;
        long expectedMinSelections = 0;
        List<ExtensionItemAITasksTaskSelectMetadataVocabulary> expectedVocabulary =
        [
            "red",
            "blue",
            "green",
            "black",
            "white",
        ];

        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedInstruction, deserialized.Instruction);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedMaxSelections, deserialized.MaxSelections);
        Assert.Equal(expectedMinSelections, deserialized.MinSelections);
        Assert.NotNull(deserialized.Vocabulary);
        Assert.Equal(expectedVocabulary.Count, deserialized.Vocabulary.Count);
        for (int i = 0; i < expectedVocabulary.Count; i++)
        {
            Assert.Equal(expectedVocabulary[i], deserialized.Vocabulary[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtensionItemAITasksTaskSelectMetadata
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["red", "blue", "green", "black", "white"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtensionItemAITasksTaskSelectMetadata
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",
        };

        Assert.Null(model.MaxSelections);
        Assert.False(model.RawData.ContainsKey("max_selections"));
        Assert.Null(model.MinSelections);
        Assert.False(model.RawData.ContainsKey("min_selections"));
        Assert.Null(model.Vocabulary);
        Assert.False(model.RawData.ContainsKey("vocabulary"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtensionItemAITasksTaskSelectMetadata
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExtensionItemAITasksTaskSelectMetadata
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",

            // Null should be interpreted as omitted for these properties
            MaxSelections = null,
            MinSelections = null,
            Vocabulary = null,
        };

        Assert.Null(model.MaxSelections);
        Assert.False(model.RawData.ContainsKey("max_selections"));
        Assert.Null(model.MinSelections);
        Assert.False(model.RawData.ContainsKey("min_selections"));
        Assert.Null(model.Vocabulary);
        Assert.False(model.RawData.ContainsKey("vocabulary"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtensionItemAITasksTaskSelectMetadata
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",

            // Null should be interpreted as omitted for these properties
            MaxSelections = null,
            MinSelections = null,
            Vocabulary = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtensionItemAITasksTaskSelectMetadata
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["red", "blue", "green", "black", "white"],
        };

        ExtensionItemAITasksTaskSelectMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtensionItemAITasksTaskSelectMetadataVocabularyTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ExtensionItemAITasksTaskSelectMetadataVocabulary value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ExtensionItemAITasksTaskSelectMetadataVocabulary value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ExtensionItemAITasksTaskSelectMetadataVocabulary value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskSelectMetadataVocabulary value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskSelectMetadataVocabulary>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskSelectMetadataVocabulary value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskSelectMetadataVocabulary>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskSelectMetadataVocabulary value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskSelectMetadataVocabulary>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ExtensionItemAITasksTaskYesNoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNo
        {
            Instruction = "Is this a luxury or high-end fashion item?",
            OnNo = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
            OnUnknown = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
            OnYes = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
        };

        string expectedInstruction = "Is this a luxury or high-end fashion item?";
        JsonElement expectedType = JsonSerializer.SerializeToElement("yes_no");
        ExtensionItemAITasksTaskYesNoOnNo expectedOnNo = new()
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };
        ExtensionItemAITasksTaskYesNoOnUnknown expectedOnUnknown = new()
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };
        ExtensionItemAITasksTaskYesNoOnYes expectedOnYes = new()
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        Assert.Equal(expectedInstruction, model.Instruction);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedOnNo, model.OnNo);
        Assert.Equal(expectedOnUnknown, model.OnUnknown);
        Assert.Equal(expectedOnYes, model.OnYes);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNo
        {
            Instruction = "Is this a luxury or high-end fashion item?",
            OnNo = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
            OnUnknown = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
            OnYes = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNo
        {
            Instruction = "Is this a luxury or high-end fashion item?",
            OnNo = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
            OnUnknown = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
            OnYes = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInstruction = "Is this a luxury or high-end fashion item?";
        JsonElement expectedType = JsonSerializer.SerializeToElement("yes_no");
        ExtensionItemAITasksTaskYesNoOnNo expectedOnNo = new()
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };
        ExtensionItemAITasksTaskYesNoOnUnknown expectedOnUnknown = new()
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };
        ExtensionItemAITasksTaskYesNoOnYes expectedOnYes = new()
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        Assert.Equal(expectedInstruction, deserialized.Instruction);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedOnNo, deserialized.OnNo);
        Assert.Equal(expectedOnUnknown, deserialized.OnUnknown);
        Assert.Equal(expectedOnYes, deserialized.OnYes);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNo
        {
            Instruction = "Is this a luxury or high-end fashion item?",
            OnNo = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
            OnUnknown = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
            OnYes = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNo
        {
            Instruction = "Is this a luxury or high-end fashion item?",
        };

        Assert.Null(model.OnNo);
        Assert.False(model.RawData.ContainsKey("on_no"));
        Assert.Null(model.OnUnknown);
        Assert.False(model.RawData.ContainsKey("on_unknown"));
        Assert.Null(model.OnYes);
        Assert.False(model.RawData.ContainsKey("on_yes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNo
        {
            Instruction = "Is this a luxury or high-end fashion item?",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNo
        {
            Instruction = "Is this a luxury or high-end fashion item?",

            // Null should be interpreted as omitted for these properties
            OnNo = null,
            OnUnknown = null,
            OnYes = null,
        };

        Assert.Null(model.OnNo);
        Assert.False(model.RawData.ContainsKey("on_no"));
        Assert.Null(model.OnUnknown);
        Assert.False(model.RawData.ContainsKey("on_unknown"));
        Assert.Null(model.OnYes);
        Assert.False(model.RawData.ContainsKey("on_yes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNo
        {
            Instruction = "Is this a luxury or high-end fashion item?",

            // Null should be interpreted as omitted for these properties
            OnNo = null,
            OnUnknown = null,
            OnYes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNo
        {
            Instruction = "Is this a luxury or high-end fashion item?",
            OnNo = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
            OnUnknown = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
            OnYes = new()
            {
                AddTags = ["luxury", "premium"],
                RemoveTags = ["budget", "affordable"],
                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                UnsetMetadata = [new("price_range")],
            },
        };

        ExtensionItemAITasksTaskYesNo copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtensionItemAITasksTaskYesNoOnNoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnNo
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<ExtensionItemAITasksTaskYesNoOnNoSetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata> expectedUnsetMetadata =
        [
            new("price_range"),
        ];

        Assert.NotNull(model.AddTags);
        Assert.Equal(expectedAddTags.Count, model.AddTags.Count);
        for (int i = 0; i < expectedAddTags.Count; i++)
        {
            Assert.Equal(expectedAddTags[i], model.AddTags[i]);
        }
        Assert.NotNull(model.RemoveTags);
        Assert.Equal(expectedRemoveTags.Count, model.RemoveTags.Count);
        for (int i = 0; i < expectedRemoveTags.Count; i++)
        {
            Assert.Equal(expectedRemoveTags[i], model.RemoveTags[i]);
        }
        Assert.NotNull(model.SetMetadata);
        Assert.Equal(expectedSetMetadata.Count, model.SetMetadata.Count);
        for (int i = 0; i < expectedSetMetadata.Count; i++)
        {
            Assert.Equal(expectedSetMetadata[i], model.SetMetadata[i]);
        }
        Assert.NotNull(model.UnsetMetadata);
        Assert.Equal(expectedUnsetMetadata.Count, model.UnsetMetadata.Count);
        for (int i = 0; i < expectedUnsetMetadata.Count; i++)
        {
            Assert.Equal(expectedUnsetMetadata[i], model.UnsetMetadata[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnNo
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnNo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnNo
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnNo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<ExtensionItemAITasksTaskYesNoOnNoSetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata> expectedUnsetMetadata =
        [
            new("price_range"),
        ];

        Assert.NotNull(deserialized.AddTags);
        Assert.Equal(expectedAddTags.Count, deserialized.AddTags.Count);
        for (int i = 0; i < expectedAddTags.Count; i++)
        {
            Assert.Equal(expectedAddTags[i], deserialized.AddTags[i]);
        }
        Assert.NotNull(deserialized.RemoveTags);
        Assert.Equal(expectedRemoveTags.Count, deserialized.RemoveTags.Count);
        for (int i = 0; i < expectedRemoveTags.Count; i++)
        {
            Assert.Equal(expectedRemoveTags[i], deserialized.RemoveTags[i]);
        }
        Assert.NotNull(deserialized.SetMetadata);
        Assert.Equal(expectedSetMetadata.Count, deserialized.SetMetadata.Count);
        for (int i = 0; i < expectedSetMetadata.Count; i++)
        {
            Assert.Equal(expectedSetMetadata[i], deserialized.SetMetadata[i]);
        }
        Assert.NotNull(deserialized.UnsetMetadata);
        Assert.Equal(expectedUnsetMetadata.Count, deserialized.UnsetMetadata.Count);
        for (int i = 0; i < expectedUnsetMetadata.Count; i++)
        {
            Assert.Equal(expectedUnsetMetadata[i], deserialized.UnsetMetadata[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnNo
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnNo { };

        Assert.Null(model.AddTags);
        Assert.False(model.RawData.ContainsKey("add_tags"));
        Assert.Null(model.RemoveTags);
        Assert.False(model.RawData.ContainsKey("remove_tags"));
        Assert.Null(model.SetMetadata);
        Assert.False(model.RawData.ContainsKey("set_metadata"));
        Assert.Null(model.UnsetMetadata);
        Assert.False(model.RawData.ContainsKey("unset_metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnNo { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnNo
        {
            // Null should be interpreted as omitted for these properties
            AddTags = null,
            RemoveTags = null,
            SetMetadata = null,
            UnsetMetadata = null,
        };

        Assert.Null(model.AddTags);
        Assert.False(model.RawData.ContainsKey("add_tags"));
        Assert.Null(model.RemoveTags);
        Assert.False(model.RawData.ContainsKey("remove_tags"));
        Assert.Null(model.SetMetadata);
        Assert.False(model.RawData.ContainsKey("set_metadata"));
        Assert.Null(model.UnsetMetadata);
        Assert.False(model.RawData.ContainsKey("unset_metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnNo
        {
            // Null should be interpreted as omitted for these properties
            AddTags = null,
            RemoveTags = null,
            SetMetadata = null,
            UnsetMetadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnNo
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        ExtensionItemAITasksTaskYesNoOnNo copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtensionItemAITasksTaskYesNoOnNoSetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnNoSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        string expectedField = "field";
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue expectedValue = "string";

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnNoSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnNoSetMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnNoSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnNoSetMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedField = "field";
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue expectedValue = "string";

        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnNoSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnNoSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        ExtensionItemAITasksTaskYesNoOnNoSetMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue value = true;
        value.Validate();
    }

    [Fact]
    public void MixedValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue value = new(
            [new ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem("string")]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MixedSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue value = new(
            [new ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem("string")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ExtensionItemAITasksTaskYesNoOnNoUnsetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata { Field = "field" };

        string expectedField = "field";

        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata { Field = "field" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata { Field = "field" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedField = "field";

        Assert.Equal(expectedField, deserialized.Field);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata { Field = "field" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata { Field = "field" };

        ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtensionItemAITasksTaskYesNoOnUnknownTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnUnknown
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata> expectedUnsetMetadata =
        [
            new("price_range"),
        ];

        Assert.NotNull(model.AddTags);
        Assert.Equal(expectedAddTags.Count, model.AddTags.Count);
        for (int i = 0; i < expectedAddTags.Count; i++)
        {
            Assert.Equal(expectedAddTags[i], model.AddTags[i]);
        }
        Assert.NotNull(model.RemoveTags);
        Assert.Equal(expectedRemoveTags.Count, model.RemoveTags.Count);
        for (int i = 0; i < expectedRemoveTags.Count; i++)
        {
            Assert.Equal(expectedRemoveTags[i], model.RemoveTags[i]);
        }
        Assert.NotNull(model.SetMetadata);
        Assert.Equal(expectedSetMetadata.Count, model.SetMetadata.Count);
        for (int i = 0; i < expectedSetMetadata.Count; i++)
        {
            Assert.Equal(expectedSetMetadata[i], model.SetMetadata[i]);
        }
        Assert.NotNull(model.UnsetMetadata);
        Assert.Equal(expectedUnsetMetadata.Count, model.UnsetMetadata.Count);
        for (int i = 0; i < expectedUnsetMetadata.Count; i++)
        {
            Assert.Equal(expectedUnsetMetadata[i], model.UnsetMetadata[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnUnknown
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnUnknown>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnUnknown
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnUnknown>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata> expectedUnsetMetadata =
        [
            new("price_range"),
        ];

        Assert.NotNull(deserialized.AddTags);
        Assert.Equal(expectedAddTags.Count, deserialized.AddTags.Count);
        for (int i = 0; i < expectedAddTags.Count; i++)
        {
            Assert.Equal(expectedAddTags[i], deserialized.AddTags[i]);
        }
        Assert.NotNull(deserialized.RemoveTags);
        Assert.Equal(expectedRemoveTags.Count, deserialized.RemoveTags.Count);
        for (int i = 0; i < expectedRemoveTags.Count; i++)
        {
            Assert.Equal(expectedRemoveTags[i], deserialized.RemoveTags[i]);
        }
        Assert.NotNull(deserialized.SetMetadata);
        Assert.Equal(expectedSetMetadata.Count, deserialized.SetMetadata.Count);
        for (int i = 0; i < expectedSetMetadata.Count; i++)
        {
            Assert.Equal(expectedSetMetadata[i], deserialized.SetMetadata[i]);
        }
        Assert.NotNull(deserialized.UnsetMetadata);
        Assert.Equal(expectedUnsetMetadata.Count, deserialized.UnsetMetadata.Count);
        for (int i = 0; i < expectedUnsetMetadata.Count; i++)
        {
            Assert.Equal(expectedUnsetMetadata[i], deserialized.UnsetMetadata[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnUnknown
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnUnknown { };

        Assert.Null(model.AddTags);
        Assert.False(model.RawData.ContainsKey("add_tags"));
        Assert.Null(model.RemoveTags);
        Assert.False(model.RawData.ContainsKey("remove_tags"));
        Assert.Null(model.SetMetadata);
        Assert.False(model.RawData.ContainsKey("set_metadata"));
        Assert.Null(model.UnsetMetadata);
        Assert.False(model.RawData.ContainsKey("unset_metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnUnknown { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnUnknown
        {
            // Null should be interpreted as omitted for these properties
            AddTags = null,
            RemoveTags = null,
            SetMetadata = null,
            UnsetMetadata = null,
        };

        Assert.Null(model.AddTags);
        Assert.False(model.RawData.ContainsKey("add_tags"));
        Assert.Null(model.RemoveTags);
        Assert.False(model.RawData.ContainsKey("remove_tags"));
        Assert.Null(model.SetMetadata);
        Assert.False(model.RawData.ContainsKey("set_metadata"));
        Assert.Null(model.UnsetMetadata);
        Assert.False(model.RawData.ContainsKey("unset_metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnUnknown
        {
            // Null should be interpreted as omitted for these properties
            AddTags = null,
            RemoveTags = null,
            SetMetadata = null,
            UnsetMetadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnUnknown
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        ExtensionItemAITasksTaskYesNoOnUnknown copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        string expectedField = "field";
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue expectedValue = "string";

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedField = "field";
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue expectedValue = "string";

        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue value = true;
        value.Validate();
    }

    [Fact]
    public void MixedValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue value = new(
            [new ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem("string")]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MixedSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue value = new(
            [new ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem("string")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata { Field = "field" };

        string expectedField = "field";

        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata { Field = "field" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata { Field = "field" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedField = "field";

        Assert.Equal(expectedField, deserialized.Field);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata { Field = "field" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata { Field = "field" };

        ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtensionItemAITasksTaskYesNoOnYesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnYes
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<ExtensionItemAITasksTaskYesNoOnYesSetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata> expectedUnsetMetadata =
        [
            new("price_range"),
        ];

        Assert.NotNull(model.AddTags);
        Assert.Equal(expectedAddTags.Count, model.AddTags.Count);
        for (int i = 0; i < expectedAddTags.Count; i++)
        {
            Assert.Equal(expectedAddTags[i], model.AddTags[i]);
        }
        Assert.NotNull(model.RemoveTags);
        Assert.Equal(expectedRemoveTags.Count, model.RemoveTags.Count);
        for (int i = 0; i < expectedRemoveTags.Count; i++)
        {
            Assert.Equal(expectedRemoveTags[i], model.RemoveTags[i]);
        }
        Assert.NotNull(model.SetMetadata);
        Assert.Equal(expectedSetMetadata.Count, model.SetMetadata.Count);
        for (int i = 0; i < expectedSetMetadata.Count; i++)
        {
            Assert.Equal(expectedSetMetadata[i], model.SetMetadata[i]);
        }
        Assert.NotNull(model.UnsetMetadata);
        Assert.Equal(expectedUnsetMetadata.Count, model.UnsetMetadata.Count);
        for (int i = 0; i < expectedUnsetMetadata.Count; i++)
        {
            Assert.Equal(expectedUnsetMetadata[i], model.UnsetMetadata[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnYes
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnYes>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnYes
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnYes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<ExtensionItemAITasksTaskYesNoOnYesSetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata> expectedUnsetMetadata =
        [
            new("price_range"),
        ];

        Assert.NotNull(deserialized.AddTags);
        Assert.Equal(expectedAddTags.Count, deserialized.AddTags.Count);
        for (int i = 0; i < expectedAddTags.Count; i++)
        {
            Assert.Equal(expectedAddTags[i], deserialized.AddTags[i]);
        }
        Assert.NotNull(deserialized.RemoveTags);
        Assert.Equal(expectedRemoveTags.Count, deserialized.RemoveTags.Count);
        for (int i = 0; i < expectedRemoveTags.Count; i++)
        {
            Assert.Equal(expectedRemoveTags[i], deserialized.RemoveTags[i]);
        }
        Assert.NotNull(deserialized.SetMetadata);
        Assert.Equal(expectedSetMetadata.Count, deserialized.SetMetadata.Count);
        for (int i = 0; i < expectedSetMetadata.Count; i++)
        {
            Assert.Equal(expectedSetMetadata[i], deserialized.SetMetadata[i]);
        }
        Assert.NotNull(deserialized.UnsetMetadata);
        Assert.Equal(expectedUnsetMetadata.Count, deserialized.UnsetMetadata.Count);
        for (int i = 0; i < expectedUnsetMetadata.Count; i++)
        {
            Assert.Equal(expectedUnsetMetadata[i], deserialized.UnsetMetadata[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnYes
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnYes { };

        Assert.Null(model.AddTags);
        Assert.False(model.RawData.ContainsKey("add_tags"));
        Assert.Null(model.RemoveTags);
        Assert.False(model.RawData.ContainsKey("remove_tags"));
        Assert.Null(model.SetMetadata);
        Assert.False(model.RawData.ContainsKey("set_metadata"));
        Assert.Null(model.UnsetMetadata);
        Assert.False(model.RawData.ContainsKey("unset_metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnYes { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnYes
        {
            // Null should be interpreted as omitted for these properties
            AddTags = null,
            RemoveTags = null,
            SetMetadata = null,
            UnsetMetadata = null,
        };

        Assert.Null(model.AddTags);
        Assert.False(model.RawData.ContainsKey("add_tags"));
        Assert.Null(model.RemoveTags);
        Assert.False(model.RawData.ContainsKey("remove_tags"));
        Assert.Null(model.SetMetadata);
        Assert.False(model.RawData.ContainsKey("set_metadata"));
        Assert.Null(model.UnsetMetadata);
        Assert.False(model.RawData.ContainsKey("unset_metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnYes
        {
            // Null should be interpreted as omitted for these properties
            AddTags = null,
            RemoveTags = null,
            SetMetadata = null,
            UnsetMetadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnYes
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        ExtensionItemAITasksTaskYesNoOnYes copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtensionItemAITasksTaskYesNoOnYesSetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnYesSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        string expectedField = "field";
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue expectedValue = "string";

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnYesSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnYesSetMetadata>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnYesSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnYesSetMetadata>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedField = "field";
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue expectedValue = "string";

        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnYesSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnYesSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        ExtensionItemAITasksTaskYesNoOnYesSetMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue value = true;
        value.Validate();
    }

    [Fact]
    public void MixedValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue value = new(
            [new ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem("string")]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MixedSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue value = new(
            [new ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem("string")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ExtensionItemAITasksTaskYesNoOnYesUnsetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata { Field = "field" };

        string expectedField = "field";

        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata { Field = "field" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata { Field = "field" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedField = "field";

        Assert.Equal(expectedField, deserialized.Field);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata { Field = "field" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata { Field = "field" };

        ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata copied = new(model);

        Assert.Equal(model, copied);
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
