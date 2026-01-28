using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Files.FileUpdateParamsProperties.UpdateProperties.UpdateFileDetailsProperties.RemoveAITagsVariants;

namespace Imagekit.Models.Files.FileUpdateParamsProperties.UpdateProperties.UpdateFileDetailsProperties;

/// <summary>
/// An array of AITags associated with the file that you want to remove, e.g. `["car",
/// "vehicle", "motorsports"]`.
///
/// If you want to remove all AITags associated with the file, send a string - "all".
///
/// Note: The remove operation for `AITags` executes before any of the `extensions`
/// are processed.
/// </summary>
[JsonConverter(typeof(RemoveAITagsConverter))]
public abstract record class RemoveAITags
{
    internal RemoveAITags() { }

    public static implicit operator RemoveAITags(List<string> value) => new Strings(value);

    public bool TryPickStrings([NotNullWhen(true)] out List<string>? value)
    {
        value = (this as Strings)?.Value;
        return value != null;
    }

    public bool TryPickAll([NotNullWhen(true)] out JsonElement? value)
    {
        value = (this as All)?.Value;
        return value != null;
    }

    public void Switch(Action<Strings> strings, Action<All> all)
    {
        switch (this)
        {
            case Strings inner:
                strings(inner);
                break;
            case All inner:
                all(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(Func<Strings, T> strings, Func<All, T> all)
    {
        return this switch
        {
            Strings inner => strings(inner),
            All inner => all(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class RemoveAITagsConverter : JsonConverter<RemoveAITags>
{
    public override RemoveAITags? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new All(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(ref reader, options);
            if (deserialized != null)
            {
                return new Strings(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        RemoveAITags value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            Strings(var strings) => strings,
            All(var all) => all,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
