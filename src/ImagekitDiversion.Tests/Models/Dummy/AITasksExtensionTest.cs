using System.Collections.Generic;
using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Dummy;

namespace ImagekitDiversion.Tests.Models.Dummy;

public class AITasksExtensionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AITasksExtension
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
        var model = new AITasksExtension
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
        var deserialized = JsonSerializer.Deserialize<AITasksExtension>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AITasksExtension
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
        var deserialized = JsonSerializer.Deserialize<AITasksExtension>(
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
        var model = new AITasksExtension
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
        var model = new AITasksExtension
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

        AITasksExtension copied = new(model);

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
        AITaskAction expectedOnNo = new()
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };
        AITaskAction expectedOnUnknown = new()
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };
        AITaskAction expectedOnYes = new()
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
        AITaskAction expectedOnNo = new()
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };
        AITaskAction expectedOnUnknown = new()
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };
        AITaskAction expectedOnYes = new()
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
