using System;
using System.Collections.Generic;
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
            Upload.Picture(@"c:\\temp\\image.jpeg","/avatar/","Shit.jpg");
            Console.ReadLine();
        }
    }
}
