using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<BaseWebhookEvent, BaseWebhookEventFromRaw>))]
public sealed record class BaseWebhookEvent : JsonModel
{
    /// <summary>
    /// Unique identifier for the event.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The type of webhook event.
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
    }

    public BaseWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BaseWebhookEvent(BaseWebhookEvent baseWebhookEvent)
        : base(baseWebhookEvent) { }
#pragma warning restore CS8618

    public BaseWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BaseWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BaseWebhookEventFromRaw.FromRawUnchecked"/>
    public static BaseWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BaseWebhookEventFromRaw : IFromRawJson<BaseWebhookEvent>
{
    /// <inheritdoc/>
    public BaseWebhookEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BaseWebhookEvent.FromRawUnchecked(rawData);
}
