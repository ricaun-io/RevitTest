using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RevitTest.Sample
{
    [TestFixtureSource(nameof(GetRevitFileNames))]
    public class Tests_OpenFileDocuments
    {
        private readonly string revitPathFile;
        public static IEnumerable<string> GetRevitFileNames()
        {
            var files = Directory.GetFiles(Folder, "*.rvt", SearchOption.AllDirectories);
            if (files.Length == 0)
            {
                return new[] { "No Revit files found in the folder." };
            }
            return files.Select(e => Path.GetFileName(e));
        }
        private static string Folder => Path.GetDirectoryName(typeof(Tests_OpenFileDocuments).Assembly.Location);
        public Tests_OpenFileDocuments(string revitFileName)
        {
            var files = Directory.GetFiles(Folder, revitFileName, SearchOption.AllDirectories);
            if (files.Length == 0)
            {
                throw new FileNotFoundException($"File not found: {revitFileName}");
            }
            this.revitPathFile = files[0];
        }

        public Document document;
        public Application application;

        [OneTimeSetUp]
        public void NewProjectDocument(Application application)
        {
            this.application = application;
            this.document = application.OpenDocumentFile(revitPathFile);
        }

        [Test]
        public void RevitTests_DocumentTitle()
        {
            Console.WriteLine(document.Title);
        }

        [OneTimeTearDown]
        public void CloseProjectDocument()
        {
            this.document.Close(false);
            this.document.Dispose();
        }
    }
}