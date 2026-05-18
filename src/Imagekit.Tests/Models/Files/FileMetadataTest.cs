using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Files;

namespace Imagekit.Tests.Models.Files;

public class FileMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileMetadata
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

        string expectedAudioCodec = "audioCodec";
        long expectedBitRate = 0;
        long expectedDensity = 0;
        long expectedDuration = 0;
        Exif expectedExif = new()
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
        };
        string expectedFormat = "format";
        bool expectedHasColorProfile = true;
        bool expectedHasTransparency = true;
        long expectedHeight = 0;
        string expectedPHash = "pHash";
        long expectedQuality = 0;
        long expectedSize = 0;
        string expectedVideoCodec = "videoCodec";
        long expectedWidth = 0;

        Assert.Equal(expectedAudioCodec, model.AudioCodec);
        Assert.Equal(expectedBitRate, model.BitRate);
        Assert.Equal(expectedDensity, model.Density);
        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedExif, model.Exif);
        Assert.Equal(expectedFormat, model.Format);
        Assert.Equal(expectedHasColorProfile, model.HasColorProfile);
        Assert.Equal(expectedHasTransparency, model.HasTransparency);
        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedPHash, model.PHash);
        Assert.Equal(expectedQuality, model.Quality);
        Assert.Equal(expectedSize, model.Size);
        Assert.Equal(expectedVideoCodec, model.VideoCodec);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileMetadata
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileMetadata
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAudioCodec = "audioCodec";
        long expectedBitRate = 0;
        long expectedDensity = 0;
        long expectedDuration = 0;
        Exif expectedExif = new()
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
        };
        string expectedFormat = "format";
        bool expectedHasColorProfile = true;
        bool expectedHasTransparency = true;
        long expectedHeight = 0;
        string expectedPHash = "pHash";
        long expectedQuality = 0;
        long expectedSize = 0;
        string expectedVideoCodec = "videoCodec";
        long expectedWidth = 0;

        Assert.Equal(expectedAudioCodec, deserialized.AudioCodec);
        Assert.Equal(expectedBitRate, deserialized.BitRate);
        Assert.Equal(expectedDensity, deserialized.Density);
        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedExif, deserialized.Exif);
        Assert.Equal(expectedFormat, deserialized.Format);
        Assert.Equal(expectedHasColorProfile, deserialized.HasColorProfile);
        Assert.Equal(expectedHasTransparency, deserialized.HasTransparency);
        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedPHash, deserialized.PHash);
        Assert.Equal(expectedQuality, deserialized.Quality);
        Assert.Equal(expectedSize, deserialized.Size);
        Assert.Equal(expectedVideoCodec, deserialized.VideoCodec);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileMetadata
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileMetadata { };

        Assert.Null(model.AudioCodec);
        Assert.False(model.RawData.ContainsKey("audioCodec"));
        Assert.Null(model.BitRate);
        Assert.False(model.RawData.ContainsKey("bitRate"));
        Assert.Null(model.Density);
        Assert.False(model.RawData.ContainsKey("density"));
        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.Exif);
        Assert.False(model.RawData.ContainsKey("exif"));
        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.HasColorProfile);
        Assert.False(model.RawData.ContainsKey("hasColorProfile"));
        Assert.Null(model.HasTransparency);
        Assert.False(model.RawData.ContainsKey("hasTransparency"));
        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.PHash);
        Assert.False(model.RawData.ContainsKey("pHash"));
        Assert.Null(model.Quality);
        Assert.False(model.RawData.ContainsKey("quality"));
        Assert.Null(model.Size);
        Assert.False(model.RawData.ContainsKey("size"));
        Assert.Null(model.VideoCodec);
        Assert.False(model.RawData.ContainsKey("videoCodec"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FileMetadata
        {
            // Null should be interpreted as omitted for these properties
            AudioCodec = null,
            BitRate = null,
            Density = null,
            Duration = null,
            Exif = null,
            Format = null,
            HasColorProfile = null,
            HasTransparency = null,
            Height = null,
            PHash = null,
            Quality = null,
            Size = null,
            VideoCodec = null,
            Width = null,
        };

        Assert.Null(model.AudioCodec);
        Assert.False(model.RawData.ContainsKey("audioCodec"));
        Assert.Null(model.BitRate);
        Assert.False(model.RawData.ContainsKey("bitRate"));
        Assert.Null(model.Density);
        Assert.False(model.RawData.ContainsKey("density"));
        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.Exif);
        Assert.False(model.RawData.ContainsKey("exif"));
        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.HasColorProfile);
        Assert.False(model.RawData.ContainsKey("hasColorProfile"));
        Assert.Null(model.HasTransparency);
        Assert.False(model.RawData.ContainsKey("hasTransparency"));
        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.PHash);
        Assert.False(model.RawData.ContainsKey("pHash"));
        Assert.Null(model.Quality);
        Assert.False(model.RawData.ContainsKey("quality"));
        Assert.Null(model.Size);
        Assert.False(model.RawData.ContainsKey("size"));
        Assert.Null(model.VideoCodec);
        Assert.False(model.RawData.ContainsKey("videoCodec"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FileMetadata
        {
            // Null should be interpreted as omitted for these properties
            AudioCodec = null,
            BitRate = null,
            Density = null,
            Duration = null,
            Exif = null,
            Format = null,
            HasColorProfile = null,
            HasTransparency = null,
            Height = null,
            PHash = null,
            Quality = null,
            Size = null,
            VideoCodec = null,
            Width = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileMetadata
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

        FileMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExifTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exif
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
        };

        ExifExif expectedExifValue = new()
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
        };
        Gps expectedGps = new() { GpsVersionID = [0] };
        Image expectedImage = new()
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
        };
        Interoperability expectedInteroperability = new()
        {
            InteropIndex = "InteropIndex",
            InteropVersion = "InteropVersion",
        };
        Dictionary<string, JsonElement> expectedMakernote = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ExifThumbnail expectedThumbnail = new()
        {
            Compression = 0,
            ResolutionUnit = 0,
            ThumbnailLength = 0,
            ThumbnailOffset = 0,
            XResolution = 0,
            YResolution = 0,
        };

        Assert.Equal(expectedExifValue, model.ExifValue);
        Assert.Equal(expectedGps, model.Gps);
        Assert.Equal(expectedImage, model.Image);
        Assert.Equal(expectedInteroperability, model.Interoperability);
        Assert.NotNull(model.Makernote);
        Assert.Equal(expectedMakernote.Count, model.Makernote.Count);
        foreach (var item in expectedMakernote)
        {
            Assert.True(model.Makernote.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Makernote[item.Key]));
        }
        Assert.Equal(expectedThumbnail, model.Thumbnail);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exif
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exif>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exif
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exif>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ExifExif expectedExifValue = new()
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
        };
        Gps expectedGps = new() { GpsVersionID = [0] };
        Image expectedImage = new()
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
        };
        Interoperability expectedInteroperability = new()
        {
            InteropIndex = "InteropIndex",
            InteropVersion = "InteropVersion",
        };
        Dictionary<string, JsonElement> expectedMakernote = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ExifThumbnail expectedThumbnail = new()
        {
            Compression = 0,
            ResolutionUnit = 0,
            ThumbnailLength = 0,
            ThumbnailOffset = 0,
            XResolution = 0,
            YResolution = 0,
        };

        Assert.Equal(expectedExifValue, deserialized.ExifValue);
        Assert.Equal(expectedGps, deserialized.Gps);
        Assert.Equal(expectedImage, deserialized.Image);
        Assert.Equal(expectedInteroperability, deserialized.Interoperability);
        Assert.NotNull(deserialized.Makernote);
        Assert.Equal(expectedMakernote.Count, deserialized.Makernote.Count);
        foreach (var item in expectedMakernote)
        {
            Assert.True(deserialized.Makernote.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Makernote[item.Key]));
        }
        Assert.Equal(expectedThumbnail, deserialized.Thumbnail);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exif
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Exif { };

        Assert.Null(model.ExifValue);
        Assert.False(model.RawData.ContainsKey("exif"));
        Assert.Null(model.Gps);
        Assert.False(model.RawData.ContainsKey("gps"));
        Assert.Null(model.Image);
        Assert.False(model.RawData.ContainsKey("image"));
        Assert.Null(model.Interoperability);
        Assert.False(model.RawData.ContainsKey("interoperability"));
        Assert.Null(model.Makernote);
        Assert.False(model.RawData.ContainsKey("makernote"));
        Assert.Null(model.Thumbnail);
        Assert.False(model.RawData.ContainsKey("thumbnail"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Exif { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Exif
        {
            // Null should be interpreted as omitted for these properties
            ExifValue = null,
            Gps = null,
            Image = null,
            Interoperability = null,
            Makernote = null,
            Thumbnail = null,
        };

        Assert.Null(model.ExifValue);
        Assert.False(model.RawData.ContainsKey("exif"));
        Assert.Null(model.Gps);
        Assert.False(model.RawData.ContainsKey("gps"));
        Assert.Null(model.Image);
        Assert.False(model.RawData.ContainsKey("image"));
        Assert.Null(model.Interoperability);
        Assert.False(model.RawData.ContainsKey("interoperability"));
        Assert.Null(model.Makernote);
        Assert.False(model.RawData.ContainsKey("makernote"));
        Assert.Null(model.Thumbnail);
        Assert.False(model.RawData.ContainsKey("thumbnail"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Exif
        {
            // Null should be interpreted as omitted for these properties
            ExifValue = null,
            Gps = null,
            Image = null,
            Interoperability = null,
            Makernote = null,
            Thumbnail = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exif
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
        };

        Exif copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExifExifTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExifExif
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
        };

        double expectedApertureValue = 0;
        long expectedColorSpace = 0;
        string expectedCreateDate = "CreateDate";
        long expectedCustomRendered = 0;
        string expectedDateTimeOriginal = "DateTimeOriginal";
        long expectedExifImageHeight = 0;
        long expectedExifImageWidth = 0;
        string expectedExifVersion = "ExifVersion";
        double expectedExposureCompensation = 0;
        long expectedExposureMode = 0;
        long expectedExposureProgram = 0;
        double expectedExposureTime = 0;
        long expectedFlash = 0;
        string expectedFlashpixVersion = "FlashpixVersion";
        double expectedFNumber = 0;
        long expectedFocalLength = 0;
        long expectedFocalPlaneResolutionUnit = 0;
        double expectedFocalPlaneXResolution = 0;
        double expectedFocalPlaneYResolution = 0;
        long expectedInteropOffset = 0;
        long expectedIso = 0;
        long expectedMeteringMode = 0;
        long expectedSceneCaptureType = 0;
        double expectedShutterSpeedValue = 0;
        string expectedSubSecTime = "SubSecTime";
        long expectedWhiteBalance = 0;

        Assert.Equal(expectedApertureValue, model.ApertureValue);
        Assert.Equal(expectedColorSpace, model.ColorSpace);
        Assert.Equal(expectedCreateDate, model.CreateDate);
        Assert.Equal(expectedCustomRendered, model.CustomRendered);
        Assert.Equal(expectedDateTimeOriginal, model.DateTimeOriginal);
        Assert.Equal(expectedExifImageHeight, model.ExifImageHeight);
        Assert.Equal(expectedExifImageWidth, model.ExifImageWidth);
        Assert.Equal(expectedExifVersion, model.ExifVersion);
        Assert.Equal(expectedExposureCompensation, model.ExposureCompensation);
        Assert.Equal(expectedExposureMode, model.ExposureMode);
        Assert.Equal(expectedExposureProgram, model.ExposureProgram);
        Assert.Equal(expectedExposureTime, model.ExposureTime);
        Assert.Equal(expectedFlash, model.Flash);
        Assert.Equal(expectedFlashpixVersion, model.FlashpixVersion);
        Assert.Equal(expectedFNumber, model.FNumber);
        Assert.Equal(expectedFocalLength, model.FocalLength);
        Assert.Equal(expectedFocalPlaneResolutionUnit, model.FocalPlaneResolutionUnit);
        Assert.Equal(expectedFocalPlaneXResolution, model.FocalPlaneXResolution);
        Assert.Equal(expectedFocalPlaneYResolution, model.FocalPlaneYResolution);
        Assert.Equal(expectedInteropOffset, model.InteropOffset);
        Assert.Equal(expectedIso, model.Iso);
        Assert.Equal(expectedMeteringMode, model.MeteringMode);
        Assert.Equal(expectedSceneCaptureType, model.SceneCaptureType);
        Assert.Equal(expectedShutterSpeedValue, model.ShutterSpeedValue);
        Assert.Equal(expectedSubSecTime, model.SubSecTime);
        Assert.Equal(expectedWhiteBalance, model.WhiteBalance);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExifExif
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExifExif>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExifExif
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExifExif>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedApertureValue = 0;
        long expectedColorSpace = 0;
        string expectedCreateDate = "CreateDate";
        long expectedCustomRendered = 0;
        string expectedDateTimeOriginal = "DateTimeOriginal";
        long expectedExifImageHeight = 0;
        long expectedExifImageWidth = 0;
        string expectedExifVersion = "ExifVersion";
        double expectedExposureCompensation = 0;
        long expectedExposureMode = 0;
        long expectedExposureProgram = 0;
        double expectedExposureTime = 0;
        long expectedFlash = 0;
        string expectedFlashpixVersion = "FlashpixVersion";
        double expectedFNumber = 0;
        long expectedFocalLength = 0;
        long expectedFocalPlaneResolutionUnit = 0;
        double expectedFocalPlaneXResolution = 0;
        double expectedFocalPlaneYResolution = 0;
        long expectedInteropOffset = 0;
        long expectedIso = 0;
        long expectedMeteringMode = 0;
        long expectedSceneCaptureType = 0;
        double expectedShutterSpeedValue = 0;
        string expectedSubSecTime = "SubSecTime";
        long expectedWhiteBalance = 0;

        Assert.Equal(expectedApertureValue, deserialized.ApertureValue);
        Assert.Equal(expectedColorSpace, deserialized.ColorSpace);
        Assert.Equal(expectedCreateDate, deserialized.CreateDate);
        Assert.Equal(expectedCustomRendered, deserialized.CustomRendered);
        Assert.Equal(expectedDateTimeOriginal, deserialized.DateTimeOriginal);
        Assert.Equal(expectedExifImageHeight, deserialized.ExifImageHeight);
        Assert.Equal(expectedExifImageWidth, deserialized.ExifImageWidth);
        Assert.Equal(expectedExifVersion, deserialized.ExifVersion);
        Assert.Equal(expectedExposureCompensation, deserialized.ExposureCompensation);
        Assert.Equal(expectedExposureMode, deserialized.ExposureMode);
        Assert.Equal(expectedExposureProgram, deserialized.ExposureProgram);
        Assert.Equal(expectedExposureTime, deserialized.ExposureTime);
        Assert.Equal(expectedFlash, deserialized.Flash);
        Assert.Equal(expectedFlashpixVersion, deserialized.FlashpixVersion);
        Assert.Equal(expectedFNumber, deserialized.FNumber);
        Assert.Equal(expectedFocalLength, deserialized.FocalLength);
        Assert.Equal(expectedFocalPlaneResolutionUnit, deserialized.FocalPlaneResolutionUnit);
        Assert.Equal(expectedFocalPlaneXResolution, deserialized.FocalPlaneXResolution);
        Assert.Equal(expectedFocalPlaneYResolution, deserialized.FocalPlaneYResolution);
        Assert.Equal(expectedInteropOffset, deserialized.InteropOffset);
        Assert.Equal(expectedIso, deserialized.Iso);
        Assert.Equal(expectedMeteringMode, deserialized.MeteringMode);
        Assert.Equal(expectedSceneCaptureType, deserialized.SceneCaptureType);
        Assert.Equal(expectedShutterSpeedValue, deserialized.ShutterSpeedValue);
        Assert.Equal(expectedSubSecTime, deserialized.SubSecTime);
        Assert.Equal(expectedWhiteBalance, deserialized.WhiteBalance);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExifExif
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExifExif { };

        Assert.Null(model.ApertureValue);
        Assert.False(model.RawData.ContainsKey("ApertureValue"));
        Assert.Null(model.ColorSpace);
        Assert.False(model.RawData.ContainsKey("ColorSpace"));
        Assert.Null(model.CreateDate);
        Assert.False(model.RawData.ContainsKey("CreateDate"));
        Assert.Null(model.CustomRendered);
        Assert.False(model.RawData.ContainsKey("CustomRendered"));
        Assert.Null(model.DateTimeOriginal);
        Assert.False(model.RawData.ContainsKey("DateTimeOriginal"));
        Assert.Null(model.ExifImageHeight);
        Assert.False(model.RawData.ContainsKey("ExifImageHeight"));
        Assert.Null(model.ExifImageWidth);
        Assert.False(model.RawData.ContainsKey("ExifImageWidth"));
        Assert.Null(model.ExifVersion);
        Assert.False(model.RawData.ContainsKey("ExifVersion"));
        Assert.Null(model.ExposureCompensation);
        Assert.False(model.RawData.ContainsKey("ExposureCompensation"));
        Assert.Null(model.ExposureMode);
        Assert.False(model.RawData.ContainsKey("ExposureMode"));
        Assert.Null(model.ExposureProgram);
        Assert.False(model.RawData.ContainsKey("ExposureProgram"));
        Assert.Null(model.ExposureTime);
        Assert.False(model.RawData.ContainsKey("ExposureTime"));
        Assert.Null(model.Flash);
        Assert.False(model.RawData.ContainsKey("Flash"));
        Assert.Null(model.FlashpixVersion);
        Assert.False(model.RawData.ContainsKey("FlashpixVersion"));
        Assert.Null(model.FNumber);
        Assert.False(model.RawData.ContainsKey("FNumber"));
        Assert.Null(model.FocalLength);
        Assert.False(model.RawData.ContainsKey("FocalLength"));
        Assert.Null(model.FocalPlaneResolutionUnit);
        Assert.False(model.RawData.ContainsKey("FocalPlaneResolutionUnit"));
        Assert.Null(model.FocalPlaneXResolution);
        Assert.False(model.RawData.ContainsKey("FocalPlaneXResolution"));
        Assert.Null(model.FocalPlaneYResolution);
        Assert.False(model.RawData.ContainsKey("FocalPlaneYResolution"));
        Assert.Null(model.InteropOffset);
        Assert.False(model.RawData.ContainsKey("InteropOffset"));
        Assert.Null(model.Iso);
        Assert.False(model.RawData.ContainsKey("ISO"));
        Assert.Null(model.MeteringMode);
        Assert.False(model.RawData.ContainsKey("MeteringMode"));
        Assert.Null(model.SceneCaptureType);
        Assert.False(model.RawData.ContainsKey("SceneCaptureType"));
        Assert.Null(model.ShutterSpeedValue);
        Assert.False(model.RawData.ContainsKey("ShutterSpeedValue"));
        Assert.Null(model.SubSecTime);
        Assert.False(model.RawData.ContainsKey("SubSecTime"));
        Assert.Null(model.WhiteBalance);
        Assert.False(model.RawData.ContainsKey("WhiteBalance"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExifExif { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExifExif
        {
            // Null should be interpreted as omitted for these properties
            ApertureValue = null,
            ColorSpace = null,
            CreateDate = null,
            CustomRendered = null,
            DateTimeOriginal = null,
            ExifImageHeight = null,
            ExifImageWidth = null,
            ExifVersion = null,
            ExposureCompensation = null,
            ExposureMode = null,
            ExposureProgram = null,
            ExposureTime = null,
            Flash = null,
            FlashpixVersion = null,
            FNumber = null,
            FocalLength = null,
            FocalPlaneResolutionUnit = null,
            FocalPlaneXResolution = null,
            FocalPlaneYResolution = null,
            InteropOffset = null,
            Iso = null,
            MeteringMode = null,
            SceneCaptureType = null,
            ShutterSpeedValue = null,
            SubSecTime = null,
            WhiteBalance = null,
        };

        Assert.Null(model.ApertureValue);
        Assert.False(model.RawData.ContainsKey("ApertureValue"));
        Assert.Null(model.ColorSpace);
        Assert.False(model.RawData.ContainsKey("ColorSpace"));
        Assert.Null(model.CreateDate);
        Assert.False(model.RawData.ContainsKey("CreateDate"));
        Assert.Null(model.CustomRendered);
        Assert.False(model.RawData.ContainsKey("CustomRendered"));
        Assert.Null(model.DateTimeOriginal);
        Assert.False(model.RawData.ContainsKey("DateTimeOriginal"));
        Assert.Null(model.ExifImageHeight);
        Assert.False(model.RawData.ContainsKey("ExifImageHeight"));
        Assert.Null(model.ExifImageWidth);
        Assert.False(model.RawData.ContainsKey("ExifImageWidth"));
        Assert.Null(model.ExifVersion);
        Assert.False(model.RawData.ContainsKey("ExifVersion"));
        Assert.Null(model.ExposureCompensation);
        Assert.False(model.RawData.ContainsKey("ExposureCompensation"));
        Assert.Null(model.ExposureMode);
        Assert.False(model.RawData.ContainsKey("ExposureMode"));
        Assert.Null(model.ExposureProgram);
        Assert.False(model.RawData.ContainsKey("ExposureProgram"));
        Assert.Null(model.ExposureTime);
        Assert.False(model.RawData.ContainsKey("ExposureTime"));
        Assert.Null(model.Flash);
        Assert.False(model.RawData.ContainsKey("Flash"));
        Assert.Null(model.FlashpixVersion);
        Assert.False(model.RawData.ContainsKey("FlashpixVersion"));
        Assert.Null(model.FNumber);
        Assert.False(model.RawData.ContainsKey("FNumber"));
        Assert.Null(model.FocalLength);
        Assert.False(model.RawData.ContainsKey("FocalLength"));
        Assert.Null(model.FocalPlaneResolutionUnit);
        Assert.False(model.RawData.ContainsKey("FocalPlaneResolutionUnit"));
        Assert.Null(model.FocalPlaneXResolution);
        Assert.False(model.RawData.ContainsKey("FocalPlaneXResolution"));
        Assert.Null(model.FocalPlaneYResolution);
        Assert.False(model.RawData.ContainsKey("FocalPlaneYResolution"));
        Assert.Null(model.InteropOffset);
        Assert.False(model.RawData.ContainsKey("InteropOffset"));
        Assert.Null(model.Iso);
        Assert.False(model.RawData.ContainsKey("ISO"));
        Assert.Null(model.MeteringMode);
        Assert.False(model.RawData.ContainsKey("MeteringMode"));
        Assert.Null(model.SceneCaptureType);
        Assert.False(model.RawData.ContainsKey("SceneCaptureType"));
        Assert.Null(model.ShutterSpeedValue);
        Assert.False(model.RawData.ContainsKey("ShutterSpeedValue"));
        Assert.Null(model.SubSecTime);
        Assert.False(model.RawData.ContainsKey("SubSecTime"));
        Assert.Null(model.WhiteBalance);
        Assert.False(model.RawData.ContainsKey("WhiteBalance"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExifExif
        {
            // Null should be interpreted as omitted for these properties
            ApertureValue = null,
            ColorSpace = null,
            CreateDate = null,
            CustomRendered = null,
            DateTimeOriginal = null,
            ExifImageHeight = null,
            ExifImageWidth = null,
            ExifVersion = null,
            ExposureCompensation = null,
            ExposureMode = null,
            ExposureProgram = null,
            ExposureTime = null,
            Flash = null,
            FlashpixVersion = null,
            FNumber = null,
            FocalLength = null,
            FocalPlaneResolutionUnit = null,
            FocalPlaneXResolution = null,
            FocalPlaneYResolution = null,
            InteropOffset = null,
            Iso = null,
            MeteringMode = null,
            SceneCaptureType = null,
            ShutterSpeedValue = null,
            SubSecTime = null,
            WhiteBalance = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExifExif
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
        };

        ExifExif copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GpsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Gps { GpsVersionID = [0] };

        List<long> expectedGpsVersionID = [0];

        Assert.NotNull(model.GpsVersionID);
        Assert.Equal(expectedGpsVersionID.Count, model.GpsVersionID.Count);
        for (int i = 0; i < expectedGpsVersionID.Count; i++)
        {
            Assert.Equal(expectedGpsVersionID[i], model.GpsVersionID[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Gps { GpsVersionID = [0] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Gps>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Gps { GpsVersionID = [0] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Gps>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<long> expectedGpsVersionID = [0];

        Assert.NotNull(deserialized.GpsVersionID);
        Assert.Equal(expectedGpsVersionID.Count, deserialized.GpsVersionID.Count);
        for (int i = 0; i < expectedGpsVersionID.Count; i++)
        {
            Assert.Equal(expectedGpsVersionID[i], deserialized.GpsVersionID[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Gps { GpsVersionID = [0] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Gps { };

        Assert.Null(model.GpsVersionID);
        Assert.False(model.RawData.ContainsKey("GPSVersionID"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Gps { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Gps
        {
            // Null should be interpreted as omitted for these properties
            GpsVersionID = null,
        };

        Assert.Null(model.GpsVersionID);
        Assert.False(model.RawData.ContainsKey("GPSVersionID"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Gps
        {
            // Null should be interpreted as omitted for these properties
            GpsVersionID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Gps { GpsVersionID = [0] };

        Gps copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Image
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
        };

        long expectedExifOffset = 0;
        long expectedGpsInfo = 0;
        string expectedMake = "Make";
        string expectedModel = "Model";
        string expectedModifyDate = "ModifyDate";
        long expectedOrientation = 0;
        long expectedResolutionUnit = 0;
        string expectedSoftware = "Software";
        long expectedXResolution = 0;
        long expectedYCbCrPositioning = 0;
        long expectedYResolution = 0;

        Assert.Equal(expectedExifOffset, model.ExifOffset);
        Assert.Equal(expectedGpsInfo, model.GpsInfo);
        Assert.Equal(expectedMake, model.Make);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedModifyDate, model.ModifyDate);
        Assert.Equal(expectedOrientation, model.Orientation);
        Assert.Equal(expectedResolutionUnit, model.ResolutionUnit);
        Assert.Equal(expectedSoftware, model.Software);
        Assert.Equal(expectedXResolution, model.XResolution);
        Assert.Equal(expectedYCbCrPositioning, model.YCbCrPositioning);
        Assert.Equal(expectedYResolution, model.YResolution);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Image
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Image>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Image
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Image>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedExifOffset = 0;
        long expectedGpsInfo = 0;
        string expectedMake = "Make";
        string expectedModel = "Model";
        string expectedModifyDate = "ModifyDate";
        long expectedOrientation = 0;
        long expectedResolutionUnit = 0;
        string expectedSoftware = "Software";
        long expectedXResolution = 0;
        long expectedYCbCrPositioning = 0;
        long expectedYResolution = 0;

        Assert.Equal(expectedExifOffset, deserialized.ExifOffset);
        Assert.Equal(expectedGpsInfo, deserialized.GpsInfo);
        Assert.Equal(expectedMake, deserialized.Make);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedModifyDate, deserialized.ModifyDate);
        Assert.Equal(expectedOrientation, deserialized.Orientation);
        Assert.Equal(expectedResolutionUnit, deserialized.ResolutionUnit);
        Assert.Equal(expectedSoftware, deserialized.Software);
        Assert.Equal(expectedXResolution, deserialized.XResolution);
        Assert.Equal(expectedYCbCrPositioning, deserialized.YCbCrPositioning);
        Assert.Equal(expectedYResolution, deserialized.YResolution);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Image
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Image { };

        Assert.Null(model.ExifOffset);
        Assert.False(model.RawData.ContainsKey("ExifOffset"));
        Assert.Null(model.GpsInfo);
        Assert.False(model.RawData.ContainsKey("GPSInfo"));
        Assert.Null(model.Make);
        Assert.False(model.RawData.ContainsKey("Make"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("Model"));
        Assert.Null(model.ModifyDate);
        Assert.False(model.RawData.ContainsKey("ModifyDate"));
        Assert.Null(model.Orientation);
        Assert.False(model.RawData.ContainsKey("Orientation"));
        Assert.Null(model.ResolutionUnit);
        Assert.False(model.RawData.ContainsKey("ResolutionUnit"));
        Assert.Null(model.Software);
        Assert.False(model.RawData.ContainsKey("Software"));
        Assert.Null(model.XResolution);
        Assert.False(model.RawData.ContainsKey("XResolution"));
        Assert.Null(model.YCbCrPositioning);
        Assert.False(model.RawData.ContainsKey("YCbCrPositioning"));
        Assert.Null(model.YResolution);
        Assert.False(model.RawData.ContainsKey("YResolution"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Image { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Image
        {
            // Null should be interpreted as omitted for these properties
            ExifOffset = null,
            GpsInfo = null,
            Make = null,
            Model = null,
            ModifyDate = null,
            Orientation = null,
            ResolutionUnit = null,
            Software = null,
            XResolution = null,
            YCbCrPositioning = null,
            YResolution = null,
        };

        Assert.Null(model.ExifOffset);
        Assert.False(model.RawData.ContainsKey("ExifOffset"));
        Assert.Null(model.GpsInfo);
        Assert.False(model.RawData.ContainsKey("GPSInfo"));
        Assert.Null(model.Make);
        Assert.False(model.RawData.ContainsKey("Make"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("Model"));
        Assert.Null(model.ModifyDate);
        Assert.False(model.RawData.ContainsKey("ModifyDate"));
        Assert.Null(model.Orientation);
        Assert.False(model.RawData.ContainsKey("Orientation"));
        Assert.Null(model.ResolutionUnit);
        Assert.False(model.RawData.ContainsKey("ResolutionUnit"));
        Assert.Null(model.Software);
        Assert.False(model.RawData.ContainsKey("Software"));
        Assert.Null(model.XResolution);
        Assert.False(model.RawData.ContainsKey("XResolution"));
        Assert.Null(model.YCbCrPositioning);
        Assert.False(model.RawData.ContainsKey("YCbCrPositioning"));
        Assert.Null(model.YResolution);
        Assert.False(model.RawData.ContainsKey("YResolution"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Image
        {
            // Null should be interpreted as omitted for these properties
            ExifOffset = null,
            GpsInfo = null,
            Make = null,
            Model = null,
            ModifyDate = null,
            Orientation = null,
            ResolutionUnit = null,
            Software = null,
            XResolution = null,
            YCbCrPositioning = null,
            YResolution = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Image
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
        };

        Image copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InteroperabilityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Interoperability
        {
            InteropIndex = "InteropIndex",
            InteropVersion = "InteropVersion",
        };

        string expectedInteropIndex = "InteropIndex";
        string expectedInteropVersion = "InteropVersion";

        Assert.Equal(expectedInteropIndex, model.InteropIndex);
        Assert.Equal(expectedInteropVersion, model.InteropVersion);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Interoperability
        {
            InteropIndex = "InteropIndex",
            InteropVersion = "InteropVersion",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Interoperability>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Interoperability
        {
            InteropIndex = "InteropIndex",
            InteropVersion = "InteropVersion",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Interoperability>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInteropIndex = "InteropIndex";
        string expectedInteropVersion = "InteropVersion";

        Assert.Equal(expectedInteropIndex, deserialized.InteropIndex);
        Assert.Equal(expectedInteropVersion, deserialized.InteropVersion);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Interoperability
        {
            InteropIndex = "InteropIndex",
            InteropVersion = "InteropVersion",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Interoperability { };

        Assert.Null(model.InteropIndex);
        Assert.False(model.RawData.ContainsKey("InteropIndex"));
        Assert.Null(model.InteropVersion);
        Assert.False(model.RawData.ContainsKey("InteropVersion"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Interoperability { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Interoperability
        {
            // Null should be interpreted as omitted for these properties
            InteropIndex = null,
            InteropVersion = null,
        };

        Assert.Null(model.InteropIndex);
        Assert.False(model.RawData.ContainsKey("InteropIndex"));
        Assert.Null(model.InteropVersion);
        Assert.False(model.RawData.ContainsKey("InteropVersion"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Interoperability
        {
            // Null should be interpreted as omitted for these properties
            InteropIndex = null,
            InteropVersion = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Interoperability
        {
            InteropIndex = "InteropIndex",
            InteropVersion = "InteropVersion",
        };

        Interoperability copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExifThumbnailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExifThumbnail
        {
            Compression = 0,
            ResolutionUnit = 0,
            ThumbnailLength = 0,
            ThumbnailOffset = 0,
            XResolution = 0,
            YResolution = 0,
        };

        long expectedCompression = 0;
        long expectedResolutionUnit = 0;
        long expectedThumbnailLength = 0;
        long expectedThumbnailOffset = 0;
        long expectedXResolution = 0;
        long expectedYResolution = 0;

        Assert.Equal(expectedCompression, model.Compression);
        Assert.Equal(expectedResolutionUnit, model.ResolutionUnit);
        Assert.Equal(expectedThumbnailLength, model.ThumbnailLength);
        Assert.Equal(expectedThumbnailOffset, model.ThumbnailOffset);
        Assert.Equal(expectedXResolution, model.XResolution);
        Assert.Equal(expectedYResolution, model.YResolution);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExifThumbnail
        {
            Compression = 0,
            ResolutionUnit = 0,
            ThumbnailLength = 0,
            ThumbnailOffset = 0,
            XResolution = 0,
            YResolution = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExifThumbnail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExifThumbnail
        {
            Compression = 0,
            ResolutionUnit = 0,
            ThumbnailLength = 0,
            ThumbnailOffset = 0,
            XResolution = 0,
            YResolution = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExifThumbnail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCompression = 0;
        long expectedResolutionUnit = 0;
        long expectedThumbnailLength = 0;
        long expectedThumbnailOffset = 0;
        long expectedXResolution = 0;
        long expectedYResolution = 0;

        Assert.Equal(expectedCompression, deserialized.Compression);
        Assert.Equal(expectedResolutionUnit, deserialized.ResolutionUnit);
        Assert.Equal(expectedThumbnailLength, deserialized.ThumbnailLength);
        Assert.Equal(expectedThumbnailOffset, deserialized.ThumbnailOffset);
        Assert.Equal(expectedXResolution, deserialized.XResolution);
        Assert.Equal(expectedYResolution, deserialized.YResolution);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExifThumbnail
        {
            Compression = 0,
            ResolutionUnit = 0,
            ThumbnailLength = 0,
            ThumbnailOffset = 0,
            XResolution = 0,
            YResolution = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExifThumbnail { };

        Assert.Null(model.Compression);
        Assert.False(model.RawData.ContainsKey("Compression"));
        Assert.Null(model.ResolutionUnit);
        Assert.False(model.RawData.ContainsKey("ResolutionUnit"));
        Assert.Null(model.ThumbnailLength);
        Assert.False(model.RawData.ContainsKey("ThumbnailLength"));
        Assert.Null(model.ThumbnailOffset);
        Assert.False(model.RawData.ContainsKey("ThumbnailOffset"));
        Assert.Null(model.XResolution);
        Assert.False(model.RawData.ContainsKey("XResolution"));
        Assert.Null(model.YResolution);
        Assert.False(model.RawData.ContainsKey("YResolution"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExifThumbnail { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExifThumbnail
        {
            // Null should be interpreted as omitted for these properties
            Compression = null,
            ResolutionUnit = null,
            ThumbnailLength = null,
            ThumbnailOffset = null,
            XResolution = null,
            YResolution = null,
        };

        Assert.Null(model.Compression);
        Assert.False(model.RawData.ContainsKey("Compression"));
        Assert.Null(model.ResolutionUnit);
        Assert.False(model.RawData.ContainsKey("ResolutionUnit"));
        Assert.Null(model.ThumbnailLength);
        Assert.False(model.RawData.ContainsKey("ThumbnailLength"));
        Assert.Null(model.ThumbnailOffset);
        Assert.False(model.RawData.ContainsKey("ThumbnailOffset"));
        Assert.Null(model.XResolution);
        Assert.False(model.RawData.ContainsKey("XResolution"));
        Assert.Null(model.YResolution);
        Assert.False(model.RawData.ContainsKey("YResolution"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExifThumbnail
        {
            // Null should be interpreted as omitted for these properties
            Compression = null,
            ResolutionUnit = null,
            ThumbnailLength = null,
            ThumbnailOffset = null,
            XResolution = null,
            YResolution = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExifThumbnail
        {
            Compression = 0,
            ResolutionUnit = 0,
            ThumbnailLength = 0,
            ThumbnailOffset = 0,
            XResolution = 0,
            YResolution = 0,
        };

        ExifThumbnail copied = new(model);

        Assert.Equal(model, copied);
    }
}
