using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagekit.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionHelper.Initialize("JsksvaTlKfg+jO8aSWXL6sSE2RI=", "7T+zwkm/8XE1UwOz/H9t0Fx/qbM=","xeamo");
            
            var img = System.Drawing.Image.FromFile(@"c:\\temp\\image.jpeg");
            var ms = new MemoryStream();
            img.Save(ms, ImageFormat.Gif);
            var arr = ms.ToArray();
            Upload.Picture(arr, "/avatar/", "Shit.jpg");
            Console.ReadLine();
        }
    }
}
