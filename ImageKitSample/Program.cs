using Imagekit.Models;
using Imagekit.Sdk;
using System;
using System.Collections.Generic;
using Imagekit;
using static Imagekit.Models.CustomMetaDataFieldSchemaObject;

namespace ImagekitSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create Instance of ImageKit
            ImagekitClient imagekit = new ImagekitClient("TestPublicKey", "TestPrivateKey", "https://api.imagekit.io/");


            #region URL Generation

            /// Generating URLs
            string imageURL = imagekit.Url(new Transformation().Width(400).Height(300))
                .Path("/default-image.jpg")
                .UrlEndpoint("https://ik.imagekit.io/your_imagekit_id/endpoint")
                .TransformationPosition("query")
                .Generate();
            Console.WriteLine("Url for first image transformed with height: 300, width: 400 - {0}", imageURL);


            ///// Generating Signed URL
            //var imgURL1 = "https://ik.imagekit.io/demo/default-image.jpg";
            //string[] queryParams = { "b=123", "a=test" };
            //try
            //{
            //    var signedUrl = imagekit.Url(new Transformation().Width(400).Height(300))
            //    .Src(imgURL1)
            //    .QueryParameters(queryParams)
            //    .ExpireSeconds(600)
            //    .Signed()
            //    .Generate();
            //    Console.WriteLine("Signed Url for first image transformed with height: 300, width: 400: - {0}", signedUrl);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            #endregion

            #region List and search files
            GetFileListRequest model = new GetFileListRequest
            {
                Type = "file",
                Limit = 10,
                Skip = 0
            };
            var res = imagekit.GetFileListRequest(model);
            #endregion

            #region GetFileDetail
            imagekit.GetFileDetail("fileId");

            #endregion

            #region  PurgeCache

            imagekit.PurgeCache("https://ik.imagekit.io/dnggmzz0v/default-image.jpg");

            #endregion

            #region  PurgeStatus


            imagekit.PurgeStatus("62e5778f31305bff3223b791");

            #endregion

            #region  Upload BY URI| Bytes | Base64


            // Upload By URI
            FileCreateRequest request = new FileCreateRequest
            {
                Url = new Uri(@"C:\test.jpg"),
                FileName = "test.jpg"
            };
            ResponseMetaData resp1 = imagekit.Upload(request);

            //Upload by bytes

            string base64 = "iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==";

            byte[] bytes = Convert.FromBase64String(base64);
            FileCreateRequest ob = new FileCreateRequest
            {
                Bytes = bytes,
                FileName = Guid.NewGuid().ToString()
            };

            ResponseMetaData resp2 = imagekit.Upload(ob);
            //Upload by Base64
            FileCreateRequest ob2 = new FileCreateRequest
            {
                Base64 = base64,
                FileName = Guid.NewGuid().ToString()
            };
            ResponseMetaData resp = imagekit.Upload(ob2);




            #endregion

            #region DeleteFile 

            imagekit.DeleteFile("fileId");

            #endregion

            #region BulkDeleteFiles

            List<string> ob3 = new List<string>();
            ob3.Add("fileId-1");
            ob3.Add("fileId-2");
            imagekit.BulkDeleteFiles(ob3);

            #endregion

            #region  GetFileMetadata
            imagekit.GetFileMetadata("fileId");
            #endregion

            #region  GetRemoteFileMetadata

            imagekit.GetRemoteFileMetadata("https://ik.imagekit.io/demo/medium_cafe_B1iTdD0C.jpg");


            #endregion

            #region  AddTags
            TagsRequest tagsRequest = new TagsRequest
            {
                Tags = new List<string>
                {
                    "tag1",
                    "tag2"
                },
                FileIds = new List<string>
                {
                    "field1"
                }
            };
            imagekit.AddTags(tagsRequest);

            #endregion

            #region  RemoveTags
            TagsRequest removeTagsRequest = new TagsRequest
            {
                Tags = new List<string>
                {
                    "tag1",
                    "tag2"
                },
                FileIds = new List<string>
                {
                    "field1"
                }
            };
            imagekit.RemoveTags(removeTagsRequest);

            #endregion

            #region  RemoveAITags
            AiTagsRequest removeAITagsRequest = new AiTagsRequest
            {
                AiTags = new List<string>
                {
                    "tag1",
                    "tag2"
                },
                FileIds = new List<string>
                {
                    "field1"
                }
            };
            imagekit.RemoveAiTags(removeAITagsRequest);

            #endregion

            #region  GetCustomMetaDataFields
            imagekit.GetCustomMetaDataFields(true);

            #endregion

            #region CreateCustomMetaDataFields

            CustomMetaDataFieldCreateRequest requestModel = new CustomMetaDataFieldCreateRequest
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

            requestModel.Schema = schema;
            imagekit.CreateCustomMetaDataFields(requestModel);

            #endregion

            #region UpdateCustomMetaDataFields

            CustomMetaDataFieldUpdateRequest requestUpdateModel = new CustomMetaDataFieldUpdateRequest
            {
                Id = "Tst3"
            };
            CustomMetaDataFieldSchemaObject updateschema = new CustomMetaDataFieldSchemaObject
            {
                Type = CustomMetaDataTypeEnum.Number,
                MinValue = 1000,
                MaxValue = 3000,
                MinLength = 500,
                MaxLength = 600,
                IsValueRequired = false
            };

            requestUpdateModel.Schema = schema;
            imagekit.UpdateCustomMetaDataFields(requestUpdateModel);

            #endregion

            #region DeleteFileVersionRequest
            DeleteFileVersionRequest delRequest = new DeleteFileVersionRequest
            {
                FileId = "fileId",
                VersionId = "versionId"
            };
            imagekit.DeleteFileVersion(delRequest);

            #endregion

            #region CopyFile

            CopyFileRequest cpyRequest = new CopyFileRequest
            {
                SourceFilePath = "Tst3",
                DestinationPath = "Tst3",
                IncludeFileVersions = true
            };
            imagekit.CopyFile(cpyRequest);

            #endregion

            #region MoveFile

            MoveFileRequest moveFile = new MoveFileRequest
            {
                SourceFilePath = "Tst3",
                DestinationPath = "Tst3"
            };
            imagekit.MoveFile(moveFile);
            #endregion

            #region RenameFile

            RenameFileRequest renameFileRequest = new RenameFileRequest
            {
                FilePath = "Tst3",
                NewFileName = "Tst4",
                PurgeCache = false
            };
            imagekit.RenameFile(renameFileRequest);


            #endregion

            #region RestoreFileVersion

            imagekit.RestoreFileVersion("abc", "1");

            #endregion

            #region CreateFolderRequest

            CreateFolderRequest createFolderRequest = new CreateFolderRequest
            {
                FolderName = "abc",
                ParentFolderPath = "source/folder/path"
            };
            imagekit.CreateFolder(createFolderRequest);

            #endregion

            #region DeleteFolderRequest

            DeleteFolderRequest deleteFolderRequest = new DeleteFolderRequest
            {
                FolderPath = "source/folder/path/new_folder"
            };
            imagekit.DeleteFolder(deleteFolderRequest);

            #endregion

            #region CopyFolder
            CopyFolderRequest cpyFolderRequest = new CopyFolderRequest
            {
                SourceFolderPath = "Tst3",
                DestinationPath = "Tst3",
                IncludeFileVersions = true
            };

            imagekit.CopyFolder(cpyFolderRequest);

            #endregion

            #region MoveFolder
            MoveFolderRequest moveFolderRequest = new MoveFolderRequest
            {
                SourceFolderPath = "Tst3",
                DestinationPath = "Tst3"

            };

            imagekit.MoveFolder(moveFolderRequest);

            #endregion

            #region GetBulkJobStatus

            imagekit.GetBulkJobStatus("jobId");

            #endregion

            #region GetFileVersions

            imagekit.GetFileVersions("fileId");

            #endregion

            #region GetFileVersionDetails

            imagekit.GetFileVersionDetails("fileId", "versionId");

            #endregion

        }

    }
}
