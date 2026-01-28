<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PageVariants = Imagekit.Models.TransformationProperties.PageVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Extracts a specific page or frame from multi-page or layered files (PDF, PSD,
/// AI).  For example, specify by number (e.g., `2`), a range (e.g., `3-4` for the
/// 2nd and 3rd layers), or by name (e.g., `name-layer-4` for a PSD layer). See [Thumbnail
/// extraction](https://imagekit.io/docs/vector-and-animated-images#get-thumbnail-from-psd-pdf-ai-eps-and-animated-files).
/// </summary>
[JsonConverter(typeof(PageConverter))]
public abstract record class Page
{
    internal Page() { }

    public static implicit operator Page(double value) => new PageVariants::Double(value);

    public static implicit operator Page(string value) => new PageVariants::String(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as PageVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as PageVariants::String)?.Value;
        return value != null;
    }

    public void Switch(Action<PageVariants::Double> @double, Action<PageVariants::String> @string)
    {
        switch (this)
        {
            case PageVariants::Double inner:
                @double(inner);
                break;
            case PageVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(Func<PageVariants::Double, T> @double, Func<PageVariants::String, T> @string)
    {
        return this switch
        {
            PageVariants::Double inner => @double(inner),
            PageVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class PageConverter : JsonConverter<Page>
{
    public override Page? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new PageVariants::Double(
                JsonSerializer.Deserialize<double>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new PageVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Page value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            PageVariants::Double(var @double) => @double,
            PageVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
=======
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;
using PageVariants = Imagekit.Models.TransformationProperties.PageVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Extracts a specific page or frame from multi-page or layered files (PDF, PSD,
/// AI).  For example, specify by number (e.g., `2`), a range (e.g., `3-4` for the
/// 2nd and 3rd layers), or by name (e.g., `name-layer-4` for a PSD layer). See [Thumbnail
/// extraction](https://imagekit.io/docs/vector-and-animated-images#get-thumbnail-from-psd-pdf-ai-eps-and-animated-files).
/// </summary>
[JsonConverter(typeof(PageConverter))]
public abstract record class Page
{
    internal Page() { }

    public static implicit operator Page(double value) => new PageVariants::Double(value);

    public static implicit operator Page(string value) => new PageVariants::String(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as PageVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as PageVariants::String)?.Value;
        return value != null;
    }

    public void Switch(Action<PageVariants::Double> @double, Action<PageVariants::String> @string)
    {
        switch (this)
        {
            case PageVariants::Double inner:
                @double(inner);
                break;
            case PageVariants::String inner:
                @string(inner);
                break;
            default:
                throw new ImageKitInvalidDataException("Data did not match any variant of Page");
        }
    }

    public T Match<T>(Func<PageVariants::Double, T> @double, Func<PageVariants::String, T> @string)
    {
        return this switch
        {
            PageVariants::Double inner => @double(inner),
            PageVariants::String inner => @string(inner),
            _ => throw new ImageKitInvalidDataException("Data did not match any variant of Page"),
        };
    }

    public abstract void Validate();
}

sealed class PageConverter : JsonConverter<Page>
{
    public override Page? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<ImageKitInvalidDataException> exceptions = [];

        try
        {
            return new PageVariants::Double(
                JsonSerializer.Deserialize<double>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new ImageKitInvalidDataException(
                    "Data does not match union variant PageVariants::Double",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new PageVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new ImageKitInvalidDataException(
                    "Data does not match union variant PageVariants::String",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Page value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            PageVariants::Double(var @double) => @double,
            PageVariants::String(var @string) => @string,
            _ => throw new ImageKitInvalidDataException("Data did not match any variant of Page"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
>>>>>>> origin/generated--merge-conflict
