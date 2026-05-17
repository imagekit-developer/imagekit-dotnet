using System.Collections.Generic;
using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Files;

namespace ImagekitDiversion.Tests.Models.Files;

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
