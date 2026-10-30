using System.Threading.Tasks;

namespace Imagekit.Tests.Services.Accounts;

public class ContractServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var contract = await this.client.Accounts.Contract.Get(
            new(),
            TestContext.Current.CancellationToken
        );
        contract.Validate();
    }
}
