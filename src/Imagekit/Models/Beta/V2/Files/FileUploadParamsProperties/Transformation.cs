using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Models.Beta.V2.Files.FileUploadParamsProperties.TransformationProperties;

namespace Imagekit.Models.Beta.V2.Files.FileUploadParamsProperties;

/// <summary>
/// Configure pre-processing (`pre`) and post-processing (`post`) transformations.
///
/// - `pre` — applied before the file is uploaded to the Media Library.     Useful
/// for reducing file size or applying basic optimizations upfront (e.g., resize, compress).
///
/// - `post` — applied immediately after upload.     Ideal for generating transformed
/// versions (like video encodes or thumbnails) in advance, so they're ready for
/// delivery without delay.
///
/// You can mix and match any combination of post-processing types.
/// </summary>
[JsonConverter(
    typeof(ModelConverter<global::Imagekit.Models.Beta.V2.Files.FileUploadParamsProperties.Transformation>)
)]
public sealed record class Transformation
    : ModelBase,
        IFromRaw<global::Imagekit.Models.Beta.V2.Files.FileUploadParamsProperties.Transformation>
{
    /// <summary>
    /// List of transformations to apply *after* the file is uploaded.   Each item
    /// must match one of the following types: `transformation`, `gif-to-video`,
    /// `thumbnail`, `abs`.
    /// </summary>
    public List<Post>? Post
    {
        get
        {
            if (!this.Properties.TryGetValue("post", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Post>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["post"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Transformation string to apply before uploading the file to the Media Library.
    /// Useful for optimizing files at ingestion.
    /// </summary>
    public string? Pre
    {
        get
        {
            if (!this.Properties.TryGetValue("pre", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["pre"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Post ?? [])
        {
            item.Validate();
        }
        _ = this.Pre;
    }

    public Transformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Transformation(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static global::Imagekit.Models.Beta.V2.Files.FileUploadParamsProperties.Transformation FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
