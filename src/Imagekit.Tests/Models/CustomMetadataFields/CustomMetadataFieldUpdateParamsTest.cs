using System;
using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.CustomMetadataFields;

namespace Imagekit.Tests.Models.CustomMetadataFields;

public class CustomMetadataFieldUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomMetadataFieldUpdateParams
        {
            ID = "id",
            Label = "price",
            Schema = new()
            {
                DefaultValue = new(
                    [
                        new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(true),
                        new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(10),
                        new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(
                            "Hello"
                        ),
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

        string expectedID = "id";
        string expectedLabel = "price";
        CustomMetadataFieldUpdateParamsSchema expectedSchema = new()
        {
            DefaultValue = new(
                [
                    new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(true),
                    new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(10),
                    new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem("Hello"),
                ]
            ),
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = 3000,
            MinLength = 0,
            MinValue = 1000,
            SelectOptions = ["small", "medium", "large", 30, 40, true],
        };

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedLabel, parameters.Label);
        Assert.Equal(expectedSchema, parameters.Schema);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomMetadataFieldUpdateParams { ID = "id" };

        Assert.Null(parameters.Label);
        Assert.False(parameters.RawBodyData.ContainsKey("label"));
        Assert.Null(parameters.Schema);
        Assert.False(parameters.RawBodyData.ContainsKey("schema"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CustomMetadataFieldUpdateParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Label = null,
            Schema = null,
        };

        Assert.Null(parameters.Label);
        Assert.False(parameters.RawBodyData.ContainsKey("label"));
        Assert.Null(parameters.Schema);
        Assert.False(parameters.RawBodyData.ContainsKey("schema"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomMetadataFieldUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/customMetadataFields/id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomMetadataFieldUpdateParams
        {
            ID = "id",
            Label = "price",
            Schema = new()
            {
                DefaultValue = new(
                    [
                        new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(true),
                        new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(10),
                        new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(
                            "Hello"
                        ),
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

        CustomMetadataFieldUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CustomMetadataFieldUpdateParamsSchemaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomMetadataFieldUpdateParamsSchema
        {
            DefaultValue = new(
                [
                    new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(true),
                    new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(10),
                    new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem("Hello"),
                ]
            ),
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = "string",
            MinLength = 0,
            MinValue = "string",
            SelectOptions = ["small", "medium", "large", 30, 40, true],
        };

        CustomMetadataFieldUpdateParamsSchemaDefaultValue expectedDefaultValue = new(
            [
                new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(true),
                new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(10),
                new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem("Hello"),
            ]
        );
        bool expectedIsValueRequired = true;
        double expectedMaxLength = 0;
        CustomMetadataFieldUpdateParamsSchemaMaxValue expectedMaxValue = "string";
        double expectedMinLength = 0;
        CustomMetadataFieldUpdateParamsSchemaMinValue expectedMinValue = "string";
        List<CustomMetadataFieldUpdateParamsSchemaSelectOption> expectedSelectOptions =
        [
            "small",
            "medium",
            "large",
            30,
            40,
            true,
        ];

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
        var model = new CustomMetadataFieldUpdateParamsSchema
        {
            DefaultValue = new(
                [
                    new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(true),
                    new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(10),
                    new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem("Hello"),
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
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFieldUpdateParamsSchema>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomMetadataFieldUpdateParamsSchema
        {
            DefaultValue = new(
                [
                    new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(true),
                    new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(10),
                    new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem("Hello"),
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
        var deserialized = JsonSerializer.Deserialize<CustomMetadataFieldUpdateParamsSchema>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CustomMetadataFieldUpdateParamsSchemaDefaultValue expectedDefaultValue = new(
            [
                new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(true),
                new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(10),
                new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem("Hello"),
            ]
        );
        bool expectedIsValueRequired = true;
        double expectedMaxLength = 0;
        CustomMetadataFieldUpdateParamsSchemaMaxValue expectedMaxValue = "string";
        double expectedMinLength = 0;
        CustomMetadataFieldUpdateParamsSchemaMinValue expectedMinValue = "string";
        List<CustomMetadataFieldUpdateParamsSchemaSelectOption> expectedSelectOptions =
        [
            "small",
            "medium",
            "large",
            30,
            40,
            true,
        ];

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
        var model = new CustomMetadataFieldUpdateParamsSchema
        {
            DefaultValue = new(
                [
                    new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(true),
                    new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(10),
                    new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem("Hello"),
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
        var model = new CustomMetadataFieldUpdateParamsSchema { };

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
        var model = new CustomMetadataFieldUpdateParamsSchema { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomMetadataFieldUpdateParamsSchema
        {
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
        var model = new CustomMetadataFieldUpdateParamsSchema
        {
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
        var model = new CustomMetadataFieldUpdateParamsSchema
        {
            DefaultValue = new(
                [
                    new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(true),
                    new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(10),
                    new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem("Hello"),
                ]
            ),
            IsValueRequired = true,
            MaxLength = 0,
            MaxValue = "string",
            MinLength = 0,
            MinValue = "string",
            SelectOptions = ["small", "medium", "large", 30, 40, true],
        };

        CustomMetadataFieldUpdateParamsSchema copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomMetadataFieldUpdateParamsSchemaDefaultValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaDefaultValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaDefaultValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaDefaultValue value = true;
        value.Validate();
    }

    [Fact]
    public void MixedValidationWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaDefaultValue value = new(
            [
                new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(true),
                new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(10),
                new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem("Hello"),
            ]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaDefaultValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CustomMetadataFieldUpdateParamsSchemaDefaultValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaDefaultValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CustomMetadataFieldUpdateParamsSchemaDefaultValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaDefaultValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CustomMetadataFieldUpdateParamsSchemaDefaultValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MixedSerializationRoundtripWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaDefaultValue value = new(
            [
                new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(true),
                new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem(10),
                new CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem("Hello"),
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CustomMetadataFieldUpdateParamsSchemaDefaultValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CustomMetadataFieldUpdateParamsSchemaDefaultValueDefaultValueItem>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class CustomMetadataFieldUpdateParamsSchemaMaxValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaMaxValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaMaxValue value = 0;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaMaxValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CustomMetadataFieldUpdateParamsSchemaMaxValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaMaxValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CustomMetadataFieldUpdateParamsSchemaMaxValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class CustomMetadataFieldUpdateParamsSchemaMinValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaMinValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaMinValue value = 0;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaMinValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CustomMetadataFieldUpdateParamsSchemaMinValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaMinValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CustomMetadataFieldUpdateParamsSchemaMinValue>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class CustomMetadataFieldUpdateParamsSchemaSelectOptionTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaSelectOption value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaSelectOption value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaSelectOption value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaSelectOption value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CustomMetadataFieldUpdateParamsSchemaSelectOption>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaSelectOption value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CustomMetadataFieldUpdateParamsSchemaSelectOption>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        CustomMetadataFieldUpdateParamsSchemaSelectOption value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CustomMetadataFieldUpdateParamsSchemaSelectOption>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
