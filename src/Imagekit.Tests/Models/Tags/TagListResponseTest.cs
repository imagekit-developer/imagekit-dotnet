using System;
using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Tags;

namespace Imagekit.Tests.Models.Tags;

public class TagListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TagListResponse
        {
            NextCursor = "nextCursor",
            Tags =
            [
                new()
                {
                    AssetCount = 0,
                    Label = "label",
                    LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                },
            ],
        };

        string expectedNextCursor = "nextCursor";
        List<Tag> expectedTags =
        [
            new()
            {
                AssetCount = 0,
                Label = "label",
                LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
            },
        ];

        Assert.Equal(expectedNextCursor, model.NextCursor);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TagListResponse
        {
            NextCursor = "nextCursor",
            Tags =
            [
                new()
                {
                    AssetCount = 0,
                    Label = "label",
                    LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TagListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TagListResponse
        {
            NextCursor = "nextCursor",
            Tags =
            [
                new()
                {
                    AssetCount = 0,
                    Label = "label",
                    LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TagListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNextCursor = "nextCursor";
        List<Tag> expectedTags =
        [
            new()
            {
                AssetCount = 0,
                Label = "label",
                LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Name = "name",
            },
        ];

        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TagListResponse
        {
            NextCursor = "nextCursor",
            Tags =
            [
                new()
                {
                    AssetCount = 0,
                    Label = "label",
                    LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TagListResponse
        {
            NextCursor = "nextCursor",
            Tags =
            [
                new()
                {
                    AssetCount = 0,
                    Label = "label",
                    LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Name = "name",
                },
            ],
        };

        TagListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
