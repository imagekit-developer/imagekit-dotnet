using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Files.Bulk;

namespace Imagekit.Tests.Models.Files.Bulk;

public class BulkRemoveAITagsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BulkRemoveAITagsResponse { SuccessfullyUpdatedFileIds = ["string"] };

        List<string> expectedSuccessfullyUpdatedFileIds = ["string"];

        Assert.NotNull(model.SuccessfullyUpdatedFileIds);
        Assert.Equal(
            expectedSuccessfullyUpdatedFileIds.Count,
            model.SuccessfullyUpdatedFileIds.Count
        );
        for (int i = 0; i < expectedSuccessfullyUpdatedFileIds.Count; i++)
        {
            Assert.Equal(
                expectedSuccessfullyUpdatedFileIds[i],
                model.SuccessfullyUpdatedFileIds[i]
            );
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BulkRemoveAITagsResponse { SuccessfullyUpdatedFileIds = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BulkRemoveAITagsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BulkRemoveAITagsResponse { SuccessfullyUpdatedFileIds = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BulkRemoveAITagsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedSuccessfullyUpdatedFileIds = ["string"];

        Assert.NotNull(deserialized.SuccessfullyUpdatedFileIds);
        Assert.Equal(
            expectedSuccessfullyUpdatedFileIds.Count,
            deserialized.SuccessfullyUpdatedFileIds.Count
        );
        for (int i = 0; i < expectedSuccessfullyUpdatedFileIds.Count; i++)
        {
            Assert.Equal(
                expectedSuccessfullyUpdatedFileIds[i],
                deserialized.SuccessfullyUpdatedFileIds[i]
            );
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BulkRemoveAITagsResponse { SuccessfullyUpdatedFileIds = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BulkRemoveAITagsResponse { };

        Assert.Null(model.SuccessfullyUpdatedFileIds);
        Assert.False(model.RawData.ContainsKey("successfullyUpdatedFileIds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BulkRemoveAITagsResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BulkRemoveAITagsResponse
        {
            // Null should be interpreted as omitted for these properties
            SuccessfullyUpdatedFileIds = null,
        };

        Assert.Null(model.SuccessfullyUpdatedFileIds);
        Assert.False(model.RawData.ContainsKey("successfullyUpdatedFileIds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BulkRemoveAITagsResponse
        {
            // Null should be interpreted as omitted for these properties
            SuccessfullyUpdatedFileIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BulkRemoveAITagsResponse { SuccessfullyUpdatedFileIds = ["string"] };

        BulkRemoveAITagsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
