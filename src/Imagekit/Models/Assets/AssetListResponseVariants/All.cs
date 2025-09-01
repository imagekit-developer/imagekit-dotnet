using Files = Imagekit.Models.Files;

namespace Imagekit.Models.Assets.AssetListResponseVariants;

/// <summary>
/// Object containing details of a file or file version.
/// </summary>
public sealed record class File(Files::File Value) : AssetListResponse, IVariant<File, Files::File>
{
    public static File From(Files::File value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class Folder(Files::Folder Value)
    : AssetListResponse,
        IVariant<Folder, Files::Folder>
{
    public static Folder From(Files::Folder value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
