using Imagekit.Constant;
using Imagekit.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using Xunit;


namespace Imagekit.UnitTests
{

    public class ManageFolderTestAsync

    {
        private const string GOOD_PUBLICKEY = "abc";
        private const string GOOD_URLENDPOINT = "https://dasdsad.dad.io/";


        [Fact]
        public void CreateFolder_Default()
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
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.CreateFolderAsync(model).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void CreateFolderException()
        {
            CreateFolderRequest model = null;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.CreateFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidCreateFolderValue, ex.Result.Message);
        }

        [Fact]
        public void Missing_folderName_Exception()
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
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.CreateFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidfolderNameValue, ex.Result.Message);
        }
        [Fact]
        public void Missing_parentFolderPath_FolderException()
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
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.CreateFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidFolderPathValue, ex.Result.Message);
        }
        [Fact]
        public void DeleteFolder_Default()
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
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.DeleteFolderAsync(model).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }
        [Fact]
        public void Missing_Folder_Path_Exception()
        {
            DeleteFolderRequest model = new DeleteFolderRequest();
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.DeleteFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidDelFolderValue, ex.Result.Message);
        }


        [Fact]
        public void CopyFolder_Default()
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
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.CopyFolderAsync(model).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void Missing_Obj_FolderException()
        {
            CopyFolderRequest model = null;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.CopyFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidCopyFolderValue, ex.Result.Message);
        }
        [Fact]
        public void Missing_sourceFolderPath_FolderException()
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
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.CopyFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidCopysourceFolderPathValue, ex.Result.Message);
        }
        [Fact]
        public void Missing_Destination_FolderPath_FolderException()
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
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.CopyFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidCopydestinationPathValue, ex.Result.Message);
        }

        [Fact]
        public void MoveFolder_Default()
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
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.MoveFolderAsync(model).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void Missing_Obj_Move_FolderException()
        {
            MoveFolderRequest model = null;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.MoveFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidCopyFolderValue, ex.Result.Message);
        }

        [Fact]
        public void Missing_sourceFolderPath_MoveFolderException()
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
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.MoveFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidCopysourceFolderPathValue, ex.Result.Message);
        }
        [Fact]
        public void Missing_Destination_FolderPath_MoveFolderException()
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
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.MoveFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidCopydestinationPathValue, ex.Result.Message);
        }

    }
}




