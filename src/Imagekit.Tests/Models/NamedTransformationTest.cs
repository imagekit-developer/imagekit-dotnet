using System;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models;

namespace Imagekit.Tests.Models;

public class NamedTransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NamedTransformation
        {
            ID = "6bZ9x2ZUx",
            CreatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z"),
            Disabled = false,
            Name = "small_thumbnail",
            Transformation = "tr:w-150,h-150,fo-center,cm-resize",
        };

        string expectedID = "6bZ9x2ZUx";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z");
        bool expectedDisabled = false;
        string expectedName = "small_thumbnail";
        string expectedTransformation = "tr:w-150,h-150,fo-center,cm-resize";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisabled, model.Disabled);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTransformation, model.Transformation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NamedTransformation
        {
            ID = "6bZ9x2ZUx",
            CreatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z"),
            Disabled = false,
            Name = "small_thumbnail",
            Transformation = "tr:w-150,h-150,fo-center,cm-resize",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NamedTransformation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NamedTransformation
        {
            ID = "6bZ9x2ZUx",
            CreatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z"),
            Disabled = false,
            Name = "small_thumbnail",
            Transformation = "tr:w-150,h-150,fo-center,cm-resize",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NamedTransformation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "6bZ9x2ZUx";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z");
        bool expectedDisabled = false;
        string expectedName = "small_thumbnail";
        string expectedTransformation = "tr:w-150,h-150,fo-center,cm-resize";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisabled, deserialized.Disabled);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTransformation, deserialized.Transformation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NamedTransformation
        {
            ID = "6bZ9x2ZUx",
            CreatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z"),
            Disabled = false,
            Name = "small_thumbnail",
            Transformation = "tr:w-150,h-150,fo-center,cm-resize",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NamedTransformation { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Disabled);
        Assert.False(model.RawData.ContainsKey("disabled"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NamedTransformation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NamedTransformation
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Disabled = null,
            Name = null,
            Transformation = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Disabled);
        Assert.False(model.RawData.ContainsKey("disabled"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Transformation);
        Assert.False(model.RawData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NamedTransformation
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Disabled = null,
            Name = null,
            Transformation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NamedTransformation
        {
            ID = "6bZ9x2ZUx",
            CreatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z"),
            Disabled = false,
            Name = "small_thumbnail",
            Transformation = "tr:w-150,h-150,fo-center,cm-resize",
        };

        NamedTransformation copied = new(model);

        Assert.Equal(model, copied);
    }
}
