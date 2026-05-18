using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models;

namespace Imagekit.Tests.Models;

public class SelectedFieldsSchemaItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SelectedFieldsSchemaItem
        {
            Type = Type.Text,
            DefaultValue = new(
                [
                    new DefaultValueArrayItem(true),
                    new DefaultValueArrayItem(10),
                    new DefaultValueArrayItem("Hello"),
                ]
            ),
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = "string",
            MinLength = 0,
            MinValue = "string",
            ReadOnly = true,
            SelectOptions = ["small", "medium", "large", 30, 40, true],
            SelectOptionsTruncated = true,
        };

        ApiEnum<string, Type> expectedType = Type.Text;
        DefaultValue expectedDefaultValue = new(
            [
                new DefaultValueArrayItem(true),
                new DefaultValueArrayItem(10),
                new DefaultValueArrayItem("Hello"),
            ]
        );
        bool expectedIsValueRequired = true;
        double expectedMaxLength = 0;
        MaxValue expectedMaxValue = "string";
        double expectedMinLength = 0;
        MinValue expectedMinValue = "string";
        bool expectedReadOnly = true;
        List<SelectOption> expectedSelectOptions = ["small", "medium", "large", 30, 40, true];
        bool expectedSelectOptionsTruncated = true;

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedDefaultValue, model.DefaultValue);
        Assert.Equal(expectedIsValueRequired, model.IsValueRequired);
        Assert.Equal(expectedMaxLength, model.MaxLength);
        Assert.Equal(expectedMaxValue, model.MaxValue);
        Assert.Equal(expectedMinLength, model.MinLength);
        Assert.Equal(expectedMinValue, model.MinValue);
        Assert.Equal(expectedReadOnly, model.ReadOnly);
        Assert.NotNull(model.SelectOptions);
        Assert.Equal(expectedSelectOptions.Count, model.SelectOptions.Count);
        for (int i = 0; i < expectedSelectOptions.Count; i++)
        {
            Assert.Equal(expectedSelectOptions[i], model.SelectOptions[i]);
        }
        Assert.Equal(expectedSelectOptionsTruncated, model.SelectOptionsTruncated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SelectedFieldsSchemaItem
        {
            Type = Type.Text,
            DefaultValue = new(
                [
                    new DefaultValueArrayItem(true),
                    new DefaultValueArrayItem(10),
                    new DefaultValueArrayItem("Hello"),
                ]
            ),
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = "string",
            MinLength = 0,
            MinValue = "string",
            ReadOnly = true,
            SelectOptions = ["small", "medium", "large", 30, 40, true],
            SelectOptionsTruncated = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SelectedFieldsSchemaItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SelectedFieldsSchemaItem
        {
            Type = Type.Text,
            DefaultValue = new(
                [
                    new DefaultValueArrayItem(true),
                    new DefaultValueArrayItem(10),
                    new DefaultValueArrayItem("Hello"),
                ]
            ),
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = "string",
            MinLength = 0,
            MinValue = "string",
            ReadOnly = true,
            SelectOptions = ["small", "medium", "large", 30, 40, true],
            SelectOptionsTruncated = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SelectedFieldsSchemaItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Type> expectedType = Type.Text;
        DefaultValue expectedDefaultValue = new(
            [
                new DefaultValueArrayItem(true),
                new DefaultValueArrayItem(10),
                new DefaultValueArrayItem("Hello"),
            ]
        );
        bool expectedIsValueRequired = true;
        double expectedMaxLength = 0;
        MaxValue expectedMaxValue = "string";
        double expectedMinLength = 0;
        MinValue expectedMinValue = "string";
        bool expectedReadOnly = true;
        List<SelectOption> expectedSelectOptions = ["small", "medium", "large", 30, 40, true];
        bool expectedSelectOptionsTruncated = true;

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedDefaultValue, deserialized.DefaultValue);
        Assert.Equal(expectedIsValueRequired, deserialized.IsValueRequired);
        Assert.Equal(expectedMaxLength, deserialized.MaxLength);
        Assert.Equal(expectedMaxValue, deserialized.MaxValue);
        Assert.Equal(expectedMinLength, deserialized.MinLength);
        Assert.Equal(expectedMinValue, deserialized.MinValue);
        Assert.Equal(expectedReadOnly, deserialized.ReadOnly);
        Assert.NotNull(deserialized.SelectOptions);
        Assert.Equal(expectedSelectOptions.Count, deserialized.SelectOptions.Count);
        for (int i = 0; i < expectedSelectOptions.Count; i++)
        {
            Assert.Equal(expectedSelectOptions[i], deserialized.SelectOptions[i]);
        }
        Assert.Equal(expectedSelectOptionsTruncated, deserialized.SelectOptionsTruncated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SelectedFieldsSchemaItem
        {
            Type = Type.Text,
            DefaultValue = new(
                [
                    new DefaultValueArrayItem(true),
                    new DefaultValueArrayItem(10),
                    new DefaultValueArrayItem("Hello"),
                ]
            ),
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = "string",
            MinLength = 0,
            MinValue = "string",
            ReadOnly = true,
            SelectOptions = ["small", "medium", "large", 30, 40, true],
            SelectOptionsTruncated = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SelectedFieldsSchemaItem { Type = Type.Text };

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
        Assert.Null(model.ReadOnly);
        Assert.False(model.RawData.ContainsKey("readOnly"));
        Assert.Null(model.SelectOptions);
        Assert.False(model.RawData.ContainsKey("selectOptions"));
        Assert.Null(model.SelectOptionsTruncated);
        Assert.False(model.RawData.ContainsKey("selectOptionsTruncated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SelectedFieldsSchemaItem { Type = Type.Text };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SelectedFieldsSchemaItem
        {
            Type = Type.Text,

            // Null should be interpreted as omitted for these properties
            DefaultValue = null,
            IsValueRequired = null,
            MaxLength = null,
            MaxValue = null,
            MinLength = null,
            MinValue = null,
            ReadOnly = null,
            SelectOptions = null,
            SelectOptionsTruncated = null,
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
        Assert.Null(model.ReadOnly);
        Assert.False(model.RawData.ContainsKey("readOnly"));
        Assert.Null(model.SelectOptions);
        Assert.False(model.RawData.ContainsKey("selectOptions"));
        Assert.Null(model.SelectOptionsTruncated);
        Assert.False(model.RawData.ContainsKey("selectOptionsTruncated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SelectedFieldsSchemaItem
        {
            Type = Type.Text,

            // Null should be interpreted as omitted for these properties
            DefaultValue = null,
            IsValueRequired = null,
            MaxLength = null,
            MaxValue = null,
            MinLength = null,
            MinValue = null,
            ReadOnly = null,
            SelectOptions = null,
            SelectOptionsTruncated = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SelectedFieldsSchemaItem
        {
            Type = Type.Text,
            DefaultValue = new(
                [
                    new DefaultValueArrayItem(true),
                    new DefaultValueArrayItem(10),
                    new DefaultValueArrayItem("Hello"),
                ]
            ),
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = "string",
            MinLength = 0,
            MinValue = "string",
            ReadOnly = true,
            SelectOptions = ["small", "medium", "large", 30, 40, true],
            SelectOptionsTruncated = true,
        };

        SelectedFieldsSchemaItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.Text)]
    [InlineData(Type.Textarea)]
    [InlineData(Type.Number)]
    [InlineData(Type.Date)]
    [InlineData(Type.Boolean)]
    [InlineData(Type.SingleSelect)]
    [InlineData(Type.MultiSelect)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.Text)]
    [InlineData(Type.Textarea)]
    [InlineData(Type.Number)]
    [InlineData(Type.Date)]
    [InlineData(Type.Boolean)]
    [InlineData(Type.SingleSelect)]
    [InlineData(Type.MultiSelect)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DefaultValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        DefaultValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        DefaultValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        DefaultValue value = true;
        value.Validate();
    }

    [Fact]
    public void MixedValidationWorks()
    {
        DefaultValue value = new(
            [
                new DefaultValueArrayItem(true),
                new DefaultValueArrayItem(10),
                new DefaultValueArrayItem("Hello"),
            ]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        DefaultValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        DefaultValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        DefaultValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MixedSerializationRoundtripWorks()
    {
        DefaultValue value = new(
            [
                new DefaultValueArrayItem(true),
                new DefaultValueArrayItem(10),
                new DefaultValueArrayItem("Hello"),
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DefaultValueArrayItemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        DefaultValueArrayItem value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        DefaultValueArrayItem value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        DefaultValueArrayItem value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        DefaultValueArrayItem value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DefaultValueArrayItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        DefaultValueArrayItem value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DefaultValueArrayItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        DefaultValueArrayItem value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DefaultValueArrayItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MaxValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        MaxValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        MaxValue value = 0;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MaxValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MaxValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        MaxValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MaxValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MinValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        MinValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        MinValue value = 0;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MinValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MinValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        MinValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MinValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SelectOptionTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        SelectOption value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        SelectOption value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        SelectOption value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        SelectOption value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SelectOption>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        SelectOption value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SelectOption>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        SelectOption value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SelectOption>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
