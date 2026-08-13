using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.NamedTransformations;

namespace Imagekit.Tests.Models.NamedTransformations;

public class NamedTransformationDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NamedTransformationDeleteResponse { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NamedTransformationDeleteResponse { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NamedTransformationDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NamedTransformationDeleteResponse { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NamedTransformationDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NamedTransformationDeleteResponse { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NamedTransformationDeleteResponse { };

        NamedTransformationDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
