using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Dummy;

namespace ImagekitDiversion.Tests.Models.Dummy;

public class OverlayTimingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OverlayTiming
        {
            Duration = 0,
            End = 0,
            Start = 0,
        };

        Duration expectedDuration = 0;
        End expectedEnd = 0;
        Start expectedStart = 0;

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedEnd, model.End);
        Assert.Equal(expectedStart, model.Start);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OverlayTiming
        {
            Duration = 0,
            End = 0,
            Start = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OverlayTiming>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OverlayTiming
        {
            Duration = 0,
            End = 0,
            Start = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OverlayTiming>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Duration expectedDuration = 0;
        End expectedEnd = 0;
        Start expectedStart = 0;

        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedEnd, deserialized.End);
        Assert.Equal(expectedStart, deserialized.Start);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OverlayTiming
        {
            Duration = 0,
            End = 0,
            Start = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OverlayTiming { };

        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.End);
        Assert.False(model.RawData.ContainsKey("end"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OverlayTiming { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OverlayTiming
        {
            // Null should be interpreted as omitted for these properties
            Duration = null,
            End = null,
            Start = null,
        };

        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.End);
        Assert.False(model.RawData.ContainsKey("end"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OverlayTiming
        {
            // Null should be interpreted as omitted for these properties
            Duration = null,
            End = null,
            Start = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OverlayTiming
        {
            Duration = 0,
            End = 0,
            Start = 0,
        };

        OverlayTiming copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DurationTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        Duration value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Duration value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Duration value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Duration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Duration value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Duration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EndTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        End value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        End value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        End value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<End>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        End value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<End>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StartTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        Start value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Start value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Start value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Start>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Start value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Start>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
