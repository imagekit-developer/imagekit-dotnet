using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Webhooks.UploadPreTransformSuccessEventProperties.DataProperties.ExtensionStatusProperties;

namespace Imagekit.Models.Webhooks.UploadPreTransformSuccessEventProperties.DataProperties;

/// <summary>
/// Extension names with their processing status at the time of completion of the
/// request. It could have one of the following status values:
///
/// `success`: The extension has been successfully applied. `failed`: The extension
/// has failed and will not be retried. `pending`: The extension will finish processing
/// in some time. On completion, the final status (success / failed) will be sent
/// to the `webhookUrl` provided.
///
/// If no extension was requested, then this parameter is not returned.
/// </summary>
[JsonConverter(typeof(ModelConverter<ExtensionStatus>))]
public sealed record class ExtensionStatus : ModelBase, IFromRaw<ExtensionStatus>
{
    public ApiEnum<string, AIAutoDescription>? AIAutoDescription
    {
        get
        {
            if (!this.Properties.TryGetValue("ai-auto-description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, AIAutoDescription>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["ai-auto-description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, AwsAutoTagging>? AwsAutoTagging
    {
        get
        {
            if (!this.Properties.TryGetValue("aws-auto-tagging", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, AwsAutoTagging>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["aws-auto-tagging"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, GoogleAutoTagging>? GoogleAutoTagging
    {
        get
        {
            if (!this.Properties.TryGetValue("google-auto-tagging", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, GoogleAutoTagging>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["google-auto-tagging"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, RemoveBg>? RemoveBg
    {
        get
        {
            if (!this.Properties.TryGetValue("remove-bg", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, RemoveBg>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["remove-bg"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.AIAutoDescription?.Validate();
        this.AwsAutoTagging?.Validate();
        this.GoogleAutoTagging?.Validate();
        this.RemoveBg?.Validate();
    }

    public ExtensionStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtensionStatus(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ExtensionStatus FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
