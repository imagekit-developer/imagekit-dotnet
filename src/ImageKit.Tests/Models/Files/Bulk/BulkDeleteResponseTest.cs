using System.Collections.Generic;
using System.Text.Json;
using ImageKit.Core;
using ImageKit.Models.Files.Bulk;

namespace ImageKit.Tests.Models.Files.Bulk;

public class BulkDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BulkDeleteResponse { SuccessfullyDeletedFileIds = ["string"] };

        List<string> expectedSuccessfullyDeletedFileIds = ["string"];

        Assert.NotNull(model.SuccessfullyDeletedFileIds);
        Assert.Equal(
            expectedSuccessfullyDeletedFileIds.Count,
            model.SuccessfullyDeletedFileIds.Count
        );
        for (int i = 0; i < expectedSuccessfullyDeletedFileIds.Count; i++)
        {
            Assert.Equal(
                expectedSuccessfullyDeletedFileIds[i],
                model.SuccessfullyDeletedFileIds[i]
            );
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BulkDeleteResponse { SuccessfullyDeletedFileIds = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BulkDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BulkDeleteResponse { SuccessfullyDeletedFileIds = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BulkDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedSuccessfullyDeletedFileIds = ["string"];

        Assert.NotNull(deserialized.SuccessfullyDeletedFileIds);
        Assert.Equal(
            expectedSuccessfullyDeletedFileIds.Count,
            deserialized.SuccessfullyDeletedFileIds.Count
        );
        for (int i = 0; i < expectedSuccessfullyDeletedFileIds.Count; i++)
        {
            Assert.Equal(
                expectedSuccessfullyDeletedFileIds[i],
                deserialized.SuccessfullyDeletedFileIds[i]
            );
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BulkDeleteResponse { SuccessfullyDeletedFileIds = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BulkDeleteResponse { };

        Assert.Null(model.SuccessfullyDeletedFileIds);
        Assert.False(model.RawData.ContainsKey("successfullyDeletedFileIds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BulkDeleteResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BulkDeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            SuccessfullyDeletedFileIds = null,
        };

        Assert.Null(model.SuccessfullyDeletedFileIds);
        Assert.False(model.RawData.ContainsKey("successfullyDeletedFileIds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BulkDeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            SuccessfullyDeletedFileIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BulkDeleteResponse { SuccessfullyDeletedFileIds = ["string"] };

        BulkDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
