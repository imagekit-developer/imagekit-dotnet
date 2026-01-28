using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImageKit.Core;

namespace ImageKit.Models.Cache.Invalidation;

[JsonConverter(
    typeof(JsonModelConverter<InvalidationCreateResponse, InvalidationCreateResponseFromRaw>)
)]
public sealed record class InvalidationCreateResponse : JsonModel
{
    /// <summary>
    /// Unique identifier of the purge request. This can be used to check the status
    /// of the purge request.
    /// </summary>
    public string? RequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("requestId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("requestId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RequestID;
    }

    public InvalidationCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvalidationCreateResponse(InvalidationCreateResponse invalidationCreateResponse)
        : base(invalidationCreateResponse) { }
#pragma warning restore CS8618

    public InvalidationCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvalidationCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvalidationCreateResponseFromRaw.FromRawUnchecked"/>
    public static InvalidationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvalidationCreateResponseFromRaw : IFromRawJson<InvalidationCreateResponse>
{
    /// <inheritdoc/>
    public InvalidationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvalidationCreateResponse.FromRawUnchecked(rawData);
}
