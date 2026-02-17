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

/// <summary>
/// Configuration object for an extension (base extensions only, not saved extension references).
/// </summary>
[JsonConverter(typeof(ExtensionConfigConverter))]
public record class ExtensionConfig : ModelBase
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

    public ExtensionConfig(RemoveBg value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionConfig(AutoTaggingExtension value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionConfig(AIAutoDescription value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionConfig(AITasks value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RemoveBg"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRemoveBg(out var value)) {
    ///     // `value` is of type `RemoveBg`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRemoveBg([NotNullWhen(true)] out RemoveBg? value)
    {
        value = this.Value as RemoveBg;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AutoTaggingExtension"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAutoTaggingExtension(out var value)) {
    ///     // `value` is of type `AutoTaggingExtension`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAutoTaggingExtension([NotNullWhen(true)] out AutoTaggingExtension? value)
    {
        value = this.Value as AutoTaggingExtension;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AIAutoDescription"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAIAutoDescription(out var value)) {
    ///     // `value` is of type `AIAutoDescription`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAIAutoDescription([NotNullWhen(true)] out AIAutoDescription? value)
    {
        value = this.Value as AIAutoDescription;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AITasks"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAITasks(out var value)) {
    ///     // `value` is of type `AITasks`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAITasks([NotNullWhen(true)] out AITasks? value)
    {
        value = this.Value as AITasks;
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
    ///     (RemoveBg value) => {...},
    ///     (AutoTaggingExtension value) => {...},
    ///     (AIAutoDescription value) => {...},
    ///     (AITasks value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<RemoveBg> removeBg,
        Action<AutoTaggingExtension> autoTaggingExtension,
        Action<AIAutoDescription> aiAutoDescription,
        Action<AITasks> aiTasks
    )
    {
        switch (this.Value)
        {
            case RemoveBg value:
                removeBg(value);
                break;
            case AutoTaggingExtension value:
                autoTaggingExtension(value);
                break;
            case AIAutoDescription value:
                aiAutoDescription(value);
                break;
            case AITasks value:
                aiTasks(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of ExtensionConfig"
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
    ///     (RemoveBg value) => {...},
    ///     (AutoTaggingExtension value) => {...},
    ///     (AIAutoDescription value) => {...},
    ///     (AITasks value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<RemoveBg, T> removeBg,
        Func<AutoTaggingExtension, T> autoTaggingExtension,
        Func<AIAutoDescription, T> aiAutoDescription,
        Func<AITasks, T> aiTasks
    )
    {
        return this.Value switch
        {
            RemoveBg value => removeBg(value),
            AutoTaggingExtension value => autoTaggingExtension(value),
            AIAutoDescription value => aiAutoDescription(value),
            AITasks value => aiTasks(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of ExtensionConfig"
            ),
        };
    }

    public static implicit operator ExtensionConfig(RemoveBg value) => new(value);

    public static implicit operator ExtensionConfig(AutoTaggingExtension value) => new(value);

    public static implicit operator ExtensionConfig(AIAutoDescription value) => new(value);

    public static implicit operator ExtensionConfig(AITasks value) => new(value);

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
                "Data did not match any variant of ExtensionConfig"
            );
        }
        this.Switch(
            (removeBg) => removeBg.Validate(),
            (autoTaggingExtension) => autoTaggingExtension.Validate(),
            (aiAutoDescription) => aiAutoDescription.Validate(),
            (aiTasks) => aiTasks.Validate()
        );
    }

    public virtual bool Equals(ExtensionConfig? other) =>
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
            RemoveBg _ => 0,
            AutoTaggingExtension _ => 1,
            AIAutoDescription _ => 2,
            AITasks _ => 3,
            _ => -1,
        };
    }
}

sealed class ExtensionConfigConverter : JsonConverter<ExtensionConfig>
{
    public override ExtensionConfig? Read(
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
                    var deserialized = JsonSerializer.Deserialize<RemoveBg>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<AIAutoDescription>(
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
                    var deserialized = JsonSerializer.Deserialize<AITasks>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<AutoTaggingExtension>(
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
        ExtensionConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<RemoveBg, RemoveBgFromRaw>))]
public sealed record class RemoveBg : JsonModel
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

    public Options? Options
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Options>("options");
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

    public RemoveBg()
    {
        this.Name = JsonSerializer.SerializeToElement("remove-bg");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RemoveBg(RemoveBg removeBg)
        : base(removeBg) { }
#pragma warning restore CS8618

    public RemoveBg(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("remove-bg");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RemoveBg(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RemoveBgFromRaw.FromRawUnchecked"/>
    public static RemoveBg FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RemoveBgFromRaw : IFromRawJson<RemoveBg>
{
    /// <inheritdoc/>
    public RemoveBg FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RemoveBg.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Options, OptionsFromRaw>))]
public sealed record class Options : JsonModel
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

    public Options() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Options(Options options)
        : base(options) { }
#pragma warning restore CS8618

    public Options(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Options(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OptionsFromRaw.FromRawUnchecked"/>
    public static Options FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OptionsFromRaw : IFromRawJson<Options>
{
    /// <inheritdoc/>
    public Options FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Options.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<AutoTaggingExtension, AutoTaggingExtensionFromRaw>))]
public sealed record class AutoTaggingExtension : JsonModel
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
    public required ApiEnum<string, Name> Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Name>>("name");
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

    public AutoTaggingExtension() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutoTaggingExtension(AutoTaggingExtension autoTaggingExtension)
        : base(autoTaggingExtension) { }
#pragma warning restore CS8618

    public AutoTaggingExtension(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutoTaggingExtension(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutoTaggingExtensionFromRaw.FromRawUnchecked"/>
    public static AutoTaggingExtension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutoTaggingExtensionFromRaw : IFromRawJson<AutoTaggingExtension>
{
    /// <inheritdoc/>
    public AutoTaggingExtension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutoTaggingExtension.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the auto-tagging extension used.
/// </summary>
[JsonConverter(typeof(NameConverter))]
public enum Name
{
    GoogleAutoTagging,
    AwsAutoTagging,
}

sealed class NameConverter : JsonConverter<Name>
{
    public override Name Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "google-auto-tagging" => Name.GoogleAutoTagging,
            "aws-auto-tagging" => Name.AwsAutoTagging,
            _ => (Name)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Name value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Name.GoogleAutoTagging => "google-auto-tagging",
                Name.AwsAutoTagging => "aws-auto-tagging",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(AIAutoDescriptionConverter))]
public record class AIAutoDescription
{
    public JsonElement Element { get; private init; }

    public AIAutoDescription()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "name": "ai-auto-description"
            }
            """
        );
    }

    internal AIAutoDescription(JsonElement element)
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
        if (this != new AIAutoDescription())
        {
            throw new ImageKitInvalidDataException("Invalid value given for 'AIAutoDescription'");
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(AIAutoDescription? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class AIAutoDescriptionConverter : JsonConverter<AIAutoDescription>
{
    public override AIAutoDescription? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        AIAutoDescription value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<AITasks, AITasksFromRaw>))]
public sealed record class AITasks : JsonModel
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
    public required IReadOnlyList<Task> Tasks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Task>>("tasks");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Task>>(
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

    public AITasks()
    {
        this.Name = JsonSerializer.SerializeToElement("ai-tasks");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AITasks(AITasks aiTasks)
        : base(aiTasks) { }
#pragma warning restore CS8618

    public AITasks(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("ai-tasks");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AITasks(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AITasksFromRaw.FromRawUnchecked"/>
    public static AITasks FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AITasks(IReadOnlyList<Task> tasks)
        : this()
    {
        this.Tasks = tasks;
    }
}

class AITasksFromRaw : IFromRawJson<AITasks>
{
    /// <inheritdoc/>
    public AITasks FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AITasks.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TaskConverter))]
public record class Task : ModelBase
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

    public Task(SelectTags value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Task(SelectMetadata value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Task(YesNo value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Task(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SelectTags"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSelectTags(out var value)) {
    ///     // `value` is of type `SelectTags`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSelectTags([NotNullWhen(true)] out SelectTags? value)
    {
        value = this.Value as SelectTags;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SelectMetadata"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSelectMetadata(out var value)) {
    ///     // `value` is of type `SelectMetadata`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSelectMetadata([NotNullWhen(true)] out SelectMetadata? value)
    {
        value = this.Value as SelectMetadata;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="YesNo"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickYesNo(out var value)) {
    ///     // `value` is of type `YesNo`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickYesNo([NotNullWhen(true)] out YesNo? value)
    {
        value = this.Value as YesNo;
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
    ///     (SelectTags value) => {...},
    ///     (SelectMetadata value) => {...},
    ///     (YesNo value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<SelectTags> selectTags,
        Action<SelectMetadata> selectMetadata,
        Action<YesNo> yesNo
    )
    {
        switch (this.Value)
        {
            case SelectTags value:
                selectTags(value);
                break;
            case SelectMetadata value:
                selectMetadata(value);
                break;
            case YesNo value:
                yesNo(value);
                break;
            default:
                throw new ImageKitInvalidDataException("Data did not match any variant of Task");
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
    ///     (SelectTags value) => {...},
    ///     (SelectMetadata value) => {...},
    ///     (YesNo value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<SelectTags, T> selectTags,
        Func<SelectMetadata, T> selectMetadata,
        Func<YesNo, T> yesNo
    )
    {
        return this.Value switch
        {
            SelectTags value => selectTags(value),
            SelectMetadata value => selectMetadata(value),
            YesNo value => yesNo(value),
            _ => throw new ImageKitInvalidDataException("Data did not match any variant of Task"),
        };
    }

    public static implicit operator Task(SelectTags value) => new(value);

    public static implicit operator Task(SelectMetadata value) => new(value);

    public static implicit operator Task(YesNo value) => new(value);

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
            throw new ImageKitInvalidDataException("Data did not match any variant of Task");
        }
        this.Switch(
            (selectTags) => selectTags.Validate(),
            (selectMetadata) => selectMetadata.Validate(),
            (yesNo) => yesNo.Validate()
        );
    }

    public virtual bool Equals(Task? other) =>
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
            SelectTags _ => 0,
            SelectMetadata _ => 1,
            YesNo _ => 2,
            _ => -1,
        };
    }
}

sealed class TaskConverter : JsonConverter<Task>
{
    public override Task? Read(
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
                    var deserialized = JsonSerializer.Deserialize<SelectTags>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<SelectMetadata>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<YesNo>(element, options);
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
                return new Task(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Task value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<SelectTags, SelectTagsFromRaw>))]
public sealed record class SelectTags : JsonModel
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

    public SelectTags()
    {
        this.Type = JsonSerializer.SerializeToElement("select_tags");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SelectTags(SelectTags selectTags)
        : base(selectTags) { }
#pragma warning restore CS8618

    public SelectTags(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("select_tags");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SelectTags(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SelectTagsFromRaw.FromRawUnchecked"/>
    public static SelectTags FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SelectTags(string instruction)
        : this()
    {
        this.Instruction = instruction;
    }
}

class SelectTagsFromRaw : IFromRawJson<SelectTags>
{
    /// <inheritdoc/>
    public SelectTags FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SelectTags.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SelectMetadata, SelectMetadataFromRaw>))]
public sealed record class SelectMetadata : JsonModel
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
    public IReadOnlyList<Vocabulary>? Vocabulary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Vocabulary>>("vocabulary");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Vocabulary>?>(
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

    public SelectMetadata()
    {
        this.Type = JsonSerializer.SerializeToElement("select_metadata");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SelectMetadata(SelectMetadata selectMetadata)
        : base(selectMetadata) { }
#pragma warning restore CS8618

    public SelectMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("select_metadata");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SelectMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SelectMetadataFromRaw.FromRawUnchecked"/>
    public static SelectMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SelectMetadataFromRaw : IFromRawJson<SelectMetadata>
{
    /// <inheritdoc/>
    public SelectMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SelectMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(VocabularyConverter))]
public record class Vocabulary : ModelBase
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

    public Vocabulary(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Vocabulary(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Vocabulary(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Vocabulary(JsonElement element)
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
                    "Data did not match any variant of Vocabulary"
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
                "Data did not match any variant of Vocabulary"
            ),
        };
    }

    public static implicit operator Vocabulary(string value) => new(value);

    public static implicit operator Vocabulary(double value) => new(value);

    public static implicit operator Vocabulary(bool value) => new(value);

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
            throw new ImageKitInvalidDataException("Data did not match any variant of Vocabulary");
        }
    }

    public virtual bool Equals(Vocabulary? other) =>
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

sealed class VocabularyConverter : JsonConverter<Vocabulary>
{
    public override Vocabulary? Read(
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
        Vocabulary value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<YesNo, YesNoFromRaw>))]
public sealed record class YesNo : JsonModel
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
    public OnNo? OnNo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OnNo>("on_no");
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
    public OnUnknown? OnUnknown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OnUnknown>("on_unknown");
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
    public OnYes? OnYes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OnYes>("on_yes");
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

    public YesNo()
    {
        this.Type = JsonSerializer.SerializeToElement("yes_no");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public YesNo(YesNo yesNo)
        : base(yesNo) { }
#pragma warning restore CS8618

    public YesNo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("yes_no");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    YesNo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="YesNoFromRaw.FromRawUnchecked"/>
    public static YesNo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public YesNo(string instruction)
        : this()
    {
        this.Instruction = instruction;
    }
}

class YesNoFromRaw : IFromRawJson<YesNo>
{
    /// <inheritdoc/>
    public YesNo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        YesNo.FromRawUnchecked(rawData);
}

/// <summary>
/// Actions to execute if the AI answers no.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OnNo, OnNoFromRaw>))]
public sealed record class OnNo : JsonModel
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
    public IReadOnlyList<SetMetadata>? SetMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SetMetadata>>("set_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SetMetadata>?>(
                "set_metadata",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of custom metadata fields to remove.
    /// </summary>
    public IReadOnlyList<UnsetMetadata>? UnsetMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<UnsetMetadata>>("unset_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<UnsetMetadata>?>(
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

    public OnNo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OnNo(OnNo onNo)
        : base(onNo) { }
#pragma warning restore CS8618

    public OnNo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OnNo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OnNoFromRaw.FromRawUnchecked"/>
    public static OnNo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OnNoFromRaw : IFromRawJson<OnNo>
{
    /// <inheritdoc/>
    public OnNo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OnNo.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SetMetadata, SetMetadataFromRaw>))]
public sealed record class SetMetadata : JsonModel
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
    public required SetMetadataValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SetMetadataValue>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Field;
        this.Value.Validate();
    }

    public SetMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetMetadata(SetMetadata setMetadata)
        : base(setMetadata) { }
#pragma warning restore CS8618

    public SetMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetMetadataFromRaw.FromRawUnchecked"/>
    public static SetMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SetMetadataFromRaw : IFromRawJson<SetMetadata>
{
    /// <inheritdoc/>
    public SetMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SetMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Value to set for the custom metadata field. The value type should match the custom
/// metadata field type.
/// </summary>
[JsonConverter(typeof(SetMetadataValueConverter))]
public record class SetMetadataValue : ModelBase
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

    public SetMetadataValue(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SetMetadataValue(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SetMetadataValue(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SetMetadataValue(
        IReadOnlyList<UnnamedSchemaWithArrayParent3> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public SetMetadataValue(JsonElement element)
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
    /// type <see cref="IReadOnlyList<UnnamedSchemaWithArrayParent3>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMixed(out var value)) {
    ///     // `value` is of type `IReadOnlyList<UnnamedSchemaWithArrayParent3>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMixed(
        [NotNullWhen(true)] out IReadOnlyList<UnnamedSchemaWithArrayParent3>? value
    )
    {
        value = this.Value as IReadOnlyList<UnnamedSchemaWithArrayParent3>;
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
    ///     (IReadOnlyList<UnnamedSchemaWithArrayParent3> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<string> @string,
        Action<double> @double,
        Action<bool> @bool,
        Action<IReadOnlyList<UnnamedSchemaWithArrayParent3>> mixed
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
            case IReadOnlyList<UnnamedSchemaWithArrayParent3> value:
                mixed(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of SetMetadataValue"
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
    ///     (IReadOnlyList<UnnamedSchemaWithArrayParent3> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<string, T> @string,
        Func<double, T> @double,
        Func<bool, T> @bool,
        Func<IReadOnlyList<UnnamedSchemaWithArrayParent3>, T> mixed
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            IReadOnlyList<UnnamedSchemaWithArrayParent3> value => mixed(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of SetMetadataValue"
            ),
        };
    }

    public static implicit operator SetMetadataValue(string value) => new(value);

    public static implicit operator SetMetadataValue(double value) => new(value);

    public static implicit operator SetMetadataValue(bool value) => new(value);

    public static implicit operator SetMetadataValue(List<UnnamedSchemaWithArrayParent3> value) =>
        new((IReadOnlyList<UnnamedSchemaWithArrayParent3>)value);

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
                "Data did not match any variant of SetMetadataValue"
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

    public virtual bool Equals(SetMetadataValue? other) =>
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
            IReadOnlyList<UnnamedSchemaWithArrayParent3> _ => 3,
            _ => -1,
        };
    }
}

sealed class SetMetadataValueConverter : JsonConverter<SetMetadataValue>
{
    public override SetMetadataValue? Read(
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
            var deserialized = JsonSerializer.Deserialize<List<UnnamedSchemaWithArrayParent3>>(
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
        SetMetadataValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(UnnamedSchemaWithArrayParent3Converter))]
public record class UnnamedSchemaWithArrayParent3 : ModelBase
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

    public UnnamedSchemaWithArrayParent3(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent3(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent3(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent3(JsonElement element)
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
                    "Data did not match any variant of UnnamedSchemaWithArrayParent3"
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
                "Data did not match any variant of UnnamedSchemaWithArrayParent3"
            ),
        };
    }

    public static implicit operator UnnamedSchemaWithArrayParent3(string value) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent3(double value) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent3(bool value) => new(value);

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
                "Data did not match any variant of UnnamedSchemaWithArrayParent3"
            );
        }
    }

    public virtual bool Equals(UnnamedSchemaWithArrayParent3? other) =>
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

sealed class UnnamedSchemaWithArrayParent3Converter : JsonConverter<UnnamedSchemaWithArrayParent3>
{
    public override UnnamedSchemaWithArrayParent3? Read(
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
        UnnamedSchemaWithArrayParent3 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<UnsetMetadata, UnsetMetadataFromRaw>))]
public sealed record class UnsetMetadata : JsonModel
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

    public UnsetMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnsetMetadata(UnsetMetadata unsetMetadata)
        : base(unsetMetadata) { }
#pragma warning restore CS8618

    public UnsetMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnsetMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnsetMetadataFromRaw.FromRawUnchecked"/>
    public static UnsetMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UnsetMetadata(string field)
        : this()
    {
        this.Field = field;
    }
}

class UnsetMetadataFromRaw : IFromRawJson<UnsetMetadata>
{
    /// <inheritdoc/>
    public UnsetMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnsetMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Actions to execute if the AI cannot determine the answer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OnUnknown, OnUnknownFromRaw>))]
public sealed record class OnUnknown : JsonModel
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
    public IReadOnlyList<OnUnknownSetMetadata>? SetMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<OnUnknownSetMetadata>>(
                "set_metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<OnUnknownSetMetadata>?>(
                "set_metadata",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of custom metadata fields to remove.
    /// </summary>
    public IReadOnlyList<OnUnknownUnsetMetadata>? UnsetMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<OnUnknownUnsetMetadata>>(
                "unset_metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<OnUnknownUnsetMetadata>?>(
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

    public OnUnknown() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OnUnknown(OnUnknown onUnknown)
        : base(onUnknown) { }
#pragma warning restore CS8618

    public OnUnknown(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OnUnknown(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OnUnknownFromRaw.FromRawUnchecked"/>
    public static OnUnknown FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OnUnknownFromRaw : IFromRawJson<OnUnknown>
{
    /// <inheritdoc/>
    public OnUnknown FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OnUnknown.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<OnUnknownSetMetadata, OnUnknownSetMetadataFromRaw>))]
public sealed record class OnUnknownSetMetadata : JsonModel
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
    public required OnUnknownSetMetadataValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<OnUnknownSetMetadataValue>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Field;
        this.Value.Validate();
    }

    public OnUnknownSetMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OnUnknownSetMetadata(OnUnknownSetMetadata onUnknownSetMetadata)
        : base(onUnknownSetMetadata) { }
#pragma warning restore CS8618

    public OnUnknownSetMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OnUnknownSetMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OnUnknownSetMetadataFromRaw.FromRawUnchecked"/>
    public static OnUnknownSetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OnUnknownSetMetadataFromRaw : IFromRawJson<OnUnknownSetMetadata>
{
    /// <inheritdoc/>
    public OnUnknownSetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OnUnknownSetMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Value to set for the custom metadata field. The value type should match the custom
/// metadata field type.
/// </summary>
[JsonConverter(typeof(OnUnknownSetMetadataValueConverter))]
public record class OnUnknownSetMetadataValue : ModelBase
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

    public OnUnknownSetMetadataValue(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OnUnknownSetMetadataValue(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OnUnknownSetMetadataValue(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OnUnknownSetMetadataValue(
        IReadOnlyList<UnnamedSchemaWithArrayParent4> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public OnUnknownSetMetadataValue(JsonElement element)
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
    /// type <see cref="IReadOnlyList<UnnamedSchemaWithArrayParent4>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMixed(out var value)) {
    ///     // `value` is of type `IReadOnlyList<UnnamedSchemaWithArrayParent4>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMixed(
        [NotNullWhen(true)] out IReadOnlyList<UnnamedSchemaWithArrayParent4>? value
    )
    {
        value = this.Value as IReadOnlyList<UnnamedSchemaWithArrayParent4>;
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
    ///     (IReadOnlyList<UnnamedSchemaWithArrayParent4> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<string> @string,
        Action<double> @double,
        Action<bool> @bool,
        Action<IReadOnlyList<UnnamedSchemaWithArrayParent4>> mixed
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
            case IReadOnlyList<UnnamedSchemaWithArrayParent4> value:
                mixed(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of OnUnknownSetMetadataValue"
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
    ///     (IReadOnlyList<UnnamedSchemaWithArrayParent4> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<string, T> @string,
        Func<double, T> @double,
        Func<bool, T> @bool,
        Func<IReadOnlyList<UnnamedSchemaWithArrayParent4>, T> mixed
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            IReadOnlyList<UnnamedSchemaWithArrayParent4> value => mixed(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of OnUnknownSetMetadataValue"
            ),
        };
    }

    public static implicit operator OnUnknownSetMetadataValue(string value) => new(value);

    public static implicit operator OnUnknownSetMetadataValue(double value) => new(value);

    public static implicit operator OnUnknownSetMetadataValue(bool value) => new(value);

    public static implicit operator OnUnknownSetMetadataValue(
        List<UnnamedSchemaWithArrayParent4> value
    ) => new((IReadOnlyList<UnnamedSchemaWithArrayParent4>)value);

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
                "Data did not match any variant of OnUnknownSetMetadataValue"
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

    public virtual bool Equals(OnUnknownSetMetadataValue? other) =>
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
            IReadOnlyList<UnnamedSchemaWithArrayParent4> _ => 3,
            _ => -1,
        };
    }
}

sealed class OnUnknownSetMetadataValueConverter : JsonConverter<OnUnknownSetMetadataValue>
{
    public override OnUnknownSetMetadataValue? Read(
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
            var deserialized = JsonSerializer.Deserialize<List<UnnamedSchemaWithArrayParent4>>(
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
        OnUnknownSetMetadataValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(UnnamedSchemaWithArrayParent4Converter))]
public record class UnnamedSchemaWithArrayParent4 : ModelBase
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

    public UnnamedSchemaWithArrayParent4(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent4(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent4(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent4(JsonElement element)
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
                    "Data did not match any variant of UnnamedSchemaWithArrayParent4"
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
                "Data did not match any variant of UnnamedSchemaWithArrayParent4"
            ),
        };
    }

    public static implicit operator UnnamedSchemaWithArrayParent4(string value) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent4(double value) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent4(bool value) => new(value);

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
                "Data did not match any variant of UnnamedSchemaWithArrayParent4"
            );
        }
    }

    public virtual bool Equals(UnnamedSchemaWithArrayParent4? other) =>
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

sealed class UnnamedSchemaWithArrayParent4Converter : JsonConverter<UnnamedSchemaWithArrayParent4>
{
    public override UnnamedSchemaWithArrayParent4? Read(
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
        UnnamedSchemaWithArrayParent4 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<OnUnknownUnsetMetadata, OnUnknownUnsetMetadataFromRaw>))]
public sealed record class OnUnknownUnsetMetadata : JsonModel
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

    public OnUnknownUnsetMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OnUnknownUnsetMetadata(OnUnknownUnsetMetadata onUnknownUnsetMetadata)
        : base(onUnknownUnsetMetadata) { }
#pragma warning restore CS8618

    public OnUnknownUnsetMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OnUnknownUnsetMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OnUnknownUnsetMetadataFromRaw.FromRawUnchecked"/>
    public static OnUnknownUnsetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public OnUnknownUnsetMetadata(string field)
        : this()
    {
        this.Field = field;
    }
}

class OnUnknownUnsetMetadataFromRaw : IFromRawJson<OnUnknownUnsetMetadata>
{
    /// <inheritdoc/>
    public OnUnknownUnsetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OnUnknownUnsetMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Actions to execute if the AI answers yes.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OnYes, OnYesFromRaw>))]
public sealed record class OnYes : JsonModel
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
    public IReadOnlyList<OnYesSetMetadata>? SetMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<OnYesSetMetadata>>(
                "set_metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<OnYesSetMetadata>?>(
                "set_metadata",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of custom metadata fields to remove.
    /// </summary>
    public IReadOnlyList<OnYesUnsetMetadata>? UnsetMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<OnYesUnsetMetadata>>(
                "unset_metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<OnYesUnsetMetadata>?>(
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

    public OnYes() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OnYes(OnYes onYes)
        : base(onYes) { }
#pragma warning restore CS8618

    public OnYes(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OnYes(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OnYesFromRaw.FromRawUnchecked"/>
    public static OnYes FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OnYesFromRaw : IFromRawJson<OnYes>
{
    /// <inheritdoc/>
    public OnYes FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OnYes.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<OnYesSetMetadata, OnYesSetMetadataFromRaw>))]
public sealed record class OnYesSetMetadata : JsonModel
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
    public required OnYesSetMetadataValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<OnYesSetMetadataValue>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Field;
        this.Value.Validate();
    }

    public OnYesSetMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OnYesSetMetadata(OnYesSetMetadata onYesSetMetadata)
        : base(onYesSetMetadata) { }
#pragma warning restore CS8618

    public OnYesSetMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OnYesSetMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OnYesSetMetadataFromRaw.FromRawUnchecked"/>
    public static OnYesSetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OnYesSetMetadataFromRaw : IFromRawJson<OnYesSetMetadata>
{
    /// <inheritdoc/>
    public OnYesSetMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OnYesSetMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Value to set for the custom metadata field. The value type should match the custom
/// metadata field type.
/// </summary>
[JsonConverter(typeof(OnYesSetMetadataValueConverter))]
public record class OnYesSetMetadataValue : ModelBase
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

    public OnYesSetMetadataValue(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OnYesSetMetadataValue(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OnYesSetMetadataValue(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OnYesSetMetadataValue(
        IReadOnlyList<UnnamedSchemaWithArrayParent5> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public OnYesSetMetadataValue(JsonElement element)
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
    /// type <see cref="IReadOnlyList<UnnamedSchemaWithArrayParent5>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMixed(out var value)) {
    ///     // `value` is of type `IReadOnlyList<UnnamedSchemaWithArrayParent5>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMixed(
        [NotNullWhen(true)] out IReadOnlyList<UnnamedSchemaWithArrayParent5>? value
    )
    {
        value = this.Value as IReadOnlyList<UnnamedSchemaWithArrayParent5>;
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
    ///     (IReadOnlyList<UnnamedSchemaWithArrayParent5> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<string> @string,
        Action<double> @double,
        Action<bool> @bool,
        Action<IReadOnlyList<UnnamedSchemaWithArrayParent5>> mixed
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
            case IReadOnlyList<UnnamedSchemaWithArrayParent5> value:
                mixed(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of OnYesSetMetadataValue"
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
    ///     (IReadOnlyList<UnnamedSchemaWithArrayParent5> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<string, T> @string,
        Func<double, T> @double,
        Func<bool, T> @bool,
        Func<IReadOnlyList<UnnamedSchemaWithArrayParent5>, T> mixed
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            IReadOnlyList<UnnamedSchemaWithArrayParent5> value => mixed(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of OnYesSetMetadataValue"
            ),
        };
    }

    public static implicit operator OnYesSetMetadataValue(string value) => new(value);

    public static implicit operator OnYesSetMetadataValue(double value) => new(value);

    public static implicit operator OnYesSetMetadataValue(bool value) => new(value);

    public static implicit operator OnYesSetMetadataValue(
        List<UnnamedSchemaWithArrayParent5> value
    ) => new((IReadOnlyList<UnnamedSchemaWithArrayParent5>)value);

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
                "Data did not match any variant of OnYesSetMetadataValue"
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

    public virtual bool Equals(OnYesSetMetadataValue? other) =>
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
            IReadOnlyList<UnnamedSchemaWithArrayParent5> _ => 3,
            _ => -1,
        };
    }
}

sealed class OnYesSetMetadataValueConverter : JsonConverter<OnYesSetMetadataValue>
{
    public override OnYesSetMetadataValue? Read(
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
            var deserialized = JsonSerializer.Deserialize<List<UnnamedSchemaWithArrayParent5>>(
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
        OnYesSetMetadataValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(UnnamedSchemaWithArrayParent5Converter))]
public record class UnnamedSchemaWithArrayParent5 : ModelBase
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

    public UnnamedSchemaWithArrayParent5(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent5(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent5(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent5(JsonElement element)
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
                    "Data did not match any variant of UnnamedSchemaWithArrayParent5"
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
                "Data did not match any variant of UnnamedSchemaWithArrayParent5"
            ),
        };
    }

    public static implicit operator UnnamedSchemaWithArrayParent5(string value) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent5(double value) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent5(bool value) => new(value);

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
                "Data did not match any variant of UnnamedSchemaWithArrayParent5"
            );
        }
    }

    public virtual bool Equals(UnnamedSchemaWithArrayParent5? other) =>
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

sealed class UnnamedSchemaWithArrayParent5Converter : JsonConverter<UnnamedSchemaWithArrayParent5>
{
    public override UnnamedSchemaWithArrayParent5? Read(
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
        UnnamedSchemaWithArrayParent5 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<OnYesUnsetMetadata, OnYesUnsetMetadataFromRaw>))]
public sealed record class OnYesUnsetMetadata : JsonModel
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

    public OnYesUnsetMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OnYesUnsetMetadata(OnYesUnsetMetadata onYesUnsetMetadata)
        : base(onYesUnsetMetadata) { }
#pragma warning restore CS8618

    public OnYesUnsetMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OnYesUnsetMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OnYesUnsetMetadataFromRaw.FromRawUnchecked"/>
    public static OnYesUnsetMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public OnYesUnsetMetadata(string field)
        : this()
    {
        this.Field = field;
    }
}

class OnYesUnsetMetadataFromRaw : IFromRawJson<OnYesUnsetMetadata>
{
    /// <inheritdoc/>
    public OnYesUnsetMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OnYesUnsetMetadata.FromRawUnchecked(rawData);
}
