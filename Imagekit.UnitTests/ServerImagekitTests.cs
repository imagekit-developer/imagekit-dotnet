using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Imagekit.Util;
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
        public void GetUploadData_Generic()
        {
            var fileName = Guid.NewGuid().ToString();
            var imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT)
                .FileName(fileName)
                .Folder("/test/")
                .isPrivateFile(true)
                .UseUniqueFileName(false)
                .CustomCoordinates("10,10,100,100")
                .ResponseFields("tags,customCoordinates,isPrivateFile")
                .Tags("tag1,tag2");
            var data = imagekit.getUploadData();
            Assert.True(data.TryGetValue("responseFields", out string respFields), "ResponseFields upload data not found");
            Assert.True(data.TryGetValue("useUniqueFileName", out string uniqueParam), "UseUniqueFileName upload not found");
            Assert.True(data.TryGetValue("folder", out string folder), "folder upload not found");
            Assert.Equal("tags,customCoordinates,isPrivateFile", respFields);
            Assert.Equal("false", uniqueParam);
            Assert.Equal("/test/", folder);
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

        [Fact]
        public void GetUploadData_MissingFileName_Exception()
        {
            var imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT)
                .Tags("tag1");
            var ex = Assert.Throws<ArgumentException>(() => imagekit.getUploadData());
            Assert.Equal(errorMessages.MISSING_UPLOAD_FILENAME_PARAMETER, ex.Message);
        }

        [Fact]
        public void ListFiles()
        {
            var responseObj = TestHelpers.ListAPIResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            Util.Utils.SetHttpClient(httpClient);

            var imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT);
            var response = imagekit.ListFiles()[0];
            response.FileId = responseObj.FileId;
            Assert.Equal(JsonConvert.SerializeObject(responseObj), JsonConvert.SerializeObject(response));
        }


        [Fact]
        public void ListFilesWithAllParams()
        {
            var responseObj = TestHelpers.ListAPIResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            Util.Utils.SetHttpClient(httpClient);

            var imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT)
                .FileType("image")
                .Tags("tag1", "tag2")
                .IncludeFolder(true)
                .Name("new-dir")
                .Sort("ASC_NAME")
                .SearchQuery("name=\"test-image.jpg\"")
                .Limit(1)
                .Skip(1);
            var response = imagekit.ListFiles()[0];
            response.FileId = responseObj.FileId;
            Assert.Equal(JsonConvert.SerializeObject(responseObj), JsonConvert.SerializeObject(response));
        }

        [Fact]
        public void GetFileDetails()
        {
            var fileId = Guid.NewGuid().ToString();
            var responseObj = TestHelpers.ListAPIResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            Util.Utils.SetHttpClient(httpClient);

            var imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT);
            var response = imagekit.GetFileDetails(fileId);
            response.FileId = responseObj.FileId;
            Assert.Equal(JsonConvert.SerializeObject(responseObj), JsonConvert.SerializeObject(response));
        }

        [Fact]
        public void GetFileDetailsWithURL()
        {
            var imageURL = "https://example.com/default.jpg";
            var responseObj = TestHelpers.ListAPIResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            Util.Utils.SetHttpClient(httpClient);

            var imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT);
            var response = imagekit.GetFileDetails(imageURL);
            response.FileId = responseObj.FileId;
            Assert.Equal(JsonConvert.SerializeObject(responseObj), JsonConvert.SerializeObject(response));
        }

        [Fact]
        public void PurgeCache()
        {
            var fileId = Guid.NewGuid().ToString();
            var responseObj = TestHelpers.PurgeAPIResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            Util.Utils.SetHttpClient(httpClient);

            var imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT);
            var response = imagekit.PurgeCache(fileId);
            Assert.Equal(JsonConvert.SerializeObject(responseObj), JsonConvert.SerializeObject(response));
        }

        [Fact]
        public void PurgeCacheStatus()
        {
            var requestId = Guid.NewGuid().ToString();
            var responseObj = TestHelpers.PurgeCacheStatusResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            Util.Utils.SetHttpClient(httpClient);

            var imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT);
            var response = imagekit.GetPurgeCacheStatus(requestId);
            Assert.Equal(JsonConvert.SerializeObject(responseObj), JsonConvert.SerializeObject(response));
        }

        [Fact]
        public async void DeleteApi_Response()
        {
            var fileId = Guid.NewGuid().ToString();
            var responseObj = TestHelpers.DeleteAPIResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            Util.Utils.SetHttpClient(httpClient);

            var imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT);
            var response = await imagekit.DeleteFileAsync(fileId);
            Assert.Equal(responseObj.StatusCode, response.StatusCode);
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
    }


    [Collection("UrlGenerationTests")]
    public class ImagekitUrlGenerationTests
    {
        private const string GOOD_PUBLICKEY = "test publickey";
        private const string GOOD_PRIVATEKEY = "test privatekey";
        private const string URLENDPOINT = "https://ik.imagekit.io/test_url_endpoint";
        private const string SAMPLE_PATH = "/default-image.jpg";
        private string SAMPLE_SRC_URL = "https://ik.imagekit.io/test_url_endpoint/default-image.jpg";
        readonly ServerImagekit imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, URLENDPOINT);

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

        [Theory]
        [InlineData("https://example.com/test.jpg", true)]
        [InlineData("http://example.com/", true)]
        [InlineData("ftp://example.com", false)]
        [InlineData(@"C:\test\test 1.jpg", false)]
        [InlineData(@"C:\test\test.jpg", false)]
        [InlineData(@"\\test.com\test.jpg", false)]
        [InlineData("http:\\mysite\test.xml", false)]
        public void IsValidURITest(string url, bool expected)
        {
            Assert.Equal(expected, Util.Utils.IsValidURI(url));
        }

        [Fact]
        public void Url_WithoutUrl_Source()
        {
            Dictionary<string, object> option1 = new Dictionary<string, object>();
            option1.Add("path", SAMPLE_PATH);
            option1.Add("src", SAMPLE_SRC_URL);
            Url u = new Url(option1);
            Exception ex = Assert.Throws<ArgumentException>(() => u.UrlBuilder("ABC"));
            Assert.Equal("Either path or src is required.", ex.Message);
        }

        [Fact]
        public void Url_WithPath()
        {
            string imageURL = imagekit.Url(new Transformation()).Path(SAMPLE_PATH).Generate();
            Assert.Equal(URLENDPOINT + "/default-image.jpg", imageURL);
        }

        [Fact]
        public void Url_WithSrc()
        {
            string imageURL = imagekit.Url(new Transformation()).Src(SAMPLE_SRC_URL).Generate();
            Assert.Equal(URLENDPOINT + "/default-image.jpg", imageURL);
        }

        [Fact]
        public void Url_Signed()
        {
            string imageURL = imagekit.Url(new Transformation()).Path(SAMPLE_PATH).Signed(true).Generate();
            Assert.Equal("https://ik.imagekit.io/test_url_endpoint/default-image.jpg?ik-s=d0f5c0d0c92c0072068b45d3d5a73ab6e306dbf8", imageURL);
        }

        [Fact]
        public void Url_Signed_Timestamp()
        {
            string imageURL = imagekit.Url(new Transformation()).Path(SAMPLE_PATH).Signed(true).ExpireSeconds(300).Generate();
            Assert.Contains("https://ik.imagekit.io/test_url_endpoint/default-image.jpg?ik-t=", imageURL);
        }
        
        [Fact]
        public void Url_Signed_Without_priavteKey()
        {
            ClientImagekit imagekit1 = new ClientImagekit(GOOD_PUBLICKEY, URLENDPOINT)
                .Path(SAMPLE_PATH).Signed(true).ExpireSeconds(300);
            var ex = Assert.Throws<ArgumentNullException>(() => imagekit1.Url(new Transformation()).Path(SAMPLE_PATH).Signed(true).ExpireSeconds(300).Generate());
            Assert.Equal(errorMessages.PRIVATE_KEY_MISSING, ex.ParamName);
        }

        [Fact]
        public void Url_WithPath_Transformation()
        {
            string imageURL = imagekit.Url(new Transformation().Height(300).Width(400)).Path(SAMPLE_PATH).Generate();
            Assert.Equal(URLENDPOINT + "/tr:h-300,w-400/default-image.jpg", imageURL);
        }

        [Fact]
        public void Url_WithSRC_Transform()
        {
            string imageURL = imagekit.Url(new Transformation().Height(300).Width(400)).Src(SAMPLE_SRC_URL).Generate();
            Assert.Equal(URLENDPOINT + "/default-image.jpg?tr=h-300%2Cw-400", imageURL);
        }

        [Fact]
        public void Url_WithSRC_Param_Transform()
        {
            string imageURL = imagekit.Url(new Transformation().Height(300).Width(400)).Src(SAMPLE_SRC_URL+"?a=test").Generate();
            Assert.Equal(URLENDPOINT + "/default-image.jpg?a=test&tr=h-300%2Cw-400", imageURL);
        }

        [Fact]
        public void Url_WithPath_Multiple_LeadingSlash()
        {
            string imageURL = imagekit.Url(new Transformation().Height(300).Width(400)).Path("///default-image.jpg").Generate();
            Assert.Equal(URLENDPOINT + "/tr:h-300,w-400/default-image.jpg", imageURL);
        }

        [Fact]
        public void Url_WithPath_Overidden_Endpoint()
        {
            string imageURL = imagekit.Url(new Transformation().Height(300).Width(400)).Path(SAMPLE_PATH).UrlEndpoint("https://ik.imagekit.io/test_url_endpoint_alt").Generate();
            Assert.Equal(URLENDPOINT + "_alt/tr:h-300,w-400/default-image.jpg", imageURL);
        }

        [Fact]
        public void Url_WithPath_TransPositionAsQuery()
        {
            string imageURL = imagekit.Url(new Transformation().Height(300).Width(400)).TransformationPosition("query").Path(SAMPLE_PATH).Generate();
            Assert.Equal(URLENDPOINT + "/default-image.jpg?tr=h-300%2Cw-400", imageURL);
        }

        [Fact]
        public void Url_WithSrc_TransPositionAsQuery()
        {
            SAMPLE_SRC_URL = URLENDPOINT + "/default-image-alt.jpg";
            string imageURL = imagekit.Url(new Transformation().Height(300).Width(400)).TransformationPosition("query").Src(SAMPLE_SRC_URL).Generate();
            Assert.Equal(URLENDPOINT + "/default-image-alt.jpg?tr=h-300%2Cw-400", imageURL);
        }

        [Fact]
        public void Url_WithSrc_QueryParamMerge()
        {
            string[] queryParams = { "b=123", "a=test" };
            string imageURL = imagekit.Url(new Transformation().Height(300).Width(400)).QueryParameters(queryParams).Src(SAMPLE_SRC_URL).Generate();
            Assert.Equal(URLENDPOINT + "/default-image.jpg?b=123&a=test&tr=h-300%2Cw-400", imageURL);
        }

        [Fact]
        public void Url_With_CorrectChainTransformation()
        {
            string imageURL = imagekit.Url(new Transformation().Height(300).Width(400).Chain().Rotation(90)).Path(SAMPLE_PATH).Generate();
            Assert.Equal(URLENDPOINT + "/tr:h-300,w-400:rt-90/default-image.jpg", imageURL);
        }

        [Fact]
        public void Url_With_Undocumented_CorrectChainTransformation()
        {
            string imageURL = imagekit.Url(new Transformation().Height(300).Width(400).Chain().RawTransformation("rndm_trnsf-abcd")).Path(SAMPLE_PATH).Generate();
            Assert.Equal(URLENDPOINT + "/tr:h-300,w-400:rndm_trnsf-abcd/default-image.jpg", imageURL);
        }

        [Fact]
        public void Url_OverlayImage()
        {
            string imageURL = imagekit.Url(new Transformation().Height(300).Width(400).OverlayImage("overlay.jpg")).Path(SAMPLE_PATH).Generate();
            Assert.Equal(URLENDPOINT + "/tr:h-300,w-400,oi-overlay.jpg/default-image.jpg", imageURL);
        }

        [Fact]
        public void Url_OverlayImage_With_Path()
        {
            string imageURL = imagekit.Url(new Transformation().Height(300).Width(400).OverlayImage("/path/to/overlay.jpg")).Path(SAMPLE_PATH).Generate();
            Assert.Equal(URLENDPOINT + "/tr:h-300,w-400,oi-path@@to@@overlay.jpg/default-image.jpg", imageURL);
        }

        [Fact]
        public void Url_OverlayX()
        {
            string imageURL = imagekit.Url(new Transformation().Height(300).Width(400).OverlayX(10)).Path(SAMPLE_PATH).Generate();
            Assert.Equal(URLENDPOINT + "/tr:h-300,w-400,ox-10/default-image.jpg", imageURL);
        }

        [Fact]
        public void Url_Border()
        {
            string imageURL = imagekit.Url(new Transformation().Height(300).Width(400).Border("20_FF0000")).Path(SAMPLE_PATH).Generate();
            Assert.Equal(URLENDPOINT + "/tr:h-300,w-400,b-20_FF0000/default-image.jpg", imageURL);
        }

        [Fact]
        public void Url_All_Combined()
        {
            var transformation = new Transformation()
                .Height(300)
                .Width(400)
                .AspectRatio("4-3")
                .Quality(40)
                .Crop("force")
                .CropMode("extract")
                .Focus("left")
                .Format("jpeg")
                .Radius(50)
                .Background("A94D34")
                .Border("5-A94D34")
                .Rotation(90)
                .Blur(10)
                .Named("some_name")
                .OverlayX(35)
                .OverlayY(35)
                .OverlayFocus("bottom")
                .OverlayHeight(20)
                .OverlayWidth(20)
                .OverlayImage("/folder/file.jpg")
                .OverlayImageTrim(false)
                .OverlayImageAspectRatio("4:3")
                .OverlayImageBackground("0F0F0F")
                .OverlayImageBorder("10_0F0F0F")
                .OverlayImageDPR(2)
                .OverlayImageQuality(50)
                .OverlayImageCropping("force")
                .OverlayText("two words")
                .OverlayTextFontSize(20)
                .OverlayTextFontFamily("Open Sans")
                .OverlayTextColor("00FFFF")
                .OverlayTextTransparency(5)
                .OverlayTextTypography("b")
                .OverlayBackground("00AAFF55")
                .OverlayTextEncoded("b3ZlcmxheSBtYWRlIGVhc3k%3D")
                .OverlayTextWidth(50)
                .OverlayTextBackground("00AAFF55")
                .OverlayTextPadding(40)
                .OverlayTextInnerAlignment("left")
                .OverlayRadius(10)
                .Progressive(true)
                .Lossless(true)
                .Trim(5)
                .Metadata(true)
                .ColorProfile(true)
                .DefaultImage("folder/file.jpg/")
                .Dpr(3)
                .EffectSharpen(10)
                .EffectUsm("2-2-0.8-0.024")
                .EffectContrast(true)
                .EffectGray()
                .Original();
            string imageURL = imagekit.Url(transformation).Path("/test_path.jpg").Generate();
            Assert.Equal(URLENDPOINT + "/tr:h-300,w-400,ar-4-3,q-40,c-force,cm-extract,fo-left,f-jpeg,r-50,bg-A94D34,b-5-A94D34,rt-90,bl-10,n-some_name,ox-35,oy-35,ofo-bottom,oh-20,ow-20,oi-folder@@file.jpg,oit-false,oiar-4:3,oibg-0F0F0F,oib-10_0F0F0F,oidpr-2,oiq-50,oic-force,ot-two words,ots-20,otf-Open Sans,otc-00FFFF,oa-5,ott-b,obg-00AAFF55,ote-b3ZlcmxheSBtYWRlIGVhc3k%3D,otw-50,otbg-00AAFF55,otp-40,otia-left,or-10,pr-true,lo-true,t-5,md-true,cp-true,di-folder@@file.jpg,dpr-3,e-sharpen-10,e-usm-2-2-0.8-0.024,e-contrast-true,e-grayscale-true,orig-true/test_path.jpg", imageURL);
        }
    }

    [Collection("GenericUnitTests")]
    public class ImagekitUnitTests
    {
        private const string GOOD_PUBLICKEY = "public_key_test";
        private const string GOOD_PRIVATEKEY = "private_key_test";
        private const string URLENDPOINT = "test endpointt";
        readonly ServerImagekit imagekit = new ServerImagekit(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, URLENDPOINT);

        [Fact]
        public void AuthenticationParamCheck()
        {
            string token = "your_token";
            string expire = "1582269249";
            AuthParamResponse authParams = imagekit.GetAuthenticationParameters(token, expire);
            Assert.Equal(token, authParams.token);
            Assert.Equal(expire, authParams.expire);
            Assert.Equal("e71bcd6031016b060d349d212e23e85c791decdd", authParams.signature);
        }

        [Fact]
        public void AuthenticationParamNullCheck()
        {
            string token = null;
            string expire = "1582269249";
            AuthParamResponse authParams = imagekit.GetAuthenticationParameters(token, expire);
            Assert.NotEmpty(authParams.token);
            Assert.IsType<String>(authParams.token);
            Assert.Equal(expire, authParams.expire);
            Assert.NotEmpty(authParams.signature);
            Assert.IsType<String>(authParams.signature);
        }

        [Fact]
        public void SignUrlSignature()
        {
            Dictionary<string, object> option = new Dictionary<string, object>();
            option.Add("privateKey", "private_key_test");
            option.Add("urlEndpoint", "https://test-domain.com/test-endpoint");
            Url u = new Url(option);
            string expiryTimestamp = "9999999999";
            string url = "https://test-domain.com/test-endpoint/tr:w-100/test-signed-url.png";
            Assert.Equal("41b3075c40bc84147eb71b8b49ae7fbf349d0f00", u.GetSignature(url, expiryTimestamp));
        }

        [Fact]
        public void SignUrlSignature1()
        {
            Dictionary<string, object> option = new Dictionary<string, object>();
            option.Add("privateKey", "private_key_test");
            option.Add("urlEndpoint", "https://test-domain.com/test-endpoint/");
            Url u = new Url(option);
            string expiryTimestamp = "9999999999";
            string url = "https://test-domain.com/test-endpoint/tr:w-100/test-signed-url.png";
            Assert.Equal("41b3075c40bc84147eb71b8b49ae7fbf349d0f00", u.GetSignature(url, expiryTimestamp));
        }

        [Theory]
        [InlineData("33699c96619cc69e", "968e978414fe04ea", 30)]
        [InlineData("63433b3ccf8e1ebe", "f5d2226cd9d32b16", 27)]
        [InlineData("f5d2226cd9d32b16", "63433b3ccf8e1ebe", 27)]
        [InlineData("33699c96619cc69e", "33699c96619cc69e", 0)]
        [InlineData("2d5ad3936d2e015b", "2d6ed293db36a4fb", 17)]
        [InlineData("a4a65595ac94518b", "7838873e791f8400", 37)]
        [InlineData("f06830ca9f1e3e90", "2222222222222222", 30)]
        public void PhashDistance(string val1, string val2, int expected)
        {
            Assert.Equal(expected, imagekit.PHashDistance(val1, val2));
        }

        private const string VALID_PHASH_STRING = "f06830ca9f1e3e90";
        private const string INVALID_ALPHA_NUMERIC_STRING = "INVALIDHEXSTRING";
        private const string INVALID_CHARACTER_STRING = "a4a655~!!@94518b";
        private const string INVALID_HEX_STRING_LEN = "42df";
        [Theory]
        [InlineData(null, VALID_PHASH_STRING, true)]
        [InlineData(VALID_PHASH_STRING, "", true)]
        [InlineData(INVALID_ALPHA_NUMERIC_STRING, VALID_PHASH_STRING, true)]
        [InlineData(INVALID_CHARACTER_STRING, VALID_PHASH_STRING, true)]
        [InlineData(VALID_PHASH_STRING, INVALID_HEX_STRING_LEN, true)]
        [InlineData(VALID_PHASH_STRING, VALID_PHASH_STRING, false)]
        public void Phash_Check(string val1, string val2, bool expectException)
        {
            if (expectException)
            {
                var ex = Assert.Throws<ArgumentException>(() => imagekit.PHashDistance(val1, val2));
                if(val2 == INVALID_HEX_STRING_LEN)
                {
                    Assert.Equal(errorMessages.UNEQUAL_STRING_LENGTH, ex.Message);
                } else if (val1 == INVALID_ALPHA_NUMERIC_STRING || val1 == INVALID_CHARACTER_STRING)
                {
                    Assert.Equal(errorMessages.INVALID_PHASH_VALUE, ex.Message);
                } else
                {
                    Assert.Equal(errorMessages.MISSING_PHASH_VALUE, ex.Message);
                }
            }
            else
            {
                Assert.Equal(0, imagekit.PHashDistance(val1, val2));
            }
        }
    }
}