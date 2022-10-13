using Imagekit.Constant;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Imagekit.UnitTests.Tags
{

    public class ManageTagsTestAsync
    {
        private const string GOOD_PUBLICKEY = "abc";
        private const string GOOD_URLENDPOINT = "https://dasdsad.dad.io/";


        [Fact]
        public void AddTags_Default()
        {
            TagsRequest tagsRequest = new TagsRequest
            {
                tags = new List<string>
                {
                    "abc",
                    "abc"
                },
                fileIds = new List<string>
            {
                "abc"
            }
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.ManageTagsAsync(tagsRequest, "addTags").Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void AddTags_Null_Exception()
        {
            TagsRequest ob = null;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.ManageTagsAsync(ob, ""));
            Assert.Equal(ErrorMessages.InvalidTagValue, ex.Result.Message);
        }
        [Fact]
        public void Missing_Tags_Null_Exception()
        {
            TagsRequest ob = new TagsRequest
            {
                tags = null,
                fileIds = new List<string> { "abc" }
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.ManageTagsAsync(ob, ""));
            Assert.Equal(ErrorMessages.InvalidTagParamValue, ex.Result.Message);
        }

        [Fact]
        public void Missing_Filed_Null_Exception()
        {
            TagsRequest ob = new TagsRequest
            {
                tags = new List<string> { "abc" },
                fileIds = null
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.ManageTagsAsync(ob, ""));
            Assert.Equal(ErrorMessages.InvalidFiledParamValue, ex.Result.Message);
        }


        [Fact]
        public void RemoveTags_Default()
        {
            TagsRequest tagsRequest = new TagsRequest
            {
                tags = new List<string>
                {
                    "abc",
                    "abc"
                },
                fileIds = new List<string>
            {
                "abc"
            }
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.ManageTagsAsync(tagsRequest, "addTags").Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void Remove_Tags_Object_Exception()
        {
            TagsRequest ob = null;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.ManageTagsAsync(ob, ""));
            Assert.Equal(ErrorMessages.InvalidTagValue, ex.Result.Message);
        }
        [Fact]
        public void Missing_Remove_Tags_Null_Exception()
        {
            TagsRequest ob = new TagsRequest
            {
                tags = null,
                fileIds = new List<string> { "abc" }
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.ManageTagsAsync(ob, ""));
            Assert.Equal(ErrorMessages.InvalidTagParamValue, ex.Result.Message);
        }


        [Fact]
        public void Remove_AITags_Null_Exception()
        {
            AITagsRequest ob = null;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.RemoveAITagsAsync(ob));
            Assert.Equal(ErrorMessages.InvalidTagValue, ex.Result.Message);
        }
        [Fact]
        public void Missing_AI_Tags_Null_Exception()
        {
            AITagsRequest ob = new AITagsRequest
            {
                AITags = null,
                fileIds = new List<string> { "abc" }
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.RemoveAITagsAsync(ob));
            Assert.Equal(ErrorMessages.InvalidTagParamValue, ex.Result.Message);
        }

        [Fact]
        public void Missing_AI_Filed_Null_Exception()
        {
            AITagsRequest ob = new AITagsRequest
            {
                AITags = new List<string> { "abc" },
                fileIds = null
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.RemoveAITagsAsync(ob));
            Assert.Equal(ErrorMessages.InvalidFiledParamValue, ex.Result.Message);
        }

    }
}




