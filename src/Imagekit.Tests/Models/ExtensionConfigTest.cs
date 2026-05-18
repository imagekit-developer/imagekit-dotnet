using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models;

namespace Imagekit.Tests.Models;

public class ExtensionConfigTest : TestBase
{
    [Fact]
    public void RemoveBgValidationWorks()
    {
        ExtensionConfig value = new RemoveBg()
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
    public void AIAutoDescriptionValidationWorks()
    {
        ExtensionConfig value = new AIAutoDescription();
        value.Validate();
    }

    [Fact]
    public void AITasksValidationWorks()
    {
        ExtensionConfig value = new AITasks(
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
    public void RemoveBgSerializationRoundtripWorks()
    {
        ExtensionConfig value = new RemoveBg()
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
    public void AIAutoDescriptionSerializationRoundtripWorks()
    {
        ExtensionConfig value = new AIAutoDescription();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AITasksSerializationRoundtripWorks()
    {
        ExtensionConfig value = new AITasks(
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

public class RemoveBgTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RemoveBg
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
        Options expectedOptions = new()
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
        var model = new RemoveBg
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
        var deserialized = JsonSerializer.Deserialize<RemoveBg>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RemoveBg
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
        var deserialized = JsonSerializer.Deserialize<RemoveBg>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.SerializeToElement("remove-bg");
        Options expectedOptions = new()
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
        var model = new RemoveBg
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
        var model = new RemoveBg { };

        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RemoveBg { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RemoveBg
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
        var model = new RemoveBg
        {
            // Null should be interpreted as omitted for these properties
            Options = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RemoveBg
        {
            Options = new()
            {
                AddShadow = true,
                BgColor = "bg_color",
                BgImageUrl = "bg_image_url",
                Semitransparency = true,
            },
        };

        RemoveBg copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Options
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
        var model = new Options
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Options>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Options
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Options>(
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
        var model = new Options
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
        var model = new Options { };

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
        var model = new Options { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Options
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
        var model = new Options
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
        var model = new Options
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        Options copied = new(model);

        Assert.Equal(model, copied);
    }
}

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
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
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

public class AIAutoDescriptionTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new AIAutoDescription();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<AIAutoDescription>(
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
        var constant = JsonSerializer.Deserialize<AIAutoDescription>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new AIAutoDescription();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AIAutoDescription>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<AIAutoDescription>(
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
        var deserialized = JsonSerializer.Deserialize<AIAutoDescription>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<AIAutoDescription>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AIAutoDescription>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class AITasksTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AITasks
        {
            Tasks =
            [
                new SelectTags()
                {
                    Instruction = "What types of clothing items are visible in this image?",
                    MaxSelections = 1,
                    MinSelections = 0,
                    Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                },
            ],
        };

        JsonElement expectedName = JsonSerializer.SerializeToElement("ai-tasks");
        List<Task> expectedTasks =
        [
            new SelectTags()
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
        var model = new AITasks
        {
            Tasks =
            [
                new SelectTags()
                {
                    Instruction = "What types of clothing items are visible in this image?",
                    MaxSelections = 1,
                    MinSelections = 0,
                    Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AITasks>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AITasks
        {
            Tasks =
            [
                new SelectTags()
                {
                    Instruction = "What types of clothing items are visible in this image?",
                    MaxSelections = 1,
                    MinSelections = 0,
                    Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AITasks>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.SerializeToElement("ai-tasks");
        List<Task> expectedTasks =
        [
            new SelectTags()
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
        var model = new AITasks
        {
            Tasks =
            [
                new SelectTags()
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
        var model = new AITasks
        {
            Tasks =
            [
                new SelectTags()
                {
                    Instruction = "What types of clothing items are visible in this image?",
                    MaxSelections = 1,
                    MinSelections = 0,
                    Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                },
            ],
        };

        AITasks copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TaskTest : TestBase
{
    [Fact]
    public void SelectTagsValidationWorks()
    {
        Task value = new SelectTags()
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
        Task value = new SelectMetadata()
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
        Task value = new YesNo()
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
        Task value = new SelectTags()
        {
            Instruction = "What types of clothing items are visible in this image?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Task>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SelectMetadataSerializationRoundtripWorks()
    {
        Task value = new SelectMetadata()
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["red", "blue", "green", "black", "white"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Task>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void YesNoSerializationRoundtripWorks()
    {
        Task value = new YesNo()
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
        var deserialized = JsonSerializer.Deserialize<Task>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SelectTagsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SelectTags
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
        var model = new SelectTags
        {
            Instruction = "What types of clothing items are visible in this image?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SelectTags>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SelectTags
        {
            Instruction = "What types of clothing items are visible in this image?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SelectTags>(
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
        var model = new SelectTags
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
        var model = new SelectTags
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
        var model = new SelectTags
        {
            Instruction = "What types of clothing items are visible in this image?",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SelectTags
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
        var model = new SelectTags
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
        var model = new SelectTags
        {
            Instruction = "What types of clothing items are visible in this image?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
        };

        SelectTags copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SelectMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SelectMetadata
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
        List<Vocabulary> expectedVocabulary = ["red", "blue", "green", "black", "white"];

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
        var model = new SelectMetadata
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["red", "blue", "green", "black", "white"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SelectMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SelectMetadata
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["red", "blue", "green", "black", "white"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SelectMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedField = "primary_color";
        string expectedInstruction = "What is the primary color of the clothing?";
        JsonElement expectedType = JsonSerializer.SerializeToElement("select_metadata");
        long expectedMaxSelections = 1;
        long expectedMinSelections = 0;
        List<Vocabulary> expectedVocabulary = ["red", "blue", "green", "black", "white"];

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
        var model = new SelectMetadata
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
        var model = new SelectMetadata
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
        var model = new SelectMetadata
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SelectMetadata
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
        var model = new SelectMetadata
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
        var model = new SelectMetadata
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["red", "blue", "green", "black", "white"],
        };

        SelectMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VocabularyTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Vocabulary value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        Vocabulary value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        Vocabulary value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Vocabulary value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Vocabulary>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Vocabulary value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Vocabulary>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        Vocabulary value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Vocabulary>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class YesNoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new YesNo
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
        OnNo expectedOnNo = new()
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };
        OnUnknown expectedOnUnknown = new()
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };
        OnYes expectedOnYes = new()
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
        var model = new YesNo
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
        var deserialized = JsonSerializer.Deserialize<YesNo>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new YesNo
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
        var deserialized = JsonSerializer.Deserialize<YesNo>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedInstruction = "Is this a luxury or high-end fashion item?";
        JsonElement expectedType = JsonSerializer.SerializeToElement("yes_no");
        OnNo expectedOnNo = new()
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };
        OnUnknown expectedOnUnknown = new()
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };
        OnYes expectedOnYes = new()
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
        var model = new YesNo
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
        var model = new YesNo { Instruction = "Is this a luxury or high-end fashion item?" };

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
        var model = new YesNo { Instruction = "Is this a luxury or high-end fashion item?" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new YesNo
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
        var model = new YesNo
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
        var model = new YesNo
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

        YesNo copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OnNoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OnNo
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<SetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<UnsetMetadata> expectedUnsetMetadata = [new("price_range")];

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
        var model = new OnNo
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnNo>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OnNo
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnNo>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<SetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<UnsetMetadata> expectedUnsetMetadata = [new("price_range")];

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
        var model = new OnNo
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
        var model = new OnNo { };

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
        var model = new OnNo { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OnNo
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
        var model = new OnNo
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
        var model = new OnNo
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        OnNo copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetMetadata { Field = "field", Value = "string" };

        string expectedField = "field";
        SetMetadataValue expectedValue = "string";

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SetMetadata { Field = "field", Value = "string" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetMetadata { Field = "field", Value = "string" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedField = "field";
        SetMetadataValue expectedValue = "string";

        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SetMetadata { Field = "field", Value = "string" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SetMetadata { Field = "field", Value = "string" };

        SetMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetMetadataValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        SetMetadataValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        SetMetadataValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        SetMetadataValue value = true;
        value.Validate();
    }

    [Fact]
    public void MixedValidationWorks()
    {
        SetMetadataValue value = new([new MetadataValueItem("string")]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        SetMetadataValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetMetadataValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        SetMetadataValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetMetadataValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        SetMetadataValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetMetadataValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MixedSerializationRoundtripWorks()
    {
        SetMetadataValue value = new([new MetadataValueItem("string")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetMetadataValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MetadataValueItemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        MetadataValueItem value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        MetadataValueItem value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        MetadataValueItem value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MetadataValueItem value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetadataValueItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        MetadataValueItem value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetadataValueItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        MetadataValueItem value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetadataValueItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnsetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnsetMetadata { Field = "field" };

        string expectedField = "field";

        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnsetMetadata { Field = "field" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsetMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnsetMetadata { Field = "field" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsetMetadata>(
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
        var model = new UnsetMetadata { Field = "field" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnsetMetadata { Field = "field" };

        UnsetMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OnUnknownTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OnUnknown
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<OnUnknownSetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<OnUnknownUnsetMetadata> expectedUnsetMetadata = [new("price_range")];

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
        var model = new OnUnknown
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnUnknown>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OnUnknown
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnUnknown>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<OnUnknownSetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<OnUnknownUnsetMetadata> expectedUnsetMetadata = [new("price_range")];

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
        var model = new OnUnknown
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
        var model = new OnUnknown { };

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
        var model = new OnUnknown { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OnUnknown
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
        var model = new OnUnknown
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
        var model = new OnUnknown
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        OnUnknown copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OnUnknownSetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OnUnknownSetMetadata { Field = "field", Value = "string" };

        string expectedField = "field";
        OnUnknownSetMetadataValue expectedValue = "string";

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OnUnknownSetMetadata { Field = "field", Value = "string" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnUnknownSetMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OnUnknownSetMetadata { Field = "field", Value = "string" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnUnknownSetMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedField = "field";
        OnUnknownSetMetadataValue expectedValue = "string";

        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OnUnknownSetMetadata { Field = "field", Value = "string" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OnUnknownSetMetadata { Field = "field", Value = "string" };

        OnUnknownSetMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OnUnknownSetMetadataValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        OnUnknownSetMetadataValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        OnUnknownSetMetadataValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        OnUnknownSetMetadataValue value = true;
        value.Validate();
    }

    [Fact]
    public void MixedValidationWorks()
    {
        OnUnknownSetMetadataValue value = new(
            [new OnUnknownSetMetadataValueMetadataValueItem("string")]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        OnUnknownSetMetadataValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnUnknownSetMetadataValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        OnUnknownSetMetadataValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnUnknownSetMetadataValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        OnUnknownSetMetadataValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnUnknownSetMetadataValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MixedSerializationRoundtripWorks()
    {
        OnUnknownSetMetadataValue value = new(
            [new OnUnknownSetMetadataValueMetadataValueItem("string")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnUnknownSetMetadataValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OnUnknownSetMetadataValueMetadataValueItemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        OnUnknownSetMetadataValueMetadataValueItem value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        OnUnknownSetMetadataValueMetadataValueItem value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        OnUnknownSetMetadataValueMetadataValueItem value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        OnUnknownSetMetadataValueMetadataValueItem value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnUnknownSetMetadataValueMetadataValueItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        OnUnknownSetMetadataValueMetadataValueItem value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnUnknownSetMetadataValueMetadataValueItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        OnUnknownSetMetadataValueMetadataValueItem value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnUnknownSetMetadataValueMetadataValueItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OnUnknownUnsetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OnUnknownUnsetMetadata { Field = "field" };

        string expectedField = "field";

        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OnUnknownUnsetMetadata { Field = "field" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnUnknownUnsetMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OnUnknownUnsetMetadata { Field = "field" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnUnknownUnsetMetadata>(
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
        var model = new OnUnknownUnsetMetadata { Field = "field" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OnUnknownUnsetMetadata { Field = "field" };

        OnUnknownUnsetMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OnYesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OnYes
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<OnYesSetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<OnYesUnsetMetadata> expectedUnsetMetadata = [new("price_range")];

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
        var model = new OnYes
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnYes>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OnYes
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnYes>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<OnYesSetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<OnYesUnsetMetadata> expectedUnsetMetadata = [new("price_range")];

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
        var model = new OnYes
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
        var model = new OnYes { };

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
        var model = new OnYes { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OnYes
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
        var model = new OnYes
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
        var model = new OnYes
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        OnYes copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OnYesSetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OnYesSetMetadata { Field = "field", Value = "string" };

        string expectedField = "field";
        OnYesSetMetadataValue expectedValue = "string";

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OnYesSetMetadata { Field = "field", Value = "string" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnYesSetMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OnYesSetMetadata { Field = "field", Value = "string" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnYesSetMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedField = "field";
        OnYesSetMetadataValue expectedValue = "string";

        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OnYesSetMetadata { Field = "field", Value = "string" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OnYesSetMetadata { Field = "field", Value = "string" };

        OnYesSetMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OnYesSetMetadataValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        OnYesSetMetadataValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        OnYesSetMetadataValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        OnYesSetMetadataValue value = true;
        value.Validate();
    }

    [Fact]
    public void MixedValidationWorks()
    {
        OnYesSetMetadataValue value = new([new OnYesSetMetadataValueMetadataValueItem("string")]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        OnYesSetMetadataValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnYesSetMetadataValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        OnYesSetMetadataValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnYesSetMetadataValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        OnYesSetMetadataValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnYesSetMetadataValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MixedSerializationRoundtripWorks()
    {
        OnYesSetMetadataValue value = new([new OnYesSetMetadataValueMetadataValueItem("string")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnYesSetMetadataValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OnYesSetMetadataValueMetadataValueItemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        OnYesSetMetadataValueMetadataValueItem value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        OnYesSetMetadataValueMetadataValueItem value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        OnYesSetMetadataValueMetadataValueItem value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        OnYesSetMetadataValueMetadataValueItem value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnYesSetMetadataValueMetadataValueItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        OnYesSetMetadataValueMetadataValueItem value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnYesSetMetadataValueMetadataValueItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        OnYesSetMetadataValueMetadataValueItem value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnYesSetMetadataValueMetadataValueItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OnYesUnsetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OnYesUnsetMetadata { Field = "field" };

        string expectedField = "field";

        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OnYesUnsetMetadata { Field = "field" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnYesUnsetMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OnYesUnsetMetadata { Field = "field" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OnYesUnsetMetadata>(
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
        var model = new OnYesUnsetMetadata { Field = "field" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OnYesUnsetMetadata { Field = "field" };

        OnYesUnsetMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
