using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using System = System;

namespace ImagekitDiversion.Models.Files.Purge;

[JsonConverter(typeof(JsonModelConverter<PurgeStatusResponse, PurgeStatusResponseFromRaw>))]
public sealed record class PurgeStatusResponse : JsonModel
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

    public PurgeStatusResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PurgeStatusResponse(PurgeStatusResponse purgeStatusResponse)
        : base(purgeStatusResponse) { }
#pragma warning restore CS8618

    public PurgeStatusResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PurgeStatusResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PurgeStatusResponseFromRaw.FromRawUnchecked"/>
    public static PurgeStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PurgeStatusResponseFromRaw : IFromRawJson<PurgeStatusResponse>
{
    /// <inheritdoc/>
    public PurgeStatusResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PurgeStatusResponse.FromRawUnchecked(rawData);
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
                _ => throw new ImagekitDiversionInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
