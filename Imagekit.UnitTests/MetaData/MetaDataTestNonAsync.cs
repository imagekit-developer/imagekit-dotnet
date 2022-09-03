using Imagekit.Constant;
using Imagekit.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;
using static Imagekit.Models.CustomMetaDataFieldSchemaObject;
using Imagekit.Models.Response;

namespace Imagekit.UnitTests.MetaData
{

    public class MetaDataTestNonAsync
    {
        private const string GOOD_PUBLICKEY = "abc";
        private const string GOOD_URLENDPOINT = "https://dasdsad.dad.io/";



        [Fact]
        public void GetFileMetadata_DefaultNonAsync()
        {


            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = (ResultMetaData)restClient.GetFileMetaData("abc");

            Assert.Equal(responseObj.Raw, response.Raw);
        }
        [Fact]
        public void GetFileMetadataExceptionNonAsync()
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
        public void GetRemoteFileMetadata_DefaultNonAsync()
        {


            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = (ResultMetaData)restClient.GetRemoteFileMetaData("abc");

            Assert.Equal(responseObj.Raw, response.Raw);
        }
        [Fact]
        public void GetRemoteFileMetadataExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.GetRemoteFileMetaData(""));
            Assert.Equal(ErrorMessages.InvalidUrlValue, ex.Message);
        }


        [Fact]
        public void GetCustomMetaDataFields_DefaultNonAsync()
        {

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.GetCustomMetaDataFields(true);
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void CreateCustomMetaDataFields_DefaultNonAsync()
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

            var response = restClient.CreateCustomMetaDataFields(model);
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

            var response = restClient.CreateCustomMetaDataFields(model);
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

            var response = restClient.CreateCustomMetaDataFields(model);
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

            var response = restClient.CreateCustomMetaDataFields(model);
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void CreateCustomMetaDataFields_successExpected_type_SingleSelect()
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

            var response = (ResultCustomMetaDataField)restClient.CreateCustomMetaDataFields(model);
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
            
            CustomMetaDataFieldSchemaObject customMetaDataFieldSchemaObject = new CustomMetaDataFieldSchemaObject
            {
                type = "MultiSelect",
                selectOptions = new string[] { "small", "medium", "large" }
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

            var response = (ResultCustomMetaDataField)restClient.CreateCustomMetaDataFields(model);
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }
        [Fact]
        public void CreateCustomMetaDataFieldsExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.CreateCustomMetaDataFields(model));
            Assert.Equal(ErrorMessages.InvalidMetaTagValue, ex.Message);
        }
        [Fact]
        public void Missing_Name_CustomMetaDataFieldsExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.CreateCustomMetaDataFields(model));
            Assert.Equal(ErrorMessages.InvalidMetaTagNameValue, ex.Message);
        }
        [Fact]
        public void Missing_Label_CustomMetaDataFieldsExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.CreateCustomMetaDataFields(model));
            Assert.Equal(ErrorMessages.InvalidMetaTagLabelValue, ex.Message);
        }
        [Fact]
        public void Missing_Schema_CustomMetaDataFieldsExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.CreateCustomMetaDataFields(model));
            Assert.Equal(ErrorMessages.InvalidMetaTagSchemaValue, ex.Message);
        }

        [Fact]
        public void DeleteCustomMetaDataField_DefaultNonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.DeleteCustomMetaDataField("abc");
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }


        [Fact]
        public void Missing_FileId_CustomMetaDataFieldExceptionNonAsync()
        {

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.DeleteCustomMetaDataField(""));
            Assert.Equal(ErrorMessages.InvalidFileidsValue, ex.Message);
        }



        [Fact]
        public void UpdateCustomMetaDataFields_DefaultNonAsync()
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

            var response = restClient.UpdateCustomMetaDataFields(model);
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void Missing_Object_CustomMetaDataFieldsExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.UpdateCustomMetaDataFields(model));
            Assert.Equal(ErrorMessages.InvalidMetaTagValue, ex.Message);
        }

        [Fact]
        public void Missing_ID_CustomUpdateMetaDataFieldsExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.UpdateCustomMetaDataFields(model));
            Assert.Equal(ErrorMessages.InvalidMetaTagIdValue, ex.Message);
        }
        [Fact]
        public void Missing_Schema_CustomUpdateMetaDataFieldsExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.UpdateCustomMetaDataFields(model));
            Assert.Equal(ErrorMessages.InvalidMetaTagSchemaValue, ex.Message);
        }

    }
}




