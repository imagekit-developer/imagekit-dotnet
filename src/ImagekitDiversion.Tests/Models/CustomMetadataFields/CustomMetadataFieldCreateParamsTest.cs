using System;
using System.Collections.Generic;
using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using CustomMetadataFields = ImagekitDiversion.Models.CustomMetadataFields;

namespace ImagekitDiversion.Tests.Models.CustomMetadataFields;

public class CustomMetadataFieldCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomMetadataFields::CustomMetadataFieldCreateParams
        {
            Label = "price",
            Name = "price",
            Schema = new()
            {
                Type = CustomMetadataFields::Type.Number,
                DefaultValue = new(
                    [
                        new CustomMetadataFields::DefaultValueItem(true),
                        new CustomMetadataFields::DefaultValueItem(10),
                        new CustomMetadataFields::DefaultValueItem("Hello"),
                    ]
                ),
                IsValueRequired = true,
                MaxLength = 0,
                MaxValue = 3000,
                MinLength = 0,
                MinValue = 1000,
                SelectOptions = ["small", "medium", "large", 30, 40, true],
            },
        };

        string expectedLabel = "price";
        string expectedName = "price";
        CustomMetadataFields::Schema expectedSchema = new()
        {
            Type = CustomMetadataFields::Type.Number,
            DefaultValue = new(
                [
                    new CustomMetadataFields::DefaultValueItem(true),
                    new CustomMetadataFields::DefaultValueItem(10),
                    new CustomMetadataFields::DefaultValueItem("Hello"),
                ]
            ),
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = 3000,
            MinLength = 0,
            MinValue = 1000,
            SelectOptions = ["small", "medium", "large", 30, 40, true],
        };

        Assert.Equal(expectedLabel, parameters.Label);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedSchema, parameters.Schema);
    }

    [Fact]
    public void Url_Works()
    {
        CustomMetadataFields::CustomMetadataFieldCreateParams parameters = new()
        {
            Label = "price",
            Name = "price",
            Schema = new()
            {
                Type = CustomMetadataFields::Type.Number,
                DefaultValue = new(
                    [
                        new CustomMetadataFields::DefaultValueItem(true),
                        new CustomMetadataFields::DefaultValueItem(10),
                        new CustomMetadataFields::DefaultValueItem("Hello"),
                    ]
                ),
                IsValueRequired = true,
                MaxLength = 0,
                MaxValue = 3000,
                MinLength = 0,
                MinValue = 1000,
                SelectOptions = ["small", "medium", "large", 30, 40, true],
            },
        };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/customMetadataFields"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomMetadataFields::CustomMetadataFieldCreateParams
        {
            Label = "price",
            Name = "price",
            Schema = new()
            {
                Type = CustomMetadataFields::Type.Number,
                DefaultValue = new(
                    [
                        new CustomMetadataFields::DefaultValueItem(true),
                        new CustomMetadataFields::DefaultValueItem(10),
                        new CustomMetadataFields::DefaultValueItem("Hello"),
                    ]
                ),
                IsValueRequired = true,
                MaxLength = 0,
                MaxValue = 3000,
                MinLength = 0,
                MinValue = 1000,
                SelectOptions = ["small", "medium", "large", 30, 40, true],
            },
        };

        CustomMetadataFields::CustomMetadataFieldCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SchemaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomMetadataFields::Schema
        {
            Type = CustomMetadataFields::Type.Text,
            DefaultValue = new(
                [
                    new CustomMetadataFields::DefaultValueItem(true),
                    new CustomMetadataFields::DefaultValueItem(10),
                    new CustomMetadataFields::DefaultValueItem("Hello"),
                ]
            ),
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = "string",
            MinLength = 0,
            MinValue = "string",
            SelectOptions = ["small", "medium", "large", 30, 40, true],
        };

        ApiEnum<string, CustomMetadataFields::Type> expectedType = CustomMetadataFields::Type.Text;
        CustomMetadataFields::DefaultValue expectedDefaultValue = new(
            [
                new CustomMetadataFields::DefaultValueItem(true),
                new CustomMetadataFields::DefaultValueItem(10),
                new CustomMetadataFields::DefaultValueItem("Hello"),
            ]
        );
        bool expectedIsValueRequired = true;
        double expectedMaxLength = 0;
        CustomMetadataFields::MaxValue expectedMaxValue = "string";
        double expectedMinLength = 0;
        CustomMetadataFields::MinValue expectedMinValue = "string";
        List<CustomMetadataFields::SelectOption> expectedSelectOptions =
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
        var model = new CustomMetadataFields::Schema
        {
            Type = CustomMetadataFields::Type.Text,
            DefaultValue = new(
                [
                    new CustomMetadataFields::DefaultValueItem(true),
                    new CustomMetadataFields::DefaultValueItem(10),
                    new CustomMetadataFields::DefaultValueItem("Hello"),
                ]
            ),
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = "string",
            MinLength = 0,
            MinValue = "string",
            SelectOptions = ["small", "medium", "large", 30, 40, true],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFields::Schema>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomMetadataFields::Schema
        {
            Type = CustomMetadataFields::Type.Text,
            DefaultValue = new(
                [
                    new CustomMetadataFields::DefaultValueItem(true),
                    new CustomMetadataFields::DefaultValueItem(10),
                    new CustomMetadataFields::DefaultValueItem("Hello"),
                ]
            ),
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = "string",
            MinLength = 0,
            MinValue = "string",
            SelectOptions = ["small", "medium", "large", 30, 40, true],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFields::Schema>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CustomMetadataFields::Type> expectedType = CustomMetadataFields::Type.Text;
        CustomMetadataFields::DefaultValue expectedDefaultValue = new(
            [
                new CustomMetadataFields::DefaultValueItem(true),
                new CustomMetadataFields::DefaultValueItem(10),
                new CustomMetadataFields::DefaultValueItem("Hello"),
            ]
        );
        bool expectedIsValueRequired = true;
        double expectedMaxLength = 0;
        CustomMetadataFields::MaxValue expectedMaxValue = "string";
        double expectedMinLength = 0;
        CustomMetadataFields::MinValue expectedMinValue = "string";
        List<CustomMetadataFields::SelectOption> expectedSelectOptions =
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
        var model = new CustomMetadataFields::Schema
        {
            Type = CustomMetadataFields::Type.Text,
            DefaultValue = new(
                [
                    new CustomMetadataFields::DefaultValueItem(true),
                    new CustomMetadataFields::DefaultValueItem(10),
                    new CustomMetadataFields::DefaultValueItem("Hello"),
                ]
            ),
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
        var model = new CustomMetadataFields::Schema { Type = CustomMetadataFields::Type.Text };

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
        var model = new CustomMetadataFields::Schema { Type = CustomMetadataFields::Type.Text };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomMetadataFields::Schema
        {
            Type = CustomMetadataFields::Type.Text,

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
        var model = new CustomMetadataFields::Schema
        {
            Type = CustomMetadataFields::Type.Text,

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
        var model = new CustomMetadataFields::Schema
        {
            Type = CustomMetadataFields::Type.Text,
            DefaultValue = new(
                [
                    new CustomMetadataFields::DefaultValueItem(true),
                    new CustomMetadataFields::DefaultValueItem(10),
                    new CustomMetadataFields::DefaultValueItem("Hello"),
                ]
            ),
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = "string",
            MinLength = 0,
            MinValue = "string",
            SelectOptions = ["small", "medium", "large", 30, 40, true],
        };

        CustomMetadataFields::Schema copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(CustomMetadataFields::Type.Text)]
    [InlineData(CustomMetadataFields::Type.Textarea)]
    [InlineData(CustomMetadataFields::Type.Number)]
    [InlineData(CustomMetadataFields::Type.Date)]
    [InlineData(CustomMetadataFields::Type.Boolean)]
    [InlineData(CustomMetadataFields::Type.SingleSelect)]
    [InlineData(CustomMetadataFields::Type.MultiSelect)]
    public void Validation_Works(CustomMetadataFields::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomMetadataFields::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CustomMetadataFields::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomMetadataFields::Type.Text)]
    [InlineData(CustomMetadataFields::Type.Textarea)]
    [InlineData(CustomMetadataFields::Type.Number)]
    [InlineData(CustomMetadataFields::Type.Date)]
    [InlineData(CustomMetadataFields::Type.Boolean)]
    [InlineData(CustomMetadataFields::Type.SingleSelect)]
    [InlineData(CustomMetadataFields::Type.MultiSelect)]
    public void SerializationRoundtrip_Works(CustomMetadataFields::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomMetadataFields::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CustomMetadataFields::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CustomMetadataFields::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CustomMetadataFields::Type>>(
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
        CustomMetadataFields::DefaultValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        CustomMetadataFields::DefaultValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        CustomMetadataFields::DefaultValue value = true;
        value.Validate();
    }

    [Fact]
    public void MixedValidationWorks()
    {
        CustomMetadataFields::DefaultValue value = new(
            [
                new CustomMetadataFields::DefaultValueItem(true),
                new CustomMetadataFields::DefaultValueItem(10),
                new CustomMetadataFields::DefaultValueItem("Hello"),
            ]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CustomMetadataFields::DefaultValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFields::DefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        CustomMetadataFields::DefaultValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFields::DefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        CustomMetadataFields::DefaultValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFields::DefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MixedSerializationRoundtripWorks()
    {
        CustomMetadataFields::DefaultValue value = new(
            [
                new CustomMetadataFields::DefaultValueItem(true),
                new CustomMetadataFields::DefaultValueItem(10),
                new CustomMetadataFields::DefaultValueItem("Hello"),
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFields::DefaultValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DefaultValueItemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        CustomMetadataFields::DefaultValueItem value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        CustomMetadataFields::DefaultValueItem value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        CustomMetadataFields::DefaultValueItem value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CustomMetadataFields::DefaultValueItem value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFields::DefaultValueItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        CustomMetadataFields::DefaultValueItem value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFields::DefaultValueItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        CustomMetadataFields::DefaultValueItem value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFields::DefaultValueItem>(
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
        CustomMetadataFields::MaxValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        CustomMetadataFields::MaxValue value = 0;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CustomMetadataFields::MaxValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFields::MaxValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        CustomMetadataFields::MaxValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFields::MaxValue>(
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
        CustomMetadataFields::MinValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        CustomMetadataFields::MinValue value = 0;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CustomMetadataFields::MinValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFields::MinValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        CustomMetadataFields::MinValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFields::MinValue>(
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
        CustomMetadataFields::SelectOption value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        CustomMetadataFields::SelectOption value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        CustomMetadataFields::SelectOption value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CustomMetadataFields::SelectOption value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFields::SelectOption>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        CustomMetadataFields::SelectOption value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFields::SelectOption>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        CustomMetadataFields::SelectOption value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFields::SelectOption>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
