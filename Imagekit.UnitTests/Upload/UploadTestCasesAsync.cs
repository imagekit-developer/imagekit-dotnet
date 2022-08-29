using Imagekit.Constant;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;
using Imagekit.Models;
using System.Collections;

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
                Url = GetURL(@"http://www.google.com/images/logos/ps_logo2.png"),
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
            var response = (Result)restClient.Upload(ob);
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
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

            var response = (Result)restClient.UploadAsync(ob).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
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

            var response = (Result)restClient.UploadAsync(ob).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
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
                "isPrivateFile",
                "tags",
                "customCoordinates"
            };

            ob.ResponseFields = responseFields;
            List<Extension> model1 = new List<Extension>();
            BackGroundImage bck = new BackGroundImage
            {
                Name = "remove-bg",
                Options = new Options() { Add_shadow = true, Bg_color = "green", Bg_image_url = "http://www.google.com/images/logos/ps_logo2.png" }
            };
            model1.Add(bck);
            ob.WebhookUrl = "https://webhook.site/c78d617f-33bc-40d9-9e61-608999721e2e";
            ob.UseUniqueFileName = false;
            ob.IsPrivateFileValue = false;
            ob.OverwriteFile = false;
            ob.OverwriteAiTags = false;
            ob.OverwriteTags = false;
            ob.OverwriteCustomMetadata = true;
            Hashtable model = new Hashtable
            {
                { "price", 2000 }
            };
            ob.CustomMetadata = model;

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);

            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = (Result)restClient.UploadAsync(ob).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
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
            List<Extension> model1 = new List<Extension>();
            BackGroundImage bck = new BackGroundImage
            {
                Name = "remove-bg",
                Options = new Options() { Add_shadow = true, Bg_color = "green", Bg_image_url = "http://www.google.com/images/logos/ps_logo2.png" }
            };
            model1.Add(bck);
            ob.WebhookUrl = "https://webhook.site/c78d617f-33bc-40d9-9e61-608999721e2e";
            ob.UseUniqueFileName = false;
            ob.IsPrivateFileValue = false;
            ob.OverwriteFile = false;
            ob.OverwriteAiTags = false;
            ob.OverwriteTags = false;
            ob.OverwriteCustomMetadata = true;
            Hashtable model = new Hashtable
            {
                { "price", 2000 }
            };
            ob.CustomMetadata = model;



            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);


            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = (Result)restClient.UploadAsync(ob).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
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
            Hashtable model = new Hashtable
            {
                { "price", 2000 }
            };
            ob.CustomMetadata = model;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);


            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = (Result)restClient.UploadAsync(ob).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void UpdateFile_Missing_File_Id()
        {
            FileUpdateRequest ob = new FileUpdateRequest
            {
                FileId = "",

            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);

            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.UpdateFileDetailAsync(ob));
            Assert.Equal(ErrorMessages.FileIdMissing, ex.Result.Message);
        }

        [Fact]
        public void UpdateFile_Default()
        {
            FileUpdateRequest ob = new FileUpdateRequest
            {
                FileId = "file-Id",

            };
            List<string> tags = new List<string>
            {
                "Software",
                "Developer",
                "Engineer"
            };
            ob.Tags = tags;

            string customCoordinates = "10,10,20,20";
            ob.CustomCoordinates = customCoordinates;
            List<string> responseFields = new List<string>
            {
                "isPrivateFile",
                "tags",
                "customCoordinates"
            };
            List<Extension> model1 = new List<Extension>();
            BackGroundImage bck = new BackGroundImage
            {
                Name = "remove-bg",
                Options = new Options() { Add_shadow = true, Bg_color = "green", Bg_image_url = "http://www.google.com/images/logos/ps_logo2.png" }
            };
            model1.Add(bck);
            ob.WebhookUrl = "https://webhook.site/c78d617f-33bc-40d9-9e61-608999721e2e";
            Hashtable model = new Hashtable
            {
                { "price", 2000 }
            };
            ob.CustomMetadata = model;

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);

            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = (Result)restClient.UpdateFileDetailAsync(ob).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        private static Uri GetURL(string imgPath)
        {
            var uri = new Uri(imgPath);

            return uri;
        }
    }
}




