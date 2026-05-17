using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Files;

namespace ImagekitDiversion.Tests.Models.Files;

public class ExifImageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExifImage
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
        var model = new ExifImage
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
        var deserialized = JsonSerializer.Deserialize<ExifImage>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExifImage
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
        var deserialized = JsonSerializer.Deserialize<ExifImage>(
            element,
            ModelBase.SerializerOptions
        );
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
        var model = new ExifImage
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
        var model = new ExifImage { };

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
        var model = new ExifImage { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExifImage
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
        var model = new ExifImage
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
        var model = new ExifImage
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

        ExifImage copied = new(model);

        Assert.Equal(model, copied);
    }
}
