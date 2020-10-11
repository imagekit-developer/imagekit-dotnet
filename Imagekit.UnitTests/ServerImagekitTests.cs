using System;
using System.Collections.Generic;
using System.IO;
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
        public void Upload_Throws_IOException()
        {
            var fileName = Guid.NewGuid().ToString();
            var fileUrl = @"c:\test\test.jpg";

            var imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT)
                .FileName(fileName);
            Exception ex = Assert.Throws<AggregateException>(() => imagekit.Upload(fileUrl));
            Assert.Equal("File Not Found.", ex.InnerException.Message);
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

        [Fact]
        public void GetUploadData_TagsString()
        {
            var fileName = Guid.NewGuid().ToString();
            var imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT)
                .FileName(fileName)
                .Tags("tag1,tag2");
            var data = imagekit.getUploadData();
            Assert.True(data.TryGetValue("tags", out string actualTags), "tags upload data not found");
            Assert.Equal("tag1,tag2", actualTags);
        }

        [Fact]
        public void GetUploadData_TagsArray()
        {
            var fileName = Guid.NewGuid().ToString();
            var imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT)
                .FileName(fileName)
                .Tags("tag1", "tag2");
            var data = imagekit.getUploadData();
            Assert.True(data.TryGetValue("tags", out string actualTags), "tags upload data not found");
            Assert.Equal("tag1,tag2", actualTags);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("null")]
        [InlineData("tag1")]
        [InlineData("tag1,tag2")]
        public async Task UpdateFileDetailsAsync_TagsString(string tags)
        {
            var fileId = Guid.NewGuid().ToString();
            var fileName = Guid.NewGuid().ToString();
            var responseObj = TestHelpers.ListAPIResponseFaker.Generate();
            responseObj.Tags = tags == null ? null : tags.Split(",");
            if (responseObj.Tags != null && responseObj.Tags[0] == "null")
            {
                responseObj.Tags = null;
            }
            responseObj.CustomCoordinates = null;
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse,
                TestHelpers.GetUpdateFileDetailsMessageValidator(responseObj.Tags, null));
            Util.Utils.SetHttpClient(httpClient);

            var imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT)
                .FileName(fileName)
                .Tags(tags);
            var response = await imagekit.UpdateFileDetailsAsync(fileId);
            Assert.Equal(JsonConvert.SerializeObject(responseObj), JsonConvert.SerializeObject(response));
        }

        [Theory, MemberData(nameof(TagsArrays))]
        public async Task UpdateFileDetailsAsync_TagsArray(string[] tags, bool isValid)
        {
            var fileId = Guid.NewGuid().ToString();
            var fileName = Guid.NewGuid().ToString();
            var imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT)
                .FileName(fileName)
                .Tags(tags);

            if (isValid)
            {
                var responseObj = TestHelpers.ListAPIResponseFaker.Generate();
                responseObj.Tags = tags;
                responseObj.CustomCoordinates = null;
                var httpResponse = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(responseObj))
                };
                var httpClient = TestHelpers.GetTestHttpClient(httpResponse,
                    TestHelpers.GetUpdateFileDetailsMessageValidator(responseObj.Tags, null));
                Util.Utils.SetHttpClient(httpClient);

                var response = await imagekit.UpdateFileDetailsAsync(fileId);
                Assert.Equal(JsonConvert.SerializeObject(responseObj), JsonConvert.SerializeObject(response));
            }
            else
            {
                var ex = await Assert.ThrowsAsync<ArgumentException>(() => imagekit.UpdateFileDetailsAsync(fileId));
                Assert.Equal(Util.errorMessages.UPDATE_DATA_TAGS_INVALID, ex.Message);
            }
        }

        public static IEnumerable<object[]> TagsArrays
        {
            get
            {
                // string[] tags, bool isValid
                yield return new object[] { null, false };
                yield return new object[] { new string[] { }, false };
                yield return new object[] { new string[] { "tag1" }, true };
                yield return new object[] { new string[] { "tag1", "tag2" }, true };
            }
        }

        [Theory]
        [InlineData("https://example.com", false)]
        [InlineData("http://example.com", false)]
        [InlineData("ftp://example.com", false)]
        [InlineData(@"C:\test\test 1.jpg", true)]
        [InlineData(@"C:\test\test.jpg", true)]
        [InlineData(@"\\test.com\test.jpg", true)]
        [InlineData("http:\\mysite\test.xml", false)]
        public void IsLocalPathTest(string path, bool expected)
        {
            Assert.Equal(expected, Util.Utils.IsLocalPath(path));
        }
    }
}
