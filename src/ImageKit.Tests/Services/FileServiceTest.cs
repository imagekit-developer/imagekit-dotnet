using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ImageKit.Models.Files;
using Models = ImageKit.Models;

namespace ImageKit.Tests.Services;

public class FileServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var file = await this.client.Files.Update(
            "fileId",
            new()
            {
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
                        new Models::UnnamedSchemaWithArrayParent0RemoveBg()
                        {
                            Options = new()
                            {
                                AddShadow = true,
                                BgColor = "bg_color",
                                BgImageUrl = "bg_image_url",
                                Semitransparency = true,
                            },
                        },
                        new Models::UnnamedSchemaWithArrayParent0AutoTaggingExtension()
                        {
                            MaxTags = 10,
                            MinConfidence = 80,
                            Name =
                                Models::UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.GoogleAutoTagging,
                        },
                        new Models::UnnamedSchemaWithArrayParent0AutoTaggingExtension()
                        {
                            MaxTags = 10,
                            MinConfidence = 80,
                            Name =
                                Models::UnnamedSchemaWithArrayParent0AutoTaggingExtensionName.AwsAutoTagging,
                        },
                        new Models::UnnamedSchemaWithArrayParent0AIAutoDescription(),
                        new Models::UnnamedSchemaWithArrayParent0AITasks(
                            [
                                new Models::UnnamedSchemaWithArrayParent0AITasksTaskSelectTags()
                                {
                                    Instruction = "What types of clothing items are visible?",
                                    MaxSelections = 1,
                                    MinSelections = 0,
                                    Vocabulary = ["shirt", "dress", "jacket"],
                                },
                            ]
                        ),
                        new Models::SavedExtension("ext_abc123"),
                    ],
                    RemoveAITags = new(["car", "vehicle", "motorsports"]),
                    Tags = ["tag1", "tag2"],
                    WebhookUrl = "https://webhook.site/0d6b6c7a-8e5a-4b3a-8b7c-0d6b6c7a8e5a",
                },
            },
            TestContext.Current.CancellationToken
        );
        file.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Files.Delete("fileId", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Copy_Works()
    {
        var response = await this.client.Files.Copy(
            new()
            {
                DestinationPath = "/folder/to/copy/into/",
                SourceFilePath = "/path/to/file.jpg",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var file = await this.client.Files.Get(
            "fileId",
            new(),
            TestContext.Current.CancellationToken
        );
        file.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Move_Works()
    {
        var response = await this.client.Files.Move(
            new()
            {
                DestinationPath = "/folder/to/move/into/",
                SourceFilePath = "/path/to/file.jpg",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Rename_Works()
    {
        var response = await this.client.Files.Rename(
            new() { FilePath = "/path/to/file.jpg", NewFileName = "newFileName.jpg" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Upload_Works()
    {
        var response = await this.client.Files.Upload(
            new() { File = Encoding.UTF8.GetBytes("text"), FileName = "fileName" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
