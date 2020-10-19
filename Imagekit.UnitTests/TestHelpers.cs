using System;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Imagekit.UnitTests
{
    public static class TestHelpers
    {
        static TestHelpers()
        {
            Faker.DefaultStrictMode = true;
        }

        public static Faker<ListAPIResponse> ListAPIResponseFaker = new Faker<ListAPIResponse>()
            .RuleFor(u => u.FileId, (f, u) => Guid.NewGuid().ToString())
            .RuleFor(u => u.Type, (f, u) => f.Random.ArrayElement(new string[] { "file", "folder" }))
            .RuleFor(u => u.Name, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.FilePath, (f, u) => f.System.FilePath())
            .RuleFor(u => u.Tags, (f, u) => f.Random.ArrayElement(new string[][]
            {
                null, // No tags
                new string[] { f.Random.Utf16String() }, // 1 tag
                new string[] { f.Random.Utf16String(), f.Random.Utf16String() } // 2 tags
            }))
            .RuleFor(u => u.IsPrivateFile, (f, u) => f.Random.Bool())
            .RuleFor(u => u.CustomCoordinates, (f, u) => f.Random.ArrayElement(new string[]
            {
                null, // No custom coordinates
                $"{f.Random.Int()},{f.Random.Int()},{f.Random.Int()},{f.Random.Int()}" // x,y,width,height
            }))
            .RuleFor(u => u.Url, (f, u) => f.Internet.UrlWithPath(fileExt: ".png"))
            .RuleFor(u => u.Thumbnail, (f, u) => f.Internet.UrlWithPath(fileExt: ".png"))
            .RuleFor(u => u.FileType, (f, u) => f.Random.ArrayElement(new string[] { "image", "non-image" }))
            .RuleFor(u => u.CreatedAt, (f, u) => f.Date.Past().ToString("YYYY-MM-DDTHH:mm:ss.sssZ"))
            .RuleFor(u => u.Message, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.StatusCode, (f, u) => 200)
            .RuleFor(u => u.XIkRequestId, (f, u) => null)
            .RuleFor(u => u.Help, (f, u) => f.Random.Utf16String());

        public static Faker<AuthParamResponse> AuthParamResponseFaker = new Faker<AuthParamResponse>()
            .RuleFor(u => u.token, (f, u) => Guid.NewGuid().ToString())
            .RuleFor(u => u.expire, (f, u) => DateTimeOffset.UtcNow.AddMinutes(30).ToUnixTimeSeconds().ToString())
            .RuleFor(u => u.signature, (f, u) => f.Random.Utf16String());

        public static Faker<MetadataResponse> MetadataResponseFaker = new Faker<MetadataResponse>()
            .RuleFor(u => u.Exif, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.Density, (f, u) => f.Random.Int())
            .RuleFor(u => u.Size, (f, u) => f.Random.Int())
            .RuleFor(u => u.Height, (f, u) => f.Random.Int())
            .RuleFor(u => u.Width, (f, u) => f.Random.Int())
            .RuleFor(u => u.Quality, (f, u) => f.Random.Int())
            .RuleFor(u => u.StatusCode, (f, u) => 200)
            .RuleFor(u => u.Format, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.PHash, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.Message, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.Help, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.Type, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.HasColorProfile, (f, u) => f.Random.Bool())
            .RuleFor(u => u.HasTransparency, (f, u) => f.Random.Bool())
            .RuleFor(u => u.XIkRequestId, (f, u) => null)
            .RuleFor(u => u.Exception, (f, u) => f.Random.Bool());


        private static double[] GetRationalTime(TimeSpan time)
        {
            var seconds = (double)time.Seconds;
            var milliseconds = (double)time.Milliseconds / 1000;
            return new double[] { time.Hours, time.Minutes, seconds + milliseconds};
        }

        private static double[] CoordinateToRational(double coordinate)
        {
            double temp;
            temp = Math.Abs(coordinate);
            var degrees = (int)Math.Truncate(temp);
            temp = (temp - degrees) * 60;
            var minutes = (int)Math.Truncate(temp);
            temp = (temp - minutes) * 60;
            var seconds = Math.Round(Math.Truncate(1000 * temp) / 1000, 1);
            return new double[] { degrees, minutes, seconds };
        }

        public static Faker<ImagekitResponse> ImagekitResponseFaker = new Faker<ImagekitResponse>()
            .RuleFor(u => u.FileId, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.Name, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.URL, (f, u) => f.Internet.UrlWithPath(fileExt: ".png"))
            .RuleFor(u => u.Thumbnail, (f, u) => f.Internet.UrlWithPath(fileExt: ".png"))
            .RuleFor(u => u.FileType, (f, u) => f.Random.ArrayElement(new string[] { "image", "non-image" }))
            .RuleFor(u => u.FilePath, (f, u) => f.System.FilePath())
            .RuleFor(u => u.Size, (f, u) => f.Random.Int())
            .RuleFor(u => u.Height, (f, u) => f.Random.Int())
            .RuleFor(u => u.Width, (f, u) => f.Random.Int())
            .RuleFor(u => u.Tags, (f, u) => new string[] { f.Random.Utf16String(), f.Random.Utf16String() })
            .RuleFor(u => u.IsPrivateFile, (f, u) => f.Random.Bool())
            .RuleFor(u => u.CustomCoordinates, (f, u) => f.Random.Bool())
            .RuleFor(u => u.Exception, (f, u) => f.Random.Bool())
            .RuleFor(u => u.StatusCode, (f, u) => 200)
            .RuleFor(u => u.Message, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.Help, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.XIkRequestId, (f, u) => null)
            .RuleFor(u => u.Metadata, (f, u) => MetadataResponseFaker.Generate());

        /// <summary>
        /// Get a test http client that response to the specified request.
        /// </summary>
        /// <param name="requestMatcher">An expression that matches the <see cref="HttpRequestMessage" /> sent in the request.</param>
        /// <param name="response">The response to return from the request.</param>
        /// <param name="callback">The function to call with the <see cref="HttpRequestMessage" /> sent in the request.</param>
        /// <returns></returns>
        public static HttpClient GetTestHttpClient(Expression requestMatcher, HttpResponseMessage response, Action<HttpRequestMessage> callback)
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
                .Protected()
                // Setup the PROTECTED method to mock
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    requestMatcher,
                    ItExpr.IsAny<CancellationToken>()
                )
                .Callback<HttpRequestMessage, CancellationToken>((msg, ct) => callback?.Invoke(msg))
                // prepare the expected response of the mocked http call
                .ReturnsAsync(response)
                .Verifiable();

            // use real http client with mocked handler here
            var httpClient = new HttpClient(handlerMock.Object);
            return httpClient;
        }


        /// <summary>
        /// Get a test http client that response to the specified request.
        /// </summary>
        /// <param name="response">The response to return from the request.</param>
        /// <param name="callback">The function to call with the <see cref="HttpRequestMessage" /> sent in the request.</param>
        /// <returns></returns>
        public static HttpClient GetTestHttpClient(HttpResponseMessage response, Action<HttpRequestMessage> callback)
        {
            return GetTestHttpClient(ItExpr.IsAny<HttpRequestMessage>(), response, callback);
        }

        /// <summary>
        /// Get a test http client that response to any request.
        /// </summary>
        /// <param name="response">The response to return from the request.</param>
        /// <returns></returns>
        public static HttpClient GetTestHttpClient(HttpResponseMessage response)
        {
            return GetTestHttpClient(ItExpr.IsAny<HttpRequestMessage>(), response, null);
        }

        public static Action<HttpRequestMessage> GetUpdateFileDetailsMessageValidator(
            string[] expectedTags,
            string expectedCustomCoordinates
        )
        {
            return async (msg) =>
            {
                var content = await msg.Content.ReadAsStringAsync();
                dynamic jobj = JObject.Parse(content);
                string[] actualTags = jobj.tags == null ? null : JsonConvert.DeserializeObject<string[]>(jobj.tags.ToString());
                string coords = jobj.customCoordinates;
                Assert.Equal(expectedTags, actualTags);
                Assert.Equal(expectedCustomCoordinates, coords);
            };
        }

        public static Action<HttpRequestMessage> GetUploadRequestMessageValidator(
            string fileUrl,
            string fileName,
            string publicKey = null,
            AuthParamResponse clientAuth = null
        )
        {
            return async (msg) =>
            {
                var contentBodyLines = await GetMultipartFormBodyContent(msg);
                CheckMultipartFormData(contentBodyLines, "file", fileUrl);
                CheckMultipartFormData(contentBodyLines, "fileName", fileName);
                if (clientAuth != null)
                {
                    CheckMultipartFormData(contentBodyLines, "signature", clientAuth.signature);
                    CheckMultipartFormData(contentBodyLines, "token", clientAuth.token);
                    CheckMultipartFormData(contentBodyLines, "expire", clientAuth.expire);
                    CheckMultipartFormData(contentBodyLines, "publicKey", publicKey);
                }
            };
        }

        private static void CheckMultipartFormData(string[] contentBodyLines, string name, string expectedValue)
        {
            var index = Array.IndexOf(contentBodyLines, $"Content-Disposition: form-data; name={name}");
            Assert.True(index >= 0, $"{name} form data not found");
            Assert.Equal(expectedValue, contentBodyLines[index + 1]);
        }

        private static async Task<string[]> GetMultipartFormBodyContent(HttpRequestMessage msg)
        {
            var content = (MultipartFormDataContent)msg.Content;
            Assert.NotNull(content);
            var contentBody = await content.ReadAsStringAsync();
            string[] contentBodyLines = null;
            if (contentBody.IndexOf("\r\n") >= 0)
            {
                contentBodyLines = contentBody.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            }
            else if (contentBody.IndexOf("\n") >= 0)
            {
                contentBodyLines = contentBody.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            }
            Assert.NotNull(contentBodyLines);
            return contentBodyLines;
        }
    }
}
