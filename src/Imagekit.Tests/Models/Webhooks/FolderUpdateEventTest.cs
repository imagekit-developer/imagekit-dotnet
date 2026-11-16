using System;
using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Files;
using Imagekit.Models.Webhooks;

namespace Imagekit.Tests.Models.Webhooks;

public class FolderUpdateEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FolderUpdateEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { Email = "email", Name = "name" },
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FolderID = "folderId",
                FolderPath = "folderPath",
                Name = "name",
                Type = FolderType.Folder,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Previous = new("folderPath"),
        };

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Folder expectedData = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = new() { Email = "email", Name = "name" },
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            FolderID = "folderId",
            FolderPath = "folderPath",
            Name = "name",
            Type = FolderType.Folder,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Previous expectedPrevious = new("folderPath");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedPrevious, model.Previous);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FolderUpdateEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { Email = "email", Name = "name" },
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FolderID = "folderId",
                FolderPath = "folderPath",
                Name = "name",
                Type = FolderType.Folder,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Previous = new("folderPath"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderUpdateEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FolderUpdateEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { Email = "email", Name = "name" },
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FolderID = "folderId",
                FolderPath = "folderPath",
                Name = "name",
                Type = FolderType.Folder,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Previous = new("folderPath"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderUpdateEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Folder expectedData = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = new() { Email = "email", Name = "name" },
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            FolderID = "folderId",
            FolderPath = "folderPath",
            Name = "name",
            Type = FolderType.Folder,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Previous expectedPrevious = new("folderPath");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedPrevious, deserialized.Previous);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FolderUpdateEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { Email = "email", Name = "name" },
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FolderID = "folderId",
                FolderPath = "folderPath",
                Name = "name",
                Type = FolderType.Folder,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Previous = new("folderPath"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FolderUpdateEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { Email = "email", Name = "name" },
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FolderID = "folderId",
                FolderPath = "folderPath",
                Name = "name",
                Type = FolderType.Folder,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Assert.Null(model.Previous);
        Assert.False(model.RawData.ContainsKey("previous"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FolderUpdateEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { Email = "email", Name = "name" },
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FolderID = "folderId",
                FolderPath = "folderPath",
                Name = "name",
                Type = FolderType.Folder,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FolderUpdateEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { Email = "email", Name = "name" },
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FolderID = "folderId",
                FolderPath = "folderPath",
                Name = "name",
                Type = FolderType.Folder,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },

            // Null should be interpreted as omitted for these properties
            Previous = null,
        };

        Assert.Null(model.Previous);
        Assert.False(model.RawData.ContainsKey("previous"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FolderUpdateEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { Email = "email", Name = "name" },
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FolderID = "folderId",
                FolderPath = "folderPath",
                Name = "name",
                Type = FolderType.Folder,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },

            // Null should be interpreted as omitted for these properties
            Previous = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FolderUpdateEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { Email = "email", Name = "name" },
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FolderID = "folderId",
                FolderPath = "folderPath",
                Name = "name",
                Type = FolderType.Folder,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Previous = new("folderPath"),
        };

        FolderUpdateEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FolderUpdateEventFolderUpdateEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FolderUpdateEventFolderUpdateEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { Email = "email", Name = "name" },
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FolderID = "folderId",
                FolderPath = "folderPath",
                Name = "name",
                Type = FolderType.Folder,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Previous = new("folderPath"),
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Folder expectedData = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = new() { Email = "email", Name = "name" },
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            FolderID = "folderId",
            FolderPath = "folderPath",
            Name = "name",
            Type = FolderType.Folder,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("folder.updated");
        Previous expectedPrevious = new("folderPath");

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedPrevious, model.Previous);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FolderUpdateEventFolderUpdateEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { Email = "email", Name = "name" },
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FolderID = "folderId",
                FolderPath = "folderPath",
                Name = "name",
                Type = FolderType.Folder,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Previous = new("folderPath"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderUpdateEventFolderUpdateEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FolderUpdateEventFolderUpdateEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { Email = "email", Name = "name" },
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FolderID = "folderId",
                FolderPath = "folderPath",
                Name = "name",
                Type = FolderType.Folder,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Previous = new("folderPath"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderUpdateEventFolderUpdateEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Folder expectedData = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = new() { Email = "email", Name = "name" },
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            FolderID = "folderId",
            FolderPath = "folderPath",
            Name = "name",
            Type = FolderType.Folder,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("folder.updated");
        Previous expectedPrevious = new("folderPath");

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedPrevious, deserialized.Previous);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FolderUpdateEventFolderUpdateEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { Email = "email", Name = "name" },
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FolderID = "folderId",
                FolderPath = "folderPath",
                Name = "name",
                Type = FolderType.Folder,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Previous = new("folderPath"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FolderUpdateEventFolderUpdateEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { Email = "email", Name = "name" },
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FolderID = "folderId",
                FolderPath = "folderPath",
                Name = "name",
                Type = FolderType.Folder,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Assert.Null(model.Previous);
        Assert.False(model.RawData.ContainsKey("previous"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FolderUpdateEventFolderUpdateEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { Email = "email", Name = "name" },
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FolderID = "folderId",
                FolderPath = "folderPath",
                Name = "name",
                Type = FolderType.Folder,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FolderUpdateEventFolderUpdateEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { Email = "email", Name = "name" },
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FolderID = "folderId",
                FolderPath = "folderPath",
                Name = "name",
                Type = FolderType.Folder,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },

            // Null should be interpreted as omitted for these properties
            Previous = null,
        };

        Assert.Null(model.Previous);
        Assert.False(model.RawData.ContainsKey("previous"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FolderUpdateEventFolderUpdateEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { Email = "email", Name = "name" },
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FolderID = "folderId",
                FolderPath = "folderPath",
                Name = "name",
                Type = FolderType.Folder,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },

            // Null should be interpreted as omitted for these properties
            Previous = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FolderUpdateEventFolderUpdateEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { Email = "email", Name = "name" },
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FolderID = "folderId",
                FolderPath = "folderPath",
                Name = "name",
                Type = FolderType.Folder,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Previous = new("folderPath"),
        };

        FolderUpdateEventFolderUpdateEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PreviousTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Previous { FolderPath = "folderPath" };

        string expectedFolderPath = "folderPath";

        Assert.Equal(expectedFolderPath, model.FolderPath);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Previous { FolderPath = "folderPath" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Previous>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Previous { FolderPath = "folderPath" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Previous>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFolderPath = "folderPath";

        Assert.Equal(expectedFolderPath, deserialized.FolderPath);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Previous { FolderPath = "folderPath" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Previous { FolderPath = "folderPath" };

        Previous copied = new(model);

        Assert.Equal(model, copied);
    }
}
