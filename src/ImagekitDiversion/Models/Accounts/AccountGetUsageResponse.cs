using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;

namespace ImagekitDiversion.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountGetUsageResponse, AccountGetUsageResponseFromRaw>))]
public sealed record class AccountGetUsageResponse : JsonModel
{
    /// <summary>
    /// Amount of bandwidth used in bytes.
    /// </summary>
    public long? BandwidthBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("bandwidthBytes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bandwidthBytes", value);
        }
    }

    /// <summary>
    /// Number of extension units used.
    /// </summary>
    public long? ExtensionUnitsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("extensionUnitsCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("extensionUnitsCount", value);
        }
    }

    /// <summary>
    /// Storage used by media library in bytes.
    /// </summary>
    public long? MediaLibraryStorageBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("mediaLibraryStorageBytes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mediaLibraryStorageBytes", value);
        }
    }

    /// <summary>
    /// Storage used by the original cache in bytes.
    /// </summary>
    public long? OriginalCacheStorageBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("originalCacheStorageBytes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("originalCacheStorageBytes", value);
        }
    }

    /// <summary>
    /// Number of video processing units used.
    /// </summary>
    public long? VideoProcessingUnitsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("videoProcessingUnitsCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("videoProcessingUnitsCount", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.ExtensionUnitsCount;
        _ = this.MediaLibraryStorageBytes;
        _ = this.OriginalCacheStorageBytes;
        _ = this.VideoProcessingUnitsCount;
    }

    public AccountGetUsageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountGetUsageResponse(AccountGetUsageResponse accountGetUsageResponse)
        : base(accountGetUsageResponse) { }
#pragma warning restore CS8618

    public AccountGetUsageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountGetUsageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountGetUsageResponseFromRaw.FromRawUnchecked"/>
    public static AccountGetUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountGetUsageResponseFromRaw : IFromRawJson<AccountGetUsageResponse>
{
    /// <inheritdoc/>
    public AccountGetUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountGetUsageResponse.FromRawUnchecked(rawData);
}
