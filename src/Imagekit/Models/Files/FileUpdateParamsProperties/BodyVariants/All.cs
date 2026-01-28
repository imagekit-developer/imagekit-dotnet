using BodyProperties = Imagekit.Models.Files.FileUpdateParamsProperties.BodyProperties;

namespace Imagekit.Models.Files.FileUpdateParamsProperties.BodyVariants;

public sealed record class UpdateFileDetails(BodyProperties::UpdateFileDetails Value)
    : Body,
        IVariant<UpdateFileDetails, BodyProperties::UpdateFileDetails>
{
    public static UpdateFileDetails From(BodyProperties::UpdateFileDetails value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ChangePublicationStatus(BodyProperties::ChangePublicationStatus Value)
    : Body,
        IVariant<ChangePublicationStatus, BodyProperties::ChangePublicationStatus>
{
    public static ChangePublicationStatus From(BodyProperties::ChangePublicationStatus value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
