using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RevitTest.Sample
{
    public class Tests_Files
    {
        public static IEnumerable<string> GetFileNames()
        {
            var folder = Directory.GetCurrentDirectory();
            return Directory.GetFiles(folder, "*RevitTest*.dll").Select(Path.GetFileName);
        }

        [TestCaseSource(nameof(GetFileNames))]
        public void TestFile(string fileName)
        {
            Console.WriteLine(fileName);
            Assert.True(true);
        }

        public static string[] GetRevitFileNames()
        {
            var downloadFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            return Directory.GetFiles(downloadFolder, "*.rvt");
        }

        [TestCaseSource(nameof(GetRevitFileNames))]
        public void TestRevitFile(string fileName)
        {
            Console.WriteLine(fileName);
            Assert.True(true);
        }
    }
}