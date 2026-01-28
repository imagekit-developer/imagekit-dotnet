using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Files.UpdateFileDetailsRequestProperties;
using UpdateFileDetailsRequestVariants = Imagekit.Models.Files.UpdateFileDetailsRequestVariants;

namespace Imagekit.Models.Files;

[JsonConverter(typeof(UpdateFileDetailsRequestConverter))]
public abstract record class UpdateFileDetailsRequest
{
    internal UpdateFileDetailsRequest() { }

    public static implicit operator UpdateFileDetailsRequest(UpdateFileDetails value) =>
        new UpdateFileDetailsRequestVariants::UpdateFileDetails(value);

    public static implicit operator UpdateFileDetailsRequest(ChangePublicationStatus value) =>
        new UpdateFileDetailsRequestVariants::ChangePublicationStatus(value);

    public bool TryPickUpdateFileDetails([NotNullWhen(true)] out UpdateFileDetails? value)
    {
        value = (this as UpdateFileDetailsRequestVariants::UpdateFileDetails)?.Value;
        return value != null;
    }

    public bool TryPickChangePublicationStatus(
        [NotNullWhen(true)] out ChangePublicationStatus? value
    )
    {
        value = (this as UpdateFileDetailsRequestVariants::ChangePublicationStatus)?.Value;
        return value != null;
    }

    public void Switch(
        Action<UpdateFileDetailsRequestVariants::UpdateFileDetails> updateFileDetails,
        Action<UpdateFileDetailsRequestVariants::ChangePublicationStatus> changePublicationStatus
    )
    {
        switch (this)
        {
            case UpdateFileDetailsRequestVariants::UpdateFileDetails inner:
                updateFileDetails(inner);
                break;
            case UpdateFileDetailsRequestVariants::ChangePublicationStatus inner:
                changePublicationStatus(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<UpdateFileDetailsRequestVariants::UpdateFileDetails, T> updateFileDetails,
        Func<UpdateFileDetailsRequestVariants::ChangePublicationStatus, T> changePublicationStatus
    )
    {
        return this switch
        {
            UpdateFileDetailsRequestVariants::UpdateFileDetails inner => updateFileDetails(inner),
            UpdateFileDetailsRequestVariants::ChangePublicationStatus inner =>
                changePublicationStatus(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class UpdateFileDetailsRequestConverter : JsonConverter<UpdateFileDetailsRequest>
{
    public override UpdateFileDetailsRequest? Read(
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
                return new UpdateFileDetailsRequestVariants::UpdateFileDetails(deserialized);
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
                return new UpdateFileDetailsRequestVariants::ChangePublicationStatus(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateFileDetailsRequest value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            UpdateFileDetailsRequestVariants::UpdateFileDetails(var updateFileDetails) =>
                updateFileDetails,
            UpdateFileDetailsRequestVariants::ChangePublicationStatus(
                var changePublicationStatus
            ) => changePublicationStatus,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
