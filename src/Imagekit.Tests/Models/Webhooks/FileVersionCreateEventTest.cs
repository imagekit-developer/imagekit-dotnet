using System;
using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Webhooks;
using Files = Imagekit.Models.Files;

namespace Imagekit.Tests.Models.Webhooks;

public class FileVersionCreateEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileVersionCreateEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
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
                                    new Files::DefaultValueArrayItem(true),
                                    new Files::DefaultValueArrayItem(10),
                                    new Files::DefaultValueArrayItem("Hello"),
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
            },
        };

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Files::File expectedData = new()
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
                                new Files::DefaultValueArrayItem(true),
                                new Files::DefaultValueArrayItem(10),
                                new Files::DefaultValueArrayItem("Hello"),
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

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileVersionCreateEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
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
                                    new Files::DefaultValueArrayItem(true),
                                    new Files::DefaultValueArrayItem(10),
                                    new Files::DefaultValueArrayItem("Hello"),
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileVersionCreateEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileVersionCreateEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
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
                                    new Files::DefaultValueArrayItem(true),
                                    new Files::DefaultValueArrayItem(10),
                                    new Files::DefaultValueArrayItem("Hello"),
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileVersionCreateEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Files::File expectedData = new()
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
                                new Files::DefaultValueArrayItem(true),
                                new Files::DefaultValueArrayItem(10),
                                new Files::DefaultValueArrayItem("Hello"),
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

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileVersionCreateEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
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
                                    new Files::DefaultValueArrayItem(true),
                                    new Files::DefaultValueArrayItem(10),
                                    new Files::DefaultValueArrayItem("Hello"),
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileVersionCreateEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
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
                                    new Files::DefaultValueArrayItem(true),
                                    new Files::DefaultValueArrayItem(10),
                                    new Files::DefaultValueArrayItem("Hello"),
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
            },
        };

        FileVersionCreateEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FileVersionCreateEventFileVersionCreateEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileVersionCreateEventFileVersionCreateEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
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
                                    new Files::DefaultValueArrayItem(true),
                                    new Files::DefaultValueArrayItem(10),
                                    new Files::DefaultValueArrayItem("Hello"),
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
            },
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Files::File expectedData = new()
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
                                new Files::DefaultValueArrayItem(true),
                                new Files::DefaultValueArrayItem(10),
                                new Files::DefaultValueArrayItem("Hello"),
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
        JsonElement expectedType = JsonSerializer.SerializeToElement("file-version.created");

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileVersionCreateEventFileVersionCreateEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
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
                                    new Files::DefaultValueArrayItem(true),
                                    new Files::DefaultValueArrayItem(10),
                                    new Files::DefaultValueArrayItem("Hello"),
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileVersionCreateEventFileVersionCreateEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileVersionCreateEventFileVersionCreateEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
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
                                    new Files::DefaultValueArrayItem(true),
                                    new Files::DefaultValueArrayItem(10),
                                    new Files::DefaultValueArrayItem("Hello"),
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileVersionCreateEventFileVersionCreateEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Files::File expectedData = new()
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
                                new Files::DefaultValueArrayItem(true),
                                new Files::DefaultValueArrayItem(10),
                                new Files::DefaultValueArrayItem("Hello"),
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
        JsonElement expectedType = JsonSerializer.SerializeToElement("file-version.created");

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileVersionCreateEventFileVersionCreateEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
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
                                    new Files::DefaultValueArrayItem(true),
                                    new Files::DefaultValueArrayItem(10),
                                    new Files::DefaultValueArrayItem("Hello"),
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileVersionCreateEventFileVersionCreateEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
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
                                    new Files::DefaultValueArrayItem(true),
                                    new Files::DefaultValueArrayItem(10),
                                    new Files::DefaultValueArrayItem("Hello"),
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
            },
        };

        FileVersionCreateEventFileVersionCreateEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
