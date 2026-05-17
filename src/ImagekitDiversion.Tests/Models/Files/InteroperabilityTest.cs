using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Files;

namespace ImagekitDiversion.Tests.Models.Files;

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
