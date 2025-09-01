using System.Threading.Tasks;
using Imagekit.Models.CustomMetadataFields.CustomMetadataFieldCreateParamsProperties.SchemaProperties;

namespace Imagekit.Tests.Services.CustomMetadataFields;

public class CustomMetadataFieldServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var customMetadataField = await this.client.CustomMetadataFields.Create(
            new()
            {
                Label = "label",
                Name = "name",
                Schema = new()
                {
                    Type = Type.Text,
                    DefaultValue = "string",
                    IsValueRequired = true,
                    MaxLength = 0,
                    MaxValue = "string",
                    MinLength = 0,
                    MinValue = "string",
                    SelectOptions = ["small", "medium", "large", 30, 40, true],
                },
            }
        );
        customMetadataField.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var customMetadataField = await this.client.CustomMetadataFields.Update(
            new() { ID = "id" }
        );
        customMetadataField.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var customMetadataFields = await this.client.CustomMetadataFields.List();
        foreach (var item in customMetadataFields)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        var customMetadataField = await this.client.CustomMetadataFields.Delete(
            new() { ID = "id" }
        );
        customMetadataField.Validate();
    }
}
