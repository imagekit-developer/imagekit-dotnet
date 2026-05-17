using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;

namespace Imagekit.Models;

[JsonConverter(typeof(ExtensionItemConverter))]
public record class ExtensionItem : ModelBase
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

    public ExtensionItem(ExtensionItemRemoveBg value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItem(ExtensionItemAutoTaggingExtension value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItem(ExtensionItemAIAutoDescription value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItem(ExtensionItemAITasks value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItem(SavedExtension value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItem(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExtensionItemRemoveBg"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRemoveBg(out var value)) {
    ///     // `value` is of type `ExtensionItemRemoveBg`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRemoveBg([NotNullWhen(true)] out ExtensionItemRemoveBg? value)
    {
        value = this.Value as ExtensionItemRemoveBg;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExtensionItemAutoTaggingExtension"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAutoTaggingExtension(out var value)) {
    ///     // `value` is of type `ExtensionItemAutoTaggingExtension`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAutoTaggingExtension(
        [NotNullWhen(true)] out ExtensionItemAutoTaggingExtension? value
    )
    {
        value = this.Value as ExtensionItemAutoTaggingExtension;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExtensionItemAIAutoDescription"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAIAutoDescription(out var value)) {
    ///     // `value` is of type `ExtensionItemAIAutoDescription`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAIAutoDescription(
        [NotNullWhen(true)] out ExtensionItemAIAutoDescription? value
    )
    {
        value = this.Value as ExtensionItemAIAutoDescription;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExtensionItemAITasks"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAITasks(out var value)) {
    ///     // `value` is of type `ExtensionItemAITasks`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAITasks([NotNullWhen(true)] out ExtensionItemAITasks? value)
    {
        value = this.Value as ExtensionItemAITasks;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SavedExtension"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (ExtensionItemRemoveBg value) =&gt; {...},
    ///     (ExtensionItemAutoTaggingExtension value) =&gt; {...},
    ///     (ExtensionItemAIAutoDescription value) =&gt; {...},
    ///     (ExtensionItemAITasks value) =&gt; {...},
    ///     (SavedExtension value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<ExtensionItemRemoveBg> removeBg,
        Action<ExtensionItemAutoTaggingExtension> autoTaggingExtension,
        Action<ExtensionItemAIAutoDescription> aiAutoDescription,
        Action<ExtensionItemAITasks> aiTasks,
        Action<SavedExtension> savedExtension
    )
    {
        switch (this.Value)
        {
            case ExtensionItemRemoveBg value:
                removeBg(value);
                break;
            case ExtensionItemAutoTaggingExtension value:
                autoTaggingExtension(value);
                break;
            case ExtensionItemAIAutoDescription value:
                aiAutoDescription(value);
                break;
            case ExtensionItemAITasks value:
                aiTasks(value);
                break;
            case SavedExtension value:
                savedExtension(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of ExtensionItem"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (ExtensionItemRemoveBg value) =&gt; {...},
    ///     (ExtensionItemAutoTaggingExtension value) =&gt; {...},
    ///     (ExtensionItemAIAutoDescription value) =&gt; {...},
    ///     (ExtensionItemAITasks value) =&gt; {...},
    ///     (SavedExtension value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<ExtensionItemRemoveBg, T> removeBg,
        Func<ExtensionItemAutoTaggingExtension, T> autoTaggingExtension,
        Func<ExtensionItemAIAutoDescription, T> aiAutoDescription,
        Func<ExtensionItemAITasks, T> aiTasks,
        Func<SavedExtension, T> savedExtension
    )
    {
        return this.Value switch
        {
            ExtensionItemRemoveBg value => removeBg(value),
            ExtensionItemAutoTaggingExtension value => autoTaggingExtension(value),
            ExtensionItemAIAutoDescription value => aiAutoDescription(value),
            ExtensionItemAITasks value => aiTasks(value),
            SavedExtension value => savedExtension(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of ExtensionItem"
            ),
        };
    }

    public static implicit operator ExtensionItem(ExtensionItemRemoveBg value) => new(value);

    public static implicit operator ExtensionItem(ExtensionItemAutoTaggingExtension value) =>
        new(value);

    public static implicit operator ExtensionItem(ExtensionItemAIAutoDescription value) =>
        new(value);

    public static implicit operator ExtensionItem(ExtensionItemAITasks value) => new(value);

    public static implicit operator ExtensionItem(SavedExtension value) => new(value);

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
                "Data did not match any variant of ExtensionItem"
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

    public virtual bool Equals(ExtensionItem? other) =>
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
            ExtensionItemRemoveBg _ => 0,
            ExtensionItemAutoTaggingExtension _ => 1,
            ExtensionItemAIAutoDescription _ => 2,
            ExtensionItemAITasks _ => 3,
            SavedExtension _ => 4,
            _ => -1,
        };
    }
}

sealed class ExtensionItemConverter : JsonConverter<ExtensionItem>
{
    public override ExtensionItem? Read(
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
                    var deserialized = JsonSerializer.Deserialize<ExtensionItemRemoveBg>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "ai-auto-description":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ExtensionItemAIAutoDescription>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "ai-tasks":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasks>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        JsonSerializer.Deserialize<ExtensionItemAutoTaggingExtension>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtensionItem value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<ExtensionItemRemoveBg, ExtensionItemRemoveBgFromRaw>))]
public sealed record class ExtensionItemRemoveBg : JsonModel
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

    public ExtensionItemRemoveBgOptions? Options
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExtensionItemRemoveBgOptions>("options");
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

    public ExtensionItemRemoveBg()
    {
        this.Name = JsonSerializer.SerializeToElement("remove-bg");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtensionItemRemoveBg(ExtensionItemRemoveBg extensionItemRemoveBg)
        : base(extensionItemRemoveBg) { }
#pragma warning restore CS8618

    public ExtensionItemRemoveBg(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("remove-bg");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtensionItemRemoveBg(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtensionItemRemoveBgFromRaw.FromRawUnchecked"/>
    public static ExtensionItemRemoveBg FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtensionItemRemoveBgFromRaw : IFromRawJson<ExtensionItemRemoveBg>
{
    /// <inheritdoc/>
    public ExtensionItemRemoveBg FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtensionItemRemoveBg.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<ExtensionItemRemoveBgOptions, ExtensionItemRemoveBgOptionsFromRaw>)
)]
public sealed record class ExtensionItemRemoveBgOptions : JsonModel
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

    public ExtensionItemRemoveBgOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtensionItemRemoveBgOptions(ExtensionItemRemoveBgOptions extensionItemRemoveBgOptions)
        : base(extensionItemRemoveBgOptions) { }
#pragma warning restore CS8618

    public ExtensionItemRemoveBgOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtensionItemRemoveBgOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtensionItemRemoveBgOptionsFromRaw.FromRawUnchecked"/>
    public static ExtensionItemRemoveBgOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtensionItemRemoveBgOptionsFromRaw : IFromRawJson<ExtensionItemRemoveBgOptions>
{
    /// <inheritdoc/>
    public ExtensionItemRemoveBgOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtensionItemRemoveBgOptions.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ExtensionItemAutoTaggingExtension,
        ExtensionItemAutoTaggingExtensionFromRaw
    >)
)]
public sealed record class ExtensionItemAutoTaggingExtension : JsonModel
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
    public required ApiEnum<string, ExtensionItemAutoTaggingExtensionName> Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ExtensionItemAutoTaggingExtensionName>
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

    public ExtensionItemAutoTaggingExtension() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtensionItemAutoTaggingExtension(
        ExtensionItemAutoTaggingExtension extensionItemAutoTaggingExtension
    )
        : base(extensionItemAutoTaggingExtension) { }
#pragma warning restore CS8618

    public ExtensionItemAutoTaggingExtension(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtensionItemAutoTaggingExtension(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtensionItemAutoTaggingExtensionFromRaw.FromRawUnchecked"/>
    public static ExtensionItemAutoTaggingExtension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtensionItemAutoTaggingExtensionFromRaw : IFromRawJson<ExtensionItemAutoTaggingExtension>
{
    /// <inheritdoc/>
    public ExtensionItemAutoTaggingExtension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtensionItemAutoTaggingExtension.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the auto-tagging extension used.
/// </summary>
[JsonConverter(typeof(ExtensionItemAutoTaggingExtensionNameConverter))]
public enum ExtensionItemAutoTaggingExtensionName
{
    GoogleAutoTagging,
    AwsAutoTagging,
}

sealed class ExtensionItemAutoTaggingExtensionNameConverter
    : JsonConverter<ExtensionItemAutoTaggingExtensionName>
{
    public override ExtensionItemAutoTaggingExtensionName Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "google-auto-tagging" => ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging,
            "aws-auto-tagging" => ExtensionItemAutoTaggingExtensionName.AwsAutoTagging,
            _ => (ExtensionItemAutoTaggingExtensionName)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtensionItemAutoTaggingExtensionName value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging => "google-auto-tagging",
                ExtensionItemAutoTaggingExtensionName.AwsAutoTagging => "aws-auto-tagging",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ExtensionItemAIAutoDescriptionConverter))]
public record class ExtensionItemAIAutoDescription
{
    public JsonElement Element { get; private init; }

    public ExtensionItemAIAutoDescription()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "name": "ai-auto-description"
            }
            """
        );
    }

    internal ExtensionItemAIAutoDescription(JsonElement element)
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
        if (this != new ExtensionItemAIAutoDescription())
        {
            throw new ImageKitInvalidDataException(
                "Invalid value given for 'ExtensionItemAIAutoDescription'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(ExtensionItemAIAutoDescription? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class ExtensionItemAIAutoDescriptionConverter : JsonConverter<ExtensionItemAIAutoDescription>
{
    public override ExtensionItemAIAutoDescription? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtensionItemAIAutoDescription value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<ExtensionItemAITasks, ExtensionItemAITasksFromRaw>))]
public sealed record class ExtensionItemAITasks : JsonModel
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
    public required IReadOnlyList<ExtensionItemAITasksTask> Tasks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ExtensionItemAITasksTask>>(
                "tasks"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ExtensionItemAITasksTask>>(
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

    public ExtensionItemAITasks()
    {
        this.Name = JsonSerializer.SerializeToElement("ai-tasks");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtensionItemAITasks(ExtensionItemAITasks extensionItemAITasks)
        : base(extensionItemAITasks) { }
#pragma warning restore CS8618

    public ExtensionItemAITasks(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("ai-tasks");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtensionItemAITasks(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtensionItemAITasksFromRaw.FromRawUnchecked"/>
    public static ExtensionItemAITasks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExtensionItemAITasks(IReadOnlyList<ExtensionItemAITasksTask> tasks)
        : this()
    {
        this.Tasks = tasks;
    }
}

class ExtensionItemAITasksFromRaw : IFromRawJson<ExtensionItemAITasks>
{
    /// <inheritdoc/>
    public ExtensionItemAITasks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtensionItemAITasks.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ExtensionItemAITasksTaskConverter))]
public record class ExtensionItemAITasksTask : ModelBase
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

    public ExtensionItemAITasksTask(
        ExtensionItemAITasksTaskSelectTags value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTask(
        ExtensionItemAITasksTaskSelectMetadata value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTask(
        ExtensionItemAITasksTaskYesNo value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTask(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExtensionItemAITasksTaskSelectTags"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSelectTags(out var value)) {
    ///     // `value` is of type `ExtensionItemAITasksTaskSelectTags`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSelectTags([NotNullWhen(true)] out ExtensionItemAITasksTaskSelectTags? value)
    {
        value = this.Value as ExtensionItemAITasksTaskSelectTags;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExtensionItemAITasksTaskSelectMetadata"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSelectMetadata(out var value)) {
    ///     // `value` is of type `ExtensionItemAITasksTaskSelectMetadata`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSelectMetadata(
        [NotNullWhen(true)] out ExtensionItemAITasksTaskSelectMetadata? value
    )
    {
        value = this.Value as ExtensionItemAITasksTaskSelectMetadata;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExtensionItemAITasksTaskYesNo"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickYesNo(out var value)) {
    ///     // `value` is of type `ExtensionItemAITasksTaskYesNo`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickYesNo([NotNullWhen(true)] out ExtensionItemAITasksTaskYesNo? value)
    {
        value = this.Value as ExtensionItemAITasksTaskYesNo;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (ExtensionItemAITasksTaskSelectTags value) =&gt; {...},
    ///     (ExtensionItemAITasksTaskSelectMetadata value) =&gt; {...},
    ///     (ExtensionItemAITasksTaskYesNo value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<ExtensionItemAITasksTaskSelectTags> selectTags,
        Action<ExtensionItemAITasksTaskSelectMetadata> selectMetadata,
        Action<ExtensionItemAITasksTaskYesNo> yesNo
    )
    {
        switch (this.Value)
        {
            case ExtensionItemAITasksTaskSelectTags value:
                selectTags(value);
                break;
            case ExtensionItemAITasksTaskSelectMetadata value:
                selectMetadata(value);
                break;
            case ExtensionItemAITasksTaskYesNo value:
                yesNo(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of ExtensionItemAITasksTask"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (ExtensionItemAITasksTaskSelectTags value) =&gt; {...},
    ///     (ExtensionItemAITasksTaskSelectMetadata value) =&gt; {...},
    ///     (ExtensionItemAITasksTaskYesNo value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<ExtensionItemAITasksTaskSelectTags, T> selectTags,
        Func<ExtensionItemAITasksTaskSelectMetadata, T> selectMetadata,
        Func<ExtensionItemAITasksTaskYesNo, T> yesNo
    )
    {
        return this.Value switch
        {
            ExtensionItemAITasksTaskSelectTags value => selectTags(value),
            ExtensionItemAITasksTaskSelectMetadata value => selectMetadata(value),
            ExtensionItemAITasksTaskYesNo value => yesNo(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of ExtensionItemAITasksTask"
            ),
        };
    }

    public static implicit operator ExtensionItemAITasksTask(
        ExtensionItemAITasksTaskSelectTags value
    ) => new(value);

    public static implicit operator ExtensionItemAITasksTask(
        ExtensionItemAITasksTaskSelectMetadata value
    ) => new(value);

    public static implicit operator ExtensionItemAITasksTask(ExtensionItemAITasksTaskYesNo value) =>
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
                "Data did not match any variant of ExtensionItemAITasksTask"
            );
        }
        this.Switch(
            (selectTags) => selectTags.Validate(),
            (selectMetadata) => selectMetadata.Validate(),
            (yesNo) => yesNo.Validate()
        );
    }

    public virtual bool Equals(ExtensionItemAITasksTask? other) =>
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
            ExtensionItemAITasksTaskSelectTags _ => 0,
            ExtensionItemAITasksTaskSelectMetadata _ => 1,
            ExtensionItemAITasksTaskYesNo _ => 2,
            _ => -1,
        };
    }
}

sealed class ExtensionItemAITasksTaskConverter : JsonConverter<ExtensionItemAITasksTask>
{
    public override ExtensionItemAITasksTask? Read(
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
                        JsonSerializer.Deserialize<ExtensionItemAITasksTaskSelectTags>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        JsonSerializer.Deserialize<ExtensionItemAITasksTaskSelectMetadata>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "yes_no":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ExtensionItemAITasksTaskYesNo>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ExtensionItemAITasksTask(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtensionItemAITasksTask value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ExtensionItemAITasksTaskSelectTags,
        ExtensionItemAITasksTaskSelectTagsFromRaw
    >)
)]
public sealed record class ExtensionItemAITasksTaskSelectTags : JsonModel
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
    /// Array of possible tag values. The combined length of all strings must not
    /// exceed 500 characters, and values cannot include the `%` character. When
    /// providing large vocabularies (more than 30 items), the AI may not follow
    /// the list strictly.
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

    public ExtensionItemAITasksTaskSelectTags()
    {
        this.Type = JsonSerializer.SerializeToElement("select_tags");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtensionItemAITasksTaskSelectTags(
        ExtensionItemAITasksTaskSelectTags extensionItemAITasksTaskSelectTags
    )
        : base(extensionItemAITasksTaskSelectTags) { }
#pragma warning restore CS8618

    public ExtensionItemAITasksTaskSelectTags(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("select_tags");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtensionItemAITasksTaskSelectTags(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtensionItemAITasksTaskSelectTagsFromRaw.FromRawUnchecked"/>
    public static ExtensionItemAITasksTaskSelectTags FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExtensionItemAITasksTaskSelectTags(string instruction)
        : this()
    {
        this.Instruction = instruction;
    }
}

class ExtensionItemAITasksTaskSelectTagsFromRaw : IFromRawJson<ExtensionItemAITasksTaskSelectTags>
{
    /// <inheritdoc/>
    public ExtensionItemAITasksTaskSelectTags FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtensionItemAITasksTaskSelectTags.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ExtensionItemAITasksTaskSelectMetadata,
        ExtensionItemAITasksTaskSelectMetadataFromRaw
    >)
)]
public sealed record class ExtensionItemAITasksTaskSelectMetadata : JsonModel
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
    /// An array of possible values matching the custom metadata field type. If not
    /// provided for SingleSelect or MultiSelect field types, all values from the
    /// custom metadata field definition will be used. When providing large vocabularies
    /// (above 30 items), the AI may not strictly adhere to the list.
    /// </summary>
    public IReadOnlyList<ExtensionItemAITasksTaskSelectMetadataVocabulary>? Vocabulary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ExtensionItemAITasksTaskSelectMetadataVocabulary>
            >("vocabulary");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ExtensionItemAITasksTaskSelectMetadataVocabulary>?>(
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

    public ExtensionItemAITasksTaskSelectMetadata()
    {
        this.Type = JsonSerializer.SerializeToElement("select_metadata");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtensionItemAITasksTaskSelectMetadata(
        ExtensionItemAITasksTaskSelectMetadata extensionItemAITasksTaskSelectMetadata
    )
        : base(extensionItemAITasksTaskSelectMetadata) { }
#pragma warning restore CS8618

    public ExtensionItemAITasksTaskSelectMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("select_metadata");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtensionItemAITasksTaskSelectMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtensionItemAITasksTaskSelectMetadataFromRaw.FromRawUnchecked"/>
    public static ExtensionItemAITasksTaskSelectMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtensionItemAITasksTaskSelectMetadataFromRaw
    : IFromRawJson<ExtensionItemAITasksTaskSelectMetadata>
{
    /// <inheritdoc/>
    public ExtensionItemAITasksTaskSelectMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtensionItemAITasksTaskSelectMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ExtensionItemAITasksTaskSelectMetadataVocabularyConverter))]
public record class ExtensionItemAITasksTaskSelectMetadataVocabulary : ModelBase
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

    public ExtensionItemAITasksTaskSelectMetadataVocabulary(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskSelectMetadataVocabulary(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskSelectMetadataVocabulary(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskSelectMetadataVocabulary(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
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
                    "Data did not match any variant of ExtensionItemAITasksTaskSelectMetadataVocabulary"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
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
                "Data did not match any variant of ExtensionItemAITasksTaskSelectMetadataVocabulary"
            ),
        };
    }

    public static implicit operator ExtensionItemAITasksTaskSelectMetadataVocabulary(
        string value
    ) => new(value);

    public static implicit operator ExtensionItemAITasksTaskSelectMetadataVocabulary(
        double value
    ) => new(value);

    public static implicit operator ExtensionItemAITasksTaskSelectMetadataVocabulary(bool value) =>
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
                "Data did not match any variant of ExtensionItemAITasksTaskSelectMetadataVocabulary"
            );
        }
    }

    public virtual bool Equals(ExtensionItemAITasksTaskSelectMetadataVocabulary? other) =>
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

sealed class ExtensionItemAITasksTaskSelectMetadataVocabularyConverter
    : JsonConverter<ExtensionItemAITasksTaskSelectMetadataVocabulary>
{
    public override ExtensionItemAITasksTaskSelectMetadataVocabulary? Read(
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
        ExtensionItemAITasksTaskSelectMetadataVocabulary value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ExtensionItemAITasksTaskYesNo, ExtensionItemAITasksTaskYesNoFromRaw>)
)]
public sealed record class ExtensionItemAITasksTaskYesNo : JsonModel
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
    public ExtensionItemAITasksTaskYesNoOnNo? OnNo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExtensionItemAITasksTaskYesNoOnNo>("on_no");
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
    public ExtensionItemAITasksTaskYesNoOnUnknown? OnUnknown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExtensionItemAITasksTaskYesNoOnUnknown>(
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
    public ExtensionItemAITasksTaskYesNoOnYes? OnYes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExtensionItemAITasksTaskYesNoOnYes>("on_yes");
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

    public ExtensionItemAITasksTaskYesNo()
    {
        this.Type = JsonSerializer.SerializeToElement("yes_no");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtensionItemAITasksTaskYesNo(
        ExtensionItemAITasksTaskYesNo extensionItemAITasksTaskYesNo
    )
        : base(extensionItemAITasksTaskYesNo) { }
#pragma warning restore CS8618

    public ExtensionItemAITasksTaskYesNo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("yes_no");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtensionItemAITasksTaskYesNo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtensionItemAITasksTaskYesNoFromRaw.FromRawUnchecked"/>
    public static ExtensionItemAITasksTaskYesNo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExtensionItemAITasksTaskYesNo(string instruction)
        : this()
    {
        this.Instruction = instruction;
    }
}

class ExtensionItemAITasksTaskYesNoFromRaw : IFromRawJson<ExtensionItemAITasksTaskYesNo>
{
    /// <inheritdoc/>
    public ExtensionItemAITasksTaskYesNo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtensionItemAITasksTaskYesNo.FromRawUnchecked(rawData);
}

/// <summary>
/// Actions to execute if the AI answers no.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ExtensionItemAITasksTaskYesNoOnNo,
        ExtensionItemAITasksTaskYesNoOnNoFromRaw
    >)
)]
public sealed record class ExtensionItemAITasksTaskYesNoOnNo : JsonModel
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
    public IReadOnlyList<ExtensionItemAITasksTaskYesNoOnNoSetMetadata>? SetMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ExtensionItemAITasksTaskYesNoOnNoSetMetadata>
            >("set_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ExtensionItemAITasksTaskYesNoOnNoSetMetadata>?>(
                "set_metadata",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of custom metadata fields to remove.
    /// </summary>
    public IReadOnlyList<ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata>? UnsetMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata>
            >("unset_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata>?>(
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

    public ExtensionItemAITasksTaskYesNoOnNo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtensionItemAITasksTaskYesNoOnNo(
        ExtensionItemAITasksTaskYesNoOnNo extensionItemAITasksTaskYesNoOnNo
    )
        : base(extensionItemAITasksTaskYesNoOnNo) { }
#pragma warning restore CS8618

    public ExtensionItemAITasksTaskYesNoOnNo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtensionItemAITasksTaskYesNoOnNo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtensionItemAITasksTaskYesNoOnNoFromRaw.FromRawUnchecked"/>
    public static ExtensionItemAITasksTaskYesNoOnNo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtensionItemAITasksTaskYesNoOnNoFromRaw : IFromRawJson<ExtensionItemAITasksTaskYesNoOnNo>
{
    /// <inheritdoc/>
    public ExtensionItemAITasksTaskYesNoOnNo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtensionItemAITasksTaskYesNoOnNo.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ExtensionItemAITasksTaskYesNoOnNoSetMetadata,
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataFromRaw
    >)
)]
public sealed record class ExtensionItemAITasksTaskYesNoOnNoSetMetadata : JsonModel
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
    public required ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue>(
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

    public ExtensionItemAITasksTaskYesNoOnNoSetMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtensionItemAITasksTaskYesNoOnNoSetMetadata(
        ExtensionItemAITasksTaskYesNoOnNoSetMetadata extensionItemAITasksTaskYesNoOnNoSetMetadata
    )
        : base(extensionItemAITasksTaskYesNoOnNoSetMetadata) { }
#pragma warning restore CS8618

    public ExtensionItemAITasksTaskYesNoOnNoSetMetadata(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtensionItemAITasksTaskYesNoOnNoSetMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtensionItemAITasksTaskYesNoOnNoSetMetadataFromRaw.FromRawUnchecked"/>
    public static ExtensionItemAITasksTaskYesNoOnNoSetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtensionItemAITasksTaskYesNoOnNoSetMetadataFromRaw
    : IFromRawJson<ExtensionItemAITasksTaskYesNoOnNoSetMetadata>
{
    /// <inheritdoc/>
    public ExtensionItemAITasksTaskYesNoOnNoSetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtensionItemAITasksTaskYesNoOnNoSetMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Value to set for the custom metadata field. The value type should match the custom
/// metadata field type.
/// </summary>
[JsonConverter(typeof(ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueConverter))]
public record class ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue : ModelBase
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

    public ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue(
        bool value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue(
        IReadOnlyList<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMixed(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMixed(
        [NotNullWhen(true)]
            out IReadOnlyList<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem>? value
    )
    {
        value =
            this.Value
            as IReadOnlyList<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (IReadOnlyList&lt;ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<string> @string,
        Action<double> @double,
        Action<bool> @bool,
        Action<
            IReadOnlyList<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem>
        > mixed
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
            case IReadOnlyList<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem> value:
                mixed(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (IReadOnlyList&lt;ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<string, T> @string,
        Func<double, T> @double,
        Func<bool, T> @bool,
        Func<
            IReadOnlyList<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem>,
            T
        > mixed
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            IReadOnlyList<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem> value =>
                mixed(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue"
            ),
        };
    }

    public static implicit operator ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue(
        string value
    ) => new(value);

    public static implicit operator ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue(
        double value
    ) => new(value);

    public static implicit operator ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue(bool value) =>
        new(value);

    public static implicit operator ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue(
        List<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem> value
    ) =>
        new(
            (IReadOnlyList<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem>)value
        );

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
                "Data did not match any variant of ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue"
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

    public virtual bool Equals(ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue? other) =>
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
            IReadOnlyList<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem> _ =>
                3,
            _ => -1,
        };
    }
}

sealed class ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueConverter
    : JsonConverter<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue>
{
    public override ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue? Read(
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
            var deserialized = JsonSerializer.Deserialize<
                List<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem>
            >(element, options);
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
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItemConverter))]
public record class ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem : ModelBase
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

    public ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem(
        bool value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
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
                    "Data did not match any variant of ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
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
                "Data did not match any variant of ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem"
            ),
        };
    }

    public static implicit operator ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem(
        string value
    ) => new(value);

    public static implicit operator ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem(
        double value
    ) => new(value);

    public static implicit operator ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem(
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
                "Data did not match any variant of ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem"
            );
        }
    }

    public virtual bool Equals(
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem? other
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

sealed class ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItemConverter
    : JsonConverter<ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem>
{
    public override ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem? Read(
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
        ExtensionItemAITasksTaskYesNoOnNoSetMetadataValueMetadataValueItem value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata,
        ExtensionItemAITasksTaskYesNoOnNoUnsetMetadataFromRaw
    >)
)]
public sealed record class ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata : JsonModel
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

    public ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata(
        ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata extensionItemAITasksTaskYesNoOnNoUnsetMetadata
    )
        : base(extensionItemAITasksTaskYesNoOnNoUnsetMetadata) { }
#pragma warning restore CS8618

    public ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtensionItemAITasksTaskYesNoOnNoUnsetMetadataFromRaw.FromRawUnchecked"/>
    public static ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata(string field)
        : this()
    {
        this.Field = field;
    }
}

class ExtensionItemAITasksTaskYesNoOnNoUnsetMetadataFromRaw
    : IFromRawJson<ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata>
{
    /// <inheritdoc/>
    public ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtensionItemAITasksTaskYesNoOnNoUnsetMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Actions to execute if the AI cannot determine the answer.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ExtensionItemAITasksTaskYesNoOnUnknown,
        ExtensionItemAITasksTaskYesNoOnUnknownFromRaw
    >)
)]
public sealed record class ExtensionItemAITasksTaskYesNoOnUnknown : JsonModel
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
    public IReadOnlyList<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata>? SetMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata>
            >("set_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata>?>(
                "set_metadata",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of custom metadata fields to remove.
    /// </summary>
    public IReadOnlyList<ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata>? UnsetMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata>
            >("unset_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata>?>(
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

    public ExtensionItemAITasksTaskYesNoOnUnknown() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtensionItemAITasksTaskYesNoOnUnknown(
        ExtensionItemAITasksTaskYesNoOnUnknown extensionItemAITasksTaskYesNoOnUnknown
    )
        : base(extensionItemAITasksTaskYesNoOnUnknown) { }
#pragma warning restore CS8618

    public ExtensionItemAITasksTaskYesNoOnUnknown(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtensionItemAITasksTaskYesNoOnUnknown(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtensionItemAITasksTaskYesNoOnUnknownFromRaw.FromRawUnchecked"/>
    public static ExtensionItemAITasksTaskYesNoOnUnknown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtensionItemAITasksTaskYesNoOnUnknownFromRaw
    : IFromRawJson<ExtensionItemAITasksTaskYesNoOnUnknown>
{
    /// <inheritdoc/>
    public ExtensionItemAITasksTaskYesNoOnUnknown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtensionItemAITasksTaskYesNoOnUnknown.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata,
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataFromRaw
    >)
)]
public sealed record class ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata : JsonModel
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
    public required ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue>(
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

    public ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata(
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata extensionItemAITasksTaskYesNoOnUnknownSetMetadata
    )
        : base(extensionItemAITasksTaskYesNoOnUnknownSetMetadata) { }
#pragma warning restore CS8618

    public ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataFromRaw.FromRawUnchecked"/>
    public static ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataFromRaw
    : IFromRawJson<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata>
{
    /// <inheritdoc/>
    public ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtensionItemAITasksTaskYesNoOnUnknownSetMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Value to set for the custom metadata field. The value type should match the custom
/// metadata field type.
/// </summary>
[JsonConverter(typeof(ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueConverter))]
public record class ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue : ModelBase
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

    public ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue(
        bool value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue(
        IReadOnlyList<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMixed(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMixed(
        [NotNullWhen(true)]
            out IReadOnlyList<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem>? value
    )
    {
        value =
            this.Value
            as IReadOnlyList<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (IReadOnlyList&lt;ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<string> @string,
        Action<double> @double,
        Action<bool> @bool,
        Action<
            IReadOnlyList<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem>
        > mixed
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
            case IReadOnlyList<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem> value:
                mixed(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (IReadOnlyList&lt;ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<string, T> @string,
        Func<double, T> @double,
        Func<bool, T> @bool,
        Func<
            IReadOnlyList<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem>,
            T
        > mixed
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            IReadOnlyList<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem> value =>
                mixed(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue"
            ),
        };
    }

    public static implicit operator ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue(
        string value
    ) => new(value);

    public static implicit operator ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue(
        double value
    ) => new(value);

    public static implicit operator ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue(
        bool value
    ) => new(value);

    public static implicit operator ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue(
        List<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem> value
    ) =>
        new(
            (IReadOnlyList<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem>)
                value
        );

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
                "Data did not match any variant of ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue"
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

    public virtual bool Equals(ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue? other) =>
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
            IReadOnlyList<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem> _ =>
                3,
            _ => -1,
        };
    }
}

sealed class ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueConverter
    : JsonConverter<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue>
{
    public override ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue? Read(
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
            var deserialized = JsonSerializer.Deserialize<
                List<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem>
            >(element, options);
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
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItemConverter)
)]
public record class ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem
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

    public ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem(
        bool value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem(
        JsonElement element
    )
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
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
                    "Data did not match any variant of ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
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
                "Data did not match any variant of ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem"
            ),
        };
    }

    public static implicit operator ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem(
        string value
    ) => new(value);

    public static implicit operator ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem(
        double value
    ) => new(value);

    public static implicit operator ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem(
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
                "Data did not match any variant of ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem"
            );
        }
    }

    public virtual bool Equals(
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem? other
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

sealed class ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItemConverter
    : JsonConverter<ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem>
{
    public override ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem? Read(
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
        ExtensionItemAITasksTaskYesNoOnUnknownSetMetadataValueMetadataValueItem value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata,
        ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadataFromRaw
    >)
)]
public sealed record class ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata : JsonModel
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

    public ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata(
        ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata extensionItemAITasksTaskYesNoOnUnknownUnsetMetadata
    )
        : base(extensionItemAITasksTaskYesNoOnUnknownUnsetMetadata) { }
#pragma warning restore CS8618

    public ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadataFromRaw.FromRawUnchecked"/>
    public static ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata(string field)
        : this()
    {
        this.Field = field;
    }
}

class ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadataFromRaw
    : IFromRawJson<ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata>
{
    /// <inheritdoc/>
    public ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtensionItemAITasksTaskYesNoOnUnknownUnsetMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Actions to execute if the AI answers yes.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ExtensionItemAITasksTaskYesNoOnYes,
        ExtensionItemAITasksTaskYesNoOnYesFromRaw
    >)
)]
public sealed record class ExtensionItemAITasksTaskYesNoOnYes : JsonModel
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
    public IReadOnlyList<ExtensionItemAITasksTaskYesNoOnYesSetMetadata>? SetMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ExtensionItemAITasksTaskYesNoOnYesSetMetadata>
            >("set_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ExtensionItemAITasksTaskYesNoOnYesSetMetadata>?>(
                "set_metadata",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of custom metadata fields to remove.
    /// </summary>
    public IReadOnlyList<ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata>? UnsetMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata>
            >("unset_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata>?>(
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

    public ExtensionItemAITasksTaskYesNoOnYes() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtensionItemAITasksTaskYesNoOnYes(
        ExtensionItemAITasksTaskYesNoOnYes extensionItemAITasksTaskYesNoOnYes
    )
        : base(extensionItemAITasksTaskYesNoOnYes) { }
#pragma warning restore CS8618

    public ExtensionItemAITasksTaskYesNoOnYes(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtensionItemAITasksTaskYesNoOnYes(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtensionItemAITasksTaskYesNoOnYesFromRaw.FromRawUnchecked"/>
    public static ExtensionItemAITasksTaskYesNoOnYes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtensionItemAITasksTaskYesNoOnYesFromRaw : IFromRawJson<ExtensionItemAITasksTaskYesNoOnYes>
{
    /// <inheritdoc/>
    public ExtensionItemAITasksTaskYesNoOnYes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtensionItemAITasksTaskYesNoOnYes.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ExtensionItemAITasksTaskYesNoOnYesSetMetadata,
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataFromRaw
    >)
)]
public sealed record class ExtensionItemAITasksTaskYesNoOnYesSetMetadata : JsonModel
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
    public required ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue>(
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

    public ExtensionItemAITasksTaskYesNoOnYesSetMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtensionItemAITasksTaskYesNoOnYesSetMetadata(
        ExtensionItemAITasksTaskYesNoOnYesSetMetadata extensionItemAITasksTaskYesNoOnYesSetMetadata
    )
        : base(extensionItemAITasksTaskYesNoOnYesSetMetadata) { }
#pragma warning restore CS8618

    public ExtensionItemAITasksTaskYesNoOnYesSetMetadata(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtensionItemAITasksTaskYesNoOnYesSetMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtensionItemAITasksTaskYesNoOnYesSetMetadataFromRaw.FromRawUnchecked"/>
    public static ExtensionItemAITasksTaskYesNoOnYesSetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtensionItemAITasksTaskYesNoOnYesSetMetadataFromRaw
    : IFromRawJson<ExtensionItemAITasksTaskYesNoOnYesSetMetadata>
{
    /// <inheritdoc/>
    public ExtensionItemAITasksTaskYesNoOnYesSetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtensionItemAITasksTaskYesNoOnYesSetMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Value to set for the custom metadata field. The value type should match the custom
/// metadata field type.
/// </summary>
[JsonConverter(typeof(ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueConverter))]
public record class ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue : ModelBase
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

    public ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue(
        bool value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue(
        IReadOnlyList<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMixed(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMixed(
        [NotNullWhen(true)]
            out IReadOnlyList<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem>? value
    )
    {
        value =
            this.Value
            as IReadOnlyList<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (IReadOnlyList&lt;ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<string> @string,
        Action<double> @double,
        Action<bool> @bool,
        Action<
            IReadOnlyList<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem>
        > mixed
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
            case IReadOnlyList<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem> value:
                mixed(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (IReadOnlyList&lt;ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<string, T> @string,
        Func<double, T> @double,
        Func<bool, T> @bool,
        Func<
            IReadOnlyList<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem>,
            T
        > mixed
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            IReadOnlyList<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem> value =>
                mixed(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue"
            ),
        };
    }

    public static implicit operator ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue(
        string value
    ) => new(value);

    public static implicit operator ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue(
        double value
    ) => new(value);

    public static implicit operator ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue(
        bool value
    ) => new(value);

    public static implicit operator ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue(
        List<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem> value
    ) =>
        new(
            (IReadOnlyList<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem>)
                value
        );

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
                "Data did not match any variant of ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue"
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

    public virtual bool Equals(ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue? other) =>
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
            IReadOnlyList<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem> _ =>
                3,
            _ => -1,
        };
    }
}

sealed class ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueConverter
    : JsonConverter<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue>
{
    public override ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue? Read(
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
            var deserialized = JsonSerializer.Deserialize<
                List<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem>
            >(element, options);
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
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItemConverter)
)]
public record class ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem : ModelBase
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

    public ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem(
        bool value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
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
                    "Data did not match any variant of ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
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
                "Data did not match any variant of ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem"
            ),
        };
    }

    public static implicit operator ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem(
        string value
    ) => new(value);

    public static implicit operator ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem(
        double value
    ) => new(value);

    public static implicit operator ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem(
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
                "Data did not match any variant of ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem"
            );
        }
    }

    public virtual bool Equals(
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem? other
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

sealed class ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItemConverter
    : JsonConverter<ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem>
{
    public override ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem? Read(
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
        ExtensionItemAITasksTaskYesNoOnYesSetMetadataValueMetadataValueItem value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata,
        ExtensionItemAITasksTaskYesNoOnYesUnsetMetadataFromRaw
    >)
)]
public sealed record class ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata : JsonModel
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

    public ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata(
        ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata extensionItemAITasksTaskYesNoOnYesUnsetMetadata
    )
        : base(extensionItemAITasksTaskYesNoOnYesUnsetMetadata) { }
#pragma warning restore CS8618

    public ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtensionItemAITasksTaskYesNoOnYesUnsetMetadataFromRaw.FromRawUnchecked"/>
    public static ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata(string field)
        : this()
    {
        this.Field = field;
    }
}

class ExtensionItemAITasksTaskYesNoOnYesUnsetMetadataFromRaw
    : IFromRawJson<ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata>
{
    /// <inheritdoc/>
    public ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtensionItemAITasksTaskYesNoOnYesUnsetMetadata.FromRawUnchecked(rawData);
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
