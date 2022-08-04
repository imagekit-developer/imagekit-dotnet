using Imagekit.Constant;
using Imagekit.Sdk;
using Imagekit.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;
using static Imagekit.Models.CustomMetaDataFieldSchemaObject;

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

            var response = restClient.GetFileMetaData("abc");
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
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

            var response = restClient.GetRemoteFileMetaData("abc");
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
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
            var ex = Assert.Throws<Exception>(() =>  restClient.GetRemoteFileMetaData(""));
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
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }

        [Fact]
        public void CreateCustomMetaDataFields_DefaultNonAsync()
        {
            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                Name = "Tst3",
                Label = "Test3"
            };
            CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject
            {
                Type = CustomMetaDataTypeEnum.Number,
                MinValue = 1000,
                MaxValue = 3000,
                MinLength = 500,
                MaxLength = 600,
                IsValueRequired = false
            };

            model.Schema = schema;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.CreateCustomMetaDataFields(model);
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }

        [Fact]
        public void CreateCustomMetaDataFields_Type_Date()
        {
            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                Name = "Tst3",
                Label = "Test3"
            };
            CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject
            {
                Type = CustomMetaDataTypeEnum.DateTime,
                MinValue = 1000,
                MaxValue = 3000,
                MinLength = 500,
                MaxLength = 600,
                IsValueRequired = false
            };

            model.Schema = schema;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.CreateCustomMetaDataFields(model);
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }
        [Fact]
        public void CreateCustomMetaDataFields_Type_Text()
        {
            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                Name = "Tst3",
                Label = "Test3"
            };
            CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject
            {
                Type = CustomMetaDataTypeEnum.Text,
                MinValue = 1000,
                MaxValue = 3000,
                MinLength = 500,
                MaxLength = 600,
                IsValueRequired = false
            };

            model.Schema = schema;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.CreateCustomMetaDataFields(model);
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }

        [Fact]
        public void CreateCustomMetaDataFields_Type_TextArea()
        {
            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                Name = "Tst3",
                Label = "Test3"
            };
            CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject
            {
                Type = CustomMetaDataTypeEnum.Textarea,
                MinValue = 1000,
                MaxValue = 3000,
                MinLength = 500,
                MaxLength = 600,
                IsValueRequired = false
            };

            model.Schema = schema;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.CreateCustomMetaDataFields(model);
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }

        [Fact]
        public void CreateCustomMetaDataFields_successExpected_type_SingleSelect()
        {
            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                Name = "Tst3",
                Label = "Test3"
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
            CustomMetaDataFieldSchemaObject customMetaDataFieldSchemaObject = new CustomMetaDataFieldSchemaObject
            {
                Type = CustomMetaDataTypeEnum.SingleSelect,
                SelectOptions = objectList
            };

            CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject
            {
                Type = CustomMetaDataTypeEnum.Number,
                MinValue = 1000,
                MaxValue = 3000,
                MinLength = 500,
                MaxLength = 600,
                DefaultValue = false,
                IsValueRequired = false
            };

            model.Schema = schema;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.CreateCustomMetaDataFields(model);
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }
        [Fact]
        public void CreateCustomMetaDataFields_successExpected_type_MultiSelect()
        {
            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                Name = "Tst3",
                Label = "Test3"
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
            CustomMetaDataFieldSchemaObject customMetaDataFieldSchemaObject = new CustomMetaDataFieldSchemaObject
            {
                Type = CustomMetaDataTypeEnum.MultiSelect,
                SelectOptions = objectList
            };

            CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject
            {
                Type = CustomMetaDataTypeEnum.Number,
                MinValue = 1000,
                MaxValue = 3000,
                MinLength = 500,
                MaxLength = 600,
                IsValueRequired = false
            };

            model.Schema = schema;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.CreateCustomMetaDataFields(model);
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
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
            var ex = Assert.Throws<Exception>(() =>  restClient.CreateCustomMetaDataFields(model));
            Assert.Equal(ErrorMessages.InvalidMetaTagValue, ex.Message);
        }
        [Fact]
        public void Missing_Name_CustomMetaDataFieldsExceptionNonAsync()
        {
            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                Name = string.Empty
            };
            CustomMetaDataFieldSchemaObject ob = new CustomMetaDataFieldSchemaObject
            {
                MaxValue = 1000
            };
            model.Schema = ob;

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.CreateCustomMetaDataFields(model));
            Assert.Equal(ErrorMessages.InvalidMetaTagNameValue, ex.Message);
        }
        [Fact]
        public void Missing_Label_CustomMetaDataFieldsExceptionNonAsync()
        {
            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                Name = "abc",
                Label = string.Empty
            };
            CustomMetaDataFieldSchemaObject ob = new CustomMetaDataFieldSchemaObject
            {
                MaxValue = 1000
            };
            model.Schema = ob;



            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.CreateCustomMetaDataFields(model));
            Assert.Equal(ErrorMessages.InvalidMetaTagLabelValue, ex.Message);
        }
        [Fact]
        public void Missing_Schema_CustomMetaDataFieldsExceptionNonAsync()
        {
            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                Name = "abc",
                Label = "test",
                Schema = null
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.CreateCustomMetaDataFields(model));
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
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
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
            var ex = Assert.Throws<Exception>(() =>  restClient.DeleteCustomMetaDataField(""));
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
                Type = CustomMetaDataTypeEnum.Number,
                MinValue = 1000,
                MaxValue = 3000
            };
            model.Schema = schema;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.UpdateCustomMetaDataFields(model);
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
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
            var ex = Assert.Throws<Exception>(() =>  restClient.UpdateCustomMetaDataFields(model));
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
                MaxValue = 1000
            };
            model.Schema = ob;

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.UpdateCustomMetaDataFields(model));
            Assert.Equal(ErrorMessages.InvalidMetaTagIdValue, ex.Message);
        }
        [Fact]
        public void Missing_Schema_CustomUpdateMetaDataFieldsExceptionNonAsync()
        {
            CustomMetaDataFieldUpdateRequest model = new CustomMetaDataFieldUpdateRequest
            {
                Id = "abc",
                Schema = null
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.UpdateCustomMetaDataFields(model));
            Assert.Equal(ErrorMessages.InvalidMetaTagSchemaValue, ex.Message);
        }

    }
}




