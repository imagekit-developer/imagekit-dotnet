using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Files;

namespace Imagekit.Tests.Models.Files;

public class FileRenameResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileRenameResponse { PurgeRequestID = "purgeRequestId" };

        string expectedPurgeRequestID = "purgeRequestId";

        Assert.Equal(expectedPurgeRequestID, model.PurgeRequestID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileRenameResponse { PurgeRequestID = "purgeRequestId" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileRenameResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileRenameResponse { PurgeRequestID = "purgeRequestId" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileRenameResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPurgeRequestID = "purgeRequestId";

        Assert.Equal(expectedPurgeRequestID, deserialized.PurgeRequestID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileRenameResponse { PurgeRequestID = "purgeRequestId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileRenameResponse { };

        Assert.Null(model.PurgeRequestID);
        Assert.False(model.RawData.ContainsKey("purgeRequestId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileRenameResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FileRenameResponse
        {
            // Null should be interpreted as omitted for these properties
            PurgeRequestID = null,
        };

        Assert.Null(model.PurgeRequestID);
        Assert.False(model.RawData.ContainsKey("purgeRequestId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FileRenameResponse
        {
            // Null should be interpreted as omitted for these properties
            PurgeRequestID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileRenameResponse { PurgeRequestID = "purgeRequestId" };

        FileRenameResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
