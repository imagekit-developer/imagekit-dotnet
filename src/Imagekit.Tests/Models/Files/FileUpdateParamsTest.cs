using System;
using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Models;
using Imagekit.Models.Files;

namespace Imagekit.Tests.Models.Files;

public class FileUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileUpdateParams
        {
            FileID = "fileId",
            UpdateFileRequest = new UpdateFileDetails()
            {
                CustomCoordinates = "10,10,100,100",
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "brand", JsonSerializer.SerializeToElement("bar") },
                    { "color", JsonSerializer.SerializeToElement("bar") },
                },
                Description = "description",
                Extensions =
                [
                    new ExtensionItemRemoveBg()
                    {
                        Options = new()
                        {
                            AddShadow = true,
                            BgColor = "bg_color",
                            BgImageUrl = "bg_image_url",
                            Semitransparency = true,
                        },
                    },
                    new ExtensionItemAutoTaggingExtension()
                    {
                        MaxTags = 10,
                        MinConfidence = 80,
                        Name = ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging,
                    },
                    new ExtensionItemAutoTaggingExtension()
                    {
                        MaxTags = 10,
                        MinConfidence = 80,
                        Name = ExtensionItemAutoTaggingExtensionName.AwsAutoTagging,
                    },
                    new ExtensionItemAIAutoDescription(),
                    new ExtensionItemAITasks(
                        [
                            new ExtensionItemAITasksTaskSelectTags()
                            {
                                Instruction = "What types of clothing items are visible?",
                                MaxSelections = 1,
                                MinSelections = 0,
                                Vocabulary = ["shirt", "dress", "jacket"],
                            },
                        ]
                    ),
                    new SavedExtension("ext_abc123"),
                ],
                RemoveAITags = new(["car", "vehicle", "motorsports"]),
                Tags = ["tag1", "tag2"],
                WebhookUrl = "https://webhook.site/0d6b6c7a-8e5a-4b3a-8b7c-0d6b6c7a8e5a",
            },
        };

        string expectedFileID = "fileId";
        UpdateFileRequest expectedUpdateFileRequest = new UpdateFileDetails()
        {
            CustomCoordinates = "10,10,100,100",
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "brand", JsonSerializer.SerializeToElement("bar") },
                { "color", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            Extensions =
            [
                new ExtensionItemRemoveBg()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                new ExtensionItemAutoTaggingExtension()
                {
                    MaxTags = 10,
                    MinConfidence = 80,
                    Name = ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging,
                },
                new ExtensionItemAutoTaggingExtension()
                {
                    MaxTags = 10,
                    MinConfidence = 80,
                    Name = ExtensionItemAutoTaggingExtensionName.AwsAutoTagging,
                },
                new ExtensionItemAIAutoDescription(),
                new ExtensionItemAITasks(
                    [
                        new ExtensionItemAITasksTaskSelectTags()
                        {
                            Instruction = "What types of clothing items are visible?",
                            MaxSelections = 1,
                            MinSelections = 0,
                            Vocabulary = ["shirt", "dress", "jacket"],
                        },
                    ]
                ),
                new SavedExtension("ext_abc123"),
            ],
            RemoveAITags = new(["car", "vehicle", "motorsports"]),
            Tags = ["tag1", "tag2"],
            WebhookUrl = "https://webhook.site/0d6b6c7a-8e5a-4b3a-8b7c-0d6b6c7a8e5a",
        };

        Assert.Equal(expectedFileID, parameters.FileID);
        Assert.Equal(expectedUpdateFileRequest, parameters.UpdateFileRequest);
    }

    [Fact]
    public void Url_Works()
    {
        FileUpdateParams parameters = new()
        {
            FileID = "fileId",
            UpdateFileRequest = new UpdateFileDetails()
            {
                CustomCoordinates = "10,10,100,100",
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "brand", JsonSerializer.SerializeToElement("bar") },
                    { "color", JsonSerializer.SerializeToElement("bar") },
                },
                Description = "description",
                Extensions =
                [
                    new ExtensionItemRemoveBg()
                    {
                        Options = new()
                        {
                            AddShadow = true,
                            BgColor = "bg_color",
                            BgImageUrl = "bg_image_url",
                            Semitransparency = true,
                        },
                    },
                    new ExtensionItemAutoTaggingExtension()
                    {
                        MaxTags = 10,
                        MinConfidence = 80,
                        Name = ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging,
                    },
                    new ExtensionItemAutoTaggingExtension()
                    {
                        MaxTags = 10,
                        MinConfidence = 80,
                        Name = ExtensionItemAutoTaggingExtensionName.AwsAutoTagging,
                    },
                    new ExtensionItemAIAutoDescription(),
                    new ExtensionItemAITasks(
                        [
                            new ExtensionItemAITasksTaskSelectTags()
                            {
                                Instruction = "What types of clothing items are visible?",
                                MaxSelections = 1,
                                MinSelections = 0,
                                Vocabulary = ["shirt", "dress", "jacket"],
                            },
                        ]
                    ),
                    new SavedExtension("ext_abc123"),
                ],
                RemoveAITags = new(["car", "vehicle", "motorsports"]),
                Tags = ["tag1", "tag2"],
                WebhookUrl = "https://webhook.site/0d6b6c7a-8e5a-4b3a-8b7c-0d6b6c7a8e5a",
            },
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/files/fileId/details"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileUpdateParams
        {
            FileID = "fileId",
            UpdateFileRequest = new UpdateFileDetails()
            {
                CustomCoordinates = "10,10,100,100",
                CustomMetadata = new Dictionary<string, JsonElement>()
                {
                    { "brand", JsonSerializer.SerializeToElement("bar") },
                    { "color", JsonSerializer.SerializeToElement("bar") },
                },
                Description = "description",
                Extensions =
                [
                    new ExtensionItemRemoveBg()
                    {
                        Options = new()
                        {
                            AddShadow = true,
                            BgColor = "bg_color",
                            BgImageUrl = "bg_image_url",
                            Semitransparency = true,
                        },
                    },
                    new ExtensionItemAutoTaggingExtension()
                    {
                        MaxTags = 10,
                        MinConfidence = 80,
                        Name = ExtensionItemAutoTaggingExtensionName.GoogleAutoTagging,
                    },
                    new ExtensionItemAutoTaggingExtension()
                    {
                        MaxTags = 10,
                        MinConfidence = 80,
                        Name = ExtensionItemAutoTaggingExtensionName.AwsAutoTagging,
                    },
                    new ExtensionItemAIAutoDescription(),
                    new ExtensionItemAITasks(
                        [
                            new ExtensionItemAITasksTaskSelectTags()
                            {
                                Instruction = "What types of clothing items are visible?",
                                MaxSelections = 1,
                                MinSelections = 0,
                                Vocabulary = ["shirt", "dress", "jacket"],
                            },
                        ]
                    ),
                    new SavedExtension("ext_abc123"),
                ],
                RemoveAITags = new(["car", "vehicle", "motorsports"]),
                Tags = ["tag1", "tag2"],
                WebhookUrl = "https://webhook.site/0d6b6c7a-8e5a-4b3a-8b7c-0d6b6c7a8e5a",
            },
        };

        FileUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
