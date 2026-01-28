using UpdateFileDetailsRequestProperties = Imagekit.Models.Files.UpdateFileDetailsRequestProperties;

namespace Imagekit.Models.Files.UpdateFileDetailsRequestVariants;

public sealed record class UpdateFileDetails(
    UpdateFileDetailsRequestProperties::UpdateFileDetails Value
)
    : UpdateFileDetailsRequest,
        IVariant<UpdateFileDetails, UpdateFileDetailsRequestProperties::UpdateFileDetails>
{
    public static UpdateFileDetails From(
        UpdateFileDetailsRequestProperties::UpdateFileDetails value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ChangePublicationStatus(
    UpdateFileDetailsRequestProperties::ChangePublicationStatus Value
)
    : UpdateFileDetailsRequest,
        IVariant<
            ChangePublicationStatus,
            UpdateFileDetailsRequestProperties::ChangePublicationStatus
        >
{
    public static ChangePublicationStatus From(
        UpdateFileDetailsRequestProperties::ChangePublicationStatus value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
