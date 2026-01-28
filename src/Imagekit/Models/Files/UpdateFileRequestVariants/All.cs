using System.Text.Json;
using UpdateFileRequestProperties = Imagekit.Models.Files.UpdateFileRequestProperties;

namespace Imagekit.Models.Files.UpdateFileRequestVariants;

public sealed record class UpdateFileDetails(UpdateFileRequestProperties::UpdateFileDetails Value)
    : UpdateFileRequest,
        IVariant<UpdateFileDetails, UpdateFileRequestProperties::UpdateFileDetails>
{
    public static UpdateFileDetails From(UpdateFileRequestProperties::UpdateFileDetails value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ChangePublicationStatus(JsonElement Value)
    : UpdateFileRequest,
        IVariant<ChangePublicationStatus, JsonElement>
{
    public static ChangePublicationStatus From(JsonElement value)
    {
        return new(value);
    }

    public override void Validate() { }
}
