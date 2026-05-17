using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models;

/// <summary>
/// Resulting set of attributes suitable for an HTML `&lt;img&gt;` element. Useful
/// for enabling responsive image loading with `srcSet` and `sizes`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ResponsiveImageAttributes, ResponsiveImageAttributesFromRaw>)
)]
public sealed record class ResponsiveImageAttributes : JsonModel
{
    /// <summary>
    /// URL for the *largest* candidate (assigned to plain `src`).
    /// </summary>
    public required string Src
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("src");
        }
        init { this._rawData.Set("src", value); }
    }

    /// <summary>
    /// `sizes` returned (or synthesised as `100vw`).  The value for the HTML `sizes`
    /// attribute.
    /// </summary>
    public string? Sizes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sizes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sizes", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("srcSet");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("srcSet", value);
        }
    }

    /// <summary>
    /// Width as a number (if `width` was provided in the input options).
    /// </summary>
    public double? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("width");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("width", value);
        }
    }

    /// <inheritdoc/>
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
    public ResponsiveImageAttributes(ResponsiveImageAttributes responsiveImageAttributes)
        : base(responsiveImageAttributes) { }
#pragma warning restore CS8618

    public ResponsiveImageAttributes(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResponsiveImageAttributes(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResponsiveImageAttributesFromRaw.FromRawUnchecked"/>
    public static ResponsiveImageAttributes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ResponsiveImageAttributes(string src)
        : this()
    {
        this.Src = src;
    }
}

class ResponsiveImageAttributesFromRaw : IFromRawJson<ResponsiveImageAttributes>
{
    /// <inheritdoc/>
    public ResponsiveImageAttributes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ResponsiveImageAttributes.FromRawUnchecked(rawData);
}
