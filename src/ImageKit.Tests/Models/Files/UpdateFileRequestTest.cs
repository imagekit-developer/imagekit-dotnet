using System.Collections.Generic;
using System.Text.Json;
using ImageKit.Core;
using ImageKit.Exceptions;
using ImageKit.Models;
using Files = ImageKit.Models.Files;

namespace ImageKit.Tests.Models.Files;

public class UpdateFileRequestTest : TestBase
{
    [Fact]
    public void DetailsValidationWorks()
    {
        Files::UpdateFileRequest value = new Files::UpdateFileDetails()
        {
            CustomCoordinates = "customCoordinates",
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            Extensions =
            [
                new UnnamedSchemaWithArrayParent0RemoveBg()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                new UnnamedSchemaWithArrayParent0AutoTaggingExtension()
                {
                    MaxTags = 5,
                    MinConfidence = 95,
                    Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
                },
                new UnnamedSchemaWithArrayParent0AIAutoDescription(),
                new UnnamedSchemaWithArrayParent0AITasks(
                    [
                        new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
                        {
                            Instruction = "What types of clothing items are visible in this image?",
                            MaxSelections = 1,
                            MinSelections = 0,
                            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                        },
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
                        },
                    ]
                ),
                new SavedExtension("ext_abc123"),
            ],
            RemoveAITags = new Files::UnionMember1(),
            Tags = ["tag1", "tag2"],
            WebhookUrl = "https://example.com",
        };
        value.Validate();
    }

    [Fact]
    public void ChangePublicationStatusValidationWorks()
    {
        Files::UpdateFileRequest value = new Files::ChangePublicationStatus()
        {
            Publish = new() { IsPublished = true, IncludeFileVersions = true },
        };
        value.Validate();
    }

    [Fact]
    public void DetailsSerializationRoundtripWorks()
    {
        Files::UpdateFileRequest value = new Files::UpdateFileDetails()
        {
            CustomCoordinates = "customCoordinates",
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            Extensions =
            [
                new UnnamedSchemaWithArrayParent0RemoveBg()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                new UnnamedSchemaWithArrayParent0AutoTaggingExtension()
                {
                    MaxTags = 5,
                    MinConfidence = 95,
                    Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
                },
                new UnnamedSchemaWithArrayParent0AIAutoDescription(),
                new UnnamedSchemaWithArrayParent0AITasks(
                    [
                        new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
                        {
                            Instruction = "What types of clothing items are visible in this image?",
                            MaxSelections = 1,
                            MinSelections = 0,
                            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                        },
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
                        },
                    ]
                ),
                new SavedExtension("ext_abc123"),
            ],
            RemoveAITags = new Files::UnionMember1(),
            Tags = ["tag1", "tag2"],
            WebhookUrl = "https://example.com",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::UpdateFileRequest>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChangePublicationStatusSerializationRoundtripWorks()
    {
        Files::UpdateFileRequest value = new Files::ChangePublicationStatus()
        {
            Publish = new() { IsPublished = true, IncludeFileVersions = true },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::UpdateFileRequest>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UpdateFileDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Files::UpdateFileDetails
        {
            CustomCoordinates = "customCoordinates",
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            Extensions =
            [
                new UnnamedSchemaWithArrayParent0RemoveBg()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                new UnnamedSchemaWithArrayParent0AutoTaggingExtension()
                {
                    MaxTags = 5,
                    MinConfidence = 95,
                    Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
                },
                new UnnamedSchemaWithArrayParent0AIAutoDescription(),
                new UnnamedSchemaWithArrayParent0AITasks(
                    [
                        new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
                        {
                            Instruction = "What types of clothing items are visible in this image?",
                            MaxSelections = 1,
                            MinSelections = 0,
                            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                        },
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
                        },
                    ]
                ),
                new SavedExtension("ext_abc123"),
            ],
            RemoveAITags = new Files::UnionMember1(),
            Tags = ["tag1", "tag2"],
            WebhookUrl = "https://example.com",
        };

        string expectedCustomCoordinates = "customCoordinates";
        Dictionary<string, JsonElement> expectedCustomMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedDescription = "description";
        List<UnnamedSchemaWithArrayParent0> expectedExtensions =
        [
            new UnnamedSchemaWithArrayParent0RemoveBg()
            {
                Options = new()
                {
                    AddShadow = true,
                    BgColor = "bg_color",
                    BgImageUrl = "bg_image_url",
                    Semitransparency = true,
                },
            },
            new UnnamedSchemaWithArrayParent0AutoTaggingExtension()
            {
                MaxTags = 5,
                MinConfidence = 95,
                Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
            },
            new UnnamedSchemaWithArrayParent0AIAutoDescription(),
            new UnnamedSchemaWithArrayParent0AITasks(
                [
                    new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
                    {
                        Instruction = "What types of clothing items are visible in this image?",
                        MaxSelections = 1,
                        MinSelections = 0,
                        Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                    },
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
                    },
                ]
            ),
            new SavedExtension("ext_abc123"),
        ];
        Files::RemoveAITags expectedRemoveAITags = new Files::UnionMember1();
        List<string> expectedTags = ["tag1", "tag2"];
        string expectedWebhookUrl = "https://example.com";

        Assert.Equal(expectedCustomCoordinates, model.CustomCoordinates);
        Assert.NotNull(model.CustomMetadata);
        Assert.Equal(expectedCustomMetadata.Count, model.CustomMetadata.Count);
        foreach (var item in expectedCustomMetadata)
        {
            Assert.True(model.CustomMetadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.CustomMetadata[item.Key]));
        }
        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.Extensions);
        Assert.Equal(expectedExtensions.Count, model.Extensions.Count);
        for (int i = 0; i < expectedExtensions.Count; i++)
        {
            Assert.Equal(expectedExtensions[i], model.Extensions[i]);
        }
        Assert.Equal(expectedRemoveAITags, model.RemoveAITags);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedWebhookUrl, model.WebhookUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Files::UpdateFileDetails
        {
            CustomCoordinates = "customCoordinates",
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            Extensions =
            [
                new UnnamedSchemaWithArrayParent0RemoveBg()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                new UnnamedSchemaWithArrayParent0AutoTaggingExtension()
                {
                    MaxTags = 5,
                    MinConfidence = 95,
                    Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
                },
                new UnnamedSchemaWithArrayParent0AIAutoDescription(),
                new UnnamedSchemaWithArrayParent0AITasks(
                    [
                        new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
                        {
                            Instruction = "What types of clothing items are visible in this image?",
                            MaxSelections = 1,
                            MinSelections = 0,
                            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                        },
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
                        },
                    ]
                ),
                new SavedExtension("ext_abc123"),
            ],
            RemoveAITags = new Files::UnionMember1(),
            Tags = ["tag1", "tag2"],
            WebhookUrl = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::UpdateFileDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Files::UpdateFileDetails
        {
            CustomCoordinates = "customCoordinates",
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            Extensions =
            [
                new UnnamedSchemaWithArrayParent0RemoveBg()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                new UnnamedSchemaWithArrayParent0AutoTaggingExtension()
                {
                    MaxTags = 5,
                    MinConfidence = 95,
                    Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
                },
                new UnnamedSchemaWithArrayParent0AIAutoDescription(),
                new UnnamedSchemaWithArrayParent0AITasks(
                    [
                        new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
                        {
                            Instruction = "What types of clothing items are visible in this image?",
                            MaxSelections = 1,
                            MinSelections = 0,
                            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                        },
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
                        },
                    ]
                ),
                new SavedExtension("ext_abc123"),
            ],
            RemoveAITags = new Files::UnionMember1(),
            Tags = ["tag1", "tag2"],
            WebhookUrl = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::UpdateFileDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCustomCoordinates = "customCoordinates";
        Dictionary<string, JsonElement> expectedCustomMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedDescription = "description";
        List<UnnamedSchemaWithArrayParent0> expectedExtensions =
        [
            new UnnamedSchemaWithArrayParent0RemoveBg()
            {
                Options = new()
                {
                    AddShadow = true,
                    BgColor = "bg_color",
                    BgImageUrl = "bg_image_url",
                    Semitransparency = true,
                },
            },
            new UnnamedSchemaWithArrayParent0AutoTaggingExtension()
            {
                MaxTags = 5,
                MinConfidence = 95,
                Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
            },
            new UnnamedSchemaWithArrayParent0AIAutoDescription(),
            new UnnamedSchemaWithArrayParent0AITasks(
                [
                    new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
                    {
                        Instruction = "What types of clothing items are visible in this image?",
                        MaxSelections = 1,
                        MinSelections = 0,
                        Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                    },
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
                    },
                ]
            ),
            new SavedExtension("ext_abc123"),
        ];
        Files::RemoveAITags expectedRemoveAITags = new Files::UnionMember1();
        List<string> expectedTags = ["tag1", "tag2"];
        string expectedWebhookUrl = "https://example.com";

        Assert.Equal(expectedCustomCoordinates, deserialized.CustomCoordinates);
        Assert.NotNull(deserialized.CustomMetadata);
        Assert.Equal(expectedCustomMetadata.Count, deserialized.CustomMetadata.Count);
        foreach (var item in expectedCustomMetadata)
        {
            Assert.True(deserialized.CustomMetadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.CustomMetadata[item.Key]));
        }
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.Extensions);
        Assert.Equal(expectedExtensions.Count, deserialized.Extensions.Count);
        for (int i = 0; i < expectedExtensions.Count; i++)
        {
            Assert.Equal(expectedExtensions[i], deserialized.Extensions[i]);
        }
        Assert.Equal(expectedRemoveAITags, deserialized.RemoveAITags);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedWebhookUrl, deserialized.WebhookUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Files::UpdateFileDetails
        {
            CustomCoordinates = "customCoordinates",
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            Extensions =
            [
                new UnnamedSchemaWithArrayParent0RemoveBg()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                new UnnamedSchemaWithArrayParent0AutoTaggingExtension()
                {
                    MaxTags = 5,
                    MinConfidence = 95,
                    Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
                },
                new UnnamedSchemaWithArrayParent0AIAutoDescription(),
                new UnnamedSchemaWithArrayParent0AITasks(
                    [
                        new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
                        {
                            Instruction = "What types of clothing items are visible in this image?",
                            MaxSelections = 1,
                            MinSelections = 0,
                            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                        },
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
                        },
                    ]
                ),
                new SavedExtension("ext_abc123"),
            ],
            RemoveAITags = new Files::UnionMember1(),
            Tags = ["tag1", "tag2"],
            WebhookUrl = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Files::UpdateFileDetails
        {
            CustomCoordinates = "customCoordinates",
            Tags = ["tag1", "tag2"],
        };

        Assert.Null(model.CustomMetadata);
        Assert.False(model.RawData.ContainsKey("customMetadata"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Extensions);
        Assert.False(model.RawData.ContainsKey("extensions"));
        Assert.Null(model.RemoveAITags);
        Assert.False(model.RawData.ContainsKey("removeAITags"));
        Assert.Null(model.WebhookUrl);
        Assert.False(model.RawData.ContainsKey("webhookUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Files::UpdateFileDetails
        {
            CustomCoordinates = "customCoordinates",
            Tags = ["tag1", "tag2"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Files::UpdateFileDetails
        {
            CustomCoordinates = "customCoordinates",
            Tags = ["tag1", "tag2"],

            // Null should be interpreted as omitted for these properties
            CustomMetadata = null,
            Description = null,
            Extensions = null,
            RemoveAITags = null,
            WebhookUrl = null,
        };

        Assert.Null(model.CustomMetadata);
        Assert.False(model.RawData.ContainsKey("customMetadata"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Extensions);
        Assert.False(model.RawData.ContainsKey("extensions"));
        Assert.Null(model.RemoveAITags);
        Assert.False(model.RawData.ContainsKey("removeAITags"));
        Assert.Null(model.WebhookUrl);
        Assert.False(model.RawData.ContainsKey("webhookUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Files::UpdateFileDetails
        {
            CustomCoordinates = "customCoordinates",
            Tags = ["tag1", "tag2"],

            // Null should be interpreted as omitted for these properties
            CustomMetadata = null,
            Description = null,
            Extensions = null,
            RemoveAITags = null,
            WebhookUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Files::UpdateFileDetails
        {
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            Extensions =
            [
                new UnnamedSchemaWithArrayParent0RemoveBg()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                new UnnamedSchemaWithArrayParent0AutoTaggingExtension()
                {
                    MaxTags = 5,
                    MinConfidence = 95,
                    Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
                },
                new UnnamedSchemaWithArrayParent0AIAutoDescription(),
                new UnnamedSchemaWithArrayParent0AITasks(
                    [
                        new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
                        {
                            Instruction = "What types of clothing items are visible in this image?",
                            MaxSelections = 1,
                            MinSelections = 0,
                            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                        },
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
                        },
                    ]
                ),
                new SavedExtension("ext_abc123"),
            ],
            RemoveAITags = new Files::UnionMember1(),
            WebhookUrl = "https://example.com",
        };

        Assert.Null(model.CustomCoordinates);
        Assert.False(model.RawData.ContainsKey("customCoordinates"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Files::UpdateFileDetails
        {
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            Extensions =
            [
                new UnnamedSchemaWithArrayParent0RemoveBg()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                new UnnamedSchemaWithArrayParent0AutoTaggingExtension()
                {
                    MaxTags = 5,
                    MinConfidence = 95,
                    Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
                },
                new UnnamedSchemaWithArrayParent0AIAutoDescription(),
                new UnnamedSchemaWithArrayParent0AITasks(
                    [
                        new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
                        {
                            Instruction = "What types of clothing items are visible in this image?",
                            MaxSelections = 1,
                            MinSelections = 0,
                            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                        },
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
                        },
                    ]
                ),
                new SavedExtension("ext_abc123"),
            ],
            RemoveAITags = new Files::UnionMember1(),
            WebhookUrl = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Files::UpdateFileDetails
        {
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            Extensions =
            [
                new UnnamedSchemaWithArrayParent0RemoveBg()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                new UnnamedSchemaWithArrayParent0AutoTaggingExtension()
                {
                    MaxTags = 5,
                    MinConfidence = 95,
                    Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
                },
                new UnnamedSchemaWithArrayParent0AIAutoDescription(),
                new UnnamedSchemaWithArrayParent0AITasks(
                    [
                        new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
                        {
                            Instruction = "What types of clothing items are visible in this image?",
                            MaxSelections = 1,
                            MinSelections = 0,
                            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                        },
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
                        },
                    ]
                ),
                new SavedExtension("ext_abc123"),
            ],
            RemoveAITags = new Files::UnionMember1(),
            WebhookUrl = "https://example.com",

            CustomCoordinates = null,
            Tags = null,
        };

        Assert.Null(model.CustomCoordinates);
        Assert.True(model.RawData.ContainsKey("customCoordinates"));
        Assert.Null(model.Tags);
        Assert.True(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Files::UpdateFileDetails
        {
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            Extensions =
            [
                new UnnamedSchemaWithArrayParent0RemoveBg()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                new UnnamedSchemaWithArrayParent0AutoTaggingExtension()
                {
                    MaxTags = 5,
                    MinConfidence = 95,
                    Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
                },
                new UnnamedSchemaWithArrayParent0AIAutoDescription(),
                new UnnamedSchemaWithArrayParent0AITasks(
                    [
                        new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
                        {
                            Instruction = "What types of clothing items are visible in this image?",
                            MaxSelections = 1,
                            MinSelections = 0,
                            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                        },
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
                        },
                    ]
                ),
                new SavedExtension("ext_abc123"),
            ],
            RemoveAITags = new Files::UnionMember1(),
            WebhookUrl = "https://example.com",

            CustomCoordinates = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Files::UpdateFileDetails
        {
            CustomCoordinates = "customCoordinates",
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            Extensions =
            [
                new UnnamedSchemaWithArrayParent0RemoveBg()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                new UnnamedSchemaWithArrayParent0AutoTaggingExtension()
                {
                    MaxTags = 5,
                    MinConfidence = 95,
                    Name = UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
                },
                new UnnamedSchemaWithArrayParent0AIAutoDescription(),
                new UnnamedSchemaWithArrayParent0AITasks(
                    [
                        new UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
                        {
                            Instruction = "What types of clothing items are visible in this image?",
                            MaxSelections = 1,
                            MinSelections = 0,
                            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                        },
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
                        },
                    ]
                ),
                new SavedExtension("ext_abc123"),
            ],
            RemoveAITags = new Files::UnionMember1(),
            Tags = ["tag1", "tag2"],
            WebhookUrl = "https://example.com",
        };

        Files::UpdateFileDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RemoveAITagsTest : TestBase
{
    [Fact]
    public void StringsValidationWorks()
    {
        Files::RemoveAITags value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void AllValidationWorks()
    {
        Files::RemoveAITags value = new Files::UnionMember1();
        value.Validate();
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        Files::RemoveAITags value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::RemoveAITags>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AllSerializationRoundtripWorks()
    {
        Files::RemoveAITags value = new Files::UnionMember1();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::RemoveAITags>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember1Test : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new Files::UnionMember1();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<Files::UnionMember1>(
            JsonSerializer.SerializeToElement("all"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<Files::UnionMember1>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new Files::UnionMember1();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::UnionMember1>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Files::UnionMember1>(
            JsonSerializer.SerializeToElement("all"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::UnionMember1>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Files::UnionMember1>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::UnionMember1>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class ChangePublicationStatusTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Files::ChangePublicationStatus
        {
            Publish = new() { IsPublished = true, IncludeFileVersions = true },
        };

        Files::Publish expectedPublish = new() { IsPublished = true, IncludeFileVersions = true };

        Assert.Equal(expectedPublish, model.Publish);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Files::ChangePublicationStatus
        {
            Publish = new() { IsPublished = true, IncludeFileVersions = true },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::ChangePublicationStatus>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Files::ChangePublicationStatus
        {
            Publish = new() { IsPublished = true, IncludeFileVersions = true },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::ChangePublicationStatus>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Files::Publish expectedPublish = new() { IsPublished = true, IncludeFileVersions = true };

        Assert.Equal(expectedPublish, deserialized.Publish);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Files::ChangePublicationStatus
        {
            Publish = new() { IsPublished = true, IncludeFileVersions = true },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Files::ChangePublicationStatus { };

        Assert.Null(model.Publish);
        Assert.False(model.RawData.ContainsKey("publish"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Files::ChangePublicationStatus { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Files::ChangePublicationStatus
        {
            // Null should be interpreted as omitted for these properties
            Publish = null,
        };

        Assert.Null(model.Publish);
        Assert.False(model.RawData.ContainsKey("publish"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Files::ChangePublicationStatus
        {
            // Null should be interpreted as omitted for these properties
            Publish = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Files::ChangePublicationStatus
        {
            Publish = new() { IsPublished = true, IncludeFileVersions = true },
        };

        Files::ChangePublicationStatus copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PublishTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Files::Publish { IsPublished = true, IncludeFileVersions = true };

        bool expectedIsPublished = true;
        bool expectedIncludeFileVersions = true;

        Assert.Equal(expectedIsPublished, model.IsPublished);
        Assert.Equal(expectedIncludeFileVersions, model.IncludeFileVersions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Files::Publish { IsPublished = true, IncludeFileVersions = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::Publish>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Files::Publish { IsPublished = true, IncludeFileVersions = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::Publish>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedIsPublished = true;
        bool expectedIncludeFileVersions = true;

        Assert.Equal(expectedIsPublished, deserialized.IsPublished);
        Assert.Equal(expectedIncludeFileVersions, deserialized.IncludeFileVersions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Files::Publish { IsPublished = true, IncludeFileVersions = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Files::Publish { IsPublished = true };

        Assert.Null(model.IncludeFileVersions);
        Assert.False(model.RawData.ContainsKey("includeFileVersions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Files::Publish { IsPublished = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Files::Publish
        {
            IsPublished = true,

            // Null should be interpreted as omitted for these properties
            IncludeFileVersions = null,
        };

        Assert.Null(model.IncludeFileVersions);
        Assert.False(model.RawData.ContainsKey("includeFileVersions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Files::Publish
        {
            IsPublished = true,

            // Null should be interpreted as omitted for these properties
            IncludeFileVersions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Files::Publish { IsPublished = true, IncludeFileVersions = true };

        Files::Publish copied = new(model);

        Assert.Equal(model, copied);
    }
}
