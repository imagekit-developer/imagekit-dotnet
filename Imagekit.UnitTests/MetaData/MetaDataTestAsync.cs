using Imagekit.Constant;
using Imagekit.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Imagekit.Models.Response;
using Xunit;
using static Imagekit.Models.CustomMetaDataFieldSchemaObject;

namespace Imagekit.UnitTests.MetaData
{

    public class MetaDataTestAsync
    {
        private const string GOOD_PUBLICKEY = "abc";
        private const string GOOD_URLENDPOINT = "https://dasdsad.dad.io/";



        [Fact]
        public void GetFileMetadata_Default()
        {


            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = (ResultMetaData)restClient.GetFileMetaDataAsync("abc").Result;

            Assert.Equal(responseObj.Raw, response.Raw);
        }
        [Fact]
        public void GetFileMetadataException()
        {
            List<string> ob = new List<string>();
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.GetFileMetaData(""));
            Assert.Equal(ErrorMessages.FileIdMissing, ex.Message);
        }


        [Fact]
        public void GetRemoteFileMetadata_Default()
        {


            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = (ResultMetaData)restClient.GetRemoteFileMetaDataAsync("abc").Result;

            Assert.Equal(responseObj.Raw, response.Raw);
        }
        [Fact]
        public void GetRemoteFileMetadataException()
        {
            List<string> ob = new List<string>();
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.GetRemoteFileMetaDataAsync(""));
            Assert.Equal(ErrorMessages.InvalidUrlValue, ex.Result.Message);
        }


        [Fact]
        public void GetCustomMetaDataFields_Default()
        {

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.GetCustomMetaDataFieldsAsync(true).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void CreateCustomMetaDataFields_Default()
        {
            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                name = "Tst3",
                label = "Test3"
            };
            CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject
            {
                type = "Number",
                minValue = 1000,
                maxValue = 3000,
                minLength = 500,
                maxLength = 600,
                isValueRequired = false
            };

            model.schema = schema;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.CreateCustomMetaDataFieldsAsync(model).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void CreateCustomMetaDataFields_Type_Date()
        {
            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                name = "Tst3",
                label = "Test3"
            };
            CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject
            {
                type = "Number",
                minValue = 1000,
                maxValue = 3000,
                minLength = 500,
                maxLength = 600,
                isValueRequired = false
            };

            model.schema = schema;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.CreateCustomMetaDataFieldsAsync(model).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }
        [Fact]
        public void CreateCustomMetaDataFields_Type_Text()
        {
            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                name = "Tst3",
                label = "Test3"
            };
            CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject
            {
                type = "Number",
                minValue = 1000,
                maxValue = 3000
                
            };

            model.schema = schema;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.CreateCustomMetaDataFieldsAsync(model).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void CreateCustomMetaDataFields_Type_TextArea()
        {

            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                name = "Tst3",
                label = "Test3"
            };
            CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject
            {
                type = "Number",
                minValue = 1000,
                maxValue = 3000
               
            };

            model.schema = schema;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.CreateCustomMetaDataFieldsAsync(model).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void CreateCustomMetaDataFields_successExpected_type_SingleSelect()
        {
         
            List<object> objectList = new List<object>
            {
                "small",
                "medium",
                "large",
                30,
                40,
                true
            };

            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                name = "Tst3",
                label = "Test3"
            };
            CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject
            {
                type = "Number",
                minValue = 1000,
                maxValue = 3000
            };

            model.schema = schema;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.CreateCustomMetaDataFieldsAsync(model).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }
        [Fact]
        public void CreateCustomMetaDataFields_successExpected_type_MultiSelect()
        {
            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                name = "Tst3",
                label = "Test3"
            };
            List<object> objectList = new List<object>
            {
                "small",
                "medium",
                "large",
                30,
                40,
                true
            };

            CustomMetaDataFieldCreateRequest customMetaDataFieldSchemaObject = new CustomMetaDataFieldCreateRequest
            {
                name = "Tst3",
                label = "Test3"
            };
            CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject
            {
                type = "Number",
                minValue = 1000,
                maxValue = 3000
            };

            model.schema = schema;
            
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.CreateCustomMetaDataFieldsAsync(model).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }
        [Fact]
        public void CreateCustomMetaDataFieldsException()
        {
            CustomMetaDataFieldCreateRequest model = null;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.CreateCustomMetaDataFieldsAsync(model));
            Assert.Equal(ErrorMessages.InvalidMetaTagValue, ex.Result.Message);
        }
        [Fact]
        public void Missing_Name_CustomMetaDataFieldsException()
        {
            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                name = string.Empty
            };
            CustomMetaDataFieldSchemaObject ob = new CustomMetaDataFieldSchemaObject
            {
                maxValue = 1000
            };
            model.schema = ob;

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.CreateCustomMetaDataFieldsAsync(model));
            Assert.Equal(ErrorMessages.InvalidMetaTagNameValue, ex.Result.Message);
        }
        [Fact]
        public void Missing_Label_CustomMetaDataFieldsException()
        {
            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                name = "abc",
                label = string.Empty
            };
            CustomMetaDataFieldSchemaObject ob = new CustomMetaDataFieldSchemaObject
            {
                maxValue = 1000
            };
            model.schema = ob;



            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.CreateCustomMetaDataFieldsAsync(model));
            Assert.Equal(ErrorMessages.InvalidMetaTagLabelValue, ex.Result.Message);
        }
        [Fact]
        public void Missing_Schema_CustomMetaDataFieldsException()
        {
            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                name = "abc",
                label = "test",
                schema = null
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.CreateCustomMetaDataFieldsAsync(model));
            Assert.Equal(ErrorMessages.InvalidMetaTagSchemaValue, ex.Result.Message);
        }

        [Fact]
        public void DeleteCustomMetaDataField_Default()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.DeleteCustomMetaDataFieldAsync("abc").Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }


        [Fact]
        public void Missing_FileId_CustomMetaDataFieldException()
        {

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.DeleteCustomMetaDataFieldAsync(""));
            Assert.Equal(ErrorMessages.InvalidFileidsValue, ex.Result.Message);
        }



        [Fact]
        public void UpdateCustomMetaDataFields_Default()
        {
            CustomMetaDataFieldUpdateRequest model = new CustomMetaDataFieldUpdateRequest
            {
                Id = "Tst3"
            };

            CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject
            {
                type = "Number",
                minValue = 1000,
                maxValue = 3000
            };
            model.schema = schema;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.UpdateCustomMetaDataFieldsAsync(model).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void Missing_Object_CustomMetaDataFieldsException()
        {
            CustomMetaDataFieldUpdateRequest model = null;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.UpdateCustomMetaDataFieldsAsync(model));
            Assert.Equal(ErrorMessages.InvalidMetaTagValue, ex.Result.Message);
        }

        [Fact]
        public void Missing_ID_CustomUpdateMetaDataFieldsException()
        {
            CustomMetaDataFieldUpdateRequest model = new CustomMetaDataFieldUpdateRequest
            {
                Id = ""
            };
            CustomMetaDataFieldSchemaObject ob = new CustomMetaDataFieldSchemaObject
            {
                maxValue = 1000
            };
            model.schema = ob;

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.UpdateCustomMetaDataFieldsAsync(model));
            Assert.Equal(ErrorMessages.InvalidMetaTagIdValue, ex.Result.Message);
        }
        [Fact]
        public void Missing_Schema_CustomUpdateMetaDataFieldsException()
        {
            CustomMetaDataFieldUpdateRequest model = new CustomMetaDataFieldUpdateRequest
            {
                Id = "abc",
                schema = null
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.UpdateCustomMetaDataFieldsAsync(model));
            Assert.Equal(ErrorMessages.InvalidMetaTagSchemaValue, ex.Result.Message);
        }

    }
}




