using System;
using Imagekit;
using Imagekit.Sdk;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ImagekitClient img = new ImagekitClient("dsadsa","dsadasd","dasdsad");
            img.GetFileDetail("url");
        }
    }
}
