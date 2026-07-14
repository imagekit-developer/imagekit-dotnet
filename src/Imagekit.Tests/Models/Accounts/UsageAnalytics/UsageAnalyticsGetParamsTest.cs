using System;
using Imagekit.Models.Accounts.UsageAnalytics;

namespace Imagekit.Tests.Models.Accounts.UsageAnalytics;

public class UsageAnalyticsGetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UsageAnalyticsGetParams
        {
            EndDate = "2019-12-27",
            StartDate = "2019-12-27",
        };

        string expectedEndDate = "2019-12-27";
        string expectedStartDate = "2019-12-27";

        Assert.Equal(expectedEndDate, parameters.EndDate);
        Assert.Equal(expectedStartDate, parameters.StartDate);
    }

    [Fact]
    public void Url_Works()
    {
        UsageAnalyticsGetParams parameters = new()
        {
            EndDate = "2019-12-27",
            StartDate = "2019-12-27",
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.imagekit.io/v1/accounts/usage-analytics?endDate=2019-12-27&startDate=2019-12-27"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UsageAnalyticsGetParams
        {
            EndDate = "2019-12-27",
            StartDate = "2019-12-27",
        };

        UsageAnalyticsGetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
