using Imagekit.Constant;
using Imagekit.Sdk;
using Imagekit.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using Xunit;


namespace Imagekit.UnitTests
{

    public class ManageFolderTestNon

    {
        private const string GoodPublickey = "abc";
        private const string GoodUrlendpoint = "https://dasdsad.dad.io/";

       
        [Fact]
        public void CreateFolder_DefaultNonAsync()
        {
            CreateFolderRequest model = new CreateFolderRequest
            {
                FolderName = "Tst3",
                ParentFolderPath = "Tst3"
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);

            var response = restClient.CreateFolder(model);
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }
       
        [Fact]
        public void CreateFolderExceptionNonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.CreateFolder(null));
            Assert.Equal(ErrorMessages.InvalidCreateFolderValue, ex.Message);
        }

        [Fact]
        public void Missing_FolderName_ExceptionNonAsync()
        {
            CreateFolderRequest model = new CreateFolderRequest
            {
                ParentFolderPath = "test"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.CreateFolder(model));
            Assert.Equal(ErrorMessages.InvalidFolderNameValue, ex.Message);
        }
        [Fact]
        public void Missing_ParentFolderPath_FolderExceptionNonAsync()
        {
            CreateFolderRequest model = new CreateFolderRequest
            {
                FolderName = "test"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.CreateFolder(model));
            Assert.Equal(ErrorMessages.InvalidFolderPathValue, ex.Message);
        }
        [Fact]
        public void DeleteFolder_DefaultNonAsync()
        {
            DeleteFolderRequest model = new DeleteFolderRequest
            {
                FolderPath = "Tst3"
            };


            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);

            var response = restClient.DeleteFolder(model);
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }
        [Fact]
        public void Missing_Folder_Path_ExceptionNonAsync()
        {
            DeleteFolderRequest model = new DeleteFolderRequest();
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.DeleteFolder(model));
            Assert.Equal(ErrorMessages.InvalidDelFolderValue, ex.Message);
        }


        [Fact]
        public void CopyFolder_DefaultNonAsync()
        {
            CopyFolderRequest model = new CopyFolderRequest
            {
                SourceFolderPath = "Tst3",
                DestinationPath = "Tst3",
                IncludeFileVersions = true
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);

            var response = restClient.CopyFolder(model);
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }
        
        [Fact]
        public void Missing_Obj_FolderExceptionNonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.CopyFolder(null));
            Assert.Equal(ErrorMessages.InvalidCopyFolderValue, ex.Message);
        }
        [Fact]
        public void Missing_SourceFolderPath_FolderExceptionNonAsync()
        {
            CopyFolderRequest model = new CopyFolderRequest
            {
                DestinationPath = "abc"
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.CopyFolder(model));
            Assert.Equal(ErrorMessages.InvalidCopySourceFolderPathValue, ex.Message);
        }
        [Fact]
        public void Missing_Destination_FolderPath_FolderExceptionNonAsync()
        {
            CopyFolderRequest model = new CopyFolderRequest
            {
                SourceFolderPath = "abc"
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.CopyFolder(model));
            Assert.Equal(ErrorMessages.InvalidCopyDestinationPathValue, ex.Message);
        }

        [Fact]
        public void MoveFolder_DefaultNonAsync()
        {
            MoveFolderRequest model = new MoveFolderRequest
            {
                SourceFolderPath = "Tst3",
                DestinationPath = "Tst3"
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);

            var response = restClient.MoveFolder(model);
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }
      
        [Fact]
        public void Missing_Obj_Move_FolderExceptionNonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.MoveFolder(null));
            Assert.Equal(ErrorMessages.InvalidCopyFolderValue, ex.Message);
        }

        [Fact]
        public void Missing_SourceFolderPath_MoveFolderExceptionNonAsync()
        {
            MoveFolderRequest model = new MoveFolderRequest
            {
                DestinationPath = "abc"
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.MoveFolder(model));
            Assert.Equal(ErrorMessages.InvalidCopySourceFolderPathValue, ex.Message);
        }
        [Fact]
        public void Missing_Destination_FolderPath_MoveFolderExceptionNonAsync()
        {
            MoveFolderRequest model = new MoveFolderRequest
            {
                SourceFolderPath = "abc"
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.MoveFolder(model));
            Assert.Equal(ErrorMessages.InvalidCopyDestinationPathValue, ex.Message);
        }
       
    }
}




