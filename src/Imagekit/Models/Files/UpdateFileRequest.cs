using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;
using Imagekit.Models.Files.UpdateFileRequestProperties;

namespace Imagekit.Models.Files;

/// <summary>
/// Schema for update file update request.
/// </summary>
[JsonConverter(typeof(UpdateFileRequestConverter))]
public record class UpdateFileRequest
{
    public object Value { get; private init; }

    public UpdateFileRequest(UpdateFileDetails value)
    {
        Value = value;
    }

    public UpdateFileRequest(ChangePublicationStatus value)
    {
        Value = value;
    }

    UpdateFileRequest(UnknownVariant value)
    {
        Value = value;
    }

    public static UpdateFileRequest CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickDetails([NotNullWhen(true)] out UpdateFileDetails? value)
    {
        value = this.Value as UpdateFileDetails;
        return value != null;
    }

    public bool TryPickChangePublicationStatus(
        [NotNullWhen(true)] out ChangePublicationStatus? value
    )
    {
        value = this.Value as ChangePublicationStatus;
        return value != null;
    }

    public void Switch(
        Action<UpdateFileDetails> details,
        Action<ChangePublicationStatus> changePublicationStatus
    )
    {
        switch (this.Value)
        {
            case UpdateFileDetails value:
                details(value);
                break;
            case ChangePublicationStatus value:
                changePublicationStatus(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UpdateFileRequest"
                );
        }
    }

    public T Match<T>(
        Func<UpdateFileDetails, T> details,
        Func<ChangePublicationStatus, T> changePublicationStatus
    )
    {
        return this.Value switch
        {
            UpdateFileDetails value => details(value),
            ChangePublicationStatus value => changePublicationStatus(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UpdateFileRequest"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of UpdateFileRequest"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                deserialized.Validate();
                return new UpdateFileRequest(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(
                new ImageKitInvalidDataException(
                    "Data does not match union variant 'UpdateFileDetails'",
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
                deserialized.Validate();
                return new UpdateFileRequest(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(
                new ImageKitInvalidDataException(
                    "Data does not match union variant 'ChangePublicationStatus'",
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
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
