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
            ImageKitClient imageKit = new ImageKitClient("TestPublicKey", "TestPrivateKey", "https://api.imageKit.io/");
           // GetFileListRequest model=new GetFileListRequest();
           // model.type = "file";
           // model.limit = 10;
           // model.skip = 0;
           //var res= imageKit.GetFileListRequest(model);


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
                           RawTransformation("h-200).w-300).l-image).i-logo.png).l-end")
                           ;
            string imageURL = imageKit.Url(trans).Path(path).TransformationPosition("query").Generate();
            Console.WriteLine("Url for first image transformed with height: 300, width: 400 - {0}", imageURL);


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
