using System.Collections.Generic;
using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Dummy;

namespace ImagekitDiversion.Tests.Models.Dummy;

public class AITaskActionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AITaskAction
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<SetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<UnsetMetadata> expectedUnsetMetadata = [new("price_range")];

        Assert.NotNull(model.AddTags);
        Assert.Equal(expectedAddTags.Count, model.AddTags.Count);
        for (int i = 0; i < expectedAddTags.Count; i++)
        {
            Assert.Equal(expectedAddTags[i], model.AddTags[i]);
        }
        Assert.NotNull(model.RemoveTags);
        Assert.Equal(expectedRemoveTags.Count, model.RemoveTags.Count);
        for (int i = 0; i < expectedRemoveTags.Count; i++)
        {
            Assert.Equal(expectedRemoveTags[i], model.RemoveTags[i]);
        }
        Assert.NotNull(model.SetMetadata);
        Assert.Equal(expectedSetMetadata.Count, model.SetMetadata.Count);
        for (int i = 0; i < expectedSetMetadata.Count; i++)
        {
            Assert.Equal(expectedSetMetadata[i], model.SetMetadata[i]);
        }
        Assert.NotNull(model.UnsetMetadata);
        Assert.Equal(expectedUnsetMetadata.Count, model.UnsetMetadata.Count);
        for (int i = 0; i < expectedUnsetMetadata.Count; i++)
        {
            Assert.Equal(expectedUnsetMetadata[i], model.UnsetMetadata[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AITaskAction
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AITaskAction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AITaskAction
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AITaskAction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedAddTags = ["luxury", "premium"];
        List<string> expectedRemoveTags = ["budget", "affordable"];
        List<SetMetadata> expectedSetMetadata =
        [
            new() { Field = "price_range", Value = "premium" },
        ];
        List<UnsetMetadata> expectedUnsetMetadata = [new("price_range")];

        Assert.NotNull(deserialized.AddTags);
        Assert.Equal(expectedAddTags.Count, deserialized.AddTags.Count);
        for (int i = 0; i < expectedAddTags.Count; i++)
        {
            Assert.Equal(expectedAddTags[i], deserialized.AddTags[i]);
        }
        Assert.NotNull(deserialized.RemoveTags);
        Assert.Equal(expectedRemoveTags.Count, deserialized.RemoveTags.Count);
        for (int i = 0; i < expectedRemoveTags.Count; i++)
        {
            Assert.Equal(expectedRemoveTags[i], deserialized.RemoveTags[i]);
        }
        Assert.NotNull(deserialized.SetMetadata);
        Assert.Equal(expectedSetMetadata.Count, deserialized.SetMetadata.Count);
        for (int i = 0; i < expectedSetMetadata.Count; i++)
        {
            Assert.Equal(expectedSetMetadata[i], deserialized.SetMetadata[i]);
        }
        Assert.NotNull(deserialized.UnsetMetadata);
        Assert.Equal(expectedUnsetMetadata.Count, deserialized.UnsetMetadata.Count);
        for (int i = 0; i < expectedUnsetMetadata.Count; i++)
        {
            Assert.Equal(expectedUnsetMetadata[i], deserialized.UnsetMetadata[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AITaskAction
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AITaskAction { };

        Assert.Null(model.AddTags);
        Assert.False(model.RawData.ContainsKey("add_tags"));
        Assert.Null(model.RemoveTags);
        Assert.False(model.RawData.ContainsKey("remove_tags"));
        Assert.Null(model.SetMetadata);
        Assert.False(model.RawData.ContainsKey("set_metadata"));
        Assert.Null(model.UnsetMetadata);
        Assert.False(model.RawData.ContainsKey("unset_metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AITaskAction { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AITaskAction
        {
            // Null should be interpreted as omitted for these properties
            AddTags = null,
            RemoveTags = null,
            SetMetadata = null,
            UnsetMetadata = null,
        };

        Assert.Null(model.AddTags);
        Assert.False(model.RawData.ContainsKey("add_tags"));
        Assert.Null(model.RemoveTags);
        Assert.False(model.RawData.ContainsKey("remove_tags"));
        Assert.Null(model.SetMetadata);
        Assert.False(model.RawData.ContainsKey("set_metadata"));
        Assert.Null(model.UnsetMetadata);
        Assert.False(model.RawData.ContainsKey("unset_metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AITaskAction
        {
            // Null should be interpreted as omitted for these properties
            AddTags = null,
            RemoveTags = null,
            SetMetadata = null,
            UnsetMetadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AITaskAction
        {
            AddTags = ["luxury", "premium"],
            RemoveTags = ["budget", "affordable"],
            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
            UnsetMetadata = [new("price_range")],
        };

        AITaskAction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetMetadata { Field = "field", Value = "string" };

        string expectedField = "field";
        SetMetadataValue expectedValue = "string";

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SetMetadata { Field = "field", Value = "string" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetMetadata { Field = "field", Value = "string" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedField = "field";
        SetMetadataValue expectedValue = "string";

        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SetMetadata { Field = "field", Value = "string" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SetMetadata { Field = "field", Value = "string" };

        SetMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetMetadataValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        SetMetadataValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        SetMetadataValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        SetMetadataValue value = true;
        value.Validate();
    }

    [Fact]
    public void MixedValidationWorks()
    {
        SetMetadataValue value = new([new MetadataValueItem("string")]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        SetMetadataValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetMetadataValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        SetMetadataValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetMetadataValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        SetMetadataValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetMetadataValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MixedSerializationRoundtripWorks()
    {
        SetMetadataValue value = new([new MetadataValueItem("string")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetMetadataValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MetadataValueItemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        MetadataValueItem value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        MetadataValueItem value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        MetadataValueItem value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MetadataValueItem value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetadataValueItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        MetadataValueItem value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetadataValueItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        MetadataValueItem value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetadataValueItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnsetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnsetMetadata { Field = "field" };

        string expectedField = "field";

        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnsetMetadata { Field = "field" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsetMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnsetMetadata { Field = "field" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsetMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedField = "field";

        Assert.Equal(expectedField, deserialized.Field);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnsetMetadata { Field = "field" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnsetMetadata { Field = "field" };

        UnsetMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
