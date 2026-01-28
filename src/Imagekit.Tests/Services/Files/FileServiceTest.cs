using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Imagekit.Models.Files.UpdateFileRequestProperties;
using Imagekit.Models.UnnamedSchemaWithArrayParent0Properties;
using Imagekit.Models.UnnamedSchemaWithArrayParent0Properties.AutoTaggingExtensionProperties;
using UnnamedSchemaWithArrayParent0Variants = Imagekit.Models.UnnamedSchemaWithArrayParent0Variants;

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
                UpdateFileRequest = new UpdateFileDetails()
                {
                    CustomCoordinates = "customCoordinates",
                    CustomMetadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Description = "description",
                    Extensions =
                    [
                        new RemoveBg()
                        {
                            Options = new()
                            {
                                AddShadow = true,
                                BgColor = "bg_color",
                                BgImageURL = "bg_image_url",
                                Semitransparency = true,
                            },
                        },
                        new AutoTaggingExtension()
                        {
                            MaxTags = 5,
                            MinConfidence = 95,
                            Name = Name.GoogleAutoTagging,
                        },
                        new UnnamedSchemaWithArrayParent0Variants::AIAutoDescription(
                            JsonSerializer.Deserialize<JsonElement>(
                                "{\"name\":\"ai-auto-description\"}"
                            )
                        ),
                    ],
                    RemoveAITags = new List<string>() { "string" },
                    Tags = ["car", "vehicle", "motorsports"],
                    WebhookURL = "https://example.com",
                },
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
