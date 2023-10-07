using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using NUnit.Framework;
using System;

namespace RevitTest.Sample
{
    public class Tests_OpenDocument : OneTimeOpenDocumentTest
    {
        // protected override string FileName => "project.rvt";

        [Test]
        public void RevitTests_DocumentTitle()
        {
            Console.WriteLine(document.Title);
        }

        [TestCase("RevitTest")]
        [TestCase("Author")]
        public void RevitTests_TransactionAuthor(string author)
        {
            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("Change Author");
                document.ProjectInformation.Author = author;
                transaction.Commit();
            }
            Assert.AreEqual(author, document.ProjectInformation.Author);
        }

        [TestCase("RevitTest", ExpectedResult = "RevitTest")]
        [TestCase("ClientName", ExpectedResult = "ClientName")]
        public string RevitTests_TransactionClientName_Expected(string clientName)
        {
            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("Change ClientName");
                document.ProjectInformation.ClientName = clientName;
                transaction.Commit();
            }
            return document.ProjectInformation.ClientName;
        }
    }

    /// <summary>
    /// OneTimeOpenDocumentTest
    /// </summary>
    public class OneTimeOpenDocumentTest
    {
        protected Document document;
        protected Application application;
        protected virtual string FileName => null;

        [OneTimeSetUp]
        public void NewProjectDocument(Application application)
        {
            this.application = application;
            if (string.IsNullOrEmpty(FileName))
            {
                this.document = application.NewProjectDocument(UnitSystem.Metric);
                return;
            }
            this.document = application.OpenDocumentFile(FileName);
        }

        [OneTimeTearDown]
        public void CloseProjectDocument()
        {
            this.document.Close(false);
            this.document.Dispose();
        }

    }
}