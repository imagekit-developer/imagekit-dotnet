using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using ImagekitDiversion.Models.Files.Details;
using Dummy = ImagekitDiversion.Models.Dummy;

namespace ImagekitDiversion.Tests.Services.Files;

public class DetailServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var fileDetails = await this.client.Files.Details.Retrieve(
            "fileId",
            new(),
            TestContext.Current.CancellationToken
        );
        fileDetails.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var detail = await this.client.Files.Details.Update(
            "fileId",
            new()
            {
                Body = new UpdateFileDetails()
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
                        new Dummy::RemovedotBgExtension()
                        {
                            Options = new()
                            {
                                AddShadow = true,
                                BgColor = "bg_color",
                                BgImageUrl = "bg_image_url",
                                Semitransparency = true,
                            },
                        },
                        new Dummy::AutoTaggingExtension()
                        {
                            MaxTags = 10,
                            MinConfidence = 80,
                            Name = Dummy::Name.GoogleAutoTagging,
                        },
                        new Dummy::AutoTaggingExtension()
                        {
                            MaxTags = 10,
                            MinConfidence = 80,
                            Name = Dummy::Name.AwsAutoTagging,
                        },
                        new Dummy::AutoDescriptionExtension(),
                        new Dummy::AITasksExtension(
                            [
                                new Dummy::SelectTags()
                                {
                                    Instruction = "What types of clothing items are visible?",
                                    MaxSelections = 1,
                                    MinSelections = 0,
                                    Vocabulary = ["shirt", "dress", "jacket"],
                                },
                            ]
                        ),
                        new Dummy::SavedExtension("ext_abc123"),
                    ],
                    RemoveAITags = new(["car", "vehicle", "motorsports"]),
                    Tags = ["tag1", "tag2"],
                    WebhookUrl = "https://webhook.site/0d6b6c7a-8e5a-4b3a-8b7c-0d6b6c7a8e5a",
                },
            },
            TestContext.Current.CancellationToken
        );
        detail.Validate();
    }
}
