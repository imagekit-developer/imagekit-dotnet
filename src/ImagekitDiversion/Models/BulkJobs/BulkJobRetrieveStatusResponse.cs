using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using System = System;

namespace ImagekitDiversion.Models.BulkJobs;

[JsonConverter(
    typeof(JsonModelConverter<BulkJobRetrieveStatusResponse, BulkJobRetrieveStatusResponseFromRaw>)
)]
public sealed record class BulkJobRetrieveStatusResponse : JsonModel
{
    /// <summary>
    /// Unique identifier of the bulk job.
    /// </summary>
    public string? JobID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("jobId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("jobId", value);
        }
    }

    /// <summary>
    /// Unique identifier of the purge request. This will be present only if `purgeCache`
    /// is set to `true` in the rename folder API request.
    /// </summary>
    public string? PurgeRequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("purgeRequestId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("purgeRequestId", value);
        }
    }

    /// <summary>
    /// Status of the bulk job.
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// Type of the bulk job.
    /// </summary>
    public ApiEnum<string, global::ImagekitDiversion.Models.BulkJobs.Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::ImagekitDiversion.Models.BulkJobs.Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.JobID;
        _ = this.PurgeRequestID;
        this.Status?.Validate();
        this.Type?.Validate();
    }

    public BulkJobRetrieveStatusResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BulkJobRetrieveStatusResponse(
        BulkJobRetrieveStatusResponse bulkJobRetrieveStatusResponse
    )
        : base(bulkJobRetrieveStatusResponse) { }
#pragma warning restore CS8618

    public BulkJobRetrieveStatusResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkJobRetrieveStatusResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BulkJobRetrieveStatusResponseFromRaw.FromRawUnchecked"/>
    public static BulkJobRetrieveStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BulkJobRetrieveStatusResponseFromRaw : IFromRawJson<BulkJobRetrieveStatusResponse>
{
    /// <inheritdoc/>
    public BulkJobRetrieveStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BulkJobRetrieveStatusResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of the bulk job.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending,
    Completed,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Pending" => Status.Pending,
            "Completed" => Status.Completed,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Pending => "Pending",
                Status.Completed => "Completed",
                _ => throw new ImagekitDiversionInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Type of the bulk job.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    CopyFolder,
    MoveFolder,
    RenameFolder,
}

sealed class TypeConverter : JsonConverter<global::ImagekitDiversion.Models.BulkJobs.Type>
{
    public override global::ImagekitDiversion.Models.BulkJobs.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "COPY_FOLDER" => global::ImagekitDiversion.Models.BulkJobs.Type.CopyFolder,
            "MOVE_FOLDER" => global::ImagekitDiversion.Models.BulkJobs.Type.MoveFolder,
            "RENAME_FOLDER" => global::ImagekitDiversion.Models.BulkJobs.Type.RenameFolder,
            _ => (global::ImagekitDiversion.Models.BulkJobs.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::ImagekitDiversion.Models.BulkJobs.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::ImagekitDiversion.Models.BulkJobs.Type.CopyFolder => "COPY_FOLDER",
                global::ImagekitDiversion.Models.BulkJobs.Type.MoveFolder => "MOVE_FOLDER",
                global::ImagekitDiversion.Models.BulkJobs.Type.RenameFolder => "RENAME_FOLDER",
                _ => throw new ImagekitDiversionInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
