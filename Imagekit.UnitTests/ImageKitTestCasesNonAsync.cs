using Imagekit.Constant;
using Imagekit.Sdk;
using Imagekit.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Imagekit.UnitTests.FileVersion
{
    public class ImageKitTestCasesNonAsync
    {
        private const string GOOD_PUBLICKEY = "public_key";
        private const string GOOD_PRIVATEKEY = "private_key";
        private const string GOOD_URLENDPOINT = "https://endpoint_url.io/";


        [Fact]
        public void Missing_Key_ExceptionNonAsync()
        {

            Exception actualException = Assert.Throws<Exception>(() => new RestClient("", "https://endpoint_url.io/", new HttpClient()));
            Assert.Equal(ErrorMessages.InvalidKey, actualException.Message);
        }
        [Fact]
        public void Missing_URL_ExceptionNonAsync()
        {

            Exception actualException = Assert.Throws<Exception>(() => new RestClient("abc", "", new HttpClient()));
            Assert.Equal(ErrorMessages.InvalidApiUrl, actualException.Message);
        }

        [Fact]
        public void Constructor_TransformationPosition_DefaultNonAsync()
        {
            var imagekit = new ImagekitClient(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT);
            Assert.NotNull(imagekit);
        }
        [Fact]
        public void UrlValidation()
        {
            var imagekit = new ImagekitClient(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT);
            string path = "/default-image.jpg";
            Transformation trans = new Transformation()
                .Width(400)
                .Height(300)
                .AspectRatio("4-3")
                .Quality(40)
                .Crop("force").CropMode("extract").
                Focus("left").
                Format("jpeg").
                Background("A94D34").
                Border("5-A94D34").
                Rotation(90).
                Blur(10).
                Named("some_name").
                OverlayX(35).
                OverlayY(35).
                OverlayFocus("bottom").
                OverlayHeight(20).
                OverlayHeight(20).
                OverlayImage("/folder/file.jpg"). // leading slash case
                OverlayImageTrim(false).
                OverlayImageAspectRatio("4:3").
                OverlayImageBackground("0F0F0F").
                OverlayImageBorder("10_0F0F0F").
                OverlayImageDpr(2).
                OverlayImageQuality(50).
                OverlayImageCropping("force").
                OverlayText("two words").
                OverlayTextFontSize(20).
                OverlayTextFontFamily("Open Sans").
                OverlayTextColor("00FFFF").
                OverlayTextTransparency(5).
                OverlayTextTypography("b").
                OverlayBackground("00AAFF55").
                OverlayTextEncoded("b3ZlcmxheSBtYWRlIGVhc3k%3D").
                OverlayTextWidth(50).
                OverlayTextBackground("00AAFF55").
                OverlayTextPadding(40).
                OverlayTextInnerAlignment("left").
                OverlayRadius(10).
                Progressive(true).
                Lossless(true).
                Trim(5).
                Metadata(true).
                ColorProfile(true).
                DefaultImage("folder/file.jpg/"). //trailing slash case
                Dpr(3).
                EffectSharpen(10).
                EffectUsm("2-2-0.8-0.024").
                EffectContrast(true).
                EffectGray().
                Original().
                Raw("h-200,w-300,l-image,i-logo.png,l-end")
                ;

            string imageURL = imagekit.Url(trans).Path(path).TransformationPosition("query").Generate();

            Assert.Equal("https://endpoint_url.io/default-image.jpg?tr=w-400%2Ch-300%2Car-4-3%2Cq-40%2Cc-force%2Ccm-extract%2Cfo-left%2Cf-jpeg%2Cbg-A94D34%2Cb-5-A94D34%2Crt-90%2Cbl-10%2Cn-some_name%2Cox-35%2Coy-35%2Cofo-bottom%2Coh-20%2Coi-folder%40%40file.jpg%2Coit-false%2Coiar-4%3A3%2Coibg-0F0F0F%2Coib-10_0F0F0F%2Coidpr-2%2Coiq-50%2Coic-force%2Cot-two%20words%2Cots-20%2Cotf-Open%20Sans%2Cotc-00FFFF%2Coa-5%2Cott-b%2Cobg-00AAFF55%2Cote-b3ZlcmxheSBtYWRlIGVhc3k%253D%2Cotw-50%2Cotbg-00AAFF55%2Cotp-40%2Cotia-left%2Cor-10%2Cpr-true%2Clo-true%2Ct-5%2Cmd-true%2Ccp-true%2Cdi-folder%40%40file.jpg%2Cdpr-3%2Ce-sharpen-10%2Ce-usm-2-2-0.8-0.024%2Ce-contrast-true%2Ce-grayscale-true%2Corig-true%2Ch-200%2Cw-300%2Cl-image%2Ci-logo.png%2Cl-end", imageURL);
        }


        [Fact]
        public void UrlValidation1()
        {
            var imagekit = new ImagekitClient(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT);
            var imgUrl1 = "https://ik.imagekit.io/demo/default-image.jpg";
            string[] queryParams = { "b=query", "a=value" };
            try
            {
                var signedUrl = imagekit.Url(new Transformation().Width(400).Height(300))
                    .Src(imgUrl1)
                    .QueryParameters(queryParams)
                    .ExpireSeconds(600)
                    .Signed()
                    .Generate();
                Console.WriteLine("Signed Url for first image transformed with height: 300, width: 400: - {0}", signedUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          }

        [Fact]
        public void GetFileRequest_DefaultNonAsync()
        {
            GetFileListRequest ob = new GetFileListRequest
            {
                Limit = 10,
                Skip = 0
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = (ResultList)restClient.GetFileListRequest(ob);

            Assert.Equal(response.Raw, response.Raw);
        }

        [Fact]
        public void GetFileDetail_DefaultNonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var response = (Result)restClient.GetFileDetail("abc");
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void GetFile_ID_Detail_ExceptionNonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.GetFileDetail(""));
            Assert.Equal(ErrorMessages.FileIdMissing, ex.Message);
        }



        [Fact]
        public void PurgeCache_DefaultNonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.PurgeCache("abc");
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }
        [Fact]
        public void PurgeStatus_DefaultNonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.PurgeStatus("abc");
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void DeleteFile_DefaultNonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = (ResultDelete)restClient.DeleteFile("abc");
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }
        [Fact]
        public void Delete_File_ID_ExceptionNonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.DeleteFile(""));
            Assert.Equal(ErrorMessages.FileIdMissing, ex.Message);
        }


        [Fact]
        public void BulkDeleteFiles_DefaultNonAsync()
        {
            List<string> ob = new List<string>
            {
                "abc",
                "abcd"
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = (ResultFileDelete)restClient.BulkDeleteFiles(ob);

            Assert.Equal(responseObj.Raw, response.Raw);
        }
        [Fact]
        public void Bulk_Delete_Files_Input_Missing_ExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.BulkDeleteFiles(ob));
            Assert.Equal(ErrorMessages.ListFilesInputMissing, ex.Message);
        }







        [Fact]
        public void Missing_Filed_Null_ExceptionNonAsync()
        {
            TagsRequest ob = new TagsRequest
            {
                tags = new List<string> { "abc" },
                fileIds = null
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.ManageTags(ob, ""));
            Assert.Equal(ErrorMessages.InvalidFiledParamValue, ex.Message);
        }




        [Fact]
        public void Missing_Remove_Filed_Null_ExceptionNonAsync()
        {
            TagsRequest ob = new TagsRequest
            {
                tags = new List<string> { "abc" },
                fileIds = null
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.ManageTags(ob, ""));
            Assert.Equal(ErrorMessages.InvalidFiledParamValue, ex.Message);
        }


        [Fact]
        public void Missing_AI_Filed_Null_ExceptionNonAsync()
        {
            AITagsRequest ob = new AITagsRequest
            {
                AITags = new List<string> { "abc" },
                fileIds = null
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.RemoveAITags(ob));
            Assert.Equal(ErrorMessages.InvalidFiledParamValue, ex.Message);
        }

        [Fact]
        public void DeleteFileVersion_DefaultNonAsync()
        {
            DeleteFileVersionRequest model = new DeleteFileVersionRequest
            {
                fileId = "Tst3",
                versionId = "Tst3"
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.DeleteFileVersion(model);
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void Missing_Object_FileVersionExceptionNonAsync()
        {
            DeleteFileVersionRequest model = null;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => (ResultNoContent)restClient.DeleteFileVersion(model));
            Assert.Equal(ErrorMessages.InvalidDelVerValue, ex.Message);
        }
        [Fact]
        public void Missing_fileId_FileVersionExceptionNonAsync()
        {
            DeleteFileVersionRequest model = new DeleteFileVersionRequest
            {
                versionId = "abc"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.DeleteFileVersion(model));
            Assert.Equal(ErrorMessages.InvalidFieldIdDelVerValue, ex.Message);
        }

        [Fact]
        public void Missing_versionId_FileVersionExceptionNonAsync()
        {
            DeleteFileVersionRequest model = new DeleteFileVersionRequest
            {
                versionId = "",
                fileId = "sas"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.DeleteFileVersion(model));
            Assert.Equal(ErrorMessages.InvalidversionIdDelVerValue, ex.Message);
        }

        [Fact]
        public void CopyFile_DefaultNonAsync()
        {
            CopyFileRequest model = new CopyFileRequest
            {
                sourceFilePath = "Tst3",
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

            var response = restClient.CopyFile(model);
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }
        [Fact]
        public void Missing_Obj_CopyFileExceptionNonAsync()
        {
            CopyFileRequest model = null;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.CopyFile(model));
            Assert.Equal(ErrorMessages.InvalidCopyValue, ex.Message);
        }



        [Fact]
        public void Missing_Source_CopyFileExceptionNonAsync()
        {
            CopyFileRequest model = new CopyFileRequest
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
            var ex = Assert.Throws<Exception>(() => restClient.CopyFile(model));
            Assert.Equal(ErrorMessages.InvalidSourceValue, ex.Message);
        }

        [Fact]
        public void Missing_Destination_CopyFileExceptionNonAsync()
        {
            CopyFileRequest model = new CopyFileRequest
            {
                sourceFilePath = "abc"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.CopyFile(model));
            Assert.Equal(ErrorMessages.InvalidDestinationValue, ex.Message);
        }

        [Fact]
        public void MoveFile_DefaultNonAsync()
        {
            MoveFileRequest model = new MoveFileRequest
            {
                sourceFilePath = "Tst3",
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

            var response = restClient.MoveFile(model);
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }
        [Fact]
        public void Missing_Obj_MoveFileExceptionNonAsync()
        {
            MoveFileRequest model = null;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.MoveFile(model));
            Assert.Equal(ErrorMessages.InvalidCopyValue, ex.Message);
        }

        [Fact]
        public void Missing_Source_MoveFileExceptionNonAsync()
        {
            MoveFileRequest model = new MoveFileRequest
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
            var ex = Assert.Throws<Exception>(() => restClient.MoveFile(model));
            Assert.Equal(ErrorMessages.InvalidSourceValue, ex.Message);
        }

        [Fact]
        public void Missing_Destination_MoveFileExceptionNonAsync()
        {
            MoveFileRequest model = new MoveFileRequest
            {
                sourceFilePath = "abc"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.MoveFile(model));
            Assert.Equal(ErrorMessages.InvalidDestinationValue, ex.Message);
        }

        [Fact]
        public void RenameFile_DefaultNonAsync()
        {
            RenameFileRequest model = new RenameFileRequest
            {
                filePath = "Tst3",
                newFileName = "Tst4",
                purgeCache = false
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.RenameFile(model);
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }
        [Fact]
        public void Missing_FilePath_RenameFileExceptionNonAsync()
        {
            RenameFileRequest model = new RenameFileRequest
            {
                newFileName = "test"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.RenameFile(model));
            Assert.Equal(ErrorMessages.InvalidRenameFilePathValue, ex.Message);
        }
        [Fact]
        public void Missing_NewFileName_RenameFileExceptionNonAsync()
        {
            RenameFileRequest model = new RenameFileRequest
            {
                filePath = "test"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.RenameFile(model));
            Assert.Equal(ErrorMessages.InvalidRenameNewFileNameValue, ex.Message);
        }


        [Fact]
        public void GetBulkJobStatus_DefaultNonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.GetBulkJobStatus("abc");
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }
        [Fact]
        public void Missing_Job_Id_BulkJobStatusExceptionNonAsync()
        {

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.GetBulkJobStatus(""));
            Assert.Equal(ErrorMessages.InvalidJobValue, ex.Message);
        }


        [Fact]
        public void SameImage_getHammingDistance_expectedSuccessWith()
        {
            var imagekit = new ImagekitClient(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT);
            int hammingDistance = imagekit.PHashDistance("f06830ca9f1e3e90", "f06830ca9f1e3e90");
            Assert.Equal(0, hammingDistance);
        }


        [Fact]
        public void SimilarImage_getHammingDistance_expectedSuccessWith()
        {
            var imagekit = new ImagekitClient(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT);
            int hammingDistance = imagekit.PHashDistance("33699c96619cc69e", "968e978414fe04ea");
            Assert.Equal(2, hammingDistance);
        }


    }
}




