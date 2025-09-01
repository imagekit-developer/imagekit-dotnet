using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Files.FileUpdateParamsProperties.UpdateProperties;
using UpdateVariants = Imagekit.Models.Files.FileUpdateParamsProperties.UpdateVariants;

namespace Imagekit.Models.Files.FileUpdateParamsProperties;

[JsonConverter(typeof(UpdateConverter))]
public abstract record class Update
{
    internal Update() { }

    public static implicit operator Update(UpdateFileDetails value) =>
        new UpdateVariants::UpdateFileDetails(value);

    public static implicit operator Update(ChangePublicationStatus value) =>
        new UpdateVariants::ChangePublicationStatus(value);

    public bool TryPickFileDetails([NotNullWhen(true)] out UpdateFileDetails? value)
    {
        value = (this as UpdateVariants::UpdateFileDetails)?.Value;
        return value != null;
    }

    public bool TryPickChangePublicationStatus(
        [NotNullWhen(true)] out ChangePublicationStatus? value
    )
    {
        value = (this as UpdateVariants::ChangePublicationStatus)?.Value;
        return value != null;
    }

    public void Switch(
        Action<UpdateVariants::UpdateFileDetails> fileDetails,
        Action<UpdateVariants::ChangePublicationStatus> changePublicationStatus
    )
    {
        switch (this)
        {
            case UpdateVariants::UpdateFileDetails inner:
                fileDetails(inner);
                break;
            case UpdateVariants::ChangePublicationStatus inner:
                changePublicationStatus(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<UpdateVariants::UpdateFileDetails, T> fileDetails,
        Func<UpdateVariants::ChangePublicationStatus, T> changePublicationStatus
    )
    {
        return this switch
        {
            UpdateVariants::UpdateFileDetails inner => fileDetails(inner),
            UpdateVariants::ChangePublicationStatus inner => changePublicationStatus(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class UpdateConverter : JsonConverter<Update>
{
    public override Update? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<UpdateFileDetails>(ref reader, options);
            if (deserialized != null)
            {
                return new UpdateVariants::UpdateFileDetails(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ChangePublicationStatus>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new UpdateVariants::ChangePublicationStatus(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Update value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            UpdateVariants::UpdateFileDetails(var fileDetails) => fileDetails,
            UpdateVariants::ChangePublicationStatus(var changePublicationStatus) =>
                changePublicationStatus,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
