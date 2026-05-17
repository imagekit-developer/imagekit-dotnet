using System;
using System.Collections.Generic;
using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.Api.V1.Files;
using Details = ImagekitDiversion.Models.Files.Details;

namespace ImagekitDiversion.Tests.Models.Files.Details;

public class DetailUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Details::DetailUpdateResponse
        {
            AITags =
            [
                new()
                {
                    Confidence = 0,
                    Name = "name",
                    Source = "source",
                },
            ],
            AudioCodec = "audioCodec",
            BitRate = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCoordinates = "customCoordinates",
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            Duration = 0,
            EmbeddedMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            FileID = "fileId",
            FilePath = "filePath",
            FileType = "fileType",
            HasAlpha = true,
            Height = 0,
            IsPrivateFile = true,
            IsPublished = true,
            Mime = "mime",
            Name = "name",
            SelectedFieldsSchema = new Dictionary<string, Details::SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Details::Type.Text,
                        DefaultValue = new(
                            [
                                new Details::DefaultValueArrayItem(true),
                                new Details::DefaultValueArrayItem(10),
                                new Details::DefaultValueArrayItem("Hello"),
                            ]
                        ),
                        IsValueRequired = true,
                        MaxLength = 0,
                        MaxValue = "string",
                        MinLength = 0,
                        MinValue = "string",
                        ReadOnly = true,
                        SelectOptions = ["small", "medium", "large", 30, 40, true],
                        SelectOptionsTruncated = true,
                    }
                },
            },
            Size = 0,
            Tags = ["string"],
            Thumbnail = "https://example.com",
            Type = Details::FileDetailsType.File,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,
            ExtensionStatus = new()
            {
                AIAutoDescription = Details::AIAutoDescription.Success,
                AITasks = Details::AITasks.Success,
                AwsAutoTagging = Details::AwsAutoTagging.Success,
                GoogleAutoTagging = Details::GoogleAutoTagging.Success,
                RemoveBg = Details::RemoveBg.Success,
            },
        };

        List<AITag> expectedAITags =
        [
            new()
            {
                Confidence = 0,
                Name = "name",
                Source = "source",
            },
        ];
        string expectedAudioCodec = "audioCodec";
        long expectedBitRate = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomCoordinates = "customCoordinates";
        Dictionary<string, JsonElement> expectedCustomMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedDescription = "description";
        long expectedDuration = 0;
        Dictionary<string, JsonElement> expectedEmbeddedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedFileID = "fileId";
        string expectedFilePath = "filePath";
        string expectedFileType = "fileType";
        bool expectedHasAlpha = true;
        double expectedHeight = 0;
        bool expectedIsPrivateFile = true;
        bool expectedIsPublished = true;
        string expectedMime = "mime";
        string expectedName = "name";
        Dictionary<string, Details::SelectedFieldsSchemaItem> expectedSelectedFieldsSchema = new()
        {
            {
                "foo",
                new()
                {
                    Type = Details::Type.Text,
                    DefaultValue = new(
                        [
                            new Details::DefaultValueArrayItem(true),
                            new Details::DefaultValueArrayItem(10),
                            new Details::DefaultValueArrayItem("Hello"),
                        ]
                    ),
                    IsValueRequired = true,
                    MaxLength = 0,
                    MaxValue = "string",
                    MinLength = 0,
                    MinValue = "string",
                    ReadOnly = true,
                    SelectOptions = ["small", "medium", "large", 30, 40, true],
                    SelectOptionsTruncated = true,
                }
            },
        };
        double expectedSize = 0;
        List<string> expectedTags = ["string"];
        string expectedThumbnail = "https://example.com";
        ApiEnum<string, Details::FileDetailsType> expectedType = Details::FileDetailsType.File;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUrl = "https://example.com";
        VersionInfo expectedVersionInfo = new() { ID = "id", Name = "name" };
        string expectedVideoCodec = "videoCodec";
        double expectedWidth = 0;
        Details::ExtensionStatus expectedExtensionStatus = new()
        {
            AIAutoDescription = Details::AIAutoDescription.Success,
            AITasks = Details::AITasks.Success,
            AwsAutoTagging = Details::AwsAutoTagging.Success,
            GoogleAutoTagging = Details::GoogleAutoTagging.Success,
            RemoveBg = Details::RemoveBg.Success,
        };

        Assert.NotNull(model.AITags);
        Assert.Equal(expectedAITags.Count, model.AITags.Count);
        for (int i = 0; i < expectedAITags.Count; i++)
        {
            Assert.Equal(expectedAITags[i], model.AITags[i]);
        }
        Assert.Equal(expectedAudioCodec, model.AudioCodec);
        Assert.Equal(expectedBitRate, model.BitRate);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomCoordinates, model.CustomCoordinates);
        Assert.NotNull(model.CustomMetadata);
        Assert.Equal(expectedCustomMetadata.Count, model.CustomMetadata.Count);
        foreach (var item in expectedCustomMetadata)
        {
            Assert.True(model.CustomMetadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.CustomMetadata[item.Key]));
        }
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDuration, model.Duration);
        Assert.NotNull(model.EmbeddedMetadata);
        Assert.Equal(expectedEmbeddedMetadata.Count, model.EmbeddedMetadata.Count);
        foreach (var item in expectedEmbeddedMetadata)
        {
            Assert.True(model.EmbeddedMetadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.EmbeddedMetadata[item.Key]));
        }
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedFilePath, model.FilePath);
        Assert.Equal(expectedFileType, model.FileType);
        Assert.Equal(expectedHasAlpha, model.HasAlpha);
        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedIsPrivateFile, model.IsPrivateFile);
        Assert.Equal(expectedIsPublished, model.IsPublished);
        Assert.Equal(expectedMime, model.Mime);
        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.SelectedFieldsSchema);
        Assert.Equal(expectedSelectedFieldsSchema.Count, model.SelectedFieldsSchema.Count);
        foreach (var item in expectedSelectedFieldsSchema)
        {
            Assert.True(model.SelectedFieldsSchema.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.SelectedFieldsSchema[item.Key]);
        }
        Assert.Equal(expectedSize, model.Size);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedThumbnail, model.Thumbnail);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedVersionInfo, model.VersionInfo);
        Assert.Equal(expectedVideoCodec, model.VideoCodec);
        Assert.Equal(expectedWidth, model.Width);
        Assert.Equal(expectedExtensionStatus, model.ExtensionStatus);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Details::DetailUpdateResponse
        {
            AITags =
            [
                new()
                {
                    Confidence = 0,
                    Name = "name",
                    Source = "source",
                },
            ],
            AudioCodec = "audioCodec",
            BitRate = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCoordinates = "customCoordinates",
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            Duration = 0,
            EmbeddedMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            FileID = "fileId",
            FilePath = "filePath",
            FileType = "fileType",
            HasAlpha = true,
            Height = 0,
            IsPrivateFile = true,
            IsPublished = true,
            Mime = "mime",
            Name = "name",
            SelectedFieldsSchema = new Dictionary<string, Details::SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Details::Type.Text,
                        DefaultValue = new(
                            [
                                new Details::DefaultValueArrayItem(true),
                                new Details::DefaultValueArrayItem(10),
                                new Details::DefaultValueArrayItem("Hello"),
                            ]
                        ),
                        IsValueRequired = true,
                        MaxLength = 0,
                        MaxValue = "string",
                        MinLength = 0,
                        MinValue = "string",
                        ReadOnly = true,
                        SelectOptions = ["small", "medium", "large", 30, 40, true],
                        SelectOptionsTruncated = true,
                    }
                },
            },
            Size = 0,
            Tags = ["string"],
            Thumbnail = "https://example.com",
            Type = Details::FileDetailsType.File,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,
            ExtensionStatus = new()
            {
                AIAutoDescription = Details::AIAutoDescription.Success,
                AITasks = Details::AITasks.Success,
                AwsAutoTagging = Details::AwsAutoTagging.Success,
                GoogleAutoTagging = Details::GoogleAutoTagging.Success,
                RemoveBg = Details::RemoveBg.Success,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Details::DetailUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Details::DetailUpdateResponse
        {
            AITags =
            [
                new()
                {
                    Confidence = 0,
                    Name = "name",
                    Source = "source",
                },
            ],
            AudioCodec = "audioCodec",
            BitRate = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCoordinates = "customCoordinates",
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            Duration = 0,
            EmbeddedMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            FileID = "fileId",
            FilePath = "filePath",
            FileType = "fileType",
            HasAlpha = true,
            Height = 0,
            IsPrivateFile = true,
            IsPublished = true,
            Mime = "mime",
            Name = "name",
            SelectedFieldsSchema = new Dictionary<string, Details::SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Details::Type.Text,
                        DefaultValue = new(
                            [
                                new Details::DefaultValueArrayItem(true),
                                new Details::DefaultValueArrayItem(10),
                                new Details::DefaultValueArrayItem("Hello"),
                            ]
                        ),
                        IsValueRequired = true,
                        MaxLength = 0,
                        MaxValue = "string",
                        MinLength = 0,
                        MinValue = "string",
                        ReadOnly = true,
                        SelectOptions = ["small", "medium", "large", 30, 40, true],
                        SelectOptionsTruncated = true,
                    }
                },
            },
            Size = 0,
            Tags = ["string"],
            Thumbnail = "https://example.com",
            Type = Details::FileDetailsType.File,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,
            ExtensionStatus = new()
            {
                AIAutoDescription = Details::AIAutoDescription.Success,
                AITasks = Details::AITasks.Success,
                AwsAutoTagging = Details::AwsAutoTagging.Success,
                GoogleAutoTagging = Details::GoogleAutoTagging.Success,
                RemoveBg = Details::RemoveBg.Success,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Details::DetailUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AITag> expectedAITags =
        [
            new()
            {
                Confidence = 0,
                Name = "name",
                Source = "source",
            },
        ];
        string expectedAudioCodec = "audioCodec";
        long expectedBitRate = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomCoordinates = "customCoordinates";
        Dictionary<string, JsonElement> expectedCustomMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedDescription = "description";
        long expectedDuration = 0;
        Dictionary<string, JsonElement> expectedEmbeddedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedFileID = "fileId";
        string expectedFilePath = "filePath";
        string expectedFileType = "fileType";
        bool expectedHasAlpha = true;
        double expectedHeight = 0;
        bool expectedIsPrivateFile = true;
        bool expectedIsPublished = true;
        string expectedMime = "mime";
        string expectedName = "name";
        Dictionary<string, Details::SelectedFieldsSchemaItem> expectedSelectedFieldsSchema = new()
        {
            {
                "foo",
                new()
                {
                    Type = Details::Type.Text,
                    DefaultValue = new(
                        [
                            new Details::DefaultValueArrayItem(true),
                            new Details::DefaultValueArrayItem(10),
                            new Details::DefaultValueArrayItem("Hello"),
                        ]
                    ),
                    IsValueRequired = true,
                    MaxLength = 0,
                    MaxValue = "string",
                    MinLength = 0,
                    MinValue = "string",
                    ReadOnly = true,
                    SelectOptions = ["small", "medium", "large", 30, 40, true],
                    SelectOptionsTruncated = true,
                }
            },
        };
        double expectedSize = 0;
        List<string> expectedTags = ["string"];
        string expectedThumbnail = "https://example.com";
        ApiEnum<string, Details::FileDetailsType> expectedType = Details::FileDetailsType.File;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUrl = "https://example.com";
        VersionInfo expectedVersionInfo = new() { ID = "id", Name = "name" };
        string expectedVideoCodec = "videoCodec";
        double expectedWidth = 0;
        Details::ExtensionStatus expectedExtensionStatus = new()
        {
            AIAutoDescription = Details::AIAutoDescription.Success,
            AITasks = Details::AITasks.Success,
            AwsAutoTagging = Details::AwsAutoTagging.Success,
            GoogleAutoTagging = Details::GoogleAutoTagging.Success,
            RemoveBg = Details::RemoveBg.Success,
        };

        Assert.NotNull(deserialized.AITags);
        Assert.Equal(expectedAITags.Count, deserialized.AITags.Count);
        for (int i = 0; i < expectedAITags.Count; i++)
        {
            Assert.Equal(expectedAITags[i], deserialized.AITags[i]);
        }
        Assert.Equal(expectedAudioCodec, deserialized.AudioCodec);
        Assert.Equal(expectedBitRate, deserialized.BitRate);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomCoordinates, deserialized.CustomCoordinates);
        Assert.NotNull(deserialized.CustomMetadata);
        Assert.Equal(expectedCustomMetadata.Count, deserialized.CustomMetadata.Count);
        foreach (var item in expectedCustomMetadata)
        {
            Assert.True(deserialized.CustomMetadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.CustomMetadata[item.Key]));
        }
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.NotNull(deserialized.EmbeddedMetadata);
        Assert.Equal(expectedEmbeddedMetadata.Count, deserialized.EmbeddedMetadata.Count);
        foreach (var item in expectedEmbeddedMetadata)
        {
            Assert.True(deserialized.EmbeddedMetadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.EmbeddedMetadata[item.Key]));
        }
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedFilePath, deserialized.FilePath);
        Assert.Equal(expectedFileType, deserialized.FileType);
        Assert.Equal(expectedHasAlpha, deserialized.HasAlpha);
        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedIsPrivateFile, deserialized.IsPrivateFile);
        Assert.Equal(expectedIsPublished, deserialized.IsPublished);
        Assert.Equal(expectedMime, deserialized.Mime);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.SelectedFieldsSchema);
        Assert.Equal(expectedSelectedFieldsSchema.Count, deserialized.SelectedFieldsSchema.Count);
        foreach (var item in expectedSelectedFieldsSchema)
        {
            Assert.True(deserialized.SelectedFieldsSchema.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.SelectedFieldsSchema[item.Key]);
        }
        Assert.Equal(expectedSize, deserialized.Size);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedThumbnail, deserialized.Thumbnail);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedVersionInfo, deserialized.VersionInfo);
        Assert.Equal(expectedVideoCodec, deserialized.VideoCodec);
        Assert.Equal(expectedWidth, deserialized.Width);
        Assert.Equal(expectedExtensionStatus, deserialized.ExtensionStatus);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Details::DetailUpdateResponse
        {
            AITags =
            [
                new()
                {
                    Confidence = 0,
                    Name = "name",
                    Source = "source",
                },
            ],
            AudioCodec = "audioCodec",
            BitRate = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCoordinates = "customCoordinates",
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            Duration = 0,
            EmbeddedMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            FileID = "fileId",
            FilePath = "filePath",
            FileType = "fileType",
            HasAlpha = true,
            Height = 0,
            IsPrivateFile = true,
            IsPublished = true,
            Mime = "mime",
            Name = "name",
            SelectedFieldsSchema = new Dictionary<string, Details::SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Details::Type.Text,
                        DefaultValue = new(
                            [
                                new Details::DefaultValueArrayItem(true),
                                new Details::DefaultValueArrayItem(10),
                                new Details::DefaultValueArrayItem("Hello"),
                            ]
                        ),
                        IsValueRequired = true,
                        MaxLength = 0,
                        MaxValue = "string",
                        MinLength = 0,
                        MinValue = "string",
                        ReadOnly = true,
                        SelectOptions = ["small", "medium", "large", 30, 40, true],
                        SelectOptionsTruncated = true,
                    }
                },
            },
            Size = 0,
            Tags = ["string"],
            Thumbnail = "https://example.com",
            Type = Details::FileDetailsType.File,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,
            ExtensionStatus = new()
            {
                AIAutoDescription = Details::AIAutoDescription.Success,
                AITasks = Details::AITasks.Success,
                AwsAutoTagging = Details::AwsAutoTagging.Success,
                GoogleAutoTagging = Details::GoogleAutoTagging.Success,
                RemoveBg = Details::RemoveBg.Success,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Details::DetailUpdateResponse { };

        Assert.Null(model.AITags);
        Assert.False(model.RawData.ContainsKey("AITags"));
        Assert.Null(model.AudioCodec);
        Assert.False(model.RawData.ContainsKey("audioCodec"));
        Assert.Null(model.BitRate);
        Assert.False(model.RawData.ContainsKey("bitRate"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CustomCoordinates);
        Assert.False(model.RawData.ContainsKey("customCoordinates"));
        Assert.Null(model.CustomMetadata);
        Assert.False(model.RawData.ContainsKey("customMetadata"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.EmbeddedMetadata);
        Assert.False(model.RawData.ContainsKey("embeddedMetadata"));
        Assert.Null(model.FileID);
        Assert.False(model.RawData.ContainsKey("fileId"));
        Assert.Null(model.FilePath);
        Assert.False(model.RawData.ContainsKey("filePath"));
        Assert.Null(model.FileType);
        Assert.False(model.RawData.ContainsKey("fileType"));
        Assert.Null(model.HasAlpha);
        Assert.False(model.RawData.ContainsKey("hasAlpha"));
        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.IsPrivateFile);
        Assert.False(model.RawData.ContainsKey("isPrivateFile"));
        Assert.Null(model.IsPublished);
        Assert.False(model.RawData.ContainsKey("isPublished"));
        Assert.Null(model.Mime);
        Assert.False(model.RawData.ContainsKey("mime"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.SelectedFieldsSchema);
        Assert.False(model.RawData.ContainsKey("selectedFieldsSchema"));
        Assert.Null(model.Size);
        Assert.False(model.RawData.ContainsKey("size"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Thumbnail);
        Assert.False(model.RawData.ContainsKey("thumbnail"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
        Assert.Null(model.VersionInfo);
        Assert.False(model.RawData.ContainsKey("versionInfo"));
        Assert.Null(model.VideoCodec);
        Assert.False(model.RawData.ContainsKey("videoCodec"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
        Assert.Null(model.ExtensionStatus);
        Assert.False(model.RawData.ContainsKey("extensionStatus"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Details::DetailUpdateResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Details::DetailUpdateResponse
        {
            // Null should be interpreted as omitted for these properties
            AITags = null,
            AudioCodec = null,
            BitRate = null,
            CreatedAt = null,
            CustomCoordinates = null,
            CustomMetadata = null,
            Description = null,
            Duration = null,
            EmbeddedMetadata = null,
            FileID = null,
            FilePath = null,
            FileType = null,
            HasAlpha = null,
            Height = null,
            IsPrivateFile = null,
            IsPublished = null,
            Mime = null,
            Name = null,
            SelectedFieldsSchema = null,
            Size = null,
            Tags = null,
            Thumbnail = null,
            Type = null,
            UpdatedAt = null,
            Url = null,
            VersionInfo = null,
            VideoCodec = null,
            Width = null,
            ExtensionStatus = null,
        };

        Assert.Null(model.AITags);
        Assert.False(model.RawData.ContainsKey("AITags"));
        Assert.Null(model.AudioCodec);
        Assert.False(model.RawData.ContainsKey("audioCodec"));
        Assert.Null(model.BitRate);
        Assert.False(model.RawData.ContainsKey("bitRate"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CustomCoordinates);
        Assert.False(model.RawData.ContainsKey("customCoordinates"));
        Assert.Null(model.CustomMetadata);
        Assert.False(model.RawData.ContainsKey("customMetadata"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.EmbeddedMetadata);
        Assert.False(model.RawData.ContainsKey("embeddedMetadata"));
        Assert.Null(model.FileID);
        Assert.False(model.RawData.ContainsKey("fileId"));
        Assert.Null(model.FilePath);
        Assert.False(model.RawData.ContainsKey("filePath"));
        Assert.Null(model.FileType);
        Assert.False(model.RawData.ContainsKey("fileType"));
        Assert.Null(model.HasAlpha);
        Assert.False(model.RawData.ContainsKey("hasAlpha"));
        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.IsPrivateFile);
        Assert.False(model.RawData.ContainsKey("isPrivateFile"));
        Assert.Null(model.IsPublished);
        Assert.False(model.RawData.ContainsKey("isPublished"));
        Assert.Null(model.Mime);
        Assert.False(model.RawData.ContainsKey("mime"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.SelectedFieldsSchema);
        Assert.False(model.RawData.ContainsKey("selectedFieldsSchema"));
        Assert.Null(model.Size);
        Assert.False(model.RawData.ContainsKey("size"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Thumbnail);
        Assert.False(model.RawData.ContainsKey("thumbnail"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
        Assert.Null(model.VersionInfo);
        Assert.False(model.RawData.ContainsKey("versionInfo"));
        Assert.Null(model.VideoCodec);
        Assert.False(model.RawData.ContainsKey("videoCodec"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
        Assert.Null(model.ExtensionStatus);
        Assert.False(model.RawData.ContainsKey("extensionStatus"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Details::DetailUpdateResponse
        {
            // Null should be interpreted as omitted for these properties
            AITags = null,
            AudioCodec = null,
            BitRate = null,
            CreatedAt = null,
            CustomCoordinates = null,
            CustomMetadata = null,
            Description = null,
            Duration = null,
            EmbeddedMetadata = null,
            FileID = null,
            FilePath = null,
            FileType = null,
            HasAlpha = null,
            Height = null,
            IsPrivateFile = null,
            IsPublished = null,
            Mime = null,
            Name = null,
            SelectedFieldsSchema = null,
            Size = null,
            Tags = null,
            Thumbnail = null,
            Type = null,
            UpdatedAt = null,
            Url = null,
            VersionInfo = null,
            VideoCodec = null,
            Width = null,
            ExtensionStatus = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Details::DetailUpdateResponse
        {
            AITags =
            [
                new()
                {
                    Confidence = 0,
                    Name = "name",
                    Source = "source",
                },
            ],
            AudioCodec = "audioCodec",
            BitRate = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCoordinates = "customCoordinates",
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            Duration = 0,
            EmbeddedMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            FileID = "fileId",
            FilePath = "filePath",
            FileType = "fileType",
            HasAlpha = true,
            Height = 0,
            IsPrivateFile = true,
            IsPublished = true,
            Mime = "mime",
            Name = "name",
            SelectedFieldsSchema = new Dictionary<string, Details::SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Details::Type.Text,
                        DefaultValue = new(
                            [
                                new Details::DefaultValueArrayItem(true),
                                new Details::DefaultValueArrayItem(10),
                                new Details::DefaultValueArrayItem("Hello"),
                            ]
                        ),
                        IsValueRequired = true,
                        MaxLength = 0,
                        MaxValue = "string",
                        MinLength = 0,
                        MinValue = "string",
                        ReadOnly = true,
                        SelectOptions = ["small", "medium", "large", 30, 40, true],
                        SelectOptionsTruncated = true,
                    }
                },
            },
            Size = 0,
            Tags = ["string"],
            Thumbnail = "https://example.com",
            Type = Details::FileDetailsType.File,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,
            ExtensionStatus = new()
            {
                AIAutoDescription = Details::AIAutoDescription.Success,
                AITasks = Details::AITasks.Success,
                AwsAutoTagging = Details::AwsAutoTagging.Success,
                GoogleAutoTagging = Details::GoogleAutoTagging.Success,
                RemoveBg = Details::RemoveBg.Success,
            },
        };

        Details::DetailUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FileUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Details::FileUpdateResponse
        {
            ExtensionStatus = new()
            {
                AIAutoDescription = Details::AIAutoDescription.Success,
                AITasks = Details::AITasks.Success,
                AwsAutoTagging = Details::AwsAutoTagging.Success,
                GoogleAutoTagging = Details::GoogleAutoTagging.Success,
                RemoveBg = Details::RemoveBg.Success,
            },
        };

        Details::ExtensionStatus expectedExtensionStatus = new()
        {
            AIAutoDescription = Details::AIAutoDescription.Success,
            AITasks = Details::AITasks.Success,
            AwsAutoTagging = Details::AwsAutoTagging.Success,
            GoogleAutoTagging = Details::GoogleAutoTagging.Success,
            RemoveBg = Details::RemoveBg.Success,
        };

        Assert.Equal(expectedExtensionStatus, model.ExtensionStatus);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Details::FileUpdateResponse
        {
            ExtensionStatus = new()
            {
                AIAutoDescription = Details::AIAutoDescription.Success,
                AITasks = Details::AITasks.Success,
                AwsAutoTagging = Details::AwsAutoTagging.Success,
                GoogleAutoTagging = Details::GoogleAutoTagging.Success,
                RemoveBg = Details::RemoveBg.Success,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Details::FileUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Details::FileUpdateResponse
        {
            ExtensionStatus = new()
            {
                AIAutoDescription = Details::AIAutoDescription.Success,
                AITasks = Details::AITasks.Success,
                AwsAutoTagging = Details::AwsAutoTagging.Success,
                GoogleAutoTagging = Details::GoogleAutoTagging.Success,
                RemoveBg = Details::RemoveBg.Success,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Details::FileUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Details::ExtensionStatus expectedExtensionStatus = new()
        {
            AIAutoDescription = Details::AIAutoDescription.Success,
            AITasks = Details::AITasks.Success,
            AwsAutoTagging = Details::AwsAutoTagging.Success,
            GoogleAutoTagging = Details::GoogleAutoTagging.Success,
            RemoveBg = Details::RemoveBg.Success,
        };

        Assert.Equal(expectedExtensionStatus, deserialized.ExtensionStatus);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Details::FileUpdateResponse
        {
            ExtensionStatus = new()
            {
                AIAutoDescription = Details::AIAutoDescription.Success,
                AITasks = Details::AITasks.Success,
                AwsAutoTagging = Details::AwsAutoTagging.Success,
                GoogleAutoTagging = Details::GoogleAutoTagging.Success,
                RemoveBg = Details::RemoveBg.Success,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Details::FileUpdateResponse { };

        Assert.Null(model.ExtensionStatus);
        Assert.False(model.RawData.ContainsKey("extensionStatus"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Details::FileUpdateResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Details::FileUpdateResponse
        {
            // Null should be interpreted as omitted for these properties
            ExtensionStatus = null,
        };

        Assert.Null(model.ExtensionStatus);
        Assert.False(model.RawData.ContainsKey("extensionStatus"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Details::FileUpdateResponse
        {
            // Null should be interpreted as omitted for these properties
            ExtensionStatus = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Details::FileUpdateResponse
        {
            ExtensionStatus = new()
            {
                AIAutoDescription = Details::AIAutoDescription.Success,
                AITasks = Details::AITasks.Success,
                AwsAutoTagging = Details::AwsAutoTagging.Success,
                GoogleAutoTagging = Details::GoogleAutoTagging.Success,
                RemoveBg = Details::RemoveBg.Success,
            },
        };

        Details::FileUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtensionStatusTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Details::ExtensionStatus
        {
            AIAutoDescription = Details::AIAutoDescription.Success,
            AITasks = Details::AITasks.Success,
            AwsAutoTagging = Details::AwsAutoTagging.Success,
            GoogleAutoTagging = Details::GoogleAutoTagging.Success,
            RemoveBg = Details::RemoveBg.Success,
        };

        ApiEnum<string, Details::AIAutoDescription> expectedAIAutoDescription =
            Details::AIAutoDescription.Success;
        ApiEnum<string, Details::AITasks> expectedAITasks = Details::AITasks.Success;
        ApiEnum<string, Details::AwsAutoTagging> expectedAwsAutoTagging =
            Details::AwsAutoTagging.Success;
        ApiEnum<string, Details::GoogleAutoTagging> expectedGoogleAutoTagging =
            Details::GoogleAutoTagging.Success;
        ApiEnum<string, Details::RemoveBg> expectedRemoveBg = Details::RemoveBg.Success;

        Assert.Equal(expectedAIAutoDescription, model.AIAutoDescription);
        Assert.Equal(expectedAITasks, model.AITasks);
        Assert.Equal(expectedAwsAutoTagging, model.AwsAutoTagging);
        Assert.Equal(expectedGoogleAutoTagging, model.GoogleAutoTagging);
        Assert.Equal(expectedRemoveBg, model.RemoveBg);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Details::ExtensionStatus
        {
            AIAutoDescription = Details::AIAutoDescription.Success,
            AITasks = Details::AITasks.Success,
            AwsAutoTagging = Details::AwsAutoTagging.Success,
            GoogleAutoTagging = Details::GoogleAutoTagging.Success,
            RemoveBg = Details::RemoveBg.Success,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Details::ExtensionStatus>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Details::ExtensionStatus
        {
            AIAutoDescription = Details::AIAutoDescription.Success,
            AITasks = Details::AITasks.Success,
            AwsAutoTagging = Details::AwsAutoTagging.Success,
            GoogleAutoTagging = Details::GoogleAutoTagging.Success,
            RemoveBg = Details::RemoveBg.Success,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Details::ExtensionStatus>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Details::AIAutoDescription> expectedAIAutoDescription =
            Details::AIAutoDescription.Success;
        ApiEnum<string, Details::AITasks> expectedAITasks = Details::AITasks.Success;
        ApiEnum<string, Details::AwsAutoTagging> expectedAwsAutoTagging =
            Details::AwsAutoTagging.Success;
        ApiEnum<string, Details::GoogleAutoTagging> expectedGoogleAutoTagging =
            Details::GoogleAutoTagging.Success;
        ApiEnum<string, Details::RemoveBg> expectedRemoveBg = Details::RemoveBg.Success;

        Assert.Equal(expectedAIAutoDescription, deserialized.AIAutoDescription);
        Assert.Equal(expectedAITasks, deserialized.AITasks);
        Assert.Equal(expectedAwsAutoTagging, deserialized.AwsAutoTagging);
        Assert.Equal(expectedGoogleAutoTagging, deserialized.GoogleAutoTagging);
        Assert.Equal(expectedRemoveBg, deserialized.RemoveBg);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Details::ExtensionStatus
        {
            AIAutoDescription = Details::AIAutoDescription.Success,
            AITasks = Details::AITasks.Success,
            AwsAutoTagging = Details::AwsAutoTagging.Success,
            GoogleAutoTagging = Details::GoogleAutoTagging.Success,
            RemoveBg = Details::RemoveBg.Success,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Details::ExtensionStatus { };

        Assert.Null(model.AIAutoDescription);
        Assert.False(model.RawData.ContainsKey("ai-auto-description"));
        Assert.Null(model.AITasks);
        Assert.False(model.RawData.ContainsKey("ai-tasks"));
        Assert.Null(model.AwsAutoTagging);
        Assert.False(model.RawData.ContainsKey("aws-auto-tagging"));
        Assert.Null(model.GoogleAutoTagging);
        Assert.False(model.RawData.ContainsKey("google-auto-tagging"));
        Assert.Null(model.RemoveBg);
        Assert.False(model.RawData.ContainsKey("remove-bg"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Details::ExtensionStatus { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Details::ExtensionStatus
        {
            // Null should be interpreted as omitted for these properties
            AIAutoDescription = null,
            AITasks = null,
            AwsAutoTagging = null,
            GoogleAutoTagging = null,
            RemoveBg = null,
        };

        Assert.Null(model.AIAutoDescription);
        Assert.False(model.RawData.ContainsKey("ai-auto-description"));
        Assert.Null(model.AITasks);
        Assert.False(model.RawData.ContainsKey("ai-tasks"));
        Assert.Null(model.AwsAutoTagging);
        Assert.False(model.RawData.ContainsKey("aws-auto-tagging"));
        Assert.Null(model.GoogleAutoTagging);
        Assert.False(model.RawData.ContainsKey("google-auto-tagging"));
        Assert.Null(model.RemoveBg);
        Assert.False(model.RawData.ContainsKey("remove-bg"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Details::ExtensionStatus
        {
            // Null should be interpreted as omitted for these properties
            AIAutoDescription = null,
            AITasks = null,
            AwsAutoTagging = null,
            GoogleAutoTagging = null,
            RemoveBg = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Details::ExtensionStatus
        {
            AIAutoDescription = Details::AIAutoDescription.Success,
            AITasks = Details::AITasks.Success,
            AwsAutoTagging = Details::AwsAutoTagging.Success,
            GoogleAutoTagging = Details::GoogleAutoTagging.Success,
            RemoveBg = Details::RemoveBg.Success,
        };

        Details::ExtensionStatus copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AIAutoDescriptionTest : TestBase
{
    [Theory]
    [InlineData(Details::AIAutoDescription.Success)]
    [InlineData(Details::AIAutoDescription.Pending)]
    [InlineData(Details::AIAutoDescription.Failed)]
    public void Validation_Works(Details::AIAutoDescription rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Details::AIAutoDescription> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Details::AIAutoDescription>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Details::AIAutoDescription.Success)]
    [InlineData(Details::AIAutoDescription.Pending)]
    [InlineData(Details::AIAutoDescription.Failed)]
    public void SerializationRoundtrip_Works(Details::AIAutoDescription rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Details::AIAutoDescription> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Details::AIAutoDescription>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Details::AIAutoDescription>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Details::AIAutoDescription>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AITasksTest : TestBase
{
    [Theory]
    [InlineData(Details::AITasks.Success)]
    [InlineData(Details::AITasks.Pending)]
    [InlineData(Details::AITasks.Failed)]
    public void Validation_Works(Details::AITasks rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Details::AITasks> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Details::AITasks>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Details::AITasks.Success)]
    [InlineData(Details::AITasks.Pending)]
    [InlineData(Details::AITasks.Failed)]
    public void SerializationRoundtrip_Works(Details::AITasks rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Details::AITasks> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Details::AITasks>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Details::AITasks>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Details::AITasks>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AwsAutoTaggingTest : TestBase
{
    [Theory]
    [InlineData(Details::AwsAutoTagging.Success)]
    [InlineData(Details::AwsAutoTagging.Pending)]
    [InlineData(Details::AwsAutoTagging.Failed)]
    public void Validation_Works(Details::AwsAutoTagging rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Details::AwsAutoTagging> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Details::AwsAutoTagging>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Details::AwsAutoTagging.Success)]
    [InlineData(Details::AwsAutoTagging.Pending)]
    [InlineData(Details::AwsAutoTagging.Failed)]
    public void SerializationRoundtrip_Works(Details::AwsAutoTagging rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Details::AwsAutoTagging> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Details::AwsAutoTagging>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Details::AwsAutoTagging>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Details::AwsAutoTagging>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class GoogleAutoTaggingTest : TestBase
{
    [Theory]
    [InlineData(Details::GoogleAutoTagging.Success)]
    [InlineData(Details::GoogleAutoTagging.Pending)]
    [InlineData(Details::GoogleAutoTagging.Failed)]
    public void Validation_Works(Details::GoogleAutoTagging rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Details::GoogleAutoTagging> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Details::GoogleAutoTagging>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Details::GoogleAutoTagging.Success)]
    [InlineData(Details::GoogleAutoTagging.Pending)]
    [InlineData(Details::GoogleAutoTagging.Failed)]
    public void SerializationRoundtrip_Works(Details::GoogleAutoTagging rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Details::GoogleAutoTagging> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Details::GoogleAutoTagging>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Details::GoogleAutoTagging>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Details::GoogleAutoTagging>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RemoveBgTest : TestBase
{
    [Theory]
    [InlineData(Details::RemoveBg.Success)]
    [InlineData(Details::RemoveBg.Pending)]
    [InlineData(Details::RemoveBg.Failed)]
    public void Validation_Works(Details::RemoveBg rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Details::RemoveBg> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Details::RemoveBg>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Details::RemoveBg.Success)]
    [InlineData(Details::RemoveBg.Pending)]
    [InlineData(Details::RemoveBg.Failed)]
    public void SerializationRoundtrip_Works(Details::RemoveBg rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Details::RemoveBg> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Details::RemoveBg>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Details::RemoveBg>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Details::RemoveBg>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
