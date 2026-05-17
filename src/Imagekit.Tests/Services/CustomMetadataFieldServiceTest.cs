using System.Threading.Tasks;
using Imagekit.Models.CustomMetadataFields;

namespace Imagekit.Tests.Services;

public class CustomMetadataFieldServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var customMetadataField = await this.client.CustomMetadataFields.Create(
            new()
            {
                Label = "price",
                Name = "price",
                Schema = new()
                {
                    Type = Type.Number,
                    DefaultValue = new(
                        [
                            new DefaultValueItem(true),
                            new DefaultValueItem(10),
                            new DefaultValueItem("Hello"),
                        ]
                    ),
                    IsValueRequired = true,
                    MaxLength = 0,
                    MaxValue = 3000,
                    MinLength = 0,
                    MinValue = 1000,
                    SelectOptions = ["small", "medium", "large", 30, 40, true],
                },
            },
            TestContext.Current.CancellationToken
        );
        customMetadataField.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var customMetadataField = await this.client.CustomMetadataFields.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        customMetadataField.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var customMetadataFields = await this.client.CustomMetadataFields.List(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in customMetadataFields)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var customMetadataField = await this.client.CustomMetadataFields.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        customMetadataField.Validate();
    }
}
