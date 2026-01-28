using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;
using Imagekit.Models.Files.UpdateFileRequestProperties;
using UpdateFileRequestVariants = Imagekit.Models.Files.UpdateFileRequestVariants;

namespace Imagekit.Models.Files;

/// <summary>
/// Schema for update file update request.
/// </summary>
[JsonConverter(typeof(UpdateFileRequestConverter))]
public abstract record class UpdateFileRequest
{
    internal UpdateFileRequest() { }

    public static implicit operator UpdateFileRequest(UpdateFileDetails value) =>
        new UpdateFileRequestVariants::UpdateFileDetails(value);

    public static implicit operator UpdateFileRequest(ChangePublicationStatus value) =>
        new UpdateFileRequestVariants::ChangePublicationStatus(value);

    public bool TryPickDetails([NotNullWhen(true)] out UpdateFileDetails? value)
    {
        value = (this as UpdateFileRequestVariants::UpdateFileDetails)?.Value;
        return value != null;
    }

    public bool TryPickChangePublicationStatus(
        [NotNullWhen(true)] out ChangePublicationStatus? value
    )
    {
        value = (this as UpdateFileRequestVariants::ChangePublicationStatus)?.Value;
        return value != null;
    }

    public void Switch(
        Action<UpdateFileRequestVariants::UpdateFileDetails> details,
        Action<UpdateFileRequestVariants::ChangePublicationStatus> changePublicationStatus
    )
    {
        switch (this)
        {
            case UpdateFileRequestVariants::UpdateFileDetails inner:
                details(inner);
                break;
            case UpdateFileRequestVariants::ChangePublicationStatus inner:
                changePublicationStatus(inner);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UpdateFileRequest"
                );
        }
    }

    public T Match<T>(
        Func<UpdateFileRequestVariants::UpdateFileDetails, T> details,
        Func<UpdateFileRequestVariants::ChangePublicationStatus, T> changePublicationStatus
    )
    {
        return this switch
        {
            UpdateFileRequestVariants::UpdateFileDetails inner => details(inner),
            UpdateFileRequestVariants::ChangePublicationStatus inner => changePublicationStatus(
                inner
            ),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UpdateFileRequest"
            ),
        };
    }

    public abstract void Validate();
}

sealed class UpdateFileRequestConverter : JsonConverter<UpdateFileRequest>
{
    public override UpdateFileRequest? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<ImageKitInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<UpdateFileDetails>(ref reader, options);
            if (deserialized != null)
            {
                return new UpdateFileRequestVariants::UpdateFileDetails(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new ImageKitInvalidDataException(
                    "Data does not match union variant UpdateFileRequestVariants::UpdateFileDetails",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ChangePublicationStatus>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new UpdateFileRequestVariants::ChangePublicationStatus(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new ImageKitInvalidDataException(
                    "Data does not match union variant UpdateFileRequestVariants::ChangePublicationStatus",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateFileRequest value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            UpdateFileRequestVariants::UpdateFileDetails(var details) => details,
            UpdateFileRequestVariants::ChangePublicationStatus(var changePublicationStatus) =>
                changePublicationStatus,
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UpdateFileRequest"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
