using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Imagekit.Core;
using Text = System.Text;

namespace Imagekit.Models.NamedTransformations;

/// <summary>
/// Creates a new named transformation and returns the created object.
///
/// <para>Named transformations let you assign a short, reusable name to a complex
/// transformation string, so it can be applied in image and video URLs as `tr:n-&lt;name&gt;`
/// and later updated without changing any existing URLs.</para>
///
/// <para>Learn more about [named transformations](https://imagekit.io/docs/transformations#named-transformations).</para>
///
/// <para>**Note:** You can create up to 250 named transformations per account. Once
/// this limit is reached, the request fails with a `400` error.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class NamedTransformationCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Name of the named transformation. This is the alias used to refer to the
    /// transformation string in image and video URLs, for example `tr:n-&lt;name&gt;`.
    /// Can only contain alphanumeric characters or `_` (hyphens are not allowed),
    /// and must be unique for your account. Name matching is case-sensitive, so `Small_Thumbnail`
    /// and `small_thumbnail` are treated as different names.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// The transformation this name refers to, expressed as one or more comma-separated
    /// transformation parameters, for example `w-150,h-150,fo-center,cm-resize`.
    /// You do not need to prefix this with `tr:` — it is added automatically. If
    /// you do include it, it must appear in lowercase at the start of the string,
    /// or the request is rejected. Learn more about the [transformation syntax](https://imagekit.io/docs/transformations).
    /// </summary>
    public required string Transformation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("transformation");
        }
        init { this._rawBodyData.Set("transformation", value); }
    }

    /// <summary>
    /// Whether this named transformation is enabled. Set to `false` to temporarily
    /// disable it without deleting it — requests using a disabled named transformation
    /// fail at delivery time.
    /// </summary>
    public bool? Enabled
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("enabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("enabled", value);
        }
    }

    public NamedTransformationCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NamedTransformationCreateParams(
        NamedTransformationCreateParams namedTransformationCreateParams
    )
        : base(namedTransformationCreateParams)
    {
        this._rawBodyData = new(namedTransformationCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public NamedTransformationCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NamedTransformationCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static NamedTransformationCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(NamedTransformationCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/named-transformations")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Text::Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
