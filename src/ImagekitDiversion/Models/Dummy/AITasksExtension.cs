using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;

namespace ImagekitDiversion.Models.Dummy;

[JsonConverter(typeof(JsonModelConverter<AITasksExtension, AITasksExtensionFromRaw>))]
public sealed record class AITasksExtension : JsonModel
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
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.Tasks)
        {
            item.Validate();
        }
    }

    public AITasksExtension()
    {
        this.Name = JsonSerializer.SerializeToElement("ai-tasks");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AITasksExtension(AITasksExtension aiTasksExtension)
        : base(aiTasksExtension) { }
#pragma warning restore CS8618

    public AITasksExtension(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("ai-tasks");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AITasksExtension(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AITasksExtensionFromRaw.FromRawUnchecked"/>
    public static AITasksExtension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AITasksExtension(IReadOnlyList<Task> tasks)
        : this()
    {
        this.Tasks = tasks;
    }
}

class AITasksExtensionFromRaw : IFromRawJson<AITasksExtension>
{
    /// <inheritdoc/>
    public AITasksExtension FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AITasksExtension.FromRawUnchecked(rawData);
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImagekitDiversionInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (SelectTags value) =&gt; {...},
    ///     (SelectMetadata value) =&gt; {...},
    ///     (YesNo value) =&gt; {...}
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
                throw new ImagekitDiversionInvalidDataException(
                    "Data did not match any variant of Task"
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
    /// <exception cref="ImagekitDiversionInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (SelectTags value) =&gt; {...},
    ///     (SelectMetadata value) =&gt; {...},
    ///     (YesNo value) =&gt; {...}
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
            _ => throw new ImagekitDiversionInvalidDataException(
                "Data did not match any variant of Task"
            ),
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
    /// <exception cref="ImagekitDiversionInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImagekitDiversionInvalidDataException(
                "Data did not match any variant of Task"
            );
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
                    var deserialized = JsonSerializer.Deserialize<SelectMetadata>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<YesNo>(element, options);
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
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
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
    /// An array of possible values matching the custom metadata field type. If not
    /// provided for SingleSelect or MultiSelect field types, all values from the
    /// custom metadata field definition will be used. When providing large vocabularies
    /// (above 30 items), the AI may not strictly adhere to the list.
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
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
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
    /// <exception cref="ImagekitDiversionInvalidDataException">
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
                throw new ImagekitDiversionInvalidDataException(
                    "Data did not match any variant of Vocabulary"
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
    /// <exception cref="ImagekitDiversionInvalidDataException">
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
            _ => throw new ImagekitDiversionInvalidDataException(
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
    /// <exception cref="ImagekitDiversionInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImagekitDiversionInvalidDataException(
                "Data did not match any variant of Vocabulary"
            );
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
        catch (Exception e) when (e is JsonException || e is ImagekitDiversionInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImagekitDiversionInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImagekitDiversionInvalidDataException)
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
    public AITaskAction? OnNo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AITaskAction>("on_no");
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
    public AITaskAction? OnUnknown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AITaskAction>("on_unknown");
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
    public AITaskAction? OnYes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AITaskAction>("on_yes");
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
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
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
