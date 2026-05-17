using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models;

namespace Imagekit.Tests.Models;

public class SolidColorOverlayTransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SolidColorOverlayTransformation
        {
            Alpha = 1,
            Background = "background",
            Gradient = new Default(),
            Height = 0,
            Radius = new Max(),
            Width = 0,
        };

        double expectedAlpha = 1;
        string expectedBackground = "background";
        Gradient expectedGradient = new Default();
        Height expectedHeight = 0;
        Radius expectedRadius = new Max();
        Width expectedWidth = 0;

        Assert.Equal(expectedAlpha, model.Alpha);
        Assert.Equal(expectedBackground, model.Background);
        Assert.Equal(expectedGradient, model.Gradient);
        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedRadius, model.Radius);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SolidColorOverlayTransformation
        {
            Alpha = 1,
            Background = "background",
            Gradient = new Default(),
            Height = 0,
            Radius = new Max(),
            Width = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SolidColorOverlayTransformation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SolidColorOverlayTransformation
        {
            Alpha = 1,
            Background = "background",
            Gradient = new Default(),
            Height = 0,
            Radius = new Max(),
            Width = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SolidColorOverlayTransformation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAlpha = 1;
        string expectedBackground = "background";
        Gradient expectedGradient = new Default();
        Height expectedHeight = 0;
        Radius expectedRadius = new Max();
        Width expectedWidth = 0;

        Assert.Equal(expectedAlpha, deserialized.Alpha);
        Assert.Equal(expectedBackground, deserialized.Background);
        Assert.Equal(expectedGradient, deserialized.Gradient);
        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedRadius, deserialized.Radius);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SolidColorOverlayTransformation
        {
            Alpha = 1,
            Background = "background",
            Gradient = new Default(),
            Height = 0,
            Radius = new Max(),
            Width = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SolidColorOverlayTransformation { };

        Assert.Null(model.Alpha);
        Assert.False(model.RawData.ContainsKey("alpha"));
        Assert.Null(model.Background);
        Assert.False(model.RawData.ContainsKey("background"));
        Assert.Null(model.Gradient);
        Assert.False(model.RawData.ContainsKey("gradient"));
        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.Radius);
        Assert.False(model.RawData.ContainsKey("radius"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SolidColorOverlayTransformation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SolidColorOverlayTransformation
        {
            // Null should be interpreted as omitted for these properties
            Alpha = null,
            Background = null,
            Gradient = null,
            Height = null,
            Radius = null,
            Width = null,
        };

        Assert.Null(model.Alpha);
        Assert.False(model.RawData.ContainsKey("alpha"));
        Assert.Null(model.Background);
        Assert.False(model.RawData.ContainsKey("background"));
        Assert.Null(model.Gradient);
        Assert.False(model.RawData.ContainsKey("gradient"));
        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.Radius);
        Assert.False(model.RawData.ContainsKey("radius"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SolidColorOverlayTransformation
        {
            // Null should be interpreted as omitted for these properties
            Alpha = null,
            Background = null,
            Gradient = null,
            Height = null,
            Radius = null,
            Width = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SolidColorOverlayTransformation
        {
            Alpha = 1,
            Background = "background",
            Gradient = new Default(),
            Height = 0,
            Radius = new Max(),
            Width = 0,
        };

        SolidColorOverlayTransformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GradientTest : TestBase
{
    [Fact]
    public void DefaultValidationWorks()
    {
        Gradient value = new Default();
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Gradient value = "string";
        value.Validate();
    }

    [Fact]
    public void DefaultSerializationRoundtripWorks()
    {
        Gradient value = new Default();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Gradient>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Gradient value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Gradient>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DefaultTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new Default();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<Default>(
            JsonSerializer.SerializeToElement(true),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<Default>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new Default();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Default>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Default>(
            JsonSerializer.SerializeToElement(true),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Default>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Default>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Default>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class HeightTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        Height value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Height value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Height value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Height>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Height value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Height>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RadiusTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        Radius value = 0;
        value.Validate();
    }

    [Fact]
    public void MaxValidationWorks()
    {
        Radius value = new Max();
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Radius value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Radius value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Radius>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MaxSerializationRoundtripWorks()
    {
        Radius value = new Max();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Radius>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Radius value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Radius>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MaxTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new Max();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<Max>(
            JsonSerializer.SerializeToElement("max"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<Max>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new Max();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Max>(element, ModelBase.SerializerOptions);

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Max>(
            JsonSerializer.SerializeToElement("max"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Max>(element, ModelBase.SerializerOptions);

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Max>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Max>(element, ModelBase.SerializerOptions);

        Assert.Equal(constant, deserialized);
    }
}

public class WidthTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        Width value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Width value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Width value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Width>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Width value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Width>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
