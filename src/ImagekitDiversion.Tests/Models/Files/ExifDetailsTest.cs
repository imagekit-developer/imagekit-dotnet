using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Files;

namespace ImagekitDiversion.Tests.Models.Files;

public class ExifDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExifDetails
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
        var model = new ExifDetails
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
        var deserialized = JsonSerializer.Deserialize<ExifDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExifDetails
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
        var deserialized = JsonSerializer.Deserialize<ExifDetails>(
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
        var model = new ExifDetails
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
        var model = new ExifDetails { };

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
        var model = new ExifDetails { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExifDetails
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
        var model = new ExifDetails
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
        var model = new ExifDetails
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

        ExifDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
