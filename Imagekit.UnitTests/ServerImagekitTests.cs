using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Xunit;

namespace Imagekit.UnitTests
{
    public class ServerImagekitTests
    {
        [Fact]
        public void Constructor()
        {
            var imagekit = new ServerImagekit("test publicKey", "test privateKey", "test urlEndpoint", "test path");
            Assert.NotNull(imagekit);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_Required_PublicKey(string publicKey)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new ServerImagekit(publicKey, "test privateKey", "test urlEndpoint", "test path"));
            Assert.Equal("publicKey", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_Required_PrivateKey(string privateKey)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new ServerImagekit("test publicKey", privateKey, "test urlEndpoint", "test path"));
            Assert.Equal("privateKey", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_Required_UrlEndpoint(string urlEndpoint)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new ServerImagekit("test publicKey", "test privateKey", urlEndpoint, "test path"));
            Assert.Equal("urlEndpoint", ex.ParamName);
        }

        [Fact]
        public void Upload()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            Util.Utils.SetHttpClient(httpClient);

            var imagekit = new ServerImagekit("test publicKey", "test privateKey", "test urlEndpoint", "test path")
                .FileName("test filename");
            var response = imagekit.Upload("https://test.com/test.png");
            Assert.Equal(JsonConvert.SerializeObject(responseObj), JsonConvert.SerializeObject(response));
        }

        [Fact]
        public async Task UploadAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            Util.Utils.SetHttpClient(httpClient);

            var imagekit = new ServerImagekit("test publicKey", "test privateKey", "test urlEndpoint", "test path")
                .FileName("test filename");
            var response = await imagekit.UploadAsync("https://test.com/test.png");
            Assert.Equal(JsonConvert.SerializeObject(responseObj), JsonConvert.SerializeObject(response));
        }
    }
}
