using System;
using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Files = Imagekit.Models.Files;

namespace Imagekit.Tests.Models.Files;

public class FileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Files::File
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
            SelectedFieldsSchema = new Dictionary<string, Files::SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Files::Type.Text,
                        DefaultValue = new(
                            [
                                new Files::UnnamedSchemaWithArrayParent0(true),
                                new Files::UnnamedSchemaWithArrayParent0(10),
                                new Files::UnnamedSchemaWithArrayParent0("Hello"),
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
            Type = Files::FileType.File,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,
        };

        List<Files::AITag> expectedAITags =
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
        Dictionary<string, Files::SelectedFieldsSchemaItem> expectedSelectedFieldsSchema = new()
        {
            {
                "foo",
                new()
                {
                    Type = Files::Type.Text,
                    DefaultValue = new(
                        [
                            new Files::UnnamedSchemaWithArrayParent0(true),
                            new Files::UnnamedSchemaWithArrayParent0(10),
                            new Files::UnnamedSchemaWithArrayParent0("Hello"),
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
        ApiEnum<string, Files::FileType> expectedType = Files::FileType.File;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUrl = "https://example.com";
        Files::VersionInfo expectedVersionInfo = new() { ID = "id", Name = "name" };
        string expectedVideoCodec = "videoCodec";
        double expectedWidth = 0;

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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Files::File
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
            SelectedFieldsSchema = new Dictionary<string, Files::SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Files::Type.Text,
                        DefaultValue = new(
                            [
                                new Files::UnnamedSchemaWithArrayParent0(true),
                                new Files::UnnamedSchemaWithArrayParent0(10),
                                new Files::UnnamedSchemaWithArrayParent0("Hello"),
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
            Type = Files::FileType.File,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::File>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Files::File
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
            SelectedFieldsSchema = new Dictionary<string, Files::SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Files::Type.Text,
                        DefaultValue = new(
                            [
                                new Files::UnnamedSchemaWithArrayParent0(true),
                                new Files::UnnamedSchemaWithArrayParent0(10),
                                new Files::UnnamedSchemaWithArrayParent0("Hello"),
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
            Type = Files::FileType.File,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::File>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Files::AITag> expectedAITags =
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
        Dictionary<string, Files::SelectedFieldsSchemaItem> expectedSelectedFieldsSchema = new()
        {
            {
                "foo",
                new()
                {
                    Type = Files::Type.Text,
                    DefaultValue = new(
                        [
                            new Files::UnnamedSchemaWithArrayParent0(true),
                            new Files::UnnamedSchemaWithArrayParent0(10),
                            new Files::UnnamedSchemaWithArrayParent0("Hello"),
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
        ApiEnum<string, Files::FileType> expectedType = Files::FileType.File;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUrl = "https://example.com";
        Files::VersionInfo expectedVersionInfo = new() { ID = "id", Name = "name" };
        string expectedVideoCodec = "videoCodec";
        double expectedWidth = 0;

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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Files::File
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
            SelectedFieldsSchema = new Dictionary<string, Files::SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Files::Type.Text,
                        DefaultValue = new(
                            [
                                new Files::UnnamedSchemaWithArrayParent0(true),
                                new Files::UnnamedSchemaWithArrayParent0(10),
                                new Files::UnnamedSchemaWithArrayParent0("Hello"),
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
            Type = Files::FileType.File,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Files::File
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
            CustomCoordinates = "customCoordinates",
            Tags = ["string"],
        };

        Assert.Null(model.AudioCodec);
        Assert.False(model.RawData.ContainsKey("audioCodec"));
        Assert.Null(model.BitRate);
        Assert.False(model.RawData.ContainsKey("bitRate"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
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
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Files::File
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
            CustomCoordinates = "customCoordinates",
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Files::File
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
            CustomCoordinates = "customCoordinates",
            Tags = ["string"],

            // Null should be interpreted as omitted for these properties
            AudioCodec = null,
            BitRate = null,
            CreatedAt = null,
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
            Thumbnail = null,
            Type = null,
            UpdatedAt = null,
            Url = null,
            VersionInfo = null,
            VideoCodec = null,
            Width = null,
        };

        Assert.Null(model.AudioCodec);
        Assert.False(model.RawData.ContainsKey("audioCodec"));
        Assert.Null(model.BitRate);
        Assert.False(model.RawData.ContainsKey("bitRate"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
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
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Files::File
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
            CustomCoordinates = "customCoordinates",
            Tags = ["string"],

            // Null should be interpreted as omitted for these properties
            AudioCodec = null,
            BitRate = null,
            CreatedAt = null,
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
            Thumbnail = null,
            Type = null,
            UpdatedAt = null,
            Url = null,
            VersionInfo = null,
            VideoCodec = null,
            Width = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Files::File
        {
            AudioCodec = "audioCodec",
            BitRate = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            SelectedFieldsSchema = new Dictionary<string, Files::SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Files::Type.Text,
                        DefaultValue = new(
                            [
                                new Files::UnnamedSchemaWithArrayParent0(true),
                                new Files::UnnamedSchemaWithArrayParent0(10),
                                new Files::UnnamedSchemaWithArrayParent0("Hello"),
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
            Thumbnail = "https://example.com",
            Type = Files::FileType.File,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,
        };

        Assert.Null(model.AITags);
        Assert.False(model.RawData.ContainsKey("AITags"));
        Assert.Null(model.CustomCoordinates);
        Assert.False(model.RawData.ContainsKey("customCoordinates"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Files::File
        {
            AudioCodec = "audioCodec",
            BitRate = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            SelectedFieldsSchema = new Dictionary<string, Files::SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Files::Type.Text,
                        DefaultValue = new(
                            [
                                new Files::UnnamedSchemaWithArrayParent0(true),
                                new Files::UnnamedSchemaWithArrayParent0(10),
                                new Files::UnnamedSchemaWithArrayParent0("Hello"),
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
            Thumbnail = "https://example.com",
            Type = Files::FileType.File,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Files::File
        {
            AudioCodec = "audioCodec",
            BitRate = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            SelectedFieldsSchema = new Dictionary<string, Files::SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Files::Type.Text,
                        DefaultValue = new(
                            [
                                new Files::UnnamedSchemaWithArrayParent0(true),
                                new Files::UnnamedSchemaWithArrayParent0(10),
                                new Files::UnnamedSchemaWithArrayParent0("Hello"),
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
            Thumbnail = "https://example.com",
            Type = Files::FileType.File,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,

            AITags = null,
            CustomCoordinates = null,
            Tags = null,
        };

        Assert.Null(model.AITags);
        Assert.True(model.RawData.ContainsKey("AITags"));
        Assert.Null(model.CustomCoordinates);
        Assert.True(model.RawData.ContainsKey("customCoordinates"));
        Assert.Null(model.Tags);
        Assert.True(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Files::File
        {
            AudioCodec = "audioCodec",
            BitRate = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            SelectedFieldsSchema = new Dictionary<string, Files::SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Files::Type.Text,
                        DefaultValue = new(
                            [
                                new Files::UnnamedSchemaWithArrayParent0(true),
                                new Files::UnnamedSchemaWithArrayParent0(10),
                                new Files::UnnamedSchemaWithArrayParent0("Hello"),
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
            Thumbnail = "https://example.com",
            Type = Files::FileType.File,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,

            AITags = null,
            CustomCoordinates = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Files::File
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
            SelectedFieldsSchema = new Dictionary<string, Files::SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Files::Type.Text,
                        DefaultValue = new(
                            [
                                new Files::UnnamedSchemaWithArrayParent0(true),
                                new Files::UnnamedSchemaWithArrayParent0(10),
                                new Files::UnnamedSchemaWithArrayParent0("Hello"),
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
            Type = Files::FileType.File,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,
        };

        Files::File copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AITagTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Files::AITag
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
        var model = new Files::AITag
        {
            Confidence = 0,
            Name = "name",
            Source = "source",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::AITag>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Files::AITag
        {
            Confidence = 0,
            Name = "name",
            Source = "source",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::AITag>(
            element,
            ModelBase.SerializerOptions
        );
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
        var model = new Files::AITag
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
        var model = new Files::AITag { };

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
        var model = new Files::AITag { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Files::AITag
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
        var model = new Files::AITag
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
        var model = new Files::AITag
        {
            Confidence = 0,
            Name = "name",
            Source = "source",
        };

        Files::AITag copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SelectedFieldsSchemaItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Files::SelectedFieldsSchemaItem
        {
            Type = Files::Type.Text,
            DefaultValue = new(
                [
                    new Files::UnnamedSchemaWithArrayParent0(true),
                    new Files::UnnamedSchemaWithArrayParent0(10),
                    new Files::UnnamedSchemaWithArrayParent0("Hello"),
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
        };

        ApiEnum<string, Files::Type> expectedType = Files::Type.Text;
        Files::DefaultValue expectedDefaultValue = new(
            [
                new Files::UnnamedSchemaWithArrayParent0(true),
                new Files::UnnamedSchemaWithArrayParent0(10),
                new Files::UnnamedSchemaWithArrayParent0("Hello"),
            ]
        );
        bool expectedIsValueRequired = true;
        double expectedMaxLength = 0;
        Files::MaxValue expectedMaxValue = "string";
        double expectedMinLength = 0;
        Files::MinValue expectedMinValue = "string";
        bool expectedReadOnly = true;
        List<Files::SelectOption> expectedSelectOptions =
        [
            "small",
            "medium",
            "large",
            30,
            40,
            true,
        ];
        bool expectedSelectOptionsTruncated = true;

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedDefaultValue, model.DefaultValue);
        Assert.Equal(expectedIsValueRequired, model.IsValueRequired);
        Assert.Equal(expectedMaxLength, model.MaxLength);
        Assert.Equal(expectedMaxValue, model.MaxValue);
        Assert.Equal(expectedMinLength, model.MinLength);
        Assert.Equal(expectedMinValue, model.MinValue);
        Assert.Equal(expectedReadOnly, model.ReadOnly);
        Assert.NotNull(model.SelectOptions);
        Assert.Equal(expectedSelectOptions.Count, model.SelectOptions.Count);
        for (int i = 0; i < expectedSelectOptions.Count; i++)
        {
            Assert.Equal(expectedSelectOptions[i], model.SelectOptions[i]);
        }
        Assert.Equal(expectedSelectOptionsTruncated, model.SelectOptionsTruncated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Files::SelectedFieldsSchemaItem
        {
            Type = Files::Type.Text,
            DefaultValue = new(
                [
                    new Files::UnnamedSchemaWithArrayParent0(true),
                    new Files::UnnamedSchemaWithArrayParent0(10),
                    new Files::UnnamedSchemaWithArrayParent0("Hello"),
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::SelectedFieldsSchemaItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Files::SelectedFieldsSchemaItem
        {
            Type = Files::Type.Text,
            DefaultValue = new(
                [
                    new Files::UnnamedSchemaWithArrayParent0(true),
                    new Files::UnnamedSchemaWithArrayParent0(10),
                    new Files::UnnamedSchemaWithArrayParent0("Hello"),
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::SelectedFieldsSchemaItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Files::Type> expectedType = Files::Type.Text;
        Files::DefaultValue expectedDefaultValue = new(
            [
                new Files::UnnamedSchemaWithArrayParent0(true),
                new Files::UnnamedSchemaWithArrayParent0(10),
                new Files::UnnamedSchemaWithArrayParent0("Hello"),
            ]
        );
        bool expectedIsValueRequired = true;
        double expectedMaxLength = 0;
        Files::MaxValue expectedMaxValue = "string";
        double expectedMinLength = 0;
        Files::MinValue expectedMinValue = "string";
        bool expectedReadOnly = true;
        List<Files::SelectOption> expectedSelectOptions =
        [
            "small",
            "medium",
            "large",
            30,
            40,
            true,
        ];
        bool expectedSelectOptionsTruncated = true;

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedDefaultValue, deserialized.DefaultValue);
        Assert.Equal(expectedIsValueRequired, deserialized.IsValueRequired);
        Assert.Equal(expectedMaxLength, deserialized.MaxLength);
        Assert.Equal(expectedMaxValue, deserialized.MaxValue);
        Assert.Equal(expectedMinLength, deserialized.MinLength);
        Assert.Equal(expectedMinValue, deserialized.MinValue);
        Assert.Equal(expectedReadOnly, deserialized.ReadOnly);
        Assert.NotNull(deserialized.SelectOptions);
        Assert.Equal(expectedSelectOptions.Count, deserialized.SelectOptions.Count);
        for (int i = 0; i < expectedSelectOptions.Count; i++)
        {
            Assert.Equal(expectedSelectOptions[i], deserialized.SelectOptions[i]);
        }
        Assert.Equal(expectedSelectOptionsTruncated, deserialized.SelectOptionsTruncated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Files::SelectedFieldsSchemaItem
        {
            Type = Files::Type.Text,
            DefaultValue = new(
                [
                    new Files::UnnamedSchemaWithArrayParent0(true),
                    new Files::UnnamedSchemaWithArrayParent0(10),
                    new Files::UnnamedSchemaWithArrayParent0("Hello"),
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Files::SelectedFieldsSchemaItem { Type = Files::Type.Text };

        Assert.Null(model.DefaultValue);
        Assert.False(model.RawData.ContainsKey("defaultValue"));
        Assert.Null(model.IsValueRequired);
        Assert.False(model.RawData.ContainsKey("isValueRequired"));
        Assert.Null(model.MaxLength);
        Assert.False(model.RawData.ContainsKey("maxLength"));
        Assert.Null(model.MaxValue);
        Assert.False(model.RawData.ContainsKey("maxValue"));
        Assert.Null(model.MinLength);
        Assert.False(model.RawData.ContainsKey("minLength"));
        Assert.Null(model.MinValue);
        Assert.False(model.RawData.ContainsKey("minValue"));
        Assert.Null(model.ReadOnly);
        Assert.False(model.RawData.ContainsKey("readOnly"));
        Assert.Null(model.SelectOptions);
        Assert.False(model.RawData.ContainsKey("selectOptions"));
        Assert.Null(model.SelectOptionsTruncated);
        Assert.False(model.RawData.ContainsKey("selectOptionsTruncated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Files::SelectedFieldsSchemaItem { Type = Files::Type.Text };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Files::SelectedFieldsSchemaItem
        {
            Type = Files::Type.Text,

            // Null should be interpreted as omitted for these properties
            DefaultValue = null,
            IsValueRequired = null,
            MaxLength = null,
            MaxValue = null,
            MinLength = null,
            MinValue = null,
            ReadOnly = null,
            SelectOptions = null,
            SelectOptionsTruncated = null,
        };

        Assert.Null(model.DefaultValue);
        Assert.False(model.RawData.ContainsKey("defaultValue"));
        Assert.Null(model.IsValueRequired);
        Assert.False(model.RawData.ContainsKey("isValueRequired"));
        Assert.Null(model.MaxLength);
        Assert.False(model.RawData.ContainsKey("maxLength"));
        Assert.Null(model.MaxValue);
        Assert.False(model.RawData.ContainsKey("maxValue"));
        Assert.Null(model.MinLength);
        Assert.False(model.RawData.ContainsKey("minLength"));
        Assert.Null(model.MinValue);
        Assert.False(model.RawData.ContainsKey("minValue"));
        Assert.Null(model.ReadOnly);
        Assert.False(model.RawData.ContainsKey("readOnly"));
        Assert.Null(model.SelectOptions);
        Assert.False(model.RawData.ContainsKey("selectOptions"));
        Assert.Null(model.SelectOptionsTruncated);
        Assert.False(model.RawData.ContainsKey("selectOptionsTruncated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Files::SelectedFieldsSchemaItem
        {
            Type = Files::Type.Text,

            // Null should be interpreted as omitted for these properties
            DefaultValue = null,
            IsValueRequired = null,
            MaxLength = null,
            MaxValue = null,
            MinLength = null,
            MinValue = null,
            ReadOnly = null,
            SelectOptions = null,
            SelectOptionsTruncated = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Files::SelectedFieldsSchemaItem
        {
            Type = Files::Type.Text,
            DefaultValue = new(
                [
                    new Files::UnnamedSchemaWithArrayParent0(true),
                    new Files::UnnamedSchemaWithArrayParent0(10),
                    new Files::UnnamedSchemaWithArrayParent0("Hello"),
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
        };

        Files::SelectedFieldsSchemaItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Files::Type.Text)]
    [InlineData(Files::Type.Textarea)]
    [InlineData(Files::Type.Number)]
    [InlineData(Files::Type.Date)]
    [InlineData(Files::Type.Boolean)]
    [InlineData(Files::Type.SingleSelect)]
    [InlineData(Files::Type.MultiSelect)]
    public void Validation_Works(Files::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Files::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Files::Type.Text)]
    [InlineData(Files::Type.Textarea)]
    [InlineData(Files::Type.Number)]
    [InlineData(Files::Type.Date)]
    [InlineData(Files::Type.Boolean)]
    [InlineData(Files::Type.SingleSelect)]
    [InlineData(Files::Type.MultiSelect)]
    public void SerializationRoundtrip_Works(Files::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Files::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Files::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Files::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DefaultValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Files::DefaultValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        Files::DefaultValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        Files::DefaultValue value = true;
        value.Validate();
    }

    [Fact]
    public void MixedValidationWorks()
    {
        Files::DefaultValue value = new(
            [
                new Files::UnnamedSchemaWithArrayParent0(true),
                new Files::UnnamedSchemaWithArrayParent0(10),
                new Files::UnnamedSchemaWithArrayParent0("Hello"),
            ]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Files::DefaultValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::DefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Files::DefaultValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::DefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        Files::DefaultValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::DefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MixedSerializationRoundtripWorks()
    {
        Files::DefaultValue value = new(
            [
                new Files::UnnamedSchemaWithArrayParent0(true),
                new Files::UnnamedSchemaWithArrayParent0(10),
                new Files::UnnamedSchemaWithArrayParent0("Hello"),
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::DefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnnamedSchemaWithArrayParent0Test : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Files::UnnamedSchemaWithArrayParent0 value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        Files::UnnamedSchemaWithArrayParent0 value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        Files::UnnamedSchemaWithArrayParent0 value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Files::UnnamedSchemaWithArrayParent0 value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::UnnamedSchemaWithArrayParent0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Files::UnnamedSchemaWithArrayParent0 value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::UnnamedSchemaWithArrayParent0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        Files::UnnamedSchemaWithArrayParent0 value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::UnnamedSchemaWithArrayParent0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MaxValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Files::MaxValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        Files::MaxValue value = 0;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Files::MaxValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::MaxValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Files::MaxValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::MaxValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MinValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Files::MinValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        Files::MinValue value = 0;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Files::MinValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::MinValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Files::MinValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::MinValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SelectOptionTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Files::SelectOption value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        Files::SelectOption value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        Files::SelectOption value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Files::SelectOption value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::SelectOption>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Files::SelectOption value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::SelectOption>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        Files::SelectOption value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::SelectOption>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FileTypeTest : TestBase
{
    [Theory]
    [InlineData(Files::FileType.File)]
    [InlineData(Files::FileType.FileVersion)]
    public void Validation_Works(Files::FileType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::FileType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Files::FileType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Files::FileType.File)]
    [InlineData(Files::FileType.FileVersion)]
    public void SerializationRoundtrip_Works(Files::FileType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::FileType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Files::FileType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Files::FileType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Files::FileType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VersionInfoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Files::VersionInfo { ID = "id", Name = "name" };

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Files::VersionInfo { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::VersionInfo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Files::VersionInfo { ID = "id", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::VersionInfo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Files::VersionInfo { ID = "id", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Files::VersionInfo { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Files::VersionInfo { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Files::VersionInfo
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Files::VersionInfo
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Files::VersionInfo { ID = "id", Name = "name" };

        Files::VersionInfo copied = new(model);

        Assert.Equal(model, copied);
    }
}
