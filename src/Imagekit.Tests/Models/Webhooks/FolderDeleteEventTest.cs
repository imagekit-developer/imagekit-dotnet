using System;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Webhooks;

namespace Imagekit.Tests.Models.Webhooks;

public class FolderDeleteEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FolderDeleteEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FolderID = "folderId", FolderPath = "folderPath" },
        };

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        FolderDeleteEventFolderDeleteEventData expectedData = new()
        {
            FolderID = "folderId",
            FolderPath = "folderPath",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FolderDeleteEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FolderID = "folderId", FolderPath = "folderPath" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderDeleteEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FolderDeleteEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FolderID = "folderId", FolderPath = "folderPath" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderDeleteEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        FolderDeleteEventFolderDeleteEventData expectedData = new()
        {
            FolderID = "folderId",
            FolderPath = "folderPath",
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FolderDeleteEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FolderID = "folderId", FolderPath = "folderPath" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FolderDeleteEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FolderID = "folderId", FolderPath = "folderPath" },
        };

        FolderDeleteEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FolderDeleteEventFolderDeleteEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FolderDeleteEventFolderDeleteEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FolderID = "folderId", FolderPath = "folderPath" },
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        FolderDeleteEventFolderDeleteEventData expectedData = new()
        {
            FolderID = "folderId",
            FolderPath = "folderPath",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("folder.deleted");

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FolderDeleteEventFolderDeleteEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FolderID = "folderId", FolderPath = "folderPath" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderDeleteEventFolderDeleteEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FolderDeleteEventFolderDeleteEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FolderID = "folderId", FolderPath = "folderPath" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderDeleteEventFolderDeleteEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        FolderDeleteEventFolderDeleteEventData expectedData = new()
        {
            FolderID = "folderId",
            FolderPath = "folderPath",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("folder.deleted");

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FolderDeleteEventFolderDeleteEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FolderID = "folderId", FolderPath = "folderPath" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FolderDeleteEventFolderDeleteEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FolderID = "folderId", FolderPath = "folderPath" },
        };

        FolderDeleteEventFolderDeleteEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FolderDeleteEventFolderDeleteEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FolderDeleteEventFolderDeleteEventData
        {
            FolderID = "folderId",
            FolderPath = "folderPath",
        };

        string expectedFolderID = "folderId";
        string expectedFolderPath = "folderPath";

        Assert.Equal(expectedFolderID, model.FolderID);
        Assert.Equal(expectedFolderPath, model.FolderPath);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FolderDeleteEventFolderDeleteEventData
        {
            FolderID = "folderId",
            FolderPath = "folderPath",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderDeleteEventFolderDeleteEventData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FolderDeleteEventFolderDeleteEventData
        {
            FolderID = "folderId",
            FolderPath = "folderPath",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderDeleteEventFolderDeleteEventData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFolderID = "folderId";
        string expectedFolderPath = "folderPath";

        Assert.Equal(expectedFolderID, deserialized.FolderID);
        Assert.Equal(expectedFolderPath, deserialized.FolderPath);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FolderDeleteEventFolderDeleteEventData
        {
            FolderID = "folderId",
            FolderPath = "folderPath",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FolderDeleteEventFolderDeleteEventData { FolderID = "folderId" };

        Assert.Null(model.FolderPath);
        Assert.False(model.RawData.ContainsKey("folderPath"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FolderDeleteEventFolderDeleteEventData { FolderID = "folderId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FolderDeleteEventFolderDeleteEventData
        {
            FolderID = "folderId",

            // Null should be interpreted as omitted for these properties
            FolderPath = null,
        };

        Assert.Null(model.FolderPath);
        Assert.False(model.RawData.ContainsKey("folderPath"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FolderDeleteEventFolderDeleteEventData
        {
            FolderID = "folderId",

            // Null should be interpreted as omitted for these properties
            FolderPath = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FolderDeleteEventFolderDeleteEventData
        {
            FolderID = "folderId",
            FolderPath = "folderPath",
        };

        FolderDeleteEventFolderDeleteEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}
