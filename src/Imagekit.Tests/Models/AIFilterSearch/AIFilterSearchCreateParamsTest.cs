using System;
using Imagekit.Models.AIFilterSearch;

namespace Imagekit.Tests.Models.AIFilterSearch;

public class AIFilterSearchCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AIFilterSearchCreateParams
        {
            Prompt = "red dresses tagged summer uploaded last month",
            CurrentFolder = "/products",
            Timezone = "Asia/Kolkata",
        };

        string expectedPrompt = "red dresses tagged summer uploaded last month";
        string expectedCurrentFolder = "/products";
        string expectedTimezone = "Asia/Kolkata";

        Assert.Equal(expectedPrompt, parameters.Prompt);
        Assert.Equal(expectedCurrentFolder, parameters.CurrentFolder);
        Assert.Equal(expectedTimezone, parameters.Timezone);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AIFilterSearchCreateParams
        {
            Prompt = "red dresses tagged summer uploaded last month",
        };

        Assert.Null(parameters.CurrentFolder);
        Assert.False(parameters.RawBodyData.ContainsKey("currentFolder"));
        Assert.Null(parameters.Timezone);
        Assert.False(parameters.RawBodyData.ContainsKey("timezone"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AIFilterSearchCreateParams
        {
            Prompt = "red dresses tagged summer uploaded last month",

            // Null should be interpreted as omitted for these properties
            CurrentFolder = null,
            Timezone = null,
        };

        Assert.Null(parameters.CurrentFolder);
        Assert.False(parameters.RawBodyData.ContainsKey("currentFolder"));
        Assert.Null(parameters.Timezone);
        Assert.False(parameters.RawBodyData.ContainsKey("timezone"));
    }

    [Fact]
    public void Url_Works()
    {
        AIFilterSearchCreateParams parameters = new()
        {
            Prompt = "red dresses tagged summer uploaded last month",
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/ai-filter-search"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AIFilterSearchCreateParams
        {
            Prompt = "red dresses tagged summer uploaded last month",
            CurrentFolder = "/products",
            Timezone = "Asia/Kolkata",
        };

        AIFilterSearchCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
