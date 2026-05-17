using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;

namespace ImagekitDiversion.Models.Dummy;

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

    public ExtensionConfig(RemovedotBgExtension value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionConfig(AutoTaggingExtension value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionConfig(AutoDescriptionExtension value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtensionConfig(AITasksExtension value, JsonElement? element = null)
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
    /// type <see cref="RemovedotBgExtension"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRemovedotBgExtension(out var value)) {
    ///     // `value` is of type `RemovedotBgExtension`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRemovedotBgExtension([NotNullWhen(true)] out RemovedotBgExtension? value)
    {
        value = this.Value as RemovedotBgExtension;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AutoTaggingExtension"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// type <see cref="AutoDescriptionExtension"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAutoDescriptionExtension(out var value)) {
    ///     // `value` is of type `AutoDescriptionExtension`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAutoDescriptionExtension(
        [NotNullWhen(true)] out AutoDescriptionExtension? value
    )
    {
        value = this.Value as AutoDescriptionExtension;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AITasksExtension"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAITasksExtension(out var value)) {
    ///     // `value` is of type `AITasksExtension`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAITasksExtension([NotNullWhen(true)] out AITasksExtension? value)
    {
        value = this.Value as AITasksExtension;
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
    ///     (RemovedotBgExtension value) =&gt; {...},
    ///     (AutoTaggingExtension value) =&gt; {...},
    ///     (AutoDescriptionExtension value) =&gt; {...},
    ///     (AITasksExtension value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<RemovedotBgExtension> removedotBgExtension,
        Action<AutoTaggingExtension> autoTaggingExtension,
        Action<AutoDescriptionExtension> autoDescriptionExtension,
        Action<AITasksExtension> aiTasksExtension
    )
    {
        switch (this.Value)
        {
            case RemovedotBgExtension value:
                removedotBgExtension(value);
                break;
            case AutoTaggingExtension value:
                autoTaggingExtension(value);
                break;
            case AutoDescriptionExtension value:
                autoDescriptionExtension(value);
                break;
            case AITasksExtension value:
                aiTasksExtension(value);
                break;
            default:
                throw new ImagekitDiversionInvalidDataException(
                    "Data did not match any variant of ExtensionConfig"
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
    ///     (RemovedotBgExtension value) =&gt; {...},
    ///     (AutoTaggingExtension value) =&gt; {...},
    ///     (AutoDescriptionExtension value) =&gt; {...},
    ///     (AITasksExtension value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<RemovedotBgExtension, T> removedotBgExtension,
        Func<AutoTaggingExtension, T> autoTaggingExtension,
        Func<AutoDescriptionExtension, T> autoDescriptionExtension,
        Func<AITasksExtension, T> aiTasksExtension
    )
    {
        return this.Value switch
        {
            RemovedotBgExtension value => removedotBgExtension(value),
            AutoTaggingExtension value => autoTaggingExtension(value),
            AutoDescriptionExtension value => autoDescriptionExtension(value),
            AITasksExtension value => aiTasksExtension(value),
            _ => throw new ImagekitDiversionInvalidDataException(
                "Data did not match any variant of ExtensionConfig"
            ),
        };
    }

    public static implicit operator ExtensionConfig(RemovedotBgExtension value) => new(value);

    public static implicit operator ExtensionConfig(AutoTaggingExtension value) => new(value);

    public static implicit operator ExtensionConfig(AutoDescriptionExtension value) => new(value);

    public static implicit operator ExtensionConfig(AITasksExtension value) => new(value);

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
                "Data did not match any variant of ExtensionConfig"
            );
        }
        this.Switch(
            (removedotBgExtension) => removedotBgExtension.Validate(),
            (autoTaggingExtension) => autoTaggingExtension.Validate(),
            (autoDescriptionExtension) => autoDescriptionExtension.Validate(),
            (aiTasksExtension) => aiTasksExtension.Validate()
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
            RemovedotBgExtension _ => 0,
            AutoTaggingExtension _ => 1,
            AutoDescriptionExtension _ => 2,
            AITasksExtension _ => 3,
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
                    var deserialized = JsonSerializer.Deserialize<RemovedotBgExtension>(
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
                    var deserialized = JsonSerializer.Deserialize<AutoDescriptionExtension>(
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
                    var deserialized = JsonSerializer.Deserialize<AITasksExtension>(
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
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AutoTaggingExtension>(
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
        ExtensionConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
