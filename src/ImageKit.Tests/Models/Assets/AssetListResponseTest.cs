using System;
using System.Collections.Generic;
using System.Text.Json;
using ImageKit.Core;
using ImageKit.Models.Assets;
using Files = ImageKit.Models.Files;

namespace ImageKit.Tests.Models.Assets;

public class AssetListResponseTest : TestBase
{
    [Fact]
    public void FileValidationWorks()
    {
        AssetListResponse value = new Files::File()
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
                        DefaultValue = "string",
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
        value.Validate();
    }

    [Fact]
    public void FolderValidationWorks()
    {
        AssetListResponse value = new Files::Folder()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            FolderID = "folderId",
            FolderPath = "folderPath",
            Name = "name",
            Type = Files::FolderType.Folder,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void FileSerializationRoundtripWorks()
    {
        AssetListResponse value = new Files::File()
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
                        DefaultValue = "string",
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AssetListResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FolderSerializationRoundtripWorks()
    {
        AssetListResponse value = new Files::Folder()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            FolderID = "folderId",
            FolderPath = "folderPath",
            Name = "name",
            Type = Files::FolderType.Folder,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AssetListResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
