using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Accounts.Usage;

namespace Imagekit.Tests.Models.Accounts.Usage;

public class UsageGetResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageGetResponse
        {
            BandwidthBytes = 0,
            ExtensionUnitsCount = 0,
            MediaLibraryStorageBytes = 0,
            OriginalCacheStorageBytes = 0,
            VideoProcessingUnitsCount = 0,
        };

        long expectedBandwidthBytes = 0;
        long expectedExtensionUnitsCount = 0;
        long expectedMediaLibraryStorageBytes = 0;
        long expectedOriginalCacheStorageBytes = 0;
        long expectedVideoProcessingUnitsCount = 0;

        Assert.Equal(expectedBandwidthBytes, model.BandwidthBytes);
        Assert.Equal(expectedExtensionUnitsCount, model.ExtensionUnitsCount);
        Assert.Equal(expectedMediaLibraryStorageBytes, model.MediaLibraryStorageBytes);
        Assert.Equal(expectedOriginalCacheStorageBytes, model.OriginalCacheStorageBytes);
        Assert.Equal(expectedVideoProcessingUnitsCount, model.VideoProcessingUnitsCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageGetResponse
        {
            BandwidthBytes = 0,
            ExtensionUnitsCount = 0,
            MediaLibraryStorageBytes = 0,
            OriginalCacheStorageBytes = 0,
            VideoProcessingUnitsCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageGetResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageGetResponse
        {
            BandwidthBytes = 0,
            ExtensionUnitsCount = 0,
            MediaLibraryStorageBytes = 0,
            OriginalCacheStorageBytes = 0,
            VideoProcessingUnitsCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageGetResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedBandwidthBytes = 0;
        long expectedExtensionUnitsCount = 0;
        long expectedMediaLibraryStorageBytes = 0;
        long expectedOriginalCacheStorageBytes = 0;
        long expectedVideoProcessingUnitsCount = 0;

        Assert.Equal(expectedBandwidthBytes, deserialized.BandwidthBytes);
        Assert.Equal(expectedExtensionUnitsCount, deserialized.ExtensionUnitsCount);
        Assert.Equal(expectedMediaLibraryStorageBytes, deserialized.MediaLibraryStorageBytes);
        Assert.Equal(expectedOriginalCacheStorageBytes, deserialized.OriginalCacheStorageBytes);
        Assert.Equal(expectedVideoProcessingUnitsCount, deserialized.VideoProcessingUnitsCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageGetResponse
        {
            BandwidthBytes = 0,
            ExtensionUnitsCount = 0,
            MediaLibraryStorageBytes = 0,
            OriginalCacheStorageBytes = 0,
            VideoProcessingUnitsCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UsageGetResponse { };

        Assert.Null(model.BandwidthBytes);
        Assert.False(model.RawData.ContainsKey("bandwidthBytes"));
        Assert.Null(model.ExtensionUnitsCount);
        Assert.False(model.RawData.ContainsKey("extensionUnitsCount"));
        Assert.Null(model.MediaLibraryStorageBytes);
        Assert.False(model.RawData.ContainsKey("mediaLibraryStorageBytes"));
        Assert.Null(model.OriginalCacheStorageBytes);
        Assert.False(model.RawData.ContainsKey("originalCacheStorageBytes"));
        Assert.Null(model.VideoProcessingUnitsCount);
        Assert.False(model.RawData.ContainsKey("videoProcessingUnitsCount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UsageGetResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UsageGetResponse
        {
            // Null should be interpreted as omitted for these properties
            BandwidthBytes = null,
            ExtensionUnitsCount = null,
            MediaLibraryStorageBytes = null,
            OriginalCacheStorageBytes = null,
            VideoProcessingUnitsCount = null,
        };

        Assert.Null(model.BandwidthBytes);
        Assert.False(model.RawData.ContainsKey("bandwidthBytes"));
        Assert.Null(model.ExtensionUnitsCount);
        Assert.False(model.RawData.ContainsKey("extensionUnitsCount"));
        Assert.Null(model.MediaLibraryStorageBytes);
        Assert.False(model.RawData.ContainsKey("mediaLibraryStorageBytes"));
        Assert.Null(model.OriginalCacheStorageBytes);
        Assert.False(model.RawData.ContainsKey("originalCacheStorageBytes"));
        Assert.Null(model.VideoProcessingUnitsCount);
        Assert.False(model.RawData.ContainsKey("videoProcessingUnitsCount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UsageGetResponse
        {
            // Null should be interpreted as omitted for these properties
            BandwidthBytes = null,
            ExtensionUnitsCount = null,
            MediaLibraryStorageBytes = null,
            OriginalCacheStorageBytes = null,
            VideoProcessingUnitsCount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageGetResponse
        {
            BandwidthBytes = 0,
            ExtensionUnitsCount = 0,
            MediaLibraryStorageBytes = 0,
            OriginalCacheStorageBytes = 0,
            VideoProcessingUnitsCount = 0,
        };

        UsageGetResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
