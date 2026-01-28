using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Imagekit.Models.Files.UpdateFileRequestProperties;
using Imagekit.Models.UnnamedSchemaWithArrayParent0Properties;
using Imagekit.Models.UnnamedSchemaWithArrayParent0Properties.AutoTaggingExtensionProperties;

namespace Imagekit.Tests.Services.Files;

public class FileServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var file = await this.client.Files.Update(
            new()
            {
                FileID = "fileId",
                UpdateFileRequest = new(
                    new UpdateFileDetails()
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
                            new(
                                new RemoveBg()
                                {
                                    Options = new()
                                    {
                                        AddShadow = true,
                                        BgColor = "bg_color",
                                        BgImageURL = "bg_image_url",
                                        Semitransparency = true,
                                    },
                                }
                            ),
                            new(
                                new AutoTaggingExtension()
                                {
                                    MaxTags = 10,
                                    MinConfidence = 80,
                                    Name = Name.GoogleAutoTagging,
                                }
                            ),
                            new(
                                new AutoTaggingExtension()
                                {
                                    MaxTags = 10,
                                    MinConfidence = 80,
                                    Name = Name.AwsAutoTagging,
                                }
                            ),
                            new(new()),
                        ],
                        RemoveAITags = new(new List<string>() { "car", "vehicle", "motorsports" }),
                        Tags = ["tag1", "tag2"],
                        WebhookURL = "https://webhook.site/0d6b6c7a-8e5a-4b3a-8b7c-0d6b6c7a8e5a",
                    }
                ),
            }
        );
        file.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Files.Delete(new() { FileID = "fileId" });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Copy_Works()
    {
        var response = await this.client.Files.Copy(
            new()
            {
                DestinationPath = "/folder/to/copy/into/",
                SourceFilePath = "/path/to/file.jpg",
            }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Get_Works()
    {
        var file = await this.client.Files.Get(new() { FileID = "fileId" });
        file.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Move_Works()
    {
        var response = await this.client.Files.Move(
            new()
            {
                DestinationPath = "/folder/to/move/into/",
                SourceFilePath = "/path/to/file.jpg",
            }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Rename_Works()
    {
        var response = await this.client.Files.Rename(
            new() { FilePath = "/path/to/file.jpg", NewFileName = "newFileName.jpg" }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Upload_Works()
    {
        var response = await this.client.Files.Upload(
            new() { File = "a value", FileName = "fileName" }
        );
        response.Validate();
    }
}
