using System.Collections.Generic;
using System.Text.Json;

namespace Imagekit.Models.Files.FileUpdateParamsProperties.UpdateProperties.UpdateFileDetailsProperties.RemoveAITagsVariants;

public sealed record class Strings(List<string> Value)
    : RemoveAITags,
        IVariant<Strings, List<string>>
{
    public static Strings From(List<string> value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class All(JsonElement Value) : RemoveAITags, IVariant<All, JsonElement>
{
    public static All From(JsonElement value)
    {
        return new(value);
    }

    public override void Validate() { }
}
