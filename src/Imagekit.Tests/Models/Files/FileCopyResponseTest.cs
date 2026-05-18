using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Files;

namespace Imagekit.Tests.Models.Files;

public class FileCopyResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileCopyResponse { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileCopyResponse { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileCopyResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileCopyResponse { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileCopyResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileCopyResponse { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileCopyResponse { };

        FileCopyResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
