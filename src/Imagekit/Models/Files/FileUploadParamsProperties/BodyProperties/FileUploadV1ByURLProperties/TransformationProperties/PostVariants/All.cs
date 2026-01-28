using PostProperties = Imagekit.Models.Files.FileUploadParamsProperties.BodyProperties.FileUploadV1ByURLProperties.TransformationProperties.PostProperties;

namespace Imagekit.Models.Files.FileUploadParamsProperties.BodyProperties.FileUploadV1ByURLProperties.TransformationProperties.PostVariants;

public sealed record class Transformation(PostProperties::Transformation Value)
    : Post,
        IVariant<Transformation, PostProperties::Transformation>
{
    public static Transformation From(PostProperties::Transformation value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class GifToVideo(PostProperties::GifToVideo Value)
    : Post,
        IVariant<GifToVideo, PostProperties::GifToVideo>
{
    public static GifToVideo From(PostProperties::GifToVideo value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class Thumbnail(PostProperties::Thumbnail Value)
    : Post,
        IVariant<Thumbnail, PostProperties::Thumbnail>
{
    public static Thumbnail From(PostProperties::Thumbnail value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class Abs(PostProperties::Abs Value) : Post, IVariant<Abs, PostProperties::Abs>
{
    public static Abs From(PostProperties::Abs value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
