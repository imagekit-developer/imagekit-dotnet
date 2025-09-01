using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Models;
using Imagekit.Models.Cache.Invalidation.InvalidationGetResponseProperties;
using Imagekit.Models.CustomMetadataFields.CustomMetadataFieldProperties.SchemaProperties;
using Imagekit.Models.Files.FileUpdateParamsProperties.UpdateProperties.UpdateFileDetailsProperties.ExtensionProperties.AutoTaggingExtensionProperties;
using Imagekit.Models.Files.FileUpdateResponseProperties.IntersectionMember1Properties.ExtensionStatusProperties;
using Imagekit.Models.Files.FileUploadParamsProperties.TransformationProperties.PostProperties.AbsProperties;
using Imagekit.Models.ImageOverlayProperties.IntersectionMember1Properties;
using Imagekit.Models.OverlayPositionProperties;
using Imagekit.Models.SubtitleOverlayTransformationProperties;
using Imagekit.Models.TextOverlayTransformationProperties;
using Imagekit.Models.Webhooks.VideoTransformationAcceptedEventProperties.DataProperties.TransformationProperties.OptionsProperties;
using Imagekit.Models.Webhooks.VideoTransformationErrorEventProperties.DataProperties.TransformationProperties.ErrorProperties;
using AbsProperties = Imagekit.Models.Beta.V2.Files.FileUploadParamsProperties.TransformationProperties.PostProperties.AbsProperties;
using AssetListParamsProperties = Imagekit.Models.Assets.AssetListParamsProperties;
using AutoTaggingExtensionProperties = Imagekit.Models.Files.FileUploadParamsProperties.ExtensionProperties.AutoTaggingExtensionProperties;
using ExtensionStatusProperties = Imagekit.Models.Files.FileUploadResponseProperties.ExtensionStatusProperties;
using FileProperties = Imagekit.Models.Files.FileProperties;
using FileUploadParamsProperties = Imagekit.Models.Files.FileUploadParamsProperties;
using FolderProperties = Imagekit.Models.Files.FolderProperties;
using IntersectionMember1Properties = Imagekit.Models.SubtitleOverlayProperties.IntersectionMember1Properties;
using JobGetResponseProperties = Imagekit.Models.Folders.Job.JobGetResponseProperties;
using OptionsProperties = Imagekit.Models.Webhooks.VideoTransformationErrorEventProperties.DataProperties.TransformationProperties.OptionsProperties;
using SchemaProperties = Imagekit.Models.CustomMetadataFields.CustomMetadataFieldCreateParamsProperties.SchemaProperties;
using TransformationProperties = Imagekit.Models.TransformationProperties;

namespace Imagekit;

public abstract record class ModelBase
{
    public Dictionary<string, JsonElement> Properties { get; set; } = [];

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Encoding>(),
            new ApiEnumConverter<string, Focus>(),
            new ApiEnumConverter<string, StreamingResolution>(),
            new ApiEnumConverter<string, IntersectionMember1Properties::Encoding>(),
            new ApiEnumConverter<string, Typography>(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.TextOverlayProperties.IntersectionMember1Properties.Encoding
            >(),
            new ApiEnumConverter<string, Flip>(),
            new ApiEnumConverter<string, InnerAlignment>(),
            new ApiEnumConverter<bool, TransformationProperties::AIRemoveBackground>(),
            new ApiEnumConverter<bool, TransformationProperties::AIRemoveBackgroundExternal>(),
            new ApiEnumConverter<bool, TransformationProperties::AIRetouch>(),
            new ApiEnumConverter<bool, TransformationProperties::AIUpscale>(),
            new ApiEnumConverter<bool, TransformationProperties::AIVariation>(),
            new ApiEnumConverter<string, TransformationProperties::AudioCodec>(),
            new ApiEnumConverter<bool, TransformationProperties::ContrastStretch>(),
            new ApiEnumConverter<string, TransformationProperties::Crop>(),
            new ApiEnumConverter<string, TransformationProperties::CropMode>(),
            new ApiEnumConverter<string, TransformationProperties::Flip>(),
            new ApiEnumConverter<string, TransformationProperties::Format>(),
            new ApiEnumConverter<bool, TransformationProperties::Grayscale>(),
            new ApiEnumConverter<string, TransformationProperties::VideoCodec>(),
            new ApiEnumConverter<string, TransformationPosition>(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.VideoOverlayProperties.IntersectionMember1Properties.Encoding
            >(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, SchemaProperties::Type>(),
            new ApiEnumConverter<string, FileProperties::Type>(),
            new ApiEnumConverter<string, FolderProperties::Type>(),
            new ApiEnumConverter<string, AIAutoDescription>(),
            new ApiEnumConverter<string, AwsAutoTagging>(),
            new ApiEnumConverter<string, GoogleAutoTagging>(),
            new ApiEnumConverter<string, RemoveBg>(),
            new ApiEnumConverter<string, ExtensionStatusProperties::AIAutoDescription>(),
            new ApiEnumConverter<string, ExtensionStatusProperties::AwsAutoTagging>(),
            new ApiEnumConverter<string, ExtensionStatusProperties::GoogleAutoTagging>(),
            new ApiEnumConverter<string, ExtensionStatusProperties::RemoveBg>(),
            new ApiEnumConverter<string, Name>(),
            new ApiEnumConverter<string, AutoTaggingExtensionProperties::Name>(),
            new ApiEnumConverter<string, FileUploadParamsProperties::ResponseField>(),
            new ApiEnumConverter<string, Protocol>(),
            new ApiEnumConverter<string, AssetListParamsProperties::FileType>(),
            new ApiEnumConverter<string, AssetListParamsProperties::Sort>(),
            new ApiEnumConverter<string, AssetListParamsProperties::Type>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, JobGetResponseProperties::Status>(),
            new ApiEnumConverter<string, JobGetResponseProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Beta.V2.Files.FileUploadResponseProperties.ExtensionStatusProperties.AIAutoDescription
            >(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Beta.V2.Files.FileUploadResponseProperties.ExtensionStatusProperties.AwsAutoTagging
            >(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Beta.V2.Files.FileUploadResponseProperties.ExtensionStatusProperties.GoogleAutoTagging
            >(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Beta.V2.Files.FileUploadResponseProperties.ExtensionStatusProperties.RemoveBg
            >(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Beta.V2.Files.FileUploadParamsProperties.ExtensionProperties.AutoTaggingExtensionProperties.Name
            >(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Beta.V2.Files.FileUploadParamsProperties.ResponseField
            >(),
            new ApiEnumConverter<string, AbsProperties::Protocol>(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Webhooks.UploadPostTransformErrorEventProperties.RequestProperties.TransformationProperties.Type
            >(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Webhooks.UploadPostTransformErrorEventProperties.RequestProperties.TransformationProperties.Protocol
            >(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Webhooks.UploadPostTransformSuccessEventProperties.RequestProperties.TransformationProperties.Type
            >(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Webhooks.UploadPostTransformSuccessEventProperties.RequestProperties.TransformationProperties.Protocol
            >(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Webhooks.UploadPreTransformSuccessEventProperties.DataProperties.ExtensionStatusProperties.AIAutoDescription
            >(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Webhooks.UploadPreTransformSuccessEventProperties.DataProperties.ExtensionStatusProperties.AwsAutoTagging
            >(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Webhooks.UploadPreTransformSuccessEventProperties.DataProperties.ExtensionStatusProperties.GoogleAutoTagging
            >(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Webhooks.UploadPreTransformSuccessEventProperties.DataProperties.ExtensionStatusProperties.RemoveBg
            >(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Webhooks.VideoTransformationAcceptedEventProperties.DataProperties.TransformationProperties.Type
            >(),
            new ApiEnumConverter<string, AudioCodec>(),
            new ApiEnumConverter<string, Format>(),
            new ApiEnumConverter<string, StreamProtocol>(),
            new ApiEnumConverter<string, VideoCodec>(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Webhooks.VideoTransformationErrorEventProperties.DataProperties.TransformationProperties.Type
            >(),
            new ApiEnumConverter<string, Reason>(),
            new ApiEnumConverter<string, OptionsProperties::AudioCodec>(),
            new ApiEnumConverter<string, OptionsProperties::Format>(),
            new ApiEnumConverter<string, OptionsProperties::StreamProtocol>(),
            new ApiEnumConverter<string, OptionsProperties::VideoCodec>(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Webhooks.VideoTransformationReadyEventProperties.DataProperties.TransformationProperties.Type
            >(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Webhooks.VideoTransformationReadyEventProperties.DataProperties.TransformationProperties.OptionsProperties.AudioCodec
            >(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Webhooks.VideoTransformationReadyEventProperties.DataProperties.TransformationProperties.OptionsProperties.Format
            >(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Webhooks.VideoTransformationReadyEventProperties.DataProperties.TransformationProperties.OptionsProperties.StreamProtocol
            >(),
            new ApiEnumConverter<
                string,
                global::Imagekit.Models.Webhooks.VideoTransformationReadyEventProperties.DataProperties.TransformationProperties.OptionsProperties.VideoCodec
            >(),
        },
    };

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.Properties, _toStringSerializerOptions);
    }

    public abstract void Validate();
}

interface IFromRaw<T>
{
    static abstract T FromRawUnchecked(Dictionary<string, JsonElement> properties);
}
