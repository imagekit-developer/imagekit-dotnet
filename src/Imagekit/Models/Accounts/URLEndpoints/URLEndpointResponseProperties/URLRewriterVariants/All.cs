using System.Text.Json;
using URLRewriterProperties = Imagekit.Models.Accounts.URLEndpoints.URLEndpointResponseProperties.URLRewriterProperties;

namespace Imagekit.Models.Accounts.URLEndpoints.URLEndpointResponseProperties.URLRewriterVariants;

public sealed record class Cloudinary(URLRewriterProperties::Cloudinary Value)
    : URLRewriter,
        IVariant<Cloudinary, URLRewriterProperties::Cloudinary>
{
    public static Cloudinary From(URLRewriterProperties::Cloudinary value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class Imgix(JsonElement Value) : URLRewriter, IVariant<Imgix, JsonElement>
{
    public static Imgix From(JsonElement value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Akamai(JsonElement Value) : URLRewriter, IVariant<Akamai, JsonElement>
{
    public static Akamai From(JsonElement value)
    {
        return new(value);
    }

    public override void Validate() { }
}
