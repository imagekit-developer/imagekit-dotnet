using System;
using ImagekitDiversion.Models.Accounts;

namespace ImagekitDiversion.Tests.Models.Accounts;

public class AccountGetUsageParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountGetUsageParams
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
        AccountGetUsageParams parameters = new()
        {
            EndDate = "2019-12-27",
            StartDate = "2019-12-27",
        };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.imagekit.io/v1/accounts/usage?endDate=2019-12-27&startDate=2019-12-27"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountGetUsageParams
        {
            EndDate = "2019-12-27",
            StartDate = "2019-12-27",
        };

        AccountGetUsageParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
