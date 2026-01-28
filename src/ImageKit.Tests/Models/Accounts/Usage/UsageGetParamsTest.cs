using System;
using ImageKit.Models.Accounts.Usage;

namespace ImageKit.Tests.Models.Accounts.Usage;

public class UsageGetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UsageGetParams { EndDate = "2019-12-27", StartDate = "2019-12-27" };

        string expectedEndDate = "2019-12-27";
        string expectedStartDate = "2019-12-27";

        Assert.Equal(expectedEndDate, parameters.EndDate);
        Assert.Equal(expectedStartDate, parameters.StartDate);
    }

    [Fact]
    public void Url_Works()
    {
        UsageGetParams parameters = new() { EndDate = "2019-12-27", StartDate = "2019-12-27" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.Equal(
            new Uri(
                "https://api.imagekit.io/v1/accounts/usage?endDate=2019-12-27&startDate=2019-12-27"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UsageGetParams { EndDate = "2019-12-27", StartDate = "2019-12-27" };

        UsageGetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
