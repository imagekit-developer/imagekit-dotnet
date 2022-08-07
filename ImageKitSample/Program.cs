using Imagekit.Sdk;
using System;
using Imagekit.Models;

namespace ImageKitSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
             
            //1  
            ImageKitClient imageKit = new ImageKitClient("TestPublicKey", "TestPrivateKey",
                "https://api.imageKit.io/");
            GetFileListRequest model=new GetFileListRequest();
            model.type = "file";
            model.limit = 10;
            model.skip = 0;
           var res= imageKit.GetFileListRequest(model);

            
            // imageKit.Instance.GetFileDetail("62d701678c8b75e43661d66d");
            // imageKit.PurgeCache("https://ik.imageKit.io/dnggmzz0v/default-image.jpg");
            // imageKit.PurgeStatus("62e5778f31305bff3223b791");
            //2  
            //FileCreateRequest ob = new FileCreateRequest();
            //ob.Url = new Uri(@"C:\test.jpg");
            //ob.FileName = "test.jpg";
            //imageKit.Upload(ob);
            //Console.WriteLine(ob.FileName);

            //3 
            //imageKit.Instance.DeleteFile("62d701678c8b75e43661d66d");

            //4
            //List<string> ob = new List<string>();
            //ob.Add("62d7f701408c558d6fc2999f");
            //ob.Add("62d7f3f64b0ef156ec137bbe");
            //imageKit.Instance.BulkDeleteFiles(ob);

            //5 
            //var res=  imageKit.Instance.GetFileMetadata("62d8f36909477610937bff1e");
            //6
            // var res = imageKit.Instance.GetRemoteFileMetadata("https://ik.imageKit.io/demo/medium_cafe_B1iTdD0C.jpg");

            //7
            // var Data = imageKit.Instance.GetCustomMetaDataFields(true);


            //8
            //CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest();
            //model.Name = "Tst3";
            //model.Label = "Test3";
            //CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject();
            //schema.SetType(CustomMetaDataTypeEnum.Number);
            //schema.SetMinValue(1000);
            //schema.SetMaxValue(3000);
            //model.Schema = schema;
            //imageKit.Instance.CreateCustomMetaDataFields(model);

            //9
            //CustomMetaDataFieldUpdateRequest model = new CustomMetaDataFieldUpdateRequest();

            //model.Id = "62dbbadb6f68334a5aeb1143";

            //CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject();
            //schema.SetType(CustomMetaDataTypeEnum.Number);
            //schema.SetMinValue(1000);
            //schema.SetMaxValue(3000);
            //model.Schema = schema;
            //imageKit.Instance.UpdateCustomMetaDataFields(model);

            //10
            //DeleteFileVersionRequest ob = new DeleteFileVersionRequest();
            //ob.SetFileId("62dc254f17bac74dfbbb474d");
            //ob.SetVersionId("62dc254f17bac74dfbbb474d");
            //imageKit.Instance.DeleteFileVersion(ob);

            //11
            //CopyFileRequest ob = new CopyFileRequest();
            //imageKit.Instance.CopyFile(ob);

            //12
            //DeleteFolderRequest ob = new DeleteFolderRequest();
            //ob.SetFolderPath("source/folder/path/new_folder");
            //imageKit.Instance.DeleteFolder(ob);

            //13
            //CreateFolderRequest ob = new CreateFolderRequest();
            //ob.FolderName="abc";
            //ob.ParentFolderPath="source/folder/path";
            //var content = JsonConvert.SerializeObject(ob);
            //imageKit.Instance.CreateFolder(ob);

            //
            /// Generating URLs
            //string path = "/default-image.jpg";
            //Transformation trans = new Transformation().Width(400).Height(300);
            //string imageURL = imageKit.Url(trans).Path(path).TransformationPosition("query").Generate();
            //Console.WriteLine("Url for first image transformed with height: 300, width: 400 - {0}", imageURL);


            ///// Generating Signed URL
            //var imgURL1 = "https://ik.imageKit.io/demo/default-image.jpg";
            //string[] queryParams = { "b=123", "a=test" };
            //try
            //{
            //    var signedUrl = imageKit.Url(new Transformation().Width(400).Height(300))
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

        }

        public static string EncodeTo64(string toEncode)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(toEncode + ":");
            string returnValue

                  = Convert.ToBase64String(plainTextBytes);

            return returnValue;

        }
        private static byte[] GetBase64()
        {
            string imagePath = @"C:\test.jpg";
            byte[] imageArray = System.IO.File.ReadAllBytes(imagePath);
            // base64ImageRepresentation = Convert.ToBase64String(imageArray);
            return imageArray;
        }

        private static Uri GetBase64URI(string imgPath)
        {
            var uri = new System.Uri(imgPath);
            return uri;
        }
    }
}
