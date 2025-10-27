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
public record class RemoveAITags
{
    public object Value { get; private init; }

    public RemoveAITags(List<string> value)
    {
        Value = value;
    }

    public RemoveAITags(UnionMember1 value)
    {
        Value = value;
    }

    RemoveAITags(UnknownVariant value)
    {
        Value = value;
    }

    public static RemoveAITags CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickStrings([NotNullWhen(true)] out List<string>? value)
    {
        value = this.Value as List<string>;
        return value != null;
    }

    public bool TryPickAll([NotNullWhen(true)] out UnionMember1? value)
    {
        value = this.Value as UnionMember1;
        return value != null;
    }

    public void Switch(Action<List<string>> strings, Action<UnionMember1> all)
    {
        switch (this.Value)
        {
            case List<string> value:
                strings(value);
                break;
            case UnionMember1 value:
                all(value);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(Func<List<string>, T> strings, Func<UnionMember1, T> all)
    {
        return this.Value switch
        {
            Strings inner => strings(inner),
            All inner => all(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of RemoveAITags"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
            var deserialized = JsonSerializer.Deserialize<UnionMember1>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new RemoveAITags(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(ref reader, options);
            if (deserialized != null)
            {
                return new RemoveAITags(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
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
