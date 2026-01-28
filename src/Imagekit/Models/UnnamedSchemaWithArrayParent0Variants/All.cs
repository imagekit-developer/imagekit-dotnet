using System.Text.Json;
using Imagekit.Core;
using UnnamedSchemaWithArrayParent0Properties = Imagekit.Models.UnnamedSchemaWithArrayParent0Properties;

namespace Imagekit.Models.UnnamedSchemaWithArrayParent0Variants;

public sealed record class RemoveBg(UnnamedSchemaWithArrayParent0Properties::RemoveBg Value)
    : UnnamedSchemaWithArrayParent0,
        IVariant<RemoveBg, UnnamedSchemaWithArrayParent0Properties::RemoveBg>
{
    public static RemoveBg From(UnnamedSchemaWithArrayParent0Properties::RemoveBg value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class AutoTaggingExtension(
    UnnamedSchemaWithArrayParent0Properties::AutoTaggingExtension Value
)
    : UnnamedSchemaWithArrayParent0,
        IVariant<
            AutoTaggingExtension,
            UnnamedSchemaWithArrayParent0Properties::AutoTaggingExtension
        >
{
    public static AutoTaggingExtension From(
        UnnamedSchemaWithArrayParent0Properties::AutoTaggingExtension value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class AIAutoDescription(JsonElement Value)
    : UnnamedSchemaWithArrayParent0,
        IVariant<AIAutoDescription, JsonElement>
{
    public static AIAutoDescription From(JsonElement value)
    {
        return new(value);
    }

    public override void Validate() { }
}
