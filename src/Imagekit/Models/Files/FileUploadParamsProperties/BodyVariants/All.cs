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

public sealed record class FileUploadByUrlv1(BodyProperties::FileUploadByUrlv1 Value)
    : Body,
        IVariant<FileUploadByUrlv1, BodyProperties::FileUploadByUrlv1>
{
    public static FileUploadByUrlv1 From(BodyProperties::FileUploadByUrlv1 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
