using UpdateProperties = Imagekit.Models.Files.FileUpdateParamsProperties.UpdateProperties;

namespace Imagekit.Models.Files.FileUpdateParamsProperties.UpdateVariants;

public sealed record class UpdateFileDetails(UpdateProperties::UpdateFileDetails Value)
    : Update,
        IVariant<UpdateFileDetails, UpdateProperties::UpdateFileDetails>
{
    public static UpdateFileDetails From(UpdateProperties::UpdateFileDetails value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ChangePublicationStatus(UpdateProperties::ChangePublicationStatus Value)
    : Update,
        IVariant<ChangePublicationStatus, UpdateProperties::ChangePublicationStatus>
{
    public static ChangePublicationStatus From(UpdateProperties::ChangePublicationStatus value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
