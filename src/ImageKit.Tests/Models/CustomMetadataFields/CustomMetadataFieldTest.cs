using System.Collections.Generic;
using System.Text.Json;
using ImageKit.Core;
using ImageKit.Exceptions;
using ImageKit.Models.CustomMetadataFields;

namespace ImageKit.Tests.Models.CustomMetadataFields;

public class CustomMetadataFieldTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomMetadataField
        {
            ID = "id",
            Label = "label",
            Name = "name",
            Schema = new()
            {
                Type = CustomMetadataFieldSchemaType.Text,
                DefaultValue = "string",
                IsValueRequired = true,
                MaxLength = 0,
                MaxValue = "string",
                MinLength = 0,
                MinValue = "string",
                SelectOptions = ["small", "medium", "large", 30, 40, true],
            },
        };

        string expectedID = "id";
        string expectedLabel = "label";
        string expectedName = "name";
        CustomMetadataFieldSchema expectedSchema = new()
        {
            Type = CustomMetadataFieldSchemaType.Text,
            DefaultValue = "string",
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = "string",
            MinLength = 0,
            MinValue = "string",
            SelectOptions = ["small", "medium", "large", 30, 40, true],
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedLabel, model.Label);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSchema, model.Schema);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomMetadataField
        {
            ID = "id",
            Label = "label",
            Name = "name",
            Schema = new()
            {
                Type = CustomMetadataFieldSchemaType.Text,
                DefaultValue = "string",
                IsValueRequired = true,
                MaxLength = 0,
                MaxValue = "string",
                MinLength = 0,
                MinValue = "string",
                SelectOptions = ["small", "medium", "large", 30, 40, true],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataField>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomMetadataField
        {
            ID = "id",
            Label = "label",
            Name = "name",
            Schema = new()
            {
                Type = CustomMetadataFieldSchemaType.Text,
                DefaultValue = "string",
                IsValueRequired = true,
                MaxLength = 0,
                MaxValue = "string",
                MinLength = 0,
                MinValue = "string",
                SelectOptions = ["small", "medium", "large", 30, 40, true],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataField>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedLabel = "label";
        string expectedName = "name";
        CustomMetadataFieldSchema expectedSchema = new()
        {
            Type = CustomMetadataFieldSchemaType.Text,
            DefaultValue = "string",
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = "string",
            MinLength = 0,
            MinValue = "string",
            SelectOptions = ["small", "medium", "large", 30, 40, true],
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedLabel, deserialized.Label);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSchema, deserialized.Schema);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomMetadataField
        {
            ID = "id",
            Label = "label",
            Name = "name",
            Schema = new()
            {
                Type = CustomMetadataFieldSchemaType.Text,
                DefaultValue = "string",
                IsValueRequired = true,
                MaxLength = 0,
                MaxValue = "string",
                MinLength = 0,
                MinValue = "string",
                SelectOptions = ["small", "medium", "large", 30, 40, true],
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomMetadataField
        {
            ID = "id",
            Label = "label",
            Name = "name",
            Schema = new()
            {
                Type = CustomMetadataFieldSchemaType.Text,
                DefaultValue = "string",
                IsValueRequired = true,
                MaxLength = 0,
                MaxValue = "string",
                MinLength = 0,
                MinValue = "string",
                SelectOptions = ["small", "medium", "large", 30, 40, true],
            },
        };

        CustomMetadataField copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomMetadataFieldSchemaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomMetadataFieldSchema
        {
            Type = CustomMetadataFieldSchemaType.Text,
            DefaultValue = "string",
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = "string",
            MinLength = 0,
            MinValue = "string",
            SelectOptions = ["small", "medium", "large", 30, 40, true],
        };

        ApiEnum<string, CustomMetadataFieldSchemaType> expectedType =
            CustomMetadataFieldSchemaType.Text;
        CustomMetadataFieldSchemaDefaultValue expectedDefaultValue = "string";
        bool expectedIsValueRequired = true;
        double expectedMaxLength = 0;
        CustomMetadataFieldSchemaMaxValue expectedMaxValue = "string";
        double expectedMinLength = 0;
        CustomMetadataFieldSchemaMinValue expectedMinValue = "string";
        List<CustomMetadataFieldSchemaSelectOption> expectedSelectOptions =
        [
            "small",
            "medium",
            "large",
            30,
            40,
            true,
        ];

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedDefaultValue, model.DefaultValue);
        Assert.Equal(expectedIsValueRequired, model.IsValueRequired);
        Assert.Equal(expectedMaxLength, model.MaxLength);
        Assert.Equal(expectedMaxValue, model.MaxValue);
        Assert.Equal(expectedMinLength, model.MinLength);
        Assert.Equal(expectedMinValue, model.MinValue);
        Assert.NotNull(model.SelectOptions);
        Assert.Equal(expectedSelectOptions.Count, model.SelectOptions.Count);
        for (int i = 0; i < expectedSelectOptions.Count; i++)
        {
            Assert.Equal(expectedSelectOptions[i], model.SelectOptions[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomMetadataFieldSchema
        {
            Type = CustomMetadataFieldSchemaType.Text,
            DefaultValue = "string",
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = "string",
            MinLength = 0,
            MinValue = "string",
            SelectOptions = ["small", "medium", "large", 30, 40, true],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFieldSchema>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomMetadataFieldSchema
        {
            Type = CustomMetadataFieldSchemaType.Text,
            DefaultValue = "string",
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = "string",
            MinLength = 0,
            MinValue = "string",
            SelectOptions = ["small", "medium", "large", 30, 40, true],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFieldSchema>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CustomMetadataFieldSchemaType> expectedType =
            CustomMetadataFieldSchemaType.Text;
        CustomMetadataFieldSchemaDefaultValue expectedDefaultValue = "string";
        bool expectedIsValueRequired = true;
        double expectedMaxLength = 0;
        CustomMetadataFieldSchemaMaxValue expectedMaxValue = "string";
        double expectedMinLength = 0;
        CustomMetadataFieldSchemaMinValue expectedMinValue = "string";
        List<CustomMetadataFieldSchemaSelectOption> expectedSelectOptions =
        [
            "small",
            "medium",
            "large",
            30,
            40,
            true,
        ];

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedDefaultValue, deserialized.DefaultValue);
        Assert.Equal(expectedIsValueRequired, deserialized.IsValueRequired);
        Assert.Equal(expectedMaxLength, deserialized.MaxLength);
        Assert.Equal(expectedMaxValue, deserialized.MaxValue);
        Assert.Equal(expectedMinLength, deserialized.MinLength);
        Assert.Equal(expectedMinValue, deserialized.MinValue);
        Assert.NotNull(deserialized.SelectOptions);
        Assert.Equal(expectedSelectOptions.Count, deserialized.SelectOptions.Count);
        for (int i = 0; i < expectedSelectOptions.Count; i++)
        {
            Assert.Equal(expectedSelectOptions[i], deserialized.SelectOptions[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomMetadataFieldSchema
        {
            Type = CustomMetadataFieldSchemaType.Text,
            DefaultValue = "string",
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = "string",
            MinLength = 0,
            MinValue = "string",
            SelectOptions = ["small", "medium", "large", 30, 40, true],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomMetadataFieldSchema { Type = CustomMetadataFieldSchemaType.Text };

        Assert.Null(model.DefaultValue);
        Assert.False(model.RawData.ContainsKey("defaultValue"));
        Assert.Null(model.IsValueRequired);
        Assert.False(model.RawData.ContainsKey("isValueRequired"));
        Assert.Null(model.MaxLength);
        Assert.False(model.RawData.ContainsKey("maxLength"));
        Assert.Null(model.MaxValue);
        Assert.False(model.RawData.ContainsKey("maxValue"));
        Assert.Null(model.MinLength);
        Assert.False(model.RawData.ContainsKey("minLength"));
        Assert.Null(model.MinValue);
        Assert.False(model.RawData.ContainsKey("minValue"));
        Assert.Null(model.SelectOptions);
        Assert.False(model.RawData.ContainsKey("selectOptions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomMetadataFieldSchema { Type = CustomMetadataFieldSchemaType.Text };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomMetadataFieldSchema
        {
            Type = CustomMetadataFieldSchemaType.Text,

            // Null should be interpreted as omitted for these properties
            DefaultValue = null,
            IsValueRequired = null,
            MaxLength = null,
            MaxValue = null,
            MinLength = null,
            MinValue = null,
            SelectOptions = null,
        };

        Assert.Null(model.DefaultValue);
        Assert.False(model.RawData.ContainsKey("defaultValue"));
        Assert.Null(model.IsValueRequired);
        Assert.False(model.RawData.ContainsKey("isValueRequired"));
        Assert.Null(model.MaxLength);
        Assert.False(model.RawData.ContainsKey("maxLength"));
        Assert.Null(model.MaxValue);
        Assert.False(model.RawData.ContainsKey("maxValue"));
        Assert.Null(model.MinLength);
        Assert.False(model.RawData.ContainsKey("minLength"));
        Assert.Null(model.MinValue);
        Assert.False(model.RawData.ContainsKey("minValue"));
        Assert.Null(model.SelectOptions);
        Assert.False(model.RawData.ContainsKey("selectOptions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomMetadataFieldSchema
        {
            Type = CustomMetadataFieldSchemaType.Text,

            // Null should be interpreted as omitted for these properties
            DefaultValue = null,
            IsValueRequired = null,
            MaxLength = null,
            MaxValue = null,
            MinLength = null,
            MinValue = null,
            SelectOptions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomMetadataFieldSchema
        {
            Type = CustomMetadataFieldSchemaType.Text,
            DefaultValue = "string",
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = "string",
            MinLength = 0,
            MinValue = "string",
            SelectOptions = ["small", "medium", "large", 30, 40, true],
        };

        CustomMetadataFieldSchema copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomMetadataFieldSchemaTypeTest : TestBase
{
    [Theory]
    [InlineData(CustomMetadataFieldSchemaType.Text)]
    [InlineData(CustomMetadataFieldSchemaType.Textarea)]
    [InlineData(CustomMetadataFieldSchemaType.Number)]
    [InlineData(CustomMetadataFieldSchemaType.Date)]
    [InlineData(CustomMetadataFieldSchemaType.Boolean)]
    [InlineData(CustomMetadataFieldSchemaType.SingleSelect)]
    [InlineData(CustomMetadataFieldSchemaType.MultiSelect)]
    public void Validation_Works(CustomMetadataFieldSchemaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomMetadataFieldSchemaType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CustomMetadataFieldSchemaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomMetadataFieldSchemaType.Text)]
    [InlineData(CustomMetadataFieldSchemaType.Textarea)]
    [InlineData(CustomMetadataFieldSchemaType.Number)]
    [InlineData(CustomMetadataFieldSchemaType.Date)]
    [InlineData(CustomMetadataFieldSchemaType.Boolean)]
    [InlineData(CustomMetadataFieldSchemaType.SingleSelect)]
    [InlineData(CustomMetadataFieldSchemaType.MultiSelect)]
    public void SerializationRoundtrip_Works(CustomMetadataFieldSchemaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomMetadataFieldSchemaType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomMetadataFieldSchemaType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CustomMetadataFieldSchemaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomMetadataFieldSchemaType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CustomMetadataFieldSchemaDefaultValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        CustomMetadataFieldSchemaDefaultValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        CustomMetadataFieldSchemaDefaultValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        CustomMetadataFieldSchemaDefaultValue value = true;
        value.Validate();
    }

    [Fact]
    public void MixedValidationWorks()
    {
        CustomMetadataFieldSchemaDefaultValue value = new(
            [
                new UnnamedSchemaWithArrayParent9(true),
                new UnnamedSchemaWithArrayParent9(10),
                new UnnamedSchemaWithArrayParent9("Hello"),
            ]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CustomMetadataFieldSchemaDefaultValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFieldSchemaDefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        CustomMetadataFieldSchemaDefaultValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFieldSchemaDefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        CustomMetadataFieldSchemaDefaultValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFieldSchemaDefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MixedSerializationRoundtripWorks()
    {
        CustomMetadataFieldSchemaDefaultValue value = new(
            [
                new UnnamedSchemaWithArrayParent9(true),
                new UnnamedSchemaWithArrayParent9(10),
                new UnnamedSchemaWithArrayParent9("Hello"),
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFieldSchemaDefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnnamedSchemaWithArrayParent9Test : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        UnnamedSchemaWithArrayParent9 value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        UnnamedSchemaWithArrayParent9 value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        UnnamedSchemaWithArrayParent9 value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent9 value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent9>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent9 value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent9>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent9 value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent9>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CustomMetadataFieldSchemaMaxValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        CustomMetadataFieldSchemaMaxValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        CustomMetadataFieldSchemaMaxValue value = 0;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CustomMetadataFieldSchemaMaxValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFieldSchemaMaxValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        CustomMetadataFieldSchemaMaxValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFieldSchemaMaxValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CustomMetadataFieldSchemaMinValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        CustomMetadataFieldSchemaMinValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        CustomMetadataFieldSchemaMinValue value = 0;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CustomMetadataFieldSchemaMinValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFieldSchemaMinValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        CustomMetadataFieldSchemaMinValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFieldSchemaMinValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CustomMetadataFieldSchemaSelectOptionTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        CustomMetadataFieldSchemaSelectOption value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        CustomMetadataFieldSchemaSelectOption value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        CustomMetadataFieldSchemaSelectOption value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CustomMetadataFieldSchemaSelectOption value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFieldSchemaSelectOption>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        CustomMetadataFieldSchemaSelectOption value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFieldSchemaSelectOption>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        CustomMetadataFieldSchemaSelectOption value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFieldSchemaSelectOption>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
