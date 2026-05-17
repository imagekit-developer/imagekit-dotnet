using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.Beta.V2.Files;
using Files = Imagekit.Models.Files;

namespace Imagekit.Tests.Models.Beta.V2.Files;

public class FileUploadResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileUploadResponse
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
                AIAutoDescription = AIAutoDescription.Success,
                AITasks = AITasks.Success,
                AwsAutoTagging = AwsAutoTagging.Success,
                GoogleAutoTagging = GoogleAutoTagging.Success,
                RemoveBg = RemoveBg.Success,
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
        ExtensionStatus expectedExtensionStatus = new()
        {
            AIAutoDescription = AIAutoDescription.Success,
            AITasks = AITasks.Success,
            AwsAutoTagging = AwsAutoTagging.Success,
            GoogleAutoTagging = GoogleAutoTagging.Success,
            RemoveBg = RemoveBg.Success,
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
        var model = new FileUploadResponse
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
                AIAutoDescription = AIAutoDescription.Success,
                AITasks = AITasks.Success,
                AwsAutoTagging = AwsAutoTagging.Success,
                GoogleAutoTagging = GoogleAutoTagging.Success,
                RemoveBg = RemoveBg.Success,
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
        var deserialized = JsonSerializer.Deserialize<FileUploadResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileUploadResponse
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
                AIAutoDescription = AIAutoDescription.Success,
                AITasks = AITasks.Success,
                AwsAutoTagging = AwsAutoTagging.Success,
                GoogleAutoTagging = GoogleAutoTagging.Success,
                RemoveBg = RemoveBg.Success,
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
        var deserialized = JsonSerializer.Deserialize<FileUploadResponse>(
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
        ExtensionStatus expectedExtensionStatus = new()
        {
            AIAutoDescription = AIAutoDescription.Success,
            AITasks = AITasks.Success,
            AwsAutoTagging = AwsAutoTagging.Success,
            GoogleAutoTagging = GoogleAutoTagging.Success,
            RemoveBg = RemoveBg.Success,
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
        var model = new FileUploadResponse
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
                AIAutoDescription = AIAutoDescription.Success,
                AITasks = AITasks.Success,
                AwsAutoTagging = AwsAutoTagging.Success,
                GoogleAutoTagging = GoogleAutoTagging.Success,
                RemoveBg = RemoveBg.Success,
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
        var model = new FileUploadResponse
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
        var model = new FileUploadResponse
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
        var model = new FileUploadResponse
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
        var model = new FileUploadResponse
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
        var model = new FileUploadResponse
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
                AIAutoDescription = AIAutoDescription.Success,
                AITasks = AITasks.Success,
                AwsAutoTagging = AwsAutoTagging.Success,
                GoogleAutoTagging = GoogleAutoTagging.Success,
                RemoveBg = RemoveBg.Success,
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
        var model = new FileUploadResponse
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
                AIAutoDescription = AIAutoDescription.Success,
                AITasks = AITasks.Success,
                AwsAutoTagging = AwsAutoTagging.Success,
                GoogleAutoTagging = GoogleAutoTagging.Success,
                RemoveBg = RemoveBg.Success,
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
        var model = new FileUploadResponse
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
                AIAutoDescription = AIAutoDescription.Success,
                AITasks = AITasks.Success,
                AwsAutoTagging = AwsAutoTagging.Success,
                GoogleAutoTagging = GoogleAutoTagging.Success,
                RemoveBg = RemoveBg.Success,
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
        var model = new FileUploadResponse
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
                AIAutoDescription = AIAutoDescription.Success,
                AITasks = AITasks.Success,
                AwsAutoTagging = AwsAutoTagging.Success,
                GoogleAutoTagging = GoogleAutoTagging.Success,
                RemoveBg = RemoveBg.Success,
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
        var model = new FileUploadResponse
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
                AIAutoDescription = AIAutoDescription.Success,
                AITasks = AITasks.Success,
                AwsAutoTagging = AwsAutoTagging.Success,
                GoogleAutoTagging = GoogleAutoTagging.Success,
                RemoveBg = RemoveBg.Success,
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

        FileUploadResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AITagTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AITag
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
        var model = new AITag
        {
            Confidence = 0,
            Name = "name",
            Source = "source",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AITag>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AITag
        {
            Confidence = 0,
            Name = "name",
            Source = "source",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AITag>(element, ModelBase.SerializerOptions);
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
        var model = new AITag
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
        var model = new AITag { };

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
        var model = new AITag { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AITag
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
        var model = new AITag
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
        var model = new AITag
        {
            Confidence = 0,
            Name = "name",
            Source = "source",
        };

        AITag copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtensionStatusTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtensionStatus
        {
            AIAutoDescription = AIAutoDescription.Success,
            AITasks = AITasks.Success,
            AwsAutoTagging = AwsAutoTagging.Success,
            GoogleAutoTagging = GoogleAutoTagging.Success,
            RemoveBg = RemoveBg.Success,
        };

        ApiEnum<string, AIAutoDescription> expectedAIAutoDescription = AIAutoDescription.Success;
        ApiEnum<string, AITasks> expectedAITasks = AITasks.Success;
        ApiEnum<string, AwsAutoTagging> expectedAwsAutoTagging = AwsAutoTagging.Success;
        ApiEnum<string, GoogleAutoTagging> expectedGoogleAutoTagging = GoogleAutoTagging.Success;
        ApiEnum<string, RemoveBg> expectedRemoveBg = RemoveBg.Success;

        Assert.Equal(expectedAIAutoDescription, model.AIAutoDescription);
        Assert.Equal(expectedAITasks, model.AITasks);
        Assert.Equal(expectedAwsAutoTagging, model.AwsAutoTagging);
        Assert.Equal(expectedGoogleAutoTagging, model.GoogleAutoTagging);
        Assert.Equal(expectedRemoveBg, model.RemoveBg);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtensionStatus
        {
            AIAutoDescription = AIAutoDescription.Success,
            AITasks = AITasks.Success,
            AwsAutoTagging = AwsAutoTagging.Success,
            GoogleAutoTagging = GoogleAutoTagging.Success,
            RemoveBg = RemoveBg.Success,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionStatus>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtensionStatus
        {
            AIAutoDescription = AIAutoDescription.Success,
            AITasks = AITasks.Success,
            AwsAutoTagging = AwsAutoTagging.Success,
            GoogleAutoTagging = GoogleAutoTagging.Success,
            RemoveBg = RemoveBg.Success,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtensionStatus>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AIAutoDescription> expectedAIAutoDescription = AIAutoDescription.Success;
        ApiEnum<string, AITasks> expectedAITasks = AITasks.Success;
        ApiEnum<string, AwsAutoTagging> expectedAwsAutoTagging = AwsAutoTagging.Success;
        ApiEnum<string, GoogleAutoTagging> expectedGoogleAutoTagging = GoogleAutoTagging.Success;
        ApiEnum<string, RemoveBg> expectedRemoveBg = RemoveBg.Success;

        Assert.Equal(expectedAIAutoDescription, deserialized.AIAutoDescription);
        Assert.Equal(expectedAITasks, deserialized.AITasks);
        Assert.Equal(expectedAwsAutoTagging, deserialized.AwsAutoTagging);
        Assert.Equal(expectedGoogleAutoTagging, deserialized.GoogleAutoTagging);
        Assert.Equal(expectedRemoveBg, deserialized.RemoveBg);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtensionStatus
        {
            AIAutoDescription = AIAutoDescription.Success,
            AITasks = AITasks.Success,
            AwsAutoTagging = AwsAutoTagging.Success,
            GoogleAutoTagging = GoogleAutoTagging.Success,
            RemoveBg = RemoveBg.Success,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtensionStatus { };

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
        var model = new ExtensionStatus { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExtensionStatus
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
        var model = new ExtensionStatus
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
        var model = new ExtensionStatus
        {
            AIAutoDescription = AIAutoDescription.Success,
            AITasks = AITasks.Success,
            AwsAutoTagging = AwsAutoTagging.Success,
            GoogleAutoTagging = GoogleAutoTagging.Success,
            RemoveBg = RemoveBg.Success,
        };

        ExtensionStatus copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AIAutoDescriptionTest : TestBase
{
    [Theory]
    [InlineData(AIAutoDescription.Success)]
    [InlineData(AIAutoDescription.Pending)]
    [InlineData(AIAutoDescription.Failed)]
    public void Validation_Works(AIAutoDescription rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AIAutoDescription> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AIAutoDescription>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AIAutoDescription.Success)]
    [InlineData(AIAutoDescription.Pending)]
    [InlineData(AIAutoDescription.Failed)]
    public void SerializationRoundtrip_Works(AIAutoDescription rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AIAutoDescription> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AIAutoDescription>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AIAutoDescription>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AIAutoDescription>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AITasksTest : TestBase
{
    [Theory]
    [InlineData(AITasks.Success)]
    [InlineData(AITasks.Pending)]
    [InlineData(AITasks.Failed)]
    public void Validation_Works(AITasks rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AITasks> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AITasks>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AITasks.Success)]
    [InlineData(AITasks.Pending)]
    [InlineData(AITasks.Failed)]
    public void SerializationRoundtrip_Works(AITasks rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AITasks> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AITasks>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AITasks>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AITasks>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AwsAutoTaggingTest : TestBase
{
    [Theory]
    [InlineData(AwsAutoTagging.Success)]
    [InlineData(AwsAutoTagging.Pending)]
    [InlineData(AwsAutoTagging.Failed)]
    public void Validation_Works(AwsAutoTagging rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AwsAutoTagging> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AwsAutoTagging>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AwsAutoTagging.Success)]
    [InlineData(AwsAutoTagging.Pending)]
    [InlineData(AwsAutoTagging.Failed)]
    public void SerializationRoundtrip_Works(AwsAutoTagging rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AwsAutoTagging> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AwsAutoTagging>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AwsAutoTagging>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AwsAutoTagging>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class GoogleAutoTaggingTest : TestBase
{
    [Theory]
    [InlineData(GoogleAutoTagging.Success)]
    [InlineData(GoogleAutoTagging.Pending)]
    [InlineData(GoogleAutoTagging.Failed)]
    public void Validation_Works(GoogleAutoTagging rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GoogleAutoTagging> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GoogleAutoTagging>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GoogleAutoTagging.Success)]
    [InlineData(GoogleAutoTagging.Pending)]
    [InlineData(GoogleAutoTagging.Failed)]
    public void SerializationRoundtrip_Works(GoogleAutoTagging rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GoogleAutoTagging> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GoogleAutoTagging>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GoogleAutoTagging>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GoogleAutoTagging>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RemoveBgTest : TestBase
{
    [Theory]
    [InlineData(RemoveBg.Success)]
    [InlineData(RemoveBg.Pending)]
    [InlineData(RemoveBg.Failed)]
    public void Validation_Works(RemoveBg rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RemoveBg> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RemoveBg>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RemoveBg.Success)]
    [InlineData(RemoveBg.Pending)]
    [InlineData(RemoveBg.Failed)]
    public void SerializationRoundtrip_Works(RemoveBg rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RemoveBg> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RemoveBg>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RemoveBg>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RemoveBg>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SelectedFieldsSchemaItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SelectedFieldsSchemaItem
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
        };

        ApiEnum<string, Type> expectedType = Type.Text;
        DefaultValue expectedDefaultValue = new(
            [
                new DefaultValueArrayItem(true),
                new DefaultValueArrayItem(10),
                new DefaultValueArrayItem("Hello"),
            ]
        );
        bool expectedIsValueRequired = true;
        double expectedMaxLength = 0;
        MaxValue expectedMaxValue = "string";
        double expectedMinLength = 0;
        MinValue expectedMinValue = "string";
        bool expectedReadOnly = true;
        List<SelectOption> expectedSelectOptions = ["small", "medium", "large", 30, 40, true];
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
        var model = new SelectedFieldsSchemaItem
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SelectedFieldsSchemaItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SelectedFieldsSchemaItem
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SelectedFieldsSchemaItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Type> expectedType = Type.Text;
        DefaultValue expectedDefaultValue = new(
            [
                new DefaultValueArrayItem(true),
                new DefaultValueArrayItem(10),
                new DefaultValueArrayItem("Hello"),
            ]
        );
        bool expectedIsValueRequired = true;
        double expectedMaxLength = 0;
        MaxValue expectedMaxValue = "string";
        double expectedMinLength = 0;
        MinValue expectedMinValue = "string";
        bool expectedReadOnly = true;
        List<SelectOption> expectedSelectOptions = ["small", "medium", "large", 30, 40, true];
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
        var model = new SelectedFieldsSchemaItem
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SelectedFieldsSchemaItem { Type = Type.Text };

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
        var model = new SelectedFieldsSchemaItem { Type = Type.Text };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SelectedFieldsSchemaItem
        {
            Type = Type.Text,

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
        var model = new SelectedFieldsSchemaItem
        {
            Type = Type.Text,

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
        var model = new SelectedFieldsSchemaItem
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
        };

        SelectedFieldsSchemaItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.Text)]
    [InlineData(Type.Textarea)]
    [InlineData(Type.Number)]
    [InlineData(Type.Date)]
    [InlineData(Type.Boolean)]
    [InlineData(Type.SingleSelect)]
    [InlineData(Type.MultiSelect)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.Text)]
    [InlineData(Type.Textarea)]
    [InlineData(Type.Number)]
    [InlineData(Type.Date)]
    [InlineData(Type.Boolean)]
    [InlineData(Type.SingleSelect)]
    [InlineData(Type.MultiSelect)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
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
        DefaultValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        DefaultValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        DefaultValue value = true;
        value.Validate();
    }

    [Fact]
    public void MixedValidationWorks()
    {
        DefaultValue value = new(
            [
                new DefaultValueArrayItem(true),
                new DefaultValueArrayItem(10),
                new DefaultValueArrayItem("Hello"),
            ]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        DefaultValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        DefaultValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        DefaultValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MixedSerializationRoundtripWorks()
    {
        DefaultValue value = new(
            [
                new DefaultValueArrayItem(true),
                new DefaultValueArrayItem(10),
                new DefaultValueArrayItem("Hello"),
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DefaultValueArrayItemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        DefaultValueArrayItem value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        DefaultValueArrayItem value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        DefaultValueArrayItem value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        DefaultValueArrayItem value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DefaultValueArrayItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        DefaultValueArrayItem value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DefaultValueArrayItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        DefaultValueArrayItem value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DefaultValueArrayItem>(
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
        MaxValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        MaxValue value = 0;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MaxValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MaxValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        MaxValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MaxValue>(
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
        MinValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        MinValue value = 0;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MinValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MinValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        MinValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MinValue>(
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
        SelectOption value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        SelectOption value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        SelectOption value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        SelectOption value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SelectOption>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        SelectOption value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SelectOption>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        SelectOption value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SelectOption>(
            element,
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
        var model = new VersionInfo { ID = "id", Name = "name" };

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VersionInfo { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VersionInfo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VersionInfo { ID = "id", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VersionInfo>(
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
        var model = new VersionInfo { ID = "id", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VersionInfo { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VersionInfo { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VersionInfo
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
        var model = new VersionInfo
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
        var model = new VersionInfo { ID = "id", Name = "name" };

        VersionInfo copied = new(model);

        Assert.Equal(model, copied);
    }
}
