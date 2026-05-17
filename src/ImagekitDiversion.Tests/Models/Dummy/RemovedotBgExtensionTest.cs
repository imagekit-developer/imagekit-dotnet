using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Dummy;

namespace ImagekitDiversion.Tests.Models.Dummy;

public class RemovedotBgExtensionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RemovedotBgExtension
        {
            Options = new()
            {
                AddShadow = true,
                BgColor = "bg_color",
                BgImageUrl = "bg_image_url",
                Semitransparency = true,
            },
        };

        JsonElement expectedName = JsonSerializer.SerializeToElement("remove-bg");
        Options expectedOptions = new()
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.Equal(expectedOptions, model.Options);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RemovedotBgExtension
        {
            Options = new()
            {
                AddShadow = true,
                BgColor = "bg_color",
                BgImageUrl = "bg_image_url",
                Semitransparency = true,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RemovedotBgExtension>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RemovedotBgExtension
        {
            Options = new()
            {
                AddShadow = true,
                BgColor = "bg_color",
                BgImageUrl = "bg_image_url",
                Semitransparency = true,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RemovedotBgExtension>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.SerializeToElement("remove-bg");
        Options expectedOptions = new()
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.Equal(expectedOptions, deserialized.Options);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RemovedotBgExtension
        {
            Options = new()
            {
                AddShadow = true,
                BgColor = "bg_color",
                BgImageUrl = "bg_image_url",
                Semitransparency = true,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RemovedotBgExtension { };

        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RemovedotBgExtension { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RemovedotBgExtension
        {
            // Null should be interpreted as omitted for these properties
            Options = null,
        };

        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RemovedotBgExtension
        {
            // Null should be interpreted as omitted for these properties
            Options = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RemovedotBgExtension
        {
            Options = new()
            {
                AddShadow = true,
                BgColor = "bg_color",
                BgImageUrl = "bg_image_url",
                Semitransparency = true,
            },
        };

        RemovedotBgExtension copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Options
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        bool expectedAddShadow = true;
        string expectedBgColor = "bg_color";
        string expectedBgImageUrl = "bg_image_url";
        bool expectedSemitransparency = true;

        Assert.Equal(expectedAddShadow, model.AddShadow);
        Assert.Equal(expectedBgColor, model.BgColor);
        Assert.Equal(expectedBgImageUrl, model.BgImageUrl);
        Assert.Equal(expectedSemitransparency, model.Semitransparency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Options
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Options>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Options
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Options>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAddShadow = true;
        string expectedBgColor = "bg_color";
        string expectedBgImageUrl = "bg_image_url";
        bool expectedSemitransparency = true;

        Assert.Equal(expectedAddShadow, deserialized.AddShadow);
        Assert.Equal(expectedBgColor, deserialized.BgColor);
        Assert.Equal(expectedBgImageUrl, deserialized.BgImageUrl);
        Assert.Equal(expectedSemitransparency, deserialized.Semitransparency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Options
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Options { };

        Assert.Null(model.AddShadow);
        Assert.False(model.RawData.ContainsKey("add_shadow"));
        Assert.Null(model.BgColor);
        Assert.False(model.RawData.ContainsKey("bg_color"));
        Assert.Null(model.BgImageUrl);
        Assert.False(model.RawData.ContainsKey("bg_image_url"));
        Assert.Null(model.Semitransparency);
        Assert.False(model.RawData.ContainsKey("semitransparency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Options { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Options
        {
            // Null should be interpreted as omitted for these properties
            AddShadow = null,
            BgColor = null,
            BgImageUrl = null,
            Semitransparency = null,
        };

        Assert.Null(model.AddShadow);
        Assert.False(model.RawData.ContainsKey("add_shadow"));
        Assert.Null(model.BgColor);
        Assert.False(model.RawData.ContainsKey("bg_color"));
        Assert.Null(model.BgImageUrl);
        Assert.False(model.RawData.ContainsKey("bg_image_url"));
        Assert.Null(model.Semitransparency);
        Assert.False(model.RawData.ContainsKey("semitransparency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Options
        {
            // Null should be interpreted as omitted for these properties
            AddShadow = null,
            BgColor = null,
            BgImageUrl = null,
            Semitransparency = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Options
        {
            AddShadow = true,
            BgColor = "bg_color",
            BgImageUrl = "bg_image_url",
            Semitransparency = true,
        };

        Options copied = new(model);

        Assert.Equal(model, copied);
    }
}
