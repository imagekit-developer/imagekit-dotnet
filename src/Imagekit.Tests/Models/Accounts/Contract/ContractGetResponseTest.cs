using System;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Accounts.Contract;

namespace Imagekit.Tests.Models.Accounts.Contract;

public class ContractGetResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractGetResponse
        {
            HasContract = true,
            AsOf = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Consumed = new()
            {
                BandwidthBytes = 0,
                ExtensionUnitsCount = 0,
                PurgeCacheRequests = 0,
                VideoProcessingUnitsCount = 0,
            },
            ContractMonths = 0,
            EffectiveContractEndDate = "2019-12-27",
            EffectiveContractStartDate = "2019-12-27",
            OriginalContractStartDate = "2019-12-27",
            Quota = new()
            {
                BandwidthBytes = 0,
                ExtensionUnitsCount = 0,
                PurgeCacheRequests = 0,
                VideoProcessingUnitsCount = 0,
            },
        };

        bool expectedHasContract = true;
        DateTimeOffset expectedAsOf = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ContractUnits expectedConsumed = new()
        {
            BandwidthBytes = 0,
            ExtensionUnitsCount = 0,
            PurgeCacheRequests = 0,
            VideoProcessingUnitsCount = 0,
        };
        long expectedContractMonths = 0;
        string expectedEffectiveContractEndDate = "2019-12-27";
        string expectedEffectiveContractStartDate = "2019-12-27";
        string expectedOriginalContractStartDate = "2019-12-27";
        ContractUnits expectedQuota = new()
        {
            BandwidthBytes = 0,
            ExtensionUnitsCount = 0,
            PurgeCacheRequests = 0,
            VideoProcessingUnitsCount = 0,
        };

        Assert.Equal(expectedHasContract, model.HasContract);
        Assert.Equal(expectedAsOf, model.AsOf);
        Assert.Equal(expectedConsumed, model.Consumed);
        Assert.Equal(expectedContractMonths, model.ContractMonths);
        Assert.Equal(expectedEffectiveContractEndDate, model.EffectiveContractEndDate);
        Assert.Equal(expectedEffectiveContractStartDate, model.EffectiveContractStartDate);
        Assert.Equal(expectedOriginalContractStartDate, model.OriginalContractStartDate);
        Assert.Equal(expectedQuota, model.Quota);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContractGetResponse
        {
            HasContract = true,
            AsOf = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Consumed = new()
            {
                BandwidthBytes = 0,
                ExtensionUnitsCount = 0,
                PurgeCacheRequests = 0,
                VideoProcessingUnitsCount = 0,
            },
            ContractMonths = 0,
            EffectiveContractEndDate = "2019-12-27",
            EffectiveContractStartDate = "2019-12-27",
            OriginalContractStartDate = "2019-12-27",
            Quota = new()
            {
                BandwidthBytes = 0,
                ExtensionUnitsCount = 0,
                PurgeCacheRequests = 0,
                VideoProcessingUnitsCount = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractGetResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractGetResponse
        {
            HasContract = true,
            AsOf = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Consumed = new()
            {
                BandwidthBytes = 0,
                ExtensionUnitsCount = 0,
                PurgeCacheRequests = 0,
                VideoProcessingUnitsCount = 0,
            },
            ContractMonths = 0,
            EffectiveContractEndDate = "2019-12-27",
            EffectiveContractStartDate = "2019-12-27",
            OriginalContractStartDate = "2019-12-27",
            Quota = new()
            {
                BandwidthBytes = 0,
                ExtensionUnitsCount = 0,
                PurgeCacheRequests = 0,
                VideoProcessingUnitsCount = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractGetResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasContract = true;
        DateTimeOffset expectedAsOf = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ContractUnits expectedConsumed = new()
        {
            BandwidthBytes = 0,
            ExtensionUnitsCount = 0,
            PurgeCacheRequests = 0,
            VideoProcessingUnitsCount = 0,
        };
        long expectedContractMonths = 0;
        string expectedEffectiveContractEndDate = "2019-12-27";
        string expectedEffectiveContractStartDate = "2019-12-27";
        string expectedOriginalContractStartDate = "2019-12-27";
        ContractUnits expectedQuota = new()
        {
            BandwidthBytes = 0,
            ExtensionUnitsCount = 0,
            PurgeCacheRequests = 0,
            VideoProcessingUnitsCount = 0,
        };

        Assert.Equal(expectedHasContract, deserialized.HasContract);
        Assert.Equal(expectedAsOf, deserialized.AsOf);
        Assert.Equal(expectedConsumed, deserialized.Consumed);
        Assert.Equal(expectedContractMonths, deserialized.ContractMonths);
        Assert.Equal(expectedEffectiveContractEndDate, deserialized.EffectiveContractEndDate);
        Assert.Equal(expectedEffectiveContractStartDate, deserialized.EffectiveContractStartDate);
        Assert.Equal(expectedOriginalContractStartDate, deserialized.OriginalContractStartDate);
        Assert.Equal(expectedQuota, deserialized.Quota);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContractGetResponse
        {
            HasContract = true,
            AsOf = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Consumed = new()
            {
                BandwidthBytes = 0,
                ExtensionUnitsCount = 0,
                PurgeCacheRequests = 0,
                VideoProcessingUnitsCount = 0,
            },
            ContractMonths = 0,
            EffectiveContractEndDate = "2019-12-27",
            EffectiveContractStartDate = "2019-12-27",
            OriginalContractStartDate = "2019-12-27",
            Quota = new()
            {
                BandwidthBytes = 0,
                ExtensionUnitsCount = 0,
                PurgeCacheRequests = 0,
                VideoProcessingUnitsCount = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContractGetResponse
        {
            HasContract = true,
            AsOf = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Consumed);
        Assert.False(model.RawData.ContainsKey("consumed"));
        Assert.Null(model.ContractMonths);
        Assert.False(model.RawData.ContainsKey("contractMonths"));
        Assert.Null(model.EffectiveContractEndDate);
        Assert.False(model.RawData.ContainsKey("effectiveContractEndDate"));
        Assert.Null(model.EffectiveContractStartDate);
        Assert.False(model.RawData.ContainsKey("effectiveContractStartDate"));
        Assert.Null(model.OriginalContractStartDate);
        Assert.False(model.RawData.ContainsKey("originalContractStartDate"));
        Assert.Null(model.Quota);
        Assert.False(model.RawData.ContainsKey("quota"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContractGetResponse
        {
            HasContract = true,
            AsOf = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContractGetResponse
        {
            HasContract = true,
            AsOf = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Consumed = null,
            ContractMonths = null,
            EffectiveContractEndDate = null,
            EffectiveContractStartDate = null,
            OriginalContractStartDate = null,
            Quota = null,
        };

        Assert.Null(model.Consumed);
        Assert.False(model.RawData.ContainsKey("consumed"));
        Assert.Null(model.ContractMonths);
        Assert.False(model.RawData.ContainsKey("contractMonths"));
        Assert.Null(model.EffectiveContractEndDate);
        Assert.False(model.RawData.ContainsKey("effectiveContractEndDate"));
        Assert.Null(model.EffectiveContractStartDate);
        Assert.False(model.RawData.ContainsKey("effectiveContractStartDate"));
        Assert.Null(model.OriginalContractStartDate);
        Assert.False(model.RawData.ContainsKey("originalContractStartDate"));
        Assert.Null(model.Quota);
        Assert.False(model.RawData.ContainsKey("quota"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContractGetResponse
        {
            HasContract = true,
            AsOf = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Consumed = null,
            ContractMonths = null,
            EffectiveContractEndDate = null,
            EffectiveContractStartDate = null,
            OriginalContractStartDate = null,
            Quota = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContractGetResponse
        {
            HasContract = true,
            Consumed = new()
            {
                BandwidthBytes = 0,
                ExtensionUnitsCount = 0,
                PurgeCacheRequests = 0,
                VideoProcessingUnitsCount = 0,
            },
            ContractMonths = 0,
            EffectiveContractEndDate = "2019-12-27",
            EffectiveContractStartDate = "2019-12-27",
            OriginalContractStartDate = "2019-12-27",
            Quota = new()
            {
                BandwidthBytes = 0,
                ExtensionUnitsCount = 0,
                PurgeCacheRequests = 0,
                VideoProcessingUnitsCount = 0,
            },
        };

        Assert.Null(model.AsOf);
        Assert.False(model.RawData.ContainsKey("asOf"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContractGetResponse
        {
            HasContract = true,
            Consumed = new()
            {
                BandwidthBytes = 0,
                ExtensionUnitsCount = 0,
                PurgeCacheRequests = 0,
                VideoProcessingUnitsCount = 0,
            },
            ContractMonths = 0,
            EffectiveContractEndDate = "2019-12-27",
            EffectiveContractStartDate = "2019-12-27",
            OriginalContractStartDate = "2019-12-27",
            Quota = new()
            {
                BandwidthBytes = 0,
                ExtensionUnitsCount = 0,
                PurgeCacheRequests = 0,
                VideoProcessingUnitsCount = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ContractGetResponse
        {
            HasContract = true,
            Consumed = new()
            {
                BandwidthBytes = 0,
                ExtensionUnitsCount = 0,
                PurgeCacheRequests = 0,
                VideoProcessingUnitsCount = 0,
            },
            ContractMonths = 0,
            EffectiveContractEndDate = "2019-12-27",
            EffectiveContractStartDate = "2019-12-27",
            OriginalContractStartDate = "2019-12-27",
            Quota = new()
            {
                BandwidthBytes = 0,
                ExtensionUnitsCount = 0,
                PurgeCacheRequests = 0,
                VideoProcessingUnitsCount = 0,
            },

            AsOf = null,
        };

        Assert.Null(model.AsOf);
        Assert.True(model.RawData.ContainsKey("asOf"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContractGetResponse
        {
            HasContract = true,
            Consumed = new()
            {
                BandwidthBytes = 0,
                ExtensionUnitsCount = 0,
                PurgeCacheRequests = 0,
                VideoProcessingUnitsCount = 0,
            },
            ContractMonths = 0,
            EffectiveContractEndDate = "2019-12-27",
            EffectiveContractStartDate = "2019-12-27",
            OriginalContractStartDate = "2019-12-27",
            Quota = new()
            {
                BandwidthBytes = 0,
                ExtensionUnitsCount = 0,
                PurgeCacheRequests = 0,
                VideoProcessingUnitsCount = 0,
            },

            AsOf = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContractGetResponse
        {
            HasContract = true,
            AsOf = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Consumed = new()
            {
                BandwidthBytes = 0,
                ExtensionUnitsCount = 0,
                PurgeCacheRequests = 0,
                VideoProcessingUnitsCount = 0,
            },
            ContractMonths = 0,
            EffectiveContractEndDate = "2019-12-27",
            EffectiveContractStartDate = "2019-12-27",
            OriginalContractStartDate = "2019-12-27",
            Quota = new()
            {
                BandwidthBytes = 0,
                ExtensionUnitsCount = 0,
                PurgeCacheRequests = 0,
                VideoProcessingUnitsCount = 0,
            },
        };

        ContractGetResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
