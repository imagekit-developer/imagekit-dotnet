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
                fileName = string.Empty
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
                file = null,
                fileName = Guid.NewGuid().ToString()
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
                file = "http://www.google.com/images/logos/ps_logo2.png",
                fileName = Guid.NewGuid().ToString()
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
                file = bytes,
                fileName = Guid.NewGuid().ToString()
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
                file = base64,
                fileName = Guid.NewGuid().ToString()
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
                file = base64,
                fileName = Guid.NewGuid().ToString()
            };
            List<string> tags = new List<string>
            {
                "Software",
                "Developer",
                "Engineer"
            };
            ob.tags = tags;
           
            string customCoordinates = "10,10,20,20";
            ob.customCoordinates = customCoordinates;
            List<string> responseFields = new List<string>
            {
                "isPrivateFile",
                "tags",
                "customCoordinates"
            };

            ob.responseFields = responseFields;
            List<Extension> model1 = new List<Extension>();
            BackGroundImage bck = new BackGroundImage
            {
                name = "remove-bg",
                options = new options() { add_shadow = true, bg_color = "green" }
            };
            TransformationObject transformationObject = new TransformationObject
            {
                type = "transformation",
                value = "w-100"
            };
            List<PostTransformation> postTransformations = new List<PostTransformation>();
            postTransformations.Add(transformationObject);
            UploadTransformation uploadTransformation = new UploadTransformation
            {
                pre = "l-text,i-Imagekit,fs-50,l-end",
                post =  postTransformations,
            };
            model1.Add(bck);
            ob.webhookUrl = "https://webhook.site/c78d617f-33bc-40d9-9e61-608999721e2e";
            ob.useUniqueFileName = true;
            ob.folder = "dummy-folder";
            ob.isPrivateFile = false;
            ob.overwriteFile = true;
            ob.overwriteAITags = true;
            ob.overwriteTags = true;
            ob.overwriteCustomMetadata = true;
            ob.transformation = uploadTransformation;
            ob.checks = "'request.folder' : '/dummy-folder'";
            ob.isPublished = true;
            Hashtable model = new Hashtable
            {
                { "price", 2000 }
            };
            ob.customMetadata = model;
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
                file = base64,
                fileName = Guid.NewGuid().ToString()
            };
            List<string> tags = null;
            ob.tags = tags;
            ob.folder = "demo1";
            string customCoordinates = "10,10,20,20";
            ob.customCoordinates = customCoordinates;
            List<string> responseFields = null;
            ob.responseFields = responseFields;
            List<Extension> model1 = new List<Extension>();
            BackGroundImage bck = new BackGroundImage
            {
                name = "remove-bg",
                options = new options() { add_shadow = true, bg_color = "green", bg_image_url = "http://www.google.com/images/logos/ps_logo2.png" }
            };
            model1.Add(bck);
            ob.webhookUrl = "https://webhook.site/c78d617f-33bc-40d9-9e61-608999721e2e";
            ob.useUniqueFileName = false;
            ob.isPrivateFile = false;
            ob.overwriteFile = false;
            ob.overwriteAITags = false;
            ob.overwriteTags = false;
            ob.overwriteCustomMetadata = true;
            Hashtable model = new Hashtable
            {
                { "price", 2000 }
            };
            ob.customMetadata = model;



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
                file = base64,
                fileName = Guid.NewGuid().ToString()
            };
            List<string> tags = null;
            ob.tags = tags;
            ob.folder = "demo1";
            string customCoordinates = "10,10,20,20";
            ob.customCoordinates = customCoordinates;
            List<string> responseFields = null;
            ob.responseFields = responseFields;
            Hashtable model = new Hashtable
            {
                { "price", 2000 }
            };
            ob.customMetadata = model;
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
                fileId = "",

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
                fileId = "file-Id",

            };
            List<string> tags = new List<string>
            {
                "Software",
                "Developer",
                "Engineer"
            };
            ob.tags = tags;

            string customCoordinates = "10,10,20,20";
            ob.customCoordinates = customCoordinates;
            List<string> responseFields = new List<string>
            {
                "isPrivateFile",
                "tags",
                "customCoordinates"
            };
            List<Extension> model1 = new List<Extension>();
            BackGroundImage bck = new BackGroundImage
            {
                name = "remove-bg",
                options = new options() { add_shadow = true, bg_color = "green", bg_image_url = "http://www.google.com/images/logos/ps_logo2.png" }
            };
            model1.Add(bck);
            ob.webhookUrl = "https://webhook.site/c78d617f-33bc-40d9-9e61-608999721e2e";
            Hashtable model = new Hashtable
            {
                { "price", 2000 }
            };
            ob.customMetadata = model;

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

        [Fact]
        public void UpdateFile_Publish_Status()
        {
            FileUpdateRequest ob = new FileUpdateRequest
            {
                fileId = "file-Id",

            };
            PublishStatus publishStatus = new PublishStatus
            {
                isPublished = false
            };
            ob.publish = publishStatus;
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

       
    }
}




