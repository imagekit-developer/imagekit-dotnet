using Imagekit.Constant;
using Imagekit.Sdk;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;
using Newtonsoft.Json.Linq;

namespace Imagekit.UnitTests.Upload
{

    public class UploadTestCasesAsync
    {
        private const string GOOD_PUBLICKEY = "abc";
        private const string GOOD_URLENDPOINT = "https://dasdsad.dad.io/";


        [Fact]
        public void Upload_InvalidObject_Exception()
        {

            FileCreateRequest ob = null;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.UploadAsync(ob));
            Assert.Equal(ErrorMessages.InvalidFileUploadObjValue, ex.Result.Message);
        }
        [Fact]
        public void Upload_InvalidFileName_Exception()
        {
            FileCreateRequest ob = new FileCreateRequest
            {
                FileName = string.Empty
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.UploadAsync(ob));
            Assert.Equal(ErrorMessages.MissingUploadFilenameParameter, ex.Result.Message);
        }
        [Fact]
        public void Upload_InvalidFileParam_Exception()
        {

            FileCreateRequest ob = new FileCreateRequest
            {
                Base64 = string.Empty,
                FileName = Guid.NewGuid().ToString()
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.UploadAsync(ob));
            Assert.Equal(ErrorMessages.InvalidFileValue, ex.Result.Message);
        }

        [Fact]
        public void UploadFileByURI_Default()
        {
            FileCreateRequest ob = new FileCreateRequest
            {
                Url = GetURL(@"C:\test.jpg"),
                FileName = Guid.NewGuid().ToString()
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);

            var RestClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var response = RestClient.Upload(ob);
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }

        [Fact]
        public void UploadFileByBytes_Default()
        {

            string base64 = "iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==";
            byte[] bytes = Convert.FromBase64String(base64);

            FileCreateRequest ob = new FileCreateRequest
            {
                Bytes = bytes,
                FileName = Guid.NewGuid().ToString()
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);


            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.UploadAsync(ob).Result;
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }

        [Fact]
        public void UploadFileByBase64_Default()
        {
            string base64 = "iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==";
            FileCreateRequest ob = new FileCreateRequest
            {
                Base64 = base64,
                FileName = Guid.NewGuid().ToString()
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);


            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.UploadAsync(ob).Result;
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }
        [Fact]
        public void UploadFile_Default()
        {
            string base64 = "iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==";
            FileCreateRequest ob = new FileCreateRequest
            {
                Base64 = base64,
                FileName = Guid.NewGuid().ToString()
            };
            List<string> tags = new List<string>
            {
                "Software",
                "Developer",
                "Engineer"
            };
            ob.Tags = tags;
            ob.Folder = "demo1";
            string customCoordinates = "10,10,20,20";
            ob.CustomCoordinates = customCoordinates;
            List<string> responseFields = new List<string>
            {
                "thumbnail",
                "tags",
                "customCoordinates"
            };

            ob.ResponseFields = responseFields;
            JObject optionsInnerObject = new JObject
            {
                { "add_shadow", true }
            };
            JObject innerObject1 = new JObject
            {
                { "name", "remove-bg" },
                { "options", optionsInnerObject }
            };
            JObject innerObject2 = new JObject
            {
                { "name", "google-auto-tagging" },
                { "minConfidence", 10 },
                { "maxTags", 5 }
            };
            JArray jsonArray = new JArray
            {
                innerObject1,
                innerObject2
            };

            ob.Extensions = jsonArray;
            ob.WebhookUrl = "https://webhook.site/c78d617f-33bc-40d9-9e61-608999721e2e";
            ob.UseUniqueFileName = false;
            ob.IsPrivateFileValue = false;
            ob.OverwriteFile = false;
            ob.OverwriteAiTags = false;
            ob.OverwriteTags = false;
            ob.OverwriteCustomMetadata = true;
            JObject jsonObjectCustomMetadata = new JObject
            {
                { "test1", 10 }
            };
            ob.CustomMetadata = jsonObjectCustomMetadata;




            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);


            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.UploadAsync(ob).Result;
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }

        [Fact]
        public void UploadFile_Null_List()
        {
            string base64 = "iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==";
            FileCreateRequest ob = new FileCreateRequest
            {
                Base64 = base64,
                FileName = Guid.NewGuid().ToString()
            };
            List<string> tags = null;
            ob.Tags = tags;
            ob.Folder = "demo1";
            string customCoordinates = "10,10,20,20";
            ob.CustomCoordinates = customCoordinates;
            List<string> responseFields = null;

            ob.ResponseFields = responseFields;
            JObject optionsInnerObject = new JObject
            {
                { "add_shadow", true }
            };
            JObject innerObject1 = new JObject
            {
                { "name", "remove-bg" },
                { "options", optionsInnerObject }
            };
            JObject innerObject2 = new JObject
            {
                { "name", "google-auto-tagging" },
                { "minConfidence", 10 },
                { "maxTags", 5 }
            };
            JArray jsonArray = new JArray
            {
                innerObject1,
                innerObject2
            };

            ob.Extensions = jsonArray;
            ob.WebhookUrl = "https://webhook.site/c78d617f-33bc-40d9-9e61-608999721e2e";
            ob.UseUniqueFileName = false;
            ob.IsPrivateFileValue = false;
            ob.OverwriteFile = false;
            ob.OverwriteAiTags = false;
            ob.OverwriteTags = false;
            ob.OverwriteCustomMetadata = true;
            JObject jsonObjectCustomMetadata = new JObject
            {
                { "test1", 10 }
            };
            ob.CustomMetadata = jsonObjectCustomMetadata;




            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);


            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.UploadAsync(ob).Result;
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }


        [Fact]
        public void UploadFile_Null_Object_List()
        {
            string base64 = "iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==";
            FileCreateRequest ob = new FileCreateRequest
            {
                Base64 = base64,
                FileName = Guid.NewGuid().ToString()
            };
            List<string> tags = null;
            ob.Tags = tags;
            ob.Folder = "demo1";
            string customCoordinates = "10,10,20,20";
            ob.CustomCoordinates = customCoordinates;
            List<string> responseFields = null;
            ob.ResponseFields = responseFields;
            JObject jsonObjectCustomMetadata = null;
            ob.CustomMetadata = jsonObjectCustomMetadata;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);


            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.UploadAsync(ob).Result;
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }

        private static Uri GetURL(string imgPath)
        {
            var uri = new Uri(imgPath);

            return uri;
        }
    }
}




