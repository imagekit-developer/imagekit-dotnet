using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;
using System = System;

namespace Imagekit.Models.Cache.Invalidation;

[JsonConverter(typeof(JsonModelConverter<InvalidationGetResponse, InvalidationGetResponseFromRaw>))]
public sealed record class InvalidationGetResponse : JsonModel
{
    /// <summary>
    /// Status of the purge request.
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status?.Validate();
    }

    public InvalidationGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvalidationGetResponse(InvalidationGetResponse invalidationGetResponse)
        : base(invalidationGetResponse) { }
#pragma warning restore CS8618

    public InvalidationGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvalidationGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvalidationGetResponseFromRaw.FromRawUnchecked"/>
    public static InvalidationGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvalidationGetResponseFromRaw : IFromRawJson<InvalidationGetResponse>
{
    /// <inheritdoc/>
    public InvalidationGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvalidationGetResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of the purge request.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending,
    Completed,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Pending" => Status.Pending,
            "Completed" => Status.Completed,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Pending => "Pending",
                Status.Completed => "Completed",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
