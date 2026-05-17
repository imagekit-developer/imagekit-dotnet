using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;
using System = System;

namespace Imagekit.Models.Folders.Job;

[JsonConverter(typeof(JsonModelConverter<JobGetResponse, JobGetResponseFromRaw>))]
public sealed record class JobGetResponse : JsonModel
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
    public ApiEnum<string, global::Imagekit.Models.Folders.Job.Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::Imagekit.Models.Folders.Job.Type>
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

    public JobGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobGetResponse(JobGetResponse jobGetResponse)
        : base(jobGetResponse) { }
#pragma warning restore CS8618

    public JobGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JobGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JobGetResponseFromRaw.FromRawUnchecked"/>
    public static JobGetResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JobGetResponseFromRaw : IFromRawJson<JobGetResponse>
{
    /// <inheritdoc/>
    public JobGetResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JobGetResponse.FromRawUnchecked(rawData);
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
                _ => throw new ImageKitInvalidDataException(
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

sealed class TypeConverter : JsonConverter<global::Imagekit.Models.Folders.Job.Type>
{
    public override global::Imagekit.Models.Folders.Job.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "COPY_FOLDER" => global::Imagekit.Models.Folders.Job.Type.CopyFolder,
            "MOVE_FOLDER" => global::Imagekit.Models.Folders.Job.Type.MoveFolder,
            "RENAME_FOLDER" => global::Imagekit.Models.Folders.Job.Type.RenameFolder,
            _ => (global::Imagekit.Models.Folders.Job.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Imagekit.Models.Folders.Job.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Imagekit.Models.Folders.Job.Type.CopyFolder => "COPY_FOLDER",
                global::Imagekit.Models.Folders.Job.Type.MoveFolder => "MOVE_FOLDER",
                global::Imagekit.Models.Folders.Job.Type.RenameFolder => "RENAME_FOLDER",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
