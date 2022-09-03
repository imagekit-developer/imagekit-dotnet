using Imagekit.Constant;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Imagekit.UnitTests.Tags
{

    public class ManageTagsTestNonAsync
    {
        private const string GOOD_PUBLICKEY = "abc";
        private const string GOOD_URLENDPOINT = "https://dasdsad.dad.io/";


        [Fact]
        public void AddTags_DefaultNonAsync()
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

            var response = restClient.ManageTags(tagsRequest, "addTags");
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void AddTags_Null_ExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.ManageTags(ob, ""));
            Assert.Equal(ErrorMessages.InvalidTagValue, ex.Message);
        }
        [Fact]
        public void Missing_Tags_Null_ExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.ManageTags(ob, ""));
            Assert.Equal(ErrorMessages.InvalidTagParamValue, ex.Message);
        }

        [Fact]
        public void Missing_Filed_Null_ExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.ManageTags(ob, ""));
            Assert.Equal(ErrorMessages.InvalidFiledParamValue, ex.Message);
        }


        [Fact]
        public void RemoveTags_DefaultNonAsync()
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

            var response = restClient.ManageTags(tagsRequest, "removeTags");
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void Remove_Tags_Object_ExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.ManageTags(ob, ""));
            Assert.Equal(ErrorMessages.InvalidTagValue, ex.Message);
        }
        [Fact]
        public void Missing_Remove_Tags_Null_ExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.ManageTags(ob, ""));
            Assert.Equal(ErrorMessages.InvalidTagParamValue, ex.Message);
        }


        [Fact]
        public void Remove_AITags_Null_ExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.RemoveAITags(ob));
            Assert.Equal(ErrorMessages.InvalidTagValue, ex.Message);
        }
        [Fact]
        public void Missing_AI_Tags_Null_ExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.RemoveAITags(ob));
            Assert.Equal(ErrorMessages.InvalidTagParamValue, ex.Message);
        }

        [Fact]
        public void Missing_AI_Filed_Null_ExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.RemoveAITags(ob));
            Assert.Equal(ErrorMessages.InvalidFiledParamValue, ex.Message);
        }

    }
}




