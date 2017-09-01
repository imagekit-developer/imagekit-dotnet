using Imagekit.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Imagekit.Util.FormUpload;

namespace Imagekit
{
    public class Upload
    {
        //public void File()
        //{

        //}
        #region Public members

#region Picture upload
        public static ImagekitResponse Picture(string Imagepath, string folder, string filename,bool UseUniqueFileName=true)
        {
            var imageObject = GetImageFileParameter(Imagepath);
            var TimeStamp = Utils.ToUnixTime(DateTime.UtcNow);
            string Ser = string.Format("apiKey={0}&filename={1}&timestamp={2}", Secret.ApiKey, filename, TimeStamp);
            var Sign = Utils.EncodeHMACSHA1(Ser, Encoding.ASCII.GetBytes(Secret.ApiPrivate));

            var postParameters = new Dictionary<string, object>
            {

                {"folder" ,folder},
                {"apiKey" , Secret.ApiKey},
                {"useUniqueFilename",UseUniqueFileName.ToString() },
                { "filename",filename },
                { "timestamp",TimeStamp },
                { "signature",Sign},
                {"file", imageObject }
            };
            
                var response = FormUpload.MultipartFormDataPost(Secret.Address, postParameters);
                var encoding = ASCIIEncoding.ASCII;
                using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
                {
                    string responseText = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<ImagekitResponse>(responseText);
                }
                


            
            //catch (WebException wex)
            //{
            //    var msg = GetServerErrorMessage(wex);
            //}
        }
        public static ImagekitResponse Picture(byte[] Image, string folder, string filename, bool UseUniqueFileName = true)
        {
            var imageObject = GetImageFileParameter(Image);
            var TimeStamp = Utils.ToUnixTime(DateTime.UtcNow);
            string Ser = string.Format("apiKey={0}&filename={1}&timestamp={2}", Secret.ApiKey, filename, TimeStamp);
            var Sign = Utils.EncodeHMACSHA1(Ser, Encoding.ASCII.GetBytes(Secret.ApiPrivate));

            var postParameters = new Dictionary<string, object>
            {

                {"folder" ,folder},
                {"apiKey" , Secret.ApiKey},
                {"useUniqueFilename",UseUniqueFileName.ToString() },
                { "filename",filename },
                { "timestamp",TimeStamp },
                { "signature",Sign},
                {"file", imageObject }
            };

            var response = FormUpload.MultipartFormDataPost(Secret.Address, postParameters);
            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                string responseText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ImagekitResponse>(responseText);
            }
        }
        public static ImagekitResponse Picture(Uri Image, string folder, string filename, bool UseUniqueFileName = true)
        {
            var imageObject = GetImageFileParameter(Image);
            var TimeStamp = Utils.ToUnixTime(DateTime.UtcNow);
            string Ser = string.Format("apiKey={0}&filename={1}&timestamp={2}", Secret.ApiKey, filename, TimeStamp);
            var Sign = Utils.EncodeHMACSHA1(Ser, Encoding.ASCII.GetBytes(Secret.ApiPrivate));

            var postParameters = new Dictionary<string, object>
            {

                {"folder" ,folder},
                {"apiKey" , Secret.ApiKey},
                {"useUniqueFilename",UseUniqueFileName.ToString() },
                { "filename",filename },
                { "timestamp",TimeStamp },
                { "signature",Sign},
                {"file", imageObject }
            };

            var response = FormUpload.MultipartFormDataPost(Secret.Address, postParameters);
            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                string responseText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ImagekitResponse>(responseText);
            }
        }

        #endregion

        #endregion


        #region GetImages
        internal static FileParameter GetImageFileParameter(string imagePath)
        {
            var img = System.Drawing.Image.FromFile(imagePath);
            var ms = new MemoryStream();
            img.Save(ms, ImageFormat.Gif);
            var arr = ms.ToArray();
            string extention;
            try
            {
                var fi = new FileInfo(imagePath);
                extention = fi.Extension;
                if (string.IsNullOrEmpty(extention))
                    extention = "jpeg";
                else if (extention.Contains("."))
                    extention = extention.Replace(".", "");
            }
            catch (Exception)
            {
                extention = "jpeg";
            }
            var fileParam = new FileParameter(arr, "image", $"image/{extention}");
            return fileParam;
        }

        internal static FileParameter GetImageFileParameter(Uri URL)
        {
            var wc = new WebClient();
            Image x = Image.FromStream(wc.OpenRead(URL));
            var ms = new MemoryStream();
            x.Save(ms, ImageFormat.Gif);
            var arr = ms.ToArray();
            string extention = "jpeg";
            var fileParam = new FileParameter(arr, "image", $"image/{extention}");
            return fileParam;
        }

        internal static FileParameter GetImageFileParameter(byte[] arr)
        {
            string extention = "jpeg";
            var fileParam = new FileParameter(arr, "image", $"image/{extention}");
            return fileParam;
        }

        internal static string GetServerErrorMessage(WebException wex)
        {
            string error;
            if (wex.Response == null) return null;
            var errorResponse = (HttpWebResponse)wex.Response;
            var respnseStream = errorResponse.GetResponseStream();
            if (respnseStream == null) return null;
            using (var reader = new StreamReader(respnseStream))
            {
                error = reader.ReadToEnd();
                reader.Close();
            }
            return error;
        }
#endregion
    }
}
