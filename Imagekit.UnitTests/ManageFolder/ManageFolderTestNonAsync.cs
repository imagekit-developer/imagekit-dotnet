using Imagekit.Constant;
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
                folderName = "Tst3",
                parentFolderPath = "Tst3"
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
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
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
            var ex = Assert.Throws<Exception>(() => restClient.CreateFolder(null));
            Assert.Equal(ErrorMessages.InvalidCreateFolderValue, ex.Message);
        }

        [Fact]
        public void Missing_folderName_ExceptionNonAsync()
        {
            CreateFolderRequest model = new CreateFolderRequest
            {
                parentFolderPath = "test"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.CreateFolder(model));
            Assert.Equal(ErrorMessages.InvalidfolderNameValue, ex.Message);
        }
        [Fact]
        public void Missing_parentFolderPath_FolderExceptionNonAsync()
        {
            CreateFolderRequest model = new CreateFolderRequest
            {
                folderName = "test"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.CreateFolder(model));
            Assert.Equal(ErrorMessages.InvalidFolderPathValue, ex.Message);
        }
        [Fact]
        public void DeleteFolder_DefaultNonAsync()
        {
            DeleteFolderRequest model = new DeleteFolderRequest
            {
                folderPath = "Tst3"
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
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
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
            var ex = Assert.Throws<Exception>(() => restClient.DeleteFolder(model));
            Assert.Equal(ErrorMessages.InvalidDelFolderValue, ex.Message);
        }


        [Fact]
        public void CopyFolder_DefaultNonAsync()
        {
            CopyFolderRequest model = new CopyFolderRequest
            {
                sourceFolderPath = "Tst3",
                destinationPath = "Tst3",
                includeFileVersions = true
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
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
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
            var ex = Assert.Throws<Exception>(() => restClient.CopyFolder(null));
            Assert.Equal(ErrorMessages.InvalidCopyFolderValue, ex.Message);
        }
        [Fact]
        public void Missing_sourceFolderPath_FolderExceptionNonAsync()
        {
            CopyFolderRequest model = new CopyFolderRequest
            {
                destinationPath = "abc"
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.CopyFolder(model));
            Assert.Equal(ErrorMessages.InvalidCopysourceFolderPathValue, ex.Message);
        }
        [Fact]
        public void Missing_Destination_FolderPath_FolderExceptionNonAsync()
        {
            CopyFolderRequest model = new CopyFolderRequest
            {
                sourceFolderPath = "abc"
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.CopyFolder(model));
            Assert.Equal(ErrorMessages.InvalidCopydestinationPathValue, ex.Message);
        }

        [Fact]
        public void MoveFolder_DefaultNonAsync()
        {
            MoveFolderRequest model = new MoveFolderRequest
            {
                sourceFolderPath = "Tst3",
                destinationPath = "Tst3"
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
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
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
            var ex = Assert.Throws<Exception>(() => restClient.MoveFolder(null));
            Assert.Equal(ErrorMessages.InvalidCopyFolderValue, ex.Message);
        }

        [Fact]
        public void Missing_sourceFolderPath_MoveFolderExceptionNonAsync()
        {
            MoveFolderRequest model = new MoveFolderRequest
            {
                destinationPath = "abc"
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.MoveFolder(model));
            Assert.Equal(ErrorMessages.InvalidCopysourceFolderPathValue, ex.Message);
        }
        [Fact]
        public void Missing_Destination_FolderPath_MoveFolderExceptionNonAsync()
        {
            MoveFolderRequest model = new MoveFolderRequest
            {
                sourceFolderPath = "abc"
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GoodPublickey, GoodUrlendpoint, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.MoveFolder(model));
            Assert.Equal(ErrorMessages.InvalidCopydestinationPathValue, ex.Message);
        }

    }
}




