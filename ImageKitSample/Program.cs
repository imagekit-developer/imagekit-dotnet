using Imagekit.Sdk;
using System;

namespace ImageKitSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // var token=  EncodeTo64("private_FguYxKgB8/Jm9Xs5ZyyLfwIBSFU=");
            //1  
            ImageKitClient ImageKit = new ImageKitClient("private_nkq6x30GzWj+MbQWG6cIxh20WZE=",
                "https://api.imagekit.io/");

            //ImageKit.Configuration.SetPrivateKey("private_FguYxKgB8/Jm9Xs5ZyyLfwIBSFU=");            
            // ImageKit.Instance.GetFileDetail("62d701678c8b75e43661d66d");
           // ImageKit.PurgeCache("https://ik.imagekit.io/dnggmzz0v/default-image.jpg");
            ImageKit.PurgeStatus("62e5778f31305bff3223b791");
            //2  
            //FileCreateRequest ob = new FileCreateRequest();
            //ob.Url = new Uri(@"C:\test.jpg");
            //ob.FileName = "test.jpg";
            //ImageKit.Upload(ob);
            //Console.WriteLine(ob.FileName);

            //3 
            //ImageKit.Instance.DeleteFile("62d701678c8b75e43661d66d");

            //4
            //List<string> ob = new List<string>();
            //ob.Add("62d7f701408c558d6fc2999f");
            //ob.Add("62d7f3f64b0ef156ec137bbe");
            //ImageKit.Instance.BulkDeleteFiles(ob);

            //5 
            //var res=  ImageKit.Instance.GetFileMetadata("62d8f36909477610937bff1e");
            //6
            // var res = ImageKit.Instance.GetRemoteFileMetadata("https://ik.imagekit.io/demo/medium_cafe_B1iTdD0C.jpg");

            //7
            // var Data = ImageKit.Instance.GetCustomMetaDataFields(true);


            //8
            //CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest();
            //model.Name = "Tst3";
            //model.Label = "Test3";
            //CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject();
            //schema.SetType(CustomMetaDataTypeEnum.Number);
            //schema.SetMinValue(1000);
            //schema.SetMaxValue(3000);
            //model.Schema = schema;
            //ImageKit.Instance.CreateCustomMetaDataFields(model);

            //9
            //CustomMetaDataFieldUpdateRequest model = new CustomMetaDataFieldUpdateRequest();

            //model.Id = "62dbbadb6f68334a5aeb1143";

            //CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject();
            //schema.SetType(CustomMetaDataTypeEnum.Number);
            //schema.SetMinValue(1000);
            //schema.SetMaxValue(3000);
            //model.Schema = schema;
            //ImageKit.Instance.UpdateCustomMetaDataFields(model);

            //10
            //DeleteFileVersionRequest ob = new DeleteFileVersionRequest();
            //ob.SetFileId("62dc254f17bac74dfbbb474d");
            //ob.SetVersionId("62dc254f17bac74dfbbb474d");
            //ImageKit.Instance.DeleteFileVersion(ob);

            //11
            //CopyFileRequest ob = new CopyFileRequest();
            //ImageKit.Instance.CopyFile(ob);

            //12
            //DeleteFolderRequest ob = new DeleteFolderRequest();
            //ob.SetFolderPath("source/folder/path/new_folder");
            //ImageKit.Instance.DeleteFolder(ob);

            //13
            //CreateFolderRequest ob = new CreateFolderRequest();
            //ob.FolderName="abc";
            //ob.ParentFolderPath="source/folder/path";
            //var content = JsonConvert.SerializeObject(ob);
            //ImageKit.Instance.CreateFolder(ob);

            //
            /// Generating URLs
            //string path = "/default-image.jpg";
            //Transformation trans = new Transformation().Width(400).Height(300);
            //string imageURL = ImageKit.Url(trans).Path(path).TransformationPosition("query").Generate();
            //Console.WriteLine("Url for first image transformed with height: 300, width: 400 - {0}", imageURL);


            ///// Generating Signed URL
            //var imgURL1 = "https://ik.imagekit.io/demo/default-image.jpg";
            //string[] queryParams = { "b=123", "a=test" };
            //try
            //{
            //    var signedUrl = ImageKit.Url(new Transformation().Width(400).Height(300))
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
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            return imageArray;
        }

        private static Uri GetBase64URI(string imgPath)
        {
            var uri = new System.Uri(imgPath);

            return uri;
        }
    }
}
