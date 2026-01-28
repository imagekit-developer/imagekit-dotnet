using System.Text.Json;
using ImageKit.Core;
using ImageKit.Models.CustomMetadataFields;

namespace ImageKit.Tests.Models.CustomMetadataFields;

public class CustomMetadataFieldDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomMetadataFieldDeleteResponse { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomMetadataFieldDeleteResponse { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFieldDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomMetadataFieldDeleteResponse { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFieldDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomMetadataFieldDeleteResponse { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomMetadataFieldDeleteResponse { };

        CustomMetadataFieldDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
