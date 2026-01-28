using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Files.FileUpdateParamsProperties.BodyProperties;
using BodyVariants = Imagekit.Models.Files.FileUpdateParamsProperties.BodyVariants;

namespace Imagekit.Models.Files.FileUpdateParamsProperties;

[JsonConverter(typeof(BodyConverter))]
public abstract record class Body
{
    internal Body() { }

    public static implicit operator Body(UpdateFileDetails value) =>
        new BodyVariants::UpdateFileDetails(value);

    public static implicit operator Body(ChangePublicationStatus value) =>
        new BodyVariants::ChangePublicationStatus(value);

    public bool TryPickUpdateFileDetails([NotNullWhen(true)] out UpdateFileDetails? value)
    {
        value = (this as BodyVariants::UpdateFileDetails)?.Value;
        return value != null;
    }

    public bool TryPickChangePublicationStatus(
        [NotNullWhen(true)] out ChangePublicationStatus? value
    )
    {
        value = (this as BodyVariants::ChangePublicationStatus)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BodyVariants::UpdateFileDetails> updateFileDetails,
        Action<BodyVariants::ChangePublicationStatus> changePublicationStatus
    )
    {
        switch (this)
        {
            case BodyVariants::UpdateFileDetails inner:
                updateFileDetails(inner);
                break;
            case BodyVariants::ChangePublicationStatus inner:
                changePublicationStatus(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BodyVariants::UpdateFileDetails, T> updateFileDetails,
        Func<BodyVariants::ChangePublicationStatus, T> changePublicationStatus
    )
    {
        return this switch
        {
            BodyVariants::UpdateFileDetails inner => updateFileDetails(inner),
            BodyVariants::ChangePublicationStatus inner => changePublicationStatus(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BodyConverter : JsonConverter<Body>
{
    public override Body? Read(
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
                return new BodyVariants::UpdateFileDetails(deserialized);
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
                return new BodyVariants::ChangePublicationStatus(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Body value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            BodyVariants::UpdateFileDetails(var updateFileDetails) => updateFileDetails,
            BodyVariants::ChangePublicationStatus(var changePublicationStatus) =>
                changePublicationStatus,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
