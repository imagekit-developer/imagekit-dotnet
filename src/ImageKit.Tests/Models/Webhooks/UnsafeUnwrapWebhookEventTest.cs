using System;
using System.Collections.Generic;
using System.Text.Json;
using ImageKit.Core;
using Files = ImageKit.Models.Files;
using Webhooks = ImageKit.Models.Webhooks;

namespace ImageKit.Tests.Models.Webhooks;

public class UnsafeUnwrapWebhookEventTest : TestBase
{
    [Fact]
    public void VideoTransformationAcceptedValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::VideoTransformationAcceptedEvent()
        {
            ID = "id",
            Type = "video.transformation.accepted",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        Webhooks::VideoTransformationAcceptedEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec = Webhooks::AudioCodec.Aac,
                        AutoRotate = true,
                        Format = Webhooks::Format.Mp4,
                        Quality = 0,
                        StreamProtocol = Webhooks::StreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec = Webhooks::VideoCodec.H264,
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
        };
        value.Validate();
    }

    [Fact]
    public void VideoTransformationReadyValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::VideoTransformationReadyEvent()
        {
            ID = "id",
            Type = "video.transformation.ready",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        Webhooks::VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            Webhooks::VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            Webhooks::VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            Webhooks::VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            Webhooks::VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { DownloadDuration = 0, EncodingDuration = 0 },
        };
        value.Validate();
    }

    [Fact]
    public void VideoTransformationErrorValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::VideoTransformationErrorEvent()
        {
            ID = "id",
            Type = "video.transformation.error",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        Webhooks::VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Error = new(Webhooks::Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            Webhooks::VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            Webhooks::VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            Webhooks::VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            Webhooks::VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
        };
        value.Validate();
    }

    [Fact]
    public void UploadPreTransformSuccessValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::UploadPreTransformSuccessEvent()
        {
            ID = "id",
            Type = "upload.pre-transform.success",
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
                    AIAutoDescription = Webhooks::AIAutoDescription.Success,
                    AITasks = Webhooks::AITasks.Success,
                    AwsAutoTagging = Webhooks::AwsAutoTagging.Success,
                    GoogleAutoTagging = Webhooks::GoogleAutoTagging.Success,
                    RemoveBg = Webhooks::RemoveBg.Success,
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
                SelectedFieldsSchema = new Dictionary<string, Webhooks::SelectedFieldsSchemaItem>()
                {
                    {
                        "foo",
                        new()
                        {
                            Type = Webhooks::SelectedFieldsSchemaItemType.Text,
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
                ThumbnailUrl = "thumbnailUrl",
                Url = "url",
                VersionInfo = new() { ID = "id", Name = "name" },
                VideoCodec = "videoCodec",
                Width = 0,
            },
            Request = new() { Transformation = "transformation", XRequestID = "x_request_id" },
        };
        value.Validate();
    }

    [Fact]
    public void UploadPreTransformErrorValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::UploadPreTransformErrorEvent()
        {
            ID = "id",
            Type = "upload.pre-transform.error",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Name = "name",
                Path = "path",
                Transformation = new(
                    new Webhooks::UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                        "encoding_failed"
                    )
                ),
            },
            Request = new() { Transformation = "transformation", XRequestID = "x_request_id" },
        };
        value.Validate();
    }

    [Fact]
    public void UploadPostTransformSuccessValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::UploadPostTransformSuccessEvent()
        {
            ID = "id",
            Type = "upload.post-transform.success",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        Webhooks::UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                    Protocol =
                        Webhooks::UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };
        value.Validate();
    }

    [Fact]
    public void UploadPostTransformErrorValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::UploadPostTransformErrorEvent()
        {
            ID = "id",
            Type = "upload.post-transform.error",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(new Webhooks::Error("encoding_failed")),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type = Webhooks::Type.Transformation,
                    Protocol = Webhooks::Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };
        value.Validate();
    }

    [Fact]
    public void DamFileCreateValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::DamFileCreateEvent()
        {
            ID = "id",
            Type = "file.created",
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
            },
        };
        value.Validate();
    }

    [Fact]
    public void DamFileUpdateValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::DamFileUpdateEvent()
        {
            ID = "id",
            Type = "file.updated",
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
            },
        };
        value.Validate();
    }

    [Fact]
    public void DamFileDeleteValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::DamFileDeleteEvent()
        {
            ID = "id",
            Type = "file.deleted",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new("fileId"),
        };
        value.Validate();
    }

    [Fact]
    public void DamFileVersionCreateValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::DamFileVersionCreateEvent()
        {
            ID = "id",
            Type = "file-version.created",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };
        value.Validate();
    }

    [Fact]
    public void DamFileVersionDeleteValidationWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::DamFileVersionDeleteEvent()
        {
            ID = "id",
            Type = "file-version.deleted",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FileID = "fileId", VersionID = "versionId" },
        };
        value.Validate();
    }

    [Fact]
    public void VideoTransformationAcceptedSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::VideoTransformationAcceptedEvent()
        {
            ID = "id",
            Type = "video.transformation.accepted",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        Webhooks::VideoTransformationAcceptedEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec = Webhooks::AudioCodec.Aac,
                        AutoRotate = true,
                        Format = Webhooks::Format.Mp4,
                        Quality = 0,
                        StreamProtocol = Webhooks::StreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec = Webhooks::VideoCodec.H264,
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VideoTransformationReadySerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::VideoTransformationReadyEvent()
        {
            ID = "id",
            Type = "video.transformation.ready",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        Webhooks::VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Options = new()
                    {
                        AudioCodec =
                            Webhooks::VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            Webhooks::VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            Webhooks::VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            Webhooks::VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                    Output = new()
                    {
                        Url = "https://example.com",
                        VideoMetadata = new()
                        {
                            Bitrate = 0,
                            Duration = 0,
                            Height = 0,
                            Width = 0,
                        },
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
            Timings = new() { DownloadDuration = 0, EncodingDuration = 0 },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VideoTransformationErrorSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::VideoTransformationErrorEvent()
        {
            ID = "id",
            Type = "video.transformation.error",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Asset = new("https://example.com"),
                Transformation = new()
                {
                    Type =
                        Webhooks::VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
                    Error = new(Webhooks::Reason.EncodingFailed),
                    Options = new()
                    {
                        AudioCodec =
                            Webhooks::VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
                        AutoRotate = true,
                        Format =
                            Webhooks::VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
                        Quality = 0,
                        StreamProtocol =
                            Webhooks::VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
                        Variants = ["string"],
                        VideoCodec =
                            Webhooks::VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
                    },
                },
            },
            Request = new()
            {
                Url = "https://example.com",
                XRequestID = "x_request_id",
                UserAgent = "user_agent",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UploadPreTransformSuccessSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::UploadPreTransformSuccessEvent()
        {
            ID = "id",
            Type = "upload.pre-transform.success",
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
                    AIAutoDescription = Webhooks::AIAutoDescription.Success,
                    AITasks = Webhooks::AITasks.Success,
                    AwsAutoTagging = Webhooks::AwsAutoTagging.Success,
                    GoogleAutoTagging = Webhooks::GoogleAutoTagging.Success,
                    RemoveBg = Webhooks::RemoveBg.Success,
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
                SelectedFieldsSchema = new Dictionary<string, Webhooks::SelectedFieldsSchemaItem>()
                {
                    {
                        "foo",
                        new()
                        {
                            Type = Webhooks::SelectedFieldsSchemaItemType.Text,
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
                ThumbnailUrl = "thumbnailUrl",
                Url = "url",
                VersionInfo = new() { ID = "id", Name = "name" },
                VideoCodec = "videoCodec",
                Width = 0,
            },
            Request = new() { Transformation = "transformation", XRequestID = "x_request_id" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UploadPreTransformErrorSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::UploadPreTransformErrorEvent()
        {
            ID = "id",
            Type = "upload.pre-transform.error",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                Name = "name",
                Path = "path",
                Transformation = new(
                    new Webhooks::UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
                        "encoding_failed"
                    )
                ),
            },
            Request = new() { Transformation = "transformation", XRequestID = "x_request_id" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UploadPostTransformSuccessSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::UploadPostTransformSuccessEvent()
        {
            ID = "id",
            Type = "upload.post-transform.success",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type =
                        Webhooks::UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
                    Protocol =
                        Webhooks::UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UploadPostTransformErrorSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::UploadPostTransformErrorEvent()
        {
            ID = "id",
            Type = "upload.post-transform.error",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                FileID = "fileId",
                Name = "name",
                Path = "path",
                Transformation = new(new Webhooks::Error("encoding_failed")),
                Url = "https://example.com",
            },
            Request = new()
            {
                Transformation = new()
                {
                    Type = Webhooks::Type.Transformation,
                    Protocol = Webhooks::Protocol.Hls,
                    Value = "value",
                },
                XRequestID = "x_request_id",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DamFileCreateSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::DamFileCreateEvent()
        {
            ID = "id",
            Type = "file.created",
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
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DamFileUpdateSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::DamFileUpdateEvent()
        {
            ID = "id",
            Type = "file.updated",
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
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DamFileDeleteSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::DamFileDeleteEvent()
        {
            ID = "id",
            Type = "file.deleted",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new("fileId"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DamFileVersionCreateSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::DamFileVersionCreateEvent()
        {
            ID = "id",
            Type = "file-version.created",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DamFileVersionDeleteSerializationRoundtripWorks()
    {
        Webhooks::UnsafeUnwrapWebhookEvent value = new Webhooks::DamFileVersionDeleteEvent()
        {
            ID = "id",
            Type = "file-version.deleted",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FileID = "fileId", VersionID = "versionId" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhooks::UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
