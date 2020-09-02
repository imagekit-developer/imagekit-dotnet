using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace Imagekit.UnitTests
{
    [Collection("Uses Utils.HttpClient")]
    public class ClientImagekitTests
    {
        [Fact]
        public void Constructor()
        {
            var imagekit = new ClientImagekit("test urlEndpoint", "test path");
            Assert.NotNull(imagekit);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_Required_UrlEndpoint(string urlEndpoint)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new ClientImagekit(urlEndpoint, "test path"));
            Assert.Equal("urlEndpoint", ex.ParamName);
        }

        [Fact]
        public void Upload()
        {
            var fileName = Guid.NewGuid().ToString();
            var fileUrl = "https://test.com/test.png";
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse,
                TestHelpers.GetUploadRequestMessageValidator(fileUrl, fileName));
            Util.Utils.SetHttpClient(httpClient);

            var imagekit = new ClientImagekit("test urlEndpoint", "test path")
                .FileName(fileName);
            var response = imagekit.Upload(fileUrl, TestHelpers.AuthParamResponseFaker.Generate());
            Assert.Equal(JsonConvert.SerializeObject(responseObj), JsonConvert.SerializeObject(response));
        }

        [Fact]
        public async Task UploadAsync()
        {
            var fileName = Guid.NewGuid().ToString();
            var fileUrl = "https://test.com/test.png";
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse,
                TestHelpers.GetUploadRequestMessageValidator(fileUrl, fileName));
            Util.Utils.SetHttpClient(httpClient);

            var imagekit = new ClientImagekit("test urlEndpoint", "test path")
                .FileName(fileName);
            var response = await imagekit.UploadAsync(fileUrl, TestHelpers.AuthParamResponseFaker.Generate());
            Assert.Equal(JsonConvert.SerializeObject(responseObj), JsonConvert.SerializeObject(response));
        }
    }
}
