using System.Text.Json;
using ExtensionProperties = Imagekit.Models.Files.FileUploadParamsProperties.BodyProperties.FileUploadByUrlv1Properties.ExtensionProperties;

namespace Imagekit.Models.Files.FileUploadParamsProperties.BodyProperties.FileUploadByUrlv1Properties.ExtensionVariants;

public sealed record class RemoveBg(ExtensionProperties::RemoveBg Value)
    : Extension,
        IVariant<RemoveBg, ExtensionProperties::RemoveBg>
{
    public static RemoveBg From(ExtensionProperties::RemoveBg value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class AutoTaggingExtension(ExtensionProperties::AutoTaggingExtension Value)
    : Extension,
        IVariant<AutoTaggingExtension, ExtensionProperties::AutoTaggingExtension>
{
    public static AutoTaggingExtension From(ExtensionProperties::AutoTaggingExtension value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class AIAutoDescription(JsonElement Value)
    : Extension,
        IVariant<AIAutoDescription, JsonElement>
{
    public static AIAutoDescription From(JsonElement value)
    {
        return new(value);
    }

    public override void Validate() { }
}
