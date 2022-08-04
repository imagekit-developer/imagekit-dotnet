using System;
using System.Linq.Expressions;
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

        public static Faker<ResponseMetaData> ImagekitResponseFaker = new Faker<ResponseMetaData>()
            .RuleFor(u => u.Raw, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.HttpStatusCode, (f, u) => 200);

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
        public static HttpClient GetTestHttpClient(HttpResponseMessage response)
        {
            return GetTestHttpClient(ItExpr.IsAny<HttpRequestMessage>(), response,null);
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

 
  

        
    }
}
