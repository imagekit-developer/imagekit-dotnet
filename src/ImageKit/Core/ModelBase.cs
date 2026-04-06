using System.Text.Json;
using ImageKit.Exceptions;
using ImageKit.Models;
using ImageKit.Models.Cache.Invalidation;
using ImageKit.Models.CustomMetadataFields;
using Assets = ImageKit.Models.Assets;
using Files = ImageKit.Models.Files;
using Job = ImageKit.Models.Folders.Job;
using V2Files = ImageKit.Models.Beta.V2.Files;
using Webhooks = ImageKit.Models.Webhooks;

namespace ImageKit.Core;

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
            new ApiEnumConverter<string, LayerMode>(),
            new ApiEnumConverter<string, Name>(),
            new ApiEnumConverter<string, UnnamedSchemaWithArrayParent0AutoTaggingExtensionName>(),
            new ApiEnumConverter<string, Encoding>(),
            new ApiEnumConverter<string, AnchorPoint>(),
            new ApiEnumConverter<string, Focus>(),
            new ApiEnumConverter<string, StreamingResolution>(),
            new ApiEnumConverter<string, SubtitleOverlayIntersectionMember1Encoding>(),
            new ApiEnumConverter<string, Typography>(),
            new ApiEnumConverter<string, TextOverlayIntersectionMember1Encoding>(),
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
            new ApiEnumConverter<string, VideoCodec>(),
            new ApiEnumConverter<string, TransformationPosition>(),
            new ApiEnumConverter<string, VideoOverlayIntersectionMember1Encoding>(),
            new ApiEnumConverter<string, CustomMetadataFieldSchemaType>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, Files::Type>(),
            new ApiEnumConverter<string, Files::FileType>(),
            new ApiEnumConverter<string, Files::FolderType>(),
            new ApiEnumConverter<string, Files::AIAutoDescription>(),
            new ApiEnumConverter<string, Files::AITasks>(),
            new ApiEnumConverter<string, Files::AwsAutoTagging>(),
            new ApiEnumConverter<string, Files::GoogleAutoTagging>(),
            new ApiEnumConverter<string, Files::RemoveBg>(),
            new ApiEnumConverter<
                string,
                Files::FileUploadResponseExtensionStatusAIAutoDescription
            >(),
            new ApiEnumConverter<string, Files::FileUploadResponseExtensionStatusAITasks>(),
            new ApiEnumConverter<string, Files::FileUploadResponseExtensionStatusAwsAutoTagging>(),
            new ApiEnumConverter<
                string,
                Files::FileUploadResponseExtensionStatusGoogleAutoTagging
            >(),
            new ApiEnumConverter<string, Files::FileUploadResponseExtensionStatusRemoveBg>(),
            new ApiEnumConverter<string, Files::FileUploadResponseSelectedFieldsSchemaItemType>(),
            new ApiEnumConverter<string, Files::ResponseField>(),
            new ApiEnumConverter<string, Files::Protocol>(),
            new ApiEnumConverter<string, Assets::FileType>(),
            new ApiEnumConverter<string, Assets::Sort>(),
            new ApiEnumConverter<string, Assets::Type>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Job::Status>(),
            new ApiEnumConverter<string, Job::Type>(),
            new ApiEnumConverter<string, V2Files::AIAutoDescription>(),
            new ApiEnumConverter<string, V2Files::AITasks>(),
            new ApiEnumConverter<string, V2Files::AwsAutoTagging>(),
            new ApiEnumConverter<string, V2Files::GoogleAutoTagging>(),
            new ApiEnumConverter<string, V2Files::RemoveBg>(),
            new ApiEnumConverter<string, V2Files::Type>(),
            new ApiEnumConverter<string, V2Files::ResponseField>(),
            new ApiEnumConverter<string, V2Files::Protocol>(),
            new ApiEnumConverter<string, Webhooks::Type>(),
            new ApiEnumConverter<string, Webhooks::Protocol>(),
            new ApiEnumConverter<
                string,
                Webhooks::UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType
            >(),
            new ApiEnumConverter<
                string,
                Webhooks::UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol
            >(),
            new ApiEnumConverter<string, Webhooks::AIAutoDescription>(),
            new ApiEnumConverter<string, Webhooks::AITasks>(),
            new ApiEnumConverter<string, Webhooks::AwsAutoTagging>(),
            new ApiEnumConverter<string, Webhooks::GoogleAutoTagging>(),
            new ApiEnumConverter<string, Webhooks::RemoveBg>(),
            new ApiEnumConverter<string, Webhooks::SelectedFieldsSchemaItemType>(),
            new ApiEnumConverter<
                string,
                Webhooks::VideoTransformationAcceptedEventIntersectionMember1DataTransformationType
            >(),
            new ApiEnumConverter<string, Webhooks::AudioCodec>(),
            new ApiEnumConverter<string, Webhooks::Format>(),
            new ApiEnumConverter<string, Webhooks::StreamProtocol>(),
            new ApiEnumConverter<string, Webhooks::VideoCodec>(),
            new ApiEnumConverter<
                string,
                Webhooks::VideoTransformationErrorEventIntersectionMember1DataTransformationType
            >(),
            new ApiEnumConverter<string, Webhooks::Reason>(),
            new ApiEnumConverter<
                string,
                Webhooks::VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec
            >(),
            new ApiEnumConverter<
                string,
                Webhooks::VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat
            >(),
            new ApiEnumConverter<
                string,
                Webhooks::VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol
            >(),
            new ApiEnumConverter<
                string,
                Webhooks::VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec
            >(),
            new ApiEnumConverter<
                string,
                Webhooks::VideoTransformationReadyEventIntersectionMember1DataTransformationType
            >(),
            new ApiEnumConverter<
                string,
                Webhooks::VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec
            >(),
            new ApiEnumConverter<
                string,
                Webhooks::VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat
            >(),
            new ApiEnumConverter<
                string,
                Webhooks::VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol
            >(),
            new ApiEnumConverter<
                string,
                Webhooks::VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec
            >(),
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
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
