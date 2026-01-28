using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;
using SelectedFieldsSchemaItemProperties = Imagekit.Models.Webhooks.UploadPreTransformSuccessEventProperties.IntersectionMember1Properties.DataProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties;

namespace Imagekit.Models.Webhooks.UploadPreTransformSuccessEventProperties.IntersectionMember1Properties.DataProperties.SelectedFieldsSchemaProperties;

[JsonConverter(typeof(ModelConverter<SelectedFieldsSchemaItem>))]
public sealed record class SelectedFieldsSchemaItem : ModelBase, IFromRaw<SelectedFieldsSchemaItem>
{
    /// <summary>
    /// Type of the custom metadata field.
    /// </summary>
    public required ApiEnum<string, SelectedFieldsSchemaItemProperties::Type> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ImageKitInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, SelectedFieldsSchemaItemProperties::Type>
            >(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The default value for this custom metadata field. The value should match the
    /// `type` of custom metadata field.
    /// </summary>
    public SelectedFieldsSchemaItemProperties::DefaultValue? DefaultValue
    {
        get
        {
            if (!this.Properties.TryGetValue("defaultValue", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SelectedFieldsSchemaItemProperties::DefaultValue?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["defaultValue"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies if the custom metadata field is required or not.
    /// </summary>
    public bool? IsValueRequired
    {
        get
        {
            if (!this.Properties.TryGetValue("isValueRequired", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["isValueRequired"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Maximum length of string. Only set if `type` is set to `Text` or `Textarea`.
    /// </summary>
    public double? MaxLength
    {
        get
        {
            if (!this.Properties.TryGetValue("maxLength", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["maxLength"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Maximum value of the field. Only set if field type is `Date` or `Number`.
    /// For `Date` type field, the value will be in ISO8601 string format. For `Number`
    /// type field, it will be a numeric value.
    /// </summary>
    public SelectedFieldsSchemaItemProperties::MaxValue? MaxValue
    {
        get
        {
            if (!this.Properties.TryGetValue("maxValue", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SelectedFieldsSchemaItemProperties::MaxValue?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["maxValue"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Minimum length of string. Only set if `type` is set to `Text` or `Textarea`.
    /// </summary>
    public double? MinLength
    {
        get
        {
            if (!this.Properties.TryGetValue("minLength", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["minLength"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Minimum value of the field. Only set if field type is `Date` or `Number`.
    /// For `Date` type field, the value will be in ISO8601 string format. For `Number`
    /// type field, it will be a numeric value.
    /// </summary>
    public SelectedFieldsSchemaItemProperties::MinValue? MinValue
    {
        get
        {
            if (!this.Properties.TryGetValue("minValue", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SelectedFieldsSchemaItemProperties::MinValue?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["minValue"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Indicates whether the custom metadata field is read only. A read only field
    /// cannot be modified after being set. This field is configurable only via the
    /// **Path policy** feature.
    /// </summary>
    public bool? ReadOnly
    {
        get
        {
            if (!this.Properties.TryGetValue("readOnly", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["readOnly"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An array of allowed values when field type is `SingleSelect` or `MultiSelect`.
    /// </summary>
    public List<SelectedFieldsSchemaItemProperties::SelectOption>? SelectOptions
    {
        get
        {
            if (!this.Properties.TryGetValue("selectOptions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<SelectedFieldsSchemaItemProperties::SelectOption>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["selectOptions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies if the selectOptions array is truncated. It is truncated when number
    /// of options are > 100.
    /// </summary>
    public bool? SelectOptionsTruncated
    {
        get
        {
            if (!this.Properties.TryGetValue("selectOptionsTruncated", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["selectOptionsTruncated"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Type.Validate();
        this.DefaultValue?.Validate();
        _ = this.IsValueRequired;
        _ = this.MaxLength;
        this.MaxValue?.Validate();
        _ = this.MinLength;
        this.MinValue?.Validate();
        _ = this.ReadOnly;
        foreach (var item in this.SelectOptions ?? [])
        {
            item.Validate();
        }
        _ = this.SelectOptionsTruncated;
    }

    public SelectedFieldsSchemaItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SelectedFieldsSchemaItem(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SelectedFieldsSchemaItem FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public SelectedFieldsSchemaItem(ApiEnum<string, SelectedFieldsSchemaItemProperties::Type> type)
        : this()
    {
        this.Type = type;
    }
}
