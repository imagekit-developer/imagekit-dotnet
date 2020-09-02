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
        private const string GOOD_PUBLICKEY = "test publickey";
        private const string GOOD_URLENDPOINT = "test urlendpoint";
        private const string GOOD_TRANSFORMATION = "path";

        [Theory]
        [InlineData("N/A", GOOD_PUBLICKEY, GOOD_URLENDPOINT, GOOD_TRANSFORMATION, false)]
        [InlineData("publicKey", null, GOOD_URLENDPOINT, GOOD_TRANSFORMATION, true)]
        [InlineData("publicKey", "", GOOD_URLENDPOINT, GOOD_TRANSFORMATION, true)]
        [InlineData("urlEndpoint", GOOD_PUBLICKEY, null, GOOD_TRANSFORMATION, true)]
        [InlineData("urlEndpoint", GOOD_PUBLICKEY, "", GOOD_TRANSFORMATION, true)]
        public void Constructor_Required(
            string paramUnderTest,
            string publicKey,
            string urlEndpoint,
            string transformationPosition,
            bool expectException
        )
        {
            if (expectException)
            {
                var ex = Assert.Throws<ArgumentNullException>(() => new ClientImagekit(publicKey, urlEndpoint, transformationPosition));
                Assert.Equal(paramUnderTest, ex.ParamName);
            }
            else
            {
                var imagekit = new ClientImagekit(publicKey, urlEndpoint, transformationPosition);
                Assert.NotNull(imagekit);
            }
        }

        [Fact]
        public void Constructor_TransformationPosition_Default()
        {
            var imagekit = new ClientImagekit(GOOD_PUBLICKEY, GOOD_URLENDPOINT);
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
                var ex = Assert.Throws<ArgumentException>(() => new ClientImagekit(GOOD_PUBLICKEY, GOOD_URLENDPOINT, transformationPosition));
                Assert.Equal("transformationPosition", ex.ParamName);
            }
            else
            {
                var imagekit = new ClientImagekit(GOOD_PUBLICKEY, GOOD_URLENDPOINT, transformationPosition);
                Assert.NotNull(imagekit);
            }
        }

        [Fact]
        public void Upload()
        {
            var fileName = Guid.NewGuid().ToString();
            var fileUrl = "https://test.com/test.png";
            var auth = TestHelpers.AuthParamResponseFaker.Generate();
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse,
                TestHelpers.GetUploadRequestMessageValidator(fileUrl, fileName, GOOD_PUBLICKEY, auth));
            Util.Utils.SetHttpClient(httpClient);

            var imagekit = new ClientImagekit(GOOD_PUBLICKEY, GOOD_URLENDPOINT)
                .FileName(fileName);
            var response = imagekit.Upload(fileUrl, auth);
            Assert.Equal(JsonConvert.SerializeObject(responseObj), JsonConvert.SerializeObject(response));
        }

        [Fact]
        public async Task UploadAsync()
        {
            var fileName = Guid.NewGuid().ToString();
            var fileUrl = "https://test.com/test.png";
            var auth = TestHelpers.AuthParamResponseFaker.Generate();
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse,
                TestHelpers.GetUploadRequestMessageValidator(fileUrl, fileName, GOOD_PUBLICKEY, auth));
            Util.Utils.SetHttpClient(httpClient);

            var imagekit = new ClientImagekit(GOOD_PUBLICKEY, GOOD_URLENDPOINT)
                .FileName(fileName);
            var response = await imagekit.UploadAsync(fileUrl, auth);
            Assert.Equal(JsonConvert.SerializeObject(responseObj), JsonConvert.SerializeObject(response));
        }
    }
}
