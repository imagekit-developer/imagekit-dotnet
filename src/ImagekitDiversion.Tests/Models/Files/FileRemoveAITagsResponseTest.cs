using System.Collections.Generic;
using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Files;

namespace ImagekitDiversion.Tests.Models.Files;

public class FileRemoveAITagsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileRemoveAITagsResponse { SuccessfullyUpdatedFileIds = ["string"] };

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
        var model = new FileRemoveAITagsResponse { SuccessfullyUpdatedFileIds = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileRemoveAITagsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileRemoveAITagsResponse { SuccessfullyUpdatedFileIds = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileRemoveAITagsResponse>(
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
        var model = new FileRemoveAITagsResponse { SuccessfullyUpdatedFileIds = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileRemoveAITagsResponse { };

        Assert.Null(model.SuccessfullyUpdatedFileIds);
        Assert.False(model.RawData.ContainsKey("successfullyUpdatedFileIds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileRemoveAITagsResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FileRemoveAITagsResponse
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
        var model = new FileRemoveAITagsResponse
        {
            // Null should be interpreted as omitted for these properties
            SuccessfullyUpdatedFileIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileRemoveAITagsResponse { SuccessfullyUpdatedFileIds = ["string"] };

        FileRemoveAITagsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
