using Models = Imagekit.Models;

namespace Imagekit.Models.OverlayVariants;

public sealed record class TextOverlay(Models::TextOverlay Value)
    : Models::Overlay,
        IVariant<TextOverlay, Models::TextOverlay>
{
    public static TextOverlay From(Models::TextOverlay value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ImageOverlay(Models::ImageOverlay Value)
    : Models::Overlay,
        IVariant<ImageOverlay, Models::ImageOverlay>
{
    public static ImageOverlay From(Models::ImageOverlay value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class VideoOverlay(Models::VideoOverlay Value)
    : Models::Overlay,
        IVariant<VideoOverlay, Models::VideoOverlay>
{
    public static VideoOverlay From(Models::VideoOverlay value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class SubtitleOverlay(Models::SubtitleOverlay Value)
    : Models::Overlay,
        IVariant<SubtitleOverlay, Models::SubtitleOverlay>
{
    public static SubtitleOverlay From(Models::SubtitleOverlay value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class SolidColorOverlay(Models::SolidColorOverlay Value)
    : Models::Overlay,
        IVariant<SolidColorOverlay, Models::SolidColorOverlay>
{
    public static SolidColorOverlay From(Models::SolidColorOverlay value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
