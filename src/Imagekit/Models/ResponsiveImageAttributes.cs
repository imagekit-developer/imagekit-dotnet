using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;

namespace Imagekit.Models;

/// <summary>
/// Resulting set of attributes suitable for an HTML `<img>` element. Useful for enabling
/// responsive image loading with `srcSet` and `sizes`.
/// </summary>
[JsonConverter(typeof(ModelConverter<ResponsiveImageAttributes>))]
public sealed record class ResponsiveImageAttributes
    : ModelBase,
        IFromRaw<ResponsiveImageAttributes>
{
    /// <summary>
    /// URL for the *largest* candidate (assigned to plain `src`).
    /// </summary>
    public required string Src
    {
        get
        {
            if (!this.Properties.TryGetValue("src", out JsonElement element))
                throw new ImageKitInvalidDataException(
                    "'src' cannot be null",
                    new ArgumentOutOfRangeException("src", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ImageKitInvalidDataException(
                    "'src' cannot be null",
                    new ArgumentNullException("src")
                );
        }
        set
        {
            this.Properties["src"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// `sizes` returned (or synthesised as `100vw`).  The value for the HTML `sizes`
    /// attribute.
    /// </summary>
    public string? Sizes
    {
        get
        {
            if (!this.Properties.TryGetValue("sizes", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["sizes"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Candidate set with `w` or `x` descriptors.  Multiple image URLs separated
    /// by commas, each with a descriptor.
    /// </summary>
    public string? SrcSet
    {
        get
        {
            if (!this.Properties.TryGetValue("srcSet", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["srcSet"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Width as a number (if `width` was provided in the input options).
    /// </summary>
    public double? Width
    {
        get
        {
            if (!this.Properties.TryGetValue("width", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["width"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Src;
        _ = this.Sizes;
        _ = this.SrcSet;
        _ = this.Width;
    }

    public ResponsiveImageAttributes() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResponsiveImageAttributes(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ResponsiveImageAttributes FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public ResponsiveImageAttributes(string src)
        : this()
    {
        this.Src = src;
    }
}
