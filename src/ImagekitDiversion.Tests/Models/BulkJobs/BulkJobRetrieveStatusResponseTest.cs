using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.BulkJobs;

namespace ImagekitDiversion.Tests.Models.BulkJobs;

public class BulkJobRetrieveStatusResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BulkJobRetrieveStatusResponse
        {
            JobID = "5d5b1a9b4c8c4c0001f3e4a2",
            PurgeRequestID = "purgeRequestId",
            Status = Status.Completed,
            Type = Type.CopyFolder,
        };

        string expectedJobID = "5d5b1a9b4c8c4c0001f3e4a2";
        string expectedPurgeRequestID = "purgeRequestId";
        ApiEnum<string, Status> expectedStatus = Status.Completed;
        ApiEnum<string, Type> expectedType = Type.CopyFolder;

        Assert.Equal(expectedJobID, model.JobID);
        Assert.Equal(expectedPurgeRequestID, model.PurgeRequestID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BulkJobRetrieveStatusResponse
        {
            JobID = "5d5b1a9b4c8c4c0001f3e4a2",
            PurgeRequestID = "purgeRequestId",
            Status = Status.Completed,
            Type = Type.CopyFolder,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BulkJobRetrieveStatusResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BulkJobRetrieveStatusResponse
        {
            JobID = "5d5b1a9b4c8c4c0001f3e4a2",
            PurgeRequestID = "purgeRequestId",
            Status = Status.Completed,
            Type = Type.CopyFolder,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BulkJobRetrieveStatusResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedJobID = "5d5b1a9b4c8c4c0001f3e4a2";
        string expectedPurgeRequestID = "purgeRequestId";
        ApiEnum<string, Status> expectedStatus = Status.Completed;
        ApiEnum<string, Type> expectedType = Type.CopyFolder;

        Assert.Equal(expectedJobID, deserialized.JobID);
        Assert.Equal(expectedPurgeRequestID, deserialized.PurgeRequestID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BulkJobRetrieveStatusResponse
        {
            JobID = "5d5b1a9b4c8c4c0001f3e4a2",
            PurgeRequestID = "purgeRequestId",
            Status = Status.Completed,
            Type = Type.CopyFolder,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BulkJobRetrieveStatusResponse { };

        Assert.Null(model.JobID);
        Assert.False(model.RawData.ContainsKey("jobId"));
        Assert.Null(model.PurgeRequestID);
        Assert.False(model.RawData.ContainsKey("purgeRequestId"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BulkJobRetrieveStatusResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BulkJobRetrieveStatusResponse
        {
            // Null should be interpreted as omitted for these properties
            JobID = null,
            PurgeRequestID = null,
            Status = null,
            Type = null,
        };

        Assert.Null(model.JobID);
        Assert.False(model.RawData.ContainsKey("jobId"));
        Assert.Null(model.PurgeRequestID);
        Assert.False(model.RawData.ContainsKey("purgeRequestId"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BulkJobRetrieveStatusResponse
        {
            // Null should be interpreted as omitted for these properties
            JobID = null,
            PurgeRequestID = null,
            Status = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BulkJobRetrieveStatusResponse
        {
            JobID = "5d5b1a9b4c8c4c0001f3e4a2",
            PurgeRequestID = "purgeRequestId",
            Status = Status.Completed,
            Type = Type.CopyFolder,
        };

        BulkJobRetrieveStatusResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Completed)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Completed)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.CopyFolder)]
    [InlineData(Type.MoveFolder)]
    [InlineData(Type.RenameFolder)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.CopyFolder)]
    [InlineData(Type.MoveFolder)]
    [InlineData(Type.RenameFolder)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
