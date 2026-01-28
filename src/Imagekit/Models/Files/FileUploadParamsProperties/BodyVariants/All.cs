using BodyProperties = Imagekit.Models.Files.FileUploadParamsProperties.BodyProperties;

namespace Imagekit.Models.Files.FileUploadParamsProperties.BodyVariants;

public sealed record class FileUploadV1(BodyProperties::FileUploadV1 Value)
    : Body,
        IVariant<FileUploadV1, BodyProperties::FileUploadV1>
{
    public static FileUploadV1 From(BodyProperties::FileUploadV1 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class FileUploadV1ByURL(BodyProperties::FileUploadV1ByURL Value)
    : Body,
        IVariant<FileUploadV1ByURL, BodyProperties::FileUploadV1ByURL>
{
    public static FileUploadV1ByURL From(BodyProperties::FileUploadV1ByURL value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
