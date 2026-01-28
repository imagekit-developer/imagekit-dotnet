using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SchemaProperties = Imagekit.Models.CustomMetadataFields.CustomMetadataFieldCreateParamsProperties.SchemaProperties;

namespace Imagekit.Models.CustomMetadataFields.CustomMetadataFieldCreateParamsProperties;

[JsonConverter(typeof(ModelConverter<Schema>))]
public sealed record class Schema : ModelBase, IFromRaw<Schema>
{
    /// <summary>
    /// Type of the custom metadata field.
    /// </summary>
    public required ApiEnum<string, SchemaProperties::Type> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<ApiEnum<string, SchemaProperties::Type>>(
                element,
                ModelBase.SerializerOptions
            );
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
    /// The default value for this custom metadata field. This property is only required
    /// if `isValueRequired` property is set to `true`. The value should match the
    /// `type` of custom metadata field.
    /// </summary>
    public SchemaProperties::DefaultValue? DefaultValue
    {
        get
        {
            if (!this.Properties.TryGetValue("defaultValue", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SchemaProperties::DefaultValue?>(
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
    /// Sets this custom metadata field as required. Setting custom metadata fields
    /// on an asset will throw error if the value for all required fields are not
    /// present in upload or update asset API request body.
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
    /// Maximum length of string. Only set this property if `type` is set to `Text`
    /// or `Textarea`.
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
    /// Maximum value of the field. Only set this property if field type is `Date`
    /// or `Number`. For `Date` type field, set the minimum date in ISO8601 string
    /// format. For `Number` type field, set the minimum numeric value.
    /// </summary>
    public SchemaProperties::MaxValue? MaxValue
    {
        get
        {
            if (!this.Properties.TryGetValue("maxValue", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SchemaProperties::MaxValue?>(
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
    /// Minimum length of string. Only set this property if `type` is set to `Text`
    /// or `Textarea`.
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
    /// Minimum value of the field. Only set this property if field type is `Date`
    /// or `Number`. For `Date` type field, set the minimum date in ISO8601 string
    /// format. For `Number` type field, set the minimum numeric value.
    /// </summary>
    public SchemaProperties::MinValue? MinValue
    {
        get
        {
            if (!this.Properties.TryGetValue("minValue", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SchemaProperties::MinValue?>(
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
    /// An array of allowed values. This property is only required if `type` property
    /// is set to `SingleSelect` or `MultiSelect`.
    /// </summary>
    public List<SchemaProperties::SelectOption>? SelectOptions
    {
        get
        {
            if (!this.Properties.TryGetValue("selectOptions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<SchemaProperties::SelectOption>?>(
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

    public override void Validate()
    {
        this.Type.Validate();
        this.DefaultValue?.Validate();
        _ = this.IsValueRequired;
        _ = this.MaxLength;
        this.MaxValue?.Validate();
        _ = this.MinLength;
        this.MinValue?.Validate();
        foreach (var item in this.SelectOptions ?? [])
        {
            item.Validate();
        }
    }

    public Schema() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Schema(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Schema FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Schema(ApiEnum<string, SchemaProperties::Type> type)
        : this()
    {
        this.Type = type;
    }
}
