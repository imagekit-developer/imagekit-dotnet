using System.Text.Json;
using ImageKit.Core;
using ImageKit.Models.Files;

namespace ImageKit.Tests.Models.Files;

public class FileMoveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileMoveResponse { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileMoveResponse { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileMoveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileMoveResponse { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileMoveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileMoveResponse { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileMoveResponse { };

        FileMoveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
