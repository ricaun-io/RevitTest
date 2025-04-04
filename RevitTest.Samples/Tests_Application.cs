using Autodesk.Revit.ApplicationServices;
using NUnit.Framework;
using System;

namespace RevitTest.Sample
{
    public class Tests_Application : ApplicationTests
    {
        [Test]
        public void RevitTests_VersionName()
        {
            Assert.IsNotNull(application);
            Console.WriteLine(application.VersionName);
        }

        [Test]
        public void RevitTests_VersionBuild()
        {
            Assert.IsNotNull(application);
            Console.WriteLine(application.VersionBuild);
        }
    }

    public abstract class ApplicationTests
    {
        protected Application application;

        [OneTimeSetUp]
        public void Setup(Application application)
        {
            this.application = application;
        }
    }
}