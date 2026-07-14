using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Accounts.UsageAnalytics;

namespace Imagekit.Tests.Models.Accounts.UsageAnalytics;

public class RequestBandwidthEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RequestBandwidthEntry { BandwidthBytes = 0, RequestCount = 0 };

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedRequestCount, model.RequestCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RequestBandwidthEntry { BandwidthBytes = 0, RequestCount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RequestBandwidthEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RequestBandwidthEntry { BandwidthBytes = 0, RequestCount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RequestBandwidthEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBandwidthBytes = 0;
        double expectedRequestCount = 0;

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedRequestCount, deserialized.RequestCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RequestBandwidthEntry { BandwidthBytes = 0, RequestCount = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RequestBandwidthEntry { BandwidthBytes = 0, RequestCount = 0 };

        RequestBandwidthEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}
