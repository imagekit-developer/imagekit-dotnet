using System;
using ImageKit.Models;
using ImageKit.Models.SavedExtensions;

namespace ImageKit.Tests.Models.SavedExtensions;

public class SavedExtensionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SavedExtensionCreateParams
        {
            Config = new RemoveBg()
            {
                Options = new()
                {
                    AddShadow = true,
                    BgColor = "bg_color",
                    BgImageUrl = "bg_image_url",
                    Semitransparency = true,
                },
            },
            Description = "Analyzes vehicle images for type, condition, and quality assessment",
            Name = "Car Quality Analysis",
        };

        ExtensionConfig expectedConfig = new RemoveBg()
        {
            Options = new()
            {
                AddShadow = true,
                BgColor = "bg_color",
                BgImageUrl = "bg_image_url",
                Semitransparency = true,
            },
        };
        string expectedDescription =
            "Analyzes vehicle images for type, condition, and quality assessment";
        string expectedName = "Car Quality Analysis";

        Assert.Equal(expectedConfig, parameters.Config);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void Url_Works()
    {
        SavedExtensionCreateParams parameters = new()
        {
            Config = new RemoveBg()
            {
                Options = new()
                {
                    AddShadow = true,
                    BgColor = "bg_color",
                    BgImageUrl = "bg_image_url",
                    Semitransparency = true,
                },
            },
            Description = "Analyzes vehicle images for type, condition, and quality assessment",
            Name = "Car Quality Analysis",
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.Equal(new Uri("https://api.imagekit.io/v1/saved-extensions"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SavedExtensionCreateParams
        {
            Config = new RemoveBg()
            {
                Options = new()
                {
                    AddShadow = true,
                    BgColor = "bg_color",
                    BgImageUrl = "bg_image_url",
                    Semitransparency = true,
                },
            },
            Description = "Analyzes vehicle images for type, condition, and quality assessment",
            Name = "Car Quality Analysis",
        };

        SavedExtensionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
