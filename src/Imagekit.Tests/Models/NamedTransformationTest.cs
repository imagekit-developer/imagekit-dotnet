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
            Enabled = true,
            Name = "small_thumbnail",
            Transformation = "w-150,h-150,fo-center,cm-pad_resize",
        };

        string expectedID = "6bZ9x2ZUx";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z");
        bool expectedEnabled = true;
        string expectedName = "small_thumbnail";
        string expectedTransformation = "w-150,h-150,fo-center,cm-pad_resize";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEnabled, model.Enabled);
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
            Enabled = true,
            Name = "small_thumbnail",
            Transformation = "w-150,h-150,fo-center,cm-pad_resize",
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
            Enabled = true,
            Name = "small_thumbnail",
            Transformation = "w-150,h-150,fo-center,cm-pad_resize",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NamedTransformation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "6bZ9x2ZUx";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-10T09:00:00.000Z");
        bool expectedEnabled = true;
        string expectedName = "small_thumbnail";
        string expectedTransformation = "w-150,h-150,fo-center,cm-pad_resize";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEnabled, deserialized.Enabled);
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
            Enabled = true,
            Name = "small_thumbnail",
            Transformation = "w-150,h-150,fo-center,cm-pad_resize",
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
            Enabled = true,
            Name = "small_thumbnail",
            Transformation = "w-150,h-150,fo-center,cm-pad_resize",
        };

        NamedTransformation copied = new(model);

        Assert.Equal(model, copied);
    }
}
