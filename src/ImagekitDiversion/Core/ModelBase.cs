using System.Text.Json;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.Api.V1.Files;
using ImagekitDiversion.Models.Dummy;
using ImagekitDiversion.Models.Files.Purge;
using BulkJobs = ImagekitDiversion.Models.BulkJobs;
using CustomMetadataFields = ImagekitDiversion.Models.CustomMetadataFields;
using Details = ImagekitDiversion.Models.Files.Details;
using Files = ImagekitDiversion.Models.Api.V2.Files;
using ModelsFiles = ImagekitDiversion.Models.Files;

namespace ImagekitDiversion.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, Name>(),
            new ApiEnumConverter<string, LayerMode>(),
            new ApiEnumConverter<string, ImageOverlayImageOverlayEncoding>(),
            new ApiEnumConverter<string, TextTextOverlayEncoding>(),
            new ApiEnumConverter<string, SubtitleSubtitleOverlayEncoding>(),
            new ApiEnumConverter<string, AnchorPoint>(),
            new ApiEnumConverter<string, Focus>(),
            new ApiEnumConverter<string, Typography>(),
            new ApiEnumConverter<string, Flip>(),
            new ApiEnumConverter<string, InnerAlignment>(),
            new ApiEnumConverter<bool, AIRemoveBackground>(),
            new ApiEnumConverter<bool, AIRemoveBackgroundExternal>(),
            new ApiEnumConverter<bool, AIRetouch>(),
            new ApiEnumConverter<bool, AIUpscale>(),
            new ApiEnumConverter<bool, AIVariation>(),
            new ApiEnumConverter<string, AudioCodec>(),
            new ApiEnumConverter<bool, ContrastStretch>(),
            new ApiEnumConverter<string, Crop>(),
            new ApiEnumConverter<string, CropMode>(),
            new ApiEnumConverter<string, TransformationFlip>(),
            new ApiEnumConverter<string, Format>(),
            new ApiEnumConverter<bool, Grayscale>(),
            new ApiEnumConverter<string, TransformationStreamingResolution>(),
            new ApiEnumConverter<string, VideoCodec>(),
            new ApiEnumConverter<string, TransformationPosition>(),
            new ApiEnumConverter<string, VideoOverlayVideoOverlayEncoding>(),
            new ApiEnumConverter<string, StreamingResolution>(),
            new ApiEnumConverter<string, Encoding>(),
            new ApiEnumConverter<string, TextOverlayTextOverlayEncoding>(),
            new ApiEnumConverter<string, Protocol>(),
            new ApiEnumConverter<string, AIAutoDescription>(),
            new ApiEnumConverter<string, AITasks>(),
            new ApiEnumConverter<string, AwsAutoTagging>(),
            new ApiEnumConverter<string, GoogleAutoTagging>(),
            new ApiEnumConverter<string, RemoveBg>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, ResponseField>(),
            new ApiEnumConverter<string, Files::ResponseField>(),
            new ApiEnumConverter<string, CustomMetadataFields::CustomMetadataFieldSchemaType>(),
            new ApiEnumConverter<string, CustomMetadataFields::Type>(),
            new ApiEnumConverter<string, ModelsFiles::FileListResponseFolderType>(),
            new ApiEnumConverter<string, ModelsFiles::FileType>(),
            new ApiEnumConverter<string, ModelsFiles::Sort>(),
            new ApiEnumConverter<string, ModelsFiles::Type>(),
            new ApiEnumConverter<string, Details::Type>(),
            new ApiEnumConverter<string, Details::FileDetailsType>(),
            new ApiEnumConverter<string, Details::AIAutoDescription>(),
            new ApiEnumConverter<string, Details::AITasks>(),
            new ApiEnumConverter<string, Details::AwsAutoTagging>(),
            new ApiEnumConverter<string, Details::GoogleAutoTagging>(),
            new ApiEnumConverter<string, Details::RemoveBg>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, BulkJobs::Status>(),
            new ApiEnumConverter<string, BulkJobs::Type>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImagekitDiversionInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
