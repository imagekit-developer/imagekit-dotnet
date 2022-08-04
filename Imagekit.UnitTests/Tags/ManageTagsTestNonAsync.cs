using Imagekit.Constant;
using Imagekit.Sdk;
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
                Tags = new List<string>()
            };
            tagsRequest.Tags.Add("abc");
            tagsRequest.Tags.Add("abc");

            tagsRequest.FileIds = new List<string>
            {
                "abc"
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
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
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
            var ex = Assert.Throws<Exception>(() =>  restClient.ManageTags(ob, ""));
            Assert.Equal(ErrorMessages.InvalidTagValue, ex.Message);
        }
        [Fact]
        public void Missing_Tags_Null_ExceptionNonAsync()
        {
            TagsRequest ob = new TagsRequest
            {
                Tags = null,
                FileIds = new List<string>()
            };
            ob.FileIds.Add("abc");
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.ManageTags(ob, ""));
            Assert.Equal(ErrorMessages.InvalidTagParamValue, ex.Message);
        }

        [Fact]
        public void Missing_Filed_Null_ExceptionNonAsync()
        {
            TagsRequest ob = new TagsRequest
            {
                Tags = new List<string>()
            };
            ob.Tags.Add("abc");
            ob.FileIds = null;

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.ManageTags(ob, ""));
            Assert.Equal(ErrorMessages.InvalidFiledParamValue, ex.Message);
        }


        [Fact]
        public void RemoveTags_DefaultNonAsync()
        {
            TagsRequest tagsRequest = new TagsRequest
            {
                Tags = new List<string>()
            };
            tagsRequest.Tags.Add("abc");
            tagsRequest.Tags.Add("abc");

            tagsRequest.FileIds = new List<string>
            {
                "abc"
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
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
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
            var ex = Assert.Throws<Exception>(() =>  restClient.ManageTags(ob, ""));
            Assert.Equal(ErrorMessages.InvalidTagValue, ex.Message);
        }
        [Fact]
        public void Missing_Remove_Tags_Null_ExceptionNonAsync()
        {
            TagsRequest ob = new TagsRequest
            {
                Tags = null,
                FileIds = new List<string>()
            };
            ob.FileIds.Add("abc");
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.ManageTags(ob, ""));
            Assert.Equal(ErrorMessages.InvalidTagParamValue, ex.Message);
        }


        [Fact]
        public void Remove_AITags_Null_ExceptionNonAsync()
        {
            AiTagsRequest ob = null;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.RemoveAiTags(ob));
            Assert.Equal(ErrorMessages.InvalidTagValue, ex.Message);
        }
        [Fact]
        public void Missing_AI_Tags_Null_ExceptionNonAsync()
        {
            AiTagsRequest ob = new AiTagsRequest
            {
                AiTags = null,
                FileIds = new List<string>()
            };
            ob.FileIds.Add("abc");
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.RemoveAiTags(ob));
            Assert.Equal(ErrorMessages.InvalidTagParamValue, ex.Message);
        }

        [Fact]
        public void Missing_AI_Filed_Null_ExceptionNonAsync()
        {
            AiTagsRequest ob = new AiTagsRequest
            {
                AiTags = new List<string>()
            };
            ob.AiTags.Add("abc");
            ob.FileIds = null;

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.RemoveAiTags(ob));
            Assert.Equal(ErrorMessages.InvalidFiledParamValue, ex.Message);
        }

    }
}




