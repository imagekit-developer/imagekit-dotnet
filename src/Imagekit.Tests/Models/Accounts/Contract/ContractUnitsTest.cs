using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Accounts.Contract;

namespace Imagekit.Tests.Models.Accounts.Contract;

public class ContractUnitsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractUnits
        {
            BandwidthBytes = 0,
            ExtensionUnitsCount = 0,
            PurgeCacheRequests = 0,
            VideoProcessingUnitsCount = 0,
        };

        long expectedBandwidthBytes = 0;
        long expectedExtensionUnitsCount = 0;
        long expectedPurgeCacheRequests = 0;
        long expectedVideoProcessingUnitsCount = 0;

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedExtensionUnitsCount, model.ExtensionUnitsCount);
        Assert.Equal(expectedPurgeCacheRequests, model.PurgeCacheRequests);
        Assert.Equal(expectedVideoProcessingUnitsCount, model.VideoProcessingUnitsCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContractUnits
        {
            BandwidthBytes = 0,
            ExtensionUnitsCount = 0,
            PurgeCacheRequests = 0,
            VideoProcessingUnitsCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractUnits>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractUnits
        {
            BandwidthBytes = 0,
            ExtensionUnitsCount = 0,
            PurgeCacheRequests = 0,
            VideoProcessingUnitsCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractUnits>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedBandwidthBytes = 0;
        long expectedExtensionUnitsCount = 0;
        long expectedPurgeCacheRequests = 0;
        long expectedVideoProcessingUnitsCount = 0;

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedExtensionUnitsCount, deserialized.ExtensionUnitsCount);
        Assert.Equal(expectedPurgeCacheRequests, deserialized.PurgeCacheRequests);
        Assert.Equal(expectedVideoProcessingUnitsCount, deserialized.VideoProcessingUnitsCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContractUnits
        {
            BandwidthBytes = 0,
            ExtensionUnitsCount = 0,
            PurgeCacheRequests = 0,
            VideoProcessingUnitsCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContractUnits
        {
            BandwidthBytes = 0,
            ExtensionUnitsCount = 0,
            PurgeCacheRequests = 0,
            VideoProcessingUnitsCount = 0,
        };

        ContractUnits copied = new(model);

        Assert.Equal(model, copied);
    }
}
