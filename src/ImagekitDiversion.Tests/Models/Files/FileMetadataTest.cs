using System.Collections.Generic;
using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Files;

namespace ImagekitDiversion.Tests.Models.Files;

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

        ExifDetails expectedExifValue = new()
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
        ExifImage expectedImage = new()
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
        Thumbnail expectedThumbnail = new()
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

        ExifDetails expectedExifValue = new()
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
        ExifImage expectedImage = new()
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
        Thumbnail expectedThumbnail = new()
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
