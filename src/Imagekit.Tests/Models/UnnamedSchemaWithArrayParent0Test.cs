using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models;

namespace Imagekit.Tests.Models;

public class UnnamedSchemaWithArrayParent0Test : TestBase
{
    [Fact]
    public void RemoveBgValidationWorks()
    {
        UnnamedSchemaWithArrayParent0 value = new UnnamedSchemaWithArrayParent0RemoveBg()
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
        UnnamedSchemaWithArrayParent0 value =
            new UnnamedSchemaWithArrayParent0AutoTaggingExtension()
            {
                MaxTags = 0,
                MinConfidence = 0,
                Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
            };
        value.Validate();
    }

    [Fact]
    public void AIAutoDescriptionValidationWorks()
    {
        UnnamedSchemaWithArrayParent0 value = new UnnamedSchemaWithArrayParent0AIAutoDescription();
        value.Validate();
    }

    [Fact]
    public void AITasksValidationWorks()
    {
        UnnamedSchemaWithArrayParent0 value = new UnnamedSchemaWithArrayParent0AITasks(
            [
                new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
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
        UnnamedSchemaWithArrayParent0 value = new SavedExtension("ext_abc123");
        value.Validate();
    }

    [Fact]
    public void RemoveBgSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0 value = new UnnamedSchemaWithArrayParent0RemoveBg()
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
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutoTaggingExtensionSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0 value =
            new UnnamedSchemaWithArrayParent0AutoTaggingExtension()
            {
                MaxTags = 0,
                MinConfidence = 0,
                Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AIAutoDescriptionSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0 value = new UnnamedSchemaWithArrayParent0AIAutoDescription();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AITasksSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0 value = new UnnamedSchemaWithArrayParent0AITasks(
            [
                new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
                {
                    Instruction = "What types of clothing items are visible in this image?",
                    MaxSelections = 1,
                    MinSelections = 0,
                    Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SavedExtensionSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0 value = new SavedExtension("ext_abc123");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnnamedSchemaWithArrayParent0RemoveBgTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0RemoveBg
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
        UnnamedSchemaWithArrayParent0RemoveBgOptions expectedOptions = new()
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
        var model = new UnnamedSchemaWithArrayParent0RemoveBg
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
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0RemoveBg>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0RemoveBg
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
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0RemoveBg>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.SerializeToElement("remove-bg");
        UnnamedSchemaWithArrayParent0RemoveBgOptions expectedOptions = new()
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
        var model = new UnnamedSchemaWithArrayParent0RemoveBg
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
        var model = new UnnamedSchemaWithArrayParent0RemoveBg { };

        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0RemoveBg { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0RemoveBg
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
        var model = new UnnamedSchemaWithArrayParent0RemoveBg
        {
            // Null should be interpreted as omitted for these properties
            Options = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0RemoveBg
        {
            Options = new()
            {
                AddShadow = true,
                BgColor = "bg_color",
                BgImageUrl = "bg_image_url",
                Semitransparency = true,
            },
        };

        UnnamedSchemaWithArrayParent0RemoveBg copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnnamedSchemaWithArrayParent0RemoveBgOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0RemoveBgOptions
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
        var model = new UnnamedSchemaWithArrayParent0RemoveBgOptions
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0RemoveBgOptions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0RemoveBgOptions
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0RemoveBgOptions>(
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
        var model = new UnnamedSchemaWithArrayParent0RemoveBgOptions
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
        var model = new UnnamedSchemaWithArrayParent0RemoveBgOptions { };

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
        var model = new UnnamedSchemaWithArrayParent0RemoveBgOptions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0RemoveBgOptions
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
        var model = new UnnamedSchemaWithArrayParent0RemoveBgOptions
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
        var model = new UnnamedSchemaWithArrayParent0RemoveBgOptions
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        UnnamedSchemaWithArrayParent0RemoveBgOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnnamedSchemaWithArrayParent0AutoTaggingExtensionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AutoTaggingExtension
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
        };

        long expectedMaxTags = 0;
        long expectedMinConfidence = 0;
        ApiEnum<string, UnnamedSchemaWithArrayParent0AutoTaggingExtensionName> expectedName =
            UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging;

        Assert.Equal(expectedMaxTags, model.MaxTags);
        Assert.Equal(expectedMinConfidence, model.MinConfidence);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AutoTaggingExtension
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AutoTaggingExtension>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AutoTaggingExtension
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AutoTaggingExtension>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedMaxTags = 0;
        long expectedMinConfidence = 0;
        ApiEnum<string, UnnamedSchemaWithArrayParent0AutoTaggingExtensionName> expectedName =
            UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging;

        Assert.Equal(expectedMaxTags, deserialized.MaxTags);
        Assert.Equal(expectedMinConfidence, deserialized.MinConfidence);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AutoTaggingExtension
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AutoTaggingExtension
        {
            MaxTags = 0,
            MinConfidence = 0,
            Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
        };

        UnnamedSchemaWithArrayParent0AutoTaggingExtension copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnnamedSchemaWithArrayParent0AutoTaggingExtensionNameTest : TestBase
{
    [Theory]
    [InlineData(UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging)]
    [InlineData(UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.AwsAutoTagging)]
    public void Validation_Works(UnnamedSchemaWithArrayParent0AutoTaggingExtensionName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnnamedSchemaWithArrayParent0AutoTaggingExtensionName> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnnamedSchemaWithArrayParent0AutoTaggingExtensionName>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging)]
    [InlineData(UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.AwsAutoTagging)]
    public void SerializationRoundtrip_Works(
        UnnamedSchemaWithArrayParent0AutoTaggingExtensionName rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnnamedSchemaWithArrayParent0AutoTaggingExtensionName> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnnamedSchemaWithArrayParent0AutoTaggingExtensionName>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnnamedSchemaWithArrayParent0AutoTaggingExtensionName>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnnamedSchemaWithArrayParent0AutoTaggingExtensionName>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UnnamedSchemaWithArrayParent0AIAutoDescriptionTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new UnnamedSchemaWithArrayParent0AIAutoDescription();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AIAutoDescription>(
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
        var constant = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AIAutoDescription>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new UnnamedSchemaWithArrayParent0AIAutoDescription();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AIAutoDescription>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AIAutoDescription>(
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
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AIAutoDescription>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AIAutoDescription>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AIAutoDescription>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasks
        {
            Tasks =
            [
                new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
                {
                    Instruction = "What types of clothing items are visible in this image?",
                    MaxSelections = 1,
                    MinSelections = 0,
                    Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                },
            ],
        };

        JsonElement expectedName = JsonSerializer.SerializeToElement("ai-tasks");
        List<UnnamedSchemaWithArrayParent0AITasksTask> expectedTasks =
        [
            new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
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
        var model = new UnnamedSchemaWithArrayParent0AITasks
        {
            Tasks =
            [
                new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
                {
                    Instruction = "What types of clothing items are visible in this image?",
                    MaxSelections = 1,
                    MinSelections = 0,
                    Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasks>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasks
        {
            Tasks =
            [
                new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
                {
                    Instruction = "What types of clothing items are visible in this image?",
                    MaxSelections = 1,
                    MinSelections = 0,
                    Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasks>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.SerializeToElement("ai-tasks");
        List<UnnamedSchemaWithArrayParent0AITasksTask> expectedTasks =
        [
            new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
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
        var model = new UnnamedSchemaWithArrayParent0AITasks
        {
            Tasks =
            [
                new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
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
        var model = new UnnamedSchemaWithArrayParent0AITasks
        {
            Tasks =
            [
                new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
                {
                    Instruction = "What types of clothing items are visible in this image?",
                    MaxSelections = 1,
                    MinSelections = 0,
                    Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                },
            ],
        };

        UnnamedSchemaWithArrayParent0AITasks copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskTest : TestBase
{
    [Fact]
    public void SelectTagsValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTask value =
            new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
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
        UnnamedSchemaWithArrayParent0AITasksTask value =
            new UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata()
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
        UnnamedSchemaWithArrayParent0AITasksTask value =
            new UnnamedSchemaWithArrayParent0AITasksTaskYesNo()
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
        UnnamedSchemaWithArrayParent0AITasksTask value =
            new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
            {
                Instruction = "What types of clothing items are visible in this image?",
                MaxSelections = 1,
                MinSelections = 0,
                Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTask>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SelectMetadataSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTask value =
            new UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata()
            {
                Field = "primary_color",
                Instruction = "What is the primary color of the clothing?",
                MaxSelections = 1,
                MinSelections = 0,
                Vocabulary = ["red", "blue", "green", "black", "white"],
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTask>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void YesNoSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTask value =
            new UnnamedSchemaWithArrayParent0AITasksTaskYesNo()
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
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTask>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskSelectTagsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags
        {
            Instruction = "What types of clothing items are visible in this image?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskSelectTags>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags
        {
            Instruction = "What types of clothing items are visible in this image?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskSelectTags>(
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags
        {
            Instruction = "What types of clothing items are visible in this image?",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags
        {
            Instruction = "What types of clothing items are visible in this image?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
        };

        UnnamedSchemaWithArrayParent0AITasksTaskSelectTags copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata
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
        List<UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary> expectedVocabulary =
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["red", "blue", "green", "black", "white"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["red", "blue", "green", "black", "white"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedField = "primary_color";
        string expectedInstruction = "What is the primary color of the clothing?";
        JsonElement expectedType = JsonSerializer.SerializeToElement("select_metadata");
        long expectedMaxSelections = 1;
        long expectedMinSelections = 0;
        List<UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary> expectedVocabulary =
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata
        {
            Field = "primary_color",
            Instruction = "What is the primary color of the clothing?",
            MaxSelections = 1,
            MinSelections = 0,
            Vocabulary = ["red", "blue", "green", "black", "white"],
        };

        UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabularyTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskYesNoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNo
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
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo expectedOnNo = new()
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown expectedOnUnknown = new()
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes expectedOnYes = new()
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNo
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
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNo>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNo
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
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNo>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedInstruction = "Is this a luxury or high-end fashion item?";
        JsonElement expectedType = JsonSerializer.SerializeToElement("yes_no");
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo expectedOnNo = new()
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown expectedOnUnknown = new()
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes expectedOnYes = new()
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNo
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNo
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNo
        {
            Instruction = "Is this a luxury or high-end fashion item?",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNo
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNo
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNo
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

        UnnamedSchemaWithArrayParent0AITasksTaskYesNo copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata> expectedUnsetMetadata =
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata> expectedUnsetMetadata =
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo { };

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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        string expectedField = "field";
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue expectedValue = "string";

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedField = "field";
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue expectedValue = "string";

        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue value = true;
        value.Validate();
    }

    [Fact]
    public void MixedValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue value = new(
            [
                new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem(
                    "string"
                ),
            ]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MixedSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue value = new(
            [
                new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem(
                    "string"
                ),
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValueMetadataValueItemTest
    : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem value =
            "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem value =
            0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem value =
            true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem value =
            "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem value =
            0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem value =
            true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata
        {
            Field = "field",
        };

        string expectedField = "field";

        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata
        {
            Field = "field",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata
        {
            Field = "field",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata>(
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata
        {
            Field = "field",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata
        {
            Field = "field",
        };

        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata> expectedUnsetMetadata =
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata> expectedUnsetMetadata =
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown { };

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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        string expectedField = "field";
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue expectedValue =
            "string";

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedField = "field";
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue expectedValue =
            "string";

        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue value = true;
        value.Validate();
    }

    [Fact]
    public void MixedValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue value = new(
            [
                new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem(
                    "string"
                ),
            ]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MixedSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue value = new(
            [
                new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem(
                    "string"
                ),
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItemTest
    : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem value =
            "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem value =
            0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem value =
            true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem value =
            "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem value =
            0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem value =
            true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata
        {
            Field = "field",
        };

        string expectedField = "field";

        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata
        {
            Field = "field",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata
        {
            Field = "field",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata>(
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata
        {
            Field = "field",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata
        {
            Field = "field",
        };

        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata> expectedUnsetMetadata =
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata> expectedUnsetMetadata =
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes { };

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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        string expectedField = "field";
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue expectedValue = "string";

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedField = "field";
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue expectedValue = "string";

        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata
        {
            Field = "field",
            Value = "string",
        };

        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue value = true;
        value.Validate();
    }

    [Fact]
    public void MixedValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue value = new(
            [
                new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem(
                    "string"
                ),
            ]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MixedSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue value = new(
            [
                new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem(
                    "string"
                ),
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValueMetadataValueItemTest
    : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem value =
            "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem value =
            0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem value =
            true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem value =
            "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem value =
            0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem value =
            true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata
        {
            Field = "field",
        };

        string expectedField = "field";

        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata
        {
            Field = "field",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata
        {
            Field = "field",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata>(
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
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata
        {
            Field = "field",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata
        {
            Field = "field",
        };

        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata copied = new(model);

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
