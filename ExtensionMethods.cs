using System;
using System.IO;

namespace WeirdCounting
{
    public static class ExtensionMethods
    {
        public static string[] ReadAllLines(this FileInfo fileInfo)
        {
        return File.ReadAllLines(fileInfo.FullName);
        }
    }
}