using System;
using System.IO.Compression;

namespace _06.Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"C:\Users\IvanV\Documents\C# Advanced - януари 2020\C# Advanced - януари 2020\04. CSharp-Advanced-Streams-Files-and-Directories", @"C:\Users\IvanV\source\repos\CSharp-Advanced-January2020\04. CSharp-Advanced-Streams-Files-and-Directories-Exercise\06.Zip-and-Extract\myArchive.zip");

            ZipFile.ExtractToDirectory(@"C:\Users\IvanV\source\repos\CSharp-Advanced-January2020\04. CSharp-Advanced-Streams-Files-and-Directories-Exercise\06.Zip-and-Extract\myArchive.zip", @"C:\Users\IvanV\Documents\C# Advanced - януари 2020\C# Advanced - януари 2020\04. CSharp-Advanced-Streams-Files-and-Directories\archive");
        }
    }
}
