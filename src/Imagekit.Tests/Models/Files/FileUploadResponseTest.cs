using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models;
using Files = Imagekit.Models.Files;

namespace Imagekit.Tests.Models.Files;

public class FileUploadResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Files::FileUploadResponse
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
            ExtensionStatus = new()
            {
                AIAutoDescription =
                    Files::FileUploadResponseExtensionStatusAIAutoDescription.Success,
                AITasks = Files::FileUploadResponseExtensionStatusAITasks.Success,
                AwsAutoTagging = Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success,
                GoogleAutoTagging =
                    Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success,
                RemoveBg = Files::FileUploadResponseExtensionStatusRemoveBg.Success,
            },
            FileID = "fileId",
            FilePath = "filePath",
            FileType = "fileType",
            Height = 0,
            IsPrivateFile = true,
            IsPublished = true,
            Metadata = new()
            {
                AudioCodec = "audioCodec",
                BitRate = 0,
                Density = 0,
                Duration = 0,
                Exif = new()
                {
                    ExifValue = new()
                    {
                        ApertureValue = 0,
                        ColorSpace = 0,
                        CreateDate = "CreateDate",
                        CustomRendered = 0,
                        DateTimeOriginal = "DateTimeOriginal",
                        ExifImageHeight = 0,
                        ExifImageWidth = 0,
                        ExifVersion = "ExifVersion",
                        ExposureCompensation = 0,
                        ExposureMode = 0,
                        ExposureProgram = 0,
                        ExposureTime = 0,
                        Flash = 0,
                        FlashpixVersion = "FlashpixVersion",
                        FNumber = 0,
                        FocalLength = 0,
                        FocalPlaneResolutionUnit = 0,
                        FocalPlaneXResolution = 0,
                        FocalPlaneYResolution = 0,
                        InteropOffset = 0,
                        Iso = 0,
                        MeteringMode = 0,
                        SceneCaptureType = 0,
                        ShutterSpeedValue = 0,
                        SubSecTime = "SubSecTime",
                        WhiteBalance = 0,
                    },
                    Gps = new() { GpsVersionID = [0] },
                    Image = new()
                    {
                        ExifOffset = 0,
                        GpsInfo = 0,
                        Make = "Make",
                        Model = "Model",
                        ModifyDate = "ModifyDate",
                        Orientation = 0,
                        ResolutionUnit = 0,
                        Software = "Software",
                        XResolution = 0,
                        YCbCrPositioning = 0,
                        YResolution = 0,
                    },
                    Interoperability = new()
                    {
                        InteropIndex = "InteropIndex",
                        InteropVersion = "InteropVersion",
                    },
                    Makernote = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Thumbnail = new()
                    {
                        Compression = 0,
                        ResolutionUnit = 0,
                        ThumbnailLength = 0,
                        ThumbnailOffset = 0,
                        XResolution = 0,
                        YResolution = 0,
                    },
                },
                Format = "format",
                HasColorProfile = true,
                HasTransparency = true,
                Height = 0,
                PHash = "pHash",
                Quality = 0,
                Size = 0,
                VideoCodec = "videoCodec",
                Width = 0,
            },
            Name = "name",
            SelectedFieldsSchema = new Dictionary<string, SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Type.Text,
                        DefaultValue = new(
                            [
                                new DefaultValueArrayItem(true),
                                new DefaultValueArrayItem(10),
                                new DefaultValueArrayItem("Hello"),
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
            ThumbnailUrl = "thumbnailUrl",
            Url = "url",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,
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
        Files::FileUploadResponseExtensionStatus expectedExtensionStatus = new()
        {
            AIAutoDescription = Files::FileUploadResponseExtensionStatusAIAutoDescription.Success,
            AITasks = Files::FileUploadResponseExtensionStatusAITasks.Success,
            AwsAutoTagging = Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success,
            GoogleAutoTagging = Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success,
            RemoveBg = Files::FileUploadResponseExtensionStatusRemoveBg.Success,
        };
        string expectedFileID = "fileId";
        string expectedFilePath = "filePath";
        string expectedFileType = "fileType";
        double expectedHeight = 0;
        bool expectedIsPrivateFile = true;
        bool expectedIsPublished = true;
        Files::FileMetadata expectedMetadata = new()
        {
            AudioCodec = "audioCodec",
            BitRate = 0,
            Density = 0,
            Duration = 0,
            Exif = new()
            {
                ExifValue = new()
                {
                    ApertureValue = 0,
                    ColorSpace = 0,
                    CreateDate = "CreateDate",
                    CustomRendered = 0,
                    DateTimeOriginal = "DateTimeOriginal",
                    ExifImageHeight = 0,
                    ExifImageWidth = 0,
                    ExifVersion = "ExifVersion",
                    ExposureCompensation = 0,
                    ExposureMode = 0,
                    ExposureProgram = 0,
                    ExposureTime = 0,
                    Flash = 0,
                    FlashpixVersion = "FlashpixVersion",
                    FNumber = 0,
                    FocalLength = 0,
                    FocalPlaneResolutionUnit = 0,
                    FocalPlaneXResolution = 0,
                    FocalPlaneYResolution = 0,
                    InteropOffset = 0,
                    Iso = 0,
                    MeteringMode = 0,
                    SceneCaptureType = 0,
                    ShutterSpeedValue = 0,
                    SubSecTime = "SubSecTime",
                    WhiteBalance = 0,
                },
                Gps = new() { GpsVersionID = [0] },
                Image = new()
                {
                    ExifOffset = 0,
                    GpsInfo = 0,
                    Make = "Make",
                    Model = "Model",
                    ModifyDate = "ModifyDate",
                    Orientation = 0,
                    ResolutionUnit = 0,
                    Software = "Software",
                    XResolution = 0,
                    YCbCrPositioning = 0,
                    YResolution = 0,
                },
                Interoperability = new()
                {
                    InteropIndex = "InteropIndex",
                    InteropVersion = "InteropVersion",
                },
                Makernote = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Thumbnail = new()
                {
                    Compression = 0,
                    ResolutionUnit = 0,
                    ThumbnailLength = 0,
                    ThumbnailOffset = 0,
                    XResolution = 0,
                    YResolution = 0,
                },
            },
            Format = "format",
            HasColorProfile = true,
            HasTransparency = true,
            Height = 0,
            PHash = "pHash",
            Quality = 0,
            Size = 0,
            VideoCodec = "videoCodec",
            Width = 0,
        };
        string expectedName = "name";
        Dictionary<string, SelectedFieldsSchemaItem> expectedSelectedFieldsSchema = new()
        {
            {
                "foo",
                new()
                {
                    Type = Type.Text,
                    DefaultValue = new(
                        [
                            new DefaultValueArrayItem(true),
                            new DefaultValueArrayItem(10),
                            new DefaultValueArrayItem("Hello"),
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
        string expectedThumbnailUrl = "thumbnailUrl";
        string expectedUrl = "url";
        VersionInfo expectedVersionInfo = new() { ID = "id", Name = "name" };
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
        Assert.Equal(expectedExtensionStatus, model.ExtensionStatus);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedFilePath, model.FilePath);
        Assert.Equal(expectedFileType, model.FileType);
        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedIsPrivateFile, model.IsPrivateFile);
        Assert.Equal(expectedIsPublished, model.IsPublished);
        Assert.Equal(expectedMetadata, model.Metadata);
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
        Assert.Equal(expectedThumbnailUrl, model.ThumbnailUrl);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedVersionInfo, model.VersionInfo);
        Assert.Equal(expectedVideoCodec, model.VideoCodec);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Files::FileUploadResponse
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
            ExtensionStatus = new()
            {
                AIAutoDescription =
                    Files::FileUploadResponseExtensionStatusAIAutoDescription.Success,
                AITasks = Files::FileUploadResponseExtensionStatusAITasks.Success,
                AwsAutoTagging = Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success,
                GoogleAutoTagging =
                    Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success,
                RemoveBg = Files::FileUploadResponseExtensionStatusRemoveBg.Success,
            },
            FileID = "fileId",
            FilePath = "filePath",
            FileType = "fileType",
            Height = 0,
            IsPrivateFile = true,
            IsPublished = true,
            Metadata = new()
            {
                AudioCodec = "audioCodec",
                BitRate = 0,
                Density = 0,
                Duration = 0,
                Exif = new()
                {
                    ExifValue = new()
                    {
                        ApertureValue = 0,
                        ColorSpace = 0,
                        CreateDate = "CreateDate",
                        CustomRendered = 0,
                        DateTimeOriginal = "DateTimeOriginal",
                        ExifImageHeight = 0,
                        ExifImageWidth = 0,
                        ExifVersion = "ExifVersion",
                        ExposureCompensation = 0,
                        ExposureMode = 0,
                        ExposureProgram = 0,
                        ExposureTime = 0,
                        Flash = 0,
                        FlashpixVersion = "FlashpixVersion",
                        FNumber = 0,
                        FocalLength = 0,
                        FocalPlaneResolutionUnit = 0,
                        FocalPlaneXResolution = 0,
                        FocalPlaneYResolution = 0,
                        InteropOffset = 0,
                        Iso = 0,
                        MeteringMode = 0,
                        SceneCaptureType = 0,
                        ShutterSpeedValue = 0,
                        SubSecTime = "SubSecTime",
                        WhiteBalance = 0,
                    },
                    Gps = new() { GpsVersionID = [0] },
                    Image = new()
                    {
                        ExifOffset = 0,
                        GpsInfo = 0,
                        Make = "Make",
                        Model = "Model",
                        ModifyDate = "ModifyDate",
                        Orientation = 0,
                        ResolutionUnit = 0,
                        Software = "Software",
                        XResolution = 0,
                        YCbCrPositioning = 0,
                        YResolution = 0,
                    },
                    Interoperability = new()
                    {
                        InteropIndex = "InteropIndex",
                        InteropVersion = "InteropVersion",
                    },
                    Makernote = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Thumbnail = new()
                    {
                        Compression = 0,
                        ResolutionUnit = 0,
                        ThumbnailLength = 0,
                        ThumbnailOffset = 0,
                        XResolution = 0,
                        YResolution = 0,
                    },
                },
                Format = "format",
                HasColorProfile = true,
                HasTransparency = true,
                Height = 0,
                PHash = "pHash",
                Quality = 0,
                Size = 0,
                VideoCodec = "videoCodec",
                Width = 0,
            },
            Name = "name",
            SelectedFieldsSchema = new Dictionary<string, SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Type.Text,
                        DefaultValue = new(
                            [
                                new DefaultValueArrayItem(true),
                                new DefaultValueArrayItem(10),
                                new DefaultValueArrayItem("Hello"),
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
            ThumbnailUrl = "thumbnailUrl",
            Url = "url",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::FileUploadResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Files::FileUploadResponse
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
            ExtensionStatus = new()
            {
                AIAutoDescription =
                    Files::FileUploadResponseExtensionStatusAIAutoDescription.Success,
                AITasks = Files::FileUploadResponseExtensionStatusAITasks.Success,
                AwsAutoTagging = Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success,
                GoogleAutoTagging =
                    Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success,
                RemoveBg = Files::FileUploadResponseExtensionStatusRemoveBg.Success,
            },
            FileID = "fileId",
            FilePath = "filePath",
            FileType = "fileType",
            Height = 0,
            IsPrivateFile = true,
            IsPublished = true,
            Metadata = new()
            {
                AudioCodec = "audioCodec",
                BitRate = 0,
                Density = 0,
                Duration = 0,
                Exif = new()
                {
                    ExifValue = new()
                    {
                        ApertureValue = 0,
                        ColorSpace = 0,
                        CreateDate = "CreateDate",
                        CustomRendered = 0,
                        DateTimeOriginal = "DateTimeOriginal",
                        ExifImageHeight = 0,
                        ExifImageWidth = 0,
                        ExifVersion = "ExifVersion",
                        ExposureCompensation = 0,
                        ExposureMode = 0,
                        ExposureProgram = 0,
                        ExposureTime = 0,
                        Flash = 0,
                        FlashpixVersion = "FlashpixVersion",
                        FNumber = 0,
                        FocalLength = 0,
                        FocalPlaneResolutionUnit = 0,
                        FocalPlaneXResolution = 0,
                        FocalPlaneYResolution = 0,
                        InteropOffset = 0,
                        Iso = 0,
                        MeteringMode = 0,
                        SceneCaptureType = 0,
                        ShutterSpeedValue = 0,
                        SubSecTime = "SubSecTime",
                        WhiteBalance = 0,
                    },
                    Gps = new() { GpsVersionID = [0] },
                    Image = new()
                    {
                        ExifOffset = 0,
                        GpsInfo = 0,
                        Make = "Make",
                        Model = "Model",
                        ModifyDate = "ModifyDate",
                        Orientation = 0,
                        ResolutionUnit = 0,
                        Software = "Software",
                        XResolution = 0,
                        YCbCrPositioning = 0,
                        YResolution = 0,
                    },
                    Interoperability = new()
                    {
                        InteropIndex = "InteropIndex",
                        InteropVersion = "InteropVersion",
                    },
                    Makernote = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Thumbnail = new()
                    {
                        Compression = 0,
                        ResolutionUnit = 0,
                        ThumbnailLength = 0,
                        ThumbnailOffset = 0,
                        XResolution = 0,
                        YResolution = 0,
                    },
                },
                Format = "format",
                HasColorProfile = true,
                HasTransparency = true,
                Height = 0,
                PHash = "pHash",
                Quality = 0,
                Size = 0,
                VideoCodec = "videoCodec",
                Width = 0,
            },
            Name = "name",
            SelectedFieldsSchema = new Dictionary<string, SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Type.Text,
                        DefaultValue = new(
                            [
                                new DefaultValueArrayItem(true),
                                new DefaultValueArrayItem(10),
                                new DefaultValueArrayItem("Hello"),
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
            ThumbnailUrl = "thumbnailUrl",
            Url = "url",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::FileUploadResponse>(
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
        Files::FileUploadResponseExtensionStatus expectedExtensionStatus = new()
        {
            AIAutoDescription = Files::FileUploadResponseExtensionStatusAIAutoDescription.Success,
            AITasks = Files::FileUploadResponseExtensionStatusAITasks.Success,
            AwsAutoTagging = Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success,
            GoogleAutoTagging = Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success,
            RemoveBg = Files::FileUploadResponseExtensionStatusRemoveBg.Success,
        };
        string expectedFileID = "fileId";
        string expectedFilePath = "filePath";
        string expectedFileType = "fileType";
        double expectedHeight = 0;
        bool expectedIsPrivateFile = true;
        bool expectedIsPublished = true;
        Files::FileMetadata expectedMetadata = new()
        {
            AudioCodec = "audioCodec",
            BitRate = 0,
            Density = 0,
            Duration = 0,
            Exif = new()
            {
                ExifValue = new()
                {
                    ApertureValue = 0,
                    ColorSpace = 0,
                    CreateDate = "CreateDate",
                    CustomRendered = 0,
                    DateTimeOriginal = "DateTimeOriginal",
                    ExifImageHeight = 0,
                    ExifImageWidth = 0,
                    ExifVersion = "ExifVersion",
                    ExposureCompensation = 0,
                    ExposureMode = 0,
                    ExposureProgram = 0,
                    ExposureTime = 0,
                    Flash = 0,
                    FlashpixVersion = "FlashpixVersion",
                    FNumber = 0,
                    FocalLength = 0,
                    FocalPlaneResolutionUnit = 0,
                    FocalPlaneXResolution = 0,
                    FocalPlaneYResolution = 0,
                    InteropOffset = 0,
                    Iso = 0,
                    MeteringMode = 0,
                    SceneCaptureType = 0,
                    ShutterSpeedValue = 0,
                    SubSecTime = "SubSecTime",
                    WhiteBalance = 0,
                },
                Gps = new() { GpsVersionID = [0] },
                Image = new()
                {
                    ExifOffset = 0,
                    GpsInfo = 0,
                    Make = "Make",
                    Model = "Model",
                    ModifyDate = "ModifyDate",
                    Orientation = 0,
                    ResolutionUnit = 0,
                    Software = "Software",
                    XResolution = 0,
                    YCbCrPositioning = 0,
                    YResolution = 0,
                },
                Interoperability = new()
                {
                    InteropIndex = "InteropIndex",
                    InteropVersion = "InteropVersion",
                },
                Makernote = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Thumbnail = new()
                {
                    Compression = 0,
                    ResolutionUnit = 0,
                    ThumbnailLength = 0,
                    ThumbnailOffset = 0,
                    XResolution = 0,
                    YResolution = 0,
                },
            },
            Format = "format",
            HasColorProfile = true,
            HasTransparency = true,
            Height = 0,
            PHash = "pHash",
            Quality = 0,
            Size = 0,
            VideoCodec = "videoCodec",
            Width = 0,
        };
        string expectedName = "name";
        Dictionary<string, SelectedFieldsSchemaItem> expectedSelectedFieldsSchema = new()
        {
            {
                "foo",
                new()
                {
                    Type = Type.Text,
                    DefaultValue = new(
                        [
                            new DefaultValueArrayItem(true),
                            new DefaultValueArrayItem(10),
                            new DefaultValueArrayItem("Hello"),
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
        string expectedThumbnailUrl = "thumbnailUrl";
        string expectedUrl = "url";
        VersionInfo expectedVersionInfo = new() { ID = "id", Name = "name" };
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
        Assert.Equal(expectedExtensionStatus, deserialized.ExtensionStatus);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedFilePath, deserialized.FilePath);
        Assert.Equal(expectedFileType, deserialized.FileType);
        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedIsPrivateFile, deserialized.IsPrivateFile);
        Assert.Equal(expectedIsPublished, deserialized.IsPublished);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
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
        Assert.Equal(expectedThumbnailUrl, deserialized.ThumbnailUrl);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedVersionInfo, deserialized.VersionInfo);
        Assert.Equal(expectedVideoCodec, deserialized.VideoCodec);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Files::FileUploadResponse
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
            ExtensionStatus = new()
            {
                AIAutoDescription =
                    Files::FileUploadResponseExtensionStatusAIAutoDescription.Success,
                AITasks = Files::FileUploadResponseExtensionStatusAITasks.Success,
                AwsAutoTagging = Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success,
                GoogleAutoTagging =
                    Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success,
                RemoveBg = Files::FileUploadResponseExtensionStatusRemoveBg.Success,
            },
            FileID = "fileId",
            FilePath = "filePath",
            FileType = "fileType",
            Height = 0,
            IsPrivateFile = true,
            IsPublished = true,
            Metadata = new()
            {
                AudioCodec = "audioCodec",
                BitRate = 0,
                Density = 0,
                Duration = 0,
                Exif = new()
                {
                    ExifValue = new()
                    {
                        ApertureValue = 0,
                        ColorSpace = 0,
                        CreateDate = "CreateDate",
                        CustomRendered = 0,
                        DateTimeOriginal = "DateTimeOriginal",
                        ExifImageHeight = 0,
                        ExifImageWidth = 0,
                        ExifVersion = "ExifVersion",
                        ExposureCompensation = 0,
                        ExposureMode = 0,
                        ExposureProgram = 0,
                        ExposureTime = 0,
                        Flash = 0,
                        FlashpixVersion = "FlashpixVersion",
                        FNumber = 0,
                        FocalLength = 0,
                        FocalPlaneResolutionUnit = 0,
                        FocalPlaneXResolution = 0,
                        FocalPlaneYResolution = 0,
                        InteropOffset = 0,
                        Iso = 0,
                        MeteringMode = 0,
                        SceneCaptureType = 0,
                        ShutterSpeedValue = 0,
                        SubSecTime = "SubSecTime",
                        WhiteBalance = 0,
                    },
                    Gps = new() { GpsVersionID = [0] },
                    Image = new()
                    {
                        ExifOffset = 0,
                        GpsInfo = 0,
                        Make = "Make",
                        Model = "Model",
                        ModifyDate = "ModifyDate",
                        Orientation = 0,
                        ResolutionUnit = 0,
                        Software = "Software",
                        XResolution = 0,
                        YCbCrPositioning = 0,
                        YResolution = 0,
                    },
                    Interoperability = new()
                    {
                        InteropIndex = "InteropIndex",
                        InteropVersion = "InteropVersion",
                    },
                    Makernote = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Thumbnail = new()
                    {
                        Compression = 0,
                        ResolutionUnit = 0,
                        ThumbnailLength = 0,
                        ThumbnailOffset = 0,
                        XResolution = 0,
                        YResolution = 0,
                    },
                },
                Format = "format",
                HasColorProfile = true,
                HasTransparency = true,
                Height = 0,
                PHash = "pHash",
                Quality = 0,
                Size = 0,
                VideoCodec = "videoCodec",
                Width = 0,
            },
            Name = "name",
            SelectedFieldsSchema = new Dictionary<string, SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Type.Text,
                        DefaultValue = new(
                            [
                                new DefaultValueArrayItem(true),
                                new DefaultValueArrayItem(10),
                                new DefaultValueArrayItem("Hello"),
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
            ThumbnailUrl = "thumbnailUrl",
            Url = "url",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Files::FileUploadResponse
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
        Assert.Null(model.CustomMetadata);
        Assert.False(model.RawData.ContainsKey("customMetadata"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.EmbeddedMetadata);
        Assert.False(model.RawData.ContainsKey("embeddedMetadata"));
        Assert.Null(model.ExtensionStatus);
        Assert.False(model.RawData.ContainsKey("extensionStatus"));
        Assert.Null(model.FileID);
        Assert.False(model.RawData.ContainsKey("fileId"));
        Assert.Null(model.FilePath);
        Assert.False(model.RawData.ContainsKey("filePath"));
        Assert.Null(model.FileType);
        Assert.False(model.RawData.ContainsKey("fileType"));
        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.IsPrivateFile);
        Assert.False(model.RawData.ContainsKey("isPrivateFile"));
        Assert.Null(model.IsPublished);
        Assert.False(model.RawData.ContainsKey("isPublished"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.SelectedFieldsSchema);
        Assert.False(model.RawData.ContainsKey("selectedFieldsSchema"));
        Assert.Null(model.Size);
        Assert.False(model.RawData.ContainsKey("size"));
        Assert.Null(model.ThumbnailUrl);
        Assert.False(model.RawData.ContainsKey("thumbnailUrl"));
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
        var model = new Files::FileUploadResponse
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
        var model = new Files::FileUploadResponse
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
            CustomMetadata = null,
            Description = null,
            Duration = null,
            EmbeddedMetadata = null,
            ExtensionStatus = null,
            FileID = null,
            FilePath = null,
            FileType = null,
            Height = null,
            IsPrivateFile = null,
            IsPublished = null,
            Metadata = null,
            Name = null,
            SelectedFieldsSchema = null,
            Size = null,
            ThumbnailUrl = null,
            Url = null,
            VersionInfo = null,
            VideoCodec = null,
            Width = null,
        };

        Assert.Null(model.AudioCodec);
        Assert.False(model.RawData.ContainsKey("audioCodec"));
        Assert.Null(model.BitRate);
        Assert.False(model.RawData.ContainsKey("bitRate"));
        Assert.Null(model.CustomMetadata);
        Assert.False(model.RawData.ContainsKey("customMetadata"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.EmbeddedMetadata);
        Assert.False(model.RawData.ContainsKey("embeddedMetadata"));
        Assert.Null(model.ExtensionStatus);
        Assert.False(model.RawData.ContainsKey("extensionStatus"));
        Assert.Null(model.FileID);
        Assert.False(model.RawData.ContainsKey("fileId"));
        Assert.Null(model.FilePath);
        Assert.False(model.RawData.ContainsKey("filePath"));
        Assert.Null(model.FileType);
        Assert.False(model.RawData.ContainsKey("fileType"));
        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.IsPrivateFile);
        Assert.False(model.RawData.ContainsKey("isPrivateFile"));
        Assert.Null(model.IsPublished);
        Assert.False(model.RawData.ContainsKey("isPublished"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.SelectedFieldsSchema);
        Assert.False(model.RawData.ContainsKey("selectedFieldsSchema"));
        Assert.Null(model.Size);
        Assert.False(model.RawData.ContainsKey("size"));
        Assert.Null(model.ThumbnailUrl);
        Assert.False(model.RawData.ContainsKey("thumbnailUrl"));
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
        var model = new Files::FileUploadResponse
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
            CustomMetadata = null,
            Description = null,
            Duration = null,
            EmbeddedMetadata = null,
            ExtensionStatus = null,
            FileID = null,
            FilePath = null,
            FileType = null,
            Height = null,
            IsPrivateFile = null,
            IsPublished = null,
            Metadata = null,
            Name = null,
            SelectedFieldsSchema = null,
            Size = null,
            ThumbnailUrl = null,
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
        var model = new Files::FileUploadResponse
        {
            AudioCodec = "audioCodec",
            BitRate = 0,
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
            ExtensionStatus = new()
            {
                AIAutoDescription =
                    Files::FileUploadResponseExtensionStatusAIAutoDescription.Success,
                AITasks = Files::FileUploadResponseExtensionStatusAITasks.Success,
                AwsAutoTagging = Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success,
                GoogleAutoTagging =
                    Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success,
                RemoveBg = Files::FileUploadResponseExtensionStatusRemoveBg.Success,
            },
            FileID = "fileId",
            FilePath = "filePath",
            FileType = "fileType",
            Height = 0,
            IsPrivateFile = true,
            IsPublished = true,
            Metadata = new()
            {
                AudioCodec = "audioCodec",
                BitRate = 0,
                Density = 0,
                Duration = 0,
                Exif = new()
                {
                    ExifValue = new()
                    {
                        ApertureValue = 0,
                        ColorSpace = 0,
                        CreateDate = "CreateDate",
                        CustomRendered = 0,
                        DateTimeOriginal = "DateTimeOriginal",
                        ExifImageHeight = 0,
                        ExifImageWidth = 0,
                        ExifVersion = "ExifVersion",
                        ExposureCompensation = 0,
                        ExposureMode = 0,
                        ExposureProgram = 0,
                        ExposureTime = 0,
                        Flash = 0,
                        FlashpixVersion = "FlashpixVersion",
                        FNumber = 0,
                        FocalLength = 0,
                        FocalPlaneResolutionUnit = 0,
                        FocalPlaneXResolution = 0,
                        FocalPlaneYResolution = 0,
                        InteropOffset = 0,
                        Iso = 0,
                        MeteringMode = 0,
                        SceneCaptureType = 0,
                        ShutterSpeedValue = 0,
                        SubSecTime = "SubSecTime",
                        WhiteBalance = 0,
                    },
                    Gps = new() { GpsVersionID = [0] },
                    Image = new()
                    {
                        ExifOffset = 0,
                        GpsInfo = 0,
                        Make = "Make",
                        Model = "Model",
                        ModifyDate = "ModifyDate",
                        Orientation = 0,
                        ResolutionUnit = 0,
                        Software = "Software",
                        XResolution = 0,
                        YCbCrPositioning = 0,
                        YResolution = 0,
                    },
                    Interoperability = new()
                    {
                        InteropIndex = "InteropIndex",
                        InteropVersion = "InteropVersion",
                    },
                    Makernote = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Thumbnail = new()
                    {
                        Compression = 0,
                        ResolutionUnit = 0,
                        ThumbnailLength = 0,
                        ThumbnailOffset = 0,
                        XResolution = 0,
                        YResolution = 0,
                    },
                },
                Format = "format",
                HasColorProfile = true,
                HasTransparency = true,
                Height = 0,
                PHash = "pHash",
                Quality = 0,
                Size = 0,
                VideoCodec = "videoCodec",
                Width = 0,
            },
            Name = "name",
            SelectedFieldsSchema = new Dictionary<string, SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Type.Text,
                        DefaultValue = new(
                            [
                                new DefaultValueArrayItem(true),
                                new DefaultValueArrayItem(10),
                                new DefaultValueArrayItem("Hello"),
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
            ThumbnailUrl = "thumbnailUrl",
            Url = "url",
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
        var model = new Files::FileUploadResponse
        {
            AudioCodec = "audioCodec",
            BitRate = 0,
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
            ExtensionStatus = new()
            {
                AIAutoDescription =
                    Files::FileUploadResponseExtensionStatusAIAutoDescription.Success,
                AITasks = Files::FileUploadResponseExtensionStatusAITasks.Success,
                AwsAutoTagging = Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success,
                GoogleAutoTagging =
                    Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success,
                RemoveBg = Files::FileUploadResponseExtensionStatusRemoveBg.Success,
            },
            FileID = "fileId",
            FilePath = "filePath",
            FileType = "fileType",
            Height = 0,
            IsPrivateFile = true,
            IsPublished = true,
            Metadata = new()
            {
                AudioCodec = "audioCodec",
                BitRate = 0,
                Density = 0,
                Duration = 0,
                Exif = new()
                {
                    ExifValue = new()
                    {
                        ApertureValue = 0,
                        ColorSpace = 0,
                        CreateDate = "CreateDate",
                        CustomRendered = 0,
                        DateTimeOriginal = "DateTimeOriginal",
                        ExifImageHeight = 0,
                        ExifImageWidth = 0,
                        ExifVersion = "ExifVersion",
                        ExposureCompensation = 0,
                        ExposureMode = 0,
                        ExposureProgram = 0,
                        ExposureTime = 0,
                        Flash = 0,
                        FlashpixVersion = "FlashpixVersion",
                        FNumber = 0,
                        FocalLength = 0,
                        FocalPlaneResolutionUnit = 0,
                        FocalPlaneXResolution = 0,
                        FocalPlaneYResolution = 0,
                        InteropOffset = 0,
                        Iso = 0,
                        MeteringMode = 0,
                        SceneCaptureType = 0,
                        ShutterSpeedValue = 0,
                        SubSecTime = "SubSecTime",
                        WhiteBalance = 0,
                    },
                    Gps = new() { GpsVersionID = [0] },
                    Image = new()
                    {
                        ExifOffset = 0,
                        GpsInfo = 0,
                        Make = "Make",
                        Model = "Model",
                        ModifyDate = "ModifyDate",
                        Orientation = 0,
                        ResolutionUnit = 0,
                        Software = "Software",
                        XResolution = 0,
                        YCbCrPositioning = 0,
                        YResolution = 0,
                    },
                    Interoperability = new()
                    {
                        InteropIndex = "InteropIndex",
                        InteropVersion = "InteropVersion",
                    },
                    Makernote = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Thumbnail = new()
                    {
                        Compression = 0,
                        ResolutionUnit = 0,
                        ThumbnailLength = 0,
                        ThumbnailOffset = 0,
                        XResolution = 0,
                        YResolution = 0,
                    },
                },
                Format = "format",
                HasColorProfile = true,
                HasTransparency = true,
                Height = 0,
                PHash = "pHash",
                Quality = 0,
                Size = 0,
                VideoCodec = "videoCodec",
                Width = 0,
            },
            Name = "name",
            SelectedFieldsSchema = new Dictionary<string, SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Type.Text,
                        DefaultValue = new(
                            [
                                new DefaultValueArrayItem(true),
                                new DefaultValueArrayItem(10),
                                new DefaultValueArrayItem("Hello"),
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
            ThumbnailUrl = "thumbnailUrl",
            Url = "url",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Files::FileUploadResponse
        {
            AudioCodec = "audioCodec",
            BitRate = 0,
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
            ExtensionStatus = new()
            {
                AIAutoDescription =
                    Files::FileUploadResponseExtensionStatusAIAutoDescription.Success,
                AITasks = Files::FileUploadResponseExtensionStatusAITasks.Success,
                AwsAutoTagging = Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success,
                GoogleAutoTagging =
                    Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success,
                RemoveBg = Files::FileUploadResponseExtensionStatusRemoveBg.Success,
            },
            FileID = "fileId",
            FilePath = "filePath",
            FileType = "fileType",
            Height = 0,
            IsPrivateFile = true,
            IsPublished = true,
            Metadata = new()
            {
                AudioCodec = "audioCodec",
                BitRate = 0,
                Density = 0,
                Duration = 0,
                Exif = new()
                {
                    ExifValue = new()
                    {
                        ApertureValue = 0,
                        ColorSpace = 0,
                        CreateDate = "CreateDate",
                        CustomRendered = 0,
                        DateTimeOriginal = "DateTimeOriginal",
                        ExifImageHeight = 0,
                        ExifImageWidth = 0,
                        ExifVersion = "ExifVersion",
                        ExposureCompensation = 0,
                        ExposureMode = 0,
                        ExposureProgram = 0,
                        ExposureTime = 0,
                        Flash = 0,
                        FlashpixVersion = "FlashpixVersion",
                        FNumber = 0,
                        FocalLength = 0,
                        FocalPlaneResolutionUnit = 0,
                        FocalPlaneXResolution = 0,
                        FocalPlaneYResolution = 0,
                        InteropOffset = 0,
                        Iso = 0,
                        MeteringMode = 0,
                        SceneCaptureType = 0,
                        ShutterSpeedValue = 0,
                        SubSecTime = "SubSecTime",
                        WhiteBalance = 0,
                    },
                    Gps = new() { GpsVersionID = [0] },
                    Image = new()
                    {
                        ExifOffset = 0,
                        GpsInfo = 0,
                        Make = "Make",
                        Model = "Model",
                        ModifyDate = "ModifyDate",
                        Orientation = 0,
                        ResolutionUnit = 0,
                        Software = "Software",
                        XResolution = 0,
                        YCbCrPositioning = 0,
                        YResolution = 0,
                    },
                    Interoperability = new()
                    {
                        InteropIndex = "InteropIndex",
                        InteropVersion = "InteropVersion",
                    },
                    Makernote = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Thumbnail = new()
                    {
                        Compression = 0,
                        ResolutionUnit = 0,
                        ThumbnailLength = 0,
                        ThumbnailOffset = 0,
                        XResolution = 0,
                        YResolution = 0,
                    },
                },
                Format = "format",
                HasColorProfile = true,
                HasTransparency = true,
                Height = 0,
                PHash = "pHash",
                Quality = 0,
                Size = 0,
                VideoCodec = "videoCodec",
                Width = 0,
            },
            Name = "name",
            SelectedFieldsSchema = new Dictionary<string, SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Type.Text,
                        DefaultValue = new(
                            [
                                new DefaultValueArrayItem(true),
                                new DefaultValueArrayItem(10),
                                new DefaultValueArrayItem("Hello"),
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
            ThumbnailUrl = "thumbnailUrl",
            Url = "url",
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
        var model = new Files::FileUploadResponse
        {
            AudioCodec = "audioCodec",
            BitRate = 0,
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
            ExtensionStatus = new()
            {
                AIAutoDescription =
                    Files::FileUploadResponseExtensionStatusAIAutoDescription.Success,
                AITasks = Files::FileUploadResponseExtensionStatusAITasks.Success,
                AwsAutoTagging = Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success,
                GoogleAutoTagging =
                    Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success,
                RemoveBg = Files::FileUploadResponseExtensionStatusRemoveBg.Success,
            },
            FileID = "fileId",
            FilePath = "filePath",
            FileType = "fileType",
            Height = 0,
            IsPrivateFile = true,
            IsPublished = true,
            Metadata = new()
            {
                AudioCodec = "audioCodec",
                BitRate = 0,
                Density = 0,
                Duration = 0,
                Exif = new()
                {
                    ExifValue = new()
                    {
                        ApertureValue = 0,
                        ColorSpace = 0,
                        CreateDate = "CreateDate",
                        CustomRendered = 0,
                        DateTimeOriginal = "DateTimeOriginal",
                        ExifImageHeight = 0,
                        ExifImageWidth = 0,
                        ExifVersion = "ExifVersion",
                        ExposureCompensation = 0,
                        ExposureMode = 0,
                        ExposureProgram = 0,
                        ExposureTime = 0,
                        Flash = 0,
                        FlashpixVersion = "FlashpixVersion",
                        FNumber = 0,
                        FocalLength = 0,
                        FocalPlaneResolutionUnit = 0,
                        FocalPlaneXResolution = 0,
                        FocalPlaneYResolution = 0,
                        InteropOffset = 0,
                        Iso = 0,
                        MeteringMode = 0,
                        SceneCaptureType = 0,
                        ShutterSpeedValue = 0,
                        SubSecTime = "SubSecTime",
                        WhiteBalance = 0,
                    },
                    Gps = new() { GpsVersionID = [0] },
                    Image = new()
                    {
                        ExifOffset = 0,
                        GpsInfo = 0,
                        Make = "Make",
                        Model = "Model",
                        ModifyDate = "ModifyDate",
                        Orientation = 0,
                        ResolutionUnit = 0,
                        Software = "Software",
                        XResolution = 0,
                        YCbCrPositioning = 0,
                        YResolution = 0,
                    },
                    Interoperability = new()
                    {
                        InteropIndex = "InteropIndex",
                        InteropVersion = "InteropVersion",
                    },
                    Makernote = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Thumbnail = new()
                    {
                        Compression = 0,
                        ResolutionUnit = 0,
                        ThumbnailLength = 0,
                        ThumbnailOffset = 0,
                        XResolution = 0,
                        YResolution = 0,
                    },
                },
                Format = "format",
                HasColorProfile = true,
                HasTransparency = true,
                Height = 0,
                PHash = "pHash",
                Quality = 0,
                Size = 0,
                VideoCodec = "videoCodec",
                Width = 0,
            },
            Name = "name",
            SelectedFieldsSchema = new Dictionary<string, SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Type.Text,
                        DefaultValue = new(
                            [
                                new DefaultValueArrayItem(true),
                                new DefaultValueArrayItem(10),
                                new DefaultValueArrayItem("Hello"),
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
            ThumbnailUrl = "thumbnailUrl",
            Url = "url",
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
        var model = new Files::FileUploadResponse
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
            ExtensionStatus = new()
            {
                AIAutoDescription =
                    Files::FileUploadResponseExtensionStatusAIAutoDescription.Success,
                AITasks = Files::FileUploadResponseExtensionStatusAITasks.Success,
                AwsAutoTagging = Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success,
                GoogleAutoTagging =
                    Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success,
                RemoveBg = Files::FileUploadResponseExtensionStatusRemoveBg.Success,
            },
            FileID = "fileId",
            FilePath = "filePath",
            FileType = "fileType",
            Height = 0,
            IsPrivateFile = true,
            IsPublished = true,
            Metadata = new()
            {
                AudioCodec = "audioCodec",
                BitRate = 0,
                Density = 0,
                Duration = 0,
                Exif = new()
                {
                    ExifValue = new()
                    {
                        ApertureValue = 0,
                        ColorSpace = 0,
                        CreateDate = "CreateDate",
                        CustomRendered = 0,
                        DateTimeOriginal = "DateTimeOriginal",
                        ExifImageHeight = 0,
                        ExifImageWidth = 0,
                        ExifVersion = "ExifVersion",
                        ExposureCompensation = 0,
                        ExposureMode = 0,
                        ExposureProgram = 0,
                        ExposureTime = 0,
                        Flash = 0,
                        FlashpixVersion = "FlashpixVersion",
                        FNumber = 0,
                        FocalLength = 0,
                        FocalPlaneResolutionUnit = 0,
                        FocalPlaneXResolution = 0,
                        FocalPlaneYResolution = 0,
                        InteropOffset = 0,
                        Iso = 0,
                        MeteringMode = 0,
                        SceneCaptureType = 0,
                        ShutterSpeedValue = 0,
                        SubSecTime = "SubSecTime",
                        WhiteBalance = 0,
                    },
                    Gps = new() { GpsVersionID = [0] },
                    Image = new()
                    {
                        ExifOffset = 0,
                        GpsInfo = 0,
                        Make = "Make",
                        Model = "Model",
                        ModifyDate = "ModifyDate",
                        Orientation = 0,
                        ResolutionUnit = 0,
                        Software = "Software",
                        XResolution = 0,
                        YCbCrPositioning = 0,
                        YResolution = 0,
                    },
                    Interoperability = new()
                    {
                        InteropIndex = "InteropIndex",
                        InteropVersion = "InteropVersion",
                    },
                    Makernote = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Thumbnail = new()
                    {
                        Compression = 0,
                        ResolutionUnit = 0,
                        ThumbnailLength = 0,
                        ThumbnailOffset = 0,
                        XResolution = 0,
                        YResolution = 0,
                    },
                },
                Format = "format",
                HasColorProfile = true,
                HasTransparency = true,
                Height = 0,
                PHash = "pHash",
                Quality = 0,
                Size = 0,
                VideoCodec = "videoCodec",
                Width = 0,
            },
            Name = "name",
            SelectedFieldsSchema = new Dictionary<string, SelectedFieldsSchemaItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Type = Type.Text,
                        DefaultValue = new(
                            [
                                new DefaultValueArrayItem(true),
                                new DefaultValueArrayItem(10),
                                new DefaultValueArrayItem("Hello"),
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
            ThumbnailUrl = "thumbnailUrl",
            Url = "url",
            VersionInfo = new() { ID = "id", Name = "name" },
            VideoCodec = "videoCodec",
            Width = 0,
        };

        Files::FileUploadResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FileUploadResponseExtensionStatusTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Files::FileUploadResponseExtensionStatus
        {
            AIAutoDescription = Files::FileUploadResponseExtensionStatusAIAutoDescription.Success,
            AITasks = Files::FileUploadResponseExtensionStatusAITasks.Success,
            AwsAutoTagging = Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success,
            GoogleAutoTagging = Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success,
            RemoveBg = Files::FileUploadResponseExtensionStatusRemoveBg.Success,
        };

        ApiEnum<
            string,
            Files::FileUploadResponseExtensionStatusAIAutoDescription
        > expectedAIAutoDescription =
            Files::FileUploadResponseExtensionStatusAIAutoDescription.Success;
        ApiEnum<string, Files::FileUploadResponseExtensionStatusAITasks> expectedAITasks =
            Files::FileUploadResponseExtensionStatusAITasks.Success;
        ApiEnum<
            string,
            Files::FileUploadResponseExtensionStatusAwsAutoTagging
        > expectedAwsAutoTagging = Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success;
        ApiEnum<
            string,
            Files::FileUploadResponseExtensionStatusGoogleAutoTagging
        > expectedGoogleAutoTagging =
            Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success;
        ApiEnum<string, Files::FileUploadResponseExtensionStatusRemoveBg> expectedRemoveBg =
            Files::FileUploadResponseExtensionStatusRemoveBg.Success;

        Assert.Equal(expectedAIAutoDescription, model.AIAutoDescription);
        Assert.Equal(expectedAITasks, model.AITasks);
        Assert.Equal(expectedAwsAutoTagging, model.AwsAutoTagging);
        Assert.Equal(expectedGoogleAutoTagging, model.GoogleAutoTagging);
        Assert.Equal(expectedRemoveBg, model.RemoveBg);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Files::FileUploadResponseExtensionStatus
        {
            AIAutoDescription = Files::FileUploadResponseExtensionStatusAIAutoDescription.Success,
            AITasks = Files::FileUploadResponseExtensionStatusAITasks.Success,
            AwsAutoTagging = Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success,
            GoogleAutoTagging = Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success,
            RemoveBg = Files::FileUploadResponseExtensionStatusRemoveBg.Success,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::FileUploadResponseExtensionStatus>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Files::FileUploadResponseExtensionStatus
        {
            AIAutoDescription = Files::FileUploadResponseExtensionStatusAIAutoDescription.Success,
            AITasks = Files::FileUploadResponseExtensionStatusAITasks.Success,
            AwsAutoTagging = Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success,
            GoogleAutoTagging = Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success,
            RemoveBg = Files::FileUploadResponseExtensionStatusRemoveBg.Success,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::FileUploadResponseExtensionStatus>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Files::FileUploadResponseExtensionStatusAIAutoDescription
        > expectedAIAutoDescription =
            Files::FileUploadResponseExtensionStatusAIAutoDescription.Success;
        ApiEnum<string, Files::FileUploadResponseExtensionStatusAITasks> expectedAITasks =
            Files::FileUploadResponseExtensionStatusAITasks.Success;
        ApiEnum<
            string,
            Files::FileUploadResponseExtensionStatusAwsAutoTagging
        > expectedAwsAutoTagging = Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success;
        ApiEnum<
            string,
            Files::FileUploadResponseExtensionStatusGoogleAutoTagging
        > expectedGoogleAutoTagging =
            Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success;
        ApiEnum<string, Files::FileUploadResponseExtensionStatusRemoveBg> expectedRemoveBg =
            Files::FileUploadResponseExtensionStatusRemoveBg.Success;

        Assert.Equal(expectedAIAutoDescription, deserialized.AIAutoDescription);
        Assert.Equal(expectedAITasks, deserialized.AITasks);
        Assert.Equal(expectedAwsAutoTagging, deserialized.AwsAutoTagging);
        Assert.Equal(expectedGoogleAutoTagging, deserialized.GoogleAutoTagging);
        Assert.Equal(expectedRemoveBg, deserialized.RemoveBg);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Files::FileUploadResponseExtensionStatus
        {
            AIAutoDescription = Files::FileUploadResponseExtensionStatusAIAutoDescription.Success,
            AITasks = Files::FileUploadResponseExtensionStatusAITasks.Success,
            AwsAutoTagging = Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success,
            GoogleAutoTagging = Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success,
            RemoveBg = Files::FileUploadResponseExtensionStatusRemoveBg.Success,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Files::FileUploadResponseExtensionStatus { };

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
        var model = new Files::FileUploadResponseExtensionStatus { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Files::FileUploadResponseExtensionStatus
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
        var model = new Files::FileUploadResponseExtensionStatus
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
        var model = new Files::FileUploadResponseExtensionStatus
        {
            AIAutoDescription = Files::FileUploadResponseExtensionStatusAIAutoDescription.Success,
            AITasks = Files::FileUploadResponseExtensionStatusAITasks.Success,
            AwsAutoTagging = Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success,
            GoogleAutoTagging = Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success,
            RemoveBg = Files::FileUploadResponseExtensionStatusRemoveBg.Success,
        };

        Files::FileUploadResponseExtensionStatus copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FileUploadResponseExtensionStatusAIAutoDescriptionTest : TestBase
{
    [Theory]
    [InlineData(Files::FileUploadResponseExtensionStatusAIAutoDescription.Success)]
    [InlineData(Files::FileUploadResponseExtensionStatusAIAutoDescription.Pending)]
    [InlineData(Files::FileUploadResponseExtensionStatusAIAutoDescription.Failed)]
    public void Validation_Works(Files::FileUploadResponseExtensionStatusAIAutoDescription rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::FileUploadResponseExtensionStatusAIAutoDescription> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusAIAutoDescription>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Files::FileUploadResponseExtensionStatusAIAutoDescription.Success)]
    [InlineData(Files::FileUploadResponseExtensionStatusAIAutoDescription.Pending)]
    [InlineData(Files::FileUploadResponseExtensionStatusAIAutoDescription.Failed)]
    public void SerializationRoundtrip_Works(
        Files::FileUploadResponseExtensionStatusAIAutoDescription rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::FileUploadResponseExtensionStatusAIAutoDescription> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusAIAutoDescription>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusAIAutoDescription>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusAIAutoDescription>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FileUploadResponseExtensionStatusAITasksTest : TestBase
{
    [Theory]
    [InlineData(Files::FileUploadResponseExtensionStatusAITasks.Success)]
    [InlineData(Files::FileUploadResponseExtensionStatusAITasks.Pending)]
    [InlineData(Files::FileUploadResponseExtensionStatusAITasks.Failed)]
    public void Validation_Works(Files::FileUploadResponseExtensionStatusAITasks rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::FileUploadResponseExtensionStatusAITasks> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusAITasks>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Files::FileUploadResponseExtensionStatusAITasks.Success)]
    [InlineData(Files::FileUploadResponseExtensionStatusAITasks.Pending)]
    [InlineData(Files::FileUploadResponseExtensionStatusAITasks.Failed)]
    public void SerializationRoundtrip_Works(
        Files::FileUploadResponseExtensionStatusAITasks rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::FileUploadResponseExtensionStatusAITasks> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusAITasks>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusAITasks>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusAITasks>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FileUploadResponseExtensionStatusAwsAutoTaggingTest : TestBase
{
    [Theory]
    [InlineData(Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success)]
    [InlineData(Files::FileUploadResponseExtensionStatusAwsAutoTagging.Pending)]
    [InlineData(Files::FileUploadResponseExtensionStatusAwsAutoTagging.Failed)]
    public void Validation_Works(Files::FileUploadResponseExtensionStatusAwsAutoTagging rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::FileUploadResponseExtensionStatusAwsAutoTagging> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusAwsAutoTagging>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Files::FileUploadResponseExtensionStatusAwsAutoTagging.Success)]
    [InlineData(Files::FileUploadResponseExtensionStatusAwsAutoTagging.Pending)]
    [InlineData(Files::FileUploadResponseExtensionStatusAwsAutoTagging.Failed)]
    public void SerializationRoundtrip_Works(
        Files::FileUploadResponseExtensionStatusAwsAutoTagging rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::FileUploadResponseExtensionStatusAwsAutoTagging> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusAwsAutoTagging>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusAwsAutoTagging>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusAwsAutoTagging>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FileUploadResponseExtensionStatusGoogleAutoTaggingTest : TestBase
{
    [Theory]
    [InlineData(Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success)]
    [InlineData(Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Pending)]
    [InlineData(Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Failed)]
    public void Validation_Works(Files::FileUploadResponseExtensionStatusGoogleAutoTagging rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::FileUploadResponseExtensionStatusGoogleAutoTagging> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusGoogleAutoTagging>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Success)]
    [InlineData(Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Pending)]
    [InlineData(Files::FileUploadResponseExtensionStatusGoogleAutoTagging.Failed)]
    public void SerializationRoundtrip_Works(
        Files::FileUploadResponseExtensionStatusGoogleAutoTagging rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::FileUploadResponseExtensionStatusGoogleAutoTagging> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusGoogleAutoTagging>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusGoogleAutoTagging>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusGoogleAutoTagging>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FileUploadResponseExtensionStatusRemoveBgTest : TestBase
{
    [Theory]
    [InlineData(Files::FileUploadResponseExtensionStatusRemoveBg.Success)]
    [InlineData(Files::FileUploadResponseExtensionStatusRemoveBg.Pending)]
    [InlineData(Files::FileUploadResponseExtensionStatusRemoveBg.Failed)]
    public void Validation_Works(Files::FileUploadResponseExtensionStatusRemoveBg rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::FileUploadResponseExtensionStatusRemoveBg> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusRemoveBg>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Files::FileUploadResponseExtensionStatusRemoveBg.Success)]
    [InlineData(Files::FileUploadResponseExtensionStatusRemoveBg.Pending)]
    [InlineData(Files::FileUploadResponseExtensionStatusRemoveBg.Failed)]
    public void SerializationRoundtrip_Works(
        Files::FileUploadResponseExtensionStatusRemoveBg rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::FileUploadResponseExtensionStatusRemoveBg> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusRemoveBg>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusRemoveBg>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Files::FileUploadResponseExtensionStatusRemoveBg>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
