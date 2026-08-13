using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models;

/// <summary>
/// A named transformation is an alias for a transformation string, letting you apply
/// and later update complex transformations without changing your image or video
/// URLs. Learn more about [named transformations](https://imagekit.io/docs/transformations#named-transformations).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NamedTransformation, NamedTransformationFromRaw>))]
public sealed record class NamedTransformation : JsonModel
{
    /// <summary>
    /// Unique identifier for a named transformation.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp of when the named transformation was created.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// Whether the named transformation is currently enabled. When this is set to
    /// `false`, requests using such disabled named transformations fail at delivery time.
    /// </summary>
    public bool? Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("enabled", value);
        }
    }

    /// <summary>
    /// Alias for the transformation string, used in URLs as `tr:n-&lt;name&gt;`.
    /// Must contain only alphanumeric characters or `_` (no hyphens), and be unique
    /// for your account. Name matching is case-sensitive.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// The transformation string this name refers to, for example `w-150,h-150,fo-center,cm-resize`.
    /// The `tr:` prefix is optional; if present, it is validated. The string must
    /// be a valid ImageKit transformation and cannot itself reference another named
    /// transformation (no nesting). Learn more about the [transformation syntax](https://imagekit.io/docs/transformations).
    /// </summary>
    public string? Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transformation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transformation", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Enabled;
        _ = this.Name;
        _ = this.Transformation;
    }

    public NamedTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NamedTransformation(NamedTransformation namedTransformation)
        : base(namedTransformation) { }
#pragma warning restore CS8618

    public NamedTransformation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NamedTransformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NamedTransformationFromRaw.FromRawUnchecked"/>
    public static NamedTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NamedTransformationFromRaw : IFromRawJson<NamedTransformation>
{
    /// <inheritdoc/>
    public NamedTransformation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NamedTransformation.FromRawUnchecked(rawData);
}
