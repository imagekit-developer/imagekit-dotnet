using Imagekit.Constant;
using Imagekit.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;
using RichardSzalay.MockHttp;
using Imagekit.Helper;
using static Imagekit.Models.CustomMetaDataFieldSchemaObject;

namespace Imagekit.UnitTests.Upload
{
    public class ImageKitRequestModelValidation
    {

        private const string GOOD_PRIVATEKEY = "private_key";
        private const string GOOD_URLENDPOINT = "https://endpoint_url.io/";
        
        [Fact]
        public void UploadFileRequest_ModelValidation()
        {
            string url = "https://upload.imagekit.io/api/v1/files/upload";
            FileCreateRequest ob = new FileCreateRequest
            {
                Url = new Uri(@"https://homepages.cae.wisc.edu/~ece533/images/cat.png"),
                FileName = "test.jpg",
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
                Options = new Options() { Add_shadow = true, Semitransparency = false, Bg_color = "green", Bg_image_url = "http://www.google.com/images/logos/ps_logo2.png" }
            };
            model1.Add(bck);
            ob.WebhookUrl = "https://webhook.site/c78d617f-33bc-40d9-9e61-608999721e2e";
            Hashtable model = new Hashtable
            {
                { "price", 2000 }
            };
            ob.CustomMetadata = model;
            var formdata = MultipartFormDataModel.Build(ob); string result = formdata.ReadAsStringAsync().Result;
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(result)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.Upload(ob);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void UpdateFileDetail_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/files/{0}/details", "file-Id");
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
            List<Extension> modelExt = new List<Extension>();
            BackGroundImage bck = new BackGroundImage
            {
                Name = "remove-bg",
                Options = new Options() { Add_shadow = true, Semitransparency = false, Bg_color = "green", Bg_image_url = "http://www.google.com/images/logos/ps_logo2.png" }
            };
            modelExt.Add(bck);
            ob.WebhookUrl = "https://webhook.site/c78d617f-33bc-40d9-9e61-608999721e2e";
            Hashtable model = new Hashtable
            {
                { "price", 2000 }
            };
            ob.CustomMetadata = model;
            var formdata = MultipartFormDataModel.BuildUpdateFile(ob);
            string result = formdata.ReadAsStringAsync().Result;
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(result)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.UpdateFileDetail(ob);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void GetFileListRequest_ModelValidation()
        {
            GetFileListRequest ob = new GetFileListRequest
            {
                Limit = 10,
                Skip = 0,
                Type = "Test",
                Path = "Test",
                Sort = "Test",
                SearchQuery = "Test",
                FileType = "Test",
                Tags = null
            };
            string param = GetJsonBody.GetFileRequestBody(ob);
            string url = string.Format("https://api.imagekit.io/v1/files/?{0}", param);

            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.GetFileListRequest(ob);
            mockHttp.VerifyNoOutstandingExpectation();
        }
        [Fact]
        public void PurgeCache_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/files/purge");
            string reqJosn = "{\"url\":\"path\"}";
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.PurgeCache("path");
            mockHttp.VerifyNoOutstandingExpectation();
        }
        [Fact]
        public void DeleteFileRequest_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/files/{0}/", "fileId");

            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Delete))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.DeleteFile("fileId");
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void PurgeStatusRequest_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/files/purge/{0}", "purgeRequestId");

            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.PurgeStatus("purgeRequestId");
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void GetFileDetailRequest_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/files/{0}/details", "fileId");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.GetFileDetail("fileId");
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void BulkDeleteFilesRequest_ModelValidation()
        {
            string reqJosn = "{\"fileIds\":[\"fileId1\",\"fileId2\"]}";

            List<string> fileIds = new List<string>
            {
                "fileId1",
                "fileId2"
            };
            string url = string.Format("https://api.imagekit.io/v1/files/batch/deleteByFileIds");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.BulkDeleteFiles(fileIds);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void GetFileMetaDataRequest_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/files/{0}/metadata", "fileId");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.GetFileMetaData("fileId");
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void GetRemoteFileMetaDataRequest_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/metadata?url={0}", "url");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.GetRemoteFileMetaData("url");
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void AddTagsRequest_ModelValidation()
        {
            string reqJosn = "{\"FileIds\":[\"abc\"],\"Tags\":[\"abc\",\"abc\"]}";

            TagsRequest tagsRequest = new TagsRequest
            {
                Tags = new List<string>
                {
                    "abc",
                    "abc"
                },
                FileIds = new List<string>
                {
                    "abc"
                }
            };
            string url = "https://upload.imagekit.io/v1/files/addTags";
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.ManageTags(tagsRequest, "addTags");
            mockHttp.VerifyNoOutstandingExpectation();
        }
        [Fact]
        public void RemoveTagsRequest_ModelValidation()
        {
            string reqJosn = "{\"FileIds\":[\"abc\"],\"Tags\":[\"abc\",\"abc\"]}";

            TagsRequest tagsRequest = new TagsRequest
            {
                Tags = new List<string>
                {
                    "abc",
                    "abc"
                },
                FileIds = new List<string>
                {
                    "abc"
                }
            };
            string url = string.Format("https://upload.imagekit.io/" + UrlHandler.RemoveTags);
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.ManageTags(tagsRequest, "removeTags");
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void RemoveAITagsRequest_ModelValidation()
        {
            string reqJosn = "{\"FileIds\":[\"abc\"],\"AiTags\":[\"abc\",\"abc\"]}";

            AiTagsRequest tagsRequest = new AiTagsRequest
            {
                AiTags = new List<string>
                {
                    "abc",
                    "abc"
                },
                FileIds = new List<string>
                {
                    "abc"
                }
            };
            string url = string.Format("https://upload.imagekit.io/" + UrlHandler.RemoveAiTags);
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.RemoveAiTags(tagsRequest);
            mockHttp.VerifyNoOutstandingExpectation();
        }


        [Fact]
        public void GetCustomMetaDataFields_ModelValidation()
        {

            string url = string.Format("https://api.imagekit.io/v1/customMetadataFields?includeDeleted={0}", true);
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.GetCustomMetaDataFields(true);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void CreateCustomMetaDataFields_ModelValidation()
        {
            string reqJosn = "{\n    \"name\": \"Tst3\",\n    \"label\": \"Test3\",\n    \"schema\": {\n        \"type\": \"Imagekit.Models.CustomMetaDataFieldSchemaObject\",\n        \"minValue\": \"1000\",\n        \"maxValue\": \"3000\"\n    }\n}";
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
            string url = "https://api.imagekit.io/v1/customMetadataFields";
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.CreateCustomMetaDataFields(model);
            mockHttp.VerifyNoOutstandingExpectation();
        }


        [Fact]
        public void DeleteCustomMetaDataField_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/customMetadataFields/{0}", "id");

            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Delete))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.DeleteCustomMetaDataField("id");
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void DeleteFileVersion_ModelValidation()
        {
            DeleteFileVersionRequest model = new DeleteFileVersionRequest
            {
                FileId = "Tst3",
                VersionId = "Tst3"
            };
            string url = string.Format("https://api.imagekit.io/v1/files/{0}/versions/{1}", model.FileId,
                model.VersionId);
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Delete))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.DeleteFileVersion(model);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void CopyFile_ModelValidation()
        {
            string reqJosn = "{\"SourceFilePath\":\"Tst3\",\"DestinationPath\":\"Tst3\",\"IncludeFileVersions\":true}";
            
            CopyFileRequest model = new CopyFileRequest
            {
                SourceFilePath = "Tst3",
                DestinationPath = "Tst3",
                IncludeFileVersions = true
            };
            string url = string.Empty;
            url = string.Format("https://api.imagekit.io/v1/files/copy");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.CopyFile(model);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void MoveFile_ModelValidation()
        {
            string reqJosn = "{\"SourceFilePath\":\"Tst3\",\"DestinationPath\":\"Tst3\"}";
            MoveFileRequest model = new MoveFileRequest
            {
                SourceFilePath = "Tst3",
                DestinationPath = "Tst3"
            };

            string url = string.Empty;
            url = string.Format("https://api.imagekit.io/v1/files/move");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.MoveFile(model);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void RenameFile_ModelValidation()
        {
            string reqJosn = "{\"FilePath\":\"Tst3\",\"NewFileName\":\"Tst4\",\"PurgeCache\":false}";
            RenameFileRequest model = new RenameFileRequest
            {
                FilePath = "Tst3",
                NewFileName = "Tst4",
                PurgeCache = false
            };

            string url = string.Empty;
            url = string.Format("https://api.imagekit.io/v1/files/rename");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Put))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.RenameFile(model);
            mockHttp.VerifyNoOutstandingExpectation();
        }


        [Fact]
        public void CopyFolder_ModelValidation()
        {
            string reqJosn = "{\"SourceFolderPath\":\"Tst3\",\"DestinationPath\":\"Tst3\",\"IncludeFileVersions\":true}";
            CopyFolderRequest model = new CopyFolderRequest
            {
                SourceFolderPath = "Tst3",
                DestinationPath = "Tst3",
                IncludeFileVersions = true
            };
            string url = string.Format("https://api.imagekit.io/v1/bulkJobs/moveFolder");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.CopyFolder(model);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void MoveFolder_ModelValidation()
        {
            string reqJosn = "{\"SourceFolderPath\":\"Tst3\",\"DestinationPath\":\"Tst3\"}";
            MoveFolderRequest model = new MoveFolderRequest
            {
                SourceFolderPath = "Tst3",
                DestinationPath = "Tst3"
            };
            string url = string.Format("https://api.imagekit.io/v1/bulkJobs/moveFolder");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.MoveFolder(model);
            mockHttp.VerifyNoOutstandingExpectation();
        }


        [Fact]
        public void GetBulkJobStatus_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/bulkJobs/{0}", "jobId");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.GetBulkJobStatus("jobId");
            mockHttp.VerifyNoOutstandingExpectation();
        }
        [Fact]
        public void GetFileVersions_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/bulkJobs/{0}", "fileId");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.GetFileVersions("fileId");
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void GetFileVersionDetails_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/files/{0}/versions/{1}", "fileId", "versionId");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.GetFileVersionDetails("fileId", "versionId");
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void RestoreFileVersion_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/files/{0}/versions/{1}/restore", "fileId", "versionId");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Put))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.RestoreFileVersion("fileId", "versionId");
            mockHttp.VerifyNoOutstandingExpectation();
        }
    }
}
