using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace Imagekit.UnitTests
{
    [Collection("Uses Utils.HttpClient")]
    public class ServerImagekitTests
    {
        private const string GOOD_PUBLICKEY = "test publickey";
        private const string GOOD_PRIVATEKEY = "test privatekey";
        private const string GOOD_URLENDPOINT = "test urlendpoint";
        private const string GOOD_TRANSFORMATION = "path";

        [Theory]
        [InlineData("N/A", GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT, GOOD_TRANSFORMATION, false)]
        [InlineData("publicKey", null, GOOD_PRIVATEKEY, GOOD_URLENDPOINT, GOOD_TRANSFORMATION, true)]
        [InlineData("publicKey", "", GOOD_PRIVATEKEY, GOOD_URLENDPOINT, GOOD_TRANSFORMATION, true)]
        [InlineData("privateKey", GOOD_PUBLICKEY, null, GOOD_URLENDPOINT, GOOD_TRANSFORMATION, true)]
        [InlineData("privateKey", GOOD_PUBLICKEY, "", GOOD_URLENDPOINT, GOOD_TRANSFORMATION, true)]
        [InlineData("urlEndpoint", GOOD_PUBLICKEY, GOOD_PRIVATEKEY, null, GOOD_TRANSFORMATION, true)]
        [InlineData("urlEndpoint", GOOD_PUBLICKEY, GOOD_PRIVATEKEY, "", GOOD_TRANSFORMATION, true)]
        public void Constructor_Required(
            string paramUnderTest,
            string publicKey,
            string privateKey,
            string urlEndpoint,
            string transformationPosition,
            bool expectException
        )
        {
            if (expectException)
            {
                var ex = Assert.Throws<ArgumentNullException>(() => new ServerImagekit(publicKey, privateKey, urlEndpoint, transformationPosition));
                Assert.Equal(paramUnderTest, ex.ParamName);
            }
            else
            {
                var imagekit = new ServerImagekit(publicKey, privateKey, urlEndpoint, transformationPosition);
                Assert.NotNull(imagekit);
            }
        }

        [Fact]
        public void Constructor_TransformationPosition_Default()
        {
            var imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT);
            Assert.NotNull(imagekit);
        }

        [Theory]
        [InlineData("path", false)]
        [InlineData("query", false)]
        [InlineData("test path", true)]
        [InlineData("test query", true)]
        [InlineData("asdf", true)]
        [InlineData(null, true)]
        [InlineData("", true)]
        public void Constructor_TransformationPosition(string transformationPosition, bool expectException)
        {
            if (expectException)
            {
                var ex = Assert.Throws<ArgumentException>(() => new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT, transformationPosition));
                Assert.Equal("transformationPosition", ex.ParamName);
            }
            else
            {
                var imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT, transformationPosition);
                Assert.NotNull(imagekit);
            }
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

            var imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT)
                .FileName(fileName);
            var response = imagekit.Upload(fileUrl);
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

            var imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT)
                .FileName(fileName);
            var response = await imagekit.UploadAsync(fileUrl);
            Assert.Equal(JsonConvert.SerializeObject(responseObj), JsonConvert.SerializeObject(response));
        }
    }
}
