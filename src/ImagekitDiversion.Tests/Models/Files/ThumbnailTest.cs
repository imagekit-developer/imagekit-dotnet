using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Files;

namespace ImagekitDiversion.Tests.Models.Files;

public class ThumbnailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Thumbnail
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
        var model = new Thumbnail
        {
            Compression = 0,
            ResolutionUnit = 0,
            ThumbnailLength = 0,
            ThumbnailOffset = 0,
            XResolution = 0,
            YResolution = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Thumbnail>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Thumbnail
        {
            Compression = 0,
            ResolutionUnit = 0,
            ThumbnailLength = 0,
            ThumbnailOffset = 0,
            XResolution = 0,
            YResolution = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Thumbnail>(
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
        var model = new Thumbnail
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
        var model = new Thumbnail { };

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
        var model = new Thumbnail { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Thumbnail
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
        var model = new Thumbnail
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
        var model = new Thumbnail
        {
            Compression = 0,
            ResolutionUnit = 0,
            ThumbnailLength = 0,
            ThumbnailOffset = 0,
            XResolution = 0,
            YResolution = 0,
        };

        Thumbnail copied = new(model);

        Assert.Equal(model, copied);
    }
}
