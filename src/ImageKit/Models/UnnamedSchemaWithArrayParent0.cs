using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImageKit.Core;
using ImageKit.Exceptions;

namespace ImageKit.Models;

[JsonConverter(typeof(UnnamedSchemaWithArrayParent0Converter))]
public record class UnnamedSchemaWithArrayParent0 : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public UnnamedSchemaWithArrayParent0(
        UnnamedSchemaWithArrayParent0RemoveBg value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0(
        UnnamedSchemaWithArrayParent0AutoTaggingExtension value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0(
        UnnamedSchemaWithArrayParent0AIAutoDescription value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0(
        UnnamedSchemaWithArrayParent0AITasks value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0(SavedExtension value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnnamedSchemaWithArrayParent0RemoveBg"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRemoveBg(out var value)) {
    ///     // `value` is of type `UnnamedSchemaWithArrayParent0RemoveBg`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRemoveBg(
        [NotNullWhen(true)] out UnnamedSchemaWithArrayParent0RemoveBg? value
    )
    {
        value = this.Value as UnnamedSchemaWithArrayParent0RemoveBg;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnnamedSchemaWithArrayParent0AutoTaggingExtension"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAutoTaggingExtension(out var value)) {
    ///     // `value` is of type `UnnamedSchemaWithArrayParent0AutoTaggingExtension`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAutoTaggingExtension(
        [NotNullWhen(true)] out UnnamedSchemaWithArrayParent0AutoTaggingExtension? value
    )
    {
        value = this.Value as UnnamedSchemaWithArrayParent0AutoTaggingExtension;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnnamedSchemaWithArrayParent0AIAutoDescription"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAIAutoDescription(out var value)) {
    ///     // `value` is of type `UnnamedSchemaWithArrayParent0AIAutoDescription`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAIAutoDescription(
        [NotNullWhen(true)] out UnnamedSchemaWithArrayParent0AIAutoDescription? value
    )
    {
        value = this.Value as UnnamedSchemaWithArrayParent0AIAutoDescription;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnnamedSchemaWithArrayParent0AITasks"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAITasks(out var value)) {
    ///     // `value` is of type `UnnamedSchemaWithArrayParent0AITasks`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAITasks([NotNullWhen(true)] out UnnamedSchemaWithArrayParent0AITasks? value)
    {
        value = this.Value as UnnamedSchemaWithArrayParent0AITasks;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SavedExtension"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSavedExtension(out var value)) {
    ///     // `value` is of type `SavedExtension`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSavedExtension([NotNullWhen(true)] out SavedExtension? value)
    {
        value = this.Value as SavedExtension;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (UnnamedSchemaWithArrayParent0RemoveBg value) => {...},
    ///     (UnnamedSchemaWithArrayParent0AutoTaggingExtension value) => {...},
    ///     (UnnamedSchemaWithArrayParent0AIAutoDescription value) => {...},
    ///     (UnnamedSchemaWithArrayParent0AITasks value) => {...},
    ///     (SavedExtension value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<UnnamedSchemaWithArrayParent0RemoveBg> removeBg,
        Action<UnnamedSchemaWithArrayParent0AutoTaggingExtension> autoTaggingExtension,
        Action<UnnamedSchemaWithArrayParent0AIAutoDescription> aiAutoDescription,
        Action<UnnamedSchemaWithArrayParent0AITasks> aiTasks,
        Action<SavedExtension> savedExtension
    )
    {
        switch (this.Value)
        {
            case UnnamedSchemaWithArrayParent0RemoveBg value:
                removeBg(value);
                break;
            case UnnamedSchemaWithArrayParent0AutoTaggingExtension value:
                autoTaggingExtension(value);
                break;
            case UnnamedSchemaWithArrayParent0AIAutoDescription value:
                aiAutoDescription(value);
                break;
            case UnnamedSchemaWithArrayParent0AITasks value:
                aiTasks(value);
                break;
            case SavedExtension value:
                savedExtension(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UnnamedSchemaWithArrayParent0"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (UnnamedSchemaWithArrayParent0RemoveBg value) => {...},
    ///     (UnnamedSchemaWithArrayParent0AutoTaggingExtension value) => {...},
    ///     (UnnamedSchemaWithArrayParent0AIAutoDescription value) => {...},
    ///     (UnnamedSchemaWithArrayParent0AITasks value) => {...},
    ///     (SavedExtension value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<UnnamedSchemaWithArrayParent0RemoveBg, T> removeBg,
        Func<UnnamedSchemaWithArrayParent0AutoTaggingExtension, T> autoTaggingExtension,
        Func<UnnamedSchemaWithArrayParent0AIAutoDescription, T> aiAutoDescription,
        Func<UnnamedSchemaWithArrayParent0AITasks, T> aiTasks,
        Func<SavedExtension, T> savedExtension
    )
    {
        return this.Value switch
        {
            UnnamedSchemaWithArrayParent0RemoveBg value => removeBg(value),
            UnnamedSchemaWithArrayParent0AutoTaggingExtension value => autoTaggingExtension(value),
            UnnamedSchemaWithArrayParent0AIAutoDescription value => aiAutoDescription(value),
            UnnamedSchemaWithArrayParent0AITasks value => aiTasks(value),
            SavedExtension value => savedExtension(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent0"
            ),
        };
    }

    public static implicit operator UnnamedSchemaWithArrayParent0(
        UnnamedSchemaWithArrayParent0RemoveBg value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0(
        UnnamedSchemaWithArrayParent0AutoTaggingExtension value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0(
        UnnamedSchemaWithArrayParent0AIAutoDescription value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0(
        UnnamedSchemaWithArrayParent0AITasks value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0(SavedExtension value) =>
        new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent0"
            );
        }
        this.Switch(
            (removeBg) => removeBg.Validate(),
            (autoTaggingExtension) => autoTaggingExtension.Validate(),
            (aiAutoDescription) => aiAutoDescription.Validate(),
            (aiTasks) => aiTasks.Validate(),
            (savedExtension) => savedExtension.Validate()
        );
    }

    public virtual bool Equals(UnnamedSchemaWithArrayParent0? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            UnnamedSchemaWithArrayParent0RemoveBg _ => 0,
            UnnamedSchemaWithArrayParent0AutoTaggingExtension _ => 1,
            UnnamedSchemaWithArrayParent0AIAutoDescription _ => 2,
            UnnamedSchemaWithArrayParent0AITasks _ => 3,
            SavedExtension _ => 4,
            _ => -1,
        };
    }
}

sealed class UnnamedSchemaWithArrayParent0Converter : JsonConverter<UnnamedSchemaWithArrayParent0>
{
    public override UnnamedSchemaWithArrayParent0? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? name;
        try
        {
            name = element.GetProperty("name").GetString();
        }
        catch
        {
            name = null;
        }

        switch (name)
        {
            case "remove-bg":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0RemoveBg>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "ai-auto-description":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AIAutoDescription>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "ai-tasks":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasks>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "saved-extension":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SavedExtension>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AutoTaggingExtension>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent0 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnnamedSchemaWithArrayParent0RemoveBg,
        UnnamedSchemaWithArrayParent0RemoveBgFromRaw
    >)
)]
public sealed record class UnnamedSchemaWithArrayParent0RemoveBg : JsonModel
{
    /// <summary>
    /// Specifies the background removal extension.
    /// </summary>
    public JsonElement Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public UnnamedSchemaWithArrayParent0RemoveBgOptions? Options
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UnnamedSchemaWithArrayParent0RemoveBgOptions>(
                "options"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("options", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Name, JsonSerializer.SerializeToElement("remove-bg")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        this.Options?.Validate();
    }

    public UnnamedSchemaWithArrayParent0RemoveBg()
    {
        this.Name = JsonSerializer.SerializeToElement("remove-bg");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0RemoveBg(
        UnnamedSchemaWithArrayParent0RemoveBg unnamedSchemaWithArrayParent0RemoveBg
    )
        : base(unnamedSchemaWithArrayParent0RemoveBg) { }
#pragma warning restore CS8618

    public UnnamedSchemaWithArrayParent0RemoveBg(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("remove-bg");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnnamedSchemaWithArrayParent0RemoveBg(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnnamedSchemaWithArrayParent0RemoveBgFromRaw.FromRawUnchecked"/>
    public static UnnamedSchemaWithArrayParent0RemoveBg FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnnamedSchemaWithArrayParent0RemoveBgFromRaw
    : IFromRawJson<UnnamedSchemaWithArrayParent0RemoveBg>
{
    /// <inheritdoc/>
    public UnnamedSchemaWithArrayParent0RemoveBg FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnnamedSchemaWithArrayParent0RemoveBg.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnnamedSchemaWithArrayParent0RemoveBgOptions,
        UnnamedSchemaWithArrayParent0RemoveBgOptionsFromRaw
    >)
)]
public sealed record class UnnamedSchemaWithArrayParent0RemoveBgOptions : JsonModel
{
    /// <summary>
    /// Whether to add an artificial shadow to the result. Default is false. Note:
    /// Adding shadows is currently only supported for car photos.
    /// </summary>
    public bool? AddShadow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("add_shadow");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("add_shadow", value);
        }
    }

    /// <summary>
    /// Specifies a solid color background using hex code (e.g., "81d4fa", "fff")
    /// or color name (e.g., "green"). If this parameter is set, `bg_image_url` must
    /// be empty.
    /// </summary>
    public string? BgColor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bg_color");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bg_color", value);
        }
    }

    /// <summary>
    /// Sets a background image from a URL. If this parameter is set, `bg_color` must
    /// be empty.
    /// </summary>
    public string? BgImageUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bg_image_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bg_image_url", value);
        }
    }

    /// <summary>
    /// Allows semi-transparent regions in the result. Default is true. Note: Semitransparency
    /// is currently only supported for car windows.
    /// </summary>
    public bool? Semitransparency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("semitransparency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("semitransparency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddShadow;
        _ = this.BgColor;
        _ = this.BgImageUrl;
        _ = this.Semitransparency;
    }

    public UnnamedSchemaWithArrayParent0RemoveBgOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0RemoveBgOptions(
        UnnamedSchemaWithArrayParent0RemoveBgOptions unnamedSchemaWithArrayParent0RemoveBgOptions
    )
        : base(unnamedSchemaWithArrayParent0RemoveBgOptions) { }
#pragma warning restore CS8618

    public UnnamedSchemaWithArrayParent0RemoveBgOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnnamedSchemaWithArrayParent0RemoveBgOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnnamedSchemaWithArrayParent0RemoveBgOptionsFromRaw.FromRawUnchecked"/>
    public static UnnamedSchemaWithArrayParent0RemoveBgOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnnamedSchemaWithArrayParent0RemoveBgOptionsFromRaw
    : IFromRawJson<UnnamedSchemaWithArrayParent0RemoveBgOptions>
{
    /// <inheritdoc/>
    public UnnamedSchemaWithArrayParent0RemoveBgOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnnamedSchemaWithArrayParent0RemoveBgOptions.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnnamedSchemaWithArrayParent0AutoTaggingExtension,
        UnnamedSchemaWithArrayParent0AutoTaggingExtensionFromRaw
    >)
)]
public sealed record class UnnamedSchemaWithArrayParent0AutoTaggingExtension : JsonModel
{
    /// <summary>
    /// Maximum number of tags to attach to the asset.
    /// </summary>
    public required long MaxTags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("maxTags");
        }
        init { this._rawData.Set("maxTags", value); }
    }

    /// <summary>
    /// Minimum confidence level for tags to be considered valid.
    /// </summary>
    public required long MinConfidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("minConfidence");
        }
        init { this._rawData.Set("minConfidence", value); }
    }

    /// <summary>
    /// Specifies the auto-tagging extension used.
    /// </summary>
    public required ApiEnum<string, UnnamedSchemaWithArrayParent0AutoTaggingExtensionName> Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UnnamedSchemaWithArrayParent0AutoTaggingExtensionName>
            >("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MaxTags;
        _ = this.MinConfidence;
        this.Name.Validate();
    }

    public UnnamedSchemaWithArrayParent0AutoTaggingExtension() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AutoTaggingExtension(
        UnnamedSchemaWithArrayParent0AutoTaggingExtension unnamedSchemaWithArrayParent0AutoTaggingExtension
    )
        : base(unnamedSchemaWithArrayParent0AutoTaggingExtension) { }
#pragma warning restore CS8618

    public UnnamedSchemaWithArrayParent0AutoTaggingExtension(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnnamedSchemaWithArrayParent0AutoTaggingExtension(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnnamedSchemaWithArrayParent0AutoTaggingExtensionFromRaw.FromRawUnchecked"/>
    public static UnnamedSchemaWithArrayParent0AutoTaggingExtension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnnamedSchemaWithArrayParent0AutoTaggingExtensionFromRaw
    : IFromRawJson<UnnamedSchemaWithArrayParent0AutoTaggingExtension>
{
    /// <inheritdoc/>
    public UnnamedSchemaWithArrayParent0AutoTaggingExtension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnnamedSchemaWithArrayParent0AutoTaggingExtension.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the auto-tagging extension used.
/// </summary>
[JsonConverter(typeof(UnnamedSchemaWithArrayParent0AutoTaggingExtensionNameConverter))]
public enum UnnamedSchemaWithArrayParent0AutoTaggingExtensionName
{
    GoogleAutoTagging,
    AwsAutoTagging,
}

sealed class UnnamedSchemaWithArrayParent0AutoTaggingExtensionNameConverter
    : JsonConverter<UnnamedSchemaWithArrayParent0AutoTaggingExtensionName>
{
    public override UnnamedSchemaWithArrayParent0AutoTaggingExtensionName Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "google-auto-tagging" =>
                UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
            "aws-auto-tagging" =>
                UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.AwsAutoTagging,
            _ => (UnnamedSchemaWithArrayParent0AutoTaggingExtensionName)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent0AutoTaggingExtensionName value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging =>
                    "google-auto-tagging",
                UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.AwsAutoTagging =>
                    "aws-auto-tagging",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(UnnamedSchemaWithArrayParent0AIAutoDescriptionConverter))]
public record class UnnamedSchemaWithArrayParent0AIAutoDescription
{
    public JsonElement Element { get; private init; }

    public UnnamedSchemaWithArrayParent0AIAutoDescription()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "name": "ai-auto-description"
            }
            """
        );
    }

    internal UnnamedSchemaWithArrayParent0AIAutoDescription(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new UnnamedSchemaWithArrayParent0AIAutoDescription())
        {
            throw new ImageKitInvalidDataException(
                "Invalid value given for 'UnnamedSchemaWithArrayParent0AIAutoDescription'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(UnnamedSchemaWithArrayParent0AIAutoDescription? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class UnnamedSchemaWithArrayParent0AIAutoDescriptionConverter
    : JsonConverter<UnnamedSchemaWithArrayParent0AIAutoDescription>
{
    public override UnnamedSchemaWithArrayParent0AIAutoDescription? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent0AIAutoDescription value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnnamedSchemaWithArrayParent0AITasks,
        UnnamedSchemaWithArrayParent0AITasksFromRaw
    >)
)]
public sealed record class UnnamedSchemaWithArrayParent0AITasks : JsonModel
{
    /// <summary>
    /// Specifies the AI tasks extension for automated image analysis using AI models.
    /// </summary>
    public JsonElement Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Array of task objects defining AI operations to perform on the asset.
    /// </summary>
    public required IReadOnlyList<UnnamedSchemaWithArrayParent0AITasksTask> Tasks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<UnnamedSchemaWithArrayParent0AITasksTask>
            >("tasks");
        }
        init
        {
            this._rawData.Set<ImmutableArray<UnnamedSchemaWithArrayParent0AITasksTask>>(
                "tasks",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Name, JsonSerializer.SerializeToElement("ai-tasks")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.Tasks)
        {
            item.Validate();
        }
    }

    public UnnamedSchemaWithArrayParent0AITasks()
    {
        this.Name = JsonSerializer.SerializeToElement("ai-tasks");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AITasks(
        UnnamedSchemaWithArrayParent0AITasks unnamedSchemaWithArrayParent0AITasks
    )
        : base(unnamedSchemaWithArrayParent0AITasks) { }
#pragma warning restore CS8618

    public UnnamedSchemaWithArrayParent0AITasks(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("ai-tasks");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnnamedSchemaWithArrayParent0AITasks(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnnamedSchemaWithArrayParent0AITasksFromRaw.FromRawUnchecked"/>
    public static UnnamedSchemaWithArrayParent0AITasks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AITasks(
        IReadOnlyList<UnnamedSchemaWithArrayParent0AITasksTask> tasks
    )
        : this()
    {
        this.Tasks = tasks;
    }
}

class UnnamedSchemaWithArrayParent0AITasksFromRaw
    : IFromRawJson<UnnamedSchemaWithArrayParent0AITasks>
{
    /// <inheritdoc/>
    public UnnamedSchemaWithArrayParent0AITasks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnnamedSchemaWithArrayParent0AITasks.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UnnamedSchemaWithArrayParent0AITasksTaskConverter))]
public record class UnnamedSchemaWithArrayParent0AITasksTask : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string Instruction
    {
        get
        {
            return Match(
                selectTags: (x) => x.Instruction,
                selectMetadata: (x) => x.Instruction,
                yesNo: (x) => x.Instruction
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                selectTags: (x) => x.Type,
                selectMetadata: (x) => x.Type,
                yesNo: (x) => x.Type
            );
        }
    }

    public long? MaxSelections
    {
        get
        {
            return Match<long?>(
                selectTags: (x) => x.MaxSelections,
                selectMetadata: (x) => x.MaxSelections,
                yesNo: (_) => null
            );
        }
    }

    public long? MinSelections
    {
        get
        {
            return Match<long?>(
                selectTags: (x) => x.MinSelections,
                selectMetadata: (x) => x.MinSelections,
                yesNo: (_) => null
            );
        }
    }

    public UnnamedSchemaWithArrayParent0AITasksTask(
        UnnamedSchemaWithArrayParent0AITasksTaskSelectTags value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0AITasksTask(
        UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0AITasksTask(
        UnnamedSchemaWithArrayParent0AITasksTaskYesNo value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0AITasksTask(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnnamedSchemaWithArrayParent0AITasksTaskSelectTags"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSelectTags(out var value)) {
    ///     // `value` is of type `UnnamedSchemaWithArrayParent0AITasksTaskSelectTags`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSelectTags(
        [NotNullWhen(true)] out UnnamedSchemaWithArrayParent0AITasksTaskSelectTags? value
    )
    {
        value = this.Value as UnnamedSchemaWithArrayParent0AITasksTaskSelectTags;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSelectMetadata(out var value)) {
    ///     // `value` is of type `UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSelectMetadata(
        [NotNullWhen(true)] out UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata? value
    )
    {
        value = this.Value as UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnnamedSchemaWithArrayParent0AITasksTaskYesNo"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickYesNo(out var value)) {
    ///     // `value` is of type `UnnamedSchemaWithArrayParent0AITasksTaskYesNo`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickYesNo(
        [NotNullWhen(true)] out UnnamedSchemaWithArrayParent0AITasksTaskYesNo? value
    )
    {
        value = this.Value as UnnamedSchemaWithArrayParent0AITasksTaskYesNo;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (UnnamedSchemaWithArrayParent0AITasksTaskSelectTags value) => {...},
    ///     (UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata value) => {...},
    ///     (UnnamedSchemaWithArrayParent0AITasksTaskYesNo value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<UnnamedSchemaWithArrayParent0AITasksTaskSelectTags> selectTags,
        Action<UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata> selectMetadata,
        Action<UnnamedSchemaWithArrayParent0AITasksTaskYesNo> yesNo
    )
    {
        switch (this.Value)
        {
            case UnnamedSchemaWithArrayParent0AITasksTaskSelectTags value:
                selectTags(value);
                break;
            case UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata value:
                selectMetadata(value);
                break;
            case UnnamedSchemaWithArrayParent0AITasksTaskYesNo value:
                yesNo(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UnnamedSchemaWithArrayParent0AITasksTask"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (UnnamedSchemaWithArrayParent0AITasksTaskSelectTags value) => {...},
    ///     (UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata value) => {...},
    ///     (UnnamedSchemaWithArrayParent0AITasksTaskYesNo value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<UnnamedSchemaWithArrayParent0AITasksTaskSelectTags, T> selectTags,
        Func<UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata, T> selectMetadata,
        Func<UnnamedSchemaWithArrayParent0AITasksTaskYesNo, T> yesNo
    )
    {
        return this.Value switch
        {
            UnnamedSchemaWithArrayParent0AITasksTaskSelectTags value => selectTags(value),
            UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata value => selectMetadata(value),
            UnnamedSchemaWithArrayParent0AITasksTaskYesNo value => yesNo(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent0AITasksTask"
            ),
        };
    }

    public static implicit operator UnnamedSchemaWithArrayParent0AITasksTask(
        UnnamedSchemaWithArrayParent0AITasksTaskSelectTags value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0AITasksTask(
        UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0AITasksTask(
        UnnamedSchemaWithArrayParent0AITasksTaskYesNo value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent0AITasksTask"
            );
        }
        this.Switch(
            (selectTags) => selectTags.Validate(),
            (selectMetadata) => selectMetadata.Validate(),
            (yesNo) => yesNo.Validate()
        );
    }

    public virtual bool Equals(UnnamedSchemaWithArrayParent0AITasksTask? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            UnnamedSchemaWithArrayParent0AITasksTaskSelectTags _ => 0,
            UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata _ => 1,
            UnnamedSchemaWithArrayParent0AITasksTaskYesNo _ => 2,
            _ => -1,
        };
    }
}

sealed class UnnamedSchemaWithArrayParent0AITasksTaskConverter
    : JsonConverter<UnnamedSchemaWithArrayParent0AITasksTask>
{
    public override UnnamedSchemaWithArrayParent0AITasksTask? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "select_tags":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskSelectTags>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "select_metadata":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "yes_no":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0AITasksTaskYesNo>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new UnnamedSchemaWithArrayParent0AITasksTask(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent0AITasksTask value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnnamedSchemaWithArrayParent0AITasksTaskSelectTags,
        UnnamedSchemaWithArrayParent0AITasksTaskSelectTagsFromRaw
    >)
)]
public sealed record class UnnamedSchemaWithArrayParent0AITasksTaskSelectTags : JsonModel
{
    /// <summary>
    /// The question or instruction for the AI to analyze the image.
    /// </summary>
    public required string Instruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("instruction");
        }
        init { this._rawData.Set("instruction", value); }
    }

    /// <summary>
    /// Task type that analyzes the image and adds matching tags from a vocabulary.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Maximum number of tags to select from the vocabulary.
    /// </summary>
    public long? MaxSelections
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_selections");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("max_selections", value);
        }
    }

    /// <summary>
    /// Minimum number of tags to select from the vocabulary.
    /// </summary>
    public long? MinSelections
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("min_selections");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("min_selections", value);
        }
    }

    /// <summary>
    /// Array of possible tag values. Combined length of all strings must not exceed
    /// 500 characters. Cannot contain the `%` character.
    /// </summary>
    public IReadOnlyList<string>? Vocabulary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("vocabulary");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "vocabulary",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Instruction;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("select_tags")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.MaxSelections;
        _ = this.MinSelections;
        _ = this.Vocabulary;
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
    {
        this.Type = JsonSerializer.SerializeToElement("select_tags");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AITasksTaskSelectTags(
        UnnamedSchemaWithArrayParent0AITasksTaskSelectTags unnamedSchemaWithArrayParent0AITasksTaskSelectTags
    )
        : base(unnamedSchemaWithArrayParent0AITasksTaskSelectTags) { }
#pragma warning restore CS8618

    public UnnamedSchemaWithArrayParent0AITasksTaskSelectTags(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("select_tags");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnnamedSchemaWithArrayParent0AITasksTaskSelectTags(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnnamedSchemaWithArrayParent0AITasksTaskSelectTagsFromRaw.FromRawUnchecked"/>
    public static UnnamedSchemaWithArrayParent0AITasksTaskSelectTags FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AITasksTaskSelectTags(string instruction)
        : this()
    {
        this.Instruction = instruction;
    }
}

class UnnamedSchemaWithArrayParent0AITasksTaskSelectTagsFromRaw
    : IFromRawJson<UnnamedSchemaWithArrayParent0AITasksTaskSelectTags>
{
    /// <inheritdoc/>
    public UnnamedSchemaWithArrayParent0AITasksTaskSelectTags FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnnamedSchemaWithArrayParent0AITasksTaskSelectTags.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata,
        UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataFromRaw
    >)
)]
public sealed record class UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata : JsonModel
{
    /// <summary>
    /// Name of the custom metadata field to set. The field must exist in your account.
    /// </summary>
    public required string Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// The question or instruction for the AI to analyze the image.
    /// </summary>
    public required string Instruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("instruction");
        }
        init { this._rawData.Set("instruction", value); }
    }

    /// <summary>
    /// Task type that analyzes the image and sets a custom metadata field value from
    /// a vocabulary.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Maximum number of values to select from the vocabulary.
    /// </summary>
    public long? MaxSelections
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_selections");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("max_selections", value);
        }
    }

    /// <summary>
    /// Minimum number of values to select from the vocabulary.
    /// </summary>
    public long? MinSelections
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("min_selections");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("min_selections", value);
        }
    }

    /// <summary>
    /// Array of possible values matching the custom metadata field type.
    /// </summary>
    public IReadOnlyList<UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary>? Vocabulary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary>
            >("vocabulary");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary>?>(
                "vocabulary",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Field;
        _ = this.Instruction;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("select_metadata"))
        )
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.MaxSelections;
        _ = this.MinSelections;
        foreach (var item in this.Vocabulary ?? [])
        {
            item.Validate();
        }
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata()
    {
        this.Type = JsonSerializer.SerializeToElement("select_metadata");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata(
        UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata unnamedSchemaWithArrayParent0AITasksTaskSelectMetadata
    )
        : base(unnamedSchemaWithArrayParent0AITasksTaskSelectMetadata) { }
#pragma warning restore CS8618

    public UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("select_metadata");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataFromRaw.FromRawUnchecked"/>
    public static UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataFromRaw
    : IFromRawJson<UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata>
{
    /// <inheritdoc/>
    public UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabularyConverter))]
public record class UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary(
        bool value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<string> @string, Action<double> @double, Action<bool> @bool)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<string, T> @string, Func<double, T> @double, Func<bool, T> @bool)
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary"
            ),
        };
    }

    public static implicit operator UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary(
        string value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary(
        double value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary(
        bool value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary"
            );
        }
    }

    public virtual bool Equals(
        UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary? other
    ) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            string _ => 0,
            double _ => 1,
            bool _ => 2,
            _ => -1,
        };
    }
}

sealed class UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabularyConverter
    : JsonConverter<UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary>
{
    public override UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent0AITasksTaskSelectMetadataVocabulary value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnnamedSchemaWithArrayParent0AITasksTaskYesNo,
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoFromRaw
    >)
)]
public sealed record class UnnamedSchemaWithArrayParent0AITasksTaskYesNo : JsonModel
{
    /// <summary>
    /// The yes/no question for the AI to answer about the image.
    /// </summary>
    public required string Instruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("instruction");
        }
        init { this._rawData.Set("instruction", value); }
    }

    /// <summary>
    /// Task type that asks a yes/no question and executes actions based on the answer.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Actions to execute if the AI answers no.
    /// </summary>
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo? OnNo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo>(
                "on_no"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_no", value);
        }
    }

    /// <summary>
    /// Actions to execute if the AI cannot determine the answer.
    /// </summary>
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown? OnUnknown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown>(
                "on_unknown"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_unknown", value);
        }
    }

    /// <summary>
    /// Actions to execute if the AI answers yes.
    /// </summary>
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes? OnYes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes>(
                "on_yes"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_yes", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Instruction;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("yes_no")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        this.OnNo?.Validate();
        this.OnUnknown?.Validate();
        this.OnYes?.Validate();
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNo()
    {
        this.Type = JsonSerializer.SerializeToElement("yes_no");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNo(
        UnnamedSchemaWithArrayParent0AITasksTaskYesNo unnamedSchemaWithArrayParent0AITasksTaskYesNo
    )
        : base(unnamedSchemaWithArrayParent0AITasksTaskYesNo) { }
#pragma warning restore CS8618

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNo(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("yes_no");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnnamedSchemaWithArrayParent0AITasksTaskYesNo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnnamedSchemaWithArrayParent0AITasksTaskYesNoFromRaw.FromRawUnchecked"/>
    public static UnnamedSchemaWithArrayParent0AITasksTaskYesNo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNo(string instruction)
        : this()
    {
        this.Instruction = instruction;
    }
}

class UnnamedSchemaWithArrayParent0AITasksTaskYesNoFromRaw
    : IFromRawJson<UnnamedSchemaWithArrayParent0AITasksTaskYesNo>
{
    /// <inheritdoc/>
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnnamedSchemaWithArrayParent0AITasksTaskYesNo.FromRawUnchecked(rawData);
}

/// <summary>
/// Actions to execute if the AI answers no.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo,
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoFromRaw
    >)
)]
public sealed record class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo : JsonModel
{
    /// <summary>
    /// Array of tag strings to add to the asset.
    /// </summary>
    public IReadOnlyList<string>? AddTags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("add_tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "add_tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of tag strings to remove from the asset.
    /// </summary>
    public IReadOnlyList<string>? RemoveTags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("remove_tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "remove_tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of custom metadata field updates.
    /// </summary>
    public IReadOnlyList<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata>? SetMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata>
            >("set_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata>?>(
                "set_metadata",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of custom metadata fields to remove.
    /// </summary>
    public IReadOnlyList<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata>? UnsetMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata>
            >("unset_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata>?>(
                "unset_metadata",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddTags;
        _ = this.RemoveTags;
        foreach (var item in this.SetMetadata ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.UnsetMetadata ?? [])
        {
            item.Validate();
        }
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo(
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo unnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo
    )
        : base(unnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo) { }
#pragma warning restore CS8618

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoFromRaw.FromRawUnchecked"/>
    public static UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoFromRaw
    : IFromRawJson<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo>
{
    /// <inheritdoc/>
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNo.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata,
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataFromRaw
    >)
)]
public sealed record class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata : JsonModel
{
    /// <summary>
    /// Name of the custom metadata field to set.
    /// </summary>
    public required string Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Value to set for the custom metadata field. The value type should match the
    /// custom metadata field type.
    /// </summary>
    public required UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Field;
        this.Value.Validate();
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata(
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata unnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata
    )
        : base(unnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata) { }
#pragma warning restore CS8618

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataFromRaw.FromRawUnchecked"/>
    public static UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataFromRaw
    : IFromRawJson<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata>
{
    /// <inheritdoc/>
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Value to set for the custom metadata field. The value type should match the custom
/// metadata field type.
/// </summary>
[JsonConverter(typeof(UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValueConverter))]
public record class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue(
        bool value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue(
        IReadOnlyList<UnnamedSchemaWithArrayParent6> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<UnnamedSchemaWithArrayParent6>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMixed(out var value)) {
    ///     // `value` is of type `IReadOnlyList<UnnamedSchemaWithArrayParent6>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMixed(
        [NotNullWhen(true)] out IReadOnlyList<UnnamedSchemaWithArrayParent6>? value
    )
    {
        value = this.Value as IReadOnlyList<UnnamedSchemaWithArrayParent6>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...},
    ///     (IReadOnlyList<UnnamedSchemaWithArrayParent6> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<string> @string,
        Action<double> @double,
        Action<bool> @bool,
        Action<IReadOnlyList<UnnamedSchemaWithArrayParent6>> mixed
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            case IReadOnlyList<UnnamedSchemaWithArrayParent6> value:
                mixed(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...},
    ///     (IReadOnlyList<UnnamedSchemaWithArrayParent6> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<string, T> @string,
        Func<double, T> @double,
        Func<bool, T> @bool,
        Func<IReadOnlyList<UnnamedSchemaWithArrayParent6>, T> mixed
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            IReadOnlyList<UnnamedSchemaWithArrayParent6> value => mixed(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue"
            ),
        };
    }

    public static implicit operator UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue(
        string value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue(
        double value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue(
        bool value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue(
        List<UnnamedSchemaWithArrayParent6> value
    ) => new((IReadOnlyList<UnnamedSchemaWithArrayParent6>)value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue"
            );
        }
        this.Switch(
            (_) => { },
            (_) => { },
            (_) => { },
            (mixed) =>
            {
                foreach (var item in mixed)
                {
                    item.Validate();
                }
            }
        );
    }

    public virtual bool Equals(
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue? other
    ) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            string _ => 0,
            double _ => 1,
            bool _ => 2,
            IReadOnlyList<UnnamedSchemaWithArrayParent6> _ => 3,
            _ => -1,
        };
    }
}

sealed class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValueConverter
    : JsonConverter<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue>
{
    public override UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<UnnamedSchemaWithArrayParent6>>(
                element,
                options
            );
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoSetMetadataValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(UnnamedSchemaWithArrayParent6Converter))]
public record class UnnamedSchemaWithArrayParent6 : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public UnnamedSchemaWithArrayParent6(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent6(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent6(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent6(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<string> @string, Action<double> @double, Action<bool> @bool)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UnnamedSchemaWithArrayParent6"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<string, T> @string, Func<double, T> @double, Func<bool, T> @bool)
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent6"
            ),
        };
    }

    public static implicit operator UnnamedSchemaWithArrayParent6(string value) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent6(double value) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent6(bool value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent6"
            );
        }
    }

    public virtual bool Equals(UnnamedSchemaWithArrayParent6? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            string _ => 0,
            double _ => 1,
            bool _ => 2,
            _ => -1,
        };
    }
}

sealed class UnnamedSchemaWithArrayParent6Converter : JsonConverter<UnnamedSchemaWithArrayParent6>
{
    public override UnnamedSchemaWithArrayParent6? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent6 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata,
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadataFromRaw
    >)
)]
public sealed record class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata
    : JsonModel
{
    /// <summary>
    /// Name of the custom metadata field to remove.
    /// </summary>
    public required string Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Field;
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata(
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata unnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata
    )
        : base(unnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata) { }
#pragma warning restore CS8618

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadataFromRaw.FromRawUnchecked"/>
    public static UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata(string field)
        : this()
    {
        this.Field = field;
    }
}

class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadataFromRaw
    : IFromRawJson<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata>
{
    /// <inheritdoc/>
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnNoUnsetMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Actions to execute if the AI cannot determine the answer.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown,
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownFromRaw
    >)
)]
public sealed record class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown : JsonModel
{
    /// <summary>
    /// Array of tag strings to add to the asset.
    /// </summary>
    public IReadOnlyList<string>? AddTags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("add_tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "add_tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of tag strings to remove from the asset.
    /// </summary>
    public IReadOnlyList<string>? RemoveTags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("remove_tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "remove_tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of custom metadata field updates.
    /// </summary>
    public IReadOnlyList<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata>? SetMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata>
            >("set_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata>?>(
                "set_metadata",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of custom metadata fields to remove.
    /// </summary>
    public IReadOnlyList<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata>? UnsetMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata>
            >("unset_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata>?>(
                "unset_metadata",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddTags;
        _ = this.RemoveTags;
        foreach (var item in this.SetMetadata ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.UnsetMetadata ?? [])
        {
            item.Validate();
        }
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown(
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown unnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown
    )
        : base(unnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown) { }
#pragma warning restore CS8618

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownFromRaw.FromRawUnchecked"/>
    public static UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownFromRaw
    : IFromRawJson<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown>
{
    /// <inheritdoc/>
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknown.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata,
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataFromRaw
    >)
)]
public sealed record class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata
    : JsonModel
{
    /// <summary>
    /// Name of the custom metadata field to set.
    /// </summary>
    public required string Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Value to set for the custom metadata field. The value type should match the
    /// custom metadata field type.
    /// </summary>
    public required UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Field;
        this.Value.Validate();
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata(
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata unnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata
    )
        : base(unnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata) { }
#pragma warning restore CS8618

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataFromRaw.FromRawUnchecked"/>
    public static UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataFromRaw
    : IFromRawJson<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata>
{
    /// <inheritdoc/>
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Value to set for the custom metadata field. The value type should match the custom
/// metadata field type.
/// </summary>
[JsonConverter(
    typeof(UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValueConverter)
)]
public record class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue
    : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue(
        bool value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue(
        IReadOnlyList<UnnamedSchemaWithArrayParent7> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue(
        JsonElement element
    )
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<UnnamedSchemaWithArrayParent7>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMixed(out var value)) {
    ///     // `value` is of type `IReadOnlyList<UnnamedSchemaWithArrayParent7>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMixed(
        [NotNullWhen(true)] out IReadOnlyList<UnnamedSchemaWithArrayParent7>? value
    )
    {
        value = this.Value as IReadOnlyList<UnnamedSchemaWithArrayParent7>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...},
    ///     (IReadOnlyList<UnnamedSchemaWithArrayParent7> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<string> @string,
        Action<double> @double,
        Action<bool> @bool,
        Action<IReadOnlyList<UnnamedSchemaWithArrayParent7>> mixed
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            case IReadOnlyList<UnnamedSchemaWithArrayParent7> value:
                mixed(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...},
    ///     (IReadOnlyList<UnnamedSchemaWithArrayParent7> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<string, T> @string,
        Func<double, T> @double,
        Func<bool, T> @bool,
        Func<IReadOnlyList<UnnamedSchemaWithArrayParent7>, T> mixed
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            IReadOnlyList<UnnamedSchemaWithArrayParent7> value => mixed(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue"
            ),
        };
    }

    public static implicit operator UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue(
        string value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue(
        double value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue(
        bool value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue(
        List<UnnamedSchemaWithArrayParent7> value
    ) => new((IReadOnlyList<UnnamedSchemaWithArrayParent7>)value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue"
            );
        }
        this.Switch(
            (_) => { },
            (_) => { },
            (_) => { },
            (mixed) =>
            {
                foreach (var item in mixed)
                {
                    item.Validate();
                }
            }
        );
    }

    public virtual bool Equals(
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue? other
    ) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            string _ => 0,
            double _ => 1,
            bool _ => 2,
            IReadOnlyList<UnnamedSchemaWithArrayParent7> _ => 3,
            _ => -1,
        };
    }
}

sealed class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValueConverter
    : JsonConverter<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue>
{
    public override UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<UnnamedSchemaWithArrayParent7>>(
                element,
                options
            );
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownSetMetadataValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(UnnamedSchemaWithArrayParent7Converter))]
public record class UnnamedSchemaWithArrayParent7 : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public UnnamedSchemaWithArrayParent7(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent7(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent7(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent7(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<string> @string, Action<double> @double, Action<bool> @bool)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UnnamedSchemaWithArrayParent7"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<string, T> @string, Func<double, T> @double, Func<bool, T> @bool)
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent7"
            ),
        };
    }

    public static implicit operator UnnamedSchemaWithArrayParent7(string value) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent7(double value) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent7(bool value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent7"
            );
        }
    }

    public virtual bool Equals(UnnamedSchemaWithArrayParent7? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            string _ => 0,
            double _ => 1,
            bool _ => 2,
            _ => -1,
        };
    }
}

sealed class UnnamedSchemaWithArrayParent7Converter : JsonConverter<UnnamedSchemaWithArrayParent7>
{
    public override UnnamedSchemaWithArrayParent7? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent7 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata,
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadataFromRaw
    >)
)]
public sealed record class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata
    : JsonModel
{
    /// <summary>
    /// Name of the custom metadata field to remove.
    /// </summary>
    public required string Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Field;
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata(
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata unnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata
    )
        : base(unnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata) { }
#pragma warning restore CS8618

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadataFromRaw.FromRawUnchecked"/>
    public static UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata(string field)
        : this()
    {
        this.Field = field;
    }
}

class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadataFromRaw
    : IFromRawJson<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata>
{
    /// <inheritdoc/>
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnUnknownUnsetMetadata.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Actions to execute if the AI answers yes.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes,
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesFromRaw
    >)
)]
public sealed record class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes : JsonModel
{
    /// <summary>
    /// Array of tag strings to add to the asset.
    /// </summary>
    public IReadOnlyList<string>? AddTags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("add_tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "add_tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of tag strings to remove from the asset.
    /// </summary>
    public IReadOnlyList<string>? RemoveTags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("remove_tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "remove_tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of custom metadata field updates.
    /// </summary>
    public IReadOnlyList<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata>? SetMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata>
            >("set_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata>?>(
                "set_metadata",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of custom metadata fields to remove.
    /// </summary>
    public IReadOnlyList<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata>? UnsetMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata>
            >("unset_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata>?>(
                "unset_metadata",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddTags;
        _ = this.RemoveTags;
        foreach (var item in this.SetMetadata ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.UnsetMetadata ?? [])
        {
            item.Validate();
        }
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes(
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes unnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes
    )
        : base(unnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes) { }
#pragma warning restore CS8618

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesFromRaw.FromRawUnchecked"/>
    public static UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesFromRaw
    : IFromRawJson<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes>
{
    /// <inheritdoc/>
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYes.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata,
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataFromRaw
    >)
)]
public sealed record class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata : JsonModel
{
    /// <summary>
    /// Name of the custom metadata field to set.
    /// </summary>
    public required string Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Value to set for the custom metadata field. The value type should match the
    /// custom metadata field type.
    /// </summary>
    public required UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Field;
        this.Value.Validate();
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata(
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata unnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata
    )
        : base(unnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata) { }
#pragma warning restore CS8618

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataFromRaw.FromRawUnchecked"/>
    public static UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataFromRaw
    : IFromRawJson<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata>
{
    /// <inheritdoc/>
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Value to set for the custom metadata field. The value type should match the custom
/// metadata field type.
/// </summary>
[JsonConverter(typeof(UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValueConverter))]
public record class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue(
        bool value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue(
        IReadOnlyList<UnnamedSchemaWithArrayParent8> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<UnnamedSchemaWithArrayParent8>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMixed(out var value)) {
    ///     // `value` is of type `IReadOnlyList<UnnamedSchemaWithArrayParent8>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMixed(
        [NotNullWhen(true)] out IReadOnlyList<UnnamedSchemaWithArrayParent8>? value
    )
    {
        value = this.Value as IReadOnlyList<UnnamedSchemaWithArrayParent8>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...},
    ///     (IReadOnlyList<UnnamedSchemaWithArrayParent8> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<string> @string,
        Action<double> @double,
        Action<bool> @bool,
        Action<IReadOnlyList<UnnamedSchemaWithArrayParent8>> mixed
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            case IReadOnlyList<UnnamedSchemaWithArrayParent8> value:
                mixed(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...},
    ///     (IReadOnlyList<UnnamedSchemaWithArrayParent8> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<string, T> @string,
        Func<double, T> @double,
        Func<bool, T> @bool,
        Func<IReadOnlyList<UnnamedSchemaWithArrayParent8>, T> mixed
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            IReadOnlyList<UnnamedSchemaWithArrayParent8> value => mixed(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue"
            ),
        };
    }

    public static implicit operator UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue(
        string value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue(
        double value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue(
        bool value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue(
        List<UnnamedSchemaWithArrayParent8> value
    ) => new((IReadOnlyList<UnnamedSchemaWithArrayParent8>)value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue"
            );
        }
        this.Switch(
            (_) => { },
            (_) => { },
            (_) => { },
            (mixed) =>
            {
                foreach (var item in mixed)
                {
                    item.Validate();
                }
            }
        );
    }

    public virtual bool Equals(
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue? other
    ) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            string _ => 0,
            double _ => 1,
            bool _ => 2,
            IReadOnlyList<UnnamedSchemaWithArrayParent8> _ => 3,
            _ => -1,
        };
    }
}

sealed class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValueConverter
    : JsonConverter<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue>
{
    public override UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<UnnamedSchemaWithArrayParent8>>(
                element,
                options
            );
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesSetMetadataValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(UnnamedSchemaWithArrayParent8Converter))]
public record class UnnamedSchemaWithArrayParent8 : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public UnnamedSchemaWithArrayParent8(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent8(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent8(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent8(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<string> @string, Action<double> @double, Action<bool> @bool)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UnnamedSchemaWithArrayParent8"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) => {...},
    ///     (double value) => {...},
    ///     (bool value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<string, T> @string, Func<double, T> @double, Func<bool, T> @bool)
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent8"
            ),
        };
    }

    public static implicit operator UnnamedSchemaWithArrayParent8(string value) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent8(double value) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent8(bool value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent8"
            );
        }
    }

    public virtual bool Equals(UnnamedSchemaWithArrayParent8? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            string _ => 0,
            double _ => 1,
            bool _ => 2,
            _ => -1,
        };
    }
}

sealed class UnnamedSchemaWithArrayParent8Converter : JsonConverter<UnnamedSchemaWithArrayParent8>
{
    public override UnnamedSchemaWithArrayParent8? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent8 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata,
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadataFromRaw
    >)
)]
public sealed record class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata
    : JsonModel
{
    /// <summary>
    /// Name of the custom metadata field to remove.
    /// </summary>
    public required string Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Field;
    }

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata(
        UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata unnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata
    )
        : base(unnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata) { }
#pragma warning restore CS8618

    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadataFromRaw.FromRawUnchecked"/>
    public static UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata(string field)
        : this()
    {
        this.Field = field;
    }
}

class UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadataFromRaw
    : IFromRawJson<UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata>
{
    /// <inheritdoc/>
    public UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnnamedSchemaWithArrayParent0AITasksTaskYesNoOnYesUnsetMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SavedExtension, SavedExtensionFromRaw>))]
public sealed record class SavedExtension : JsonModel
{
    /// <summary>
    /// The unique ID of the saved extension to apply.
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
    /// Indicates this is a reference to a saved extension.
    /// </summary>
    public JsonElement Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        if (
            !JsonElement.DeepEquals(this.Name, JsonSerializer.SerializeToElement("saved-extension"))
        )
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public SavedExtension()
    {
        this.Name = JsonSerializer.SerializeToElement("saved-extension");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SavedExtension(SavedExtension savedExtension)
        : base(savedExtension) { }
#pragma warning restore CS8618

    public SavedExtension(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("saved-extension");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SavedExtension(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SavedExtensionFromRaw.FromRawUnchecked"/>
    public static SavedExtension FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SavedExtension(string id)
        : this()
    {
        this.ID = id;
    }
}

class SavedExtensionFromRaw : IFromRawJson<SavedExtension>
{
    /// <inheritdoc/>
    public SavedExtension FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SavedExtension.FromRawUnchecked(rawData);
}
